using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.Javascript.UI;
using Cayita.Javascript;
using jQueryApi;

namespace Navbar
{
	[IgnoreNamespace]
	public class DemoNavlist
	{
		public DemoNavlist ()
		{
		}
		
		public static void Execute(Element parent)
		{
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new SideNavBar(div, nav=>{
					nav.AddHeader("Menu");
					nav.AddItem("#","Tables", (li,anchor)=>{});
					nav.AddItem("#","Form", (li,anchor)=>{});
					nav.AddItem("#","Navbar", (li,anchor)=>{});
					nav.AddItem("#","Navlist", (li,anchor)=>{});
					nav.AddHDivider();
					nav.AddItem("#","Exit", (li,anchor)=>{});

					nav.OnClick("a", ev=>{
						ev.PreventDefault();
						jQuery.Select("#div-log").Empty();
						jQuery.Select("#div-log").Text(ev.CurrentTarget.InnerText+ " clicked" );
					});
				});

				new Div(div, d=>d.ID="div-log" );
				
				div.Append(@"");
				
				
			}).AppendTo(parent);
		}
		
	}
}