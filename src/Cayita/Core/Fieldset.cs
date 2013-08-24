using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Fieldset:Atom
	{
		[InlineCode("Cayita.UI.Atom('fieldset')")]
		public Fieldset(){}

		[InlineCode("Cayita.UI.Atom('fieldset',null,null,null,{action},{parent})")]
		public Fieldset(Atom parent, Action<Div> action=null){}

		[InlineCode("Cayita.UI.Atom('fieldset',null,null,null,{action})")]
		public Fieldset(Action<Div> action=null){}
	}
}

