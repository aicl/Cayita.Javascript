using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
		
	[ScriptNamespace("Cayita.UI")]
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
