using System;
using System.Html;

namespace Cayita.UI
{

	public class HtmlList:ElementBase
	{
				
		public HtmlList(Element parent, Action<ListElement> element, bool ordered=false)
		{
			CreateElement (ordered ? "ol" : "ul", parent);
			element.Invoke (Element ());
		}
		

		public HtmlList (Element parent, bool ordered=false)
		{
			CreateElement (ordered ? "ol" : "ul", parent);
		}

		public new ListElement Element()
		{
			return base.Element().As<ListElement>();
		}


		public static HtmlList CreateNavList(Element parent)
		{
			var l = new HtmlList(parent, e=>{
				e.ClassName="nav nav-list";
				e.OnClick("li", ev=>{
					e.JQuery("li").RemoveClass("active");
					ev.CurrentTarget.AddClass("active");
				});

			});
			return l;
		}

		public static HtmlList CreateNavList(Element parent, Action<ListElement> element)
		{
			var nl = HtmlList.CreateNavList(parent);
			element(nl.Element());
			return nl;
		}

	}
}
