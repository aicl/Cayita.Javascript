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
		
		public CheckboxField(ElementBase parent, Action<Element,CheckBoxElement> field)
			:this(parent.Element(), field)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.CheckboxField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElemente,ChecBoxElement>
		/// </param>
		public CheckboxField(Element parent, Action<Element,CheckBoxElement> field)
		{

			controlGroup =  Div.CreateControlGroup(parent,  cgDiv=>{
				controls= Div.CreateControls(cgDiv,  ctdiv=>{
					var label = new Label(ctdiv, lb=>{
						lb.ClassName="checkbox";
					});
					Init( default(Element) );
					label.ForField(Element().ID);
					field(label.Element(), Element());  
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
					
					label.ForField(Element().ID);
					field( Element());  
					
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

/*
<div class="control-group">
    <div class="controls">
      <label class="checkbox">
        <input type="checkbox"> Remember me
      </label>
      <button type="submit" class="btn">Sign in</button>
    </div>
</div>
*/