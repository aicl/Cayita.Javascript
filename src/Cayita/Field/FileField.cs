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
			[InlineCode("{this}.get_inputSize()")]get;
			[InlineCode("{this}.set_inputSize({value})")]set;
		}

		[IntrinsicProperty]
		internal Div _uneditable {
			get;
			set;
		}

		[IntrinsicProperty]
		internal string _inputSize {
			get;
			set;
		}



	}
}

