using System;
using System.Linq;
using System.Html;
using System.Collections.Generic;
using Cayita.Javascript.Data;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	[Serializable]
	public class SelectedGridRow<T> : SelectedRow
	{
		public T  Record {get;set;}

	}

	[ScriptNamespace("Cayita.UI")]
	[Serializable]
	public class HtmlGrid<T>:HtmlTable where T: new()
	{
		List<TableColumn<T>> columns;
		Store<T> store ;
		TableElement table;
		SelectedGridRow<T> selectedrow;

		public HtmlGrid (Element parent,  Action<TableElement> element, Store<T> store, List<TableColumn<T>> columns)
		{
			CreateElement("table", parent, new ElementConfig());
			table =Element();
			table.ClassName = "table table-striped table-hover table-condensed";
			table.SetAttribute ("data-provides", "rowlink");
			element(table); 
			this.columns= columns;
			this.store= store;

			table.JSelect().On ("click","tbody tr", e =>  { 
				var row = (TableRowElement)e.CurrentTarget;
				table.JSelectRows().RemoveClass ("info");
				row.JSelect ().AddClass ("info");
				var record = this.store.First (f =>((object)((dynamic) f)[store.GetRecordIdProperty()]).ToString() == row.GetRecordId());
				selectedrow= new SelectedGridRow<T>{ RecordId= row.GetRecordId(), Row= row, Record= record};
				jQuery.FromElement(table).Trigger("rowselected", new object[]{selectedrow} );
			});

			Render();



			store.OnStoreChanged+=(st, dt)=>{
				switch(dt.Action)
				{
				case StoreChangedAction.Read:
					Cayita.Javascript.Firebug.Console.Log("HtmlGrid: cargando filas en el grid 1 ", store, store.Count);
					table.Load(store, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Added:
					table.CreateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Replaced:
					table.UpdateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Inserted:
					table.CreateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Removed:
					var index = ((dynamic) dt.OldData)[store.GetRecordIdProperty()];
					table.JSelectRow((object)index).Remove();
					break;
				case StoreChangedAction.Cleared:
					table.tBodies[0].JSelect().Empty();
					break;
				}

			};

		}


		public SelectedGridRow<T> GetSelectedRow()
		{
			return selectedrow;
		}

		public void Render()
		{
			table.CreateHeader(columns);
			table.Load<T>(store, columns, store.GetRecordIdProperty());
		}


	}
}

