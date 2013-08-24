using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class SubmitButton:Button
	{
		[InlineCode("Cayita.UI.SubmitButton()")]
		public SubmitButton ()
		{
		}

		[InlineCode("Cayita.UI.SubmitButton({text})")]
		public SubmitButton (string text)
		{
		}

		[InlineCode("Cayita.UI.SubmitButton(null, {action},{parent})")]
		public SubmitButton(Atom parent, Action<Div> action=null){}


		[InlineCode("Cayita.UI.SubmitButton(null, {action},null)")]
		public SubmitButton(Action<Div> action){}
	}
}

