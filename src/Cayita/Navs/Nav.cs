using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Collections.Generic;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Nav:HtmlList
	{
		[InlineCode("Cayita.UI.Nav()")]
		public Nav ()
		{
		}

		[InlineCode("Cayita.UI.Nav({className})")]
		public Nav(string className){}


		[InlineCode("{this}.addItem({item})")]
		public void Add(HtmlListItem item)
		{
		}

		[InlineCode("{this}.addValue({value},{text},{handler},{iconClass})")]
		public void Add(string value, string text=null, jQueryEventHandler handler=null,string iconClass=null)
		{
		}

		[InlineCode("{this}.addDropdownMenu({item})")]
		public void Add(DropdownMenu item)
		{
		}


		[InlineCode("{this}.addDropdownSubmenu({item})")]
		public void Add(DropdownSubmenu item)
		{
		}

		[InlineCode("{this}.removeItem({value})")]
		public void Remove(string value)
		{
		}

		[InlineCode("{this}.disableItem({value},{disable})")]
		public void Disable(string value, bool disable=true)
		{
		}

		[InlineCode("{this}.disableAll({disable})")]
		public void DisableAll(bool disable=true)
		{
		}

		[InlineCode("{this}.addDivider({divider})")]
		public void AddDivider(string divider)
		{
		}

		[InlineCode("{this}.nav.loadList({list})")]
		public void Load(IEnumerable<string> list)
		{
		}

		[InlineCode("{this}.nav.loadNavItemList({list})")]
		public void Load(IEnumerable<NavItem> list)
		{
		}

		[InlineCode("{this}.nav.loadData({data},{itemFn})")]
		public void Load<TData>(IList<TData> data, Func<TData,HtmlListItem> itemFn)
		{
		}

	}
}

