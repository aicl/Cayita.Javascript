using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Button:Atom
	{
		[InlineCode("Cayita.UI.Button()")]
		public Button(){}

		[InlineCode("Cayita.UI.Button({text},{className},{type})")]
		public Button(string text, string className="btn", string type =null ){}

		[InlineCode("Cayita.UI.Button(null, null, null, {action},{parent})")]
		public Button(Atom parent, Action<Div> action=null){}


		[InlineCode("Cayita.UI.Button(null, null, null, {action},null)")]
		public Button(Action<Div> action){}

		[IntrinsicProperty]
		public Form Form {
			get;
			set;
		}
		
		
		[IntrinsicProperty]
		public string Value {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Type {
			get;
			set;
		}

		[IntrinsicProperty]
		public bool Autofocus {
			get;
			set;
		}

	}
}

