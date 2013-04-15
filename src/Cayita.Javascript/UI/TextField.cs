using System;
using System.Html;

namespace Cayita.UI
{
	
	public class TextField:Div
	{		
		DivElement cg ;
		LabelElement lb ;
		DivElement ctrls ;
		TextElement te;
		
		void Init()
		{
			cg = Element ();
			cg.ClassName = "control-group";

			lb = new Label(cg,l=>l.ClassName="control-label").Element();
			
			ctrls = Div.CreateControls(cg, div=>{
				te = new InputText(div).Element();
				
			}).Element();
			
		}
		
		
		public TextField(Element parent, Action<LabelElement,TextElement> field)
			:base(parent)
		{
			Init ();
			
			field.Invoke(lb, te);
			lb.For= te.ID;
			
			if( string.IsNullOrEmpty( lb.Text()) ) lb.Hide();
			
		}
		
		public TextField(Element parent, Action<TextElement> field):base(parent)
		{
			Init ();
			field.Invoke(te);
			lb.For= te.ID;
			lb.Hide();
			
		}
		
		public TextField(Element parent, string label, string fieldname):
			this(parent, (l,f)=>{l.Text(label); f.Name=fieldname;})
		{
		}
		
		
		
		public DivElement Controls()
		{
			return ctrls;
		}
		
		public LabelElement Label()
		{
			return lb;
		}
		
		public TextElement TextElement()
		{
			return te;
		}
	}
}