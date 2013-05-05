using System;
using System.Html;

namespace Cayita.UI
{
		
	public class HtmlTable:ElementBase<HtmlTable>
	{
		protected HtmlTable(){}

		public HtmlTable (Element parent,  Action<TableElement> element)
		{
			CreateElement("table", parent);
			element.Invoke(Element()); 
		}
		
		public HtmlTable (Element parent)
		{
			CreateElement("table", parent);
		}
		
		public new TableElement Element()
		{
			return base.Element().As<TableElement>();
		}

		public HtmlTable (Action<TableElement> element)
		{
			CreateElement("table",null);
			element.Invoke(Element()); 
		}

	}

	public class TableHeader:HtmlTable
	{
		public TableHeader (Element parent,  Action<TableElement> element)
		{
			CreateElement("thead", parent);
			element.Invoke(Element()); 
		}
		
		public TableHeader (Element parent)
		{
			CreateElement("thead", parent);
		}
		
				
	}
	
	public class TableFooter:HtmlTable
	{
		public TableFooter (Element parent,  Action<TableElement> element)
		{
			CreateElement("tfoot", parent);
			element.Invoke(Element()); 
		}
		
		public TableFooter (Element parent)
		{
			CreateElement("tfoot", parent);
		}

		
	}



	public class TableBody:ElementBase<TableBody>
	{				 
		public TableBody(TableElement parent)
		{
			CreateElement("tbody", parent);
		}
	}

}