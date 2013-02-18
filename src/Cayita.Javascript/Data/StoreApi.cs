using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Javascript.Data
{
	[Serializable]	
	[ScriptNamespace("Cayita.Data")]
	public class StoreApi<T>
	{
		public StoreApi()
		{
			Url= "api/" + typeof(T).Name;
			DataType="json";
			DataProperty="Result";
			TotalCountProperty="TotalCount";
			HtmlProperty = "Html";
			
		}
		
		public string Url {get;set;}
		public string DataType {get;set;}
		protected internal AjaxRequestCallback<T> AjaxRequestCallback{get;set;}
		protected internal AjaxRequestCallback<T> Success{get;set;}
		protected internal AjaxErrorCallback<T> Error{get;set;}
		protected internal Action<T> Always{get;set;}
		public string DataProperty {get;set;}
		public string TotalCountProperty {get;set;}
		public string HtmlProperty {get;set;}
	}
}

