using System.Runtime.CompilerServices;
using System;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CheckField:Field<bool>
	{
		[InlineCode("Cayita.UI.CheckField()")]
		public CheckField()
		{
		}

		[InlineCode("Cayita.UI.CheckField({name},{text})")]
		public CheckField(string name, string text=null)
		{
		}

		[InlineCode("Cayita.UI.CheckField(null, null, {action},{parent})")]
		public CheckField(Atom parent, Action<CheckField> action=null){}
	}


}

