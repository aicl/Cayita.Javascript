using System;
using System.Html;

namespace Cayita.UI
{

	public class Icon:ElementBase<Icon>
	{

		public Icon()
		{
			CreateElement("i",null);
		}

		public Icon(Action<IconElement> element)
		{
			CreateElement("i", null);
			element(Element());
		}

		public Icon(Element parent,  Action<IconElement> element)
		{
			CreateElement("i", parent);
			element(Element());
		}

		public Icon( Element parent)
		{
			CreateElement("i", parent);
		}

		public new  IconElement Element()
		{
			return (IconElement)base.Element();
		}


	}
}

