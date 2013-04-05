using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.Data
{
	[Serializable]
	[ScriptNamespace("Cayita.Data")]
	public class ReadOptions 
	{
		dynamic query_= new {};

		public ReadOptions()
		{
			QueryParams = new JsDictionary<string,object>();
			PageSizeParam= "limit";
			PageNumberParam ="page";
			DynamicQueryParams = new {};
		}

		public  int? PageNumber {get; set;}
		public  int? PageSize {get;  set;}
		public JsDictionary<string,object> QueryParams {get; private set;}
		public string OrderBy {get;set;}
		public string OrderType {get;set;}
		public string PageSizeParam {get;set;}
		public string PageNumberParam {get;set;}
		public bool LocalPaging { get; set; }

		public object OrderByParam {
			get;
			set;
		}
		
		public object OrderTypeParam {
			get;
			set;
		}
		
		public dynamic DynamicQueryParams {get; private set;}

		public dynamic GetRequestObject(){

			dynamic ro = new {};
			if (!string.IsNullOrEmpty (OrderBy))
				ro [OrderByParam] = OrderBy;
			if (!string.IsNullOrEmpty (OrderType))
				ro [OrderTypeParam] = OrderType;
			if (! LocalPaging) {
				if (PageNumber.HasValue)
					ro[PageNumberParam] = PageNumber;
				if (PageSize.HasValue)
					ro [PageSizeParam] = PageSize;
			}
		
			foreach(var kv in QueryParams)
			{

				ro[kv.Key]= kv.Value;
			}

			((object)ro).PopulateFrom((object)DynamicQueryParams);
			((object)ro).PopulateFrom((object)query_);

			return ro;

		}

		public void  Query<T>(T query) 
		{
			((object)query_).PopulateFrom (query);
		}

	}
	
	//FormData

}

