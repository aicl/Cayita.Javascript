using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Tab:Anchor
	{
		[InlineCode("Cayita.UI.Tab()")]
		public Tab ()
		{
		}

		public string Caption { 
			get; 
			set; 
		}

		public  new bool Disabled { 
			[InlineCode("{this}.isDisabled()")]get; 
			[InlineCode("{this}.disable({value})")]set; 
		}


		[IntrinsicProperty]
		public Div Body { 
			get{ return null; }
		}

		[IntrinsicProperty]
		protected internal HtmlListItem Item { get; set; }


		[IntrinsicProperty]
		public Action<Tab> ClickHandler { get; set; }

	}


}

