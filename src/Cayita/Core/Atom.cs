using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Atom:Element{

		protected Atom(){}

		[InlineCode("Cayita.UI.Atom({tagName},{type},{className})")]
		public  Atom (string tagName, string type=null, string className=null )
		{
		}


		public jQueryObject JQuery{
			[InlineCode("$({this})")] get{ return null;}
		}

		public void Append(Element child){
		}

		[InlineCode("$({this}).append({content})")]
		public void Append(string content){
		}


		[InlineCode("$({this}).toggle()")]
		public void Toggle(){
		}


		[InlineCode("$({this}).empty()")]
		public void Empty(){
		}

		[InlineCode("$({this}).remove()")]
		public void Remove(){
		}


		[InlineCode("$({this}).addClass({className})")]
		public void AddClass(string className){

		}

		[InlineCode("{this}.classList.remove({className})")]
		public void RemoveClass(string className){
		
		}


		[InlineCode("{this}.classList.contains({className})")]
		public bool HasClass(string className){
			return false;
		}


		[IntrinsicProperty]
		public string OuterHTML
		{
			get{ return "";}
		}

		public string Text {
			get;
			set;
		}

		[InlineCode("{this}.set_getTextFn({txtFn})")]
		public void SetTextFn(Action<Atom,string> txtFn){

		}

		[InlineCode("{this}.set_setTextFn({txtFn})")]
		public void GetTextFn(Func<Atom,string> txtFn){

		}

		public string CreateId(){
			return "";
		}


		public bool Hidden {
			[InlineCode("{this}.is_hidden()")]
			get;
			[InlineCode("{this}.do_hide({value})")]
			set;
		}



		[InlineCode("{this}.add_handler({eventName},{eventHandler},{selector}, {context})")]
		public  void On ( string eventName, jQueryEventHandler eventHandler, string selector="",  object context=null )
		{
		}

		[InlineCode("{this}.remove_handler({eventName},{eventHandler},{selector})")]
		public  void Off ( string eventName, jQueryEventHandler eventHandler, string selector="")
		{
		}

		public event jQueryEventHandler Clicked {
			[InlineCode("{this}.add_clicked({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_clicked({value})")]
			remove
			{
			}
		}


	}




}

//f.Append("<style>.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  </style>");