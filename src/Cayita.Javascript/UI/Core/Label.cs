using System;
using System.Html;

namespace Cayita.UI
{		

	public class Label:ElementBase<Label>
	{

		public Label(Action<LabelElement> element):this(null, element)
		{
		}

		public Label(Element parent,  Action<LabelElement> element)
		{
			CreateElement("label", parent);
			element.Invoke(Element());
		}
								
		public Label (Element parent=null)
		{
			CreateElement("label", parent);
		}
				

		public Label TextLabel(string textLabel)
		{
			Element().Text(textLabel);
			return this;
		}

		public string TextLabel()
		{
			return Element().Text();
		}

		public Label For(string fieldId)
		{
			Element().For=fieldId;
			return this;
		}

		public string For()
		{
			return Element ().For;
		}


		public static Label CreateControlLabel(Element parent, string textLabel,
		                                       string forField=null,  bool visible=true)
		{
			return  new Label(parent, lb=>{
				lb.Text(textLabel);
				lb.ClassName= "control-label";
				if (!string.IsNullOrEmpty(forField)) lb.For= forField;
				if(!visible) lb.Hide();
			});

		}

		public new LabelElement Element()
		{
			return base.Element().As<LabelElement>();
		}

	}
	
}
