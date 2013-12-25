using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class TableColumn<T> where T:new()
	{
		[InlineCode("Cayita.UI.TableColumn({T})()")]
		public TableColumn()
		{
		}

		[InlineCode("Cayita.UI.TableColumn({T})({index},{header},{val},{autoHeader})")]
		public TableColumn( string index,string header=null,
		                   Action<T,TableCellAtom> val =null, bool autoHeader=true  )
		{
		}

		[InlineCode("Cayita.UI.TableColumn({T})(null,null,{val},false, {header})")]
		public TableColumn( Action<T,TableCellAtom> val , Action<TableCellAtom> header )
		{
		}

		[IntrinsicProperty]
		public TableCellAtom Header { get; set; }

		[IntrinsicProperty]
		public Func<T,TableCellAtom> Value { get; set; }

		[IntrinsicProperty]
		public TableCellAtom Footer { get; set; }

		[IntrinsicProperty]
		public bool Hidden { get; set; }

		[IntrinsicProperty]
		public Action<T,TableRowAtom> AfterCellCreated { get; set; }

		[InlineCode("Cayita.UI.BuildColumns({T})({autoHeader})")]
		public static List<TableColumn<T>> BuildColumns(bool autoHeader=true)
		{
			return null;
		}

	}
}

