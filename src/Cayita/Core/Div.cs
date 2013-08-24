using System;
using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Div:Atom
	{

		[InlineCode("Cayita.UI.Atom('div')")]
		public Div(){}

		[InlineCode("Cayita.UI.Atom('div',null,null,null,{action},{parent})")]
		public Div(Atom parent, Action<Div> action=null){}

		[InlineCode("Cayita.UI.Atom('div',null,null,null,{action})")]
		public Div(Action<Div> action){}


		[InlineCode("Cayita.UI.Atom('div',null,{className})")]
		public Div(string className){}


		[IntrinsicProperty]
		public string Align 
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public bool NoWrap
		{
			get;
			set;
		}

	}



}

