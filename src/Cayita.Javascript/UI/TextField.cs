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

		public TextField(ElementBase parent, Action<Element,TextElement> field)
			:this(parent.Element(), field)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.TextField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElment, TextElement>
		/// </param>
		public TextField(Element parent, Action<Element,TextElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent, cge=>{
				label = Label.CreateControlLabel(cge,"");
				controls = Div.CreateControls(cge, cte=>{
					CreateInput(cte, new TextConfig());
					label.ForField( Element().ID);
					field(label.Element(), Element());
				});
			});
		}

		public TextField(Element parent, Action<TextElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent, cge=>{
				label = Label.CreateControlLabel(null,"");
				controls = new Div(cge, cte=>{
					CreateInput(cte, new TextConfig());
					label.ForField( Element().ID);
					field(Element());
				});
			});
		}

		public Div GetControGroup()
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
