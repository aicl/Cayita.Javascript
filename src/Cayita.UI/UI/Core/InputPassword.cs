using System;
using System.Html;

namespace Cayita.UI
{
	public class InputPassword:InputText
	{

		public InputPassword():base()
		{
			Element ().Type = "password";
		}
		
		public InputPassword(Action<TextElement> input):this()
		{
			input.Invoke ( Element() );
		}

	}
}

