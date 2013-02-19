using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class LegendConfig:ElementConfig
	{	
		public LegendConfig():base(){}				
		public string Text{get;set;}

	}
		

	[ScriptNamespace("Cayita.UI")]
	public class Legend:ElementBase
	{

		public Legend(Element parent, LegendConfig config, Action<Element> element)
		{
			Init(parent, config);
			element(Element());
		}
		

		public Legend (Element parent, LegendConfig config)
		{
			Init(parent, config);
		}
		
		void Init(Element parent, LegendConfig config)
		{
			CreateElement("legend", parent, config);
			if(!string.IsNullOrEmpty(config.Text)) Text(config.Text);
		}
		
		public void Text(string textLegend)
		{
			Element().InnerText=textLegend;
		}
		
		public string Text()
		{
			return Element().InnerText;
		}
		
			
		
	}
	
}
