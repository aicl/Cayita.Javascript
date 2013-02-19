using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
		
	[ScriptNamespace("Cayita.UI")]
	public class HtmlTable:ElementBase
	{
		protected HtmlTable(){}

		public HtmlTable (Element parent,  Action<TableElement> element)
		{
			CreateElement("table", parent, new ElementConfig());
			element(Element()); 
		}
		
		public HtmlTable (Element parent)
		{
			CreateElement("table", parent, new ElementConfig());
		}
		
		public new TableElement Element()
		{
			return (TableElement) base.Element();
		}

	}

	[ScriptNamespace("Cayita.UI")]
	public class TableHeader:HtmlTable
	{
		public TableHeader (Element parent,  Action<TableElement> element)
		{
			CreateElement("thead", parent, new ElementConfig());
			element(Element()); 
		}
		
		public TableHeader (Element parent)
		{
			CreateElement("thead", parent, new ElementConfig());
		}
		
		public new TableElement Element()
		{
			return (TableElement) base.Element();
		}
		
	}
	
	[ScriptNamespace("Cayita.UI")]
	public class TableFooter:HtmlTable
	{
		public TableFooter (Element parent,  Action<TableElement> element)
		{
			CreateElement("tfoot", parent, new ElementConfig());
			element(Element()); 
		}
		
		public TableFooter (Element parent)
		{
			CreateElement("tfoot", parent, new ElementConfig());
		}
		
		public new TableElement Element()
		{
			return (TableElement) base.Element();
		}
		
	}



	[ScriptNamespace("Cayita.UI")]
	public class TableBody:ElementBase
	{
				 
		public TableBody(TableElement parent)
		{
			CreateElement("tbody", parent, new ElementConfig());
		}
	}

}

