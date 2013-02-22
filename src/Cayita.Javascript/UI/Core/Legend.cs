using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public class Legend:ElementBase
	{

		public Legend(Element parent, Action<Element> element)
		{
			CreateElement("legend", parent);
			element(Element());
		}

		public Legend (Element parent)
		{
			CreateElement("legend", parent);
		}
		
				
		
	}
	
}
