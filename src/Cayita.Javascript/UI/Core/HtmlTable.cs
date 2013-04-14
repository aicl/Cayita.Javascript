using System;
using System.Html;

namespace Cayita.UI
{
		
	public class HtmlTable:ElementBase
	{
		protected HtmlTable(){}

		public HtmlTable (Element parent,  Action<TableElement> element)
		{
			CreateElement("table", parent);
			element(Element()); 
		}
		
		public HtmlTable (Element parent)
		{
			CreateElement("table", parent);
		}
		
		public new TableElement Element()
		{
			return (TableElement) base.Element();
		}

		public HtmlTable (Action<TableElement> element)
		{
			CreateElement("table",null);
			element(Element()); 
		}

	}

	public class TableHeader:HtmlTable
	{
		public TableHeader (Element parent,  Action<TableElement> element)
		{
			CreateElement("thead", parent);
			element(Element()); 
		}
		
		public TableHeader (Element parent)
		{
			CreateElement("thead", parent);
		}
		
		public new TableElement Element()
		{
			return (TableElement) base.Element();
		}
		
	}
	
	public class TableFooter:HtmlTable
	{
		public TableFooter (Element parent,  Action<TableElement> element)
		{
			CreateElement("tfoot", parent);
			element(Element()); 
		}
		
		public TableFooter (Element parent)
		{
			CreateElement("tfoot", parent);
		}
		
		public new TableElement Element()
		{
			return (TableElement) base.Element();
		}
		
	}



	public class TableBody:ElementBase
	{				 
		public TableBody(TableElement parent)
		{
			CreateElement("tbody", parent);
		}
	}

}