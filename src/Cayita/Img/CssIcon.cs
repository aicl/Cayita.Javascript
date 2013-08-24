using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CssIcon:Atom
	{
		[InlineCode("Cayita.UI.Atom('i',null,null)")]
		public CssIcon(){}

		[InlineCode("Cayita.UI.Atom('i',null,{className})")]
		public CssIcon(string className){}


		[InlineCode("Cayita.UI.Atom('i',null,{className},null,null,{parent})")]
		public CssIcon(Atom parent, string className){}

	}
}

