using System;
using jQueryApi;
using System.Runtime.CompilerServices;
using Cayita.Javascript.Data;

namespace jQueryApi
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public static class ReqExtensions
	{
		[InlineCode("cayita.fn.getAjaxResponse({req})")]
		public static AjaxResponse GetError<TData> (this jQueryDataHttpRequest<TData> req){
			return default(AjaxResponse);	
		}

	}
}

