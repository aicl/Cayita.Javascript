using System;
using System.Html;

namespace Cayita.UI
{

	public class Span:ElementBase
	{
		public Span(Element parent,  Action<Element> element)
		{
			CreateElement("span", parent);
			element(Element());
		}
						
		public Span (Element parent)
		{
			CreateElement("span", parent);
		}
			
	}
	
}