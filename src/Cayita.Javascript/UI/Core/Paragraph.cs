using System;
using System.Html;

namespace Cayita.UI
{


	public class Paragraph:ElementBase
	{
		public Paragraph(Element parent, Action<Element> element)
		{
			CreateElement("p", parent);
			element(Element()); 
		}
		

		public Paragraph (Element parent)
		{
			CreateElement("p", parent);
		}
				
	}
	
}
