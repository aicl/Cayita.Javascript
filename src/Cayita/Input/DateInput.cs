using System.Runtime.CompilerServices;
using jQueryApi.UI.Widgets;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class DateInput:Input<DateTime>
	{
		[InlineCode("Cayita.UI.DateInput()")]
		public DateInput ()
		{
		}

		[InlineCode("Cayita.UI.DateInput({options})")]
		public DateInput (DatePickerOptions options)
		{
		}


		[InlineCode("Cayita.UI.DateInput({options},null,null,null,null,{parent})")]
		public DateInput (Atom parent, DatePickerOptions options)
		{
		}

		[InlineCode("Cayita.UI.DateInput(null,null,null,null,{action},{parent})")]
		public DateInput (Atom parent, Action<DateInput> action)
		{
		}

		[IntrinsicProperty]
		public DatePickerObject Picker{
			get { return null;}
		}
	}
}

