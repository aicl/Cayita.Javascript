using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class ResetButton:Button
	{
		[InlineCode("Cayita.UI.ResetButton()")]
		public ResetButton ()
		{
		}

		[InlineCode("Cayita.UI.ResetButton({text})")]
		public ResetButton (string text)
		{
		}

		[InlineCode("Cayita.UI.ResetButton(null, {action},{parent})")]
		public ResetButton(Atom parent, Action<Div> action=null){}


		[InlineCode("Cayita.UI.ResetButton(null, {action},null)")]
		public ResetButton(Action<Div> action){}

	}
}

