using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class HtmlList:Atom
	{
		[InlineCode("Cayita.UI.HtmlList()")]
		public HtmlList ()
		{
		}

		[InlineCode("Cayita.UI.HtmlList({className})")]
		public HtmlList(string className){}

	}
}

