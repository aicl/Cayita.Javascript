using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;
using jQueryApi;

namespace Cayita.Javascript.DemoForm
{
	[IgnoreNamespace]
	public class DemoForm
	{
		public DemoForm(){}

		public static void Execute(Element parent)
		{

			Document.CreateElement("h2").Text("Default styles").AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					new FieldSet(f, fs=>{
						new Legend(fs, lg=> lg.Text("Legend") );
						new Label(fs, lb=> lb.Text("Label Name"));
						new InputText(fs, input=> input.SetPlaceHolder("Type something"));
						new Span(fs, sp =>{ sp.ClassName="help-block"; sp.Text("Example block-level help text here") ;});
						new CheckboxField(fs, (lb,cb)=>{
							lb.Text("check me out");
						});
						new SubmitButton(fs, bt=>{
							bt.Text("Submit");
							bt.JQuery().Click(ev=>{ev.PreventDefault();});
						});
					});
				});

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;FieldSet(f,&nbsp;fs=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Legend(fs,&nbsp;lg=&gt;&nbsp;lg.Text(</span><span class=""string"">""Legend""</span><span>)&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Label(fs,&nbsp;lb=&gt;&nbsp;lb.Text(</span><span class=""string"">""Label&nbsp;Name""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(fs,&nbsp;input=&gt;&nbsp;input.SetPlaceHolder(</span><span class=""string"">""Type&nbsp;something""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Span(fs,&nbsp;sp&nbsp;=&gt;{&nbsp;sp.ClassName=</span><span class=""string"">""help-block""</span><span>;&nbsp;sp.Text(</span><span class=""string"">""Example&nbsp;block-level&nbsp;help&nbsp;text&nbsp;here""</span><span>)&nbsp;;});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(fs,&nbsp;(lb,cb)=&gt;{lb.Text(</span><span class=""string"">""check&nbsp;me&nbsp;out""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(fs,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Submit""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
  new FieldSet(f, fs=&gt;{
    new Legend(fs, lg=&gt; lg.Text(""Legend"") );
    new Label(fs, lb=&gt; lb.Text(""Label Name""));
    new InputText(fs, input=&gt; input.SetPlaceHolder(""Type something""));
    new Span(fs, sp =&gt;{ sp.ClassName=""help-block""; sp.Text(""Example block-level help text here"") ;});
    new CheckboxField(fs, (lb,cb)=&gt;{lb.Text(""check me out"");});
    new SubmitButton(fs, bt=&gt;{
        bt.Text(""Submit"");
        bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});
    });
  });
});</textarea></div>");

			}).AppendTo(parent);

			//------------------

			Document.CreateElement("h2").Text("Optional Layouts").AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					f.ClassName="form-search";
					new InputText(f, input=>{
						input.ClassName="input-medium search-query";
					});
					new SubmitButton(f, bt=>{
						bt.Text("Search");
						bt.JQuery().Click(ev=>{ev.PreventDefault();});
					});
				});
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-search""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class=""string"">""input-medium&nbsp;search-query""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Search""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
	f.ClassName=""form-search"";
	new InputText(f, input=&gt;{
		input.ClassName=""input-medium search-query"";
	});
	new SubmitButton(f, bt=&gt;{
		bt.Text(""Search"");
		bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});
	});
});</textarea></div>");
			}).AppendTo(parent);

			//---------------------------------
			Document.CreateElement("h2").Text("Inline Form").AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					f.ClassName="form-inline";
					new InputText(f, input=>{
						input.ClassName="input-small";
						input.SetPlaceHolder("Email");
					});
					new InputPassword(f, input=>{
						input.ClassName="input-small";
						input.SetPlaceHolder("Password");
					});
					new Label(f, lb=>{
						new InputCheckbox(lb, cb=>{});
						lb.Append("Remember me");
						lb.ClassName="checkbox";
					});
					new SubmitButton(f, bt=>{
						bt.Text("Sign in");
						bt.JQuery().Click(ev=>{ev.PreventDefault();});
					});
				});
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-inline""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class=""string"">""input-small""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputPassword(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class=""string"">""input-small""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class=""string"">""Password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Label(f,&nbsp;lb=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputCheckbox(lb,&nbsp;cb=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Append(<span class=""string"">""Remember&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.ClassName=<span class=""string"">""checkbox""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Sign&nbsp;in""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
	f.ClassName=""form-inline"";
	new InputText(f, input=&gt;{
		input.ClassName=""input-small"";
		input.SetPlaceHolder(""Email"");
	});
	new InputPassword(f, input=&gt;{
		input.ClassName=""input-small"";
		input.SetPlaceHolder(""Password"");
	});
	new Label(f, lb=&gt;{
		new InputCheckbox(lb, cb=&gt;{});
		lb.Append(""Remember me"");
		lb.ClassName=""checkbox"";
	});
	new SubmitButton(f, bt=&gt;{
		bt.Text(""Sign in"");
		bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});
	});
});</textarea></div>");
			}).AppendTo(parent);

			//--------------------------------

			Document.CreateElement("h2").Text("Horizontal Form").AppendTo(parent);
			
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					f.ClassName="form-horizontal";
					new TextField(f, (label,input)=>{
						label.Text("Email");
						input.SetPlaceHolder("Email");
					});
					new TextField(f, (label,input)=>{
						label.Text("Password");
						input.Type="password";
						input.SetPlaceHolder("Password");
					});
					new CheckboxField(f, (lb,cb)=>{
						lb.Text("Remember me");
						new SubmitButton(lb.ParentNode, bt=>{
							bt.Text("Sign in");
							bt.JQuery().Click(ev=>{ev.PreventDefault();});
						});
					});

				});
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-horizontal""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class=""string"">""Password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.Type=<span class=""string"">""password""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class=""string"">""Password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(f,&nbsp;(lb,cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class=""string"">""Remember&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(lb.ParentNode,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Sign&nbsp;in""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
	f.ClassName=""form-horizontal"";
	new TextField(f, (label,input)=&gt;{
		label.Text(""Email"");
		input.SetPlaceHolder(""Email"");
	});
	new TextField(f, (label,input)=&gt;{
		label.Text(""Password"");
		input.Type=""password"";
		input.SetPlaceHolder(""Password"");
	});
	new CheckboxField(f, (lb,cb)=&gt;{
		lb.Text(""Remember me"");
		new SubmitButton(lb.ParentNode, bt=&gt;{
			bt.Text(""Sign in"");
			bt.JQuery().Click(ev=&gt;{ev.PreventDefault();});
		});
	});
});</textarea></div>");
			}).AppendTo(parent);


			//--------------------------------

			/*
*/
		}
		
	}
}

