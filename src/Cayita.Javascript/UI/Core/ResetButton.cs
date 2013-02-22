using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class ResetButton:ButtonBase
	{
		public ResetButton (Element parent, Action<ButtonElement> element)
		{
			CreateButton(parent, "reset");
			element(Element());
		}
	
		public ResetButton(Element parent)
		{
			CreateButton(parent, "reset");
		}

	}
}

