using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TabPanel:Div
	{
		[InlineCode("Cayita.UI.TabPanel()")]
		public TabPanel ()
		{
		}

		[InlineCode("Cayita.UI.TabPanel({options})")]
		public TabPanel (TabPanelOptions options)
		{
		}

		[InlineCode("Cayita.UI.TabPanel({options}, {action})")]
		public TabPanel (TabPanelOptions options, Action<TabPanel> action)
		{
		}

		public DropdownTab AddDropdownTab(string text, string iconClass=null){
			return null;
		}

		public void Add(Tab tab){
		}

		[InlineCode("{this}.addTab({action})")]
		public void Add(Action<Tab> action){
		}

		public void GetTab(int index){
		}


		public void Remove(int index){
		}

		public void Remove(Tab tab){
		}


		public void Show(int index){
		}

		public void Show(Tab tab){
		}


		public void Disable(int index, bool value=true){
		}

		public void Disable(Tab tab, bool value=true){
		}

		public event jQueryEventHandler TabClicked {
			[InlineCode("{this}.add_tabClicked({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_tabClicked({value})")]
			remove
			{
			}
		}


		[IntrinsicProperty]
		public  HtmlList Links { get; internal set; }

		[IntrinsicProperty]
		public  Div Content { get; internal set; }


	}

}

