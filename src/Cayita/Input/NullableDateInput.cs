using System.Runtime.CompilerServices;
using jQueryApi.UI.Widgets;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NullableDateInput:Input<DateTime?>
	{
		[InlineCode("Cayita.UI.NullableDateInput()")]
		public NullableDateInput ()
		{
		}

		[InlineCode("Cayita.UI.NullableDateInput({options})")]
		public NullableDateInput (DatePickerOptions options)
		{
		}

		[InlineCode("Cayita.UI.NullableDateInput({options},null,null,null,null,{parent})")]
		public NullableDateInput (Atom parent, DatePickerOptions options)
		{
		}

		[InlineCode("Cayita.UI.NullableDateInput(null,null,null,null,{action},{parent})")]
		public NullableDateInput (Atom parent, Action<NullableDateInput> action)
		{
		}

		[IntrinsicProperty]
		public DatePickerObject Picker{
			get { return null;}
		}

	}
}

