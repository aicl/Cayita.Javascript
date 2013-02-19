using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class ListItemConfig:ElementConfig
	{	
		public ListItemConfig():base(){}				

		public string Item{get;set;}
	}

	[ScriptNamespace("Cayita.UI")]
	public class ListItem:ElementBase
	{
				
		public ListItem(Element parent, ListItemConfig config, Action<Element> element)
		{
			Init(parent, config);
			element(Element());
		}

		
		public ListItem (Element parent, ListItemConfig config)
		{
			Init(parent, config);
			if(!string.IsNullOrEmpty(config.Item)) JSelect().Text(config.Item);
		}
		
		void Init(Element parent, ListItemConfig config)
		{
			CreateElement( "li", parent, config);

		}

		public void Item (string item)
		{
			JSelect().Text(item);
		}

		public static ListItem CreateNavListItem(Element parent, string href, string item)
		{
			var il = new ListItem(parent, new ListItemConfig());
			new Anchor(il.Element(),
			           a=>{
				a.Href= href;
				a.InnerText= item;
			});
			return il;
		}
			
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

		public static ListItem CreateNavListItem(Element parent, string href, string item,
		                                        Action<Element,AnchorElement> element)
		{
			var il = new ListItem(parent, new ListItemConfig());
			var anchor = new Anchor(il.Element(),
			                        a=>{
				a.Href= href;
				a.InnerText= item;
			});
			element(il.Element(), anchor.Element()); 
			return il;
		}

		public static ListItem CreateNavHeader(Element parent, string item)
		{
			return  new ListItem(parent, new ListItemConfig{CssClass="nav-header", Item=item});
		}
		
	}
}

/*

<li><a href="api/User/read?cayita=true" class="mainMenuItem" id="user-menu-item" >Users </a></li>
*/