using System;
using System.Runtime.CompilerServices;
using System.Html;
using System.Collections.Generic;

namespace Cayita.UI
{
	[Serializable]	
	public class TableColumn<T> where T:new()
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

		public static List<TableColumn<T>> BuildColumns(bool autoHeader=true)
		{
			List<TableColumn<T>> cols = new List<TableColumn<T>> ();
			var o = new T ();
			var props= o.GetProperties ();
			foreach (var p in props) {
				cols.Add( new TableColumn<T>(p,autoHeader:autoHeader));
			}
			
			return cols;
		}

	}
}

