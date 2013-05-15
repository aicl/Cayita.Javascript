using System;
using System.Html;

namespace Cayita.UI
{
	public class InputTextArea:InputBase<InputTextArea>
	{
		protected InputTextArea(){}

		public InputTextArea(Element parent,  Action<TextAreaElement> element)
			:base(parent, "textarea")

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

