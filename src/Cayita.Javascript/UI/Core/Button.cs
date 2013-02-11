using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class Button:ButtonBase
	{
		public Button (Element parent, Action<ButtonElement> element)
			:base(parent, new ButtonConfig(), "button")
		{
			element(Element());
		}

		public Button(Element parent)
			:base(parent, new ButtonConfig(), "button")
		{}
		
	}
}

