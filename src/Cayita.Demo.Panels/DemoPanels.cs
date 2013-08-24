using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Collections.Generic;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoPanels
	{
		public DemoPanels ()
		{
		}

		public static void Execute(Atom parent)
		{
			var code = new Div ();

			new Div (d=>{
				d.ClassName="bs-docs-example";

				UI.CreateContainer( d, ct=>{

					UI.CreateRowFluid(ct, r=>{

						new Div(r, sp=>{
							sp.ClassName="span5";

							var p1 =CreatePanel("Apps");

							new Div(pi=>{
								pi.ClassName="c-icons";
								pi.Append("<style>img {height: 40px;}  .c-icon {height: 95px;}</style>");

								foreach( var app in GetApps()){
									new ImgPicture(pi, img=>{
										img.Img.Src=app.Icon;
										img.Text=app.Title;
										img.Clicked+= (e) =>{e.PreventDefault(); app.Title.LogInfo();};
									});
								}
								p1.Add(pi);
							});

							var p2 =CreatePanel("Demo");

							var color = new TextField();
							var bb = new Button("Change background");
							bb.Clicked+= (e) => p2.Body.Style.BackgroundColor= color.Value;
							var bc = new Button("collapse");
							bc.Clicked+= (e) =>  p2.Collapse();

							p2.Add(color);
							p2.Add(bb);
							p2.Add(bc);

							sp.JQuery.Append(p1).Append(p2);


						});

						new Div(r, sp=>{
							sp.ClassName="span5";

							var p1 =CreatePanel("El Coyote");

							new Div( cy=>{  
								cy.ClassName="span2";  
								new Image(cy,i=>{  
									i.Src="img/coyote.jpg";  
									i.Style.Height="100px";  
								});  
								p1.Add(cy);
							});  

							new Div( cy=>{  
								cy.ClassName="span10";  
								cy.Append(@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.  
<a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");  
								p1.Add(cy);
							});  


							var p2 =CreatePanel("Table");
							var tb = new Table<App>("title");
							tb.Load(GetApps());
							p2.Add(tb);
							sp.JQuery.Append(p1).Append(p2);


						});

					});

				});


				var wn=1;  

				new Button(d, bt=>{
					bt.Text="Window I";  
					bt.Clicked+=evt=>{  
						new Panel( new PanelOptions{Overlay=true}){
							Caption="Window " +(wn++).ToString(),
							Left=(wn*5).ToString()+"px",  
							Top=(wn*15).ToString()+"px",  
							Width="300px",  
							Height="100px",

						}.Show();  
					};
				});


				new Button(d, bt=>{
					bt.Text="Window II";  
					bt.Clicked+=evt=>{  
						var panel= new Panel( new PanelOptions{
							Overlay=true,
							Caption="Custom Close Icon and Handler",
							Left="200px",  
							Top="300px",  
							Width="auto",  
							CloseIconClass="icon-th-large",
							CloseIconHandler=p=>{
								p.Caption="Close icon changed !!!";
								p.CloseIcon.ClassName= "icon-remove-circle";
								p.CloseIconHandler= pn=> {pn.Close(); "Panel was closed".LogError(5000); };
								p.Height="400px";
							}

						});

						panel.Add( new Button(b=>{
							b.Text="click me !";
							b.Style.Width="100%";
							b.Style.Height="100%";
							b.Clicked+= (e) => "button clicked".LogSuccess();

						}));

						panel.Show();


					};
				});


				new Button(d, bt=>{
					bt.Text="Window III";  
					bt.Clicked+=evt=>{  
						var panel= new Panel( new PanelOptions{
							Overlay=true,
							Caption="no closable, no collapsible",
							Left="200px",  
							Top="300px",  
							Width="auto",  
							Collapsible=false,
							Closable=false,
						});

						panel.Add( new Button(b=>{
							b.Text="click me !";
							b.Style.Width="100%";
							b.Style.Height="100%";
							b.Clicked+= (e) => {
								panel.Caption ="now closable and  collapsible";
								panel.Closable=true;
								panel.Collapsible=true;
								b.Disabled=true;
							};

						}));

						panel.Show();


					};
				});


				d.JQuery.Append("C# code".Header(4)).Append(code);
				parent.Append(d);
			});

			  

			var rq =jQuery.GetData<string> ("code/demopanels.html");
			rq.Done (s=> code.InnerHTML=s);

		}

		static Panel CreatePanel(string caption, bool draggable=false, bool closable=false)
		{
			var p = new Panel( new PanelOptions{Draggable=draggable, Closable=closable, Caption=caption});
			p.Body.Style.PaddingTop = "10px";
			p.Body.Style.PaddingBottom = "5px";
			return  p;
		}

		static List<App> GetApps()
		{
			var a = new List<App> (){
				new App{Title="Calculator", Icon="img/calculator.png"},
				new App{Title="Control Panel", Icon="img/control.png"},
				new App{Title="Firewall Settings", Icon="img/firewall.png"},
				new App{Title="Spreadsheet", Icon="img/calc.png"},
				new App{Title="Mail", Icon="img/mail.png"},
				new App{Title="Jack Sparrow Navigator", Icon="img/web.png"},
				new App{Title="MonoDevelop", Icon="img/monodevelop.png"},
				new App{Title="Tomboy", Icon="img/tomboy.png"},
				new App{Title="Skype", Icon="img/skype.png"}
			} ;
			return a;
		}

	}

	public class App:Record
	{
		public App(){}
		public string Title { get; set; }
		public string Icon { get; set; }


	}
	
}

