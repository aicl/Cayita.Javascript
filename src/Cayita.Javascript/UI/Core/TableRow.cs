using System;
using System.Html;

namespace Cayita.UI
{
	
	public class TableRow:ElementBase<TableRow>
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
			return  base.Element().As<TableRowElement>();
		}
		
	}
}

