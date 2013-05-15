using System;
using System.Html;

namespace Cayita.UI
{

	public class TextField:TextFieldBase<TextField>
	{

		public TextField():base(){}

		public TextField(ElementBase parent):base(parent.Element()){}


		public TextField(Element parent):base(parent)
		{
		}
		
		public TextField(Action<LabelElement,TextElement> field):base(null, field)
		{
		}
		
		public TextField(Element parent, Action<LabelElement,TextElement> field):base(parent)
			
		{
		}
		
		public TextField(Action<TextElement> field):base(null, field)
		{
		}
		
		public TextField(Element parent, Action<TextElement> field):base(parent, field)
		{
		}
		
		public TextField(Element parent, string label, string fieldname):
			base(parent,label, fieldname)
		{

		}

	}
	
}