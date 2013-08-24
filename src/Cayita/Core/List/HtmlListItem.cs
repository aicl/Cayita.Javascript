using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class HtmlListItem:Atom
	{
		[InlineCode("Cayita.UI.Atom('li',null,null)")]
		public HtmlListItem ()
		{
		}

		[InlineCode("Cayita.UI.Atom('li',null,{className},{text})")]
		public HtmlListItem(string className, string text=null){}

	}

}