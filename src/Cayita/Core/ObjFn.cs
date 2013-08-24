using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class ObjFn
	{
		[InlineCode("{value}=='0'?0:parseFloat({value})||null")]
		public static decimal? ParseNullableFloat (this object value)
		{
			return null;
		}

		[InlineCode("parseFloat({value})||0")]
		public static decimal ParseFloat (this object value)
		{
			return default(decimal);
		}


	}
}

