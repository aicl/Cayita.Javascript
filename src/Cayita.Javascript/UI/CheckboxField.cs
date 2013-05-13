using System;
using System.Html;

namespace Cayita.UI
{
	
	public class CheckboxField:Field<CheckboxField>
	{
		public CheckboxField(Element parent=null):base(parent, "checkbox",true)
		{
			Element ().Value = "true";
			Label.ClassName ("checkbox");
		}
		
		public CheckboxField(Action<LabelElement,TextElement> field):this(null, field)
		{
		}
		
		public CheckboxField(Element parent, Action<LabelElement,TextElement> field):this(parent)
			
		{
			field.Invoke(Label.Element(), Element().As<TextElement>());
			Label.For( Element().ID);
			if( string.IsNullOrEmpty( Label.TextLabel()) ) Label.Hide();
		}
		
		public CheckboxField(Action<TextElement> field):this(null, field)
		{
		}
		
		public CheckboxField(Element parent, Action<TextElement> field):this(parent)
		{
			field.Invoke(Element().As<TextElement>());
			Label.For(Element().ID).Hide();
		}
		
		public CheckboxField(Element parent, string label, string fieldname):
			this(parent)
		{
			Label.Text (label);
			Name(fieldname);
		}
		
		public new CheckBoxElement Element()
		{
			return base.Element().As<CheckBoxElement> ();
		}
		
	}
	
	
}


/*
using System;
using System.Html;

namespace Cayita.UI
{

	public class CheckboxField :Div
	{
		DivElement cg ;
		DivElement ctrls ;

		LabelElement lb;
		CheckBoxElement cb;

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.UI.CheckboxField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElement,ChecBoxElement>
		/// </param>
		public CheckboxField(Element parent, Action<LabelElement,CheckBoxElement> field):base(parent)
		{
			Init (null);
			field.Invoke(lb,cb);
			lb.For= cb.ID;
			lb.Append(cb);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.UI.CheckboxField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='textLabel'>
		/// Text label.
		/// </param>
		/// <param name='field'>
		/// Field<CheckBoxElement>
		/// </param>
		public CheckboxField(Element parent,string textLabel, Action<CheckBoxElement> field):base(parent)
		{
			Init (textLabel);
			field.Invoke(cb);
			lb.For= cb.ID;
			lb.Append(cb);
		}


		void Init(string textLabel)
		{
			cg = Element ();
			cg.ClassName="control-group";
			
			ctrls= Div.CreateControls(cg,  div=>{
				lb = new Label(div, l=>{
					l.ClassName="checkbox";
					if(!string.IsNullOrEmpty(textLabel)) l.Text(textLabel);
				}).Element();
				
				cb = new InputCheckbox().Element();
			}).Element();
		}

		public DivElement Controls()
		{
			return ctrls;
		}

		public LabelElement Label(){
			return lb;
		}

		public CheckBoxElement CheckBox(){
			return cb;
		}

	}
}
*/