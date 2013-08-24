using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NavList:NavBase
	{
		[InlineCode("Cayita.UI.NavList({parent})")]
		public NavList(Atom parent=null){
		}

		public string Header {
			[InlineCode("{this}.nav.get_header()")]get;
			[InlineCode("{this}.nav.set_header({value})")]set;
		}

		[InlineCode("{this}.nav.addDivider('divider')")]
		public new void AddDivider()
		{
		}

	}
}
