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

			jQuery.OnDocumentReady (() => {

				var app = new App ();
				app.GetMenuItems ();
				app.ShowTopNavBar ();
				app.ShowMenu ();

			});

		}

		void GetMenuItems ()
		{
			MenuItems= new List<MenuItem>();
			MenuItems.Add(new MenuItem{Title="Forms", File="modules/DemoForm.js", Class="DemoForm"});
			MenuItems.Add(new MenuItem{Title="Tables", File="modules/DemoTables.js", Class="DemoTables"});
			MenuItems.Add(new MenuItem{Title="Navbar", File="modules/DemoNavbar.js", Class="DemoNavbar"});
			MenuItems.Add(new MenuItem{Title="Navlist", File="modules/DemoNavlist.js", Class="DemoNavlist"});
			MenuItems.Add(new MenuItem{Title="Modals", File="modules/DemoModals.js", Class="DemoModals"});
			MenuItems.Add(new MenuItem{Title="Panels", File="modules/DemoPanels.js", Class="DemoPanels"});
			MenuItems.Add(new MenuItem{Title="SearchBox", File="modules/DemoSearchBox.js", Class="DemoSearchBox"});

		}
		
		void ShowTopNavBar()
		{
			TopNavBar= new TopNavBar(null,"Cayita.Javascript - demo","","",nav=>{

				nav.AddItem((l,a)=>{
					a.Text("Home");
					a.OnClick(GoHome);
				});
				nav.AddItem((l,a)=>{
					a.Text("Licence");
					a.OnClick(GoLicence);
				});
				nav.AddItem((l,a)=>{
					a.Text("Contact");
					a.OnClick(GoContact);
				});
				nav.AddItem((l,a)=>{
					a.Text("About");
					a.OnClick(GoAbout);
				});

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


		void GoHome(jQueryEvent evt)
		{
			"Home".LogInfo ();
		}
		
		void GoLicence(jQueryEvent evt)
		{
			"Licence".LogInfo ();
		}
		
		void GoContact(jQueryEvent evt)
		{
			"Contact".LogInfo ();
		}
		
		void GoAbout(jQueryEvent evt)
		{
			"About".LogInfo ();
		}

	}
}

