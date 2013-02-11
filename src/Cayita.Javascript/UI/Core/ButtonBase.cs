using System;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class ButtonConfig:ElementConfig
	{
		public ButtonConfig():base(){
			CssClass="btn";
		}
		public string Text {get;set;}
		public string LoadingText {get;set;}
	}


	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public abstract class ButtonBase:ElementBase
	{
		protected ButtonBase(){}
		
		public ButtonBase(Element parent, ButtonConfig config, string type)
		{
			CreateButton(parent, config, type);
		}
		
		protected void CreateButton(Element parent, ButtonConfig config, string type)
		{
			CreateElement("button", parent, config);
			if(!string.IsNullOrEmpty(type)) ((ButtonElement) Element()).Type=type;
			if(!string.IsNullOrEmpty(config.Text)) Text(config.Text);
			if(!string.IsNullOrEmpty(config.LoadingText)) LoadingText(config.LoadingText);
		}

		public void Text(string value){
			JSelect().Text(value);
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

