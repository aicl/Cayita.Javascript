using System;
using System.Html;

namespace Cayita.UI
{

	public abstract class TextFieldBase<T>:Field<T> where T:InputBase<T>
	{
		public TextElement Input { get; protected set; }
		
		public TextFieldBase(Element parent=null):base(parent, "text")
		{
			Input = Element ();
		}
		
		public TextFieldBase(Action<LabelElement,TextElement> field):this(null, field)
		{
		}
		
		public TextFieldBase(Element parent, Action<LabelElement,TextElement> field):this(parent)
			
		{
			field.Invoke(ControlLabel.Element(), Element().As<TextElement>());
			ControlLabel.For( Element().ID);
			if( string.IsNullOrEmpty( ControlLabel.TextLabel()) ) ControlLabel.Hide();
		}
		
		public TextFieldBase(Action<TextElement> field):this(null, field)
		{
		}
		
		public TextFieldBase(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element().As<TextElement>());
			ControlLabel.For(Element().ID).Hide();
		}
		
		public TextFieldBase(Element parent, string label, string fieldname):
			this(parent)
		{
			ControlLabel.Text (label);
			Name(fieldname);
		}
		
		public new TextElement Element()
		{
			return base.Element ().As<TextElement> ();
		}
		
	}
	
	
}


