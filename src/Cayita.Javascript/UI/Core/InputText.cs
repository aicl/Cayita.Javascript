using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class TextConfig: InputConfig
	{
		public TextConfig():base(){}
		public int? MinLength{get;set;}
		public int? MaxLength{get;set;}
	}


	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class InputText:InputBase
	{

		protected internal InputText()
		{}


		public InputText(Element parent,  Action<TextElement> element)
			:base(parent, new TextConfig(),"text" )
		{
			element( Element());
		}
		

		public InputText (Element parent)
			:base(parent, new TextConfig(),"text")
		{}


		public new TextElement Element()
		{
			return (TextElement)  base.Element() ;
		}


	}

}

