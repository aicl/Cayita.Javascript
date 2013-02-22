using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public class SubmitButton:ButtonBase
	{
		public SubmitButton (Element parent, Action<ButtonElement> element)

		{
			CreateButton(parent, "submit");
			element(Element()); 
		}

		public SubmitButton(Element parent)
		{
			CreateButton(parent, "submit");
		}
			
	}
}

