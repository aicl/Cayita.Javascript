using System.Html;
using System;
using jQueryApi;
using System.Collections.Generic;

namespace Cayita
{
	public static partial class UI
	{
		public static OptionAtom<T> OptionAtom<T>(string className="")
		{
			var e = Atom ("option","option", className);
			e.SetToAtomProperty( "get_value", (Func<T>)( ()=> GetValue<T>(e) ));
			e.SetToAtomProperty( "set_value", (Action<T>)( (v)=> SetValue(e,v) ));
			e.SetToAtomProperty("set_setValueFn", (Action<Action<Element,T>>)( (v)=> SetValueFn(e,v) ));
			e.SetToAtomProperty("set_getValueFn", (Action<Func<Element,T>>)( (v)=> GetValueFn(e,v) ));

			return e.As<OptionAtom<T>> ();
		}

		public static SelectInput<T> SelectInput<T>(string type="select-one",string className="")
		{
			var e = Input<T> ("select", type, className).As<SelectInput<T>>();

			e.SetToAtomProperty("addOption",(Action<Action<OptionAtom<T>>>)( (a)=> AddOption<T>(e,a) ));
			e.SetToAtomProperty ("addValue", (Action<T,string, bool>)( (data,text,selected)=> AddValue(e,data,text,selected) ));

			e.SetToAtomProperty ("get_selectedOption", (Func<OptionAtom<T>>)(() => GetSelectedOption<T> (e)));
			e.SetToAtomProperty ("get_selected", (Func<List<OptionAtom<T>>>)(() => GetSelected<T> (e)));

			e.SetToAtomProperty ("loadData",
			                 (Action<IList<object>,Func<object,OptionAtom<T>>,bool>)
			                 ((data,optionFn,append) => LoadData (e, data, optionFn, append)));
			e.SetToAtomProperty("LoadList", (Action<IList<T>, bool>)( (data, append)=> LoadList(e,data,append) ));

			e.SetToAtomProperty ("removeValue", (Action<T>)( (value)=> RemoveValue(e,value) ));
			e.SetToAtomProperty ("removeOption", (Action<OptionAtom<T>>)( (value)=> RemoveOption(e,value) ));
			e.SetToAtomProperty("removeAll", (Action)(()=> RemoveAll(e)));

			e.SetToAtomProperty ("selectValue",(Action<T,bool>)( (value,selected)=>SelectValue(e,value, selected) ));
			e.SetToAtomProperty ("selectOption",(Action<OptionAtom<T>,bool>)( (value,selected)=>SelectValue(e,value.Value, selected) ));
			e.SetToAtomProperty ("selectAll", (Action<bool>)((selected) => SelectAll (e,selected)));

			return e;
		}

		static void RemoveValue<T>(SelectInput<T> parent, T value){
			jQuery.Select ("option[value={0}]".Fmt (value), parent ).Remove ();
		}


		static void RemoveOption<T>(SelectInput<T> parent, OptionAtom<T> option){
			jQuery.Select ("option[value={0}]".Fmt (option.Value), parent ).Remove ();
		}


		static void AddValue<T>(SelectInput<T> parent, T value, string text, bool selected){
			AddOption<T>(parent, o=>{
				o.Value=value; o.Text= text?? Cast<string>(value); o.Selected=selected;
			});
		}

		static void AddOption<T>(SelectInput<T> parent, Action<OptionAtom<T>> config)
		{
			var option = new OptionAtom<T> ();
			config (option);
			parent.Add (option);
		}

		static OptionAtom<T> GetSelectedOption<T>(SelectInput<T> parent){
			if(parent.SelectedIndex<0) 
				return default( OptionAtom<T> );
			return parent.Options [parent.SelectedIndex].As<OptionAtom<T>> ();

		}

		static  void RemoveAll<T>(SelectInput<T> el)
		{
			jQuery.FromElement ( el ).Empty ();
		}

		static List<OptionAtom<T>> GetSelected<T>(SelectInput<T> el)
		{
			var s = new List<OptionAtom<T>> ();
			var q = jQuery.Select ("option:selected", el );
			q.Each ((index, element) =>  s.Add( element.As<OptionAtom<T>>() ));
			return s;
		}

		static void LoadData<T,TData>(SelectInput<T> el,IList<TData> data, Func<TData,OptionAtom<T>> optionFn, bool append=false){

			if (!append)
				RemoveAll (el);

			foreach (var d in data) {
				el.Add (optionFn (d));
			}

		}

		static void LoadList<T>(SelectInput<T> el, IList<T> data, bool append =false){
			if (!append)
				RemoveAll (el);

			foreach (var d in data) {
				el.Add (o=> {o.Value= d; o.Text= Cast<string>(d); });
			}

		}


		static void SelectValue<T>(SelectInput<T> el, T value, bool selected)
		{
			var o = jQuery.Select ("option[value={0}]".Fmt (value), el).GetElement (0);
			if (o != null)
				o.As<OptionElement> ().Selected = selected;
		}

		static void SelectAll<T> (SelectInput<T> el, bool selected)
		{
			jQuery.Select ("option", el).Each((i,e)=>e.As<OptionElement>().Selected=selected);
		}
	}
}

