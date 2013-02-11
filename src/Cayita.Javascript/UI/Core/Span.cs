using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class SpanConfig:ElementConfig
	{	
		public SpanConfig():base(){}				

	}
	
	
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class Span:ElementBase
	{

		public Span(Element parent,  Action<Element> element)
		{
			CreateElement("span", parent, new SpanConfig());
			element(Element());
		}
						
		public Span (Element parent, SpanConfig config)
		{
			CreateElement("span", parent, new SpanConfig());
		}
		

				
	}
	
}
