using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	
	[ScriptNamespace("Cayita.UI")]
	public  class Input:InputBase
	{

		public Input(Element parent,  Action<InputElement> element)
			:base(parent,"text")
		{
			element(Element());
		}
				
		public Input (Element parent)
			:base(parent,"text")
		{
		}

	}
	
}
