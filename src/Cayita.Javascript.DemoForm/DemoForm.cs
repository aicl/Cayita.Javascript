using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;
using jQueryApi;
using Cayita.Javascript.Plugins;

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
			Document.CreateElement("h3").Text("Search form").AppendTo(parent);

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
			Document.CreateElement("h3").Text("Inline Form").AppendTo(parent);

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

			Document.CreateElement("h3").Text("Horizontal Form").AppendTo(parent);
			
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

			//----------------------------------

			Document.CreateElement("h2").Text("Samples").AppendTo(parent);
			Document.CreateElement("h3").Text("Login Form").AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";

				Div.CreateContainer(div, container=>{
					Div.CreateRow(container, row=>{

						new Div(row,element=>{
							element.ClassName="span4 offset3 well";
							new Legend(element,  l=>{
								l.InnerText="Login Form";
							});
							
							new Form(element, fe=>{
								Div.CreateControlGroup(fe,cg=>{
									new InputText(cg, pe=>{
										pe.SetPlaceHolder("your username");
										pe.Name="UserName";
										pe.ClassName="span12";
										pe.SetRequired();
										pe.SetMinLength(8);
									});
								});
																
								Div.CreateControlGroup(fe, cg=>{
									new InputPassword(cg, pe=>{
										pe.SetPlaceHolder("your password");
										pe.Name="Password";
										pe.ClassName="span12";
										pe.SetRequired();
										pe.SetMinLength(6);
									});
								});

								new CheckboxField(fe, (lb, cb)=>{
									lb.Text("Remember me");
									cb.Name="Remember";
								});

								new SubmitButton(fe, b=>{
									b.JQuery().Text("Login");
									b.AddClass("btn-info btn-block");
									b.LoadingText("  authenticating ...");
								});

								fe.Validate( new ValidateOptions()
								            .SetSubmitHandler(f=>{
									var bt =(ButtonElement)f.JQuery("button[type=submit]")[0];
									bt.ShowLoadingText();
									Window.SetTimeout(()=>{
										bt.ResetLoadingText();
										Div.CreateAlertSuccessAfter(f,"Welcome : "+ f.JQuery("input[name=UserName]").GetValue());
										f.Reset();
									}, 1000);
								}));
							});
						});
					});
				});	

				//
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>Div.CreateContainer(div,&nbsp;container=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRow(container,&nbsp;row=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(row,element=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;element.ClassName=<span class=""string"">""span4&nbsp;offset3&nbsp;well""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Legend(element,&nbsp;&nbsp;l=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.InnerText=<span class=""string"">""Login&nbsp;Form""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Form(element,&nbsp;fe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateControlGroup(fe,cg=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(cg,&nbsp;pe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetPlaceHolder(<span class=""string"">""your&nbsp;username""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Name=<span class=""string"">""UserName""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.ClassName=<span class=""string"">""span12""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetRequired();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetMinLength(8);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateControlGroup(fe,&nbsp;cg=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputPassword(cg,&nbsp;pe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetPlaceHolder(<span class=""string"">""your&nbsp;password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Name=<span class=""string"">""Password""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.ClassName=<span class=""string"">""span12""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetRequired();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetMinLength(6);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(fe,&nbsp;(lb,&nbsp;cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class=""string"">""Remember&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.Name=<span class=""string"">""Remember""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(fe,&nbsp;b=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.JQuery().Text(<span class=""string"">""Login""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.AddClass(<span class=""string"">""btn-info&nbsp;btn-block""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.LoadingText(<span class=""string"">""&nbsp;&nbsp;authenticating&nbsp;...""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fe.Validate(&nbsp;<span class=""keyword"">new</span><span>&nbsp;ValidateOptions()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SetSubmitHandler(f=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bt&nbsp;=(ButtonElement)f.JQuery(<span class=""string"">""button[type=submit]""</span><span>)[0];&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ShowLoadingText();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Window.SetTimeout(()=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ResetLoadingText();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessAfter(f,<span class=""string"">""Welcome&nbsp;:&nbsp;""</span><span>+&nbsp;f.JQuery(</span><span class=""string"">""input[name=UserName]""</span><span>).GetValue());&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Reset();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;1000);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">Div.CreateContainer(div, container=&gt;{
	Div.CreateRow(container, row=&gt;{
			new Div(row,element=&gt;{
			element.ClassName=""span4 offset3 well"";
			new Legend(element,  l=&gt;{
				l.InnerText=""Login Form"";
			});
					
			new Form(element, fe=&gt;{
				Div.CreateControlGroup(fe,cg=&gt;{
					new InputText(cg, pe=&gt;{
						pe.SetPlaceHolder(""your username"");
						pe.Name=""UserName"";
						pe.ClassName=""span12"";
						pe.SetRequired();
						pe.SetMinLength(8);
					});
				});
																
				Div.CreateControlGroup(fe, cg=&gt;{
					new InputPassword(cg, pe=&gt;{
						pe.SetPlaceHolder(""your password"");
						pe.Name=""Password"";
						pe.ClassName=""span12"";
						pe.SetRequired();
						pe.SetMinLength(6);
					});
				});

				new CheckboxField(fe, (lb, cb)=&gt;{
					lb.Text(""Remember me"");
					cb.Name=""Remember"";
				});

				new SubmitButton(fe, b=&gt;{
					b.JQuery().Text(""Login"");
					b.AddClass(""btn-info btn-block"");
					b.LoadingText(""  authenticating ..."");
				});

				fe.Validate( new ValidateOptions()
				            .SetSubmitHandler(f=&gt;{
					var bt =(ButtonElement)f.JQuery(""button[type=submit]"")[0];
					bt.ShowLoadingText();
					Window.SetTimeout(()=&gt;{
						bt.ResetLoadingText();
						Div.CreateAlertSuccessAfter(f,""Welcome : ""+ f.JQuery(""input[name=UserName]"").GetValue());
						f.Reset();
					}, 1000);
				}));
			});
		});
	});
});</textarea></div>");
			}).AppendTo(parent);


			//-----------------------------------

			Document.CreateElement("h3").Text("Contact Form").AppendTo(parent);

			new Div(null, ex=>{
				ex.ClassName="bs-docs-example";
				Div.CreateContainer(ex, container=>{
					new Form( container, f=>{
						f.AddClass("well span8");
						Div.CreateRowFluid(f, row=>{
							new Div(row, sp=>{
								sp.ClassName="span5";
								new Label(sp, l=>l.Text("FirstName"));
								new InputText(sp, i=>{i.ClassName="span12"; i.SetRequired();});
								new Label(sp, l=>l.Text("LastName"));
								new InputText(sp, i=>i.ClassName="span12");
								new Label(sp, l=>l.Text("Email address"));
								new InputText(sp, i=>i.ClassName="span12");
								new Label(sp, l=>l.Text("Subject"));

								new HtmlSelect(sp, sl=>{
									sl.Name="Subject";sl.ClassName="span12";
									new HtmlOption(sl, opt=>{opt.Value=""; opt.Text("Choose One:");});
									new HtmlOption(sl, opt=>{opt.Value="1"; opt.Text("General Customer Service");});
									new HtmlOption(sl, opt=>{opt.Value="2"; opt.Text("Suggestions");});
									new HtmlOption(sl, opt=>{opt.Value="3"; opt.Text("Product Support");});
									new HtmlOption(sl, opt=>{opt.Value="4"; opt.Text("Bug");});
								});
							});

							new Div(row, sp=>{
								sp.ClassName="span7";
								new Label(sp, l=>l.Text("Message"));
								var ta =(AreaElement) Document.CreateElement("textarea");
								ta.ClassName="input-xlarge span12";
								ta.SetAttribute("rows",11);
								sp.Append(ta);
								
							});
							new SubmitButton(row, bt=>{
								bt.AddClass("btn-primary pull-right");
								bt.Text("Send");
							});

							f.Validate(new ValidateOptions().SetSubmitHandler(vf=>{
								Div.CreateAlertSuccessBefore(vf.FirstChild,"message sent");
								vf.Reset();
							}).AddRule((rf,ms)=>{
								rf.Element= (SelectElement) f.JQuery("[name=Subject]")[0];
								rf.Rule.Required();
								ms.Required("choose an option");
							}));
						});
					});
				});

				ex.Append(@"");
			}).AppendTo(parent);



			//-----------------------------------
			/*
<form class="well span8">
  <div class="row">
		<div class="span3">
			<label>First Name</label>
			<input type="text" class="span3" placeholder="Your First Name">
			<label>Last Name</label>
			<input type="text" class="span3" placeholder="Your Last Name">
			<label>Email Address</label>
			<input type="text" class="span3" placeholder="Your email address">
			<label>Subject
			<select id="subject" name="subject" class="span3">
				<option value="na" selected="">Choose One:</option>
				<option value="service">General Customer Service</option>
				<option value="suggestions">Suggestions</option>
				<option value="product">Product Support</option>
			</select>
			</label>
		</div>
		<div class="span5">
			<label>Message</label>
			<textarea name="message" id="message" class="input-xlarge span5" rows="10"></textarea>
		</div>
	
		<button type="submit" class="btn btn-primary pull-right">Send</button>
	</div>
</form>
			 */
		}
		/*
		List<SubjectOption>


		class SubjectOption
		{
			public SubjectOption(){}
			public int Id {get;set;}
			public string Subject {get;set;}
		}
*/
	}
}

