using System;
using System.Html;

namespace Cayita.UI
{
	
	public class Form:ElementBase<Form>
	{

		public Form(Element parent, Action<FormElement> element)
		{
			CreateElement("form", parent);
			element(Element());
		}


		public Form (Element parent=null)
		{
			CreateElement("form", parent);
		}


		public new FormElement Element()
		{
			return (FormElement) base.Element();
		}

		public FormData FormData()
		{
			return new FormData(Element());
		}

	}
}
