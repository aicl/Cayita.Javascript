using System.Html;

namespace Cayita.UI
{
	public class PasswordField:TextFieldBase<PasswordField>
	{

		public PasswordField():this(default(Element))
		{}
		
		public PasswordField(ElementBase parent):this(parent.GetMainElement() )
		{}
				
		public PasswordField(Element parent):base(parent)
		{
			Type ("password");
		}

	}
}

