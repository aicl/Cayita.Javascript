using System;
using System.Html;

namespace Cayita.UI
{

	public class HtmlList:ElementBase<HtmlList>
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


		public static HtmlList CreateNav(Element parent, string navType="")
		{
			var l = new HtmlList(parent, e=>{
				e.ClassName=string.Format("nav{0}", string.IsNullOrEmpty(navType)?"": " "+navType);
				e.OnClick("li", ev=>{
					e.JQuery("li").RemoveClass("active");
					ev.CurrentTarget.AddClass("active");
				});

			});
			return l;
		}

		public static HtmlList CreateNav(Element parent, Action<ListElement> element, string navType="")
		{
			var nl = HtmlList.CreateNav(parent, navType);
			element(nl.Element());
			return nl;
		}

	}
}
