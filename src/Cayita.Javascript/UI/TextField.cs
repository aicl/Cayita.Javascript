using System;
using System.Html;

namespace Cayita.UI
{
	
	public class TextField:Div
	{		
		public Label Label  { get; protected set; }
		public Div Controls { get; protected set; }
		public InputText Input { get; protected set; }
		
		void Init()
		{
			ClassName("control-group");
			Label = new Label().ClassName("control-label");
			Input = new InputText ();
			Controls = new Div ().ClassName("controls").Append (Input); 
			Append (Label);
			Append (Controls);
		}
				
		public TextField(Element parent, Action<LabelElement,TextElement> field)
			:base(parent)
		{
			Init ();
			field.Invoke(Label.Element(), Input.Element());
			Label.For( Input.ID);
			if( string.IsNullOrEmpty( Label.TextLabel()) ) Label.Hide();
		}
		
		public TextField(Element parent, Action<TextElement> field):base(parent)
		{
			Init ();
			field.Invoke(Input.Element());
			Label.For(Input.ID).Hide();
		}
		
		public TextField(Element parent, string label, string fieldname):
			this(parent, (l,f)=>{l.Text(label); f.Name=fieldname;})
		{
		}

		public TextField(Element parent=null):base(parent)
		{
			Init ();
		}
	}
}