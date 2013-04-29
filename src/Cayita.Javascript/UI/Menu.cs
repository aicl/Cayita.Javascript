using System;
using System.Html;
using Cayita.UI;

namespace Cayita.UI
{
	public class Menu:HtmlList
	{
		public Menu(Action<ListElement> list):this(default(Element), list)
		{
		}

		public Menu(Element parent, Action<ListElement> list):base(parent)
		{
			var el = Element ();
			el.ClassName = "dropdown-menu";
			el.SetAttribute ("role", "menu");
			list.Invoke (Element ());
		}

		public new Menu AppendTo(Element parent)
		{
			parent.Append (this).AddClass ("dropdown");
			return this;
		}
	}

	//<ul class="dropdown-menu" role="menu" aria-labelledby="drop2">

	public class SubMenu:ListItem
	{
		public SubMenu(string item, Action<ListElement> list):this(default(ListElement), item, list)
		{
		}
		
		public SubMenu(ListElement parent,string item, Action<ListElement> list):base(parent)
		{
			var li = Element ();
			li.ClassName = "dropdown-submenu";
			new Anchor(li, a=>{
				a.Href= "#";
				a.TabIndex=-1;
				a.Text(item);
			});

			var nv= HtmlList.CreateNavList (li);
			nv.ClassName("dropdown-menu");

			list.Invoke (nv.Element ());
		}
		
		public SubMenu AppendTo(Menu parent)
		{
			parent.Append (this);
			return this;
		}
	}

}
/*
<li class="dropdown-submenu">
                    <a tabindex="-1" href="#">More options</a>
                    <ul class="dropdown-menu">
                      <li><a tabindex="-1" href="#">Second level link</a></li>
                      <li><a tabindex="-1" href="#">Second level link</a></li>
                      <li><a tabindex="-1" href="#">Second level link</a></li>
                      <li><a tabindex="-1" href="#">Second level link</a></li>
                      <li><a tabindex="-1" href="#">Second level link</a></li>
                    </ul>
                  </li>
*/