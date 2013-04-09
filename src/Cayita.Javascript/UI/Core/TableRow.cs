using System;
using System.Html;

namespace Cayita.UI
{
	
	public class TableRow:ElementBase
	{
		public TableRow (Element parent,  Action<TableRowElement> element)
		{
			CreateElement("tr", parent);
			element(Element()); 
		}
		
		public TableRow (Element parent)
		{
			CreateElement("tr", parent);
		}
		
		public new TableRowElement Element()
		{
			return (TableRowElement) base.Element();
		}
		
	}
}

