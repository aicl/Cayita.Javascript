using System;
using System.Runtime.CompilerServices;
using Cayita.JData;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Grid<T>:Table<T> where T: Record, new()
	{
		[InlineCode("Cayita.UI.Grid({T})({store},{columns})")]
		public Grid (Store<T> store, List<TableColumn<T>> columns=null)
		{
		}

		[IntrinsicProperty]
		public Store<T> Store { get;  internal set; }

		[IntrinsicProperty]
		public TableRowAtom SelectedRow { get;  internal set; }

		public  bool Multiple  { 
			[InlineCode("{this}.is_multiple()")] 
			get; 
			[InlineCode("{this}.multiple({value})")] 
			set; 
		}

		[IntrinsicProperty]
		public Func<Grid<T>, Atom> ReadRequestStarted {  get; internal set;}
		[IntrinsicProperty]
		public Action<Grid<T>, Atom> ReadRequestFinished  { get;  internal set; }
		[IntrinsicProperty]
		public GridRequestMessage ReadRequestMessage  { get; internal set;}

		[IntrinsicProperty]
		internal  List<int> NavKeys { get; set; }

		public TableRowAtom[] GetSelected(){
			return null;
		}

		[InlineCode("{this}.selectRow({id},{trigger})")]
		public void Select(object id, bool trigger=true){
		}

		[InlineCode("{this}.deselectRow({id},{trigger})")]
		public void DeSelect(object id, bool trigger=true){
		}

		public void ClearSelection(){
		}

		public event Action<Grid<T> , TableRowAtom> RowClicked {
			[InlineCode("{this}.add_rowClicked({value})")]
			add{}
			[InlineCode("{this}.remove_rowClicked({value})")]
			remove{}
		}

		public event Action<Grid<T> , TableRowAtom> RowSelected {
			[InlineCode("{this}.add_rowSelected({value})")]
			add{}
			[InlineCode("{this}.remove_rowSelected({value})")]
			remove{}
		}

		public event Action<Grid<T> ,jQueryEvent> KeyDown {
			[InlineCode("{this}.add_keydown({value})")]
			add{}
			[InlineCode("{this}.remove_keydown({value})")]
			remove{}
		}
	}
}
