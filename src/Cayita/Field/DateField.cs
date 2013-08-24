using System;
using System.Runtime.CompilerServices;
using jQueryApi.UI.Widgets;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class DateField:Field<DateTime>
	{
		[InlineCode("Cayita.UI.DateField()")]
		public DateField ()
		{
		}

		[InlineCode("Cayita.UI.DateField({options},{name},{placeholder})")]
		public DateField (DatePickerOptions options, string name=null, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.DateField(null, {name},{placeholder})")]
		public DateField (string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.DateField(null, null, null, {action},{parent})")]
		public DateField (Atom parent, Action<DateField> action)
		{
		}

		[IntrinsicProperty]
		public new DateInput Input  { 
			get { return null; }
		}

		public DatePickerObject Picker { get { return null; } }

	}
}

