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
	

	public class DropDownSubmenu:ListItem
	{
		public DropDownSubmenu(string item, Action<ListElement> list):this(default(ListElement), item, list)
		{
		}
		
		public DropDownSubmenu(ListElement parent,string item, Action<ListElement> list):base(parent)
		{
			var li = Element ();
			li.ClassName = "dropdown-submenu";
			new Anchor(li, a=>{
				a.Href= "#";
				a.TabIndex=-1;
				a.Text(item);
			});

			new HtmlList(li, nl=>{
				nl.ClassName="dropdown-menu";
				list.Invoke (nl);
			});

		}
		
		public DropDownSubmenu AppendTo(DropDownMenu parent)
		{
			parent.Append (this);
			return this;
		}
	}

}
