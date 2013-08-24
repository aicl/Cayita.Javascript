using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class IntInput:BaseNumericInput<int>
	{
		[InlineCode("Cayita.UI.IntInput()")]
		public IntInput ()
		{

		}
	}

}

