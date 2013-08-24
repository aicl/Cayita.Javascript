using System;
using System.Runtime.CompilerServices;
using jQueryApi.UI.Widgets;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NullableDateField:Field<DateTime?>
	{
		[InlineCode("Cayita.UI.NullableDateField()")]
		public NullableDateField ()
		{
		}

		[InlineCode("Cayita.UI.NullableDateField({options},{name},{placeholder})")]
		public NullableDateField (DatePickerOptions options, string name=null, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.NullableDateField(null,{name},{placeholder})")]
		public NullableDateField ( string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.NullableDateField(null,null,null,{action},{parent})")]
		public NullableDateField ( Atom parent, Action<NullableDateField> action)
		{
		}


		public new NullableDateInput Input  { 
			[InlineCode("{this}.input")]get { return null; } 
		}

		public DatePickerObject Picker { get { return null; } }
	}
}

