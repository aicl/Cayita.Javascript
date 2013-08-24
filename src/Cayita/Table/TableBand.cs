using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class TableBand:Atom
	{
		protected TableBand ()
		{
		}

		[InlineCode("{this}.insertRow({index})")]
		public TableRowAtom InsertRow(int index =-1){
			return null;
		}

		[InlineCode("{this}.addRow({row})")]
		public void AddRow(TableRowAtom row){
		}

		[InlineCode("{this}.deleteRow({index})")]
		public void DeleteRow (int index=-1)
		{
		}
	}
}

