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
				new NavBar(div,"App Title",nav=>{
					nav.AddItem("Home");
					nav.AddItem("License");
					nav.AddItem("Contact");
					nav.AddItem("Config", new DropDownMenu(l=>{
						l.AddItem("Users");
						l.AddItem("Groups");
						l.AddItem(new DropDownSubmenu("More Options", sm=>{
							sm.AddItem("Option 1");
							sm.AddItem("Option 2");
						}));
					}));
					nav.AddItem("About");

					nav.OnClick("a", ev=>{
						ev.PreventDefault();
						jQuery.Select("#div-log").Text(ev.CurrentTarget.Text()+ " clicked" );
					});

				});
				new Div(div, d=>d.ID="div-log" );

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;NavBar(div,</span><span class=""string"">""App&nbsp;Title""</span><span>,nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""Home""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""License""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""Contact""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""Config""</span><span>,&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;Menu(l=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.AddItem(<span class=""string"">""Users""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.AddItem(<span class=""string"">""Groups""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.AddItem(<span class=""keyword"">new</span><span>&nbsp;SubMenu(</span><span class=""string"">""More&nbsp;Options""</span><span>,&nbsp;sm=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sm.AddItem(<span class=""string"">""Option&nbsp;1""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sm.AddItem(<span class=""string"">""Option&nbsp;2""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class=""string"">""About""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class=""string"">""a""</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class=""string"">""#div-log""</span><span>).Text(ev.CurrentTarget.Text()+&nbsp;</span><span class=""string"">""&nbsp;clicked""</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new NavBar(div,""App Title"",nav=&gt;{
	nav.AddItem(""Home"");
	nav.AddItem(""License"");
	nav.AddItem(""Contact"");
	nav.AddItem(""Config"", new Menu(l=&gt;{
		l.AddItem(""Users"");
		l.AddItem(""Groups"");
		l.AddItem(new SubMenu(""More Options"", sm=&gt;{
			sm.AddItem(""Option 1"");
			sm.AddItem(""Option 2"");
		}));
	}));
	nav.AddItem(""About"");
	
	nav.OnClick(""a"", ev=&gt;{
		ev.PreventDefault();
		jQuery.Select(""#div-log"").Text(ev.CurrentTarget.Text()+ "" clicked"" );
	});
	
});</textarea></div>");


			}).AppendTo(parent);
		}

	}
}