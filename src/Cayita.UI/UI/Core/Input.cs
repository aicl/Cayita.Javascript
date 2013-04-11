using System;
using System.Html;

namespace Cayita.UI
{
	public  class Input:CayitaElement
	{
		
		public Input():base("input")
		{
		}
		
		public Input(Action<InputElement> input):this()
		{
			input.Invoke (Element());
		}
		
		public new  InputElement Element()
		{
			return El.As<InputElement> ();
		}
		
		public Input Apply(Action<InputElement> input)
		{
			input.Invoke (Element ());
			return this;
		}
		
	}
}

