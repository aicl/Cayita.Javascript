using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public class Form:ElementBase
	{

		public Form(Element parent, Action<FormElement> element)
		{
			CreateElement("form", parent);
			element(Element());
		}


		public Form (Element parent)
		{
			CreateElement("form", parent);
		}


		public new FormElement Element()
		{
			return (FormElement) base.Element();
		}

	}
}

