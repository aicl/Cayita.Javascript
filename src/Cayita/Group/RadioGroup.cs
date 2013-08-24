using System.Runtime.CompilerServices;
using System;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class RadioGroup<T>:GroupBase<T> {

		[InlineCode("Cayita.UI.RadioGroup({T})()")]
		public RadioGroup(){

		}

		[InlineCode("Cayita.UI.RadioGroup({T})({action},{parent})")]
		public RadioGroup(Atom parent, Action<RadioGroup<T>> action=null){

		}

	}
}
