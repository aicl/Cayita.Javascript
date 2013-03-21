using System;
using Cayita.Javascript.UI;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.Javascript.Data;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class StorePaging<T>:Div where T: new ()
	{
		Div divnav;
		string pText ="page";
		string ofText = "of";
		string infoTmpl= "from {0} to {1} of {2}";

		Store<T> store_ ;

		DivElement element;

		ButtonElement first;
		ButtonElement prev;
		ButtonElement next;
		ButtonElement last;

		LabelElement page;
		LabelElement totalPages;
		LabelElement info;
		InputElement currentPage;

		public StorePaging (Element parent, Store<T> store):base(parent)
		{
			store_ = store;

			element = Element ();

			divnav = new Div (element, d => {
				d.ClassName="btn-group";
				first = new IconButton(d, (b,i)=>{ b.Disabled=true; b.OnClick(evt=> store_.ReadFirstPage());	b.AddClass("btn-small"); i.ClassName="icon-double-angle-left";}).Element();
				prev = new IconButton(d, (b,i)=>{ b.Disabled=true;	b.OnClick(evt=>store_.ReadPreviousPage()); b.AddClass("btn-small");i.ClassName="icon-angle-left";}).Element();
				next = new IconButton(d, (b,i)=>{ b.Disabled=true;	b.OnClick(evt=>store_.ReadNextPage()); b.AddClass("btn-small"); i.ClassName="icon-angle-right"; }).Element();
				last = new IconButton(d, (b,i)=>{ b.Disabled=true;	b.OnClick(evt=>store_.ReadLastPage());b.AddClass("btn-small");i.ClassName="icon-double-angle-right"; }).Element();
			});

			new Div (element, d => {
				d.ClassName="btn-group form-inline label";
				page=new Label(d, l => {
					l.ClassName="checkbox";
					l.Style.PaddingRight="2px";
					l.Text(pText);
					l.Style.FontSize="98%";
				}).Element();

				currentPage=new Input(d,i => {
					i.ClassName="input-mini";
					i.Style.Padding="0px";
					i.Style.Height="18px";
					i.AutoNumeric(new {mDec=0, wEmpty= "empty", vMin=0});
					i.Style.TextAlign="center";
					i.Style.FontSize="97%";
					i.Style.Width="45px";
					i.JQuery().Keypress(evt=>{
						if(evt.Which==13)
						{
							store_.ReadPage( i.GetValue<int>()-1);
						}
					});
				}).Element();

				totalPages = new Label(d, l => {
					l.ClassName="checkbox";
					l.Style.PaddingLeft="2px";
					l.Text(ofText + " {0}");
					l.Style.FontSize="98%";
				}).Element();
			});

			new Div (element, d => {
				d.ClassName="btn-group form-inline label";
				info =new Label(d, l => {
					l.ClassName="checkbox";
					l.Style.PaddingRight="2px";
					l.Text(infoTmpl);
					l.Style.FontSize="98%";
				}).Element();

			});

			store.OnStoreChanged += (st, dt) => {
				Update();
			};

		}

		public Div Navigator()
		{
			return divnav;
		}

		public StorePaging<T> PageText(string text)
		{
			pText = text;
			return this;
		}

		public StorePaging<T> OfTotalText(string text)
		{
			ofText = text;
			return this;
		}

		public StorePaging<T> InfoTemplate(string text)
		{
			infoTmpl = text;
			return this;
		}

		public void Update()
		{
			//currentPage.SetValue (1);

			var lo = store_.GetLastOption();
			var pageNumber = lo.PageNumber.HasValue ? lo.PageNumber.Value : 0;
			var pageSize = lo.PageSize.HasValue ? lo.PageSize.Value : 0;

			var from_ = (pageNumber*pageSize) +1;
			
			var to_ = (pageNumber * pageSize) +(lo.PageSize.HasValue? lo.PageSize.Value:0);

			var pagesCount = store_.GetPagesCount ();

			if (to_ > store_.GetTotalCount ())
				to_ = store_.GetTotalCount ();
			if (to_ == 0)
				from_ = 0;

			first.Disabled = !store_.HasPreviousPage ();
			prev.Disabled = !store_.HasPreviousPage ();
			next.Disabled = !store_.HasNextPage ();
			last.Disabled = !store_.HasNextPage ();

			page.Text(pText);

			currentPage.SetValue (pageNumber + 1);
			//currentPage.AutoNumeric(new {vMax=pagesCount});

			totalPages.Text ( ofText + " "+ pagesCount.ToString() );

			info.Text(	string.Format(infoTmpl, from_, to_, store_.GetTotalCount( )) );
	

		}

	}
}


/*
<div>
	<div class="btn-group">
		<button id="btn-1" type="button" class="btn btn-small">
		<i id="i-50" class="icon-double-angle-left icon-small"></i>
		</button>
		<button id="btn-2" type="button" class="btn btn-small">
		<i id="i-51" class="icon-angle-left icon-small"></i>
		</button>
		<button id="btn-3" type="button" class="btn btn-small">
		<i id="i-52" class="icon-angle-right icon-small"></i>
		</button>
		<button id="btn-4" type="button" class="btn btn-small">
		<i id="i-52" class="icon-double-angle-right icon-small"></i>
		</div>
		
		<div class="btn-group form-inline">	 		
 		<label class="checkbox" style="padding-right:2px">Page</label>
 		<input type="text" class="input-mini" style="padding:0px; text-align:center">
  		<label class="checkbox" style="padding-left:2px"> of 200 </label>
		</div>

		<div class= "btn-group form-inline">
		 <label class="checkbox"> Cliente del 13 al 24 de 32</label>
		</div>
		
	</div>

*/

