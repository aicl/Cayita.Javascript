using System.Runtime.CompilerServices;
using jQueryApi;
using System.Collections.Generic;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class NavBase:Div
	{

		public event jQueryEventHandler Selected
		{
			[InlineCode("{this}.nav.add_selected({value})")]
			add{
			}
			[InlineCode("{this}.nav.remove_selected({value})")]
			remove{
			}
		}

		[InlineCode("{this}.nav.addValue({value},{text},{handler},{disable},{iconClass})")]
		public void Add(string value, string text=null, jQueryEventHandler handler=null,
		                bool disable=false, string iconClass=null)
		{
		}


		[InlineCode("{this}.nav.addValue({value},null,{handler},false,null)")]
		public void Add(string value, jQueryEventHandler handler)
		{
		}

		[InlineCode("{this}.nav.addItem({item})")]
		public void Add(NavItem item)
		{
		}

		[InlineCode("{this}.nav.addDropdownMenu({item})")]
		public void Add(DropdownMenu item)
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
		public void Load<TData>(IEnumerable<TData> data, Func<TData,HtmlListItem> itemFn)
		{
		}

		[InlineCode("{this}.nav.removeItem({value})")]
		public void Remove(string value)
		{
		}

		[InlineCode("{this}.nav.removeAll()")]
		public void RemoveAll()
		{
		}

		[InlineCode("{this}.nav.selectItem({value})")]
		public void Select(string value)
		{
		}

		[InlineCode("{this}.nav.disableItem({value},{disable})")]
		public void Disable(string value, bool disable=true)
		{
		}

		[InlineCode("{this}.nav.disableAll({disable})")]
		public void DisableAll( bool disable=true)
		{
		}

		[InlineCode("{this}.nav.addDivider()")]
		public void AddDivider()
		{
		}


		[InlineCode("{this}.nav.getItem({value})")]
		public NavItem GetItem(string value)
		{
			return null;
		}

		[IntrinsicProperty]
		internal Nav Nav {
			get;
			set;
		}

	}
}