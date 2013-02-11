using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class TextField :InputText
	{

		public Div ControlGroup {get;private set;}
		public Label Label {get; private set;}
		public Div Controls {get;private set;}

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
			ControlGroup = Div.CreateControlGroup(parent, cge=>{
				Label = Label.CreateControlLabel(cge,"");
				Controls = Div.CreateControls(cge, cte=>{
					CreateInput(cte, new TextConfig());
					Label.ForField( Element().ID);
					field(Label.Element(), Element());
				});
			});
		}

		public TextField(Element parent, Action<TextElement> field)
		{
			ControlGroup = Div.CreateControlGroup(parent, cge=>{
				Label = Label.CreateControlLabel(null,"");
				Controls = new Div(cge, cte=>{
					CreateInput(cte, new TextConfig());
					Label.ForField( Element().ID);
					field(Element());
				});
			});
		}

	}
}
