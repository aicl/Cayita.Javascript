using System;
using System.Runtime.CompilerServices;
using System.Html;


namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class IconAnchor:Anchor
	{


		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.IconAnchor"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='element'>
		/// Element. Action<AnchorElement,IconElement>
		/// </param>
		public IconAnchor(Element parent,  Action<Element,Element> element)
			:base(parent)
		{
			Element().ClassName="btn";
			var i = new Icon( Element() );
			element(Element(), i.Element());
		}
		
	}


	[ScriptNamespace("Cayita.UI")]
	public class IconButton:Button
	{

		
		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.IconButton"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='element'>
		/// Element. Action<ButtonElement,IconElement>
		/// </param>
		public IconButton(Element parent,  Action<Element,Element> element)
			:base(parent)
		{
			Element().ClassName="btn";
			var i = new Icon( Element() );
			element(Element(), i.Element());
		}
		
	}

}

