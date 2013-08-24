using System;
using System.Runtime.CompilerServices;

namespace Cayita.JData
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class StoreRequestedData
	{
		[InlineCode("Cayita.Data.StoreRequestedData()")]
		protected internal StoreRequestedData ()
		{
		}

		[IntrinsicProperty]
		public StoreRequestedAction Action { get; set; }
		[IntrinsicProperty]
		public StoreRequestedState State { get; set; }
	}
}

