using System;
using System.Html;
namespace Cayita.UI
{
	public class IconAnchor:Anchor
	{
		Icon ic;
		
		public IconAnchor ():base()
		{
			ic = new Icon ();
			Append (ic);
		}
		
		public IconAnchor Icon(Action<Icon> icon)
		{
			icon (ic);
			return this;
		}
		
		public IconAnchor Anchor(Action<AnchorElement> anchor)
		{
			anchor (Element());
			return this;
		}
		
		
	}
}

