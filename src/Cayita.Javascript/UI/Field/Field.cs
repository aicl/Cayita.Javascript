using System;
using System.Html;

namespace Cayita.UI
{
	
	public abstract class Field<TField>:InputBase<TField> where   TField:ElementBase
	{
		public Label ControlLabel  { get; protected set; }
		public Div Controls { get; protected set; }
		public Div ControlGroup { get; protected set; }

		public Field (Element parent=null, string type="text", bool append=true):base(parent, type)
		{

			ControlGroup = new Div (parent).ClassName ("control-group");
			ControlLabel = new Label ().ClassName ("control-label");
			Controls = new Div ().ClassName ("controls");

			if(append) base.AppendTo (Controls);
			ControlGroup.Append (ControlLabel);
			ControlGroup.Append (Controls);

		}

		public new TField Text(string value)
		{
			ControlLabel.Text (value);
			return As<TField> ();
		}

		public new string Text()
		{
			return ControlLabel.Text ();
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
			field.Invoke(ControlLabel.Element(), Element().As<TextElement>());
			ControlLabel.For( Element().ID);
			if( string.IsNullOrEmpty( ControlLabel.TextLabel()) ) ControlLabel.Hide();
		}

		public Field(Action<TextElement> field):this(null, field)
		{
		}
		
		public Field(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element().As<TextElement>());
			ControlLabel.For(Element().ID).Hide();
		}
		
		public Field(Element parent, string label, string fieldname):
			this(parent)
		{
			ControlLabel.Text (label);
			Name(fieldname);
		}

	}


}


