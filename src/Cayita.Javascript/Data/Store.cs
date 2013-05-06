using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;
using Cayita.UI;
namespace Cayita.Data
{

	public class Store<T> :IList<T> where T: new()
	{
		List<T> st= new List<T>();
		Func<T, IDeferred<T>> createFunc;
		Func<ReadOptions,  IDeferred<T>> readFunc;
		Func<T, IDeferred<T>> updateFunc;
		Func<T, IDeferred<string>> destroyFunc;
		Func<T, IDeferred<T>> patchFunc;

		Func<T, bool> filterFunc = d => true;

		StoreApi<T> createApi=new StoreApi<T>{Url= "api/" + typeof(T).Name+"/create"};
		StoreApi<T> readApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/read"};
		StoreApi<T> updateApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/update"};
		StoreApi<string> destroyApi = new StoreApi<string>{Url= "api/" + typeof(T).Name+"/destroy"};
		StoreApi<T> patchApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/patch"};
		ReadOptions lastOption= new ReadOptions();

		int defaultPageSize=10;

		int totalCount=0;

		string idProperty="Id";
		
		public Store()
		{

			createFunc= (record)=>{	
				StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Create, State=StoreRequestedState.Started});
				var req= jQuery.PostRequest<T>(createApi.Url, record, cb=>{} ,createApi.DataType);
				req.Done(scb=>{
					var r = createApi.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if (((object) res).IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							st.Add(item);
							OnStoreChanged( item, item,  StoreChangedAction.Created);
						}
					}
					else
					{
						st.Add((T)res);
						OnStoreChanged((T)res, (T)res, StoreChangedAction.Created);
					}

				});
				req.Fail(f=>{
					StoreError(this, new StoreErrorData<T>{Action=StoreErrorAction.Create, Request=req});
				});

