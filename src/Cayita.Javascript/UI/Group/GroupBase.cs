using System;
using System.Html;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita.UI
{

	
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

			Controls.JQuery( ).On("change", "[type="+tp+"]", evt=> {
				var i = evt.Target.As<InputElement>();
				var item = new GroupItem{Value=i.Value, Text= i.ParentNode.Text()};
				var checkd =  i.Get<bool>("checked");
				OnChanged(item, checkd, evt);
			});

		}

		public event Action<TField,GroupItem,bool,jQueryEvent> Changed=(f,i,ch,evt)=>{};

		protected virtual void OnChanged (GroupItem item, bool checkd,  jQueryEvent evt)
		{
			Changed (As<TField> (), item, checkd, evt);
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

			var input = new TInput ().Value(item.Value);

			new Label (Controls.Element ())
				.ClassName (tp+(il?" inline":""))
					.Text(item.Text)
					.For (input.ID).Append (input);
			if (!string.IsNullOrEmpty (nm))
				input.Name (nm);

		}
		
	}
	
}
