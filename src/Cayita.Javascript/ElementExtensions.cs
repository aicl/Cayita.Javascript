using System.Html;
using jQueryApi;
using System.Runtime.CompilerServices;
using Cayita.Plugins;

namespace Cayita.UI
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
		public static jQueryObject AppendTo(this Element child, Element parent)
		{
			return null;
		}

		[InlineCode("$({parent}.element()).append({child})")]
		public static jQueryObject AppendTo<T>(this jQueryObject child, ElementBase<T> parent) where T: ElementBase
		{
			return null;
		}


		[InlineCode("$({parent}).append({child})")]
		public static jQueryObject Append(this Element parent, Element child)
		{
			return null;
		}

		[InlineCode("$({parent}).append({child}.element())")]
		public static jQueryObject Append<T>(this Element parent, ElementBase<T> child) where T: ElementBase
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

		[InlineCode("cayita.fn.serialize({form})")]
		public static string Serialize(this FormElement form)
		{
			return null;
		}

		[InlineCode("cayita.fn.dataChanged({form})")]
		public static bool DataChanged(this FormElement form)
		{
			return false;
		}
					
		[InlineCode("cayita.fn.autoNumeric({element}, {options})")]
		public static jQueryObject AutoNumeric(this InputElement element, dynamic options= null)
		{
			return null;
		}
				
		[InlineCode("cayita.fn.autoNumeric({element},{options})")]
		public static jQueryObject AutoNumeric(this TableCellElement element, dynamic options=null)
		{
			return null;
		}

		[InlineCode("cayita.fn.datepicker({element}, {options})")]
		public static jQueryObject Datepicker(this InputElement element, dynamic options=null)
		{
			return null;
		}


		[InlineCode("$('tbody tr', {element})")]
		public static jQueryObject GetRows(this TableElement element)
		{
			return null;
		}

		[InlineCode("$('tbody tr', {element}).first()")]
		public static jQueryObject GetFirstRow(this TableElement element)
		{
			return null;
		}

		[InlineCode("$('tbody tr', {element}).last()")]
		public static jQueryObject GetLastRow(this TableElement element)
		{
			return null;
		}

		[InlineCode("$('tr[record-id='+{recordId}+']', {element})")]
		public static jQueryObject GetRow(this TableElement element, object recordId)
		{
			return null;
		}

		[InlineCode("$({element}).attr('required',{value})")]
		public static jQueryObject Required(this InputElement element, bool value=true)
		{
			return null;
		}

		[InlineCode("$({element}).attr('data-type','numeric')")]
		public static jQueryObject IsNumeric(this InputElement element)
		{
			return null;
		}

		[InlineCode("$({element}).attr('placeholder',{value})")]
		public static jQueryObject PlaceHolder(this InputElement element, string value)
		{
			return null;
		}

		[InlineCode("$({element}).attr('minlength',{value})")]
		public static jQueryObject MinLength(this TextElement element, int value)
		{
			return null;
		}
			
		[InlineCode("$({element}).attr('maxlength',{value})")]
		public static jQueryObject MaxLength(this TextElement element, int value)
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


		//

		[InlineCode("$({element}).on({eventName},{selector}, {eventHandler})")]
		public static jQueryObject On(this Element element, string eventName, string selector, jQueryEventHandler eventHandler)
		{
			return null;
		}

		[InlineCode("$({element}).on({eventName},{eventHandler})")]
		public static jQueryObject On(this Element element, string eventName,  jQueryEventHandler eventHandler)
		{
			return null;
		}

		[InlineCode("$({element}).on('click', {selector}, {eventHandler})")]
		public static jQueryObject OnClick(this Element element, string selector, jQueryEventHandler eventHandler)
		{
			return null;
		}

		[InlineCode("$({element}).on('click',{eventHandler})")]
		public static jQueryObject OnClick(this Element element,  jQueryEventHandler eventHandler)
		{
			return null;
		}


		[InlineCode("$({form}).on('change', {selector}, {eventHandler})")]
		public static jQueryObject OnChange(this FormElement form, string selector, jQueryEventHandler eventHandler)
		{
			return null;
		}
		
		[InlineCode("$({form}).on('change','input', {eventHandler})")]
		public static jQueryObject OnChange(this FormElement form,  jQueryEventHandler eventHandler)
		{
			return null;
		}

		[InlineCode("$({element}).is(':visible')")]
		public static bool IsVisible(this Element element)
		{
			return false;
		}

		[InlineCode("{element}.is(':visible')")]
		public static bool IsVisible(this jQueryObject element)
		{
			return false;
		}

		[InlineCode("Alertify.log.info({message}.outerHTML,{delay})")]
		public static void LogInfo(this Element message, int delay=5000)
		{	
		}

		[InlineCode("Alertify.log.info({message}.outerHTML,{delay})")]
		public static void LogSuccess(this Element message, int delay=5000)
		{	
		}

		[InlineCode("Alertify.log.error({message}.outerHTML,{delay})")]
		public static void LogError(this Element message, int delay=0)
		{
			
		}

	}
}
