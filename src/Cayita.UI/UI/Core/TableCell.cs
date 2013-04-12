using System;
using System.Html;

namespace Cayita.UI
{

	public class TableCell:CayitaElement
	{
		public TableCell ():base("td")
		{
		}
		
		public TableCell(Action<TableCellElement> form):this()
		{
			form.Invoke (Element ());
		}
			
		public new TableCellElement Element()
		{
			return El.As<TableCellElement> ();
		}
			
	}
}