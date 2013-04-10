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


		public Image (Element parent, Action<ImageElement> image)
		{
			CreateElement("img", parent);
			image(Element()); 
		}

		public new ImageElement Element()
		{
			return (ImageElement) base.Element();
		}

		public new Image Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			base.Append<T> (content);
			return this;
		}
		
		public Image Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}

		public Image Src(string url)
		{
			this.Element ().Src = url;
			return this;
		}

		public new Image ClassName(string className)
		{
			Element ().ClassName = className;
			return this;
		}
		
		public new Image RemoveClass(string className)
		{
			JQuery ().RemoveClass (className);
			return this;
		}
		
		public new Image AddClass(string className)
		{
			JQuery ().AddClass (className);
			return this;
		}


	}
}

