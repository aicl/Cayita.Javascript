using System;
using System.Html;

namespace Cayita.UI
{
	public class InputText:InputBase<InputText>
	{
		protected InputText(){}

		public InputText(Element parent,  Action<TextElement> element)
			:base(parent,"text" )
		{
			element.Invoke( Element());
		}
		

		public InputText (Element parent=null, string type="text")
			:base(parent,"text")
		{
		}


		public new TextElement Element()
		{
			return   base.Element().As<TextElement>() ;
		}

	}

}