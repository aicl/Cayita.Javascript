using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class TableRow:ElementBase
	{
		public TableRow (Element parent,  Action<TableRowElement> element)
		{
			CreateElement("tr", parent, new ElementConfig());
			element(Element()); 
		}
		
		public TableRow (Element parent)
		{
			CreateElement("tr", parent, new ElementConfig());
		}
		
		public new TableRowElement Element()
		{
			return (TableRowElement) base.Element();
		}
		
	}
}

