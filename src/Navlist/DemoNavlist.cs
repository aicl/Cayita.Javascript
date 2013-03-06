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

				var sb =new SideNavBar(div, nav=>{
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

				sb.Element().Style.MaxWidth="240px";
				sb.Element().Style.Padding="8px 0";

				new Div(div, d=>d.ID="div-log" );
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>var&nbsp;sb&nbsp;=</span><span class=""keyword"">new</span><span>&nbsp;SideNavBar(div,&nbsp;nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddHeader(<span class=""string"">""Menu""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""#""</span><span>,</span><span class=""string"">""Tables""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""#""</span><span>,</span><span class=""string"">""Form""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""#""</span><span>,</span><span class=""string"">""Navbar""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""#""</span><span>,</span><span class=""string"">""Navlist""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddHDivider();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""#""</span><span>,</span><span class=""string"">""Exit""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class=""string"">""a""</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class=""string"">""#div-log""</span><span>).Empty();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class=""string"">""#div-log""</span><span>).Text(ev.CurrentTarget.InnerText+&nbsp;</span><span class=""string"">""&nbsp;clicked""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>sb.Element().Style.MaxWidth=<span class=""string"">""240px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>sb.Element().Style.Padding=<span class=""string"">""8px&nbsp;0""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">new</span><span>&nbsp;Div(div,&nbsp;d=&gt;d.ID=</span><span class=""string"">""div-log""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">var sb =new SideNavBar(div, nav=&gt;{
	nav.AddHeader(""Menu"");
	nav.AddItem(""#"",""Tables"", (li,anchor)=&gt;{});
	nav.AddItem(""#"",""Form"", (li,anchor)=&gt;{});
	nav.AddItem(""#"",""Navbar"", (li,anchor)=&gt;{});
	nav.AddItem(""#"",""Navlist"", (li,anchor)=&gt;{});
	nav.AddHDivider();
	nav.AddItem(""#"",""Exit"", (li,anchor)=&gt;{});
	
	nav.OnClick(""a"", ev=&gt;{
		ev.PreventDefault();
		jQuery.Select(""#div-log"").Empty();
		jQuery.Select(""#div-log"").Text(ev.CurrentTarget.InnerText+ "" clicked"" );
	});
});

sb.Element().Style.MaxWidth=""240px"";
sb.Element().Style.Padding=""8px 0"";

new Div(div, d=&gt;d.ID=""div-log"" );</textarea></div>");
				
			}).AppendTo(parent);
		}
		
	}
}