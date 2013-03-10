using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.Data
{
	[Serializable]
	[ScriptNamespace("Cayita.Data")]
	public class ReadOptions 
	{
		public ReadOptions()
		{
			QueryString = new JsDictionary<string,object>();
			PageSizeParam= "limit";
			PageNumberParam ="page";
			Request = new {};
		}
		public  int? PageNumber {get; set;}
		public  int? PageSize {get;  set;}
		public JsDictionary<string,object> QueryString {get; private set;}
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
		
		public dynamic Request {get; private set;}
				

	}
	
	//FormData

}

