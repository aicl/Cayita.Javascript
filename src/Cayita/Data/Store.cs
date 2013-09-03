using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.JData
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class Store<T> :IList<T> where T: Record, new()
	{
		[InlineCode("Cayita.Data.Store({T})()")]
		public Store()
		{
		}

		[IntrinsicProperty]
		public ReadOptions LastOption { get; protected internal set;}
		[IntrinsicProperty]
		public StoreApi<T> Api { get; protected internal set;}

		protected internal Func<T, bool>  FilterFn { get; set;}

		public int TotalCount { get; protected internal set;}

		public Func<T, IDeferred<T>> CreateFn { get; set; }
		public Func<ReadOptions,  IDeferred<T>> ReadFn { get; set; }
		public Func<T, IDeferred<T>> UpdateFn { get; set; }
		public Func<T, IDeferred<string>> DestroyFn { get; set; }
		public Func<T, IDeferred<T>> PatchFn { get; set; }

		public string IdProperty { get; set; }


		public IDeferred<T> Create(T record)
		{
			return null;
		}

		public virtual IDeferred<T> Read(Action<ReadOptions> options=null, bool clear=true)
		{
			return  null;
		}

		public IDeferred<T> Update(T record)
		{
			return null;
		}

		public IDeferred<string> Destroy(T record)
		{
			return null;
		}

		public IDeferred<T> Patch(T record)
		{
			return null;
		}

		#region IList implementation
		public int IndexOf (T item)
		{
			return 0;
		}			

		public void Insert (int index, T item)
		{
		}			
		public void RemoveAt (int index)
		{
		}			
		public T this [int index] {
			[InlineCode("{this}.get_item({index})")]get{ return default(T);}
			[InlineCode("{this}.set_item({index},{value})")]set{}
		}			
		#endregion			


		public void Replace(T record)
		{
		}

		#region ICollection implementation			
		public int Count
		{
			[InlineCode("{this}.get_count()")]get { return 0;}
		}

		public void Add (T item)
		{
		}

		public void Clear ()
		{
		}

		public bool Contains (T item)
		{
			return false;
		}

		public bool Remove (T item)
		{
			return false;
		}
		#endregion

		#region IEnumerable implementation			
		public IEnumerator<T> GetEnumerator ()
		{
			return null;
		}
		#endregion			
		#region IEnumerable implementation			
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return null;
		}
		#endregion

		public void  Load(IList<T> data, Action<ReadOptions> options=null, bool append=false)
		{
		}

		public bool HasNextPage()
		{
			return false;
		}

		public bool HasPreviousPage()
		{
			return false;
		}


		public void ReadFirstPage ()
		{
		}

		public void ReadNextPage(bool checkForNext=true)
		{
		}

		public void ReadPreviousPage(bool checkForPrevious=true)
		{
		}

		public void ReadLastPage ()
		{
		}

		public void ReadPage(int page)
		{
		}

		public int PagesCount()
		{
			return 0;
		}

		public Tuple<int,int,int> FromTo(){
			return null;
		}


		public IDeferred<T> Refresh()
		{
			return null;
		}

		public void Filter(Func<T, bool> filter=null)
		{
		}

		public event Action<Store<T> , StoreChangedData<T>> StoreChanged {
			[InlineCode("{this}.add_storeChanged({value})")]
			add{}
			[InlineCode("{this}.remove_storeChanged({value})")]
			remove{}
		}

		public event Action<Store<T> , StoreFailedData<T>> StoreFailed {
			[InlineCode("{this}.add_storeFailed({value})")]
			add{}
			[InlineCode("{this}.remove_storeFailed({value})")]
			remove{}
		}
		public event Action<Store<T> , StoreRequestedData> StoreRequested{
			[InlineCode("{this}.add_storeRequested({value})")]
			add{}
			[InlineCode("{this}.remove_storeRequested({value})")]
			remove{}
		}


		public List<T> Data { get { return null; } }

	}


}
