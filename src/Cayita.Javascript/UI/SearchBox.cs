using System;
using Cayita.UI;
using System.Html;
using Cayita.Data;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita.UI
{
	public class SearchBox<T>:Div where T: new()
	{
		SearchBoxConfig<T> cfg;

		TextElement te;
		InputElement he;

		DivElement main;
		DivElement body;

		HtmlGrid<T> gr;

		string searchText;
		string searchIndex;

		public SearchBox (Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig<T> config)
			:this(null, store, columns, config)
		{
		}


		public SearchBox (Element parent,Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig<T> config):base(parent)
		{
			Init (store, columns, config);
		}

		void Reset ()
		{
			te.Value = "";
			he.Value = "";
			searchText = null;
			searchIndex = null;
			OnRowSelected (this, null);
		}
					
		void Init(Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig<T> config )
		{

			cfg = config;

			if (string.IsNullOrEmpty (cfg.IndexField)) 
				cfg.IndexField = store.GetRecordIdProperty ();

			main = Element ();
		
			he = new Input (main, e => {
				e.Hide (); 
				e.Name=cfg.Name; 
				if (cfg.Required) e.Required() ;
			}).Element ();

			te = new InputText (main, e=>{
				e.ClassName="search-query";
				e.PlaceHolder(cfg.PlaceHolder);
				e.JQuery().Keyup(evt=>{
						
					var k = evt.Which;

					//down enter numpad_enter
					if ( k== 40 || k==13 || k==108  )
					{
						if(!body.IsVisible()) body.Show();
						gr.JQuery().Focus();
						return;
					}
					// esc
					if( k== 27 )
					{
						he.Value=searchIndex;
						te.Value=searchText;
						if(body.IsVisible()) body.Hide();
						return;
					}

					// end home left 
					//numpad_add numpad_decimal numpad_divid numpad_multiply numpad_substract
					// page_down page_up right up tab
					if(k==35 || k==36 || k==37 || k==107 || k==110 || k==11 || k==106 || k==109
					   || k==34 || k==33 || k==39 || k==38 || k==9)
					{
						return;
					}

					if(! cfg.SearchButton || cfg.LocalFilter!=null)
					{
						Action b= ()=>{
								Search(store);
								if(!body.IsVisible()) body.Show();		
						};
						b.Delay(cfg.Delay);
					}

				});
			}).Element();

			//search button
			new IconButton(main, (b, ibn)=>{  

				if(!cfg.SearchButton) b.Hide();
				ibn.ClassName=cfg.SearchIconClassName;

				b.OnClick (e => {
					Search(store);
					body.JQuery().Toggle(); if(body.IsVisible()) gr.JQuery().Focus();
				});
			}); 

			// reset button
			new IconButton(main, (b, ibn)=>{  
				
				if(!cfg.ResetButton) b.Hide();
				ibn.ClassName=cfg.ResetIconClassName;
				
				b.OnClick (e => {
					Reset ();
				});
			});


			body = new Div (main, e=>{
				e.Hide();
				e.ClassName="c-search-body";
			}).Element();

			gr = new HtmlGrid<T> (body, store, columns);

			if(cfg.Paged) new StorePaging<T>(body, store);


			gr.OnRowClicked += (g, sr) => {
				ReadSelectedRow (sr);
			};

			gr.OnKey += (g,evt) => {
				var k= evt.Which;

				if (k==27){
					body.Hide();
					return;
				}

				if( k==13 || k== 107){
					var sr =g.GetSelectedRow();
					ReadSelectedRow(sr);
					return;
				}

			};

			OnRowSelected = (sb,sr) => {};

			if (cfg.OnRowSelectedHandler != null)
				OnRowSelected += cfg.OnRowSelectedHandler;
		}

		void ReadSelectedRow (SelectedRow<T> sr)
		{
			if (sr == null)
				return;

			he.SetValue (sr.Record.Get (cfg.IndexField));
			te.SetValue (sr.Record.Get (cfg.TextField));
			searchText = te.Value;
			searchIndex = he.Value;
			body.Hide ();
			OnRowSelected (this, sr);
		}

		void Search (Store<T> store)
		{

			if(te.Value!=searchText){
				he.Value=null;

				var st=te.Value;
				
				if(cfg.LocalFilter==null){

					if(st.Length<cfg.MinLength)
					{
						return ;
					}
					store.Read(opt=>opt.QueryParams[cfg.TextField]=st);

				} else {
					store.Filter(t=> cfg.LocalFilter(t,st));
				}				
			}
		}

		Action<Action, int> Delay()
		{
			var timer = 0;
			return  (callback, delay) => {
				Window.ClearTimeout(timer);
				timer =Window.SetTimeout( callback, delay );
			};
		}

		public event Action<SearchBox<T>, SelectedRow<T>> OnRowSelected;
	}

	[Serializable]
	public class SearchBoxConfig<T> where T: new()
	{
		public SearchBoxConfig()
		{
			IndexField = "Id";
			Name = "";
			Paged = true;
			Delay = 400;
			SearchIconClassName = "icon-search";
			ResetIconClassName = "icon-remove";
			MinLength = 4;

		}


		public string IndexField { get; set; }

		public string TextField { get; set; }

		public string Name { get; set; }

		public bool Required { get; set; }

		public bool Paged { get; set; }

		public Func<T,string,bool> LocalFilter{get;set;}

		public bool SearchButton { get; set; }

		public bool ResetButton { get; set; }

		public int Delay { get; set; }

		//public bool AutoSelect { get; set; }

		public int MinLength {get;set;}

		public string SearchIconClassName {get;set;}
						
		public string ResetIconClassName {get;set;}

		public Action<SearchBox<T>, SelectedRow<T>> OnRowSelectedHandler{ get; set; }

		public string PlaceHolder { get; set; }

	}

}

