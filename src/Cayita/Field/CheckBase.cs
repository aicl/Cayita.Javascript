using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[ScriptNamespace("C")]
	public abstract class CheckBase<TInput>:Field<TInput> where TInput: Input, new () 
	{
		protected CheckBase (string type):base(false)
		{
			InputLabel = new Label { ClassName=type };
			InputLabel.Append (Input);
			Controls.Append (InputLabel);
		}


		public Label InputLabel 
		{ 
			[InlineCode("{this}.InputLabel")]
			get;
			[InlineCode("{this}.InputLabel={value}")]
			protected set;
		}

		
		public bool Checked
		{
			[InlineCode("{this}.Input.El.checked")]
			get; 
			[InlineCode("{this}.Input.El.checked={value}")]
			set; 
		}
		
		public string InputLabelText {
			[InlineCode("AtomFn.GetText({this}.InputLabel)")]
			get;
			[InlineCode("AtomFn.SetText({this}.InputLabel, {value})")]
			set;
		}
		
		public string InputLabelCssText {
			[InlineCode("{this}.InputLabel.El.style.cssText")]
			get;
			[InlineCode("{this}.InputLabel.El.style.cssText={value}")]
			set;
		}
		
		public Style InputLabelStyle {
			[InlineCode("{this}.InputLabel.El.style")]
			get { return null; }
		}



	}
	
}

