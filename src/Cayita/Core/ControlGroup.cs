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


		[IntrinsicProperty]
		public Label Label {
			get;
			internal set;
		}

		[IntrinsicProperty]
		public Div Controls {
			get;
			internal set;
		}
	

		public string LabelText {
			[InlineCode("{this}.label.get_text()")]
			get;
			[InlineCode("{this}.label.set_text({value})")]
			set;
		}

		public string LabelCssText {
			[InlineCode("{this}.label.style.cssText")]
			get;
			[InlineCode("{this}.label.style.cssText={value}")]
			set;
		}

		public Style LabelStyle {
			[InlineCode("{this}.label.style")]
			get { return null; }
		}

	}

}
