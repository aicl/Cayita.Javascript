using System;
using System.Html;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita.UI
{
	
	public class InputSelect:ElementBase<InputSelect>
	{
		protected InputSelect ()
		{
			Init (null);
		}

		public InputSelect (Element parent )
		{	
			Init(parent);
		}

		public InputSelect (Action<SelectElement> element )
		{	
			Init(null);
			element.Invoke(Element());
		}


		public InputSelect (Element parent,  Action<SelectElement> element )
		{	
			Init(parent);
			element.Invoke(Element());
		}
		
		protected void Init(Element parent)
		{
			CreateElement("select", parent);
		}
		
		public new SelectElement Element()
		{
			return  base.Element().As<SelectElement>();
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

/*
var miValue = $("#miSelectBox" ).val();
if (miValue >0)
    $("#miSelectBox option[value="+miValue+"]").attr("selected",true);

 */
