using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class SideNavBar:Div
	{

		HtmlList navList;

		
		public HtmlList GetNavList()
		{
			return navList;
		}
		
		public SideNavBar (Element parent,  Action<ListElement> navlist)
			:base(parent)
		{
			
			Element().ClassName="well sidebar-nav";

			navList= HtmlList.CreateNavList(Element(), navlist);
					
			
		}
	}
}
