using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NullableIntField: Field<int?>
	{

		[InlineCode("Cayita.UI.NullableIntField()")]
		public NullableIntField()
		{
		}

		[InlineCode("Cayita.UI.NullableIntField({name},{placeholder})")]
		public NullableIntField(string name, string placeholder=null)
		{
		}


		[InlineCode("Cayita.UI.NullableIntField(null, null, {action},{parent})")]
		public NullableIntField(Atom parent, Action<NullableIntField> action)
		{
		}

	}
}

