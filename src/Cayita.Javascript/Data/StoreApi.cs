using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Javascript.Data
{
	[Serializable]	
	[ScriptNamespace("Cayita.Data")]
	[PreserveMemberCase]
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
		public AjaxRequestCallback<T> AjaxRequestCallback{get;set;}
		public AjaxRequestCallback<T> Success{get;set;}
		public AjaxErrorCallback<T> Error{get;set;}
		public Action<T> Always{get;set;}
		public string DataProperty {get;set;}
		public string TotalCountProperty {get;set;}
		public string HtmlProperty {get;set;}
	}
}

