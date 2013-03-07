using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
		
	[ScriptNamespace("Cayita.UI")]
	public class InputText:InputBase
	{

		protected InputText(){}

		public InputText(Element parent,  Action<TextElement> element)
			:base(parent,"text" )
		{
			element( Element());
		}
		

		public InputText (Element parent)
			:base(parent,"text")
		{}


		public new TextElement Element()
		{
			return (TextElement)  base.Element() ;
		}


	}

}

