using System;
using System.Html;
namespace Cayita.UI
{
	public class IconButton:Button
	{
		Icon ic;

		public IconButton ():base()
		{
			ic = new Icon ();
			Append (ic);
		}

		public IconButton Icon(Action<Icon> icon)
		{
			icon (ic);
			return this;
		}

		public IconButton Button(Action<ButtonElement> button)
		{
			button (Element());
			return this;
		}


	}
}

