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
		// string = url; T object (filter, record);  type:=json, html text
		Func<string, T,  string, jQueryDataHttpRequest<T>> createFunc;
		Func<string, ReadOptions,  string, jQueryDataHttpRequest<T>> readFunc;
		Func<string, T,  string, jQueryDataHttpRequest<T>> updateFunc;
		Func<string, T,  string, jQueryDataHttpRequest<string>> destroyFunc;
		Func<string, T,  string, jQueryDataHttpRequest<T>> patchFunc;
		
		StoreApi<T> createApi;
		StoreApi<T> readApi;
		StoreApi<T> updateApi;
		StoreApi<string> destroyApi;
		StoreApi<T> patchApi;

		string idProperty="Id";
		
		public Store()
		{
			OnStoreChanged=(store, data)=>{};
			OnStoreError=(store, request)=>{};

			createApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/create"};
			readApi= new StoreApi<T>{Url= "api/" + typeof(T).Name+"/read"};
			updateApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/update"};
			destroyApi = new StoreApi<string>{Url= "api/" + typeof(T).Name+"/destroy"};
			patchApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/patch"};

			createFunc= (url, record,  type)=>{	
				return jQuery.PostRequest<T>(url, record, cb=>{} ,type)
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

					});
			};

			readFunc= (url, readOptions,  type)=>{	
				return jQuery.GetData<T>(url, RequestObject(readOptions),cb=>{},type)
					.Done(scb=>{
						var r = readApi.DataProperty;
						dynamic data = (dynamic) scb;

						if (((object) data[r]).IsArray())
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								st.Add(item);
							}
						}
						else
						{
							st.Add((T)data[r]);
						}
						OnStoreChanged(this, new StoreChangedData<T>{ Action= StoreChangedAction.Read});
					})
						.Fail(f=>{
							OnStoreError(this, new StoreError<T>{
								Action=StoreErrorAction.Read, 
								Request=  f as jQueryDataHttpRequest<T>
							});
						}).Always(f=>{

						});

			};


			updateFunc= (url, record,  type)=>{	
				return jQuery.PostRequest<T>(url, record, cb=>{},type)
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
					});
			};

			destroyFunc= (url, record,  type)=>{	
				var req = (dynamic) new {};
				req[idProperty]=((dynamic)record)[idProperty];
				return jQuery.PostRequest<string>(url, (object)req, cb=>{},type)
					.Done(scb=>{
						var dr =st.First( f=> ((dynamic)f)[idProperty]== ((dynamic)record)[idProperty]);
						st.Remove(dr);
						OnStoreChanged(this, new StoreChangedData<T>{ NewData= dr, OldData=dr, Action= StoreChangedAction.Destroyed});
					});
			};


			patchFunc= (url, record,  type)=>{

				return jQuery.PostRequest<T>(url, record, cb=>{},type)
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
					});
			};

		}


		public void SetIdProperty(string value )
		{
			idProperty=value;
		}

		public string GetRecordIdProperty()
		{
			return idProperty;
		}

		public void SetCreateFunc(Func<string, T,  string, jQueryDataHttpRequest<T>> createFunc)
		{
			this.createFunc=createFunc; 
		}

		public void SetReadFunc(Func<string, ReadOptions,  string , jQueryDataHttpRequest<T>> readFunc)
		{
			this.readFunc=readFunc; 
		}

		public void SetUpdateFunc(Func<string, T,   string , jQueryDataHttpRequest<T>> updateFunc)
		{
			this.updateFunc=updateFunc;
		}

		public void SetDestroyFunc(Func<string, T,  string , jQueryDataHttpRequest<string>> destroyFunc)
		{
			this.destroyFunc=destroyFunc;
		}

		public void SetPatchFunc(Func<string, T,   string , jQueryDataHttpRequest<T>> patchFunc)
		{
			this.patchFunc=patchFunc;
		}

		public void SetCreateApi( Action<StoreApi<T>> api)
		{
			api(createApi);
		}

		public void SetReadApi( Action<StoreApi<T>> api)
		{
			api(readApi);
		}

		public StoreApi<T> GetReadApi( )
		{
			return readApi;
		}

		public void SetUpdateApi( Action<StoreApi<T>> api)
		{
			api(updateApi);
		}

		public void SetDestroyApi( Action<StoreApi<string>> api)
		{
			api(destroyApi);
		}

		public void SetPatchApi( Action<StoreApi<T>> api)
		{
			api(patchApi);
		}



		public void Create(Action<T> config){
			var record = new T();
			config(record);
			Create(record);
		}
		
		public void Create(T record)
		{
			createFunc(createApi.Url, record, createApi.DataType);
		}
		
		public void Create(FormElement form)
		{
			var record = new T();
			form.LoadTo(record);
			Create(record);
		}


		public jQueryDataHttpRequest<T> Read(Action<ReadOptions> options=null)
		{
			ReadOptions readOptions= new ReadOptions();
			if(options!=null) options(readOptions);
			return  readFunc(readApi.Url, readOptions,  readApi.DataType); 
		}

		public void Update(T record)
		{
			updateFunc(updateApi.Url, record, updateApi.DataType);
		}

		public void Destroy(Action<T> config)
		{
			T record= new T();
			config(record);
			destroyFunc(destroyApi.Url, record, destroyApi.DataType);		}


		public void Patch(T record)
		{
			patchFunc(patchApi.Url, record,  patchApi.DataType);
		}

		public object RequestObject(ReadOptions readOptions){
			dynamic ro = new {};
			if(!string.IsNullOrEmpty(readOptions.OrderBy)) ro[readOptions.OrderByParam]= readOptions.OrderBy;
			if(!string.IsNullOrEmpty(readOptions.OrderType)) ro[readOptions.OrderTypeParam]= readOptions.OrderType;
			if(readOptions.PageSize.HasValue) ro[readOptions.PageSizeParam]= readOptions.PageSize;
			if(readOptions.PageNumber.HasValue) ro[readOptions.PageNumberParam]= readOptions.PageNumber;
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
			var source =st.First( f=> ((dynamic)f)[idProperty]== ((dynamic)record)[idProperty]);
			var index = st.IndexOf(source);
			var r = source.Clone();
			var old = source.Clone();
			record(r);
			source.PopulateFrom(r);
			OnStoreChanged(this, new StoreChangedData<T>{ NewData= source, OldData=old, Action= StoreChangedAction.Replaced, Index= index});
		}

		#region ICollection implementation			
		
		public int Count
		{
			get {return st.Count;}
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
			return st.GetEnumerator();
		}
		#endregion			
		#region IEnumerable implementation			
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return st.GetEnumerator();
		}
#endregion


		public event Action<Store<T> , StoreChangedData<T> > OnStoreChanged;
		public event Action<Store<T> , StoreError<T>> OnStoreError;



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
		Cleared
	}

	//
	[ScriptNamespace("Cayita.Data")]
	[Serializable]
	public class StoreError<T>
	{
		protected internal StoreError(){}
		public StoreErrorAction Action {get;set;}
		public jQueryDataHttpRequest<T> Request{get;set;}

	}
	
	public enum StoreErrorAction{
		Created,
		Read,
		Updated,
		Destroyed,
		Patched,
		Added,
		Inserted,
		Replaced,
		Removed,
		Cleared
	}

}

