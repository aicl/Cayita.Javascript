using System;
using System.Html;

namespace Cayita.UI
{
		
	public class HtmlTable:HtmlTableBase<HtmlTable>
	{
		protected HtmlTable(){}
		
		public HtmlTable (Element parent,  Action<TableElement> element):base(parent,element,"table")
		{
		}
		
		public HtmlTable (Element parent):base(parent,"table")
		{
		}

		public HtmlTable (Action<TableElement> element):base(element,"table")
		{
		}

	}


	public abstract class HtmlTableBase<T>:ElementBase<T> where T:ElementBase
	{
		protected HtmlTableBase(){}

		public HtmlTableBase (Element parent,  Action<TableElement> element, string tagname)
		{
			CreateElement(tagname, parent);
			element.Invoke(Element()); 
		}
		
		public HtmlTableBase (Element parent, string tagname)
		{
			CreateElement(tagname, parent);
		}

		public HtmlTableBase (Action<TableElement> element, string tagname)
		{
			CreateElement(tagname,null);
			element.Invoke(Element()); 
		}

		public new TableElement Element()
		{
			return base.Element().As<TableElement>();
		}

	}

	public class TableHeader:HtmlTableBase<TableHeader>
	{
		public TableHeader (Element parent,  Action<TableElement> element):base(parent,element,"thead")
		{
		}
		
		public TableHeader (Element parent):base(parent, "thead")
		{
		}
		
				
	}
	
	public class TableFooter:HtmlTableBase<TableFooter>
	{
		public TableFooter (Element parent,  Action<TableElement> element):base(parent,"tfoot")
		{
		}
		
		public TableFooter (Element parent):base(parent,"tfoot")
		{
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