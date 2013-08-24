using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Span:Atom
	{
		[InlineCode("Cayita.UI.Atom('span',null,null)")]
		public Span(){}

		[InlineCode("Cayita.UI.Atom('span',null,{className})")]
		public Span(string className){}

		[InlineCode("Cayita.UI.Atom('span',null,null,null,{action},{parent})")]
		public Span(Atom parent, Action<Div> action=null){}

	}
}

