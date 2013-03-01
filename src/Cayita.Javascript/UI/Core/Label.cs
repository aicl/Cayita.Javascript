using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
		
	[ScriptNamespace("Cayita.UI")]
	public class Label:ElementBase
	{
				
		public Label(Element parent,  Action<Element> element)
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
			return Element().InnerText;
		}

		public void ForField(string fieldName)
		{
			if(!string.IsNullOrEmpty(fieldName))
			{
				Element().SetAttribute("for", fieldName);
			}
			else
			{
				Element().RemoveAttribute("for");
			}

		}

		public string ForField()
		{
			object forF= Element().GetAttribute("for");
			return forF==null? string.Empty:forF.ToString();
		}


		public static Label CreateControlLabel(Element parent, string textLabel,
		                                       string forField=null,  bool visible=true)
		{
			return  new Label(parent, lb=>{
				lb.Text(textLabel);
				lb.ClassName= "control-label";
				if (!string.IsNullOrEmpty(forField)) lb.SetAttribute("for", forField);
				if(!visible) lb.Hide();
			});

		}


	}
	
}
