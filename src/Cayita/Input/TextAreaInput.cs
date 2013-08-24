using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TextAreaInput:Input<string>
	{

		[InlineCode("Cayita.UI.Input(String)('textarea')")]
		public TextAreaInput ()
		{
		}

		[InlineCode("Cayita.UI.Input(String)('textarea',null,null, null, null,{action},{parent})")]
		public TextAreaInput (Atom parent, Action<TextAreaInput> action=null)
		{
		}

		[IntrinsicProperty]
		public int Cols {
			get;
			set;
		}

		[IntrinsicProperty]
		public int Rows {
			get;
			set;
		}

	}
}

