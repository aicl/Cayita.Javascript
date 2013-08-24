using System;
using System.Runtime.CompilerServices;
using System.Html;
using System.Collections;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Form:Atom
	{
		[InlineCode("Cayita.UI.Form()")]
		public Form ()
		{
		}

		[InlineCode("Cayita.UI.Form({parent},{action})")]
		public Form (Atom parent,Action<Form> action=null )
		{
		}


		[InlineCode("Cayita.UI.Form(null,{action})")]
		public Form (Action<Form> action )
		{
		}

		[IntrinsicProperty]
		public string AcceptCharset {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Action
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public Atom[] Elements
		{
			get{ return null;}

		}

		[IntrinsicProperty]
		public string Encoding
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public string EncType
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public int Length
		{
			get
			{
				return 0;
			}
		}

		[IntrinsicProperty]
		public string Method
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public string Name
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public string Target
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public Action<Form> SubmitHandler
		{
			get;
			set;
		}

		public void Reset ()
		{
		}

		public void Submit ()
		{
		}



		[InlineCode("{this}.populateFrom({data})")]
		public void PopulateFrom<T>(T data) where T: Record
		{
		}

		[InlineCode("{this}.populateFrom({data})")]
		public void PopulateFrom(JsDictionary data)
		{
		}

		[InlineCode("{this}.populate({data})")]
		public void Populate(Record data)
		{
		}

		[InlineCode("{this}.populate({data})")]
		public void Populate(JsDictionary data)
		{
		}

		public Input[] Inputs{
			get{ return null;}
		}

		public bool CheckValidity(){
			return false;
		}

		public void Clear(){
		}

		public bool HasChanges(){
			return false;
		}


		public event jQueryEventHandler Changed {
			[InlineCode("{this}.add_changed({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_change({value})")]
			remove
			{
			}
		}

		public event Action<Form,FormUpdatedAction> Updated{
			[InlineCode("{this}.add_updated({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_updated({value})")]
			remove
			{
			}
		}


		[IntrinsicProperty]
		internal Action<Form, FormUpdatedAction> _updated {
			get;
			set;
		}

		[IntrinsicProperty]
		internal Func<Input,bool> _validate {
			get;
			set;
		}
		[IntrinsicProperty]
		internal Action<Form>  _clear{
			get;set;
		}
	}
}

//https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/Forms/Data_form_validation?redirectlocale=en-US&redirectslug=HTML%2FForms%2FData_form_validation