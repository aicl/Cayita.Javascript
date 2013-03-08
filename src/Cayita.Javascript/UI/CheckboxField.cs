using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public class CheckboxField :InputCheckbox
	{
		Div controlGroup ;
		Div controls ;
		

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.CheckboxField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElement,ChecBoxElement>
		/// </param>
		public CheckboxField(Element parent, Action<LabelElement,CheckBoxElement> field)
		{

			controlGroup =  Div.CreateControlGroup(parent,  cgDiv=>{
				controls= Div.CreateControls(cgDiv,  ctdiv=>{
					var label = new Label(ctdiv, lb=>{
						lb.ClassName="checkbox";
					});
					Init( default(Element) );
					field(label.Element(), Element());  
					label.ForField(Element().ID);
					label.Element().AppendChild(Element());
				});
			});
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.CheckboxField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='textLabel'>
		/// Text label.
		/// </param>
		/// <param name='field'>
		/// Field<CheckBoxElement>
		/// </param>
		public CheckboxField(Element parent,string textLabel, Action<CheckBoxElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent,cgDiv=>{
				controls=  Div.CreateControls(cgDiv, ctdiv=>{
					
					var label = new Label(ctdiv, lb=>{
						lb.ClassName="checkbox";
						lb.Text(textLabel);
					});
					
					Init( default(Element));
					field( Element());  
					label.ForField(Element().ID);
					label.Element().AppendChild(Element());
				});
			});
		}

		public Div GetControlGroup()
		{
			return controlGroup;
		}

		public Div GetControls()
		{
			return controls;
		}

	}
}