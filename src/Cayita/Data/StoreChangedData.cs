using System;
using System.Runtime.CompilerServices;

namespace Cayita.JData
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class StoreChangedData<T>
	{
		[InlineCode("Cayita.Data.StoreChangedData({T})()")]
		protected internal StoreChangedData ()
		{
		}

		[IntrinsicProperty]
		public  T NewData {get; set;}
		[IntrinsicProperty]
		public  T OldData {get; set;}
		[IntrinsicProperty]
		public StoreChangedAction Action { get; set; }
		[IntrinsicProperty]
		public int Index { get; set; }
	}
}

