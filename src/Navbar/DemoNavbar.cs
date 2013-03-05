using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.Javascript.UI;
using Cayita.Javascript;
using jQueryApi;

namespace Navbar
{
	[IgnoreNamespace]
	public class DemoNavbar
	{
		public DemoNavbar ()
		{
		}

		public static void Execute(Element parent)
		{
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new TopNavBar(div,"App Title","","",nav=>{
					ListItem.CreateNavListItem(nav,"#","Home", (li,anchor)=>{});
					ListItem.CreateNavListItem(nav,"#","License", (li,anchor)=>{});
					ListItem.CreateNavListItem(nav,"#","Contact", (li,anchor)=>{});
					ListItem.CreateNavListItem(nav,"#","About", (li,anchor)=>{});

					nav.OnClick("a", ev=>{
						jQuery.Select("#div-log").Empty();
						jQuery.Select("#div-log").Text(ev.CurrentTarget.InnerText+ " clicked" );
					});

				});
				new Div(div, d=>d.ID="div-log" );

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;TopNavBar(div,</span><span class=""string"">""App&nbsp;Title""</span><span>,</span><span class=""string"">""""</span><span>,</span><span class=""string"">""""</span><span>,nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;ListItem.CreateNavListItem(nav,<span class=""string"">""#""</span><span>,</span><span class=""string"">""Home""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;ListItem.CreateNavListItem(nav,<span class=""string"">""#""</span><span>,</span><span class=""string"">""License""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;ListItem.CreateNavListItem(nav,<span class=""string"">""#""</span><span>,</span><span class=""string"">""Contact""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;ListItem.CreateNavListItem(nav,<span class=""string"">""#""</span><span>,</span><span class=""string"">""About""</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class=""string"">""a""</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class=""string"">""#div-log""</span><span>).Empty();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class=""string"">""#div-log""</span><span>).Text(ev.CurrentTarget.InnerText+&nbsp;</span><span class=""string"">""&nbsp;clicked""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Div(div,&nbsp;d=&gt;d.ID=</span><span class=""string"">""div-log""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">new TopNavBar(div,""App Title"","""","""",nav=&gt;{
	ListItem.CreateNavListItem(nav,""#"",""Home"", (li,anchor)=&gt;{});
	ListItem.CreateNavListItem(nav,""#"",""License"", (li,anchor)=&gt;{});
	ListItem.CreateNavListItem(nav,""#"",""Contact"", (li,anchor)=&gt;{});
	ListItem.CreateNavListItem(nav,""#"",""About"", (li,anchor)=&gt;{});
	
	nav.OnClick(""a"", ev=&gt;{
		jQuery.Select(""#div-log"").Empty();
		jQuery.Select(""#div-log"").Text(ev.CurrentTarget.InnerText+ "" clicked"" );
	});
	
});
new Div(div, d=&gt;d.ID=""div-log"" );</textarea></div>");


			}).AppendTo(parent);
		}

	}
}