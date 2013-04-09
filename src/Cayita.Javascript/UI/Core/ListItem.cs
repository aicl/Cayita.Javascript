using System;
using System.Html;

namespace Cayita.UI
{

	public class ListItem:ElementBase
	{
				
		public ListItem(ListElement parent,  Action<Element> element)
		{
			Init(parent);
			element(Element());
		}

		
		public ListItem (ListElement parent )
		{
			Init(parent);
		}
		
		void Init(ListElement parent)
		{
			CreateElement( "li", parent);

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
			
		/*
		/// <summary>
		/// Creats the nav list item.
		/// </summary>
		/// <returns>
		/// The nav list item.
		/// </returns>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='href'>
		/// Href.
		/// </param>
		/// <param name='item'>
		/// Item.
		/// </param>
		/// <param name='element'>
		/// Action<ListItemElement,AnchorElement>
		/// </param>

		public static ListItem CreateNavListItem(ListElement parent, string href, string item,
		                                        Action<Element,AnchorElement> element)
		{
			var il = new ListItem(parent);
			var anchor = new Anchor(il.Element(),
			                        a=>{
				a.Href= href;
				a.Text(item);
			});
			element(il.Element(), anchor.Element()); 
			return il;
		}

		public static ListItem CreateNavHeader(ListElement parent, string item)
		{
			return new ListItem(parent, l=>{
				l.ClassName="nav-header";
				l.Text(item);
			});

		}

		public static ListItem CreateHDivider(ListElement parent)
		{
			return new ListItem(parent, l=>{
				l.ClassName="divider";
			});
			
		}
		*/

	}
}

/*

<li><a href="api/User/read?cayita=true" class="mainMenuItem" id="user-menu-item" >Users </a></li>
*/