using System;
using System.Html;

namespace Cayita.UI
{

	public class TextField:Field<TextField>
	{
		public TextElement Input { get; protected set; }

		public TextField(Element parent=null):base(parent, "text")
		{
			Input = Element ();
		}
		
		public TextField(Action<LabelElement,TextElement> field):this(null, field)
		{
		}
		
		public TextField(Element parent, Action<LabelElement,TextElement> field):this(parent)
			
		{
			field.Invoke(ControlLabel.Element(), Element());
			ControlLabel.For( Element().ID);
			if( string.IsNullOrEmpty( ControlLabel.TextLabel()) ) ControlLabel.Hide();
		}
		
		public TextField(Action<TextElement> field):this(null, field)
		{
		}
		
		public TextField(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element());
			ControlLabel.For(Element().ID).Hide();
		}
		
		public TextField(Element parent, string label, string fieldname):
			this(parent)
		{
			ControlLabel.Text (label);
			Name(fieldname);
		}

		public new TextElement Element()
		{
			return base.Element().As<TextElement> ();
		}

	}


}