using System;
using System.Html;

namespace Cayita.UI
{
	public class Anchor:CayitaElement
	{
		
		public Anchor ():base("a")
		{
			Element ().Href = "#";

		}
		
		public Anchor (Action<AnchorElement> div):this()
		{
			div.Invoke (Element ());
		}
		
		public new AnchorElement Element()
		{
			return El.As<AnchorElement> ();
		}
		
		public Anchor Apply(Action<AnchorElement> div)
		{
			div.Invoke (Element ());
			return this;
		}


		public Anchor Href(string value)
		{
			Element ().Href = value;
			return this;
		}

	}
}

