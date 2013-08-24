using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class DropdownMenu:Anchor
	{

		[InlineCode("Cayita.UI.DropdownMenu()")]
		public DropdownMenu ()
		{
		}

		public string IconClass { 
			get;
			set;
		}

		[IntrinsicProperty]
		public Nav Nav { 
			get ;
			internal set;
		}


		public void AddTo(Element parent)
		{
		}

		[IntrinsicProperty]
		public  CssIcon Icon {
			get;
			internal set;
		}

	}
}

