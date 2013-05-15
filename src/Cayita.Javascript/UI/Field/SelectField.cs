using System;
using System.Html;

namespace Cayita.UI
{

	public abstract class SelectFieldBase<T>:Field<T> where T:InputBase<T>
	{
		public SelectElement Input { get; protected set; }
		
		public SelectFieldBase(Element parent=null,string type="select-one"):base(parent, type:type,tagname:"select")
		{
			Input = Element ();
		}
		
		public SelectFieldBase(Action<LabelElement,SelectElement> field):this(null, field)
		{
		}
		
		public SelectFieldBase(Element parent, Action<LabelElement,SelectElement> field):this(parent)
			
		{
			field.Invoke(ControlLabel.Element(), Element());
			ControlLabel.For( Element().ID);
			if( string.IsNullOrEmpty( ControlLabel.TextLabel()) ) ControlLabel.Hide();
		}
		
		public SelectFieldBase(Action<SelectElement> field):this(null, field)
		{
		}
		
		public SelectFieldBase(Element parent, Action<SelectElement> field):this(parent)
		{
			field.Invoke(Element());
			ControlLabel.For(Element().ID).Hide();
		}
		
		public SelectFieldBase(Element parent, string label, string fieldname):
			this(parent)
		{
			ControlLabel.Text (label);
			Name(fieldname);
		}
		
		public new SelectElement Element()
		{
			return base.Element().As<SelectElement> ();
		}

	}

	public class SelectField:SelectFieldBase<SelectField>
	{

		public SelectField(Element parent=null):base(parent)
		{
		}
		
		public SelectField(Action<LabelElement,SelectElement> field):base(null, field)
		{
		}
		
		public SelectField(Element parent, Action<LabelElement,SelectElement> field):base(parent, field)	
		{
		}
		
		public SelectField(Action<SelectElement> field):base(null, field)
		{
		}
		
		public SelectField(Element parent, Action<SelectElement> field):base(parent,field)
		{
		}
		
		public SelectField(Element parent, string label, string fieldname):
			base(parent, label, fieldname)
		{
		}

	}
	
	
}