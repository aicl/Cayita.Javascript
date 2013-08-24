using System.Runtime.CompilerServices;
using System;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NumericInput:BaseNumericInput<decimal>
	{
		[InlineCode("Cayita.UI.NumericInput()")]
		public NumericInput ()
		{
		}


		[InlineCode("Cayita.UI.NumericInput(null, null, null, null, {action}, {parent})")]
		public NumericInput (Atom parent, Action<NumericInput> action)
		{
		}

	}

}

