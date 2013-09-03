using System;
using System.Collections.Generic;
using System.Linq;
using jQueryApi;

namespace Cayita.JData
{
	public static partial class Data
	{
		public static Store<T> Store<T>() where T: Record, new()
		{

			var o = UI.Cast<Store<T>> (new List<T> ());

			o.LastOption = new ReadOptions ();
			o.Api = new StoreApi<T> ();

			Func<T,bool> filterFn = d => true;
			var totalCount = 0;
			var idProperty="Id";

			var defaultPageSize = 10;
			var ls = new List<T> ();
			var storeChanged = (Action<Store<T> , StoreChangedData<T>>)((st, d) => {});
			var storeRequested = (Action<Store<T> , StoreRequestedData>)((st, d) => {});
			var storeFailed = (Action<Store<T> , StoreFailedData<T>>)((st, d) => {});

			var onStoreFailed = (Action<Store<T>,StoreFailedAction, jQueryDataHttpRequest<T>>)
				((store,action,rq) => 
				 storeFailed (store, new StoreFailedData<T> { Action=action, Request= rq }));

			var onStoreRequested= (Action<Store<T>,StoreRequestedAction,StoreRequestedState>)
				((store,action,state)=>
					storeRequested(store, new StoreRequestedData(){Action=action,State=state}
			));
		
			var onStoreChanged = (Action<Store<T>,StoreChangedAction,T,T,int?>)(
				(store,action,ndata, odata,index) =>{ storeChanged (store, new StoreChangedData<T>(){
				Action=action,
				NewData=ndata,
				OldData=odata,
				Index=index.HasValue?index.Value:-1
				});
			});

			Func<T, IDeferred<T>> createFn= (record)=>{	
				onStoreRequested(o, StoreRequestedAction.Create, StoreRequestedState.Started);
				var req= jQuery.PostRequest<T>(o.Api.CreateApi, record, cb=>{} ,o.Api.DataType);
				req.Done(scb=>{
					var r = o.Api.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if (((object) res).IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							ls.Add(item);
							onStoreChanged(o,StoreChangedAction.Created, item, item, ls.IndexOf(item)  );
						}
					}
					else
					{
						ls.Add((T)res);
						onStoreChanged(o,StoreChangedAction.Created, (T)res, (T)res, ls.IndexOf((T)res) );
					}

				});
				req.Fail(f=>{
					onStoreFailed(o, StoreFailedAction.Create, req);
				});

				req.Always(t=>{
					onStoreRequested(o,StoreRequestedAction.Create, StoreRequestedState.Finished);
				});
	
				return req;
			};


			Func<ReadOptions,  IDeferred<T>> readFn = ( readOptions) => {	
				onStoreRequested (o,StoreRequestedAction.Read, StoreRequestedState.Started);
				var req = jQuery.GetData<T> (o.Api.ReadApi, readOptions.Request, cb => {}, o.Api.DataType);
				req.Done (scb=>{
					var r = o.Api.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if (((object) res).IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							foreach(var kv in o.Api.Converters)
							{
								((dynamic)item)[kv.Key]= kv.Value(item);
							}
							ls.Add(item);
						}
					}
					else
					{
						ls.Add((T)res);
					}

					int? tc = data[o.Api.TotalCountProperty];
					o.TotalCount= tc.HasValue? tc.Value: ls.Count(o.FilterFn);
					onStoreChanged(o,StoreChangedAction.Read, default(T), default(T), -1);
				});
				req.Fail (f=>{
					onStoreFailed(o,StoreFailedAction.Read, req);
				});
				req.Always (f=>{
					onStoreRequested(o,StoreRequestedAction.Read, StoreRequestedState.Finished);
				});
				return req;
			};

