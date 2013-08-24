
using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Collections.Generic;

namespace Cayita
{
	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class ElFn
	{


		[PreserveName]
		internal static void SetValue(this Element element, object value)
		{


			if(value==null) {
				ReflectionFn.Set (element, "value", "");
				return;
			}

			var type = (ReflectionFn.Get(element, "type")??"").ToString();

			if(type=="radio" || type=="checkbox" || type=="select-one" || type=="select-multiple"
			   || type=="option")
			{
				ReflectionFn.Set (element, "object", value);
				ReflectionFn.Set (element, "value", value);
			}
			else if (element.HasAttribute ("autonumeric")) {
				jQuery.FromElement (element).Execute ("autoNumeric", "set", value);
			} else if (element.HasAttribute ("datepicker")) {
				jQuery.FromElement (element).Execute ("datepicker", "setDate", value);
			} else {
				ReflectionFn.Set (element, "value", value);
			}

		}

		[PreserveName]
		internal static object GetValue(this Element element)
		{
			object r;
			var type = (ReflectionFn.Get(element, "type")??"").ToString();
			if ( type == "select-one" || type == "select-multiple") {
				var index = element.As<SelectElement> ().SelectedIndex;
				r= index < 0 
					? null 
						: ReflectionFn.Get (element.As<SelectElement> ().Options[index], "object");

			}
			else if (element.HasAttribute ("autonumeric")) {
				r=jQuery.FromElement (element).Execute ("autoNumeric", "get").ParseNullableFloat();
			} else if (element.HasAttribute ("datepicker")) {
				r=jQuery.FromElement (element).Execute ("datepicker", "getDate");
			} else {
				r=ReflectionFn.Get (element, "object")??ReflectionFn.Get (element, "value");
			}

			return r;

		}


	}
}

