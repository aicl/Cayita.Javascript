using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class IntField:Field<int>
	{
		[InlineCode("Cayita.UI.IntField()")]
		public IntField()
		{
		}

		[InlineCode("Cayita.UI.IntField({name},{placeholder})")]
		public IntField(string name, string placeholder=null)
		{
		}

		[InlineCode("Cayita.UI.IntField(null, null, {action},{parent})")]
		public IntField(Atom parent, Action<IntField> action)
		{
		}

		[IntrinsicProperty]
		public new IntInput Input {
			get;
			internal set;
		}

	}
}

