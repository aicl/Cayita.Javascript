using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Javascript.UI
{
	
	[ScriptNamespace("Cayita.UI")]
	public class HtmlList:ElementBase
	{
				
		public HtmlList(Element parent, Action<Element> element, bool ordered=false)
		{
			CreateElement( ordered? "ol":"ul", parent);
			element(Element());
		}
		

		public HtmlList (Element parent, bool ordered=false)
		{
			CreateElement( ordered? "ol":"ul", parent);
		}


		public static HtmlList CreateNavList(Element parent)
		{
			var l = new HtmlList(parent, e=>{
				e.ClassName="nav nav-list";
			});
			l.JQuery().On("click","li", e=>{
				l.JQuery("li").RemoveClass("active");
				e.CurrentTarget.AddClass("active");
			});
			return l;
		}

		public static HtmlList CreateNavList(Element parent, Action<Element> element)
		{
			var nl = HtmlList.CreateNavList(parent);
			element(nl.Element());
			return nl;

		}

	}
}

