using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class SelectField :HtmlSelect
	{
		
		public Div ControlGroup {get;private set;}
		public Label Label {get; private set;}
		public Div Controls {get;private set;}


		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElemente, SelectElement>.
		/// </param>
		public SelectField(Element parent, Action<Element,SelectElement> field)
		{
			ControlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				Label = Label.CreateControlLabel(cgDiv, "");
				Controls = Div.CreateControls( cgDiv, ctDiv=>{
					Init(ctDiv);
					Label.ForField( Element().ID);
					field(Label.Element(), Element());
				});
			});  
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<SelectElement>
		/// </param>
		public SelectField(Element parent, Action<SelectElement> field)
		{
			ControlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				Label = Label.CreateControlLabel(default(Element), "");
				Controls = new Div( cgDiv,  ctDiv=>{
					Init(ctDiv);
					Label.ForField( Element().ID);
					field(Element());
				});
			});  
		}

	}
}
