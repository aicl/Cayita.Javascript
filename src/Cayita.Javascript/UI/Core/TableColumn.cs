using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.UI
{
	[Serializable]	
	public class TableColumn<T>
	{
		public TableColumn (){}

		public TableColumn( string index,string header=null, Action<T,TableCellElement> val =null, bool autoHeader=true  )
		{
			if (string.IsNullOrEmpty (header) && autoHeader) 
				header = index;

			if (!string.IsNullOrEmpty (header))
				Header = new  TableCell (c => c.Text (header)).Element ();

			if (val == null) 
				val = (t,c ) => c.SetValue(t.Get(index));

			Value = t => {
				var cell = new TableCell ().Element ();
				val.Invoke (t,cell );
				return cell;
			};

		}
		
		public TableCellElement Header { get; set; }
		
		public Func<T,TableCellElement> Value { get; set; }

		public TableCellElement Footer { get; set; }

		public bool Hidden { get; set; }

		public Action<T,TableRowElement> AfterCellCreate { get; set; }
	}
}

