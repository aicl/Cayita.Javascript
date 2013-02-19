using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class InputConfig:ElementConfig
	{
		
		public InputConfig():base(){}
		
		public string Placeholder {get;set;}
		public bool Required {get;set;}
		
		public string RelativeSize {get;set;}
		public string GridSize {get;set;}
		public string Value {get;set;}
		
	}

	
	[ScriptNamespace("Cayita.UI")]
	public  class Input:InputBase
	{
		public Input(ElementBase parent, InputConfig config,  Action<InputElement> element)
			:this(parent.Element(), config, element)
		{
		}
		
		public Input(Element parent, InputConfig config,  Action<InputElement> element)
			:base(parent, config,"")
		{
			element(Element());
		}
				
		public Input (Element parent, InputConfig config)
			:base(parent, config, "")
		{
		}
		
		public Input (ElementBase parent, InputConfig config):
			base(parent.Element(), config, "")
		{
		}

	}
	
}
