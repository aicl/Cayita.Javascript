using System;
using System.Html;

namespace Cayita.UI
{

	public class InputCheckbox:InputBase<InputCheckbox>
	{
		public InputCheckbox()
		{
			Init (null);
		}

		public InputCheckbox( Action<CheckBoxElement> element)
		{
			Init(null);
			element.Invoke(Element()); Element();
		}


		public InputCheckbox(Element parent,  Action<CheckBoxElement> element)
		{
			Init(parent);
			element.Invoke(Element()); Element();
		}

		
		public InputCheckbox  (Element parent)
		{
			Init(parent);
		}
		
		protected void Init(Element parent)
		{
			CreateInput(parent, "checkbox");
			Element().Value="true";
		}

		public new CheckBoxElement Element()
		{
			return  base.Element().As<CheckBoxElement>();
		}

	}
	
}