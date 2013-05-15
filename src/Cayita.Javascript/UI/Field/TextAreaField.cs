using System;
using System.Html;

namespace Cayita.UI
{
	
	public class TextAreaField:Field<TextAreaField>
	{
		public TextAreaElement Input { get; protected set; }
		
		public TextAreaField(Element parent=null):base(parent, type:null,tagname:"textarea")
		{
			Input = Element ();
		}
		
		public TextAreaField(Action<LabelElement,TextAreaElement> field):this(null, field)
		{
		}
		
		public TextAreaField(Element parent, Action<LabelElement,TextAreaElement> field):this(parent)
			
		{
			field.Invoke(ControlLabel.Element(), Element());
			ControlLabel.For( Element().ID);
			if( string.IsNullOrEmpty( ControlLabel.TextLabel()) ) ControlLabel.Hide();
		}
		
		public TextAreaField(Action<TextAreaElement> field):this(null, field)
		{
		}
		
		public TextAreaField(Element parent, Action<TextAreaElement> field):this(parent)
		{
			field.Invoke(Element());
			ControlLabel.For(Element().ID).Hide();
		}
		
		public TextAreaField(Element parent, string label, string fieldname):
			this(parent)
		{
			ControlLabel.Text (label);
			Name(fieldname);
		}
		
		public new TextAreaElement Element()
		{
			return base.Element().As<TextAreaElement> ();
		}
		
	}
	
	
}