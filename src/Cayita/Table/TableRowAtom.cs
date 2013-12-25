using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TableRowAtom:Atom
	{
		[InlineCode("Cayita.UI.TableRowAtom()")]
		public TableRowAtom ()
		{
		}

		[InlineCode("Cayita.UI.TableRowAtom(null, {action})")]
		public TableRowAtom ( Action<TableRowAtom> action )
		{
		}

		[IntrinsicProperty]
		public ElementCollection Cells
		{
			get	{ return null;}
		}
		[IntrinsicProperty]
		public int RowIndex
		{
			get	{ return 0;}
		}
		[IntrinsicProperty]
		public int SectionRowIndex
		{
			get	{ return 0;}
		}
		//
		// Methods
		//

		public void DeleteCell (int index=-1)
		{
		}


		public TableCellAtom InsertCell (int index=-1)
		{
			return null;
		}

		public string RecordId {
			get;
			internal set;
		}



		public TableCellAtom GetFirstCell()
		{
			return null;
		}


		public TableCellAtom GetLastCell()
		{
			return null;
		}


		public TableCellAtom GetCellByIndex(int index)
		{
			return null;
		}
	

		public void AddCell(TableCellAtom cell){
		}


	}
}

