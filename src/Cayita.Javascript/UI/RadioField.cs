using System;
using System.Runtime.CompilerServices;
using System.Html;
using System.Collections.Generic;

namespace Cayita.UI
{

	[Serializable]
	public class RadioItem
	{
		public RadioItem(){}
		public string Text { get; set;}
		public string Value { get; set;}
	}


	public class RadioField:Div
	{
		DivElement element;

		Div controls ;

		public RadioField (Element parent, string label, string fieldName, IList<RadioItem> items, bool inline=true)
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
						if(!inline) lb.RemoveClass("inline");
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