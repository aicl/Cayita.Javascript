using System;
using System.Html;

namespace Cayita.UI
{
	
	public class Form:CayitaElement
	{
		public Form ():base("form")
		{
		}

		public Form(Action<FormElement> form):this()
		{
			form.Invoke (Element ());
		}
				
		
		public new FormElement Element()
		{
			return El.As<FormElement> ();
		}
		
	}
}

