using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TextField:Field<string>
	{
		[InlineCode("Cayita.UI.TextField()")]
		public TextField()
		{
		}

		[InlineCode("Cayita.UI.TextField({name},{placeholder})")]
		public TextField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.TextField(null, null, {action},{parent})")]
		public TextField(Atom parent, Action<TextField> action=null){}
	}
}
