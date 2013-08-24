using System;
using Cayita.JData;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita
{
	public static partial class UI
	{
		public static SelectedGridRow<T> SelectedGridRow<T>() where T: new ()
		{
			return UI.Cast<SelectedGridRow<T>>( new {
				row=default(object), recordId=default(object), record= UI.Cast<object>(new T())
			});
		}


		public static GridRequestMessage GridRequestMessage(){

			return UI.Cast<GridRequestMessage>( new {
				target=default(object), message=default(string), htmlElement= default(object)
			});
		}

		public static Grid<T> Grid<T>(Store<T> store, List<TableColumn<T>> columns) 
			where T:Record,new()
		{
			var e =  Table<T> (columns, store.IdProperty).As<Grid<T>>();  
			e.Store = store;
			var multiple = false;

			var rowClicked = (Action<Grid<T>,TableRowAtom>)((g,r) => {});
			var rowSelected = (Action<Grid<T>,TableRowAtom>)((g,r) => {});
			var keydown = (Action<Grid<T>,jQueryEvent>)((g,evt) => {});

			var onRowClicked = (Action<TableRowAtom>)(r => rowClicked (e, r));
			var onRowSelected = (Action<TableRowAtom>)(r => rowSelected (e, r));
			var onKeydown = (Action<jQueryEvent>)( evt=> keydown(e,evt));

			var selectRowImp=(Action<TableRowAtom,bool,bool>)( (row, triggerSelected, triggerClicked)=>{

				if (row == null) return;
				e.SelectedRow =row;

				if( !e.Multiple) e.GetRows().ForEach(r=> r.RemoveClass ("info"));
				row.AddClass("info");

				if(triggerClicked) onRowClicked(row);
				if(triggerSelected) onRowSelected( row);

			});

			var previousRow = (Action)(() => {
				TableRowAtom row;
				if (e.SelectedRow == null) {
					row = e.GetLastRow ();
					if (row==null)
						return;

				} else {
					row =e.SelectedRow.PreviousSibling.As<TableRowAtom> ();
					if (row==null) 
						store.ReadPreviousPage();
				}
				selectRowImp (row, true, false);
			});

			var nextRow= (Action)(()=>{
				TableRowAtom row;
				if (e.SelectedRow == null) {
					row = e.GetFirstRow ();
					if (row == null)
						return;

				} else {
					row =e.SelectedRow.NextSibling.As<TableRowAtom> ();
					if(row==null) 
						store.ReadNextPage();

				}
				selectRowImp (row, true, false);
			});

			var keydownHandler = (Action<jQueryEvent>)(evt =>
			{
				evt.PreventDefault ();
				switch (evt.Which) {
				case 34: //page_down
					store.ReadNextPage ();
					break;
				case 33: //page_up
					store.ReadPreviousPage ();
					break;
				case 35: // end
					break;
				case 36: // home
					break;
				case 38: //up
					previousRow ();
					break;
				case 40: 
					nextRow ();
					break;
				default:	
					onKeydown(evt);
					break;
				}

			});

			e.SetToAtomProperty ("multiple", (Action<bool?>)(m => multiple = !m.HasValue || m.Value ? true : false));

			e.SetToAtomProperty ("is_multiple", (Func<bool>)(()=> multiple));

			e.SetToAtomProperty ("add_rowClicked", (Action<Action<Grid<T> , TableRowAtom>>)
			                     (v => rowClicked=  Cast<Action<Grid<T>,TableRowAtom>>(Delegate.Combine (rowClicked, v)) ));

			e.SetToAtomProperty ("remove_rowClicked", (Action<Action<Grid<T> , TableRowAtom>>)
			                     (v => rowClicked=  Cast<Action<Grid<T>,TableRowAtom>>(Delegate.Remove (rowClicked, v)) ));


			e.SetToAtomProperty ("add_rowSelected", (Action<Action<Grid<T> , TableRowAtom>>)
			                     (v => rowSelected=  Cast<Action<Grid<T>,TableRowAtom>>(Delegate.Combine (rowSelected, v)) ));

			e.SetToAtomProperty ("remove_rowSelected", (Action<Action<Grid<T> , TableRowAtom>>)
			                     (v => rowSelected=  Cast<Action<Grid<T>,TableRowAtom>>(Delegate.Remove (rowSelected, v)) ));


			e.SetToAtomProperty ("add_keydown", (Action<Action<Grid<T> , jQueryEvent>>)
			                     (v => keydown=  Cast<Action<Grid<T>,jQueryEvent>>(Delegate.Combine (keydown, v)) ));

			e.SetToAtomProperty ("remove_keydown", (Action<Action<Grid<T> , jQueryEvent>>)
			                     (v => keydown=  Cast<Action<Grid<T>,jQueryEvent>>(Delegate.Remove (keydown, v)) ));

			e.SetToAtomProperty("selectRow", (Action<object,bool?>)( (id,trigger)=>{
				selectRowImp( e.GetRowById(id), trigger.HasValue?trigger.HasValue:true ,false);
			}));

			e.SetToAtomProperty("unSelectRow", (Action<object>)( (id)=>{
				e.GetRowById(id).RemoveClass("info");
			}));

			e.SetToAtomProperty("clearSelection", (Action)(()=>{
				e.GetRows().ForEach(r=> r.RemoveClass ("info"));
				e.SelectedRow=null;
			}));


			e.SetToAtomProperty("getSelected", (Func<TableRowAtom[]>)( ()=>
				Cast<TableRowAtom[]>( jQuery.Select("tbody[main] tr[tb={0}].info".Fmt(e.ID),e).GetElements())
			));

			e.On("click", ev =>  { 
				selectRowImp(ev.CurrentTarget.As<TableRowAtom>(), true,true);
			},"tbody[main] tr[tb={0}]".Fmt(e.ID) ); 

			e.On ("keydown", evt => keydownHandler (evt));

			e.ReadRequestMessage= new GridRequestMessage{Target=e.Body, Message="Reading " + typeof(T).Name };

			e.ReadRequestStarted = (grid) => {
				var sp = new SpinnerIcon(e.ReadRequestMessage.Message);
				sp.Style.Position="fixed";
				sp.Style.ZIndex=10000;
				sp.Style.Opacity="0.6";
				sp.Style.Height= "90%";
				sp.Style.Width= "77%";
				e.ReadRequestMessage.Target.Append(sp);
				return sp;
			};

			e.ReadRequestFinished= (grid, el)=>{

				el.Remove();
			};

			e.Load (e.Store);


			e.Store.StoreChanged+=(st, dt)=>{
				switch(dt.Action)
				{
					case StoreChangedAction.Created:
					e.AddRow(dt.NewData);
					break;
					case StoreChangedAction.Filtered:
					case StoreChangedAction.Loaded:
					case StoreChangedAction.Read:
					e.Load(e.Store);
					e.ClearSelection();
					break;
					case StoreChangedAction.Updated:
					e.UpdateRow(dt.NewData);
					break;
					case StoreChangedAction.Destroyed:
					var recordId = dt.OldData.Get(e.Store.IdProperty);
					e.GetRowById(recordId).Remove();
					break;
					case StoreChangedAction.Patched:
					e.UpdateRow(dt.NewData);
					break;

					case StoreChangedAction.Added:
					e.AddRow(dt.NewData);
					break;
					case StoreChangedAction.Replaced:
					e.UpdateRow(dt.NewData);
					break;
					case StoreChangedAction.Inserted:
					e.AddRow(dt.NewData);
					break;
					case StoreChangedAction.Removed:
					var id = dt.OldData.Get(e.Store.IdProperty);
					e.GetRowById(id).Remove();
					break;
					case StoreChangedAction.Cleared:
					e.Body.Empty();
					e.ClearSelection();
					break;
				}
			};

			e.Store.StoreRequested+=(st, request)=>{
				switch (request.Action) {
					case StoreRequestedAction.Create:
					break;
					case StoreRequestedAction.Read:
					if(request.State== StoreRequestedState.Started)
					{
						e.ReadRequestMessage.HtmlElement= e.ReadRequestStarted(e);
					}
					else
					{
						e.ReadRequestFinished(e, e.ReadRequestMessage.HtmlElement);
					}
					break;
					case StoreRequestedAction.Update:
					break;
					case StoreRequestedAction.Destroy:
					break;
					case StoreRequestedAction.Patch:

					break;
				}

			};

			return e;
		}
	}
}

