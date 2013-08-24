using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class FileFieldBase:Field<string>
	{

		public new  FileInput Input {
			[InlineCode("{this}.cg.input")]
			get{ return null; }
		}

		[InlineCode("{this}.cg.hidePreview({hide})")]
		public void HidePreview(bool hide= true){
		}

		public string FileOpenText {
			[InlineCode("{this}.cg.get_fileOpenText()")]get;
			[InlineCode("{this}.cg.set_fileOpenText({value})")]set;
		}


		public string FileChangeText {
			[InlineCode("{this}.cg.get_fileChangeText()")]get;
			[InlineCode("{this}.cg.set_fileChangeText({value})")]set;
		}

		public string FileRemoveText {
			[InlineCode("{this}.cg.get_fileRemoveText()")]get;
			[InlineCode("{this}.cg.set_fileRemoveText({value})")]set;
		}

		public CssIcon FileOpenIcon {
			[InlineCode("{this}.cg.fileOpenIcon")]get;
			[InlineCode("{this}.cg.fileOpenIcon={value}")] internal set;
		}

		public CssIcon FileChangeIcon {
			[InlineCode("{this}.cg.fileChangeIcon")]get;
			[InlineCode("{this}.cg.fileChangeIcon={value}")] internal set;
		}

		public CssIcon FileRemoveIcon {
			[InlineCode("{this}.cg.fileRemoveIcon")]get;
			[InlineCode("{this}.cg.fileRemoveIcon={value}")]internal set;
		}

		public LocalFile[]  Files {
			[InlineCode("{this}.cg.input.files")]
			get { return null; }
		}


		/// <summary>
		/// Gets or sets  accepted type files.
		/// </summary>
		/// <value>accepted types : audio/*  video/* image/* image/jpeg, image/png  MIME_type </value>
		public string Accept
		{
			[InlineCode("{this}.cg.input.accept")]
			get;
			[InlineCode("{this}.cg.input.accept={value}")]
			set;
		}

		public bool Multiple
		{
			[InlineCode("{this}.cg.input.multiple")]
			get;
			[InlineCode("{this}.cg.input.multiple={value}")]
			set;
		}

	}
}
