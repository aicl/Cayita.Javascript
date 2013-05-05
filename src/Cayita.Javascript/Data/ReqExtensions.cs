using System;
using jQueryApi;
using System.Runtime.CompilerServices;
using Cayita.Data;

namespace jQueryApi
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public static class ReqExtensions
	{
		[InlineCode("cayita.fn.getAjaxResponse({req})")]
		public static AjaxResponse GetError<TData> (this jQueryDataHttpRequest<TData> req){
			return default(AjaxResponse);	
		}

		[InlineCode("cayita.fn.getAjaxResponse({req})")]
		public static AjaxResponse GetError (this jQueryXmlHttpRequest req){
			return default(AjaxResponse);	
		}

	}
}

