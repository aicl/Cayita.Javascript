using System;
using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using jQueryApi;

namespace Cayita
{

	public static partial class Fn
	{
		public static jQueryXmlHttpRequest Send (this FormData fd, string url)
		{
			return jQuery.Ajax ( new jQueryAjaxOptions{
				Url=url,
				Type="POST",
				Data= fd.AsTypeOption(),
				ProcessData=false,
				ContentType=""
			});
		}


		public static Action<Action,int>  RunAfterFn()
		{

			var timer = 0;

			return  (Action<Action,int>)( (cb,dl)=>{
				Window.ClearTimeout(timer);
				timer= Window.SetTimeout(cb,dl);
			});

		}

		public static void RunAfter(this Action callback, int miliseconds)
		{
			RunAfterFn ()(callback, miliseconds);
		}


		public static Action<Action,int> DelayFn = ((Func<Action<Action,int>>)( ()=> {
			var timer = 0;
			return  (Action<Action,int>)( (cb,dl)=>{
				Window.ClearTimeout(timer);
				timer= Window.SetTimeout(cb,dl);
			});
		}))();

		public static void Delay(this Action callback, int miliseconds)
		{
			DelayFn (callback, miliseconds);
		}


		public static string[]  GetProperties(this object o){
			string[] keys = Object.Keys (o);
			var r = new List<string> ();

			foreach (var i in keys){
				if (Script.TypeOf( ((dynamic)o)[i]) != "function")
					r.Add (i); 

			}

			return r.ToArray();
		}


		public static void CopyFrom(this object target,  object source)
		{
			var p = source.GetProperties ();
			foreach (var s in p)
				((dynamic)target) [s] = ((dynamic)source) [s];
		}


		public static void PopulateFrom (this Record target, Record source)
		{
			var tp = target.GetProperties ();
			var sp = source.GetProperties ();
			foreach (var s in tp) {
				if (sp.Contains (s))
					((dynamic)target) [s] = ((dynamic)source) [s];
			}
		}

		public static Record Clone (this Record target)
		{
			var source = new JsDictionary<string, object> ();
			CopyFrom (target, source);
			return UI.Cast<Record>(source);
		}


		public static DateTime? Normalize(this DateTime date){
			if(date==null) return null;
			var d = new DateTime (new Regex (@"//Date\(([^)]+)\)//").Exec("/{0}/".Fmt(date))[1].ParseFloat());
			return new DateTime( d.GetUtcFullYear(),d.GetUtcMonth(), d.GetUtcDate(),
			                  d.GetUtcHours(), d.GetUtcMinutes(), d.GetUtcSeconds());
		}

		[InlineCode("parseFloat({value})")]
		static long ParseFloat (this string value){
			return 0;
		}

		internal static  object Get(this object o, string property)
		{
			return (object) ((dynamic)o)[property] ; 
		}

		internal static  T Get<T>(this object o, string property) 
		{
			return  UI.Cast<string> (((dynamic)o)[property]); 
		}

		[InlineCode("{@func}.call({arg})")]
		internal static T Call<T>(string func, object arg){
			return default(T);
		}


		[InlineCode("this.{@name}={value}")]
		public static void 	AddObject(string name, object value){
		}

		[InlineCode("this.{@name}")]
		public static T GetObject<T>(string name){
			return default(T);
		}

		[InlineCode("this")]
		public static T This<T>(){
			return default(T);
		}

		public static void SomeClass(string name)
		{
			int? age=null;
			Fn.AddObject("name", name);
			Fn.AddObject("showName", (Action)(
				()=>Firebug.Console.Log( Fn.This<SomeClass>().Name )));

			Fn.AddObject("setAge", (Action<int>)(
				(a)=> age=a ));

			Fn.AddObject("showAge", (Action)(
				()=>Firebug.Console.Log( "Age;", age )));

		}

	}

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class SomeClass{
		[InlineCode("new Cayita.Fn.SomeClass({yourname})")]
		public SomeClass(string yourname){
		}
		[IntrinsicProperty]
		public string Name { get; set; }
		public void ShowName(){
		}
		public void ShowAge(){
		}
		public void SetAge(int age){
		}

	}

}
//http://phrogz.net/JS/classes/OOPinJS.html
//http://phrogz.net/JS/classes/ExtendingJavaScriptObjectsAndClasses.html
//http://net.tutsplus.com/tutorials/javascript-ajax/quick-tip-private-variables-in-javascript/
