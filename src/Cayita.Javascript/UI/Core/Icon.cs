using System;
using System.Runtime.CompilerServices;
using System.Html;


namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class Icon:ElementBase
	{

		public Icon(Element parent,  Action<Element> element)
		{
			CreateElement("i", parent, new ElementConfig());
			element(Element());
		}

		public Icon( Element parent)
		{
			CreateElement("i", parent, new ElementConfig());
		}


	}
}

