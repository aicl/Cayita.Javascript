using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class Anchor:ElementBase
	{
	
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
				
	}
}

