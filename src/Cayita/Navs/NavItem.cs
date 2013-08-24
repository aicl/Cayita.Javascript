using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NavItem:HtmlListItem
	{
		[InlineCode("Cayita.UI.NavItem()")]
		public  NavItem()
		{
		}

		[InlineCode("Cayita.UI.NavItem({value},{text},{handler},{disable},{iconClassName})")]
		public  NavItem(string value, string text=null, jQueryEventHandler handler=null, bool disable=false, string iconClassName=null)
		{
		}

		public string Value { 
			[InlineCode("{this}.get_value()")]get;
			[InlineCode("{this}.set_value({value})")]set;
		}

		public string IconClass { 
			get;
			set;
		}

		[IntrinsicProperty]
		public jQueryEventHandler Handler { 
			get;
			set;
		}

		public new bool Disabled{
			[InlineCode("{this}.is_disabled()")]get;
			[InlineCode("{this}.disable({value})")]set;
		}


		[IntrinsicProperty]
		internal Anchor _anchor { 
			get;
			set;
		}

		[IntrinsicProperty]
		internal CssIcon _icon 
		{
			get;
			set;
		}

	}

}