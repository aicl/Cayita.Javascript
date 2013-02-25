using Cayita.Javascript.UI;
using jQueryApi;
using Cayita.Javascript;
using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita.Javascritp.App
{
	[IgnoreNamespace]
	public class MenuItem{
		public string Title {get;set;}
		public string File {get;set;}
	}

	[IgnoreNamespace]
	public class App
	{
		TopNavBar TopNavBar {get;set;}
		Div Work {get;set;}

		List<MenuItem> MenuItems {get;set;}


		public static void Main ()
		{
			jQuery.OnDocumentReady( ()=>{
				
				var app = new App();
				app.LoadMenuItems();
				app.ShowTopNavBar();
				app.ShowMenu();
				
			});
		}

		void LoadMenuItems ()
		{
			MenuItems= new List<MenuItem>();
			MenuItems.Add(new MenuItem{Title="Forms", File="Forms.js"});
			MenuItems.Add(new MenuItem{Title="Tables", File="Tables.js"});
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
			
			var um= Div.CreateContainerFluid(default(Element), fluid=>{
				Div.CreateRowFluid(fluid,  row=>{
					new Div(row,  span=>{
						span.ClassName="span2";
						new SideNavBar(span, list=>{
							ListItem.CreateNavHeader(list, "Main Menu");
							foreach(var item in MenuItems){
								ListItem.CreateNavListItem(list,"#",item.Title, (li,anchor)=>{
									anchor.JQuery().Click(e=>{
										e.PreventDefault();
										Work.Empty();
										jQuery.GetScript(item.File, (o)=>{
											ExecuteModule(Work.Element());
										});											
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
			});
			um.AppendTo(Document.Body);
		}

		[InlineCode("MainModule.execute({parent})")]
		void ExecuteModule(Element parent){}
			
	
	}
}
