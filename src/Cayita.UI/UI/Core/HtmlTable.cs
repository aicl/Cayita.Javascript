using System;
using System.Html;

namespace Cayita.UI
{
	public class HtmlTable:CayitaElement
	{
		public HtmlTable ():base("table")
		{
		}

		public HtmlTable(Action<TableElement> table):this()
		{
			table.Invoke (Element ());
		}
		
		
		public new TableElement Element()
		{
			return El.As<TableElement> ();
		}
	}


	public class TableHeader:CayitaElement
	{
		public TableHeader ():base("thead")
		{
		}
		
		public TableHeader(Action<TableElement> table):this()
		{
			table.Invoke (Element ());
		}
		
		
		public new TableElement Element()
		{
			return El.As<TableElement> ();
		}	
	}

	public class TableFooter:CayitaElement
	{
		public TableFooter ():base("tfoot")
		{
		}
		
		public TableFooter(Action<TableElement> table):this()
		{
			table.Invoke (Element ());
		}
		
		
		public new TableElement Element()
		{
			return El.As<TableElement> ();
		}	
	}


	public class TableBody:CayitaElement
	{
		public TableBody ():base("tfoot")
		{
		}
		
	}


}

