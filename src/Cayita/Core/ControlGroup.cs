using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class ControlGroup :Div
	{
		[InlineCode("Cayita.UI.ControlGroup()")]
		public ControlGroup()
		{
		}

		protected internal object MainObject {
			[InlineCode("{this}.cg")]
			get{ return null;}
		}

		public Label Label {
			[InlineCode("{this}.cg.label")]
			get { return  null; }

		}

		public Div Controls {
			[InlineCode("{this}.cg.controls")]
			get { return  null; }

		}
	
		public string LabelText {
			[InlineCode("{this}.cg.label.get_text()")]
			get;
			[InlineCode("{this}.cg.label.set_text({value})")]
			set;
		}

		public string LabelCssText {
			[InlineCode("{this}.cg.label.style.cssText")]
			get;
			[InlineCode("{this}.cg.label.style.cssText={value}")]
			set;
		}

		public Style LabelStyle {
			[InlineCode("{this}.cg.label.style")]
			get { return null; }
		}

	}

}
