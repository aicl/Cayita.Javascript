using System;
using System.Html;

namespace Cayita.UI
{
	public class InputText:Input
	{
		public InputText():base()
		{
			Element ().Type = "text";
		}
		
		public InputText(Action<TextElement> input):this()
		{
			input.Invoke ( Element() );
		}
		
		public new TextElement Element()
		{
			return El.As<TextElement> ();
		}
		
		public InputText Apply(Action<TextElement> input)
		{
			input.Invoke (Element ());
			return this;
		}
		
	}
}

