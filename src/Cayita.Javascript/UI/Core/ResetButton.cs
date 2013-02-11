using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class ResetButton:ButtonBase
	{
		public ResetButton (Element parent, Action<ButtonElement> element)
			:base(parent, new ButtonConfig(),"reset")
		{
			element(Element());
		}
	

		public ResetButton(Element parent)
			:base(parent, new ButtonConfig(),"reset")
		{}


		
	}
}

