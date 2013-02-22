using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	
	[ScriptNamespace("Cayita.UI")]
	public class HtmlList:ElementBase
	{
				
		public HtmlList(Element parent, Action<Element> element, bool ordered=false)
		{
			CreateElement( ordered? "ol":"ul", parent, new ElementConfig());
			element(Element());
		}
		

		public HtmlList (Element parent, bool ordered=false)
		{
			CreateElement( ordered? "ol":"ul", parent, new ElementConfig());
		}


		public static HtmlList CreatNavList(Element parent)
		{
			var l = new HtmlList(parent, e=>{
				e.ClassName="nav nav-list";
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

