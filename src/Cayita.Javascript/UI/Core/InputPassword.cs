using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class InputPassword:InputText
	{


		public InputPassword(Element parent,  Action<TextElement> element)
			:this(parent)
		{
			element(Element());
		}


		public InputPassword (Element parent)
			:base(parent)
		{
			Element().Type="password";
		}


	}
	
}