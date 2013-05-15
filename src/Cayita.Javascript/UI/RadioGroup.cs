using System;
using System.Html;
using System.Collections.Generic;

namespace Cayita.UI
{

	[Serializable]
	public class RadioItem
	{
		public RadioItem(){}
		public string Text { get; set;}
		public string Value { get; set;}
	}
	
	public class RadioGroup:ElementBase<RadioGroup>
	{

		public Div Controls { get; protected set; }

		public Label ControlLabel { get; protected set; }

		string nm;
		bool il;

		void Init(Element parent)
		{
			CreateElement ("div", parent);
			Element ().ClassName = "control-group";

			ControlLabel = new Label ().ClassName ("control-label");
			Controls = new Div ().ClassName ("controls");

			base.Append (ControlLabel);
			base.Append (Controls);

		}

		public RadioGroup (Element parent=null, string text=null, string fieldName=null, IList<RadioItem> items=null, bool inline=true)
		{

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

		public RadioGroup  Inline(bool inline)
		{
			il = inline;

			var l = Controls.JQuery ("label.radio");
			if (inline)
				l.AddClass ("inline");
			else
				l.RemoveClass ("inline");

			return this;
		}

		public RadioGroup  Name(string name)
		{
			nm = name;

			Controls.JQuery ("[type=radio]").Attribute ("name", name);

			return this;
		}

		public string  Name()
		{
			return nm;
		}


		public new RadioGroup  Text(string text)
		{
			ControlLabel.Text (text);
			return this;
		}
		
		public new string  Text()
		{
			return ControlLabel.Text ();
		}


		public RadioGroup Add(RadioItem item)
		{
			AddItem (item);
			return this;
		}

		public new DivElement Element()
		{
			return base.Element ().As<DivElement>();
		}


		void AddItem(RadioItem item)
		{
			new InputRadio (Controls.Element(), (lb,rd) => {
				lb.Text (item.Text);
				if (!il)
					lb.RemoveClass ("inline");
				if(!string.IsNullOrEmpty( nm)) rd.Name = nm;
				rd.SetValue (item.Value);
			});
		}


	}
	
}

/*
<div id="c-div-69" class="control-group">
	<label id="c-label-25" class="control-label" style="width: 80px;"><ctxt>Level</ctxt></label>
	<div id="c-div-70" class="controls">
		<label id="c-label-26" class="radio inline" for="c-input-29">
			<ctxt>A</ctxt>
			<input id="c-input-29" type="radio" name="Level" value="A" checked="checked">
		</label>
		<label id="c-label-27" class="radio inline" for="c-input-31">
			<ctxt>B</ctxt>
			<input id="c-input-31" type="radio" name="Level" value="B">
		</label>
		<label id="c-label-28" class="radio inline" for="c-input-33">
			<ctxt>C</ctxt>
			<input id="c-input-33" type="radio" name="Level" value="C">
		</label>
	</div>
</div>
*/
