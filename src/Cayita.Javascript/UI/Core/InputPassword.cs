using System;
using System.Html;

namespace Cayita.UI
{

	public class InputPassword:InputText
	{

		public InputPassword(Element parent,  Action<TextElement> element)
			:this(parent)
		{
			element.Invoke(Element());
		}


		public InputPassword (Element parent)
			:base(parent)
		{
			Element().Type="password";
		}

	}
	
}