using jQueryApi;
using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Cayita.UI;

namespace Cayita.Javascritp.App
{

	[IgnoreNamespace]
	public class MenuItem
	{
		public string Class {get;set;}
		public string Title {get;set;}
		public string File {get;set;}
	}

	[IgnoreNamespace]
	public class App
	{
		TopNavBar TopNavBar {get;set;}
		Div Work {get;set;}
		List<MenuItem> MenuItems {get;set;}

		List<string>  modules = new List<string>();

		public static void Main ()
		{
			jQuery.OnDocumentReady( ()=>{
				var app = new App();
				app.GetMenuItems();
				app.ShowTopNavBar();
				app.ShowMenu();
/*
				Bootbox.Dialog("Este es un simple menaje");

				Bootbox.Error("ha ocurrido un grave error");
*/
/*				Bootbox.Dialog("Message Text", new DialogOptions{Header="Header Text"});

				Bootbox.Dialog("Message from App", opt=>{
					opt.Header="Your Header Text";},
				bt=>bt.Add(new DialogButton(){Label="Button Text", Class="btn btn-success"} ));

				var d = new Div(null, div=>{
					div.ClassName="span3";
					new Span(div, sp=>sp.Text("!!! span !!!"));
					new TextField(div, field=>{
						field.SetPlaceHolder("just a field");

					});
					new CheckboxField(div,"Check..", cb=>{
						cb.Checked=true;
					});
					new TextArea(div, area=>{
						area.Value="cayita is amazing,  some text ...";
					});
					new Button(div, bt=>{
						bt.OnClick(evt=>Bootbox.Alert("BUTTON CLICK"));
						bt.Text("Info Button");
					
					});
				});


				Bootbox.Dialog(d, opt=>{
					opt.Header="large-modal";
					opt.Classes="modal-large";
				},
				bt=>bt.Add(new DialogButton{Label="My super Button", Callback=()=> Bootbox.Prompt("simple prompt")} ));
*/
				new Panel().Render().OnCollapseHandler( (p,cl)=>{
					("previous panel state:"+(cl?"collapsed":"expanded")).Info() ;});
				new Panel().Caption("Panel Caption I").Render();
				new Panel().Caption("Panel Caption II").Closable(true).Render();
				new Panel().Caption("Panel Caption III").Closable(true).Render();

				new Panel()
					.Caption("Panel Caption IV")
						.Closable(true)
						.OnCloseHandler(p=>{"Panel closed ".Info(); })
						.Render();


				new Panel()
					.Caption("Panel Caption V")
						.CloseIconClass("icon-th-large")
						.Closable(true)
						.CloseIconHandler(p=>{ 
							p.Caption("* V now Overlay !" );
							p.CloseIconClass("icon-remove-circle");
							p.CloseIconHandler(pn=>pn.Close());
							p.Width("auto");
							p.Height("400px");
							p.Left("10px");
							p.Top("100px");
							p.Overlay(true);
						})
						.OnCloseHandler(p=>{"panel closed ".Info(); })
						.Render();

				new Panel()
					.Caption("Overlay")
						.Left("40%")
						.Top("10%")
						.Width("auto")
						.Height("400px")
						.Overlay(true)
						.Render()
						.Append("Hello World!")
						.Append("Hello World!".Header(3))
						.Append( new Panel())
						.Append( new Panel().Append( new Button(null, bt=>{
							bt.Text("Click me");
							bt.Style.Width="100%"; bt.Style.Height="100%";
							bt.OnClick(evt=>{"button clicked!!!".Info();
							});
						})));


			});


		}

		void GetMenuItems ()
		{
			MenuItems= new List<MenuItem>();
			MenuItems.Add(new MenuItem{Title="Forms", File="modules/DemoForm.js", Class="DemoForm"});
			MenuItems.Add(new MenuItem{Title="Tables", File="modules/DemoTables.js", Class="DemoTables"});
			MenuItems.Add(new MenuItem{Title="Navbar", File="modules/DemoNavbar.js", Class="DemoNavbar"});
			MenuItems.Add(new MenuItem{Title="Navlist", File="modules/DemoNavlist.js", Class="DemoNavlist"});

		}
		
		void ShowTopNavBar()
		{
			TopNavBar= new TopNavBar(null,"Cayita.Javascript - demo","","",nav=>{

				nav.AddItem("Home");
				nav.AddItem("License");
				nav.AddItem("Contact");
				nav.AddItem("About");
			});

			TopNavBar.AddClass("navbar-inverse navbar-fixed-top").AppendTo (Document.Body);
		}
		
		void ShowMenu()
		{	
			Div.CreateContainerFluid(default(Element), fluid=>{
				Div.CreateRowFluid(fluid,  row=>{
					new Div(row,  span=>{
						span.ClassName="span2";
						new SideNavBar(span, list=>{

							list.AddHeader( "Main Menu");
							list.AddHDivider();
							foreach(var item in MenuItems){
								list.AddItem( (li,anchor)=>{
									anchor.Text(item.Title);
									anchor.OnClick(e=>{
										e.PreventDefault();
										Work.Empty();
										if(modules.Contains(item.Class))
										{
											ExecuteModule(Work.Element(), item.Class);
										}
										else
										{
											jQuery.GetScript(item.File, (o)=>{
												modules.Add(item.Class);
												ExecuteModule(Work.Element(), item.Class);
											});											
										}
									});
								});
							}
						});
					});
					
					Work= new Div(row,  work=>{
						work.ClassName="span10";
						work.ID="work";
						work.AppendChild("Welcome".Header(3));
					});
				});
			}).AppendTo(Document.Body);

		}

		[InlineCode("window[{className}]['execute']({parent})")]
		void ExecuteModule(Element parent, string className){}
				
	}
}


/*
Cayita.UI
Cayita.Data
Cayita.Plugins
Cayita.Ajax
Cayita.Extensions
*/