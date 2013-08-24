using System;
using jQueryApi;
using System.Collections.Generic;
using System.Linq;
using System.Html;

namespace Cayita
{

	public static partial class UI
	{
		public static string OptionSelector = "label[option=true]";

		static GroupOption<T> GroupOption<T>(CheckInput<T> input, T value, string text, bool selected )
		{
			input.Value = value;
			input.Checked = selected;
			input.Text=text ?? Cast<string> (value);

			var l = input.ParentNode.As<Label> ();
			l.SetAttribute ("option", true);

			object go = new {};
			DefineProperty (go,"input", new {value=Cast<object>(input), writable= false});

			l.DefineAtomProperty ("go", new {value=go, writable= false});

			return Cast<GroupOption<T>>(l);
		}


		public static GroupOption<T> CheckOption<T>(T value, string text, bool selected){

			var input = CheckInput<T> ();
			var e = GroupOption<T> (input,value, text, selected);
			e.ClassName = "checkbox";
			return e;
		}

		public static GroupOption<T> RadioOption<T>(T value, string text, bool selected){

			var input = RadioInput<T> ();
			var e = GroupOption<T> (input,value, text, selected);
			e.ClassName = "radio";
			return e;
		}

		public static GroupBase<T> CheckGroup<T>(Action<GroupBase<T>> action=null, Atom parent=null)
		{
			var e= InputGroup<T> ();
			var cg = e.MainObject;
			SetToProperty(cg,"addValue", (Action<T,string,bool>)(
				(value,text,selected)=> AddOption<T>(e, CheckOption(value, text,selected)) 
				));

			SetToProperty(cg,"loadList",(Action<IList<T>>)(
				(l)=> LoadList<T>(e,l, (Func<T,GroupOption<T>>)((d)=> CheckOption(d,null,false)   ) )
				));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}

		public static GroupBase<T> RadioGroup<T>(Action<GroupBase<T>> action=null, Atom parent=null)
		{
			var e= InputGroup<T> ();
			var cg = e.MainObject;
			SetToProperty (cg, "addValue", (Action<T,string,bool>)(
				(value,text,selected) => AddOption<T> (e, RadioOption (value, text, selected))));

			SetToProperty(cg,"loadList",(Action<IList<T>>)(
				(l)=> LoadList<T>(e,l, (Func<T,GroupOption<T>>)((d)=> RadioOption(d,null,false)   ) )
				));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}


		public static GroupBase<T> InputGroup<T>()
		{
			var e = ControlGroup ().As<GroupBase<T>> ();
			var cg = e.MainObject; 

			SetToProperty (cg, "inline", (Action<bool>)(v => SetInlineValue (e, v)));
			SetToProperty (cg, "isInline", (Func<bool>)(() => GetInlineValue (e)));

			SetToProperty (cg, "required", (Action<bool?>)(v => {
				if (!v.HasValue || v.Value) {
					jQuery.FromElement (e).Attribute("required","required");
					jQuery.Select("input", e.Controls).Each((i,el)=>{
						el.As<Input>().Required=true;
					});
				}
				else{
					jQuery.FromElement (e).RemoveAttr("required");
					jQuery.Select("input", e.Controls).Each((i,el)=>{
						el.As<Input>().Required=false;
					});
				}
			}));
			SetToProperty (cg, "isRequired", (Func<bool>)(() => ! jQuery.FromElement (e).GetAttribute ("required").IsNullOrEmpty () ));

			SetToProperty (cg, "set_name", (Action<string>)(v => SetName (e, v)));
			SetToProperty (cg, "get_name", (Func<string>)(() => GetName (e)));

			SetToProperty (cg, "addOption", (Action<GroupOption<T>>)(o => AddOption (e,  o)));

			SetToProperty (cg, "removeOption", (Action<GroupOption<T>>)(v => RemoveValue<T> (e, v.Value)));
			SetToProperty (cg, "removeValue", (Action<T>)(v => RemoveValue<T> (e, v)));
			SetToProperty (cg, "removeAll", (Action)(() => RemoveAll (e)));

			SetToProperty (cg, "getChecked", (Func<GroupOption<T>[]>)(() => GetChecked<T> (e)));
			SetToProperty (cg, "getOptions", (Func<GroupOption<T>[]>)(() => GetOptions<T> (e)));

			SetToProperty (cg, "checkOption", (Action<GroupOption<T>,bool>)((v,c) => CheckValue (e, v.Value, c)));
			SetToProperty (cg, "checkValue", (Action<T,bool>)((v,c) => CheckValue (e, v, c)));
			SetToProperty (cg, "checkAll", (Action<bool>)((c) => CheckAll (e, c)));

			SetToProperty (cg, "disableOption", (Action<GroupOption<T>,bool>)((v,d) => DisableValue (e, v.Value, d)));
			SetToProperty (cg, "disableValue", (Action<T,bool>)((v,d) => DisableValue (e, v, d)));
			SetToProperty (cg, "disableAll", (Action<bool>)((d) => DisableAll (e,  d)));

			SetToProperty (cg,"add_checked", (Action<jQueryEventHandler>)
			                      ((ev) => On(e.Controls, "check", ev, OptionSelector)));

			SetToProperty (cg,"remove_checked", (Action<jQueryEventHandler>)
			                      ((ev) => Off (e,"check", ev, OptionSelector)));

			jQuery.FromElement(e.Controls).On ("change", "input", ev =>{ 
				jQuery.FromElement(ev.Target.ParentNode).Trigger("check");
			});
			e.Inline = true;

			return e;
		}



