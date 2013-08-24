using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class OptionAtom<T> : Atom
	{
		[InlineCode("Cayita.UI.OptionAtom({T})()")]
		public OptionAtom(){
		}

		[IntrinsicProperty]
		public FormElement Form
		{
			get
			{
				return null;
			}
		}
		[IntrinsicProperty]
		public bool Selected {
			get;
			set;
		}


		public T Value {
			[InlineCode("{this}.get_value()")]
			get;
			[InlineCode("{this}.set_value({value})")]
			set;
		}

	}
}
