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
			[InlineCode("{this}.cg.emptyImg.src")]get;
			[InlineCode("{this}.cg.emptyImg.src={value}")]internal set;
		}

		public Image EmptyImg {
			[InlineCode("{this}.cg.emptyImg")]get;
			[InlineCode("{this}.cg.emptyImg={value}")]internal set;
		}

		public Div Thumbnail {
			[InlineCode("{this}.cg.thumbnail")]get;
			[InlineCode("{this}.cg.thumbnail={value}")]  internal set;
		}


		public Div ThumbnailPreview {
			[InlineCode("{this}.cg.thumbnailPreview")]get;
			[InlineCode("{this}.cg.thumbnailPreview={value}")]  internal set;
		}
	}
}

