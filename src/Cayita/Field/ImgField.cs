using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class ImgField:FileFieldBase
	{
		[InlineCode("Cayita.UI.ImgField()")]
		public ImgField ()
		{
		}

		[InlineCode("Cayita.UI.ImgField(null, null, {action},{parent})")]
		public ImgField(Atom parent, Action<ImgField> action=null){}


		public string EmptyImgSrc {
			[InlineCode("{this}.emptyImg.src")]get;
			[InlineCode("{this}.emptyImg.src={value}")]internal set;
		}

		[IntrinsicProperty]
		public Image EmptyImg {
			get;
			internal set;
		}

		[IntrinsicProperty]
		public Div Thumbnail {
			get;
			internal set;
		}

		[IntrinsicProperty]
		public Div ThumbnailPreview {
			get;
			internal set;
		}
	}
}

