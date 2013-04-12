using System;
using System.Html;

namespace Cayita.UI
{
	public class Label:CayitaElement
	{
		public Label():base("label")
		{
		}
		
		public Label(Action<LabelElement> input):this()
		{
			input.Invoke ( Element() );
		}
		
		public new LabelElement Element()
		{
			return El.As<LabelElement> ();
		}
		
		public Label Apply(Action<LabelElement> input)
		{
			input.Invoke (Element ());
			return this;
		}

		public Label For(string fieldId)
		{
			Element ().For = fieldId;
			return this;
		}

	}
}