			Func<T, IDeferred<T>> updateFn = (record) => {	
				onStoreRequested (o,StoreRequestedAction.Update, StoreRequestedState.Started);
				var req = jQuery.PostRequest<T> (o.Api.UpdateApi, record, cb => {}, o.Api.DataType);
				req.Done (scb=>{
					var r = o.Api.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if (((object) res).IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							var ur =ls.First( f=> f.Get(o.IdProperty)== item.Get(o.IdProperty));
							var old = new T();
							old.PopulateFrom(ur);
							ur.PopulateFrom(item);
							onStoreChanged(o,StoreChangedAction.Updated,ur, old, ls.IndexOf(ur));
						}
					}
					else
					{
						var ur =ls.First( f=> f.Get(o.IdProperty)== res.Get(o.IdProperty));
						var old = new T();
						old.PopulateFrom(ur);
						ur.PopulateFrom((T)res);
						onStoreChanged(o,StoreChangedAction.Updated,ur, old, ls.IndexOf(ur));
					}
				});
				req.Fail (f=>{
					onStoreFailed(o,StoreFailedAction.Update, req);
				});
				req.Always (f=>{
					onStoreRequested(o,StoreRequestedAction.Update, StoreRequestedState.Finished);
				});
				return req;
			};


			Func<T, IDeferred<string>> destroyFn = (record) => {	
				onStoreRequested (o,StoreRequestedAction.Destroy, StoreRequestedState.Started);
				var data = (dynamic)new {};
				data [o.IdProperty] = record.Get (o.IdProperty);
				var req = jQuery.PostRequest<string> (o.Api.DestroyApi, (object)data, cb => {}, o.Api.DataType);
				req.Done (scb=>{
					var dr =ls.First( f=> f.Get(o.IdProperty)== record.Get(o.IdProperty));
					ls.Remove(dr);
					onStoreChanged(o,StoreChangedAction.Destroyed,dr, dr,-1);
				});
				req.Fail (f=>{
					onStoreFailed(o,StoreFailedAction.Destroy,null);
				});
				req.Always (f=>{
					onStoreRequested(o,StoreRequestedAction.Destroy, StoreRequestedState.Finished);
				});
				return req;
			};


			Func<T, IDeferred<T>> patchFn = (record) => {
				onStoreRequested (o, StoreRequestedAction.Patch, StoreRequestedState.Started);
				var req = jQuery.PostRequest<T> (o.Api.PatchApi, record, cb => {}, o.Api.DataType);
				req.Done (scb=>{	
					var r = o.Api.DataProperty;
					dynamic data = (dynamic) scb;
					var res = data[r]?? data;
					if ( res.IsArray())
					{
						foreach (var item in ((IList<T>) res))
						{
							var ur =ls.First( f=> f.Get(o.IdProperty)== item.Get(o.IdProperty));
							var old = new T();
							old.PopulateFrom(ur);
							ur.PopulateFrom(item);
							onStoreChanged(o,StoreChangedAction.Patched,ur, old,ls.IndexOf(ur) );
						}
					}
					else
					{
						var ur =ls.First( f=> f.Get(o.IdProperty)== res.Get(o.IdProperty));
						var old = new T();
						old.PopulateFrom(ur);
						ur.PopulateFrom((T)res);
						onStoreChanged(o,StoreChangedAction.Patched,ur, old,ls.IndexOf(ur) );
					}
				});
				req.Fail (f=>{
					onStoreFailed(o,StoreFailedAction.Patch, req);
				});
				req.Always (f=>{
					onStoreRequested(o,StoreRequestedAction.Patch, StoreRequestedState.Finished);
				});
				return req;
			};

			UI.SetToProperty (o, "get_data", (Func< List<T>>)(() => ls));

			UI.SetToProperty (o, "create", (Func<T, IDeferred<T>>)((d)=> createFn(d)));

			UI.SetToProperty(o, "read", (Func<Action<ReadOptions>, bool?, IDeferred<T>>)((ro,clear)=>{
				if(!clear.HasValue || clear.Value) ls.Clear();
				if(ro!=null) ro(o.LastOption);
				var lo= o.LastOption;
				if(lo.PageNumber.HasValue &&
				   ( !lo.PageSize.HasValue || (lo.PageSize.HasValue && lo.PageSize.Value==0) ) )
					lo.PageSize= defaultPageSize;

				return  readFn( o.LastOption); 
			}));

			UI.SetToProperty (o, "update", (Func<T, IDeferred<T>>)((d)=> updateFn(d)));
			UI.SetToProperty (o, "destroy", (Func<T, IDeferred<string>>)((d)=> destroyFn(d)));
			UI.SetToProperty (o, "patch", (Func<T, IDeferred<T>>)((d)=> patchFn(d)));

			UI.SetToProperty(o, "replace", (Action<T>)(record=>{
				var self=o;
				var source = ls.First (f => f.Get (self.IdProperty).ToString () == record.Get (self.IdProperty).ToString ());
				var index = ls.IndexOf(source);
				T old = UI.Cast<T>( source.Clone());
				source.PopulateFrom(record);
				onStoreChanged(o,StoreChangedAction.Replaced,source, old, index);
			}));

			UI.SetToProperty (o, "load", (Action<IList<T>,Action<ReadOptions>, bool?>)((data,ro,append) => {
				if(ro!=null) ro(o.LastOption);
				var lo= o.LastOption;
				if(lo.PageNumber.HasValue &&
				   ( !lo.PageSize.HasValue || (lo.PageSize.HasValue &&lo.PageSize.Value==0) ) )
					lo.PageSize= defaultPageSize;

				if(!append.HasValue || !append.Value ) ls.Clear();
				ls.AddRange(data);
				o.TotalCount = ls.Count (o.FilterFn);
				onStoreChanged (o,StoreChangedAction.Loaded, default(T), default(T), -1);
			}));


			UI.SetToProperty (o, "hasNextPage", (Func<bool>)(() => 
				(o.Count == o.TotalCount || !o.LastOption.PageNumber.HasValue)
					? false  : o.LastOption.PageNumber.Value + 1 < o.PagesCount ()));

			UI.SetToProperty (o, "hasPreviousPage", (Func<bool>) (()=>
				!( o.Count== o.TotalCount || !o.LastOption.PageNumber.HasValue
				         || ( o.LastOption.PageNumber.HasValue && o.LastOption.PageNumber.Value==0)) 
			));

			UI.SetToProperty(o,"readFirstPage", (Action)(()=>{

				if (o.LastOption.PageNumber.HasValue)
					o.LastOption.PageNumber = 0;

				if (!o.LastOption.LocalPaging)
					o.ReadFn (o.LastOption);
				else
					onStoreChanged (o,StoreChangedAction.Read, default(T), default(T), -1);
			}));

			UI.SetToProperty (o, "readNextPage", (Action<bool?>)(checkForNext => {
				if ((!checkForNext.HasValue || checkForNext.Value) && !o.HasNextPage ())
					return;

				o.LastOption.PageNumber++;
				if (!o.LastOption.LocalPaging)
					o.ReadFn (o.LastOption);
				else
					onStoreChanged (o,StoreChangedAction.Read, default(T), default(T), -1);
			}));

			UI.SetToProperty (o, "readPreviousPage", (Action<bool?>)(checkForPrevious => {
				if ((!checkForPrevious.HasValue || checkForPrevious.Value) && !o.HasPreviousPage ())
					return;
				o.LastOption.PageNumber--;

				if (!o.LastOption.LocalPaging)  
					o.ReadFn (o.LastOption);
				else 
					onStoreChanged (o,StoreChangedAction.Read, default(T), default(T), -1);
			}));

			UI.SetToProperty (o, "readLastPage", (Action)(() => {
				if (o.LastOption.PageNumber.HasValue)
					o.LastOption.PageNumber = o.PagesCount () - 1;

				if (!o.LastOption.LocalPaging)
					o.ReadFn (o.LastOption);
				else
					onStoreChanged (o,StoreChangedAction.Read, default(T), default(T), -1);
			}));


			UI.SetToProperty (o, "readPage", (Action<int>)(page => {
				if (o.LastOption.PageNumber.HasValue)
					o.LastOption.PageNumber = page< 0?
						0:
						page>= o.PagesCount()?
						o.PagesCount()-1:
						page;

				if (!o.LastOption.LocalPaging)
					o.ReadFn (o.LastOption);
				else
					onStoreChanged (o,StoreChangedAction.Read, default(T), default(T), -1);
			}));

			UI.SetToProperty (o, "pagesCount", (Func<int>)(() => {
				return (int) Math.Ceiling( (decimal) o.TotalCount  /
				                          ((decimal)( o.LastOption.PageSize.HasValue 
				           ? o.LastOption.PageSize.Value
				           : ls.Count ) ));
			}));

			UI.SetToProperty (o, "fromTo", (Func<Tuple<int,int,int>>)(() => {
				var lo = o.LastOption;
				var pageNumber = lo.PageNumber.HasValue ? lo.PageNumber.Value : 0;
				var pageSize = lo.PageSize.HasValue ? lo.PageSize.Value : o.TotalCount;

				var from_ = (pageNumber*pageSize) +1;
				var to_ = (pageNumber * pageSize) + pageSize;

				if (to_ > o.TotalCount )
					to_ = o.TotalCount;
				if (to_ == 0)
					from_ = 0;

				return Tuple.Create<int,int,int>(pageNumber,from_,to_);
			}));

			UI.SetToProperty(o, "indexOf", (Func<T,int>)(ls.IndexOf));

			UI.SetToProperty(o, "insert", (Action<int,T>)((index, item)=>{
				ls.Insert(index, item);
				onStoreChanged(o,StoreChangedAction.Inserted, item, item, index);
			}));

			UI.SetToProperty(o, "removeAt", (Action<int>)( index=>{
				var item =  ls[index];
				ls.RemoveAt(index);
				onStoreChanged(o,StoreChangedAction.Removed, item, item, index);
			}));

			UI.SetToProperty (o, "get_item", (Func<int,T>)(index => ls [index]));

			UI.SetToProperty (o, "set_item", (Action<int,T>)((index,value) => {
				T old = ls[index];
				T clone = UI.Cast<T>( old.Clone());
				ls[index]=value;
				onStoreChanged(o,StoreChangedAction.Replaced, clone, value,index);
			}));

			UI.SetToProperty (o, "get_count", (Func<int>)(
				() => (o.LastOption.LocalPaging && o.LastOption.PageSize.HasValue
				&& o.LastOption.PageSize.Value < ls.Count (o.FilterFn)) ?
				o.LastOption.PageSize.Value :
				ls.Count (o.FilterFn)));

			UI.SetToProperty (o, "add", (Action<T>)(item => {
				ls.Add(item);
				onStoreChanged (o, StoreChangedAction.Added,item, item, o.TotalCount  - 1);
			}));

			UI.SetToProperty (o, "clear", (Action)(() => {
				ls.Clear ();
				onStoreChanged (o,StoreChangedAction.Cleared, default(T), default(T), -1);
			}));

			UI.SetToProperty (o, "contains", (Func<T,bool>)(ls.Contains));

			UI.SetToProperty (o, "remove", (Func<T,bool>)(item => {
				var index = ls.IndexOf(item);
				var r= ls.Remove(item);
				if(r)
					onStoreChanged (o,StoreChangedAction.Removed,item, item,  index);
				return r;
			}));

			UI.SetToProperty (o, "getEnumerator", (Func <IEnumerator<T>>)(() => {
				var lo=o.LastOption;

				if(lo.LocalPaging && lo.PageNumber.HasValue && lo.PageSize.HasValue)
				{
					return ls.Where(o.FilterFn).Skip(lo.PageNumber.Value*lo.PageSize.Value).
						Take(lo.PageSize.Value).GetEnumerator();
				}
				return ls.Where(o.FilterFn).GetEnumerator();
			}));


			UI.SetToProperty (o, "add_storeChanged", (Action<Action<Store<T> , StoreChangedData<T>>>)
			                  (v => storeChanged = UI.Cast<Action<Store<T> , StoreChangedData<T>>> (Delegate.Combine (storeChanged, v))));

			UI.SetToProperty (o, "remove_storeChanged", (Action<Action<Store<T> , StoreChangedData<T>>>)
			                  (v => storeChanged = UI.Cast<Action<Store<T> , StoreChangedData<T>>> (Delegate.Remove (storeChanged, v))));

			UI.SetToProperty (o, "add_storeFailed", (Action<Action<Store<T> , StoreFailedData<T>>>)
			                  (v => storeFailed= UI.Cast<Action<Store<T> , StoreFailedData<T>>>(Delegate.Combine (storeFailed, v)) ));

			UI.SetToProperty (o, "remove_storeFailed", (Action<Action<Store<T> , StoreFailedData<T>>>)
			                  (v => storeFailed= UI.Cast<Action<Store<T> , StoreFailedData<T>>>(Delegate.Remove (storeFailed, v))));

			UI.SetToProperty (o, "add_storeRequested", (Action<Action<Store<T> , StoreRequestedData>>)
			                  (v => storeRequested = UI.Cast<Action<Store<T> , StoreRequestedData>> (Delegate.Combine (storeRequested, v))));

			UI.SetToProperty (o, "remove_storeRequested", (Action<Action<Store<T> , StoreRequestedData>>)
			                  (v => storeRequested = UI.Cast<Action<Store<T> , StoreRequestedData>> (Delegate.Remove (storeRequested, v))));

			UI.SetToProperty (o, "filter", (Action<Func<T, bool>>) (fn=>{
				if (fn!=null) filterFn= fn;
				if (o.LastOption.PageNumber.HasValue)
					o.LastOption.PageNumber = 0;
				o.TotalCount = ls.Count (filterFn);
				onStoreChanged (o,StoreChangedAction.Filtered, default(T), default(T), -1);
			}));

			UI.SetToProperty (o,"get_createFn", (Func<Func<T, IDeferred<T>>>)(() => createFn));
			UI.SetToProperty (o,"set_createFn", (Action<Func<T, IDeferred<T>>>)((v) => createFn=v));

			UI.SetToProperty(o, "get_readFn", (Func<Func<ReadOptions,  IDeferred<T>>>)( ()=> readFn));
			UI.SetToProperty(o, "set_readFn", (Action<Func<ReadOptions,  IDeferred<T>>>)( (v)=> readFn=v));

			UI.SetToProperty (o,"get_updateFn", (Func<Func<T, IDeferred<T>>>)(() => updateFn));
			UI.SetToProperty (o,"set_updateFn", (Action<Func<T, IDeferred<T>>>)((v) => updateFn=v));

			UI.SetToProperty (o,"get_destroyFn", (Func<Func<T, IDeferred<string>>>)(() => destroyFn));
			UI.SetToProperty (o,"set_destroyFn", (Action<Func<T, IDeferred<string>>>)((v) => destroyFn=v));

			UI.SetToProperty (o,"get_patchFn", (Func<Func<T, IDeferred<T>>>)(() => patchFn));
			UI.SetToProperty (o,"set_patchFn", (Action<Func<T, IDeferred<T>>>)((v) => patchFn=v));

			UI.SetToProperty(o, "get_totalCount", (Func<int>)( ()=> totalCount));
			UI.SetToProperty(o, "set_totalCount", (Action<int>)( (v)=> totalCount=v));

			UI.SetToProperty(o, "get_idProperty", (Func<string>)( ()=> idProperty));
			UI.SetToProperty(o, "set_idProperty", (Action<string>)( (v)=> idProperty=v));

			UI.SetToProperty(o, "get_filterFn", (Func<Func<T,bool>>)( ()=> filterFn));
			UI.SetToProperty(o, "set_filterFn", (Action<Func<T,bool>>)( (v)=> filterFn=v));

			return o;
		}

	}
}

