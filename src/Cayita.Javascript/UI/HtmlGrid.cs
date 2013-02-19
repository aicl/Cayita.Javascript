using System;
using System.Linq;
using System.Html;
using System.Collections.Generic;
using Cayita.Javascript.Data;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	[Serializable]
	public class SelectedRow<T> : SelectedRow where T:new()
	{
		public SelectedRow()
		{
			Record= new T();
		}
		public T  Record {get;set;}
	}


	[ScriptNamespace("Cayita.UI")]
	public class HtmlGrid<T>:HtmlTable where T: new()
	{

		List<TableColumn<T>> columns;
		Store<T> store ;
		TableElement table;
		SelectedRow<T> selectedrow;

		public HtmlGrid (Element parent,  Action<TableElement> element, Store<T> store, List<TableColumn<T>> columns)
		{
			OnRowSelected=(grid,row)=>{};

			CreateElement("table", parent, new ElementConfig());
			table =Element();
			table.ClassName = "table table-striped table-hover table-condensed";
			table.SetAttribute ("data-provides", "rowlink");
			element(table); 
			this.columns= columns;
			this.store= store;

			table.JSelect().On ("click","tbody tr", e =>  { 
				var row = (TableRowElement)e.CurrentTarget;
				SelectRowImp(row, true);
			});

			Render();

			store.OnStoreChanged+=(st, dt)=>{
				switch(dt.Action)
				{
				case StoreChangedAction.Created:
					table.CreateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Read:
					Cayita.Javascript.Firebug.Console.Log("HtmlGrid: cargando filas en el grid 1 ", store, store.Count);
					table.Load(store, columns, store.GetRecordIdProperty());
					SelectRow(true);
					break;
				case StoreChangedAction.Updated:
					table.UpdateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Destroyed:
					var recordId = ((dynamic) dt.OldData)[store.GetRecordIdProperty()];
					table.JSelectRow((object)recordId).Remove();
					SelectRow(true);
					break;
				case StoreChangedAction.Patched:
					table.UpdateRow(dt.NewData, columns, store.GetRecordIdProperty());
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
					var id = ((dynamic) dt.OldData)[store.GetRecordIdProperty()];
					table.JSelectRow((object)id).Remove();
					SelectRow(true);
					break;
				case StoreChangedAction.Loaded:
					table.Load(store,columns, store.GetRecordIdProperty());
					SelectRow(true);
					break;
				case StoreChangedAction.Cleared:
					table.tBodies[0].JSelect().Empty();
					SelectRow(true);
					break;
				}

			};

		}

		public SelectedRow<T> GetSelectedRow()
		{
			return selectedrow;
		}

		public void Render()
		{
			table.CreateHeader(columns);
			table.Load<T>(store, columns, store.GetRecordIdProperty());
		}


		public void SelectRow(object recordId, bool trigger =true)
		{
			var row = (TableRowElement) table.JSelectRow(recordId).GetElement(0);
			SelectRowImp(row, trigger);
		}

		public void SelectRow(bool trigger =true)
		{
			table.JSelectRows().RemoveClass ("info");
			selectedrow=default(SelectedRow<T>);
			if(trigger) OnRowSelected(this, selectedrow);
		}

		void SelectRowImp(TableRowElement row, bool trigger=true)
		{
			var self= this;
			table.JSelectRows().RemoveClass ("info");
			row.JSelect ().AddClass ("info");
			var record = store.First (f =>((object)((dynamic) f)[self.store.GetRecordIdProperty()]).ToString() == row.GetRecordId());
			selectedrow= new SelectedRow<T>{ RecordId= row.GetRecordId(), Row= row, Record= record};
			if(trigger) OnRowSelected(this, selectedrow);
		}

		/// <summary>
		/// Hides the column.
		/// </summary>
		/// <param name='columnIndex'>
		/// Column index ( zero based)
		/// </param>
		public void HideColumn(int columnIndex)
		{
			columns[columnIndex++].Hidden=true;
			table.JSelect().Find ("td:nth-child("+columnIndex+"),th:nth-child("+columnIndex+")").Hide();
		}
	
		/// <summary>
		/// Shows the column.
		/// </summary>
		/// <param name='columnIndex'>
		/// Column index. (zero based)
		/// </param>
		public void ShowColumn(int columnIndex)
		{
			columns[columnIndex++].Hidden=false;
			table.JSelect().Find ("td:nth-child("+columnIndex+"),th:nth-child("+columnIndex+")").Show();
		}

		public event Action<HtmlGrid<T> ,SelectedRow<T>> OnRowSelected;

	}
}

