using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class Image:ElementBase
	{
		public Image (Element parent, Action<ImageElement> image)
		{
			CreateElement("div", parent);
			image(Element()); 
		}

		public new ImageElement Element()
		{
			return (ImageElement) base.Element();
		}

	}
}

