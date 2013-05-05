using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.UI
{
	public class TextArea:ElementBase<TextArea>
	{
		protected TextArea(){}

		public TextArea(Element parent,  Action<TextAreaElement> element)

		{
			CreateElement("textarea", parent);
			element.Invoke(Element());
		}
		
		public TextArea (Element parent)
		{
			CreateElement("textarea", parent);
		}

		public new  TextAreaElement Element()
		{
			return base.Element().As<TextAreaElement>();
		}

	}
}

