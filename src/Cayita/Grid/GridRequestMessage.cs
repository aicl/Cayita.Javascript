using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class GridRequestMessage
	{
		[InlineCode("Cayita.UI.GridRequestMessage()")]
		public GridRequestMessage ()
		{
		}

		[IntrinsicProperty]
		public Atom Target{ get; set; }
		[IntrinsicProperty]
		public string Message { get; set; }
		[IntrinsicProperty]
		protected internal Atom HtmlElement { get; set; }
	}
}

