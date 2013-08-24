using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NavBar:NavBase
	{
		[InlineCode("Cayita.UI.NavBar()")]
		public NavBar(){
		}

		public string BrandText {
			[InlineCode("{this}.nav.get_brandText()")]
			get;
			[InlineCode("{this}.nav.set_brandText({value})")]
			set;
		}

		public bool Inverse {
			[InlineCode("{this}.nav.is_inverse()")]
			get;
			[InlineCode("{this}.nav.inverse({value})")]
			set;
		}

		[InlineCode("{this}.nav.addDivider('divider-vertical')")]
		public new void AddDivider()
		{
		}

		[InlineCode("{this}.collapse.addElement({element})")]
		public void AddElement(Atom element)
		{
		}

		public event jQueryEventHandler BrandClicked
		{
			[InlineCode("{this}.nav.add_brandClicked({value})")]
			add{
			}
			[InlineCode("{this}.nav.remove_brandClicked({value})")]
			remove{
			}
		}

		internal Anchor Brand {
			[InlineCode("{this}.nav.$brand")]
			get;
			[InlineCode("{this}.nav.$brand={value}")]
			set;
		}


		[IntrinsicProperty]
		internal Div Collapse {
			get;
			set;
		}

	}
}
