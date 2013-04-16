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

		ButtonElement bt;
		DivElement main;
		DivElement body;

		HtmlGrid<T> gr;

		string searchText;


		public SearchBox (Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig<T> config):base(default(Element))
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

			bt = new Button (main, e=> e.Text("Search")).Element();

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
					searchText=te.Value;
					body.Hide();
				}
			});

			bt.OnClick (e => {
				if(te.Value!=searchText){
					searchText=te.Value;

					if(cfg.LocalFilter==null){
						store.Read(opt=>{
							opt.QueryParams[cfg.TextField]=searchText;
						});
					} else {
						store.Filter(t=> cfg.LocalFilter(t,searchText));
					}				
				}
				if(!body.IsVisible()) body.Show();

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
		}



		public string IndexField { get; set; }

		public string TextField { get; set; }

		public string Name { get; set; }

		public bool Required { get; set; }

		public bool Paged { get; set; }

		public Func<T,string,bool> LocalFilter{get;set;}
	}

}

