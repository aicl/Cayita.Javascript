using System;
using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class PasswordField:Field<string>
	{
		[InlineCode("Cayita.UI.PasswordField()")]
		public PasswordField()
		{
		}

		[InlineCode("Cayita.UI.PasswordField({name},{placeholder})")]
		public PasswordField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.PasswordField(null, null, {action},{parent})")]
		public PasswordField(Atom parent, Action<PasswordField> action=null){}

	}
}

