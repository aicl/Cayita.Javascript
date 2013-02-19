using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class FormConfig:ElementConfig
	{	
		public FormConfig():base(){}

		public string Method {get;set;}
		public string Action {get;set;}
		public string AcceptCharset {get;set;}
	}

	[ScriptNamespace("Cayita.UI")]
	public class Form:ElementBase
	{

		public Form(Element parent, Action<FormElement> element)
		{
			CreateElement("form", parent,new FormConfig());
			element(Element());
		}


		public Form (Element parent)
		{
			CreateElement("form", parent,new FormConfig());
		}


		public new FormElement Element()
		{
			return (FormElement) base.Element();
		}

	}
}

