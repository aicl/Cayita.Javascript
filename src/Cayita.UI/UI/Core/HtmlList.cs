using System;
using System.Html;

namespace Cayita.UI
{
	public class HtmlList:CayitaElement
	{
		public HtmlList ():base("ul")
		{
		}

		public HtmlList(Action<ListElement> list):this()
		{
			list.Invoke (Element ());
		}
		
		
		public new ListElement Element()
		{
			return El.As<ListElement> ();
		}

	}
}

