using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Label:Atom
	{
		[InlineCode("Cayita.UI.Label()")]
		public Label(){}

		[InlineCode("Cayita.UI.Label (null, {text}, null, {parent})")]
		public Label (Atom parent, string text=null)
		{
		}

		[InlineCode("Cayita.UI.Label({className})")]
		public Label(string className){}


		[InlineCode("Cayita.UI.Label (null, null, {action}, {parent})")]
		public Label (Atom parent, Action<Label> action)
		{
		}

		public string For {
			get;
			set;
		}
	}
}

