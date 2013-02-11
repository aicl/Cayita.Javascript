using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class TableCell:ElementBase
	{
		public TableCell (TableRowElement parent,  Action<TableCellElement> element)
		{
			CreateElement("td", parent, new ElementConfig());
			element(Element()); 
		}
		
		public TableCell (TableRowElement parent)
		{
			CreateElement("td", parent, new ElementConfig());
		}

		public TableCell ()
		{
			CreateElement("td", default(Element), new ElementConfig());
		}

		public TableCell (Action<TableCellElement> element)
		{
			CreateElement("td", default(Element), new ElementConfig());
			element(Element()); 
		}

		public new TableCellElement Element()
		{
			return (TableCellElement) base.Element();
		}
		
	}
}

