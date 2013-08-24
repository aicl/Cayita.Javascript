using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NullableIntInput:BaseNumericInput<int>
	{
		[InlineCode("Cayita.UI.NullableIntInput()")]
		public NullableIntInput ()
		{

		}
	}
}

