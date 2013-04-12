using System;
using System.Html;

namespace Cayita.UI
{
	
	public class Paragraph:CayitaElement
	{
		public Paragraph ():base("p")
		{
		}
		
		public Paragraph(Action<ParagraphElement> form):this()
		{
			form.Invoke (Element ());
		}
		
		
		public new ParagraphElement Element()
		{
			return El.As<ParagraphElement> ();
		}
		
		
	}
}