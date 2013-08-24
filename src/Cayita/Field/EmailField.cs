using System;
using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class EmailField:Field<string>
	{
		[InlineCode("Cayita.UI.EmailField()")]
		public EmailField()
		{
		}

		[InlineCode("Cayita.UI.EmailField({name},{placeholder})")]
		public EmailField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.EmailField(null, null, {action},{parent})")]
		public EmailField(Atom parent, Action<EmailField> action=null){}

	}
}

