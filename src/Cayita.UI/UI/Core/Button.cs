using System;
using System.Html;

namespace Cayita.UI
{
	public class Button:CayitaElement
	{
		public Button ():base("button")
		{
			ClassName ("btn");
		}

		public Button (Action<ButtonElement> div):this()
		{
			div.Invoke (Element ());
		}
		
		public new ButtonElement Element()
		{
			return El.As<ButtonElement> ();
		}


	}
}

