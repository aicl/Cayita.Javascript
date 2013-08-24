using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Html;
using System.Collections.Generic;
using Cayita;

namespace Cayita.Demo
{

	[IgnoreNamespace]
	public class MenuItem
	{
		public string Class {get;set;}
		public string Title {get;set;}
		public string File {get;set;}

	}

	[IgnoreNamespace]
	public partial class App
	{
		NavBar TopNavBar {get;set;}
		List<MenuItem> MenuItems { get; set; }
		Div Work { get; set; }

		List<string>  modules = new List<string>();

		public static void Main ()
		{
			jQuery.OnDocumentReady (() => {
				var app = new App ();
				app.ShowTopNavBar();
				app.BuildMenuItems();
				app.ShowMenu();
				app.GoHome();
			});

		}

		void BuildMenuItems ()
		{
			MenuItems= new List<MenuItem>();
			MenuItems.Add(new MenuItem{Title="Forms", File="modules/DemoForm.js", Class="DemoForm"});
			MenuItems.Add(new MenuItem{Title="Tables", File="modules/DemoTables.js", Class="DemoTables"});
			MenuItems.Add(new MenuItem{Title="Navbar", File="modules/DemoNavbar.js", Class="DemoNavbar"});
			MenuItems.Add(new MenuItem{Title="Navlist", File="modules/DemoNavlist.js", Class="DemoNavlist"});
			MenuItems.Add(new MenuItem{Title="Modals", File="modules/DemoModals.js", Class="DemoModals"});
			MenuItems.Add(new MenuItem{Title="Panels", File="modules/DemoPanels.js", Class="DemoPanels"});
			MenuItems.Add(new MenuItem{Title="SearchBox", File="modules/DemoSearchBox.js", Class="DemoSearchBox"});
			MenuItems.Add(new MenuItem{Title="TabPanel", File="modules/DemoTabPanel.js", Class="DemoTabPanel"});
			MenuItems.Add(new MenuItem{Title="File Upload", File="modules/DemoFileUpload.js", Class="DemoFileUpload"});
			MenuItems.Add(new MenuItem{Title="Mix", File="modules/DemoMix.js", Class="DemoMix"});
		}

		void ShowMenu()
		{	
			UI.CreateContainerFluid (fluid=>{
				UI.CreateRowFluid(fluid, row=>{

					new Div(row,span=>{
						span.ClassName="span2";
						var navlist = new NavList(span);
						navlist.Header="Main Menu";
						navlist.AddDivider();

						foreach(var item in MenuItems){
							navlist.Add(item.Title, handler:e=>{
								e.PreventDefault();

								Work.Empty();
								if(modules.Contains(item.Class))
								{
									ExecuteModule(Work, item.Class);
								}
								else
								{
									jQuery.GetScript(item.File, (o)=>{
										modules.Add(item.Class);
										ExecuteModule(Work, item.Class);
									});											
								}


							});
						}

					});

					Work = new Div(row, w=>{
						w.ID="work";
						w.ClassName="span10";
						w.Append("Welcome".Header(3));

					});

				});

				Document.Body.AppendChild(fluid);
			});

		}

		void ShowTopNavBar()
		{
			TopNavBar = new NavBar ();
			TopNavBar.BrandText = "Cayita Demo";
			TopNavBar.Add ("Home", handler: GoHomeClick);
			TopNavBar.Add ("License", handler: GoLicense);
			TopNavBar.Add ("Contact", handler: GoContact);
			TopNavBar.Add ("About", handler: GoAbout);
			TopNavBar.Inverse = true;
			TopNavBar.AddClass("navbar-fixed-top");
			Document.Body.AppendChild (TopNavBar);
		}

		[InlineCode("window[{className}]['execute']({parent})")]
		void ExecuteModule(Atom parent, string className){}


	}
}
