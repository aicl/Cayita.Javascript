using System;
using Cayita.JData;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class SearchBox<T>: Div where T: Record, new()
	{
		[InlineCode("Cayita.UI.SearchBox({T})({store}, {columns}, {config})")]
		public SearchBox (Store<T> store, List<TableColumn<T>> columns=null, SearchBoxConfig config=null) 
		{
		}

		[InlineCode("Cayita.UI.SearchBox({T})({store}, null, {config})")]
		public SearchBox (Store<T> store,  SearchBoxConfig config) 
		{
		}

		[IntrinsicProperty]
		public SearchBoxConfig Config{ get;   internal set; }

		[IntrinsicProperty]
		public Func<T,string,bool> LocalFilter{  get;set;}

		[IntrinsicProperty]
		public ButtonIcon SearchButton { get;  internal set; }
		[IntrinsicProperty]
		public ButtonIcon ResetButton { get;  internal set; }
		[IntrinsicProperty]
		public Div Body { get;  internal set; }

		public event Action<SearchBox<T> , TableRowAtom> RowSelected {
			[InlineCode("{this}.add_rowSelected({value})")]
			add{}
			[InlineCode("{this}.remove_rowSelected({value})")]
			remove{}
		}

		[IntrinsicProperty]
		public string IndexValue { get;  internal set; }

		[IntrinsicProperty]
		public string TextValue { get;  internal set; }

	}
}

