using System;
using System.Html;

namespace Cayita.UI
{
	public class Div:CayitaElement
	{
		
		public Div ():base("div")
		{
		}

		public Div (Action<DivElement> div):this()
		{
			div.Invoke (Element ());
		}
		
		public new DivElement Element()
		{
			return El.As<DivElement> ();
		}

		public Div Apply(Action<DivElement> div)
		{
			div.Invoke (Element ());
			return this;
		}
		
	}
}

