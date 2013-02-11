using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class SubmitButton:ButtonBase
	{
		public SubmitButton (Element parent, Action<ButtonElement> element)
			:base(parent, new ButtonConfig(),"submit")
		{
			element(Element()); 
		}
		

		public SubmitButton(Element parent)
			:base(parent, new ButtonConfig(),"submit")
		{}
			

	}
}

