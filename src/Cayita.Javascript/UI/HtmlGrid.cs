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
	[Serializable]
	public class RequestMessage
	{
		public  RequestMessage(){}
		public Element Target{get;set;}
		public string Message {get;set;}
		protected internal Element HtmlElement {get;set;}
	}

	[ScriptNamespace("Cayita.UI")]
	public class HtmlGrid<T>:HtmlTable where T: new()
	{

		List<TableColumn<T>> columns;
		Store<T> store ;
		TableElement table;
		SelectedRow<T> selectedrow;
		Func<HtmlGrid<T>, Element> readRequestStarted;
		Action<HtmlGrid<T>, Element> readRequestFinished;
		RequestMessage readRequestMessage;

		protected HtmlGrid (Element parent)
		{
			Init (parent, new Store<T>(), new List<TableColumn<T>>() );
		}

		public HtmlGrid (Element parent,  Store<T> store, List<TableColumn<T>> columns)
		{

			Init(parent, store, columns);

		}

		private void Init(Element parent,  Store<T> datastore, List<TableColumn<T>> tablecolumns )
		{
			CreateElement("table", parent);
			table =Element();
			table.ClassName = "table table-striped table-hover table-condensed";
			table.SetAttribute ("data-provides", "rowlink");
			columns= tablecolumns;
			store= datastore;
			
			OnRowSelected=(grid,row)=>{};
			table.OnClick("tbody tr", e =>  { 
				var row = (TableRowElement)e.CurrentTarget;
				SelectRowImp(row, true);
			}); 
			
			Render();
			
			readRequestMessage= new RequestMessage{Target=table.tBodies[0], Message="Reading " + typeof(T).Name };
			
			readRequestStarted=(grid)=>{
				var sp = new SpinnerIcon((div, icon)=>{
					div.Style.Position="fixed";
					div.Style.ZIndex=10000;
					div.Style.Opacity="0.7";
					div.Style.Height= (grid.table.ClientHeight+30).ToString()+ "px";
					div.Style.Width= grid.table.ClientWidth.ToString()+ "px";
				},readRequestMessage.Message);
				readRequestMessage.Target.Append(sp.Element());
				return sp.Element();
			};
			
			readRequestFinished= (grid, el)=>{
				el.Remove();
			};
			
			
			store.OnStoreChanged+=(st, dt)=>{
				switch(dt.Action)
				{
				case StoreChangedAction.Created:
					table.CreateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Loaded:
				case StoreChangedAction.Read:
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
				case StoreChangedAction.Cleared:
					table.tBodies[0].Empty();
					SelectRow(true);
					break;
				}
			};
			
			store.OnStoreRequest+=(st, request)=>{
				switch (request.Action) {
				case StoreRequestAction.Create:
					break;
				case StoreRequestAction.Read:
					if(request.State== StoreRequestState.Started)
					{
						readRequestMessage.HtmlElement= readRequestStarted(this);
					}
					else
					{
						readRequestFinished(this, readRequestMessage.HtmlElement);
					}
					break;
				case StoreRequestAction.Update:
					break;
				case StoreRequestAction.Destroy:
					break;
				case StoreRequestAction.Patch:
					
					break;
				}
				
			};
		}

		public Store<T> GetStore()
		{
			return store;
		}


		public HtmlGrid<T> SetReadRequestMessage(Action<RequestMessage> message)
		{
			message(readRequestMessage);
			return this;
		}

		public SelectedRow<T> GetSelectedRow()
		{
			return selectedrow;
		}

		public void Render()
		{
			table.CreateHeader(columns);
			//table.Load<T>(store, columns, store.GetRecordIdProperty());
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
			row.JQuery ().AddClass ("info");
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
			table.JQuery().Find ("td:nth-child("+columnIndex+"),th:nth-child("+columnIndex+")").Hide();
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
			table.JQuery().Find ("td:nth-child("+columnIndex+"),th:nth-child("+columnIndex+")").Show();
		}

		public event Action<HtmlGrid<T> ,SelectedRow<T>> OnRowSelected;

	}
}

