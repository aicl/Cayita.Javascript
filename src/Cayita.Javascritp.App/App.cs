using Cayita.Javascript.UI;
using jQueryApi;
using Cayita.Javascript;
using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

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
			});
		}

		void GetMenuItems ()
		{
			MenuItems= new List<MenuItem>();
			MenuItems.Add(new MenuItem{Title="Forms", File="modules/DemoForm.js", Class="DemoForm"});
			MenuItems.Add(new MenuItem{Title="Tables", File="modules/DemoTables.js", Class="DemoTables"});
		}
		
		void ShowTopNavBar()
		{
			TopNavBar= new TopNavBar(Document.Body,"Cayita.Javascript - demo","","",nav=>{
				ListItem.CreateNavListItem(nav,"#","Home", (li,anchor)=>{

				});
				ListItem.CreateNavListItem(nav,"#","License", (li,anchor)=>{
					
				});
				ListItem.CreateNavListItem(nav,"#","Contact", (li,anchor)=>{
					
				});
				ListItem.CreateNavListItem(nav,"#","About", (li,anchor)=>{
					
				});
			});
			
		}
		
		void ShowMenu()
		{	
			Div.CreateContainerFluid(default(Element), fluid=>{
				Div.CreateRowFluid(fluid,  row=>{
					new Div(row,  span=>{
						span.ClassName="span2";
						new SideNavBar(span, list=>{

							ListItem.CreateNavHeader(list, "Main Menu");
							foreach(var item in MenuItems){
								ListItem.CreateNavListItem(list,"#",item.Title, (li,anchor)=>{
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
						var m = Document.CreateElement("h3");
						m.InnerText="Welcome";
						work.AppendChild(m);
					});
				});
			}).AppendTo(Document.Body);

		}

		[InlineCode("window[{className}]['execute']({parent})")]
		void ExecuteModule(Element parent, string className){}
				
	}
}
