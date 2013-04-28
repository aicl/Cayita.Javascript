using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
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
				new TopNavBar(div,"App Title",nav=>{
					nav.AddItem("Home");
					nav.AddItem("License");
					nav.AddItem("Contact");
					nav.AddItem("About");
					nav.AddItem("Config", new DropDownMenu(l=>{
						l.AddItem("Users");
						l.AddItem("Groups");
					}));

					nav.OnClick("a", ev=>{
						ev.PreventDefault();
						jQuery.Select("#div-log").Text(ev.CurrentTarget.Text()+ " clicked" );
					});

				});
				new Div(div, d=>d.ID="div-log" );

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;TopNavBar(div,</span><span class=""string"">""App&nbsp;Title""</span><span>,nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""Home""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""License""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""Contact""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""About""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class=""string"">""a""</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class=""string"">""#div-log""</span><span>).Text(ev.CurrentTarget.Text()+&nbsp;</span><span class=""string"">""&nbsp;clicked""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Div(div,&nbsp;d=&gt;d.ID=</span><span class=""string"">""div-log""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">new TopNavBar(div,""App Title"",nav=&gt;{
	nav.AddItem(""Home"");
	nav.AddItem(""License"");
	nav.AddItem(""Contact"");
	nav.AddItem(""About"");
	
	nav.OnClick(""a"", ev=&gt;{
		ev.PreventDefault();
		jQuery.Select(""#div-log"").Text(ev.CurrentTarget.Text()+ "" clicked"" );
	});
	
});
new Div(div, d=&gt;d.ID=""div-log"" );</textarea></div>");


			}).AppendTo(parent);
		}

	}
}