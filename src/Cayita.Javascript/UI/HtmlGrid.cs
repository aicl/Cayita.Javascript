using System;
using System.Linq;
using System.Html;
using System.Collections.Generic;
using Cayita.Data;
using jQueryApi;

namespace Cayita.UI
{

	[Serializable]
	public class SelectedRow<T> : SelectedRow where T:new()
	{
		public SelectedRow()
		{
			Record= new T();
		}
		public T  Record { get; set; }
	}

	[Serializable]
	public class ClickedRow<T>: SelectedRow<T> where T:new()
	{
	}

	[Serializable]
	public class RequestMessage
	{
		public  RequestMessage(){}
		public Element Target{ get; set; }
		public string Message { get; set; }
		protected internal Element HtmlElement { get; set; }
	}

	public class HtmlGrid<T>:HtmlTable where T: new()
	{

		List<TableColumn<T>> columns;
		Store<T> store ;
		TableElement table;
		ClickedRow<T> selectedrow;
		Func<HtmlGrid<T>, Element> readRequestStarted;
		Action<HtmlGrid<T>, Element> readRequestFinished;
		RequestMessage readRequestMessage;

		readonly List<int>  nvkeys= new List<int>(){33, 34,  35, 36, 38, 40 };
		// page_up, page_down, end, home, up, donw

		protected HtmlGrid (Element parent)
		{
			Init (parent, new Store<T>()  );
		}

		public HtmlGrid (Element parent,  Store<T> store, List<TableColumn<T>> columns=null)
		{
			Init(parent, store, columns);
		}


		private void Init(Element parent,  Store<T> datastore, List<TableColumn<T>> cols=null )
		{
			CreateElement("table", parent);
			table =Element();
			table.TabIndex = -1;
			table.ClassName = "table table-striped table-hover table-condensed";
			table.SetAttribute ("data-provides", "rowlink");
			columns = cols ?? TableColumn<T>.BuildColumns (true);
			store= datastore;
			
			OnRowSelected = (grid,row) => {};
			OnRowClicked = (grid,row) => {};
			OnKey = (grid, evt) => {};

			table.OnClick("tbody tr", e =>  { 
				var row = (TableRowElement)e.CurrentTarget;
				SelectRowImp(row, true,true);
			}); 

			table.JQuery ().Keydown (evt => KeydownHandler (evt));

			table.CreateHeader(columns);
			
			readRequestMessage= new RequestMessage{Target=table, Message="Reading " + typeof(T).Name };
			
			readRequestStarted=(grid)=>{
				var sp = new SpinnerIcon((div, icon)=>{
					div.Style.Position="fixed";
					div.Style.ZIndex=10000;
					div.Style.Opacity="0.6";
					div.Style.Height= "90%";
					div.Style.Width= "77%";
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
				case StoreChangedAction.Filtered:
				case StoreChangedAction.Loaded:
				case StoreChangedAction.Read:
					table.Load(store, columns, store.GetRecordIdProperty());
					SelectRow(true);
					break;
				case StoreChangedAction.Updated:
					table.UpdateRow(dt.NewData, columns, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Destroyed:
					var recordId = dt.OldData.Get(store.GetRecordIdProperty());
					table.GetRow(recordId).Remove();
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
					var id = dt.OldData.Get(store.GetRecordIdProperty());
					table.GetRow(id).Remove();
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

		protected virtual void NavKeyHandler (jQueryEvent evt)
		{

			evt.PreventDefault();
			switch(evt.Which)
			{
			case 34: //page_down
				store.ReadNextPage();
				break;
			case 33: //page_up
				store.ReadPreviousPage();
				break;
			case 35: // end
				break;
			case 36: // home
				break;
			case 38: //up
				PreviousRow();
				break;
			case 40: 
				NextRow();
				break;
			default:	
				break;
			}

		}

		protected  virtual void KeydownHandler(jQueryEvent evt)
		{
			if (nvkeys.Contains (evt.Which)) {
				NavKeyHandler (evt);
				return ;
			}
			OnKey (this, evt);

		}

		public void NextRow()
		{
			TableRowElement row;
			if (selectedrow == null) {
				var jfr = table.GetFirstRow ();
				if (jfr.Length == 0)
					return;
				row = jfr.GetElement (0).As<TableRowElement> ();

			} else {
				row =selectedrow.Row.NextSibling.As<TableRowElement> ();
				if(row==null) 
					store.ReadNextPage();

			}
			SelectRowImp (row, true, false);
		}

		public void PreviousRow()
		{

			TableRowElement row;
			if (selectedrow == null) {
				var jfr = table.GetLastRow ();
				if (jfr.Length == 0)
					return;
				row = jfr.GetElement (0).As<TableRowElement> ();
				
			} else {
				row =selectedrow.Row.PreviousSibling.As<TableRowElement> ();
				if (row==null) 
					if(row==null) store.ReadPreviousPage();
				
			}
			SelectRowImp (row, true, false);
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
			table.Load<T>(store, columns, store.GetRecordIdProperty());
			SelectRow(true);
		}

		public void SelectRow(object recordId, bool trigger =true)
		{
			var row = (TableRowElement) table.GetRow(recordId).GetElement(0);
			SelectRowImp(row, trigger,false);
		}

		public void SelectRow(bool trigger =true)
		{
			table.GetRows().RemoveClass ("info");
			selectedrow=default(ClickedRow<T>);
			if(trigger) OnRowSelected(this, selectedrow);
		}

		void SelectRowImp(TableRowElement row, bool triggerSelected=true, bool triggerClicked=false)
		{
			if (row == null)
				return;

			var self= this;
			table.GetRows().RemoveClass ("info");
			row.JQuery ().AddClass ("info");
			var record = store.First (f => f.Get(self.store.GetRecordIdProperty()).ToString() == row.GetRecordId());
			selectedrow= new ClickedRow<T>{ RecordId= row.GetRecordId(), Row= row, Record= record};
			if(triggerClicked) OnRowClicked(this, selectedrow);
			if(triggerSelected) OnRowSelected(this, selectedrow);
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
		public event Action<HtmlGrid<T> ,ClickedRow<T>> OnRowClicked;
		public event Action<HtmlGrid<T> ,jQueryEvent> OnKey; 


	}
}

