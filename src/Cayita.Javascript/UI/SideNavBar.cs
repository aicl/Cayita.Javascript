using System;
using System.Html;

namespace Cayita.UI
{
	public class SideNavBar:Div
	{

		ListElement nav;

		public ListElement NavList()
		{
			return nav;
		}
		
		public SideNavBar (Element parent,  Action<ListElement> navlist)
			:base(parent)
		{
			
			Element().ClassName="well sidebar-nav";
			nav= HtmlList.CreateNavList(Element(), navlist).Element();					
		}
	}
}
