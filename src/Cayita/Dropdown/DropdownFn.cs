using System;
using jQueryApi;
using System.Html;

namespace Cayita
{

	public static partial class UI
	{
		public static DropdownMenu DropdownMenu (string text, string iconClass)
		{
			var o = Cast<DropdownMenu> (CreateMenuBase(text,iconClass, true, "dropdown" ));                                 			
			o.ClassName="dropdown-toggle";
			o.SetAttribute("role","button");
			o.SetAttribute ("data-toggle", "dropdown");
			o.Nav.SetAttribute ("role", "menu");
			return o;
		}

		public static DropdownSubmenu DropdownSubmenu (string text, string iconClass)
		{
			var o = Cast<DropdownSubmenu> (CreateMenuBase (text, iconClass, false, "dropdown-submenu"));
			jQuery.FromElement (o).On ("click", e => e.PreventDefault ());
			return o;
		}


		static object CreateMenuBase (string text, string iconClass,  bool caret, string parentClass )
		{
			var a = Cast<DropdownMenu> (new Anchor ());
			a.TabIndex=-1;
			var icon = new CssIcon (iconClass);
			jQuery.FromElement (a).Append (icon).Append(BuildText(text)+ (caret?"<b class='caret'></b>":""));

			var nav = CreateNavBase ();
			nav.ClassName = "dropdown-menu";

			DefineProperty (a, "icon", new {value= icon, writable=false});
			DefineProperty (a, "nav", new {value= nav, writable=false});

			SetToProperty (a, "get_iconClass", (Func<string>)(() => a.Icon.ClassName));
			SetToProperty (a, "set_iconClass", (Action<string>)((v) => a.Icon.ClassName = v));
			SetToProperty (a, "addTo", (Action<Element>)((v) => {
				jQuery.FromElement(v).Append(a).Append(a.Nav).AddClass( parentClass);
			}));

			return a;
		}

	}
}

