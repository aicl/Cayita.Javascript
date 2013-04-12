using System;
using System.Html;

namespace Cayita.UI
{
	public class ListItem:CayitaElement
	{
		public ListItem ():base("li")
		{
		}

		public ListItem(Action<ListElement> list):this()
		{
			list.Invoke (Element ());
		}
		
		
		public new ListElement Element()
		{
			return El.As<ListElement> ();
		}

	}
}

