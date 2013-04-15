using System;
using System.Html;

namespace Cayita.UI
{

	public class IconAnchor:Anchor
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.UI.IconAnchor"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='element'>
		/// Element. Action<AnchorElement,IconElement>
		/// </param>
		public IconAnchor(Element parent,  Action<AnchorElement,IconElement> element)
			:base(parent)
		{
			var i = new Icon( Element() );
			element(Element(), i.Element());
		}
	}


	public class IconButton:Button
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.UI.IconButton"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='element'>
		/// Element. Action<ButtonElement,IconElement>
		/// </param>
		public IconButton(Element parent,  Action<ButtonElement,IconElement> element)
			:base(parent)
		{
			Element().ClassName="btn";
			var i = new Icon( Element() );
			element(Element(), i.Element());
		}
		
	}

}