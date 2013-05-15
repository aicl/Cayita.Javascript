using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;

namespace Modals
{
	[IgnoreNamespace]
	public class DemoModals
	{
		public DemoModals ()
		{
		}
		
		public static void Execute(Element parent)
		{
			"Modals".Header (2).AppendTo (parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";

				div.Append( new Button(div,b=>{
					b.Text("Simple Modal Dialog I");
					b.OnClick(evt=> Bootbox.Dialog("Your App Text: cayita is awesome....") );
				}));

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Dialog(</span><span class=""string"">""Your&nbsp;App&nbsp;Text:&nbsp;cayita&nbsp;is&nbsp;awesome....""</span><span>);&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Dialog(""Your App Text: cayita is awesome...."");</textarea></div>");
								
			}).AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
								
				div.Append( new Button(div,b=>{
					b.Text("Simple Modal Dialog II");
					b.OnClick(evt=> Bootbox.Dialog("Your App Text: cayita is awesome....", "Cayita Dialog") );
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Dialog(</span><span class=""string"">""Your&nbsp;App&nbsp;Text:&nbsp;cayita&nbsp;is&nbsp;awesome....""</span><span>,&nbsp;</span><span class=""string"">""Cayita&nbsp;Dialog""</span><span>)&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Dialog(""Your App Text: cayita is awesome...."", ""Cayita Dialog"")</textarea></div>");
				
				
			}).AppendTo(parent);


			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div,b=>{
					b.Text("Custom Dialog I");
					b.OnClick(evt=>{

						Bootbox.Dialog("Message from App",opt=>{
							opt.Header="Your Header Text";
							opt.OnEscape=()=> "ESC pressed".LogInfo();
						},
						bt=>bt.Add( new DialogButton(){
							Label="OK", 
							Class="btn btn-success",
							Callback= ()=> "OK clicked".LogInfo()
						}));

					});
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Dialog(</span><span class=""string"">""Message&nbsp;from&nbsp;App""</span><span>,opt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.Header=<span class=""string"">""Your&nbsp;Header&nbsp;Text""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.OnEscape=()=&gt;&nbsp;<span class=""string"">""ESC&nbsp;pressed""</span><span>.LogInfo();&nbsp;&nbsp;</span></span></li><li class=""""><span>},&nbsp;&nbsp;</span></li><li class=""alt""><span>bt=&gt;bt.Add(&nbsp;<span class=""keyword"">new</span><span>&nbsp;DialogButton(){&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;Label=<span class=""string"">""OK""</span><span>,&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;Class=<span class=""string"">""btn&nbsp;btn-success""</span><span>,&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;Callback=&nbsp;()=&gt;&nbsp;<span class=""string"">""OK&nbsp;clicked""</span><span>.LogInfo()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>}));&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Dialog(""Message from App"",opt=&gt;{
	opt.Header=""Your Header Text"";
	opt.OnEscape=()=&gt; ""ESC pressed"".LogInfo();
},
bt=&gt;bt.Add( new DialogButton(){
	Label=""OK"", 
	Class=""btn btn-success"",
	Callback= ()=&gt; ""OK clicked"".LogInfo()
}));</textarea></div>");
				
				
			}).AppendTo(parent);
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div, b=>{
					b.Text("Custom Dialog II");
					b.OnClick(evt=>{

						var d = new Div(null, dd=>{
							dd.ClassName="span3";
							new TextField(dd, field=>field.PlaceHolder("Your Name"));
							new CheckboxField(dd,(cbl,cbi )=>{
								cbl.Text("I like cayita"); 
								cbi.Checked=true; cbi.Disabled=true;
							});
							new TextArea(dd, area=>	area.Value="cayita is amazing ...");
						});
												
						Bootbox.Dialog(d, opt=>{
							opt.Header="large-modal";
							opt.Classes="modal-large";
							opt.OnEscape= ()=> "ESC pressed".LogInfo();
						},
						bt=>{
							bt.Add(new DialogButton{
								Label="Cancel",
								Callback=()=> "Cancel pressed. Click here to delete message".LogError()
							});
							bt.Add( new DialogButton{
								Label="Save",
								Callback= ()=> "Save pressed".LogSuccess()
							});
						});
					});
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>var&nbsp;d&nbsp;=&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;Div(</span><span class=""keyword"">null</span><span>,&nbsp;dd=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;dd.ClassName=<span class=""string"">""span3""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(dd,&nbsp;field=&gt;field.PlaceHolder(</span><span class=""string"">""Your&nbsp;Name""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(dd,(cbl,cbi&nbsp;)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbl.Text(<span class=""string"">""I&nbsp;like&nbsp;cayita""</span><span>);&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbi.Checked=<span class=""keyword"">true</span><span>;&nbsp;cbi.Disabled=</span><span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextArea(dd,&nbsp;area=&gt;&nbsp;&nbsp;area.Value=</span><span class=""string"">""cayita&nbsp;is&nbsp;amazing&nbsp;...""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>Bootbox.Dialog(d,&nbsp;opt=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.Header=<span class=""string"">""large-modal""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.Classes=<span class=""string"">""modal-large""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.OnEscape=&nbsp;()=&gt;&nbsp;<span class=""string"">""ESC&nbsp;pressed""</span><span>.LogInfo();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>},&nbsp;&nbsp;</span></li><li class=""""><span>bt=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Add(<span class=""keyword"">new</span><span>&nbsp;DialogButton{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label=<span class=""string"">""Cancel""</span><span>,&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Callback=()=&gt;&nbsp;<span class=""string"">""Cancel&nbsp;pressed.&nbsp;Click&nbsp;here&nbsp;to&nbsp;delete&nbsp;message""</span><span>.LogError()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Add(&nbsp;<span class=""keyword"">new</span><span>&nbsp;DialogButton{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label=<span class=""string"">""Save""</span><span>,&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Callback=&nbsp;()=&gt;&nbsp;<span class=""string"">""Save&nbsp;pressed""</span><span>.LogSuccess()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">var d = new Div(null, dd=&gt;{
	dd.ClassName=""span3"";
	new TextField(dd, field=&gt;field.PlaceHolder(""Your Name""));
	new CheckboxField(dd,(cbl,cbi )=&gt;{
		cbl.Text(""I like cayita""); 
		cbi.Checked=true; cbi.Disabled=true;
	});
	new TextArea(dd, area=&gt;	area.Value=""cayita is amazing ..."");
});

Bootbox.Dialog(d, opt=&gt;{
	opt.Header=""large-modal"";
	opt.Classes=""modal-large"";
	opt.OnEscape= ()=&gt; ""ESC pressed"".LogInfo();
},
bt=&gt;{
	bt.Add(new DialogButton{
		Label=""Cancel"",
		Callback=()=&gt; ""Cancel pressed. Click here to delete message"".LogError()
	});
	bt.Add( new DialogButton{
		Label=""Save"",
		Callback= ()=&gt; ""Save pressed"".LogSuccess()
	});
});
</textarea></div>");


			}).AppendTo(parent);


			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div,b=>{
					b.Text("Error Dialog ");
					b.OnClick(evt=> Bootbox.Error("You must use cayita", "Error !!!") );
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Error(</span><span class=""string"">""You&nbsp;must&nbsp;use&nbsp;cayita""</span><span>,&nbsp;</span><span class=""string"">""Error&nbsp;!!!""</span><span>)&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Error(""You must use cayita"", ""Error !!!"")</textarea></div>");
				
			}).AppendTo(parent);


			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div,b=>{
					b.Text("Alert ");
					b.OnClick(evt=>
					          Bootbox.Alert("User is over quota"));
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Alert(</span><span class=""string"">""User&nbsp;is&nbsp;over&nbsp;quota""</span><span>)&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Alert(""User is over quota"")</textarea></div>");
				
			}).AppendTo(parent);


			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div,b=>{
					b.Text("Prompt");
					b.OnClick(evt=>
					          Bootbox.Prompt("Your name?", callback:r=>("Your name is:"+ r).LogInfo()));
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Prompt(</span><span class=""string"">""Your&nbsp;name?""</span><span>,&nbsp;callback:r=&gt;(</span><span class=""string"">""Your&nbsp;name&nbsp;is:""</span><span>+&nbsp;r).LogInfo())&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Prompt(""Your name?"", callback:r=&gt;(""Your name is:""+ r).LogInfo())</textarea></div>");
				
			}).AppendTo(parent);


			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div,b=>{
					b.Text("Confirm");
					b.OnClick(evt=> Bootbox.Confirm("Are you sure?", callback: res=> ((res?"OK":"Cancel")+" pressed").LogInfo() ) );
				}));
				
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Bootbox.Confirm(</span><span class=""string"">""Are&nbsp;you&nbsp;sure?""</span><span>,&nbsp;callback:&nbsp;res=&gt;&nbsp;(res?</span><span class=""string"">""OK""</span><span>:</span><span class=""string"">""Cancel""</span><span>+</span><span class=""string"">""&nbsp;pressed""</span><span>).LogInfo()&nbsp;)&nbsp;&nbsp;</span></span></li></ol><textarea style=""display:none;"" class=""originalCode"">Bootbox.Confirm(""Are you sure?"", callback: res=&gt; (res?""OK"":""Cancel""+"" pressed"").LogInfo() )</textarea></div>");
				
			}).AppendTo(parent);


		}
		
	}
}
