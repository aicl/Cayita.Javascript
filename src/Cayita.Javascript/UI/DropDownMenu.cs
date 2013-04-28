using System;
using System.Html;
using Cayita.UI;

namespace Cayita.UI
{
	public class DropDownMenu:HtmlList
	{
		public DropDownMenu(Action<ListElement> list):this(default(Element), list)
		{
		}

		public DropDownMenu(Element parent, Action<ListElement> list):base(parent)
		{
			var el = Element ();
			el.ClassName = "dropdown-menu";
			el.SetAttribute ("role", "menu");
			list.Invoke (Element ());
		}

		public new DropDownMenu AppendTo(Element parent)
		{
			parent.Append (this).AddClass ("dropdown");
			return this;
		}
	}

	//<ul class="dropdown-menu" role="menu" aria-labelledby="drop2">
}
