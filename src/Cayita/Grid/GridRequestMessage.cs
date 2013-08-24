using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
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

