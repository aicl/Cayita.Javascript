using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
		
	[ScriptNamespace("Cayita.UI")]
	public class InputCheckbox:InputBase
	{
		protected InputCheckbox(){}


		public InputCheckbox(Element parent,  Action<CheckBoxElement> element)
		{
			Init(parent);
			element(Element()); Element();
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
			return (CheckBoxElement) base.Element();
		}

	}
	
}