using System;
using Cayita.UI;
using System.Html;
using Cayita.Data;
using System.Collections.Generic;

namespace Cayita.UI
{
	public class SearchBox<T>:Div where T: new()
	{
		SearchBoxConfig cfg;

		TextElement te;
		InputElement he;

		ButtonElement bt;
		DivElement main;
		DivElement body;

		HtmlGrid<T> gr;


		public SearchBox (Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig config):base(default(Element))
		{
			Init (store, columns, config);
		}

					
		void Init(Store<T> store, List<TableColumn<T>> columns, SearchBoxConfig config )
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
				} else {
					he.SetValue("");
					te.SetValue("");
				}
			});

			bt.OnClick (e => {
				body.JQuery().Toggle();
			});
		}



	}

	[Serializable]
	public class SearchBoxConfig
	{
		public SearchBoxConfig()
		{

			RemoteFilter = true;
			IndexField = "Id";
			Name = "";
			Paged = true;
		}

		public bool RemoteFilter{ get; set; }

		public string IndexField { get; set; }

		public string TextField { get; set; }

		public string Name { get; set; }

		public bool Required { get; set; }

		public bool Paged { get; set; }

	}

}

