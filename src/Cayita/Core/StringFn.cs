using System.Runtime.CompilerServices;

namespace Cayita
{

	public static partial class Fn
	{
		[InlineCode("ss.isNullOrEmptyString({str})")]
		public static bool IsNullOrEmpty(this string str)
		{
			return false;
		}
		
		public static string Fmt(this string format, params object[] args)
		{
			return string.Format (format, args);
		}


		[InlineCode("{value}=='0'?0:parseFloat({value})||null")]
		public static decimal? ParseNullableNumber (this string value)
		{
			return null;
		}

		[InlineCode("parseFloat({value})||0")]
		public static decimal ParseNumber (this string value)
		{
			return default(decimal);
		}


		[InlineCode("Alertify.log.info({message},{delay})")]
		public static void LogInfo (this string message, int delay=5000)
		{
		}

		[InlineCode("Alertify.log.success({message},{delay})")]
		public static void LogSuccess (this string message, int delay=5000)
		{
		}

		[InlineCode("Alertify.log.error({message},{delay})")]
		public static void LogError (this string message, int delay=0)
		{
		}


		public static Atom Header (this string text,  int size)
		{
			return UI.Atom ("h" + size.ToString (),null, null, text);

		}

		public static Paragraph Paragraph (this string text)
		{
			return UI.Atom ("p" ,null, null, text).As<Paragraph>();
		}

	}
}

