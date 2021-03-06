using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TableCellAtom:Atom
	{
		[InlineCode("Cayita.UI.TableCellAtom()")]
		public TableCellAtom ()
		{
		}

		[InlineCode("Cayita.UI.TableCellAtom(null, {action})")]
		public TableCellAtom (Action<TableCellAtom> action)
		{
		}

		public object Value {
			[InlineCode("{this}.get_value()")]	get;
			[InlineCode("{this}.set_value({value})")] set;
		}


		public Action<TableCellAtom,object>  SetValueFn {
			[InlineCode("{this}.set_setValueFn({value})")] set{}
		}


		public  Func<TableCellAtom,object>  GetValueFn{
			[InlineCode("{this}.set_getValueFn({value})")] set{}
		}

		[IntrinsicProperty]
		public int CellIndex
		{
			get;
			set;
		}
		[IntrinsicProperty]
		public int ColSpan {
			get;
			set;
		}
		[IntrinsicProperty]
		public bool NoWrap
		{
			get;
			set;
		}
		[IntrinsicProperty]
		public int RowSpan
		{
			get;
			set;
		}

	}
}

