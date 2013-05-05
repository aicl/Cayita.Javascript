using System;
using System.Html;

namespace Cayita.UI
{
	public class ResetButton:ButtonBase<ResetButton>
	{
		public ResetButton (Element parent, Action<ButtonElement> element)
		{
			CreateButton(parent, "reset");
			element.Invoke(Element());
		}
	
		public ResetButton(Element parent)
		{
			CreateButton(parent, "reset");
		}

	}
}