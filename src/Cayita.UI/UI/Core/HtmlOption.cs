using System;
using System.Html;

namespace Cayita.UI
{
	public class HtmlOption:CayitaElement
	{
		public HtmlOption ():base("option")
		{
		}

		public HtmlOption (Action<OptionElement> div):this()
		{
			div.Invoke (Element ());
		}
		
		public new OptionElement Element()
		{
			return El.As<OptionElement> ();
		}
		
		public HtmlOption Apply(Action<OptionElement> div)
		{
			div.Invoke (Element ());
			return this;
		}

	}
}

