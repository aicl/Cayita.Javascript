using System;
using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class PasswordInput:Input<string>
	{

		[InlineCode("Cayita.UI.Input(String)('input','password')")]
		public PasswordInput ()
		{
		}

		[InlineCode("Cayita.UI.Input(String)('input','password',null, null, null,{action},{parent})")]
		public PasswordInput (Atom parent, Action<PasswordInput> action=null)
		{
		}

	}
}

