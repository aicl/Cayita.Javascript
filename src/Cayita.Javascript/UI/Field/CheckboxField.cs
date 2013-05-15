using System;
using System.Html;

namespace Cayita.UI
{
	
	public class CheckboxField:Field<CheckboxField>
	{
		public Label Label  { get; protected set; }

		public CheckBoxElement Input { get; protected set; }


		public CheckboxField():this(default(Element))
		{

		}

		public CheckboxField(ElementBase parent):this(parent.Element())
		{
			
		}

		public CheckboxField(Element parent ):base(parent, "checkbox",false)
		{
			Input = Element ();

			Element ().Value = "true";
			Label = new Label(Controls.Element(), l=>{
				l.ClassName="checkbox";
				l.For=Element().ID;
				l.Append(Element());
			});

		}
		
		public CheckboxField(Action<LabelElement,CheckBoxElement> field):this(null, field)
		{
		}
		
		public CheckboxField(Element parent, Action<LabelElement,CheckBoxElement> field):this(parent)
			
		{
			field.Invoke(Label.Element(), Element());
			Label.For( Element().ID);
		}

		
		public CheckboxField(Element parent, string label, string fieldname):
			this(parent)
		{
			Label.Text (label);
			Name(fieldname);
		}

		public new CheckboxField Text(string value)
		{
			Label.Text (value);
			return this;
		}
		
		public new string Text()
		{
			return Label.Text ();
		}


		public new CheckBoxElement Element()
		{
			return base.Element().As<CheckBoxElement> ();
		}
		
	}
		
}