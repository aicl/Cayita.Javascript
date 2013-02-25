using System;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public abstract class ButtonBase:ElementBase
	{
		protected ButtonBase(){}
				
		protected void CreateButton(Element parent,  string type)
		{
			CreateElement("button", parent);
			if(!string.IsNullOrEmpty(type))  Element().JQuery().Attribute("type",type);
		}

		public void Text(string value){
			JQuery().Text(value);
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

