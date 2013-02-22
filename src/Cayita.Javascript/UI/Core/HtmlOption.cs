using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class HtmlOption:ElementBase
	{

		public HtmlOption ( Action<OptionElement> element )
		{
			Init(default(Element));
			element(Element());
		}

		public HtmlOption (SelectElement parent,  Action<OptionElement> element )
		{
			Init(parent);
			element(Element());
		}

		void Init(Element parent)
		{
			CreateElement("option", parent);
		}

		public new OptionElement Element()
		{
			return (OptionElement) base.Element();
		}


	}
}

