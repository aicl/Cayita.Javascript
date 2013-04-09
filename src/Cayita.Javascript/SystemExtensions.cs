using System;
using System.Runtime.CompilerServices;

namespace System
{
	[Serializable]	
	public static class SystemExtensions
	{
		public static JsDate ToJsDate(this DateTime date){
			if(date==null) return null;
			var tick = long.Parse( date.ToString());
			var d = new DateTime(tick);
			return new JsDate( d.GetUtcFullYear(),d.GetUtcMonth(), d.GetUtcDate(),
			                  d.GetUtcHours(), d.GetUtcMinutes(), d.GetUtcSeconds());
		}

		[InlineCode("cayita.fn.convertToDate({value})")]
		public static DateTime ConvertToDate(this DateTime value){
			return default(DateTime);
		}

		public static string Format(this JsDate date, string format){
			if(date==null) return string.Empty;
			return date.Format(format);
		}

		/// <summary>
		/// Determines if value is date formatted. 
		/// </summary>
		/// <returns>
		/// <c>true</c> if  value  is formatted as dd.mm.yyyy || dd/mm/yyyy || dd-mm-yyyy; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='value'>
		/// Value.
		/// </param>
		[InlineCode("cayita.fn.isDateFormatted({value})")]
		public static bool IsDateFormatted(this string value)
		{
			return false;
		}

		/// <summary>
		/// Convert date-formatted string into a date (see IsDateFormatted)
		/// </summary>
		/// <returns>
		/// The date.
		/// </returns>
		/// <param name='value'>
		/// Value.
		/// </param>
		//[InlineCode("(function(value){{return new Date(value.slice(6,10), parseInt(value.slice(3,5)-1) , value.slice(0,2))}})({value})")]
		[InlineCode("cayita.fn.toDate({value})")]
		public static DateTime ToDate(this string value)
		{
			return default(DateTime);
		}

		[InlineCode("cayita.fn.populateFrom({target},{source})")]
		public static void PopulateFrom(this object target, object source)
		{}

		[InlineCode("cayita.fn.toServerDate({value})")]
		public static string ToServerDate(this string value)
		{
			return null;
		}

		[InlineCode("cayita.fn.clone({source})")]
		public static T Clone<T>(this T  source)
		{
			return default(T);
		}
	}
}

