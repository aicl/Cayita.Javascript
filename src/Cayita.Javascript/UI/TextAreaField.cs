using System;
using System.Html;

namespace Cayita.UI
{

	public class TextAreaField:Div
	{		
		DivElement cg ;
		LabelElement lb ;
		DivElement ctrls ;
		TextAreaElement te;

		void Init()
		{
			cg = Element ();
			
			lb = new Label(cg,l=>l.ClassName="control-group").Element();
			
			ctrls = Div.CreateControls(cg, div=>{
				te = new TextArea(div).Element();
				
			}).Element();

		}


		public TextAreaField(Element parent, Action<LabelElement,TextAreaElement> field)
			:base(parent)
		{
			Init ();

			field.Invoke(lb, te);
			lb.For= te.ID;

			if( string.IsNullOrEmpty( lb.Text()) ) lb.Hide();

		}
		
		public TextAreaField(Element parent, Action<TextAreaElement> field):base(parent)
		{
			Init ();
			field.Invoke(te);
			lb.For= te.ID;
			lb.Hide();

		}
		
		public TextAreaField(Element parent, string label, string fieldname):
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

		public TextAreaElement TextArea()
		{
			return te;
		}
	}
}