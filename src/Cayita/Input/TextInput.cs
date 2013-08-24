using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TextInput:Input<string>
	{

		[InlineCode("Cayita.UI.Input(String)('input','text')")]
		public TextInput ()
		{
		}

		[InlineCode("Cayita.UI.Input(String)('input','text',null, null, null,{action},{parent})")]
		public TextInput (Atom parent, Action<TextInput> action=null)
		{
		}

	}
}

