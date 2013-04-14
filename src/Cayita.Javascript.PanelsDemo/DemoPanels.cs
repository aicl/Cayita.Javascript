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
				new App{Tittle="Tomboy", Icon="img/tomboy.png"}
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
				
				div.Append( Div.CreateContainerFluid(div, cf=>{
					Div.CreateRowFluid(cf, rf=>{
						new Div(rf, ld=>{
							ld.ClassName="span6";
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
						});

						new Div(rf, ld=>{
							ld.ClassName="span6";
							new Panel()
								.Caption("Panel 2")
									.Closable(false)
									.Render(ld);
						});

					});

					Div.CreateRowFluid(cf, rf=>{
						new Div(rf, ld=>{
							ld.ClassName="span6";
							new Panel()
								.Caption("Panel 3")
									.Closable(false)
									.Render(ld);
							
						});
						
						new Div(rf, ld=>{
							ld.ClassName="span6";
							new Panel()
								.Caption("Panel 4")
									.Closable(false)
									.Render(ld);

							
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

