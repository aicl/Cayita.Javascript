using System;
using System.Html;
namespace Cayita.UI
{
	public class Image:CayitaElement
	{
		public Image ():base("img")
		{
		}

		public Image(Action<ImageElement> img):this()
		{
			img.Invoke (Element ());
		}
		
		
		public new ImageElement Element()
		{
			return El.As<ImageElement> ();
		}

		public Image Src(string url)
		{
			this.Element ().Src = url;
			return this;
		}

	}
}

