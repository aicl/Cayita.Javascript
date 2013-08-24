using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NumericField:Field<decimal>
	{
		[InlineCode("Cayita.UI.NumericField()")]
		public NumericField()
		{
		}

		[InlineCode("Cayita.UI.NumericField({name},{placeholder})")]
		public NumericField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.NumericField(null, null, {action},{parent})")]
		public NumericField(Atom parent, Action<NumericField> action = null)
		{
		}

	}
}

