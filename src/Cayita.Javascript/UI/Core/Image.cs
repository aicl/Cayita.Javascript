using System;
using System.Html;

namespace Cayita.UI
{
	public class Image:ElementBase
	{
		public Image ()
		{
			CreateElement("img", null);
		}

		public Image ( Action<ImageElement> image)
		{
			CreateElement("img", null);
			image(Element()); 
		}


		public Image (Element parent, Action<ImageElement> image)
		{
			CreateElement("img", parent);
			image(Element()); 
		}

		public new ImageElement Element()
		{
			return (ImageElement) base.Element();
		}


		public Image Src(string url)
		{
			this.Element ().Src = url;
			return this;
		}




	}
}

