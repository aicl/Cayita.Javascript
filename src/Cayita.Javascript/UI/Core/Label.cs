using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class LabelConfig:ElementConfig
	{	
		public LabelConfig():base(){}				

		public string TextLabel{get;set;}
		public string ForField {get;set;}
	}


	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class Label:ElementBase
	{
				
		public Label(Element parent, LabelConfig config, Action<Element> element)
		{
			Init(parent, config);
			element(Element());
		}
								
		public Label (Element parent, LabelConfig config)
		{
			Init(parent, config);
		}
				
		void Init(Element parent, LabelConfig config)
		{
			CreateElement("label", parent, config);
			if(!string.IsNullOrEmpty(config.TextLabel)) TextLabel(config.TextLabel);
			if(!string.IsNullOrEmpty(config.ForField))	ForField(config.ForField);
		}

		public void TextLabel(string textLabel)
		{
			Element().InnerText=textLabel;
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
			return Label.Create(parent, textLabel, forField, "control-label", visible);
		}


		public static Label Create(Element parent,string textLabel,
		                           string forField=null, string cssClass=null, bool visible=true)
		{
			var l = new Label(parent,
			new LabelConfig{
				Visible=visible,
				TextLabel=textLabel,
				ForField=forField,
				CssClass=cssClass
			});

			return l;
		}

	}
	
}
