using System.Html;
using System;

[Serializable]	
public class TableColumn<T>
{
	public TableColumn (){}
	
	public TableCellElement Header { get; set; }
	
	public Func<T,TableCellElement> Value { get; set; }
	
	public TableCellElement Footer { get; set; }
	
	public bool Hidden { get; set; }
	
	public Action<T,TableRowElement> AfterCellCreate { get; set; }
}
