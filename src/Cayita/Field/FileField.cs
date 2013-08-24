using jQueryApi;
using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class FileField:FileFieldBase
	{

		[InlineCode("Cayita.UI.FileField()")]
		public FileField()
		{
		}

		[InlineCode("Cayita.UI.FileField(null, null, {action},{parent})")]
		public FileField(Atom parent, Action<FileField> action=null){}


		public string InputSize {
			[InlineCode("{this}.cg.get_inputSize()")]get;
			[InlineCode("{this}.cg.set_inputSize({value})")]set;
		}

		[IntrinsicProperty]
		internal Div Uneditable {
			get;
			set;
		}




	}
}

