using System;
using System.Html;

namespace Cayita.UI
{
	
	public abstract class Field<TField>:InputBase<TField> where   TField:ElementBase
	{
		public Label Label  { get; protected set; }
		public Div Controls { get; protected set; }
		public Div ControlGroup { get; protected set; }

		public Field (Element parent=null, string type="text", bool labelAsParent=false):base(parent, type)
		{

			ControlGroup = new Div (parent).ClassName ("control-group");
			Label = new Label ().ClassName ("control-label");
			Controls = new Div ().ClassName ("controls");

			if (labelAsParent) {
				ControlGroup.Append (Controls);
				Controls.Append(Label);
				base.AppendTo (Label);

			} else {
				base.AppendTo (Controls);
				ControlGroup.Append (Label);
				ControlGroup.Append (Controls);
			}
		}

		public new TField Text(string value)
		{
			Label.Text (value);
			return As<TField> ();
		}

		public new string Text()
		{
			return Label.Text ();
		}


		public new  TField AppendTo(ElementBase parent)
		{
			ControlGroup.AppendTo(parent);
			return As<TField> ();
		}

		public new  TField SlideToggle()
		{
			ControlGroup.SlideToggle (); 
			return As<TField> ();
		}

		public new  TField Hide()
		{
			ControlGroup.Hide ();
			return As<TField> ();
		}

		public new  TField Show()
		{
			ControlGroup.Show ();
			return As<TField> ();
		}

	}

	public class Field:Field<Field>
	{
		public Field(Element parent=null):base(parent, "text")
		{
		}

		public Field(Action<LabelElement,TextElement> field):this(null, field)
		{
		}
		
		public Field(Element parent, Action<LabelElement,TextElement> field):this(parent)
			
		{
			field.Invoke(Label.Element(), Element().As<TextElement>());
			Label.For( Element().ID);
			if( string.IsNullOrEmpty( Label.TextLabel()) ) Label.Hide();
		}

		public Field(Action<TextElement> field):this(null, field)
		{
		}
		
		public Field(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element().As<TextElement>());
			Label.For(Element().ID).Hide();
		}
		
		public Field(Element parent, string label, string fieldname):
			this(parent)
		{
			Label.Text (label);
			Name(fieldname);
		}

	}


}


