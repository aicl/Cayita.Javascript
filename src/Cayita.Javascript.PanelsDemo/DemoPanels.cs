using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;

namespace Modals
{
	public class App
	{
		public App(){}
		public string Tittle { get; set; }
		public string Icon { get; set; }
	
		public static List<App> GetApps()
		{
			var a = new List<App> (){
				new App{Tittle="Calculator", Icon="img/calculator.png"},
				new App{Tittle="Control Panel", Icon="img/control.png"},
				new App{Tittle="Firewall Settings", Icon="img/firewall.png"},
				new App{Tittle="Spreadsheet", Icon="img/calc.png"},
				new App{Tittle="Mail", Icon="img/mail.png"},
				new App{Tittle="Jack Sparrow Navigator", Icon="img/web.png"},
				new App{Tittle="MondDevelop", Icon="img/monodevelop.png"},
				new App{Tittle="Tomboy", Icon="img/tomboy.png"},
				new App{Tittle="Skype", Icon="img/skype.png"}
			} ;
			return a;
		}
	}



	[IgnoreNamespace]
	public class DemoPanels
	{
		public DemoPanels ()
		{
		}
		
		public static void Execute(Element parent)
		{
			"Modals".Header (2).AppendTo (parent);
			
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				div.Style.PaddingLeft="40px";
				div.Append( Div.CreateContainer(div, cf=>{
					Div.CreateRow(cf, rf=>{
						new Div(rf, ld=>{
							ld.ClassName="span5";
							var apps = new Panel().Caption("Apps").Closable(false).Resizable(false);
							new Div(id=>{
								id.ClassName="c-icons";
								id.Append("<style>img {height: 40px;}  .c-icon {height: 95px;}</style>");
								foreach(var app in App.GetApps()){
									new Anchor( id, a=>{
										a.ClassName="c-icon";
										new Image(a, img=>{
											img.Src=app.Icon;
											img.ClassName="img-rounded";
										});
										a.OnClick(ev=>{
											ev.PreventDefault();
											app.Tittle.LogInfo();										
										});
										new Span(a, sp=>{
											sp.ClassName="c-icon-label";
											sp.InnerHTML=app.Tittle;
										});
										
									});
								}
								apps.Append(id);
							});
							apps.Render(ld);

							new Panel()
								.Caption("Panel 4")
									.Closable(false)
									.Render(ld);

						});

						new Div(rf, ld=>{
							ld.ClassName="span5";
							var coyote = new Panel()
								.Caption("El Coyote").Closable(false).Render(ld).Draggable(false).Resizable(false);

							new Paragraph (p=>{
								p.Append( new Image(i=>{
									i.Src="img/coyote.jpg";
									i.Style.Height="20px";
									i.Style.Width="15px";
								}));
								p.Append(@"<i><b>El <a href=""https://es.wikipedia.org/wiki/Coyote"" title=""Coyote"" target=""_blank"">Coyote</a> y el <a href=""https://es.wikipedia.org/wiki/Geococcyx_californianus"" title=""Geococcyx californianus"" target=""_blank"">Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href=""https://es.wikipedia.org/wiki/Estados_Unidos"" title=""Estados Unidos"" target=""_blank"">estadounidense</a> de <a href=""https://es.wikipedia.org/wiki/Dibujos_animados"" title=""Dibujos animados"" target=""_blank"">dibujos animados</a> creada en el año de <a href=""https://es.wikipedia.org/wiki/1949"" title=""1949"" target=""_blank"">1949</a> por el animador <a href=""https://es.wikipedia.org/wiki/Chuck_Jones"" title=""Chuck Jones"" target=""_blank"">Chuck Jones</a> para <a href=""https://es.wikipedia.org/wiki/Warner_Brothers"" title=""Warner Brothers"" target=""_blank"">Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href=""https://es.wikipedia.org/wiki/Mark_Twain"" title=""Mark Twain"" target=""_blank"">Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.");
								coyote.Append(p);
							});

							var tbp= new Panel().Caption("Table").Closable(false).Draggable(false).Resizable(false);

							new HtmlTable(t=>{
								t.ClassName="table table-striped table-hover table-condensed";
								new TableHeader(t, h=>{
									new TableRow(h, tr=>{
										new TableCell(tr, td=> td.SetValue("Title"));
										new TableCell(tr, td=> td.SetValue("URL"));
										        
									});
								});
						
								foreach (var app in App.GetApps())
								{
									new TableRow(t, tr=>{
										new TableCell(tr, td=> td.SetValue(app.Tittle));
										new TableCell(tr, td=> td.SetValue(app.Icon));
									});
								}
								tbp.Append(t);
							});

							tbp.Render(ld);


						});

					});



				}));
				
				div.Append(@"");
				
			}).AppendTo(parent);
			
					
		}
		
	}
}



/*
new Div(null, div=>{
	div.ClassName="bs-docs-example";

	div.Append( new Button(div,b=>{
		b.Text("Simple Modal Dialog I");
		b.OnClick(evt=> Bootbox.Dialog("Your App Text: cayita is awesome....") );
	}));

	div.Append(@"");
					
}).AppendTo(parent);
*/

