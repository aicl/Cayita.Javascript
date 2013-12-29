using System;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace Cayita
{
	public static partial class Fn
	{
		public static FailRequest GetFailRequest(this jQueryXmlHttpRequest request){
			var r = new FailRequest (request);
			return r;
		}

		[InlineCode("Cayita.Fn.getFailRequest({request})")]
		public static FailRequest GetFailRequest<T>(this jQueryDataHttpRequest<T> request){
			return null;
		}

	}
}

