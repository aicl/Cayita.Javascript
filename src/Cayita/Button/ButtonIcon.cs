using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class ButtonIcon:Button
	{
		[InlineCode("Cayita.UI.ButtonIcon()")]
		public ButtonIcon ()
		{
		}

		[InlineCode("Cayita.UI.ButtonIcon({iconClass})")]
		public ButtonIcon (string iconClass)
		{
		}

		[InlineCode("Cayita.UI.ButtonIcon(null, {action},{parent})")]
		public ButtonIcon(Atom parent, Action<ButtonIcon> action=null){}


		[InlineCode("Cayita.UI.ButtonIcon(null, {action},null)")]
		public ButtonIcon(Action<ButtonIcon> action){}


		[IntrinsicProperty]
		public CssIcon  Icon{ get; protected internal set; }


		public string IconClass{ get; set; }
	}
}

