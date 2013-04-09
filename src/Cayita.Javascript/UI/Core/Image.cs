using System;
using System.Html;

namespace Cayita.UI
{
	public class Image:ElementBase
	{
		public Image (Element parent, Action<ImageElement> image)
		{
			CreateElement("img", parent);
			image(Element()); 
		}

		public new ImageElement Element()
		{
			return (ImageElement) base.Element();
		}

	}
}

