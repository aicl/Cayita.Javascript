using System;
using Cayita.UI;
using System.Html;
using Cayita.Data;
using System.Collections.Generic;

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

			te = new InputText (main, e=> e.ClassName="search-query").Element();

			new IconButton(main, (b, ibn)=>{  

				if(!cfg.SearchButton) b.Hide();
				ibn.ClassName=cfg.SearchIconClassName;

				b.OnClick (e => {
					if(te.Value!=searchText){
						var st=te.Value;
						
						if(cfg.LocalFilter==null){
							store.Read(opt=>{
								opt.QueryParams[cfg.TextField]=st;
							});
						} else {
							store.Filter(t=> cfg.LocalFilter(t,st));
						}				
					}
					body.JQuery().Toggle();
				});
			}); 

			new IconButton(main, (b, ibn)=>{  
				
				if(!cfg.ResetButton) b.Hide();
				ibn.ClassName=cfg.ResetIconClassName;
				
				b.OnClick (e => {
					te.Value="";
					he.Value="";
					searchText=null;
				});
			});


			body = new Div (main, e=>{
				e.Hide();
				e.ClassName="c-search-body";
			}).Element();

			gr = new HtmlGrid<T> (body, store, columns);

			if(cfg.Paged) new StorePaging<T>(body, store);


			gr.OnRowSelected += ((g, sr) => {

				if(sr!=null){
					he.SetValue( sr.Record.GetValue(cfg.IndexField));
					te.SetValue( sr.Record.GetValue(cfg.TextField));
					body.Hide();
					searchText=te.Value;
				}
			});


		}

	}

	[Serializable]
	public class SearchBoxConfig<T> where T: new()
	{
		public SearchBoxConfig()
		{
			IndexField = "Id";
			Name = "";
			Paged = true;
			Delay = 300;
			SearchIconClassName = "icon-search";
			ResetIconClassName = "icon-remove";
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

		//public SearchButtonConfig  SearchButtonConfig { get; set; }
	}

}

