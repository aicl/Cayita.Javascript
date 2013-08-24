using System;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace Cayita
{

	public static partial class Plugins
	{
		[PreserveCase]
		public static NumericOptions NumericOptions(){
			var o = UI.Cast<NumericOptions> (new {});
			o.MaxValue=9007199254740992;
			o.MinValue=-9007199254740992;
			return o;
		}

		[PreserveCase]
		public static AutoNumeric AutoNumeric(Atom input, NumericOptions options=null)
		{

			Init (input, options);		
			dynamic methods = new {};

			methods["get"]= (Func<bool, decimal?>)( (r)=>  GetValue(input,false)  );
			methods["set"]= (Action< decimal?>)( (v)=> SetValue(input,v) );
			methods["init"]= (Action<NumericOptions>)( o=> Init(input,o) );
			methods["update"]= (Action<NumericOptions>)( o=> Update(input,o) );
			methods["getSettings"]= (Func<NumericOptions>)( ()=> GetSettings(input) );

			input.DefineAtomProperty ("autoNumeric", new {value=methods, writable= false});

			return UI.Cast<AutoNumeric> (input);
		}


		static decimal? GetValue(Atom input, bool required=false)
		{
			var v = jQuery.FromElement (input).Execute<string>("autoNumeric", "get");
			return (required)? v.ParseNumber(): v.ParseNullableNumber ();
		}

		static void SetValue(Atom input, decimal? value)
		{
			jQuery.FromElement (input).Execute("autoNumeric", "set", value);
		}

		static void Init (Atom input, NumericOptions options=null)
		{
			if (input.HasAttribute ("autonumeric"))
				return;
			InitImp (input, options);

		}

		static void Update (Atom input, NumericOptions options)
		{
			if (!input.HasAttribute ("autonumeric"))
				InitImp (input, options);
			else
				jQuery.FromElement (input).Execute ("autoNumeric", "update", options);

		}

		static NumericOptions GetSettings (Atom input)
		{
			if (!input.HasAttribute ("autonumeric"))
				InitImp (input);
			return jQuery.FromElement (input).Execute<NumericOptions> ("autoNumeric", "getSettings");

		}


		static void InitImp (Atom input, NumericOptions options=null)
		{
			input.SetAttribute ("autonumeric", true);
			input.SetAttribute ("data-type", "numeric");
			input.Style.CssText = "text-align:right;";
			jQuery.FromElement (input).Execute ("autoNumeric", "init", options);
		}
	}
}


