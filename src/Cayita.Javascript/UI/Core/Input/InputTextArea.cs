using System;
using System.Html;

namespace Cayita.UI
{
	public class InputTextArea:ElementBase<InputTextArea>
	{
		protected InputTextArea(){}

		public InputTextArea(Element parent,  Action<TextAreaElement> element)

		{
			CreateElement("textarea", parent);
			element.Invoke(Element());
		}
		
		public InputTextArea (Element parent)
		{
			CreateElement("textarea", parent);
		}

		public new  TextAreaElement Element()
		{
			return base.Element().As<TextAreaElement>();
		}

	}
}

