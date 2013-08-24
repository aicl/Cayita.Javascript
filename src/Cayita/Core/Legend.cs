using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Legend:Atom
	{
		[InlineCode("Cayita.UI.Atom ('legend')")]
		public Legend ()
		{
		}

		[InlineCode("Cayita.UI.Atom ('legend',null, null, {text},null, {parent})")]
		public Legend (Atom parent, string text=null)
		{
		}

		[InlineCode("Cayita.UI.Atom ('legend',null, null, {text})")]
		public Legend (string text)
		{
		}

	}
}

