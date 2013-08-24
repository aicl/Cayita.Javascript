using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita.JData
{
	[ScriptNamespace("Cayita"), PreserveMemberCase]
	public static partial class Data
	{

		public static StoreChangedData<T> StoreChangedData<T>()
		{
			return UI.Cast<StoreChangedData<T>> (new {
				newData=default(object),
				oldData=default(object),
				action = StoreChangedAction.None,
				index =-1
			});
		}


		public static StoreFailedData<T> StoreFailedData<T>()
		{
			return UI.Cast<StoreFailedData<T>> (new {
				action=StoreFailedAction.None,
				request= default(object)
			});
		}

		public static StoreRequestedData StoreRequestedData<T>()
		{
			return UI.Cast<StoreRequestedData> (new {
				action=StoreRequestedAction.None,
				state = StoreRequestedState.None
			});
		}


		public static ReadOptions ReadOptions(){

			var o = UI.Cast<ReadOptions> (new {
				pageSizeParam = "limit",
				pageNumberParam= "page",
				orderByParam = "orderby",
				orderTypeParam = "ordertype",
				pageSize=default(string),
				orderBy=default(string),
				pageNumber=default(string),
				localPaging=false,
				query = new JsDictionary<string,object>(),
				dynamicQuery = new {}
			});

			var df= new JsDictionary<string,object>();

			UI.SetToProperty (o, "get_request", (Func<JsDictionary<string,object>>)(() => {
				var ro = new JsDictionary<string,object>();
				if (!string.IsNullOrEmpty (o.OrderBy))
					ro [o.OrderByParam] = o.OrderBy;
				if (!string.IsNullOrEmpty (o.OrderType))
					ro [o.OrderTypeParam] = o.OrderType;
				if (! o.LocalPaging) {
					if (o.PageNumber.HasValue)
						ro[o.PageNumberParam] = o.PageNumber.Value;
					if (o.PageSize.HasValue)
						ro [o.PageSizeParam] = o.PageSize;
				}

				foreach(var kv in o.Query)
				{
					ro[kv.Key]= kv.Value;
				}

				((object)ro).CopyFrom((object)o.DynamicQuery);
				((object)ro).CopyFrom(df);

				return ro;

			}));

			UI.SetToProperty (o, "set_dataForm", (Action<object>)(s => { 
				df.Clear ();
				df.CopyFrom (s); 
			}));

			return o;

		}


		public static StoreApi<T> StoreApi<T>()
		{

			var s= UI.Cast<StoreApi<T>>( new {
				url= "api/" + typeof(T).Name,
				dataType="json",
				dataProperty="Result",
				totalCountProperty="TotalCount",
				htmlProperty = "Html",
				converters= new JsDictionary<string, Func<object,object>>(), //Func<T, object>>()
				createMethod="create",
				readMethod="read",
				updateMethod="update",
				destroyMethod="destroy",
				patchMethod="patch",
			});
			Func<string> createApiFn = 
				() =>
					"{0}{1}".Fmt (!s.Url.IsNullOrEmpty()?s.Url:"",
					       !s.CreateMethod.IsNullOrEmpty () ? ((!s.Url.IsNullOrEmpty () ? "/" : "") + s.CreateMethod) : "");

			Func<string> readApiFn = 
				() => "{0}{1}".Fmt (!s.Url.IsNullOrEmpty()?s.Url:"",
				                    !s.ReadMethod.IsNullOrEmpty () ? ((!s.Url.IsNullOrEmpty () ? "/" : "") + s.ReadMethod) : "");

			Func<string> updateApiFn = 
				() => "{0}{1}".Fmt (!s.Url.IsNullOrEmpty()?s.Url:"",
				                    !s.UpdateMethod.IsNullOrEmpty () ? ((!s.Url.IsNullOrEmpty () ? "/" : "") + s.UpdateMethod) : "");

			Func<string> destroyApiFn = 
				() => "{0}{1}".Fmt (!s.Url.IsNullOrEmpty()?s.Url:"",
			                    !s.DestroyMethod.IsNullOrEmpty () ? ((!s.Url.IsNullOrEmpty () ? "/" : "") + s.DestroyMethod) : "");

			Func<string> patchApiFn =
				() => "{0}{1}".Fmt (!s.Url.IsNullOrEmpty()?s.Url:"",
			                    !s.PatchMethod.IsNullOrEmpty () ? ((!s.Url.IsNullOrEmpty () ? "/" : "") + s.PatchMethod) : "");

			UI.SetToProperty (s, "get_createApiFn", (Func<Func<string>>)(()=>createApiFn));
			UI.SetToProperty (s, "set_createApiFn", (Action<Func<string>>)((v)=>createApiFn=v));
			UI.SetToProperty (s, "get_createApi", (Func<string>)(()=>createApiFn()));


			UI.SetToProperty (s, "get_readApiFn", (Func<Func<string>>)(()=>readApiFn));
			UI.SetToProperty (s, "set_readApiFn", (Action<Func<string>>)((v)=>readApiFn=v));
			UI.SetToProperty (s, "get_readApi", (Func<string>)(()=>readApiFn()));

			UI.SetToProperty (s, "get_updateApiFn", (Func<Func<string>>)(()=>updateApiFn));
			UI.SetToProperty (s, "set_updateApiFn", (Action<Func<string>>)((v)=>updateApiFn=v));
			UI.SetToProperty (s, "get_updateApi", (Func<string>)(()=> updateApiFn()));


			UI.SetToProperty (s, "get_destroyApiFn", (Func<Func<string>>)(()=>destroyApiFn));
			UI.SetToProperty (s, "set_destroyApiFn", (Action<Func<string>>)((v)=>destroyApiFn=v));
			UI.SetToProperty (s, "get_destroyApi", (Func<string>)(()=>destroyApiFn()));


			UI.SetToProperty (s, "get_patchApiFn", (Func<Func<string>>)(()=>patchApiFn));
			UI.SetToProperty (s, "set_patchApiFn", (Action<Func<string>>)((v)=>patchApiFn=v));
			UI.SetToProperty (s, "get_patchApi", (Func<string>)(()=>patchApiFn()));

			return s;

		}

	}

}