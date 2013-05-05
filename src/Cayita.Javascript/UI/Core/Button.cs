using System;
using System.Html;

namespace Cayita.UI
{

	public class Button:ButtonBase<Button>
	{
		public Button (Action<ButtonElement> element)
		{
			CreateButton(null, "button");
			element.Invoke(Element());
		}

		public Button (Element parent, Action<ButtonElement> element)
		{
			CreateButton(parent, "button");
			element.Invoke(Element());
		}

		public Button(Element parent=null)

		{
			CreateButton(parent, "button");
		}
		
	}
}

