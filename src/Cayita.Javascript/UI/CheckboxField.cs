using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class CheckboxField :InputCheckbox
	{
		public Div ControlGroup {get;private set;}
		public Div Controls {get;private set;}
		
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

			ControlGroup =  Div.CreateControlGroup(parent,  cgDiv=>{
				Controls= Div.CreateControls(cgDiv,  ctdiv=>{
					var label = new Label(ctdiv, new LabelConfig{
						CssClass="checkbox"
					});
					Init( default(Element), new CheckboxConfig());
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
			
			ControlGroup = Div.CreateControlGroup(parent,cgDiv=>{
				Controls=  Div.CreateControls(cgDiv, ctdiv=>{
					
					var label = new Label(ctdiv, new LabelConfig{
						CssClass="checkbox",
						TextLabel=textLabel
					});
					
					Init( default(Element), new CheckboxConfig());
					
					label.ForField(Element().ID);
					field( Element());  
					
					label.Element().AppendChild(Element());
				});
			});
			
			
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