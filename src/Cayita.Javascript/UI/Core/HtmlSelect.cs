using System;
using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class HtmlSelect:ElementBase
	{
		protected HtmlSelect (){}

		public HtmlSelect (Element parent )
		{	
			Init(parent);
		}

		public HtmlSelect (Element parent,  Action<SelectElement> element )
		{	
			Init(parent);
			element(Element());
		}
		
		protected void Init(Element parent)
		{
			CreateElement("select", parent, new ElementConfig());
		}
		
		public new SelectElement Element()
		{
			return (SelectElement) base.Element();
		}
		
		public void Load<T>(IList<T> data, Func<T, HtmlOption> func)
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
			return Element().SelectItem(value);

		}

	}
}

/*
var miValue = $("#miSelectBox" ).val();
if (miValue >0)
    $("#miSelectBox option[value="+miValue+"]").attr("selected",true);

 */
