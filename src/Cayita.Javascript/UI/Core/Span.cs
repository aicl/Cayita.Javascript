using System;
using System.Html;

namespace Cayita.UI
{

	public class Span:ElementBase
	{
		public Span ()
		{
			CreateElement("span", null);
		}

		public Span(Element parent,  Action<Element> element)
		{
			CreateElement("span", parent);
			element(Element());
		}
						
		public Span (Element parent)
		{
			CreateElement("span", parent);
		}

		public new Span Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			base.Append<T> (content);
			return this;
		}
		
		public Span Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}
		
		public new Span ClassName(string className)
		{
			Element ().ClassName = className;
			return this;
		}
		
		
		public new Span RemoveClass(string className)
		{
			JQuery ().RemoveClass (className);
			return this;
		}
		
		public new Span AddClass(string className)
		{
			JQuery ().AddClass (className);
			return this;
		}

		public Span Text(string value)
		{
			JQuery ().Text (value);
			return this;
		}


	}
	
}