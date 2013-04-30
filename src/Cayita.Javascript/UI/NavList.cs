using System;
using System.Html;

namespace Cayita.UI
{
	public class NavList:Div
	{

		ListElement nav;

		public ListElement NavLinks()
		{
			return nav;
		}
		
		public NavList (Element parent,  Action<ListElement> navlist)
			:base(parent)
		{
			
			Element ().ClassName = "well sidebar-nav";
			nav = HtmlList.CreateNav (Element (), navlist, "nav-list").Element ();
		}
	}
}
