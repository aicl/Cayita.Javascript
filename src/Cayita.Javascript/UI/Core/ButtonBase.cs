using System;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{

	public abstract class ButtonBase:ElementBase<ButtonBase>
	{
		protected ButtonBase(){}
				
		protected void CreateButton(Element parent,  string type)
		{
			CreateElement("button", parent);
			if(!string.IsNullOrEmpty(type))  Element().Type=type;
			Element().ClassName="btn";
		}

		public void Text(string value){
			Element().Text(value);
		}

		public void LoadingText(string value)
		{
			Element().LoadingText(value);
		}

		public  jQueryObject ShowLoadingText()
		{
			return Element().ShowLoadingText();
		}

		public  jQueryObject ResetLoadingText()
		{
			return Element().ResetLoadingText();
		}

		public  jQueryObject Toggle()
		{
			return Element().Toggle(); 
		}

		public new ButtonElement Element()
		{
			return (ButtonElement)base.Element();
		}
	}
}