		static bool GetInlineValue(ControlGroup parent)
		{
			return ! jQuery.FromElement (parent).GetAttribute ("inline").IsNullOrEmpty ();
		}

		static void SetInlineValue(ControlGroup parent, bool value)
		{
			if (value){
				jQuery.FromElement (parent).Attribute("inline","true");
				jQuery.Select("label[option=true]", parent.Controls).AddClass ("inline");
			}
			else{
				jQuery.FromElement (parent).RemoveAttr ("inline");
				jQuery.Select("label[option=true]", parent.Controls).RemoveClass ("inline");
			}
		}

		static string GetName(ControlGroup parent)
		{
			return jQuery.FromElement (parent.Controls).GetAttribute ("groupname")??"";
		}

		static void SetName (ControlGroup parent, string value)
		{
			jQuery.FromElement(parent.Controls).Attribute ("groupname", value);
			jQuery.Select("input",parent.Controls).Attribute ("name", value);
		}

		static void AddOption<T>(ControlGroup parent,  GroupOption<T> item)
		{

			var name = GetName (parent);
			if (!name.IsNullOrEmpty ())
				item.Input.Name = name;

			if(GetInlineValue(parent))
				jQuery.FromElement (item).AddClass ("inline");

			if (! item.Input.ID.IsNullOrEmpty ())
				item.For = item.Input.ID;

			if (! jQuery.FromElement (parent).GetAttribute ("required").IsNullOrEmpty ())
				item.Input.Required = true;

			jQuery.FromElement(parent.Controls).Append (item);

		}

		static GroupOption<T>[] GetOptions<T>(ControlGroup parent)
		{
			return
				Cast<GroupOption<T>[]>(
					jQuery.Select (OptionSelector, parent.Controls).GetElements ());

		}

		static GroupOption<T>[] GetChecked<T>(ControlGroup parent)
		{
			var l = GetOptions<T> (parent);
			return  l.Where (x=>x.Checked).ToArray ();
		}

		static void RemoveValue<T>( ControlGroup parent, T value)
		{
			var l =Cast<List<GroupOption<T>>> (GetOptions<T>(parent));
			var item = l.FirstOrDefault (x=> Object.Equals(x .Value,value));
			if (item != null) {
				jQuery.FromElement(item).Remove ();
				l.Remove (item);
			}
		}

		static void RemoveAll(ControlGroup parent)
		{
			jQuery.FromElement (parent.Controls).Empty ();
		}

		static void DisableValue<T>( ControlGroup parent, T value, bool disable)
		{
			var e = jQuery.Select ("input[value={0}]".Fmt(value), parent.Controls).GetElement (0);
			if (e != null)
				e.Disabled = disable;
		}

		static void DisableAll(ControlGroup parent, bool disable)
		{
			jQuery.Select ("input", parent.Controls).Each ((index,element)=> element.Disabled=disable);
		}

		static void CheckValue<T>( ControlGroup parent, T value, bool chck)
		{
			var e = jQuery.Select ("input[value={0}]".Fmt(value), parent.Controls).GetElement (0);
			if (e != null)
				e.As<CheckBoxElement> ().Checked=chck;
		}

		static void CheckAll(ControlGroup parent, bool check)
		{
			jQuery.Select ("input", parent.Controls).Each ((index,element)=> element.As<CheckBoxElement>().Checked=check);
		}


		static void LoadData<T,TData>(ControlGroup el,IList<TData> data, Func<TData,GroupOption<T>> optionFn, bool append=false){

			if (!append)
				RemoveAll (el);

			foreach (var d in data) {
				AddOption (el, optionFn (d));
			}

		}

		static void LoadList<T>(ControlGroup el, IList<T> data, Func<T,GroupOption<T>> factory, bool append =false){
			if (!append)
				RemoveAll (el);

			foreach (var d in data) {
				GroupOption<T> option = factory(d);
				AddOption (el, option);
			}

		}

	}
}
