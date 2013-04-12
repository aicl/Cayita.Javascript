using System;
using System.Html;

namespace Cayita.UI
{
	public class InputRadio:Input
	{
		public InputRadio():base()
		{
			Element ().Type = "radio";
		}
		
		public InputRadio(Action<CheckBoxElement> input):this()
		{
			input.Invoke ( Element() );
		}
		
		public new CheckBoxElement Element()
		{
			return El.As<CheckBoxElement> ();
		}
		
		public InputRadio Apply(Action<CheckBoxElement> input)
		{
			input.Invoke (Element ());
			return this;
		}
		
	}
}