				req.Always(t=>{
					StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Create, State=StoreRequestedState.Finished});
				});

				return req;
			};

			readFunc= ( readOptions)=>{	
				StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Read, State=StoreRequestedState.Started});
				var req = jQuery.GetData<T>(readApi.Url, (object)readOptions.GetRequestObject() ,cb=>{},readApi.DataType);
				req.Done(scb=>{
					var r = readApi.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if (((object) res).IsArray())
					{
						foreach (var item in ((IList<T>) res))
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
						st.Add((T)res);
					}

					int? tc = data[readApi.TotalCountProperty];
					totalCount= tc.HasValue? tc.Value: st.Count(filterFunc);

					OnStoreChanged( StoreChangedAction.Read);
				});
				req.Fail(f=>{
					StoreError(this, new StoreErrorData<T>{Action=StoreErrorAction.Read, Request=req});
				});
				req.Always(f=>{
					StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Read, State=StoreRequestedState.Finished});
				});
				return req;
			};


			updateFunc= (record)=>{	
				StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Update, State=StoreRequestedState.Started});
				var req= jQuery.PostRequest<T>(updateApi.Url, record, cb=>{},updateApi.DataType);
				req.Done(scb=>{
					var r = updateApi.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if (((object) res).IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							var ur =st.First( f=> f.Get(idProperty)== item.Get(idProperty));
							var old = new T();
							old.PopulateFrom(ur);
							ur.PopulateFrom(item);
							OnStoreChanged(ur, old, StoreChangedAction.Updated);
						}
					}
					else
					{
						var ur =st.First( f=> f.Get(idProperty)== res.Get(idProperty));
						var old = new T();
						old.PopulateFrom(ur);
						ur.PopulateFrom((T)res);
						OnStoreChanged(ur, old, StoreChangedAction.Updated);
					}
				});
				req.Fail(f=>{
					StoreError(this, new StoreErrorData<T>{Action=StoreErrorAction.Update, Request=req});
				});
				req.Always(f=>{
					StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Update, State=StoreRequestedState.Finished});
				});
				return req;
			};

			destroyFunc= (record)=>{	
				StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Destroy, State=StoreRequestedState.Started});
				var data = (dynamic) new {};
				data[idProperty]=record.Get(idProperty);
				var req= jQuery.PostRequest<string>(destroyApi.Url, (object)data, cb=>{},destroyApi.DataType);
				req.Done(scb=>{
					var dr =st.First( f=> f.Get(idProperty)== record.Get(idProperty));
					st.Remove(dr);
					OnStoreChanged(dr, dr, StoreChangedAction.Destroyed);
				});
				req.Fail(f=>{
					StoreError(this, new StoreErrorData<T>{Action=StoreErrorAction.Destroy});
				});
				req.Always(f=>{
					StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Destroy, State=StoreRequestedState.Finished});
				});
				return req;
			};


			patchFunc= (record)=>{

				StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Patch, State=StoreRequestedState.Started});
				var req= jQuery.PostRequest<T>(patchApi.Url, record, cb=>{},patchApi.DataType);
				req.Done(scb=>{	
					var r = updateApi.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if ( res.IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							var ur =st.First( f=> f.Get(idProperty)== item.Get(idProperty));
							var old = new T();
							old.PopulateFrom(ur);
							ur.PopulateFrom(item);
							OnStoreChanged(ur, old, StoreChangedAction.Patched);
						}
					}
					else
					{
						var ur =st.First( f=> f.Get(idProperty)== res.Get(idProperty));
						var old = new T();
						old.PopulateFrom(ur);
						ur.PopulateFrom((T)res);
						OnStoreChanged(ur, old,StoreChangedAction.Patched);
					}
				});
				req.Fail(f=>{
					StoreError(this, new StoreErrorData<T>{Action=StoreErrorAction.Patch, Request=req});
				});
				req.Always(f=>{
					StoreRequested(this, new StoreRequestedData{Action=StoreRequestedAction.Patch, State=StoreRequestedState.Finished});
				});
				return req;
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


		public virtual IDeferred<T> Read(Action<ReadOptions> options=null, bool clear=true)
		{
			if(clear) st.Clear();

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

		
		#region IList implementation
		public int IndexOf (T item)
		{
			return st.IndexOf(item);
		}			
		
		public void Insert (int index, T item)
		{
			st.Insert(index, item);
			OnStoreChanged(item, item, StoreChangedAction.Inserted, index);
		}			
		public void RemoveAt (int index)
		{
			var item = this[index];
			st.RemoveAt(index);
			OnStoreChanged(item, item, StoreChangedAction.Removed, index);
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
			var source = st.First (f => f.Get (self.idProperty).ToString () == recordId.ToString ());
			var index = st.IndexOf(source);
			var old = source.Clone();
			record(source);
			OnStoreChanged(source,old, StoreChangedAction.Replaced, index);
		}

		public void Replace(T record)
		{
			var self=this;
			var source = st.First (f => f.Get (self.idProperty).ToString () == record.Get (self.idProperty).ToString ());
			var index = st.IndexOf(source);
			var old = source.Clone();
			source.PopulateFrom(record);
			OnStoreChanged(source, old, StoreChangedAction.Replaced, index);
		}

		#region ICollection implementation			
		
		public int Count
		{
			get 
			{
				return 
				(lastOption!=null && lastOption.LocalPaging && lastOption.PageSize.HasValue
					 && lastOption.PageSize.Value<st.Count(filterFunc))?
					lastOption.PageSize.Value:
					st.Count(filterFunc);
			}
		}
		
		public void Add (T item)
		{
			st.Add(item);
			OnStoreChanged (item, item, StoreChangedAction.Added, GetTotalCount () - 1);
		}

		public void Clear ()
		{
			st.Clear();
			OnStoreChanged (StoreChangedAction.Cleared);
		}
		public bool Contains (T item)
		{
			return st.Contains(item);
		}
		
		public bool Remove (T item)
		{
			var index = st.IndexOf(item);
			var r =  st.Remove(item);
			if (r) 
				OnStoreChanged (item, item, StoreChangedAction.Removed, index);
			return r;
		}
		#endregion
		#region IEnumerable implementation			
		public IEnumerator<T> GetEnumerator ()
		{
			var lo = lastOption;
			if(lo.LocalPaging && lo.PageNumber.HasValue && lo.PageSize.HasValue)
			{
				return st.Where(filterFunc).Skip(lo.PageNumber.Value*lo.PageSize.Value).
					Take(lo.PageSize.Value).GetEnumerator();
			}

			return st.Where(filterFunc).GetEnumerator();
		}
		#endregion			
		#region IEnumerable implementation			
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			var lo = lastOption;
			if(lo.LocalPaging && lo.PageNumber.HasValue && lo.PageSize.HasValue)
			{
				return st.Where(filterFunc).Skip(lo.PageNumber.Value*lo.PageSize.Value).
					Take(lo.PageSize.Value).GetEnumerator();
			}
			return st.Where(filterFunc).GetEnumerator();
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
			totalCount = st.Count (filterFunc);
			OnStoreChanged (StoreChangedAction.Loaded);
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
			return  lastOption.PageNumber.Value + 1 < GetPagesCount ();
		}

		public bool HasPreviousPage()
		{
			return !( Count== totalCount || !lastOption.PageNumber.HasValue
			        || ( lastOption.PageNumber.HasValue && lastOption.PageNumber.Value==0)) ;
		}


		public void ReadFirstPage ()
		{
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = 0;

			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged (StoreChangedAction.Read);

		}

		public void ReadNextPage(bool checkForNext=true)
		{
			if (checkForNext && !HasNextPage ())
				return;

			lastOption.PageNumber++;
			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged (StoreChangedAction.Read);
		}

		public void ReadPreviousPage(bool checkForPrevious=true)
		{
			if (checkForPrevious && !HasPreviousPage ())
				return;

			lastOption.PageNumber--;

			if (!lastOption.LocalPaging)  
				readFunc (lastOption);
			else 
				OnStoreChanged (StoreChangedAction.Read);
		}

		public void ReadLastPage ()
		{
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = GetPagesCount () - 1;
			
			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged (StoreChangedAction.Read);
		}

		public void ReadPage(int page)
		{
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = page< 0?
					0:
					page>= GetPagesCount()?
					GetPagesCount()-1:
					page;

			if (!lastOption.LocalPaging)
				readFunc (lastOption);
			else
				OnStoreChanged (StoreChangedAction.Read);

		}

		public int GetPagesCount()
		{
			return (int) Math.Ceiling( (decimal) totalCount  /
			                    ((decimal)( lastOption.PageSize.HasValue ? lastOption.PageSize.Value: st.Count ) ));
		}


		public IDeferred<T> Refresh()
		{
			return readFunc( lastOption);
		}

		public void Filter(Func<T, bool> filter)
		{
			filterFunc = filter;
			totalCount = st.Count (filterFunc);
			if (lastOption.PageNumber.HasValue)
				lastOption.PageNumber = 0;
			StoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Filtered});
		}

		public event Action<Store<T> , StoreChangedData<T> > StoreChanged = (st, d) => {};
		public event Action<Store<T> , StoreErrorData<T>> StoreError = (st, d) => {};
		public event Action<Store<T> , StoreRequestedData> StoreRequested = (st, d) => {};

		protected void OnStoreChanged(T newData, T oldData, StoreChangedAction action, int index=0)
		{
			StoreChanged (this, new StoreChangedData<T>{NewData=newData, OldData=oldData, Action=action, Index=index});
		}

		protected void OnStoreChanged(StoreChangedAction action)
		{
			StoreChanged (this, new StoreChangedData<T>{Action=action});
		}

	}

	[ScriptNamespace("Cayita.Data")]
	[Serializable]
	public class StoreChangedData<T>
	{
		protected internal StoreChangedData(){}
		public  T NewData {get; set;}
		public  T OldData {get; set;}
		public StoreChangedAction Action { get; set; }
		public int Index { get; set; }
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
		Loaded,
		Filtered
	}

	[ScriptNamespace("Cayita.Data")]
	[Serializable]
	public class StoreErrorData<T>
	{
		protected internal StoreErrorData(){}
		public StoreErrorAction Action { get; set; }
		public jQueryDataHttpRequest<T> Request{ get; set; }

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
	public class StoreRequestedData
	{
		protected internal StoreRequestedData(){}
		public StoreRequestedAction Action { get; set; }
		public StoreRequestedState State { get; set; }
	}
	
	public enum StoreRequestedAction{
		Create,
		Read,
		Update,
		Destroy,
		Patch
	}

	public enum StoreRequestedState{
		Started,
		Finished
	}

}

