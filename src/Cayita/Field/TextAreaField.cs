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
			[InlineCode("{this}.input")]
			get{ return null; }

		}

		public int Rows {
			[InlineCode("{this}.input.rows")]
			get;
			[InlineCode("{this}.input.rows={value}")]
			set;
		}

		public int Cols {
			[InlineCode("{this}.input.cols")]
			get;
			[InlineCode("{this}.input.cols={value}")]
			set;
		}

	}
}

