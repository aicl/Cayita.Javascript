using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CheckInput<T> : Input<T>
	{
		[InlineCode("Cayita.UI.CheckInput({T})()")]
		public CheckInput(){
		}

		[InlineCode("Cayita.UI.CheckInput({T})(null,null,null, {action},{parent})")]
		public CheckInput(Atom parent, Action<CheckInput<T>> action=null){
		}

		[IntrinsicProperty]
		public new bool Checked {
			get;
			set;

		}
		[IntrinsicProperty]
		public bool DefaultChecked {
			get;
			set;
		}
		[IntrinsicProperty]
		public bool Indeterminate {
			get;
			set;
		}

	}


	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CheckInput : CheckInput<bool>
	{
		[InlineCode("Cayita.UI.BooleanCheck()")]
		public CheckInput(){
		}

		[InlineCode("Cayita.UI.BooleanCheck(null,null,null, {action},{parent})")]
		public CheckInput(Atom parent, Action<CheckInput> action=null){
		}

	}

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class RadioInput<T> : CheckInput<T>
	{
		[InlineCode("Cayita.UI.RadioInput({T})()")]
		public RadioInput(){
		}
	}

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class RadioInput : CheckInput<bool>
	{
		[InlineCode("Cayita.UI.BooleanRadioInput()")]
		public RadioInput(){
		}
	}


}

