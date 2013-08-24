using System;
using Cayita.JData;
using System.Collections.Generic;
using jQueryApi;
using System.Linq;

namespace Cayita
{
	public static partial class UI
	{
		public static SearchBoxConfig SearchBoxConfig ()
		{
			return Cast<SearchBoxConfig> (new {
				name = "",
				paged = true,
				delay = 400,
				searchIconClassName = "icon-search",
				resetIconClassName = "icon-remove",
				minLength = 4,
				required=false,
				placeholder="",
			});

		}

		public static SearchBox<T> SearchBox<T>(Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig config)
			where T: Record, new()
		{

			string searchText=null;
			string searchIndex=null;

			var e = Atom ("div").As<SearchBox<T>>();

			e.Config = config;

			var rowSelected = (Action<SearchBox<T>,TableRowAtom>)((g,r) => {});
			var onRowSelected = (Action<TableRowAtom>)(r => rowSelected (e, r));

			var he = new TextInput ();
			he.Hidden = true;
			he.Required = config.Required;

			var te = new TextInput ();
			te.ClassName = "search-query";
			te.Placeholder = config.Placeholder;

			e.SearchButton = new ButtonIcon (config.SearchIconClassName);
			e.SearchButton.Hidden = !config.SearchButton;

			e.ResetButton = new ButtonIcon (config.ResetIconClassName);
			e.ResetButton.Hidden = !config.ResetButton;

			e.Body = new Div ("c-search-body");
			e.Body.Hidden = true;


			e.SetToAtomProperty ("add_rowSelected", (Action<Action<SearchBox<T> , TableRowAtom>>)
			                     (v => rowSelected=  Cast<Action<SearchBox<T>,TableRowAtom>>(Delegate.Combine (rowSelected, v)) ));

			e.SetToAtomProperty ("remove_rowSelected", (Action<Action<SearchBox<T> , TableRowAtom>>)
			                     (v => rowSelected=  Cast<Action<SearchBox<T>,TableRowAtom>>(Delegate.Remove (rowSelected, v)) ));


			if (columns == null) {
				columns=new List<TableColumn<T>>();
				columns.Add(new TableColumn<T>(config.TextField, autoHeader:false));
			}

			var gr = new Grid<T> ( store, columns);
			e.Body.Append (gr);

			if (config.Paged) {
				e.Body.Append (new StorePager<T> ( store));
			}

			var reset = (Action<bool>)(all =>
			                           {
				if (all) {
					te.Value = "";
					he.Value = "";
				}
				if (!string.IsNullOrEmpty (searchText)) {
					searchText = null;
					searchIndex = null;
					onRowSelected (null);
				}
			});

			var search = (Action)(() =>
			{
				if (te.Value != searchText) {

					var st = te.Value;

					if (e.LocalFilter == null) {

						if (st.Length < e.Config.MinLength) {
							return;
						}
						store.Read (opt=>opt.Query[e.Config.TextField]=st);

					} else {
						store.Filter (t=> e.LocalFilter(t,st));
					}

					reset (false);
				}
			});


			var readSelectedRow = (Action<TableRowAtom>)(sr =>
			{
				if (sr == null)
				{
					e.IndexValue=null;
					e.TextValue= null;
					return;
				}

				var rec = store.First(r=> 	r.Get(store.IdProperty).ToString()== sr.RecordId);
				he.Value = rec.Get(store.IdProperty).ToString(); 
				te.Value = rec.Get(e.Config.TextField).ToString(); 
				searchText = te.Value;
				searchIndex = he.Value;
				e.Body.Hidden=true;
				e.IndexValue= he.Value;
				e.TextValue= te.Value;
				onRowSelected (sr);
			});

			e.SearchButton.Clicked+= ev => {
				search ();
				e.Body.Toggle ();
				if (!e.Body.Hidden)
					gr.Focus ();
			};

			e.ResetButton.Clicked+= ev =>	{ reset(true); e.Body.Hidden=true; };

			
			gr.RowClicked += (g, sr) => {
				readSelectedRow (sr);
			};

			gr.KeyDown += (g,evt) => {
				var k= evt.Which;

				if (k==27){
					e.Body.Hidden=true;
					return;
				}

				if( k==13 || k== 107){
					readSelectedRow(g.SelectedRow);
					return;
				}

			};


			jQuery.FromElement (te).Keyup (evt => {

				var k = evt.Which;

				//down enter numpad_enter
				if (k == 40 || k == 13 || k == 108) {
					if (e.Body.Hidden )
						e.Body.Hidden=false;
					jQuery.FromElement(gr).Focus ();
					return;
				}
				// esc
				if (k == 27) {
					he.Value =  searchIndex;
					te.Value = searchText;
					if (!e.Body.Hidden)
						e.Body.Hidden =true;
					return;
				}

				// end home left 
				//numpad_add numpad_decimal numpad_divid numpad_multiply numpad_substract
				// page_down page_up right up tab
				if (k == 35 || k == 36 || k == 37 || k == 107 || k == 110 || k == 11 || k == 106 || k == 109
				    || k == 34 || k == 33 || k == 39 || k == 38 || k == 9) {
					return;
				}

				if (! config.SearchButton || e.LocalFilter != null) {
					Action b = () => {
						search ();
						if (e.Body.Hidden)
						e.Body.Hidden=false;
					};
					b.Delay (config.Delay);
				}

			});

			jQuery.FromElement (e).Append (he).Append(te).Append(e.SearchButton).Append(e.ResetButton).Append(e.Body);

			return e;

		}

	}


}

