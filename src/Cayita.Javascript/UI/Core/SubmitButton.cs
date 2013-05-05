using System;
using System.Html;

namespace Cayita.UI
{

	public class SubmitButton:ButtonBase<SubmitButton>
	{
		public SubmitButton (Element parent, Action<ButtonElement> element)

		{
			CreateButton(parent, "submit");
			element.Invoke(Element()); 
		}

		public SubmitButton(Element parent=null)
		{
			CreateButton(parent, "submit");
		}
			
	}
}

