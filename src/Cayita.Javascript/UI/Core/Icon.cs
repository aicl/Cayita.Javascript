using System;
using System.Html;

namespace Cayita.UI
{

	public class Icon:ElementBase
	{

		public Icon()
		{
			CreateElement("i",null);
		}

		public Icon(Element parent,  Action<Element> element)
		{
			CreateElement("i", parent);
			element(Element());
		}

		public Icon( Element parent)
		{
			CreateElement("i", parent);
		}

		public new Icon Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			base.Append<T> (content);
			return this;
		}

		public Icon Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}
	}
}

