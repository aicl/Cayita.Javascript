using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Table<T>:TableAtom where T: Record, new()
	{
		[InlineCode("Cayita.UI.Table({T})()")]
		public Table ()
		{
		}

		[InlineCode("Cayita.UI.Table({T})({columns},{idProperty})")]
		public Table (List<TableColumn<T>> columns, string idProperty="Id")
		{
		}

		[InlineCode("Cayita.UI.Table({T})(null,{idProperty})")]
		public Table (string idProperty)
		{
		}

		[IntrinsicProperty]
		public List<TableColumn<T>> Columns { get ;  internal set; }

		[IntrinsicProperty]
		public string IdProperty{ get ;  internal set; }


		[IntrinsicProperty]
		public TableHead Head{ get ; internal set; }


		[IntrinsicProperty]
		public TableFoot Foot{ get ; internal set; }


		public TableRowAtom GetRowById(object id){
			return null;
		}


		public void AddRow( T data)
		{
		}

		public void UpdateRow( T data)
		{
		}

		public void RemoveRow( T data)
		{
		}

		public void RemoveRowById( object id)
		{
		}

		public void Load(IList<T> list, bool append =false)
		{
		}


	}
}

