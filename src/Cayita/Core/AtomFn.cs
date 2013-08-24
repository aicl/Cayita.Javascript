using System;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;
using System.Collections.Generic;
using jQueryApi.UI.Widgets;

namespace Cayita
{

	[PreserveMemberCase]
	public static partial class UI
	{
		public static bool AutoId=false;
		public static string CTextTag="ctxt";
		public static string ControlGroupClassName="control-group";
		public static string ControlLabelClassName="control-label";
		public static string ControlsClassName="controls";
		public static string EmptyImgSrc = "http://www.placehold.it/200x150/EFEFEF/AAAAAA&text=no+image";
		
		static Dictionary<string,int> tags = new Dictionary<string,int>();

		public static Atom Atom (string tagName, string type=null, string className=null, string text=null, Action<Atom> action=null, Atom parent=null )
		{
			var e = Document.CreateElement (tagName).As<Atom>();

			if (AutoId)
				e.CreateId ();

			if (!type.IsNullOrEmpty ())
				e.SetToAtomProperty("type", type);

			if (!className.IsNullOrEmpty ())
				e.ClassName = className;

			if (!text.IsNullOrEmpty ())
				jQuery.FromElement (e).Append (BuildText(text));


			e.SetToAtomProperty ("isHidden", (Func<bool>)(() => !jQuery.FromElement (e).Is (":visible")));
			e.SetToAtomProperty("Hide", (Action<bool?>)( v=> {
				if(!v.HasValue || v.Value)
					jQuery.FromElement(e).Hide();
				else
					jQuery.FromElement(e).Show();
			}));

			e.SetToAtomProperty("append", (Action<Element>)((c)=> e.JQuery.Append(c.ParentNode??c)));
			e.SetToAtomProperty("toString", (Func<string>)( ()=> e.InnerHTML ));
			e.SetToAtomProperty("get_text", (Func<string>)( ()=> GetText(e) ));
			e.SetToAtomProperty("set_text", (Action<string>)( (v)=> SetText(e,v) ));
			e.SetToAtomProperty("createId", (Func<string>)( ()=> CreateId(e) ));
			e.SetToAtomProperty("set_setTextFn", (Action<Action<Element,string>>)( (v)=> SetTextFn(e,v) ));
			e.SetToAtomProperty("set_getTextFn", (Action<Func<Element,string>>)( (v)=> GetTextFn(e,v) ));
			e.SetToAtomProperty ("add_handler", (Action<string,jQueryEventHandler,string, object>)
			                ((name,ev,se,co) => On (e, name, ev, se, co)));

			e.SetToAtomProperty ("remove_handler", (Action<string,jQueryEventHandler,string>)
			                 ((name,ev,se) => Off (e, name, ev, se)));

			e.SetToAtomProperty ("add_clicked", (Action<jQueryEventHandler,string>)
			                 ((ev,se) => OnClick (e, ev, se)));

			e.SetToAtomProperty ("remove_clicked", (Action<jQueryEventHandler,string>)
			                 ((ev,se) => OffClick (e, ev, se)));


			if (action != null)
				action.Invoke (e);

			if (parent != null)
				parent.Append (e);

			return e; 
		}

		public static Anchor Anchor ( string className=null, string href="#", string text=null )
		{
			var e = Atom ("a", null, className,text);
			if (! href.IsNullOrEmpty ())
				e.SetToAtomProperty ("href", href);
			return e.As<Anchor> ();
		}

		public static Label Label ( string className=null, string text=null, Action<Label>action=null, Atom parent=null)
		{
			var e = Atom ("label", null, className,text, null).As<Label>();
			e.SetToAtomProperty("get_for", (Func<string>)( ()=>  (e.GetAttribute("for")??"").ToString() ));
			e.SetToAtomProperty("set_for", (Action<string>)( (v)=> e.SetAttribute("for",v) ));
			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);
			return e;
		}

		public static ControlGroup ControlGroup()
		{
			var e = new Div (ControlGroupClassName); 
			var label = new Label( ControlLabelClassName);
			var controls = new Div(ControlsClassName);
			jQuery.FromElement (e).Append (label).Append (controls);

			object cg = new {};
			DefineProperty (cg,"label", new {value=label, writable= false});
			DefineProperty (cg,"controls", new {value=controls, writable= false});
			e.DefineAtomProperty("cg",  new {value=cg, writable= false});

			e.SetToAtomProperty( "get_text", (Func<string>)( () => label.Text));
			e.SetToAtomProperty ( "set_text", (Action<string>)( (v) => label.Text=v));

			return e.As<ControlGroup> (); 
		}

