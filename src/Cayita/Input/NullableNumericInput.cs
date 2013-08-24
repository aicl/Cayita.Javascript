using System.Runtime.CompilerServices;

namespace Cayita
{
	
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class NullableNumericInput:BaseNumericInput<decimal?>
	{
		[InlineCode("Cayita.UI.NullableNumericInput()")]
		public NullableNumericInput ()
		{

		}
	}

}
