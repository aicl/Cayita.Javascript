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
		DivElement cg;

		DivElement ctrls ;

		public RadioField (Element parent, string label, string fieldName, IList<RadioItem> items, bool inline=true)
			:base(parent)
		{
			cg= Element();
			cg.ClassName="control-group";

			new Label (cg, l => {
				l.ClassName = "control-label";
				l.Text (label); }).Element ();

			ctrls = Div.CreateControls(cg, ct=>{
				foreach( var item in items)
				{
					new InputRadio(ct, (lb,rd)=>{
						lb.Text(item.Text);
						if(!inline) lb.RemoveClass("inline");
						rd.Name=fieldName;
						rd.SetValue(item.Value);
					});
				}
			}).Element();
		}
		
		public DivElement Controls()
		{
			return ctrls;
		}
	}
}