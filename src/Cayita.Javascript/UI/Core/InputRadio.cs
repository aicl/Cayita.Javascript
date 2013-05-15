using System;
using System.Html;

namespace Cayita.UI
{
	public class InputRadio:InputBase<InputRadio>
	{

		public InputRadio()
		{
			Init (null);
		}
		
		public InputRadio( Action<CheckBoxElement> element)
		{
			Init(null);
			element.Invoke(Element()); Element();
		}
		
		
		public InputRadio(Element parent,  Action<CheckBoxElement> element)
		{
			Init(parent);
			element.Invoke(Element()); Element();
		}
		
		
		public InputRadio  (Element parent)
		{
			Init(parent);
		}
		
		protected void Init(Element parent)
		{
			CreateInput(parent, "radio");
		}
		
		public new CheckBoxElement Element()
		{
			return  base.Element().As<CheckBoxElement>();
		}

	}
}

