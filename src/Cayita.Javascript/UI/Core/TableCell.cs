using System;
using System.Html;

namespace Cayita.UI
{

	public class TableCell:ElementBase<TableCell>
	{
		public TableCell (TableRowElement parent,  Action<TableCellElement> element)
		{
			CreateElement("td", parent);
			element.Invoke(Element()); 
		}
		
		public TableCell (TableRowElement parent)
		{
			CreateElement("td", parent);
		}

		public TableCell ()
		{
			CreateElement("td", default(Element));
		}

		public TableCell (Action<TableCellElement> element)
		{
			CreateElement("td", default(Element));
			element.Invoke(Element()); 
		}

		public new TableCellElement Element()
		{
			return base.Element().As<TableCellElement>();
		}
		
	}
}

