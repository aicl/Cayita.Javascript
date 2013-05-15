using System;
using System.Html;

namespace Cayita.UI
{
	
	public abstract class Field<TField>:InputBase<TField> where  TField:ElementBase
	{
		public Label ControlLabel  { get; protected set; }
		public Div Controls { get; protected set; }
		public Div ControlGroup { get; protected set; }

		public Field (Element parent=null, string type="text", bool append=true, string tagname="input"):base(parent,type,tagname)
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
	
}


