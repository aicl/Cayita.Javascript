using System.Runtime.CompilerServices;
using System;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CssIcon:Atom
	{
		[InlineCode("Cayita.UI.Atom('i')")]
		public CssIcon(){}

		[InlineCode("Cayita.UI.Atom('i',null,{className})")]
		public CssIcon(string className){}


		[InlineCode("Cayita.UI.Atom('i',null,{className},null,null,{parent})")]
		public CssIcon(Atom parent, string className){}

		[InlineCode("Cayita.UI.Atom('i',null,null,null,{action},{parent})")]
		public CssIcon (Atom parent,Action<CssIcon> action)
		{
		}

		[InlineCode("Cayita.UI.Atom('i',null,null,null,{action},null)")]
		public CssIcon (Action<CssIcon> action)
		{
		}
	}
}

