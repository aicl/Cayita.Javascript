using System;
using System.Html;

namespace Cayita.UI
{

	public  class Input:InputBase<Input>
	{

		public Input(Element parent,  Action<InputElement> element, string type="text")
			:base(parent,type)
		{
			element.Invoke(Element());
		}
				
		public Input (Element parent,string type="text" )
			:base(parent, type)
		{
		}

	}
	
}
