using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class TextAreaField:TextArea
	{		
		Div controlGroup ;
		Label label ;
		Div controls ;

		public TextAreaField(Element parent, Action<Element,TextAreaElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent, cge=>{
				label = Label.CreateControlLabel(cge,"");
				controls = Div.CreateControls(cge, cte=>{
					CreateElement("textarea",cte);
					field(label.Element(), Element());
					label.ForField( Element().ID);
				});
				if( string.IsNullOrEmpty( label.TextLabel()) ) label.Hide();
			});
		}
		
		public TextAreaField(Element parent, Action<TextAreaElement> field)
		{
			controlGroup = Div.CreateControlGroup(parent, cge=>{
				label = Label.CreateControlLabel(cge,"");
				label.Hide();
				controls = new Div(cge, cte=>{
					CreateElement("textarea",cte);
					field(Element());
					label.ForField( Element().ID);
				});
			});
		}
		
		public TextAreaField(Element parent, string label, string fieldname):
			this(parent, (l,f)=>{l.Text(label); f.Name=fieldname;})
		{
		}
		
		
		public Div GetControlGroup()
		{
			return controlGroup;
		}
		
		public Div GetControls()
		{
			return controls;
		}
		
		public Label GetLabel()
		{
			return label;
		}
	}
}