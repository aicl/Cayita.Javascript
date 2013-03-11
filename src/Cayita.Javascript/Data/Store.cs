using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;

namespace Cayita.Javascript.Data
{

	[ScriptNamespace("Cayita.Data")]
	public class Store<T> :IList<T> where T: new()
	{
		List<T> st= new List<T>();
		Func<T, IDeferred<T>> createFunc;
		Func<ReadOptions,  IDeferred<T>> readFunc;
		Func<T, IDeferred<T>> updateFunc;
		Func<T, IDeferred<string>> destroyFunc;
		Func<T, IDeferred<T>> patchFunc;
		
		StoreApi<T> createApi;
		StoreApi<T> readApi;
		StoreApi<T> updateApi;
		StoreApi<string> destroyApi;
		StoreApi<T> patchApi;
		ReadOptions lastOption;

		int defaultPageSize=10;

		int totalCount=0;

		string idProperty="Id";
		
		public Store()
		{
			OnStoreChanged=(store, data)=>{};
			OnStoreError=(store, request)=>{};
			OnStoreRequest=(store, state )=>{};

			createApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/create"};
			readApi= new StoreApi<T>{Url= "api/" + typeof(T).Name+"/read"};
			updateApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/update"};
			destroyApi = new StoreApi<string>{Url= "api/" + typeof(T).Name+"/destroy"};
			patchApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/patch"};
			lastOption= new ReadOptions();

			createFunc= (record)=>{	
				OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Create, State=StoreRequestState.Started});
				return jQuery.PostRequest<T>(createApi.Url, record, cb=>{} ,createApi.DataType)
					.Done(scb=>{
						var r = createApi.DataProperty;
						dynamic data = (dynamic) scb;
						if (((object) data[r]).IsArray())
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								st.Add(item);
								OnStoreChanged(this, new StoreChangedData<T>{ NewData= item, OldData=item, Action= StoreChangedAction.Created});
							}
						}
						else
						{
							st.Add((T)data[r]);
							OnStoreChanged(this, new StoreChangedData<T>{ NewData= (T)data[r], OldData=(T)data[r], Action= StoreChangedAction.Created});
						}

					})
						.Fail(f=>{
							OnStoreError(this, new StoreError<T>{Action=StoreErrorAction.Create, Request= f as jQueryDataHttpRequest<T>});
						})
						.Always(t=>{
							OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Create, State=StoreRequestState.Finished});
						});
			};

			readFunc= ( readOptions)=>{	
				OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Read, State=StoreRequestState.Started});
				return jQuery.GetData<T>(readApi.Url, RequestObject(readOptions),cb=>{},readApi.DataType)
					.Done(scb=>{
						var r = readApi.DataProperty;
						dynamic data = (dynamic) scb;

						if (((object) data[r]).IsArray())
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								foreach(var kv in readApi.Converters)
								{
									((dynamic)item)[kv.Key]= kv.Value(item);
								}
								st.Add(item);
							}
						}
						else
						{
							st.Add((T)data[r]);
						}

						int? tc = data[readApi.TotalCountProperty];
						totalCount= tc.HasValue? tc.Value: st.Count;

						OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});
					})
						.Fail(f=>{
							OnStoreError(this, new StoreError<T>{Action=StoreErrorAction.Read,	Request= f as jQueryDataHttpRequest<T>});
						}).Always(f=>{
							OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Read, State=StoreRequestState.Finished});
						});

			};


			updateFunc= (record)=>{	
				OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Update, State=StoreRequestState.Started});
				return jQuery.PostRequest<T>(updateApi.Url, record, cb=>{},updateApi.DataType)
					.Done(scb=>{
						var r = updateApi.DataProperty;
						dynamic data = (dynamic) scb;

						if (((object) data[r]).IsArray())
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								dynamic i = (dynamic)item;
								var ur =st.First( f=> ((dynamic)f)[idProperty]== i[idProperty]);
								var old = new T();
								old.PopulateFrom(ur);
								ur.PopulateFrom(item);
								OnStoreChanged(this, new StoreChangedData<T>{ NewData= ur, OldData=old, Action= StoreChangedAction.Updated});
							}
						}
						else
						{
							dynamic i = (dynamic)data[r];
							var ur =st.First( f=> ((dynamic)f)[idProperty]== i[idProperty]);
							var old = new T();
							old.PopulateFrom(ur);
							ur.PopulateFrom((T)data[r]);
							OnStoreChanged(this, new StoreChangedData<T>{ NewData= ur, OldData=old, Action= StoreChangedAction.Updated});
						}
					})
						.Fail(f=>{
							OnStoreError(this, new StoreError<T>{Action=StoreErrorAction.Update, Request= f as jQueryDataHttpRequest<T>});
						}).Always(f=>{
							OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Update, State=StoreRequestState.Finished});
						});
			};

			destroyFunc= (record)=>{	
				OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Destroy, State=StoreRequestState.Started});
				var req = (dynamic) new {};
				req[idProperty]=((dynamic)record)[idProperty];
				return jQuery.PostRequest<string>(destroyApi.Url, (object)req, cb=>{},destroyApi.DataType)
					.Done(scb=>{
						var dr =st.First( f=> ((dynamic)f)[idProperty]== ((dynamic)record)[idProperty]);
						st.Remove(dr);
						OnStoreChanged(this, new StoreChangedData<T>{ NewData= dr, OldData=dr, Action= StoreChangedAction.Destroyed});
					}).Fail(f=>{
						OnStoreError(this, new StoreError<T>{Action=StoreErrorAction.Destroy, Request= f as jQueryDataHttpRequest<T>});
					}).Always(f=>{
						OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Destroy, State=StoreRequestState.Finished});
					});
			};


			patchFunc= (record)=>{

				OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Patch, State=StoreRequestState.Started});
				return jQuery.PostRequest<T>(patchApi.Url, record, cb=>{},patchApi.DataType)
					.Done(scb=>{	
						var r = updateApi.DataProperty;
						dynamic data = (dynamic) scb;

						if ( data[r].IsArray())
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								dynamic i = (dynamic)item;
								var ur =st.First( f=> ((dynamic)f)[idProperty]== i[idProperty]);
								var old = new T();
								old.PopulateFrom(ur);
								ur.PopulateFrom(item);
								OnStoreChanged(this, new StoreChangedData<T>{ NewData= ur, OldData=old, Action= StoreChangedAction.Patched});
							}
						}
						else
						{
							dynamic i = (dynamic)data[r];
							var ur =st.First( f=> ((dynamic)f)[idProperty]== i[idProperty]);
							var old = new T();
							old.PopulateFrom(ur);
							ur.PopulateFrom((T)data[r]);
							OnStoreChanged(this, new StoreChangedData<T>{ NewData= ur, OldData=old, Action= StoreChangedAction.Patched});
						}
					}).Fail(f=>{
						OnStoreError(this, new StoreError<T>{Action=StoreErrorAction.Patch, Request= f as jQueryDataHttpRequest<T>});
					}).Always(f=>{
						OnStoreRequest(this, new StoreRequest{Action=StoreRequestAction.Patch, State=StoreRequestState.Finished});
					});
			};

		}


		public Store<T> SetIdProperty(string value )
		{
			idProperty=value;
			return this;
		}

		public string GetRecordIdProperty()
		{
			return idProperty;
		}

		public int GetTotalCount()
		{
			return totalCount;
		}

		public Store<T> SetCreateFunc(Func< T, IDeferred<T>> createFunc)
		{
			this.createFunc=createFunc; 
			return this;
		}

		public Store<T> SetReadFunc(Func<ReadOptions, IDeferred<T>> readFunc)
		{
			this.readFunc=readFunc; 
			return this;
		}

		public Store<T> SetUpdateFunc(Func<T,IDeferred<T>> updateFunc)
		{
			this.updateFunc=updateFunc;
			return this;
		}

		public Store<T> SetDestroyFunc(Func<T, IDeferred<string>> destroyFunc)
		{
			this.destroyFunc=destroyFunc;
			return this;
		}

		public Store<T> SetPatchFunc(Func<T,IDeferred<T>> patchFunc)
		{
			this.patchFunc=patchFunc;
			return this;
		}

		public Store<T> SetCreateApi( Action<StoreApi<T>> api)
		{
			api(createApi);
			return this;
		}

		public Store<T> SetReadApi( Action<StoreApi<T>> api)
		{
			api(readApi);
			return this;
		}


		public Store<T> SetUpdateApi( Action<StoreApi<T>> api)
		{
			api(updateApi);
			return this;
		}

		public Store<T> SetDestroyApi( Action<StoreApi<string>> api)
		{
			api(destroyApi);
			return this;
		}

		public Store<T> SetPatchApi( Action<StoreApi<T>> api)
		{
			api(patchApi);
			return this;
		}



		public void Create(Action<T> config){
			var record = new T();
			config(record);
			Create(record);
		}
		
		public void Create(T record)
		{
			createFunc(record);
		}
		
		public void Create(FormElement form)
		{
			var record = new T();
			form.LoadTo(record);
			Create(record);
		}


		public IDeferred<T> Read(Action<ReadOptions> options=null)
		{
			if(options!=null) options(lastOption);
			if(lastOption.PageNumber.HasValue &&
			   ( !lastOption.PageSize.HasValue || (lastOption.PageSize.HasValue &&lastOption.PageSize.Value==0) ) )
				lastOption.PageSize= defaultPageSize;

			return  readFunc( lastOption); 
		}

		public IDeferred<T> Update(T record)
		{
			return updateFunc(record);
		}

		public IDeferred<string> Destroy(Action<T> config)
		{
			T record= new T();
			config(record);
			return destroyFunc( record);
		}


		public IDeferred<T> Patch(T record)
		{
			return patchFunc(record);
		}

		public object RequestObject(ReadOptions readOptions){
			dynamic ro = new {};
			if(!string.IsNullOrEmpty(readOptions.OrderBy)) ro[readOptions.OrderByParam]= readOptions.OrderBy;
			if(!string.IsNullOrEmpty(readOptions.OrderType)) ro[readOptions.OrderTypeParam]= readOptions.OrderType;
			if (! readOptions.LocalPaging) {
				if(readOptions.PageNumber.HasValue) ro[readOptions.PageNumberParam]= readOptions.PageNumber;
				if(readOptions.PageSize.HasValue) ro[readOptions.PageSizeParam]= readOptions.PageSize;
			}

			((object)(ro)).PopulateFrom((object)readOptions.Request);
			
			return ro;
		}
		
		#region IList implementation
		public int IndexOf (T item)
		{
			return st.IndexOf(item);
		}			
		
		public void Insert (int index, T item)
		{
			st.Insert(index, item);
			OnStoreChanged(this, new StoreChangedData<T>{ NewData= item, OldData=item, Action= StoreChangedAction.Inserted, Index= index});
		}			
		public void RemoveAt (int index)
		{
			var item = this[index];
			st.RemoveAt(index);
			OnStoreChanged(this, new StoreChangedData<T>{ NewData= item, OldData=item, Action= StoreChangedAction.Removed, Index= index});
		}			
		public T this [int index] {
			get {
				return st[index];
			}
			set {
				st[index]=value;
			}
		}			
		#endregion			

		public void Replace(object recordId, Action<T> record)
		{
			var self=this;
			var source =st.First( f=>( (object)((dynamic)f)[self.idProperty]).ToString()== recordId.ToString());
			var index = st.IndexOf(source);
			var old = source.Clone();
			record(source);
			OnStoreChanged(this, new StoreChangedData<T>{ NewData= source, OldData=old, Action= StoreChangedAction.Replaced, Index= index});
		}

		public void Replace(T record)
		{
			var self=this;
			var source =st.First( f=>( (object)((dynamic)f)[self.idProperty]).ToString()==((object)((dynamic)record)[self.idProperty]).ToString() );
			var index = st.IndexOf(source);
			var old = source.Clone();
			source.PopulateFrom(record);
			OnStoreChanged(this, new StoreChangedData<T>{ NewData= source, OldData=old, Action= StoreChangedAction.Replaced, Index= index});
		}

		#region ICollection implementation			
		
		public int Count
		{
			get 
			{
				return 
				(lastOption!=null && lastOption.LocalPaging && lastOption.PageSize.HasValue
					 && lastOption.PageSize.Value<st.Count)?
					lastOption.PageSize.Value:
					st.Count;
			}
		}
		
		public void Add (T item)
		{
			st.Add(item);
			OnStoreChanged(this, new StoreChangedData<T>{ NewData= item, OldData=item, Action= StoreChangedAction.Added, Index=st.Count-1});
		}

		public void Clear ()
		{
			st.Clear();
			OnStoreChanged(this, new StoreChangedData<T>{ Action=StoreChangedAction.Cleared });
		}
		public bool Contains (T item)
		{
			return st.Contains(item);
		}
		
		public bool Remove (T item)
		{
			var index = st.IndexOf(item);
			var r =  st.Remove(item);
			if(r) OnStoreChanged(this, new StoreChangedData<T>{ OldData=item, NewData=item, Action=StoreChangedAction.Removed, Index=index });
			return r;
		}
		#endregion
		#region IEnumerable implementation			
		public IEnumerator<T> GetEnumerator ()
		{
			var lo = lastOption;
			if(lo.LocalPaging && lo.PageNumber.HasValue && lo.PageSize.HasValue)
			{
				return st.Skip(lo.PageNumber.Value*lo.PageSize.Value).
					Take(lo.PageSize.Value).GetEnumerator();
			}

			return st.GetEnumerator();
		}
		#endregion			
		#region IEnumerable implementation			
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			var lo = lastOption;
			if(lo.LocalPaging && lo.PageNumber.HasValue && lo.PageSize.HasValue)
			{
				return st.Skip(lo.PageNumber.Value*lo.PageSize.Value).
					Take(lo.PageSize.Value).GetEnumerator();
			}
			return st.GetEnumerator();
		}
