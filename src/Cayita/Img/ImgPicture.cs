using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class ImgPicture:Anchor
	{
		[InlineCode("Cayita.UI.ImgPicture()")]
		public ImgPicture ()
		{
		}

		[InlineCode("Cayita.UI.ImgPicture({src},{text}, null, {parent})")]
		public ImgPicture (Atom parent, string src, string text)
		{
		}

		[InlineCode("Cayita.UI.ImgPicture(null,null, {action}, {parent})")]
		public ImgPicture (Atom parent,Action<ImgPicture> action)
		{
		}


		[IntrinsicProperty]
		public Image Img { get; internal set; }
		[IntrinsicProperty]
		public Label Label { get; internal set; }

		public string Src { get; set; }
	}
}

