using System;
using System.Html;

namespace Cayita.UI
{

	public class Anchor:ElementBase
	{
	
		public Anchor()
		{
			Init (null);
		}


		public Anchor(Element parent,  Action<AnchorElement> element)
		{
			Init(parent);
			element(Element());
		}

		public Anchor  (Element parent)	
		{
			Init(parent);
		}
		
		void Init(Element parent)
		{
			CreateElement("a", parent);
			Element().Href="#";
		}
		
		public new AnchorElement Element()
		{
			return (AnchorElement) base.Element();
		}

		public Anchor Href(string url)
		{
			this.Element ().Href = url;
			return this;
		}
				
	}
}

