using System.Runtime.CompilerServices;
using System;
using jQueryApi;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class Input:Atom
	{
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

		[IntrinsicProperty]
		public string Placeholder {
			get;
			set;
		}

		[IntrinsicProperty]
		public bool Required {
			get;
			set;
		}

		[IntrinsicProperty]
		public bool ReadOnly {
			get;
			set;
		}

		[IntrinsicProperty]
		public bool Checked {
			get;
			set;
		}

		[IntrinsicProperty]
		public int MaxLength {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Value {
			get;
			set;
		}

		[IntrinsicProperty]
		public ValidityState Validity {
			get{ return null;}
		}


		[IntrinsicProperty]
		public string  ValidationMessage {
			get{ return null;}
		}

		[IntrinsicProperty]
		internal PopoverObject ErrorMessage{
			get;
			set;
		}

		public int MinLength {
			get;
			set;
		}


		[IntrinsicProperty]
		public string Pattern{
			get;
			set;
		}

		[IntrinsicProperty]
		public Func<Input,string> MinLengthMsgFn{
			get;
			set;
		}

		[IntrinsicProperty]
		internal int _minLength {
			get;
			set;
		}


		public void Select(){
		}

		public bool CheckValidity()
		{
			return false;
		}

		public void SetCustomValidity(string message)
		{

		}

	}

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class Input<T>:Input
	{

		[InlineCode("Cayita.UI.Input({T})('input')")]
		protected Input (){}

		[InlineCode("Cayita.UI.Input({T})({tagName},{type},{className})")]
		protected Input(string tagName, string type=null, string className=null){}


		public new T Value {
			[InlineCode("{this}.get_value()")]
			get;
			[InlineCode("{this}.set_value({value})")]
			set;
		}

		[InlineCode("{this}.set_setValueFn({valFn})")]
		public void SetValueFn(Action<Atom,T> valFn){

		}

		[InlineCode("{this}.set_getValueFn({valFn})")]
		public void GetValueFn(Func<Atom,T> valFn){

		}


		public event jQueryEventHandler Changed {
			[InlineCode("{this}.add_changed({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_changed({value})")]
			remove
			{
			}
		}

	}

}

