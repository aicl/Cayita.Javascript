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


		public static HtmlList CreatNavList(Element parent)
		{
			var l = new HtmlList(parent, e=>{
				e.ClassName="nav nav-list";
			});
			l.JSelect().On("click","li", e=>{
				jQuery.Select("li", l.Element()).RemoveClass("active");
				jQuery.FromElement( e.CurrentTarget).AddClass("active");
			});
			return l;
		}

		public static HtmlList CreatNavList(Element parent, Action<Element> element)
		{
			var nl = HtmlList.CreatNavList(parent);
			element(nl.Element());
			return nl;

		}

	}
}

