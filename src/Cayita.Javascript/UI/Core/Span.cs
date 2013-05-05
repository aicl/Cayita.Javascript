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

		public new Span Append<T>(Action<T> content) where T: ElementBase<T>, new()
		{ 
			base.Append<T> (content);
			return this;
		}
		
		public Span Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}
		

		public Span Text(string value)
		{
			JQuery ().Text (value);
			return this;
		}

		public new SpanElement Element()
		{
			return  base.Element ().As<SpanElement> ();
		}

	}
	
}