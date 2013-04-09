using System;
using System.Runtime.CompilerServices;
using System.Html;


namespace Cayita.UI
{

	public class Icon:ElementBase
	{

		public Icon(Element parent,  Action<Element> element)
		{
			CreateElement("i", parent);
			element(Element());
		}

		public Icon( Element parent)
		{
			CreateElement("i", parent);
		}


	}
}

