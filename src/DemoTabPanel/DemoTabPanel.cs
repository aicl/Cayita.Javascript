using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;

namespace Cayita.Javascript
{

	[IgnoreNamespace]
	public class DemoTabPanel
	{
		public DemoTabPanel ()
		{
		}

		public static void Execute(Element parent)
		{
			
			"Default styles".Header (2).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";

				var tb =new TabPanel(div, cfg=>{
					cfg.Bordered=true;
					cfg.Content.Style.MinHeight="100px";
				});
				tb.AddTab(tab=>{
					tab.Title="First tab";
					tab.Body.Append("Hello first tab".Header(3));
				});

				tb.AddTab(tab=>{
					tab.Title="Second tab";
					tab.Body.AddClass("well");
					tab.Body.Append("Hello second tab");
					tab.Body.Style.Color="red";
				});

				tb.AddTab(tab=>{
					tab.Title="El Coyote";

					tab.Body.Append( new Div( d=>{
						d.ClassName="span2";
						new Image(d,i=>	i.Src="img/coyote.jpg");
					}));
					
					tab.Body.Append(new Div( d=>{
						d.ClassName="span10";
						d.Append(@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
					}));

				});

			}).AppendTo(parent);


			//

			"Default styles".Header (2).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				
				var tb =new TabPanel(div, cfg=>{
					cfg.Bordered=false;
					cfg.TabsPosition="right";
					cfg.Content.Style.MinHeight="100px";
				});
				tb.AddTab(tab=>{
					tab.Title="First tab";
					tab.Body.Append("Hello first tab".Header(3));
				});
				
				tb.AddTab(tab=>{
					tab.Title="Second tab";
					tab.Body.AddClass("well");
					tab.Body.Append("Hello second tab");
					tab.Body.Style.Color="red";
				});
				
				tb.AddTab(tab=>{
					tab.Title="El Coyote";
					
					tab.Body.Append( new Div( d=>{
						d.ClassName="span2";
						new Image(d,i=>	i.Src="img/coyote.jpg");
					}));
					
					tab.Body.Append(new Div( d=>{
						d.ClassName="span10";
						d.Append(@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
					}));
					
				});
				
			}).AppendTo(parent);

		}

	}
}

