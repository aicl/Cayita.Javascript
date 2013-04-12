using System;

namespace Cayita.UI
{
	public class CheckBoxField:InputCheckBox
	{
		Div cg;
		Div ct;
		Label lb;

		public CheckBoxField ():base()
		{

			cg = new Div ();
			ct = new Div ();
			lb = new Label (l=>{
				l.ClassName="checkbox";
				l.For= Element().ID;
				l.Append(Element()); 
			});

			ct.Append (lb);
			cg.Append (ct);
		}

		public Div ControlGroup()
		{
			return cg;
		}

		public Div Control()
		{
			return ct;
		}

		public Label Label()
		{
			return lb;
		}

		public CheckBoxField Apply(Action<CheckBoxField> field)
		{
			field (this);
			return this;
		}

	}
}

