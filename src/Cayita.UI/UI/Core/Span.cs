using System;
using System.Html;

namespace Cayita.UI
{
	public class Span:CayitaElement
	{
		
		
		public Span():base("span")
		{
		}
		
		public Span(Action<Element> span):this()
		{
			span.Invoke (Element());
		}
		
		public Span Text(string value)
		{
			base.Element().InnerHTML = value;
			return this;
		}
		
		public Span Apply(Action<Element> span)
		{
			span.Invoke (Element ());
			return this;
		}
		
	}
}

