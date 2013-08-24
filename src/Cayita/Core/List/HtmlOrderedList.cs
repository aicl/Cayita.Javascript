using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class HtmlOrderedList:Atom
	{
		[InlineCode("Cayita.UI.Atom('ol',null,null)")]
		public HtmlOrderedList ()
		{
		}

		[InlineCode("Cayita.UI.Atom('ol',null,{className})")]
		public HtmlOrderedList(string className){}

	}
}

