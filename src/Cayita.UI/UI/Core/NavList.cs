using System;
using System.Html;

namespace Cayita.UI
{
	public class NavList:HtmlList
	{
		public NavList ():base()
		{
			Init ();
		}

		public NavList (Action<ListElement> list):base(list)
		{
			Init ();
		}

		void  Init()
		{
			var e = Element ();
			e.ClassName="nav nav-list";
			e.OnClick("li", ev=>{
				e.JQuery("li").RemoveClass("active");
				ev.CurrentTarget.AddClass("active");
			});

		}

	}
}

