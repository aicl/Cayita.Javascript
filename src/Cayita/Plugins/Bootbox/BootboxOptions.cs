using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class BootboxOptions
	{
		[InlineCode("Cayita.Plugins.BootboxOptions()")]
		public BootboxOptions ()
		{
		}

		[IntrinsicProperty]
		public bool HeaderCloseButton {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Header {
			get;
			set;
		}

		[IntrinsicProperty]
		public bool Animate {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Classes {
			get;
			set;
		}

		[IntrinsicProperty]
		public Action OnEscape {
			get; set;
		}


		[IntrinsicProperty]
		public bool Backdrop {
			get;
			set;
		}

	}


}

