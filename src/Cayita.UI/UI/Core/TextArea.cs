using System;
using System.Html;

namespace Cayita.UI
{
	
	public class TextArea:CayitaElement
	{
		public TextArea ():base("textarea")
		{
		}
		
		public TextArea(Action<TextAreaElement> form):this()
		{
			form.Invoke (Element ());
		}
		
		public new TextAreaElement Element()
		{
			return El.As<TextAreaElement> ();
		}
		
	}
}