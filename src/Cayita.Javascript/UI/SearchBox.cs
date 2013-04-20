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
				e.JQuery().Keyup(evt=>{
								
					Action b= ()=>{
						switch(evt.Which)
						{
						case 40: // down
						case 35: // end
						case 36: // home
						case 37: //left
						case 107: //numpad_add
						case 110: //numpad_decimal
						case 111: //numpad_divid
						case 106: //numpad_multiply
						case 109: //numpad_substract
						case 34: //page_down
						case 33: //page_up
						case 39: //right
						case 38: //up
							break;
						case 27: // esc
							he.Value=searchIndex;
							te.Value=searchText;
							if(body.IsVisible()) body.Hide();
							break;
							
						case 9: // tab
							break;
						case 13: // enter
						case 108: // numpad enter
						default:
							if(! cfg.SearchButton || cfg.LocalFilter!=null)
							{
								Search(store);
								if(!body.IsVisible()) body.Show();
							}
							break;
						}

					};
					b.Delay(cfg.Delay);

				});
			}).Element();

			//search button
			new IconButton(main, (b, ibn)=>{  

				if(!cfg.SearchButton) b.Hide();
				ibn.ClassName=cfg.SearchIconClassName;

				b.OnClick (e => {
					Search(store);
					body.JQuery().Toggle();
				});
			}); 

			// reset button
			new IconButton(main, (b, ibn)=>{  
				
				if(!cfg.ResetButton) b.Hide();
				ibn.ClassName=cfg.ResetIconClassName;
				
				b.OnClick (e => {
					te.Value="";
					he.Value="";
					searchText=null;
					searchIndex=null;
				});
			});


			body = new Div (main, e=>{
				e.Hide();
				e.ClassName="c-search-body";
			}).Element();

			gr = new HtmlGrid<T> (body, store, columns);

			if(cfg.Paged) new StorePaging<T>(body, store);


			gr.OnRowClicked += ((g, sr) => {

				if(sr!=null){
					he.SetValue( sr.Record.GetValue(cfg.IndexField));
					te.SetValue( sr.Record.GetValue(cfg.TextField));
					body.Hide();
					searchText=te.Value;
					searchIndex=he.Value;
				}

				if(OnRowSelected!=null) OnRowSelected(this,sr);

			});



			if (cfg.OnRowSelectedHandler != null)
				OnRowSelected += cfg.OnRowSelectedHandler;
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

		public bool AutoSelect { get; set; }

		public int MinLength {get;set;}

		public string SearchIconClassName {get;set;}
						
		public string ResetIconClassName {get;set;}

		public Action<SearchBox<T>, SelectedRow<T>> OnRowSelectedHandler{ get; set; }

		//public SearchButtonConfig  SearchButtonConfig { get; set; }
	}

}

