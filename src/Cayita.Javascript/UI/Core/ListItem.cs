using System;
using System.Html;

namespace Cayita.UI
{

	public class ListItem:ElementBase<ListItem>
	{
				
		public ListItem(ListElement parent,  Action<ListItemElement> element)
		{
			Init(parent);
			element.Invoke(Element());
		}

		
		public ListItem (ListElement parent )
		{
			Init(parent);
		}
		
		void Init(ListElement parent)
		{
			CreateElement( "li", parent);
		}


		public new ListItemElement Element()
		{
			return base.Element().As<ListItemElement>();
		}

		public static ListItem CreateNavListItem(ListElement parent, string href, string item)
		{
			var il = new ListItem(parent);
			new Anchor(il.Element(),
			           a=>{
				a.Href= href;
				a.Text( item );
			});
			return il;
		}
			

	}
}

/*

<li><a href="api/User/read?cayita=true" class="mainMenuItem" id="user-menu-item" >Users </a></li>
*/