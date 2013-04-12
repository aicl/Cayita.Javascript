using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.UI
{

	public class Paragraph:ElementBase
	{
		public Paragraph()
		{
			CreateElement("p", null);
		}

		public Paragraph(Action<ParagraphElement> element)
		{
			CreateElement("p", null);
			element(Element()); 
		}

		public Paragraph(Element parent, Action<ParagraphElement> element)
		{
			CreateElement("p", parent);
			element(Element()); 
		}
		

		public Paragraph (Element parent)
		{
			CreateElement("p", parent);
		}

		public new  ParagraphElement Element()
		{
			return (ParagraphElement)base.Element();
		}


		public  void LogInfo ( int delay=5000)
		{
			Element ().LogInfo (delay);
		}

		public void LogSuccess ( int delay=5000)
		{
			Element ().LogSuccess (delay);
		}

		public void LogError ( int delay=0)
		{
			Element ().LogError (delay);
		}

	}
	
}
