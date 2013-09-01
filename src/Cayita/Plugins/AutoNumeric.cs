using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public  class AutoNumeric
	{
		[InlineCode("Cayita.Plugins.AutoNumeric({atom}, {options})")]
		public AutoNumeric(Element atom, NumericOptions options=null)
		{
		}

		public decimal? Value {
			[InlineCode("{this}.autoNumeric.get()")]
			get;
			[InlineCode("{this}.autoNumeric.set({value})")]
			set;
		}

		public NumericOptions Settings {
			[InlineCode("{this}.autoNumeric.getSettings()")]
			get;
			[InlineCode("{this}.autoNumeric.update({value})")]
			set;
		}

		[InlineCode("{this}.autoNumeric.update{options}")]
		public void Update (NumericOptions options) {

		}


		public string Text {
			[InlineCode("{this}.autoNumeric.get_text()")] get { return ""; } 
		}
	}

}

