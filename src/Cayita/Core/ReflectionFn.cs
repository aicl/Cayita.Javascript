using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class ReflectionFn
	{
	
		[InlineCode("{o}.{@property}={value}")]
		public static void Set( Object o , string property, object value)
		{
			((dynamic)o) [property] = value; // see inlinecode
		}

		[InlineCode("{o}.{@property}")]
		public static object Get( Object o , string property)
		{
			return ((dynamic)o) [property]; //see inlinecode
		}


		[InlineCode("typeof({o}.{@property})=='undefined'")]
		public static bool Undefined(object o, string property )
		{
			return false;
		}

		[InlineCode("typeof({o}.{@property})!='undefined' && typeof({o}.{@property})!='function'"  )]
		public static bool HasProperty(object o, string property)
		{
			return false;
		}

		[InlineCode("Array.isArray({o})")]
		public static bool IsArray(this object o)
		{
			return false;
		}


		[ScriptSkip]
		internal static T As<T> (object o){
			return default(T);
		}

	}
}

