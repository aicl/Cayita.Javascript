using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.UI
{
	public class HtmlOption:ElementBase<HtmlOption>
	{

		public HtmlOption ( Action<OptionElement> element )
		{
			Init(null);
			element.Invoke(Element());
		}

		public HtmlOption (SelectElement parent,  Action<OptionElement> element )
		{
			Init(parent);
			element.Invoke(Element());
		}

		void Init(Element parent)
		{
			CreateElement("option", parent);
		}

		public new OptionElement Element()
		{
			return  base.Element ().As<OptionElement> ();
		}

	}
}

