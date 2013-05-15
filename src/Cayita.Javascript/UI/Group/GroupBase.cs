using System;
using System.Html;
using System.Collections.Generic;

namespace Cayita.UI
{

	public class CheckGroup:GroupBase<CheckGroup,InputCheckbox>
	{
	
		public CheckGroup(Element parent):base("checkbox", parent)
		{
		}

		public CheckGroup(ElementBase parent):base("checkbox", parent.Element())
		{
		}

		public CheckGroup():base("checkbox")
		{

		}
	
	}

	
	[Serializable]
	public class GroupItem
	{
		public GroupItem(){}
		public string Text { get; set;}
		public string Value { get; set;}

	}
	
	public abstract class GroupBase<TField,TInput>:ElementBase<TField> where  TField:ElementBase
		where TInput:InputBase<TInput>, new ()
	{
		
		public Div Controls { get; protected set; }
		
		public Label ControlLabel { get; protected set; }

		public TInput Input { get; protected set; }
		
		string nm;
		bool il;
		string tp;
		
				
		public GroupBase (string type, Element parent=null, string text=null, string fieldName=null, IList<GroupItem> items=null, bool inline=true)
		{

			tp = type;
			nm = fieldName;
			il = inline;
			
			Init (parent);
			
			if (!string.IsNullOrEmpty (text))
				ControlLabel.Text (text);
			
			if (items != null) {
				
				foreach (var item in items) {
					AddItem(item);
				}
			}
		}

		void Init(Element parent)
		{
			CreateElement ("div", parent);
			Element ().ClassName = "control-group";
			
			ControlLabel = new Label ().ClassName ("control-label");
			Controls = new Div ().ClassName ("controls");
			
			base.Append (ControlLabel);
			base.Append (Controls);
			
		}

		public TField  Inline(bool inline)
		{
			il = inline;
			
			var l = Controls.JQuery ("label."+tp);
			if (il)
				l.AddClass ("inline");
			else
				l.RemoveClass ("inline");
			
			return this.As<TField>();
		}
		
		public TField  Name(string name)
		{
			nm = name;
			
			Controls.JQuery ("[type="+tp+"]").Attribute ("name", name);
			
			return this.As<TField>();
		}
		
		public string  Name()
		{
			return nm;
		}
		
		
		public new TField  Text(string text)
		{
			ControlLabel.Text (text);
			return this.As<TField>();
		}
		
		public new string  Text()
		{
			return ControlLabel.Text ();
		}
		
		
		public TField Add(GroupItem item)
		{
			AddItem (item);
			return this.As<TField>();
		}
		
		public new DivElement Element()
		{
			return base.Element ().As<DivElement>();
		}
		
		
		void AddItem(GroupItem item)
		{

			Input = new TInput ().Value(item.Value);

			new Label (Controls.Element ())
				.ClassName (tp+(il?" inline":""))
					.Text(item.Text)
					.For (Input.ID).Append (Input);
			if (!string.IsNullOrEmpty (nm))
				Input.Name (nm);

		
			/*
			new InputRadio (Controls.Element(), (lb,rd) => {
				lb.Text (item.Text);
				if (!il)
					lb.RemoveClass ("inline");
				if(!string.IsNullOrEmpty( nm)) rd.Name = nm;
				rd.SetValue (item.Value);
			});
			*/
		}
		
		
	}
	
}
