using System;
using System.Html;

namespace Cayita.UI
{		

	public class Label:ElementBase<Label>
	{
				
		public Label(Element parent,  Action<LabelElement> element)
		{
			CreateElement("label", parent);
			element(Element());
		}
								
		public Label (Element parent)
		{
			CreateElement("label", parent);
		}
				

		public void TextLabel(string textLabel)
		{
			Element().Text(textLabel);
		}

		public string TextLabel()
		{
			return Element().Text();
		}

		public void ForField(string fieldId)
		{
			Element().For=fieldId;
		}

		public string ForField()
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
