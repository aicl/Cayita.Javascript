using System;
using System.Html;

namespace Cayita.UI
{
	public class InputCheckBox:Input
	{
		public InputCheckBox():base()
		{
			Element ().Type = "checkbox";
			Element().Value="true";
		}
		
		public InputCheckBox(Action<CheckBoxElement> input):this()
		{
			input.Invoke ( Element() );
		}
		
		public new CheckBoxElement Element()
		{
			return El.As<CheckBoxElement> ();
		}
		
		public InputCheckBox Apply(Action<CheckBoxElement> input)
		{
			input.Invoke (Element ());
			return this;
		}
		
	}
}