#endregion

		public void  Load(IList<T> data, Action<ReadOptions> options=null, bool append=false)
		{

			if(options!=null) options(lastOption);
			if(lastOption.PageNumber.HasValue &&
			   ( !lastOption.PageSize.HasValue || (lastOption.PageSize.HasValue &&lastOption.PageSize.Value==0) ) )
				lastOption.PageSize= defaultPageSize;

			if(!append )st.Clear();
			st.AddRange(data);
			OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Loaded});
		}

		public ReadOptions GetLastOption()
		{
			return lastOption;
		}

		public int GetDefaultPageSize()
		{
			return defaultPageSize;
		}

		public void SetDefaultPageSize(int value)
		{
			defaultPageSize=value;
		}

		public bool HasNextPage()
		{
			if (Count== totalCount || !lastOption.PageNumber.HasValue) return false;
			return totalCount/lastOption.PageSize.Value> lastOption.PageNumber.Value;

		}

		public bool HasPreviousPage()
		{
			return !( Count== totalCount || !lastOption.PageNumber.HasValue
			        || ( lastOption.PageNumber.HasValue && lastOption.PageNumber.Value==0)) ;
		}


		public void GetFirstPage ()
		{
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = 0;

			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});

		}

		public void GetNextPage()
		{
			if(HasNextPage())
				lastOption.PageNumber++;
			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});
		}

		public void GetPreviousPage()
		{
			if(HasPreviousPage()) lastOption.PageNumber--;

			if (!lastOption.LocalPaging)  
				readFunc( lastOption);
			else 
				OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});
		}

		public void GetLastPage ()
		{
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = totalCount/lastOption.PageSize.Value;
			
			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});
		}

		public void GetPage(int page)
		{
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = page< 0?
					0:
					page>totalCount/lastOption.PageSize.Value?
					totalCount/lastOption.PageSize.Value:
					page;

			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});

		}

		public IDeferred<T> Refresh()
		{
			return readFunc( lastOption);
		}

		public event Action<Store<T> , StoreChangedData<T> > OnStoreChanged;
		public event Action<Store<T> , StoreError<T>> OnStoreError;
		public event Action<Store<T> , StoreRequest> OnStoreRequest;

	}

	[ScriptNamespace("Cayita.Data")]
	[Serializable]
	public class StoreChangedData<T>
	{
		protected internal StoreChangedData(){}
		public  T NewData {get; set;}
		public  T OldData {get; set;}
		public StoreChangedAction Action {get;set;}
		public int Index {get;set;}
	}

	public enum StoreChangedAction{
		Created,
		Read,
		Updated,
		Destroyed,
		Patched,

		Added,
		Inserted,
		Replaced,
		Removed,
		Cleared,
		Loaded
	}

	[ScriptNamespace("Cayita.Data")]
	[Serializable]
	public class StoreError<T>
	{
		protected internal StoreError(){}
		public StoreErrorAction Action {get;set;}
		public jQueryDataHttpRequest<T> Request{get;set;}

	}
	
	public enum StoreErrorAction{
		Create,
		Read,
		Update,
		Destroy,
		Patch
	}
	
	[ScriptNamespace("Cayita.Data")]
	[Serializable]
	public class StoreRequest
	{
		protected internal StoreRequest(){}
		public StoreRequestAction Action {get;set;}
		public StoreRequestState State {get;set;}
	}
	
	public enum StoreRequestAction{
		Create,
		Read,
		Update,
		Destroy,
		Patch
	}

	public enum StoreRequestState{
		Started,
		Finished
	}

}

