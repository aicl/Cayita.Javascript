using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class ParagraphConfig:ElementConfig
	{	
		public ParagraphConfig():base(){}				
		public string Text{get;set;}
	}
	
	
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class Paragraph:ElementBase
	{
		public Paragraph(Element parent, ParagraphConfig config, Action<Element> element)
		{
			Init(parent, config);
			element(Element());
		}
		

		public Paragraph (Element parent, ParagraphConfig config)
		{
			Init(parent, config);
		}
		
		void Init(Element parent, ParagraphConfig config)
		{
			CreateElement("p", parent, config);
			if(!string.IsNullOrEmpty(config.Text)) Text(config.Text);
			
		}
		
		public void Text(string text)
		{
			JSelect().Text(text);
		}
		
		public string Text()
		{
			return JSelect().GetText();
		}
		
		
	}
	
}
