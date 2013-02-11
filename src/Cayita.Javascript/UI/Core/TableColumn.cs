using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class TableColumn<T>
	{
		public TableColumn (){}
		
		public TableCellElement Header {get;set;}
		
		public Func<T,TableCellElement> Value {get;set;}

		public TableCellElement Footer {get;set;}

	}
}

