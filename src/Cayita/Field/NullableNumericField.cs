using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NullableNumericField:Field<decimal?>
	{
		[InlineCode("Cayita.UI.NullableNumericField()")]
		public NullableNumericField()
		{
		}

		[InlineCode("Cayita.UI.NullableNumericField({name},{placeholder})")]
		public NullableNumericField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.NullableNumericField(null, null, {action},{parent})")]
		public NullableNumericField(Atom parent, Action<NullableNumericField> action=null)
		{
		}

	}
}

