using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class CheckboxConfig: InputConfig
	{
		public CheckboxConfig():base(){
			Value="true";
		}
		public bool Checked {get;set;}

	}

	
	[ScriptNamespace("Cayita.UI")]
	public class InputCheckbox:InputBase
	{
		protected InputCheckbox(){}


		public InputCheckbox(Element parent,  Action<CheckBoxElement> element)
		{
			Init(parent, new CheckboxConfig{Value="true"});
			element(Element());
		}

		
		public InputCheckbox  (Element parent)
		{
			Init(parent, new CheckboxConfig{Value="true"});
		}
		
		protected void Init(Element parent, CheckboxConfig config)
		{
			CreateInput(parent, config, "checkbox");
			Element().Checked=config.Checked;
		}

		public new CheckBoxElement Element()
		{
			return (CheckBoxElement) base.Element();
		}


	}
	
}