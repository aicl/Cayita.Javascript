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

		public Anchor(Action<AnchorElement> element)
		{
			Init(null);
			element(Element());
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

		public new Anchor ClassName(string className)
		{
			Element ().ClassName = className;
			return this;
		}
		
		public new Anchor RemoveClass(string className)
		{
			JQuery ().RemoveClass (className);
			return this;
		}
		
		public new Anchor AddClass(string className)
		{
			JQuery ().AddClass (className);
			return this;
		}
				
	}
}

