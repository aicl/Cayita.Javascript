using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class DropdownTab:DropdownMenu
	{

		[InlineCode("Cayita.UI.DropdownTab({parent},{text},{iconClass})")]
		protected internal DropdownTab (TabPanel parent, string text, string iconClass)
		{
		}

		public void Add(Tab tab){
		}

	}
}
