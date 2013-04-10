using System;
using System.Html;

namespace Cayita.UI
{


	public class Paragraph:ElementBase
	{
		public Paragraph()
		{
			CreateElement("p", null);
		}

		public Paragraph(Element parent, Action<Element> element)
		{
			CreateElement("p", parent);
			element(Element()); 
		}
		

		public Paragraph (Element parent)
		{
			CreateElement("p", parent);
		}

		public new Paragraph Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			base.Append<T> (content);
			return this;
		}

		public new Paragraph Append (string content)
		{
			base.Append (content);
			return this;
		}

		public new Paragraph Append (Element content)
		{
			base.Append (content);
			return this;
		}

		public Paragraph Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}

	}
	
}
