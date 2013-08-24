using System;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace Cayita.JData
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class StoreFailedData<T>
	{
		[InlineCode("Cayita.Data.StoreFailedData({T})()")]
		protected internal StoreFailedData ()
		{
		}

		[IntrinsicProperty]
		public StoreFailedAction Action { get; set; }
		[IntrinsicProperty]
		public jQueryDataHttpRequest<T> Request{ get; set; }
	}
}

