using System;
using System.Html;

namespace Cayita.UI
{

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


	public class FieldSet:ElementBase
	{
		
		public FieldSet(Element parent, Action<Element> element)
		{
			CreateElement("fieldset", parent);
			element(Element());
		}
		
		public FieldSet (Element parent)
		{
			CreateElement("fieldset", parent);
		}
		
	}
	
}