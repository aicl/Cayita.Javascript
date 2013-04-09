using System;
using System.Html;

namespace Cayita.UI
{
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
