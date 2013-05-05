using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.UI
{

	public class Paragraph:ElementBase<Paragraph>
	{
		public Paragraph()
		{
			CreateElement("p", null);
		}

		public Paragraph(Action<ParagraphElement> element)
		{
			CreateElement("p", null);
			element.Invoke(Element()); 
		}

		public Paragraph(Element parent, Action<ParagraphElement> element)
		{
			CreateElement("p", parent);
			element.Invoke(Element()); 
		}
		

		public Paragraph (Element parent)
		{
			CreateElement("p", parent);
		}

		public new  ParagraphElement Element()
		{
			return base.Element().As<ParagraphElement>();
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