		public static Input<T> Input<T> (string tagName, string type=null, string className=null, string name=null, string placeholder=null, Action<Atom> action=null, Atom parent=null  )
		{
			var e = Atom (tagName, type, className,null, null, null).As<Input<T>>();

			e.MinLengthMsgFn = i => "Min {0} chars".Fmt (i.MinLength);
			var minLength = 0;

			if(!name.IsNullOrEmpty()) e.Name=name;
			if(!placeholder.IsNullOrEmpty()) e.Placeholder=placeholder;

			e.SetToAtomProperty( "get_value", (Func<T>)( ()=> GetValue<T>(e) ));
			e.SetToAtomProperty( "set_value", (Action<T>)( (v)=> SetValue(e,v) ));
			e.SetToAtomProperty("set_setValueFn", (Action<Action<Element,T>>)( (v)=> SetValueFn(e,v) ));
			e.SetToAtomProperty("set_getValueFn", (Action<Func<Element,T>>)( (v)=> GetValueFn(e,v) ));

			e.SetToAtomProperty ("add_changed", (Action<jQueryEventHandler,string>)
			                 ((ev,se) => OnChange (e, ev, se)));

			e.SetToAtomProperty ("removed_changed", (Action<jQueryEventHandler,string>)
			                 ((ev,se) => OffChange (e, ev, se)));

			e.SetToAtomProperty("get_minLength",(Func<int>)(()=> minLength));
			e.SetToAtomProperty("set_minLength",(Action<int>)((v)=> {
				e.Pattern=".{{0},}".Fmt(v);
				minLength=v;
			}));


			e.SetToAtomProperty ("checkValidity", (Func<bool>)(() => {
				e.SetCustomValidity("");
				var r = e.Validity.Valid;

				if(!r && e.Validity.PatternMismatch && e.MinLength>0){
					e.SetCustomValidity(e.MinLengthMsgFn(e));
				}
				return r;
			}));

			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);

