using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;

namespace Cayita.Javascript.Data
{

	[ScriptNamespace("Cayita.Data")]
	[PreserveMemberCase]
	public class Store<T> :IList<T> where T: new()
	{
		List<T> st= new List<T>();
		// string = url, object = filter, callback, type:=json,  html text
		Func<string, ReadOptions,  AjaxRequestCallback<T>, string, jQueryDataHttpRequest<T>> readFunc;
		Func<string, T,  AjaxRequestCallback<T>, string, jQueryDataHttpRequest<T>> createFunc;
		
		StoreApi<T> readApi;
		StoreApi<T> createApi;
		
		public Store()
		{
			
			readApi= new StoreApi<T>{Url= "api/" + typeof(T).Name+"/read"};

			createApi = new StoreApi<T>{Url= "api/" + typeof(T).Name+"/create"};

			readFunc= (url, readOptions, cb, type)=>{
				
				return jQuery.GetData<T>(url, RequestObject(readOptions), cb,type)
					.Success(scb=>{
						
						var r = readApi.DataProperty;
						dynamic data = (dynamic) scb;
						Cayita.Javascript.Firebug.Console.Log("dynamic ", data[r]);
						if ( IsArray(data[r]))
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								st.Add(item);
							}
						}
						else
						{
							st.Add((T)data["r"]);
						}
					});
			};

			createFunc= (url, record, cb, type)=>{
				
				return jQuery.PostRequest<T>(url, record, cb,type)
					.Success(scb=>{
						
						var r = readApi.DataProperty;
						dynamic data = (dynamic) scb;
						Cayita.Javascript.Firebug.Console.Log("dynamic ", data[r]);
						if ( IsArray(data[r]))
						{
							foreach (var item in ((IList<T>) data[r]))
							{
								st.Add(item);
							}
						}
						else
						{
							st.Add((T)data["r"]);
						}
					});
			};

		}
		
		[InlineCode("Array.isArray({o})")]
		bool IsArray(object o){
			return false;
		}
		
		public void SetReadFunc(Func<string, ReadOptions,  AjaxRequestCallback<T>, string , jQueryDataHttpRequest<T>> readFunc)
		{
			this.readFunc=readFunc;
		}

		public void SetCreateFunc(Func<string, T,  AjaxRequestCallback<T>, string , jQueryDataHttpRequest<T>> createFunc)
		{
			this.createFunc=createFunc;
		}

		public void SetReadApi( Action<StoreApi<T>> api)
		{
			api(readApi);
		}

		public void SetCreateApi( Action<StoreApi<T>> api)
		{
			api(createApi);
		}

		public void Read(Action<ReadOptions> options)
		{
			ReadOptions readOptions= new ReadOptions();
			options(readOptions);

			readFunc(readApi.Url, readOptions, readApi.AjaxRequestCallback, readApi.DataType)
				.Success(readApi.Success)
					.Error(readApi.Error)
					.Always(readApi.Always);
		}

		public void Create(Action<T> config){
			var record = new T();
			config(record);
			Create(record);
		}

		public void Create(T record)
		{
			createFunc(createApi.Url, record, createApi.AjaxRequestCallback, createApi.DataType)
				.Success(createApi.Success)
					.Error(createApi.Error)
					.Always(createApi.Always);
		}

		public void Create(FormElement form)
		{
			var record = new T();
			form.LoadTo(record);
			Create(record);
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
		}			
		public void RemoveAt (int index)
		{
			st.RemoveAt(index);
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
		#region ICollection implementation			
		
		public int Count
		{
			get {return st.Count;}
		}
		
		public void Add (T item)
		{
			st.Add(item);
		}
		public void Clear ()
		{
			st.Clear();
		}
		public bool Contains (T item)
		{
			return st.Contains(item);
		}
		
		public bool Remove (T item)
		{
			return st.Remove(item);
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
	}

}

