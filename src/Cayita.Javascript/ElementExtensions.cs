using System.Html;
using jQueryApi;
using System.Runtime.CompilerServices;
using Cayita.Javascript.Plugins;

namespace Cayita.Javascript
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public static class ElementExtensions
	{
		[InlineCode("'#'+{element}.id")]
		public static string SelectorById(this Element element)
		{
			return "";
		}

		[InlineCode("$({element})")]
		public static jQueryObject JQuery(this Element element)
		{
			return null;
		}

		[InlineCode("$({selector},{element})")]
		public static jQueryObject JQuery(this Element element, string selector)
		{
			return null;
		}

		[InlineCode("$({element}).text({value})")]
		public static jQueryObject Text(this Element element, string value)
		{
			return null;
		}

		[InlineCode("$({element}).addClass({className})")]
		public static jQueryObject AddClass(this Element element, string className)
		{
			return null;
		}

		[InlineCode("$({element}).removeClass({className})")]
		public static jQueryObject RemoveClass(this Element element, string className)
		{
			return null;
		}

		[InlineCode("$({parent}).append({child})")]
		public static jQueryObject Append(this Element parent, Element child)
		{
			return null;
		}

		[InlineCode("$({parent}).append({text})")]
		public static jQueryObject Append(this Element parent, string text)
		{
			return null;
		}

		[InlineCode("$({element}).empty()")]
		public static jQueryObject Empty(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).remove()")]
		public static jQueryObject Remove(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).hide()")]
		public static jQueryObject Hide(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).show()")]
		public static jQueryObject Show(this Element element)
		{
			return null;
		}


		[InlineCode("$({element}).slideToggle()")]
		public static jQueryObject SlideToggle(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).fadeIn()")]
		public static jQueryObject FadeIn(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).fadeOut()")]
		public static jQueryObject FadeOut(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).fadeToggle()")]
		public static jQueryObject FadeToggle(this Element element)
		{
			return null;
		}

		[InlineCode("$({element}).serialize()")]
		public static object Serialize(this FormElement element)
		{
			return null;
		}

		[InlineCode("$({element}).autoNumeric('getString')")]
		public static object AutoNumericGetString(this FormElement element)
		{
			return null;
		}

		[InlineCode("cayita.fn.autoNumericInit({element})")]
		public static jQueryObject AutoNumericInit(this InputElement element)
		{
			return null;
		}
	
		[InlineCode("cayita.fn.autoNumericInit({element}, {options})")]
		public static jQueryObject AutoNumericInit(this InputElement element, dynamic options)
		{
			return null;
		}

		[InlineCode("cayita.fn.autoNumericInit({element})")]
		public static jQueryObject AutoNumericInit(this TableCellElement element)
		{
			return null;
		}
		
		[InlineCode("cayita.fn.autoNumericInit({element},{options})")]
		public static jQueryObject AutoNumericInit(this TableCellElement element, dynamic options)
		{
			return null;
		}


		[InlineCode("$('tbody tr', {element})")]
		public static jQueryObject JSelectRows(this TableElement element)
		{
			return null;
		}

		[InlineCode("$('tr[record-id='+{recordId}+']', {element})")]
		public static jQueryObject JSelectRow(this TableElement element, object recordId)
		{
			return null;
		}

		[InlineCode("$({element}).attr('required',{value})")]
		public static jQueryObject SetRequired(this InputElement element, bool value=true)
		{
			return null;
		}

		[InlineCode("$({element}).attr('placeholder',{value})")]
		public static jQueryObject SetPlaceHolder(this TextElement element, string value)
		{
			return null;
		}

		[InlineCode("$({element}).attr('minlength',{value})")]
		public static jQueryObject SetMinLength(this TextElement element, int value)
		{
			return null;
		}
			
		[InlineCode("$({element}).attr('maxlength',{value})")]
		public static jQueryObject SetMaxLength(this TextElement element, int value)
		{
			return null;
		}

		[InlineCode("{element}.getAttribute('record-id')")] 
		public static string GetRecordId(this TableRowElement element)
		{
			return null;
		}

		[InlineCode("cayita.fn.setValue({element}, {value})")] 
		public static jQueryObject SetValue(this InputElement element, object value)
		{
			return null;
		}

		[InlineCode("$({element}).text({value})")]
		public static jQueryObject SetValue(this TableCellElement element, object value)
		{
			return null;
		}


		[InlineCode("cayita.fn.getValue({element})")] 
		public static object GetValue(this InputElement element)
		{
			return null;
		}

		[InlineCode("cayita.fn.getValue({element})")] 
		public static T GetValue<T>(this InputElement element)
		{
			return default(T);
		}

		//$( "#s" + " option[value="+2+"]").attr("selected",true);
		/// <summary>
		/// Selects the item.
		/// </summary>
		/// <returns>
		/// The selected item.
		/// </returns>
		/// <param name='element'>
		/// SelectElement.
		/// </param>
		/// <param name='value'>
		/// Value.
		/// </param>
		[InlineCode("$('option[value='+{value}+']',{element}).attr('selected',true)")]
		public static jQueryObject SelectOption( this SelectElement element, object value)
		{
			return null;
		}
		//$("option:selected").prop("selected", false)
		[InlineCode("$('option:selected',{element}).prop('selected',false)")]
		public static jQueryObject UnSelectOption(this SelectElement element)
		{
			return null;
		}

		[InlineCode("$('option[value='+{value}+']', {element})")]
		public static jQueryObject GetOption(this SelectElement element, object value)
		{
			return null;
		}

		#region jquery.validate jQuery Validation Plugin - v1.10.0 

		[InlineCode("$({element}).validate()")]
		public static void Validate(this FormElement element)
		{
		}
		
		[InlineCode("$({element}).validate({options})")] // TODO : returns validator !!!
		public static void Validate(this FormElement element, ValidateOptions options )
		{
		}

		[InlineCode("typeof({o}.{@property})=='undefined'")]
		public static bool IsUndefined<T>(this T o, string property ) where T: new()
		{
			return false;
		}

		#endregion jquery.validate jQuery Validation Plugin - v1.10.0 
			
		[InlineCode("Array.isArray({o})")]
		public static bool IsArray(this object o)
		{
			return false;
		}

		[InlineCode("$({button}).attr('type',{value})")]
		public static jQueryObject Type(this ButtonElement button, string value)
		{
			return null;
		}

	}
}
