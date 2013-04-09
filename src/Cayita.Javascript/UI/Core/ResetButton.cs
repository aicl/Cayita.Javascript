using System;
using System.Html;

namespace Cayita.UI
{
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