using System;
using System.Collections;
using jQueryApi;
using System.Collections.Generic;


namespace Cayita{

	public enum FormUpdatedAction{
		Clear,
		Populate
	}
}

namespace Cayita
{
	public static partial class UI
	{
		public static Form Form (Atom parent=null, Action<Atom> action=null )
		{


			var e = Atom ("form", null, null, null, action, parent).As<Form>();
			e._updated = (Action<Form, FormUpdatedAction>)( (f,a) => {});

			e._validate = (Func<Input,bool>)((i)=>{

				if(i.ErrorMessage==null && !i.Validity.Valid){
					i.ErrorMessage= i.Popover( new PopoverOptions{Trigger="manual", Content="OK"});
					i.ErrorMessage.Show();
				}

				if(i.CheckValidity()){
					if(i.ErrorMessage!=null){
						i.ErrorMessage.Destroy();
						i.ErrorMessage=null;
					}
					return true;
				}
				else{
					jQuery.Select(".popover-content", i.NextSibling).First().Html(i.ValidationMessage);
					return false;
				}
			});

			e._clear = (Action<Form>)(f=>{
				f.Reset();
				var inputs = f.Inputs;

				foreach(var i in inputs)
				{
					if(i.ErrorMessage!=null) {
						i.ErrorMessage.Destroy();
						i.ErrorMessage=null;
					}
				}
			});

			e.SetAttribute ("novalidate", "novalidate");

			e.SetToAtomProperty("clear", (Action)(()=>{
				e._clear(e);
				e.JQuery.Data("_source_", e.JQuery.Serialize());
				e._updated(e, FormUpdatedAction.Clear);
			}));

			e.SetToAtomProperty("populateFrom", (Action<JsDictionary>)( d=>{
				e._clear(e);
				foreach(var p in d)
				{
					var o = jQuery.Select ("[name='{0}']".Fmt(p.Key), e);
					o.Each ((index, element)=>{

						var atom = element.As<Input<object>>();
						var value = p.Value;

						var type = atom.GetFromAtomProperty ("type").ToString();

						if (type == "radio") {
							if (Object.Equals (value,  atom.Value))
								atom.SetToAtomProperty("checked",true);
						} else if (type == "checkbox") {
							if (!value.IsArray ()) {
								if (Object.Equals (value, true))
									atom.SetToAtomProperty( "checked", true);
							} else {
								var a = Cast<List<object>> (value);
								if (a.IndexOf (atom.Value) > 0)
									atom.SetToAtomProperty( "checked", true);
							}
						} else if (type == "select-multiple" && value.IsArray ()) {

							var a = Cast<List<object>> (value);
							foreach (var item in a) {
								var q = jQuery.Select ("option[value={0}]".Fmt (item), atom);
								if (q.Length > 0) {
									SetToProperty(q.GetElement(0), "selected", true);
								}
							}
						} else if (atom.HasAttribute ("autonumeric")) {
							jQuery.FromElement (atom).Execute ("autoNumeric", "set", value);
						} else if (atom.HasAttribute ("datepicker")) {
							jQuery.FromElement (atom).Execute ("datepicker", "setDate", value);
						} else {
							atom.SetToAtomProperty ( "value", value??"");
						}
					});
				}
				e.JQuery.Data("_source_", e.JQuery.Serialize());
				e._updated(e,FormUpdatedAction.Populate);
			}));


			e.SetToAtomProperty ("populate", (Action<JsDictionary>)(d => {

				foreach(var p in d)
				{
					var o = jQuery.Select ("[name='{0}']".Fmt(p.Key), e);

					if (o.Length == 0)
						continue;

					var r = new List<object> ();

					o.Each ((index,element)=>{
						var input = element.As<Input<object>>();
						var type =input.Type;
						if(type=="radio"){
							if (Object.Equals( input.GetFromAtomProperty("checked"),true)) r.Add( input.Value);
						} else  if(type=="checkbox"){
							if (Object.Equals( input.Value,true)){
								r.Add((Object.Equals( input.GetFromAtomProperty("checked"),true)) );
							}
							else if (Object.Equals( input.GetFromAtomProperty("checked"),true))
								r.Add(input.Value);
						} else if(type=="select-one" || type=="select-multiple"){
							var q = jQuery.Select ("option:selected", element );
							q.Each((i,el)=>	r.Add(el.As<OptionAtom<object>>().Value) );
						} else {
							r.Add( input.Value);
						}

					});

					if (!p.Value.IsArray ()) {
						if (r.Count>0 )d[p.Key] = r [0];
					} else {
						d[p.Key] = r ;
					}
				}

			}));

			e.SetToAtomProperty ("get_inputs", (Func<Input[]>)(
				() => Cast<Input[]> (jQuery.Select("input,select,textarea",e).GetElements())));

			e.SetToAtomProperty ("checkValidity", (Func<bool>)(() => {
				var inputs = e.Inputs;
				foreach(var i in inputs){
					if(!i.CheckValidity()) return false;
				}
				return true;
			}));

			e.SetToAtomProperty("hasChanges",(Func<bool>)(()=>e.JQuery.Serialize()!=e.JQuery.GetDataValue("_source_").ToString()));

			e.SetToAtomProperty ("add_changed", (Action<jQueryEventHandler>)
			                     (hdl => jQuery.FromElement (e).On ("change", hdl) ));

			e.SetToAtomProperty ("remove_changed", (Action<jQueryEventHandler>)
			                     (hdl => jQuery.FromElement (e).Off ("change", "", hdl)));


			e.SetToAtomProperty ("add_updated", (Action<Action<Form,FormUpdatedAction>>)
			                     (v => e._updated=  Cast<Action<Form,FormUpdatedAction>>(Delegate.Combine (e._updated, v)) ));

			e.SetToAtomProperty ("remove_updated", (Action<Action<Form,FormUpdatedAction>>)
			                     (v => e._updated=  Cast<Action<Form,FormUpdatedAction>>(Delegate.Remove (e._updated, v)) ));


			jQuery.FromElement (e).On ("keyup", "input[type!=radio]input[type!=checkbox],select,textarea", ev => {
				e._validate( ev.CurrentTarget.As<Input>());
			});

			jQuery.FromElement (e).On ("change", "input[type=radio],input[type=checkbox]", ev => {

				var type = ev.CurrentTarget.As<Atom>().GetFromAtomProperty ("type").ToString();

				e._validate(
					jQuery.Select("input[type={0}][name={1}]".Fmt(type,ev.CurrentTarget.As<Input>().Name),e).Last().GetElement(0).As<Input>());

			});

			jQuery.FromElement (e).On ("change", "select", ev => {
				e._validate( ev.CurrentTarget.As<Input>());
			});


			jQuery.FromElement (e).On ("submit", ev => {
				ev.PreventDefault();
				var inputs = e.Inputs;
				var v = true;
				foreach(var i in inputs)
				{
					var type = i.GetFromAtomProperty ("type").ToString();
					if(type=="radio" || type=="checkbox")
					{
						v=e._validate(
						jQuery.Select("input[type={0}][name={1}]".Fmt(type,i.Name),e).Last().GetElement(0).As<Input>())
							&& v;
					}
					else
						v= e._validate(i) && v;
				}

				if(v && e.SubmitHandler!=null) e.SubmitHandler(e);
			});

			return e;
		}
	}
}

