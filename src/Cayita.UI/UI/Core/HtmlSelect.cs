using System;
using System.Html;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita.UI
{
	public class HtmlSelect:CayitaElement
	{
		public HtmlSelect ():base("select")
		{
		}

		public HtmlSelect (Action<SelectElement> div):this()
		{
			div.Invoke (Element ());
		}
		
		public new SelectElement Element()
		{
			return El.As<SelectElement> ();
		}
		
		public HtmlSelect Apply(Action<SelectElement> div)
		{
			div.Invoke (Element ());
			return this;
		}

		public void Load<T>(IList<T> data, Func<T, OptionElement> func)
		{
			Element().Load(data, func);
		}
		
		/// <summary>
		/// Selects the item.
		/// </summary>
		/// <returns>
		/// The selectec item.
		/// </returns>
		/// <param name='value'>
		/// Value.
		/// </param>
		public jQueryObject SelectItem(string value)
		{
			return Element().SelectOption(value);
			
		}


	}
}

