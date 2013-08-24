using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CssPicture:Anchor
	{
		[InlineCode("Cayita.UI.CssPicture()")]
		public CssPicture ()
		{
		}

		[InlineCode("Cayita.UI.CssPicture({src},{text}, null, {parent})")]
		public CssPicture (Atom parent, string src, string text)
		{
		}

		[InlineCode("Cayita.UI.CssPicture(null,null, {action}, {parent})")]
		public CssPicture (Atom parent,Action<CssPicture> action)
		{
		}


		[IntrinsicProperty]
		public CssIcon Img { get; internal set; }
		[IntrinsicProperty]
		public Label Label { get; internal set; }

		public string Src { get; set; }
	}
}

