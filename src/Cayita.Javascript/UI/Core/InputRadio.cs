using System;
using System.Html;

namespace Cayita.UI
{
	public class InputRadio:InputBase
	{
		public InputRadio (Element parent,  Action<Element,CheckBoxElement> field)
		{
			new Label(parent, lb=>{
				lb.ClassName="radio inline";
				CreateInput(null, "radio");
				lb.For=Element().ID;
				field(lb, Element());  
				lb.Append(Element());
			});
		}

		public new CheckBoxElement Element()
		{
			return (CheckBoxElement) base.Element();
		}
	}
}

