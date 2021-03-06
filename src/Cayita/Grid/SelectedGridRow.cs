using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class SelectedGridRow<T> where T:new()
	{
		[InlineCode("Cayita.UI.SelectedGridRow({T})()")]
		public SelectedGridRow ()
		{
		}
		[IntrinsicProperty]
		public object RecordId { get; set;}
		[IntrinsicProperty]
		public TableRowAtom Row { get; set;}
		[IntrinsicProperty]
		public T  Record { get; set; }
	}
}

