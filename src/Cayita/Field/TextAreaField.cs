using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TextAreaField:Field<string>
	{
		[InlineCode("Cayita.UI.TextAreaField()")]
		public TextAreaField()
		{
		}

		[InlineCode("Cayita.UI.TextAreaField({name},{placeholder})")]
		public TextAreaField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.TextAreaField(null, null, {action},{parent})")]
		public TextAreaField(Atom parent, Action<TextAreaField> action=null){}


		public new TextAreaInput Input {
			[InlineCode("{this}.cg.input")]
			get{ return null; }

		}

		public int Rows {
			[InlineCode("{this}.cg.input.rows")]
			get;
			[InlineCode("{this}.cg.input.rows={value}")]
			set;
		}

		public int Cols {
			[InlineCode("{this}.cg.input.cols")]
			get;
			[InlineCode("{this}.cg.input.cols={value}")]
			set;
		}

	}
}

