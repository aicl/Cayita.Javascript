using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class BaseNumericInput<T>:Input<T>
	{
		public NumericOptions Settings {
			[InlineCode("{this}.autoNumeric.getSettings()")]
			get;
			[InlineCode("{this}.autoNumeric.update({value})")]
			set;
		}
	}

}