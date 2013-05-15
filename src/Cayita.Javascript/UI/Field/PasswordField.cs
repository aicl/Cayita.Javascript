using System;
using Cayita.UI;
using System.Html;

namespace Cayita
{
	public class PasswordField:TextFieldBase<PasswordField>
	{

		public PasswordField():this(default(Element))
		{}
		
		public PasswordField(ElementBase parent):this(parent.Element())
		{}
				
		public PasswordField(Element parent):base(parent)
		{
			Type ("password");
		}

	}
}

