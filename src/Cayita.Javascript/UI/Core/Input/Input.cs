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


	public  class InputHidden:InputBase<InputHidden>
	{
				
		public InputHidden (Element parent, string name=null)
			:base(parent,"text")
		{
			if (! string.IsNullOrEmpty (name))
				Element ().Name = name;
		}

		public InputHidden () :this(null)
		{}


	}


}
