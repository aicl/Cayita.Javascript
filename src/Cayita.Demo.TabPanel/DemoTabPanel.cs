using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoTabPanel
	{
		public DemoTabPanel ()
		{
		}


		public static void Execute (Atom parent)
		{

			var d = new Div ("bs-docs-example");

			var top = new TabPanel (new TabPanelOptions{
				TabsPosition="top",
				Bordered=true,

			});
			top.Content.Style.MinHeight = "100px";

			var t1 = new Tab ();
			t1.Caption="First Tab";
			t1.Body.Append ("Firs tab body");
			AlertFn.Success (t1.Body.FirstChild, "Cayita is awesome");
			top.Add (t1);

			top.Add (tab=>{
				tab.Caption= "Second Tab";
				tab.Body.AddClass("well");  
				tab.Body.Append("Hello second tab");  
				tab.Body.Style.Color="red";  
			});

			top.Add (tab=>{
				tab.Caption= "El Coyote";
				tab.Body.Append( new Div(cd=>{
					cd.ClassName="span1";
					cd.Append( new Image{Src="img/coyote.jpg"});
				}));
				tab.Body.Append( new Div(cd=>{
					cd.ClassName="span11";
					cd.Append( CoyoteText);
				}));
			});

			d.Append (top);

			parent.JQuery.Append ("Tabs on top".Header(3)).Append(d);


			var right = new TabPanel (new TabPanelOptions{
				TabsPosition="right",
			}, pn=>{
				pn.Add( tab=>{
					tab.Caption="First tab";  
					tab.Body.Append("Hello first tab".Header(3));
				});
				pn.Add( tab=>{
					tab.Caption= "Second tab";
					tab.Body.AddClass("well");  
					tab.Body.Append("Hello second tab");  
					tab.Body.Style.Color="blue";  
					tab.Body.Style.Height="80px";
				});
				pn.Add( tab=>{
					tab.Caption= "El Coyote";
					tab.Body.Append( new Div(cd=>{
						cd.ClassName="span1";
						cd.Append( new Image{Src="img/coyote.jpg"});
					}));
					tab.Body.Append( new Div(cd=>{
						cd.ClassName="span11";
						cd.Append( CoyoteText);
					}));
				});

			});

			new Div (ex=>{
				ex.ClassName="bs-docs-example";
				ex.Append(right);
				parent.JQuery.Append ("Tabs on right".Header(3)).Append(ex);
			});

			right.Show (2);


			var bottom = new TabPanel (new TabPanelOptions{
				TabsPosition="below",
			}, pn=>{
				pn.Add( tab=>{
					tab.Caption="First tab";  
					tab.Body.Append("Hello first tab".Header(3));
				});
				pn.Add( tab=>{
					tab.Caption= "Second tab";
					tab.Body.AddClass("well");  
					tab.Body.Append("Hello second tab");  
					tab.Body.Style.Color="blue";  
					tab.Body.Style.Height="80px";
				});
				pn.Add( tab=>{
					tab.Caption= "El Coyote";
					tab.Body.Append( new Div(cd=>{
						cd.ClassName="span1";
						cd.Append( new Image{Src="img/coyote.jpg"});
					}));
					tab.Body.Append( new Div(cd=>{
						cd.ClassName="span11";
						cd.Append( CoyoteText);
					}));
				});

			});

			bottom.Content.Style.MinHeight = "150px";

			new Div (ex=>{
				ex.ClassName="bs-docs-example";
				ex.Append(bottom);
				parent.JQuery.Append ("Tabs on bottom".Header(3)).Append(ex);
			});

			bottom.Show (1);

			var left = new TabPanel (new TabPanelOptions{
				TabsPosition="left", Bordered=true
			}, pn=>{
				pn.Add( tab=>{
					tab.Caption="First tab";  
					tab.Body.Append("Hello first tab".Header(3));
				});
				pn.Add( tab=>{
					tab.Caption= "Second tab";
					tab.Body.AddClass("well");  
					tab.Body.Append("Hello second tab");  
					tab.Body.Style.Color="blue";  
					tab.Body.Style.Height="80px";
				});
				pn.Add( tab=>{
					new Image(tab, i=>{i.Src="img/coyote.jpg"; i.Style.Height="106px";});
					new Label(tab, "El Coyote");
					tab.Body.Append(CoyoteText);
				});

			});
			left.Content.Style.MinHeight = "220px";

			new Div (ex=>{
				ex.ClassName="bs-docs-example";
				ex.Append(left);
				parent.JQuery.Append ("Tabs on left".Header(3)).Append(ex);
			});

			left.Show (0);


			parent.Append ("C# code".Header(3));

			var rq =jQuery.GetData<string> ("code/demotabpanel.html");
			rq.Done (s=> {
				var code=new Div();
				code.InnerHTML= s;
				parent.Append(code);
			});



		}

		static string CoyoteText{
			get{
				return @"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> 
y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' 
target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes 
de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' 
target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' 
title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de 
<a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador 
<a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> 
para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' 
target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de 
<a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, 
titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.  
<a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' 
target='_blank'>El Coyote (wikipedia)</a> ";
			}
		}
	}
}
