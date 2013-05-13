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
			field.Invoke(Label.Element(), Element().As<TextElement>());
			Label.For( Element().ID);
			if( string.IsNullOrEmpty( Label.TextLabel()) ) Label.Hide();
		}
		
		public TextField(Action<TextElement> field):this(null, field)
		{
		}
		
		public TextField(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element().As<TextElement>());
			Label.For(Element().ID).Hide();
		}
		
		public TextField(Element parent, string label, string fieldname):
			this(parent)
		{
			Label.Text (label);
			Name(fieldname);
		}

		public new TextElement Element()
		{
			return base.Element().As<TextElement> ();
		}

	}


}