using System;
using System.Html;

namespace Cayita.UI
{

	public class TextField:Field<TextField>
	{
		public TextField(Element parent=null):base(parent, "text")
		{
		}
		
		public TextField(Action<LabelElement,TextElement> field):this(null, field)
		{
		}
		
		public TextField(Element parent, Action<LabelElement,TextElement> field):this(parent)
			
		{
			field.Invoke(ControlLabel.Element(), Element().As<TextElement>());
			ControlLabel.For( Element().ID);
			if( string.IsNullOrEmpty( ControlLabel.TextLabel()) ) ControlLabel.Hide();
		}
		
		public TextField(Action<TextElement> field):this(null, field)
		{
		}
		
		public TextField(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element().As<TextElement>());
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