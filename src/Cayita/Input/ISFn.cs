/*
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;

namespace Cayita
{
	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class ISFn
	{

		public static SelectOption GetSelectedOption(InputSelect input)
		{
			var q = jQuery.Select ( "option:selected", input.El ).Last();

			SelectOption r = null;
			if (q.Length > 0) {
				r = new SelectOption( q.GetElement(0).As<OptionElement>() );
			}

			return r;
		}

	}

}

*/

using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class MyAtom:Element{

		protected MyAtom(){}

		[InlineCode("MyFn.CreateAtom({tagName},{type},{className})")]
		public  MyAtom (string tagName, string type=null, string className=null )
		{
		}

		public string Text {
			[InlineCode("{this}.get_text()")]
			get;
			[InlineCode("{this}.set_text({value})")]
			set;
		}

		[InlineCode("MyFn.SetTextFunc({this},{txtFn})")]
		public void SetTextFn(Action<MyAtom,string> txtFn){

		}

		[InlineCode("MyFn.GetTextFunc({this},{txtFn})")]
		public void GetTextFn(Func<MyAtom,string> txtFn){

		}

	}


	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class MyLabel:MyAtom
	{
		[InlineCode("MyFn.CreateAtom('label',null,null)")]
		public MyLabel(){}


		[InlineCode("MyFn.CreateAtom('label',null,{className})")]
		public MyLabel(string className){}


		public string For {
			[InlineCode("{this}.getAttribute('for')")]
			get;
			[InlineCode("{this}.setAttribute('for', {value})")]
			set;
		}
	}

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class MyInput<T>:MyAtom
	{

		[InlineCode("MyFn.CreateInput({T})('input')")]
		public MyInput (){}

		[InlineCode("MyFn.CreateInput({T})({tagName},{type},{className})")]
		public MyInput(string tagName, string type=null, string className=null){}

		[IntrinsicProperty]
		public string Name {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Type {
			get;
			set;
		}
		//

		public T Value {
			[InlineCode("{this}.get_value()")]
			get;
			[InlineCode("{this}.set_value({value})")]
			set;
		}

		[InlineCode("MyFn.SetValueFunc({T})({this},{txtFn})")]
		public void SetValueFn(Action<MyAtom,T> txtFn){

		}

		[InlineCode("MyFn.GetValueFunc({T})({this},{txtFn})")]
		public void GetValueFn(Func<MyAtom,T> txtFn){

		}

		//


		public void Select(){
		}
	
	}

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TextInput:MyInput<string>
	{
		[InlineCode("MyFn.CreateInput(String)('input','text',null)")]
		public TextInput(){
		}
	}


	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public class MyField<TInput,T>:MyAtom where TInput:MyInput<T>, new()
	{
		[InlineCode("MyFn.CreateField({TInput},{T})('input')")]
		public MyField(){
		}

		public TInput Input { 
			[InlineCode("{this}.input")]
			get{return default(TInput);} 

		}


	}


	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public class MyTextField:MyField<TextInput,string>
	{
		[InlineCode("MyFn.CreateField(Element,String)('input','text')")]
		public MyTextField(){
		}

	}

	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class MyFn
	{
		public static MyAtom CreateAtom (string tagName, string type=null, string className=null )
		{
			var el = Document.CreateElement (tagName);

			if (!type.IsNullOrEmpty ())
				el.As<InputElement> ().Type = type;

			if (!className.IsNullOrEmpty ())
				el.ClassName = className;

			ReflectionFn.Set(el, "get_text", (Func<string>)( ()=> GetText(el) ));
			ReflectionFn.Set(el, "set_text", (Action<string>)( (v)=> SetText(el,v) ));

			return el.As<MyAtom> (); 
		}

		public static MyInput<T> CreateInput<T> (string tagName, string type=null, string className=null )
		{
			var el = CreateAtom (tagName, type, className);
			ReflectionFn.Set(el, "get_value", (Func<T>)( ()=> GetValue<T>(el.As<InputElement>()) ));
			ReflectionFn.Set(el, "set_value", (Action<T>)( (v)=> SetValue(el.As<InputElement>(),v) ));
			return el.As<MyInput<T>> ();
		}


		public static MyField<TInput,T> CreateField<TInput,T>(string tagName, string type=null, bool noappend=false) 
			where TInput:MyInput<T> , new ()
		{
			var el = CreateAtom ("div");

			var input = CreateInput<T> (tagName, type);
			ReflectionFn.Set (el, "input", input);
			if (!noappend)
				jQuery.FromElement (el).Append (input);

			return el.As<MyField<TInput,T>> ();
		}



		//public static 


		public static void SetTextFunc(Element el, Action<Element,string > func)
		{
			ReflectionFn.Set(el, "set_text", (Action<string>)( (v)=> func(el,v) ));
		}


		public static void GetTextFunc(Element el, Func<Element,string> func)
		{
			ReflectionFn.Set(el, "get_text", (Func<string>)( ()=> func(el) ));
		}


		public static void SetText( Element atom , string value)
		{
			var v = value ?? "";
			var ctxt = jQuery.Select (AtomFn.CTextTag, atom);
			if (ctxt.Length == 0) {
				jQuery.FromElement (atom).Append (AtomFn.BuildText(v));
			}
			else
				ctxt.Html (v);
		}

		public static string GetText( Element atom)
		{
			var ctxt=jQuery.Select (AtomFn.CTextTag, atom);
			return ctxt.Length == 0 ? "": ctxt.GetHtml();
		}


		//

		public static void SetValue<T>( InputElement atom , T value)
		{
			ReflectionFn.Set (atom, "value", value);
		}

		public static T GetValue<T>( InputElement atom)
		{
			return (T)(ReflectionFn.Get (atom, "object")??ReflectionFn.Get (atom, "value"));
		}


	}


}