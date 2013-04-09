using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita.Data
{
	[Serializable]	
	public class StoreApi<T>
	{
		public StoreApi()
		{
			Url= "api/" + typeof(T).Name;
			DataType="json";
			DataProperty="Result";
			TotalCountProperty="TotalCount";
			HtmlProperty = "Html";
			Converters= new JsDictionary<string, Func<T, object>>();
		}
		
		public string Url { get; set; }
		public string DataType { get; set; }
		public string DataProperty { get; set; }
		public string TotalCountProperty { get; set; }
		public string HtmlProperty { get; set; }
		public  JsDictionary<string, Func<T,object>> Converters { get; set; }
	}
}