			return e;
		}

		public static Input<T> AutoNumeric<T> (NumericOptions options=null,string className=null, string name=null, string placeholder=null, Action<Input<T>> action=null,  Atom parent=null )
		{
			var e = Input<T> ("input", "text", className, name, placeholder);
			Plugins.AutoNumeric(e, options);
			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);
			return e;
		}


		public static Input<decimal?> NullableNumericInput (NumericOptions options=null, string className=null, string name=null, string placeholder=null,
		                                                    Action<Input<decimal?>> action=null,  Atom parent=null )
		{
			options = options ?? new NumericOptions { LeadingZero="deny" };
			var e = AutoNumeric<decimal?>(options, className,name, placeholder,action, parent);
			return e;
		}

		public static Input<decimal> NumericInput (NumericOptions options=null,string className=null, string name=null, string placeholder=null,
		                                           Action<Input<decimal>> action=null,  Atom parent=null )
		{
			options = options ?? new NumericOptions { Empty="zero", LeadingZero="deny" };
			var e = AutoNumeric<decimal>(options, className, name, placeholder, action, parent);
			return e;
		}

		public static Input<int> IntInput (NumericOptions options=null,string className=null, string name=null, string placeholder=null, 
		                                   Action<Input<int>> action=null,  Atom parent=null )
		{
			options = options ?? new NumericOptions { Empty="zero", LeadingZero="deny", DecimalPlaces=0 };
			var e = AutoNumeric<int>(options, className, name, placeholder, action, parent);
			return e;
		}

		public static Input<int?> NullableIntInput (NumericOptions options=null,string className=null, string name=null, string placeholder=null,
		                                            Action<Input<int?>> action=null,  Atom parent=null )
		{
			options = options ?? new NumericOptions {  LeadingZero="deny", DecimalPlaces=0 };
			var e = AutoNumeric<int?>(options, className, name, placeholder, action, parent);
			return e;
		}


		public static CheckInput<T> CheckInput<T>(string className=null, string name=null, string text=null,
		                                          Action<CheckInput<T>> action=null, Atom parent=null)
		{
			var e = Input<T> ("input", "checkbox", className, name).As<CheckInput<T>> ();
			var l = Label ("checkbox");
			jQuery.FromElement (l).Append (e);
			l.Text = text?? "";

			e.SetToAtomProperty("get_text", (Func<string>)( ()=> l.Text ));
			e.SetToAtomProperty("set_text", (Action<string>)( (v)=> l.Text=v ));

			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);

			return e;
		}

		public static CheckInput<bool> BooleanCheck(string className, string name, string text,
		                                            Action<CheckInput<bool>> action=null, Atom parent=null)
		{
			var e = CheckInput<bool> (className, name, text);
			e.Value = true;
			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);
			return e;
		}

		public static RadioInput<T> RadioInput<T>(string className="", string name=null, string text=null,
		                                          Action<RadioInput<T>> action=null, Atom parent=null)
		{
			var e = Input<T> ("input", "radio", className,name).As<RadioInput<T>> ();
			var l = Label ("radio");
			jQuery.FromElement (l).Append (e);
			l.Text = text?? "";

			e.SetToAtomProperty("get_text", (Func<string>)( ()=> l.Text ));
			e.SetToAtomProperty("set_text", (Action<string>)( (v)=> l.Text=v ));

			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);

			return e;
		}


		public static RadioInput<bool> BooleanRadioInput(string className="", string name=null, string text=null,
		                                                 Action<RadioInput<bool>> action=null, Atom parent=null)
		{
			var e = RadioInput<bool> (className, name, text);
			e.Value = true;

			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);
			return e;
		}


		public static FileInput FileInput(string className=null, string name=null, string placeholder=null){
			return Input<string> ("input", "file", className, name, placeholder).As<FileInput> ();
		}


		public static DateInput DateInput(DatePickerOptions options=null, string className=null, string name=null, string placeholder=null,
		                                  Action<DateInput> action=null, Atom parent=null)
		{
			return BuildDateInput<DateInput>(options, className, name, placeholder,action, parent);
		}

		public static NullableDateInput NullableDateInput(DatePickerOptions options=null, string className=null, string name=null, string placeholder=null,
		                                                  Action<NullableDateInput> action=null, Atom parent=null)
		{
			return BuildDateInput<NullableDateInput>(options, className, name, placeholder,action, parent);
		}


		public static HtmlList HtmlList(string className=null)
		{
			return UI.Atom ("ul", null, className).As<HtmlList> ();
		}



		static T BuildDateInput<T>(DatePickerOptions options=null, string className=null, string name=null, string placeholder=null,
		                           Action<T> action=null, Atom parent=null)
			where T: Atom
		{
			var e = Input<DateTime> ("input", "text", className, name, placeholder).As<T>();
			e.DefineAtomProperty ("picker", new {value=jQuery.FromElement (e).DatePicker (options), writable=false });
			e.SetAttribute ("datepicker", true);

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}


		internal static string BuildText(string text)
		{
			return "<ctxt>{0}</ctxt>".Fmt (text);
		}

		static void SetTextFn(Element el, Action<Element,string > func)
		{
			el.SetToAtomProperty( "get_text", (Action<string>)( (v)=> func(el,v) ));
		}


		static void GetTextFn(Element el, Func<Element,string> func)
		{
			el.SetToAtomProperty( "set_text", (Func<string>)( ()=> func(el) ));
		}


		internal static void SetValueFn<T>(Element el, Action<Element,T> func)
		{
			el.SetToAtomProperty( "set_value", (Action<T>)( (v)=> func(el,v) ));
		}


		internal static void GetValueFn<T>(Element el, Func<Element,T> func)
		{
			el.SetToAtomProperty( "get_value", (Func<T>)( ()=> func(el) ));
		}


		static string CreateId(this Element e)
		{
			var id=0;
			tags.TryGetValue(e.TagName, out id);
			tags[e.TagName]=++id;
			e.ID= "{0}-{1}".Fmt(e.TagName.ToLower(),id);
			return e.ID;
		}


		static void SetText( Element atom , string value)
		{
			var v = value ?? "";
			var ctxt = jQuery.Select (UI.CTextTag, atom);
			if (ctxt.Length == 0) {
				jQuery.FromElement (atom).Append (BuildText(v));
			}
			else
				ctxt.Html (v);
		}

		static string GetText( Element atom)
		{
			var ctxt=jQuery.Select (CTextTag, atom);
			return ctxt.Length == 0 ? "": ctxt.GetHtml();
		}


		internal static void SetValue( Element atom, object value)
		{
			var type = atom.GetFromAtomProperty ("type").ToString();

			if(type=="radio" || type=="checkbox" || type=="select-one" || type=="select-multiple"
			   || type=="option")
			{
				atom.SetToAtomProperty ("Object", value);
				atom.SetToAtomProperty ("value", value??"");
			}
			else if (atom.HasAttribute ("autonumeric")) {
				jQuery.FromElement (atom).Execute ("autoNumeric", "set", value);
			} else if (atom.HasAttribute ("datepicker")) {
				jQuery.FromElement (atom).Execute ("datepicker", "setDate", value);
			} else {
				atom.SetToAtomProperty ( "value", value??"");
			}

		}

		internal static T GetValue<T>( Element atom)
		{
			object r;
			var type = atom.GetFromAtomProperty ("type").ToString();

			if ( type == "select-one" || type == "select-multiple") {
				var index = atom.As<SelectElement> ().SelectedIndex;
				r = index < 0 
					? null 
						: atom.As<SelectElement> ().Options [index].GetFromAtomProperty ("Object");
			}
			else if (atom.HasAttribute ("autonumeric")) {
				r=jQuery.FromElement (atom).Execute<string>("autoNumeric", "get").ParseNullableNumber();
			} else if (atom.HasAttribute ("datepicker")) {
				r=jQuery.FromElement (atom).Execute ("datepicker", "getDate");
			} else {
				r = atom.GetFromAtomProperty ("Object") ?? atom.GetFromAtomProperty ("value");
			}
			return Cast<T> (r);

		}

		internal static void On(Element atom, string eventName,jQueryEventHandler eventHandler,string selector="", object context=null)
		{
			var data = new JsDictionary<string, object>();
			data ["context"] = context;
			jQuery.FromElement (atom).On (eventName, selector, data, eventHandler);
		}


		internal static void Off(Element atom, string eventName,jQueryEventHandler eventHandler,string selector="")
		{
			jQuery.FromElement (atom).Off (eventName, selector, eventHandler);
		}

		static void OnClick(Element atom, jQueryEventHandler eventHandler,string selector="" )
		{
			jQuery.FromElement (atom).On ("click",selector, eventHandler);
		}

		static void OffClick(Element atom, jQueryEventHandler eventHandler,string selector="" )
		{
			jQuery.FromElement (atom).Off ("click",selector, eventHandler);
		}

		internal static void OnChange(Element atom, jQueryEventHandler eventHandler,string selector="" )
		{
			jQuery.FromElement (atom).On ("change",selector, eventHandler);
		}

		internal static void OffChange(Element atom, jQueryEventHandler eventHandler,string selector="" )
		{
			jQuery.FromElement (atom).Off ("change",selector, eventHandler);
		}
		

		[ScriptSkip]
		public static T Cast<T>(object o )
		{
			return (T)o;
		}

		[InlineCode("{o}.{@property}={value}")]
		internal static void SetToAtomProperty( this Element o, string property, object value)
		{
			((dynamic)o) [property] = value; // see inlinecode
		}

		[InlineCode("{o}.{@property}")]
		internal static object GetFromAtomProperty(this Element o, string property)
		{
			return ((dynamic)o) [property]; //see inlinecode
		}


		[InlineCode("Object.defineProperty({o},{name},{descriptor})")]
		internal static void DefineAtomProperty(this Element o, string name, dynamic descriptor)
		{
		}

		[InlineCode("Object.defineProperty({o},{name},{descriptor})")]
		internal static void DefineProperty( object o, string name, dynamic descriptor) 
		{
		}

		[InlineCode("{o}.{@property}={value}")]
		public static void SetToProperty( object o, string property, object value)
		{
			((dynamic)o) [property] = value; // see inlinecode
		}

		[InlineCode("{o}.{@property}")]
		public static object GetFromProperty(object o, string property)
		{
			return ((dynamic)o) [property]; //see inlinecode
		}

		[InlineCode("Array.isArray({o})")]
		internal static bool IsArray(this object o)
		{
			return false;
		}


		[InlineCode("Alertify.log.info({message}.outerHTML,{delay})")]
		public static void LogInfo(this Element message, int delay=5000)
		{	
		}

		[InlineCode("Alertify.log.info({message}.outerHTML,{delay})")]
		public static void LogSuccess(this Element message, int delay=5000)
		{	
		}

		[InlineCode("Alertify.log.error({message}.outerHTML,{delay})")]
		public static void LogError(this Element message, int delay=0)
		{

		}


		public static Div CreateDiv(Atom parent, Action<Div> action=null, string className=null){

			var d= new Div (className);
			if (action != null)
				action (d);

			if (parent != null)
				parent.Append (d);
			return d;
		}



		public static Div CreateContainerFluid(Atom parent,Action<Div> action=null)
		{
			return CreateDiv (parent, action, "container-fluid"); 
		}

		public static Div CreateContainerFluid(Action<Div> action=null)
		{
			return CreateDiv (null,action, "container-fluid"); 
		}

		public static Div CreateContainer(Atom parent,Action<Div> action=null)
		{
			return CreateDiv (parent, action, "container"); 
		}

		public static Div CreateContainer(Action<Div> action=null)
		{
			return CreateDiv (null,action, "container"); 
		}


		public static Div CreateRowFluid(Atom parent, Action<Div> action=null)
		{
			return CreateDiv (parent, action, "row-fluid"); 
		}

		public static Div CreateRowFluid(Action<Div> action=null)
		{
			return CreateDiv (null,action, "row-fluid"); 
		}

		public static Div CreateRow(Atom parent=null, Action<Div> action=null)
		{
			return CreateDiv (parent, action, "row"); 
		}

		public static Div CreateRow(Action<Div> action=null)
		{
			return CreateDiv (null, action, "row"); 
		}


	}

	
}
//var r = Fn.Call<bool>("HTMLInputElement.prototype.checkValidity", e);