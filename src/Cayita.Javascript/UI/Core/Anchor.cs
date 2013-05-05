using System;
using System.Html;

namespace Cayita.UI
{

	public class Anchor:ElementBase<Anchor>
	{
	
		public Anchor()
		{
			Init (null);
		}

		public Anchor(Action<AnchorElement> element)
		{
			Init(null);
			element.Invoke(Element()); 
		}


		public Anchor(Element parent,  Action<AnchorElement> element)
		{
			Init(parent);
			element.Invoke(Element());
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

