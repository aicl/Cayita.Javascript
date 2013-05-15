using System;
using System.Html;

namespace Cayita.UI
{
	public class InputRadio:InputBase<InputRadio>
	{
		public InputRadio (Element parent,  Action<LabelElement,CheckBoxElement> field, bool inline=true)
		{
			new Label(parent, lb=>{
				lb.ClassName= string.Format("radio{0}", inline? " inline":"");
				CreateInput(null, "radio");
				lb.For=Element().ID;
				field(lb, Element());  
				lb.Append(Element());
			});
		}


		public new CheckBoxElement Element()
		{
			return  base.Element().As<CheckBoxElement>();
		}
	}
}

