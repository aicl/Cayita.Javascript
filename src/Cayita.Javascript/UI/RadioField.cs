using System;
using System.Runtime.CompilerServices;
using System.Html;
using System.Collections.Generic;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	[Serializable]
	public class RadioItem
	{
		public RadioItem(){}
		public string Text {get;set;}
		public string Value {get;set;}
	}


	[ScriptNamespace("Cayita.UI")]
	public class RadioField:Div
	{
		DivElement element;

		Div controls ;

		public RadioField (Element parent, string label, string fieldName, IList<RadioItem> items)
			:base(parent)
		{
			element= Element();
			element.ClassName="control-group";
			Label.CreateControlLabel(element, label);
			controls = Div.CreateControls(element, ct=>{
				foreach( var item in items)
				{
					new InputRadio(ct, (lb,rd)=>{
						lb.Text(item.Text);
						rd.Name=fieldName;
						rd.SetValue(item.Value);
					});
				}
			});
		}
		
		public Div GetControls()
		{
			return controls;
		}
	}
}

