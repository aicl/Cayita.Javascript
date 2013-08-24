using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class FileFieldBase:Field<string>
	{

		[IntrinsicProperty]
		public new  FileInput Input {
			get;
			internal set;
		}

		[InlineCode("{this}.hidePreview({hide})")]
		public void HidePreview(bool hide= true){
		}

		public string FileOpenText {
			[InlineCode("{this}.get_fileOpenText()")]get;
			[InlineCode("{this}.set_fileOpenText({value})")]set;
		}


		public string FileChangeText {
			[InlineCode("{this}.get_fileChangeText()")]get;
			[InlineCode("{this}.set_fileChangeText({value})")]set;
		}

		public string FileRemoveText {
			[InlineCode("{this}.get_fileRemoveText()")]get;
			[InlineCode("{this}.set_fileRemoveText({value})")]set;
		}

		public CssIcon FileOpenIcon {
			[InlineCode("{this}.fileOpenIcon")]get;
			[InlineCode("{this}.fileOpenIcon={value}")] internal set;
		}

		public CssIcon FileChangeIcon {
			[InlineCode("{this}.fileChangeIcon")]get;
			[InlineCode("{this}.fileChangeIcon={value}")] internal set;
		}

		public CssIcon FileRemoveIcon {
			[InlineCode("{this}.fileRemoveIcon")]get;
			[InlineCode("{this}.fileRemoveIcon={value}")]internal set;
		}

		public LocalFile[]  Files {
			[InlineCode("{this}.input.files")]
			get { return null; }
		}


		/// <summary>
		/// Gets or sets  accepted type files.
		/// </summary>
		/// <value>accepted types : audio/*  video/* image/* image/jpeg, image/png  MIME_type </value>
		public string Accept
		{
			[InlineCode("{this}.input.accept")]
			get;
			[InlineCode("{this}.input.accept={value}")]
			set;
		}

		public bool Multiple
		{
			[InlineCode("{this}.input.multiple")]
			get;
			[InlineCode("{this}.input.multiple={value}")]
			set;
		}

		[IntrinsicProperty]
		internal Div _divinput {
			get;
			set;
		}

		[IntrinsicProperty]
		internal Span _spanfile {
			get;
			set;
		}

		[IntrinsicProperty]
		internal Span _spanfileopen {
			get;
			set;
		}



	}
}
