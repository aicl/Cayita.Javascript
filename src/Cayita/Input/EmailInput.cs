using System;
using System.Runtime.CompilerServices;

namespace Cayita
{



	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class EmailInput:Input<string>
	{

		[InlineCode("Cayita.UI.Input(String)('input','email')")]
		public EmailInput ()
		{
		}

		[InlineCode("Cayita.UI.Input(String)('input','email',null, null, null,{action},{parent})")]
		public EmailInput (Atom parent, Action<EmailInput> action=null)
		{
		}

	}
}

