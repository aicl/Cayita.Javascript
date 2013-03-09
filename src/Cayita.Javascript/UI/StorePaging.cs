using System;
using Cayita.Javascript.UI;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.Javascript.Data;

namespace Cayita.Javascript
{
	[ScriptNamespace("Cayita.UI")]
	public class StorePaging<T>:Div
	{
		Div divnav;
		string pText ="page";
		string ofText = "of";
		string infoTmpl= "Items from {0} to {1} of {2}";

		Store<T> store_ ;

		Func<string>  pTextFunc = ()=>{return pText;};
		Func<string>  ofTextFunc = ()=>{return ofText;};

		Func<string>  infoTextFunc = ()=>{
			var lo = store_.GetLastOption();
			string fv = ( (lo.PageNumber.HasValue? lo.PageNumber.Value:0)+1)*
			lo.PageSize.HasValue?
			return string.Format(infoTmpl ) ;
		};

		DivElement element;
		public StorePaging (Element parent):base(parent)
		{
			element = Element ();

			divnav = new Div (element, d => {
				d.ClassName="btn-group";
				new Button(d, b=>{	b.AddClass("btn-small");});
				new Icon(d, i=>{i.ClassName="icon-double-angle-left";});
			});

			new Div (element, d => {
				new Button(d, b=>{	b.AddClass("btn-small");});
				new Icon(d, i=>{i.ClassName="icon-angle-left";});
			});

			new Div (element, d => {
				new Button(d, b=>{	b.AddClass("btn-small");});
				new Icon(d, i=>{i.ClassName="icon-angle-right";});
			});

			new Div (element, d => {
				new Button(d, b=>{	b.AddClass("btn-small");});
				new Icon(d, i=>{i.ClassName="icon-double-angle-right";});
			});


			new Div (element, d => {
				d.ClassName="btn-group form-inline";
				new Label(d, l => {
					l.ClassName="checkbox";
					l.Style.PaddingRight="2px";
					l.Text(pTextFunc());
				});
				new Input(d,i => {
					i.ClassName="input-mini";
					i.Style.Padding="0px";
					i.Style.TextAlign="center";
					i.AutoNumeric(new {mDec=0, wEmpty= "empty"});
				});

				new Label(d, l => {
					l.ClassName="checkbox";
					l.Style.PaddingLeft="2px";
					l.Text(ofText + " {0}");
				});
			});

			new Div (element, d => {
				d.ClassName="btn-group form-inline";
				new Label(d, l => {
					l.ClassName="checkbox";
					l.Style.PaddingRight="2px";
					l.Text(infoTmpl);
				});

			});

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

