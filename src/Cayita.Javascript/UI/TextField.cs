using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public class TextField :InputText
	{

		Div controlGroup ;
		Label label ;
		Div controls ;

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.TextField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElement, TextElement>
		/// </param>
		public TextField(Element parent, Action<LabelElement,TextElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent, cge=>{
				label = Label.CreateControlLabel(cge,"");
				controls = Div.CreateControls(cge, cte=>{
					CreateInput(cte);
					field(label.Element(), Element());
					label.ForField( Element().ID);
				});
				if( string.IsNullOrEmpty( label.TextLabel()) ) label.Hide();
			});
		}

		public TextField(Element parent, Action<TextElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent, cge=>{
				label = Label.CreateControlLabel(cge,"");
				label.Hide();
				controls = new Div(cge, cte=>{
					CreateInput(cte);
					field(Element());
					label.ForField( Element().ID);
				});
			});
		}

		public TextField(Element parent, string label, string fieldname):
			this(parent, (l,f)=>{l.Text(label); f.Name=fieldname;})
		{
		}


		public Div GetControlGroup()
		{
			return controlGroup;
		}
		
		public Div GetControls()
		{
			return controls;
		}
		
		public Label GetLabel()
		{
			return label;
		}
	}
}
