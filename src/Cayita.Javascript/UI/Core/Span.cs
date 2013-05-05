using System;
using System.Html;

namespace Cayita.UI
{

	public class Span:ElementBase<Span>
	{
		public Span ()
		{
			CreateElement("span", null);
		}

		public Span(Element parent,  Action<SpanElement> element)
		{
			CreateElement("span", parent);
			element.Invoke(Element());
		}
						
		public Span (Element parent)
		{
			CreateElement("span", parent);
		}

				


		public new SpanElement Element()
		{
			return  base.Element ().As<SpanElement> ();
		}

	}
	
}