using System;
using System.Html;

namespace Cayita.UI
{
	public class Icon:CayitaElement
	{
		public Icon ():base("i")
		{
		}

		public Icon (Action<Element> icon): this()
		{
			icon.Invoke (Element ());
		}
	}
}

