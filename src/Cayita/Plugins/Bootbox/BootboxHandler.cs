using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class BootboxHandler
	{
		[InlineCode("{}")]
		public BootboxHandler ()
		{
		}

		[IntrinsicProperty]
		public string Label { get; set; }
		[IntrinsicProperty]
		public string Class { get; set; }
		[IntrinsicProperty]
		public Action Callback { get; set; }

	}
}

