using System;
using System.Html;

namespace Cayita.UI
{
	public class TableRow:CayitaElement
	{
		public TableRow ():base("tr")
		{
		}

		public TableRow(Action<TableRowElement> row):this()
		{
			row.Invoke (Element ());
		}
		
		
		public new TableRowElement Element()
		{
			return El.As<TableRowElement> ();
		}

	}
}

