using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;
using Cayita.Plugins;
using Cayita.UI;

namespace Cayita.Javascript.DemoForm
{
	[IgnoreNamespace]
	public class DemoForm
	{
		public DemoForm(){}

		public static void Execute(Element parent)
		{

			"Default styles".Header (2).AppendTo (parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					new FieldSet(f, fs=>{
						new Legend(fs, lg=> lg.Text("Legend") );
						new Label(fs, lb=> lb.Text("Label Name"));
						new InputText(fs, input=> input.PlaceHolder("Type something"));
						new Span(fs, sp =>{ sp.ClassName="help-block"; sp.Text("Example block-level help text here") ;});
						new CheckboxField(fs, (lb,cb)=>{
							lb.Text("check me out");
						});
						new SubmitButton(fs, bt=>{
							bt.Text("Submit");
							bt.OnClick(ev=>{ev.PreventDefault();});
						});
					});
				});

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;FieldSet(f,&nbsp;fs=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Legend(fs,&nbsp;lg=&gt;&nbsp;lg.Text(</span><span class=""string"">""Legend""</span><span>)&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Label(fs,&nbsp;lb=&gt;&nbsp;lb.Text(</span><span class=""string"">""Label&nbsp;Name""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(fs,&nbsp;input=&gt;&nbsp;input.PlaceHolder(</span><span class=""string"">""Type&nbsp;something""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Span(fs,&nbsp;sp&nbsp;=&gt;{&nbsp;sp.ClassName=</span><span class=""string"">""help-block""</span><span>;&nbsp;sp.Text(</span><span class=""string"">""Example&nbsp;block-level&nbsp;help&nbsp;text&nbsp;here""</span><span>)&nbsp;;});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(fs,&nbsp;(lb,cb)=&gt;{lb.Text(</span><span class=""string"">""check&nbsp;me&nbsp;out""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(fs,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Submit""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
  new FieldSet(f, fs=&gt;{
    new Legend(fs, lg=&gt; lg.Text(""Legend"") );
    new Label(fs, lb=&gt; lb.Text(""Label Name""));
    new InputText(fs, input=&gt; input.PlaceHolder(""Type something""));
    new Span(fs, sp =&gt;{ sp.ClassName=""help-block""; sp.Text(""Example block-level help text here"") ;});
    new CheckboxField(fs, (lb,cb)=&gt;{lb.Text(""check me out"");});
    new SubmitButton(fs, bt=&gt;{
        bt.Text(""Submit"");
        bt(ev=&gt;{ev.PreventDefault();});
    });
  });
});</textarea></div>");

			}).AppendTo(parent);

			//------------------

			"Optional Layouts".Header (2).AppendTo (parent);
			"Search form".Header(3).AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					f.ClassName="form-search";
					new InputText(f, input=>{
						input.ClassName="input-medium search-query";
					});
					new SubmitButton(f, bt=>{
						bt.Text("Search");
						bt.OnClick(ev=>{ev.PreventDefault();});
					});
				});
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-search""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class=""string"">""input-medium&nbsp;search-query""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Search""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
	f.ClassName=""form-search"";
	new InputText(f, input=&gt;{
		input.ClassName=""input-medium search-query"";
	});
	new SubmitButton(f, bt=&gt;{
		bt.Text(""Search"");
		bt.OnClick(ev=&gt;{ev.PreventDefault();});
	});
});</textarea></div>");
			}).AppendTo(parent);

			//---------------------------------
			"Inline Form".Header(3).AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					f.ClassName="form-inline";
					new InputText(f, input=>{
						input.ClassName="input-small";
						input.PlaceHolder("Email");
					});
					new InputPassword(f, input=>{
						input.ClassName="input-small";
						input.PlaceHolder("Password");
					});
					new Label(f, lb=>{
						new InputCheckbox(lb, cb=>{});
						lb.Append("Remember me");
						lb.ClassName="checkbox";
					});
					new SubmitButton(f, bt=>{
						bt.Text("Sign in");
						bt.OnClick(ev=>{ev.PreventDefault();});
					});
				});
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-inline""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class=""string"">""input-small""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputPassword(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class=""string"">""input-small""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class=""string"">""Password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Label(f,&nbsp;lb=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputCheckbox(lb,&nbsp;cb=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Append(<span class=""string"">""Remember&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.ClassName=<span class=""string"">""checkbox""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Sign&nbsp;in""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
	f.ClassName=""form-inline"";
	new InputText(f, input=&gt;{
		input.ClassName=""input-small"";
		input.PlaceHolder(""Email"");
	});
	new InputPassword(f, input=&gt;{
		input.ClassName=""input-small"";
		input.PlaceHolder(""Password"");
	});
	new Label(f, lb=&gt;{
		new InputCheckbox(lb, cb=&gt;{});
		lb.Append(""Remember me"");
		lb.ClassName=""checkbox"";
	});
	new SubmitButton(f, bt=&gt;{
		bt.Text(""Sign in"");
		bt.OnClick(ev=&gt;{ev.PreventDefault();});
	});
});</textarea></div>");
			}).AppendTo(parent);

			//--------------------------------

			"Horizontal Form".Header(3).AppendTo(parent);
			
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Form(div , f=>{
					f.ClassName="form-horizontal";
					new TextField(f, (label,input)=>{
						label.Text("Email");
						input.PlaceHolder("Email");
					});
					new TextField(f, (label,input)=>{
						label.Text("Password");
						input.Type="password";
						input.PlaceHolder("Password");
					});
					new CheckboxField(f, (lb,cb)=>{
						lb.Text("Remember me");
						new SubmitButton(lb.ParentNode, bt=>{
							bt.Text("Sign in");
							bt.OnClick(ev=>{ev.PreventDefault();});
						});
					});

				});
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-horizontal""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class=""string"">""Password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.Type=<span class=""string"">""password""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class=""string"">""Password""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(f,&nbsp;(lb,cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class=""string"">""Remember&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(lb.ParentNode,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Sign&nbsp;in""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(div , f=&gt;{
	f.ClassName=""form-horizontal"";
	new TextField(f, (label,input)=&gt;{
		label.Text(""Email"");
		input.PlaceHolder(""Email"");
	});
	new TextField(f, (label,input)=&gt;{
		label.Text(""Password"");
		input.Type=""password"";
		input.PlaceHolder(""Password"");
	});
	new CheckboxField(f, (lb,cb)=&gt;{
		lb.Text(""Remember me"");
		new SubmitButton(lb.ParentNode, bt=&gt;{
			bt.Text(""Sign in"");
			bt.OnClick(ev=&gt;{ev.PreventDefault();});
		});
	});
});</textarea></div>");
			}).AppendTo(parent);

			//----------------------------------

			"Samples".Header(2).AppendTo(parent);
			"Login Form".Header(3).AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";

				Div.CreateContainer(div, container=>{
					Div.CreateRow(container, row=>{

						new Div(row,element=>{
							element.ClassName="span4 offset3 well";
							new Legend(element,  l=>{
								l.Text("Login Form");
							});
							
							new Form(element, fe=>{
								new TextField(fe, i=>{
									i.PlaceHolder("your username");	i.Name="UserName";	i.ClassName="span12";
									i.Required();i.MinLength(8);
								});
													
								new TextField(fe, i=>{
									i.PlaceHolder("your password");	i.Name="Password"; i.ClassName="span12";
									i.Required(); i.MinLength(6);
									i.Type="password";
								});

								new CheckboxField(fe, (lb, cb)=>{
									lb.Text("Remember me");
									cb.Name="Remember";
								});

								new SubmitButton(fe, b=>{
									b.Text("Login");
									b.AddClass("btn-info btn-block");
									b.LoadingText("  authenticating ...");
								});

								fe.Validate( new ValidateOptions().SetSubmitHandler(f=>{
									var bt =f.Find<ButtonElement>("[type=submit]");
									bt.ShowLoadingText();
									Window.SetTimeout(()=>{
										bt.ResetLoadingText();
										Div.CreateAlertSuccessAfter(f,"Welcome : "+ f.FindByName<InputElement>("UserName").GetValue());
										f.Clear();
									}, 1000);
								}));
							});
						});
					});
				});	

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(element,&nbsp;fe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(fe,&nbsp;i=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.PlaceHolder(<span class=""string"">""your&nbsp;username""</span><span>);&nbsp;&nbsp;i.Name=</span><span class=""string"">""UserName""</span><span>;&nbsp;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.();i.MinLength(8);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(fe,&nbsp;i=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.PlaceHolder(<span class=""string"">""your&nbsp;password""</span><span>);&nbsp;&nbsp;i.Name=</span><span class=""string"">""Password""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Requiered();&nbsp;i.MinLength(6);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Type=<span class=""string"">""password""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(fe,&nbsp;(lb,&nbsp;cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class=""string"">""Remember&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.Name=<span class=""string"">""Remember""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(fe,&nbsp;b=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Text(<span class=""string"">""Login""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.AddClass(<span class=""string"">""btn-info&nbsp;btn-block""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.LoadingText(<span class=""string"">""&nbsp;&nbsp;authenticating&nbsp;...""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;fe.Validate(&nbsp;<span class=""keyword"">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bt&nbsp;=f.Find&lt;ButtonElement&gt;(<span class=""string"">""[type=submit]""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ShowLoadingText();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Window.SetTimeout(()=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ResetLoadingText();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessAfter(f,<span class=""string"">""Welcome&nbsp;:&nbsp;""</span><span>+&nbsp;f.FindByName&lt;InputElement&gt;(</span><span class=""string"">""UserName""</span><span>).GetValue());&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Clear();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;1000);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form(element, fe=&gt;{
	new TextField(fe, i=&gt;{
		i.PlaceHolder(""your username"");	i.Name=""UserName"";	i.ClassName=""span12"";
		i.Requiered();i.MinLength(8);
	});
	
	new TextField(fe, i=&gt;{
		i.PlaceHolder(""your password"");	i.Name=""Password""; i.ClassName=""span12"";
		i.Requiered(); i.MinLength(6);
		i.Type=""password"";
	});
	
	new CheckboxField(fe, (lb, cb)=&gt;{
		lb.Text(""Remember me"");
		cb.Name=""Remember"";
	});
	
	new SubmitButton(fe, b=&gt;{
		b.Text(""Login"");
		b.AddClass(""btn-info btn-block"");
		b.LoadingText(""  authenticating ..."");
	});
	
	fe.Validate( new ValidateOptions().SetSubmitHandler(f=&gt;{
		var bt =f.Find&lt;ButtonElement&gt;(""[type=submit]"");
		bt.ShowLoadingText();
		Window.SetTimeout(()=&gt;{
			bt.ResetLoadingText();
			Div.CreateAlertSuccessAfter(f,""Welcome : ""+ f.FindByName&lt;InputElement&gt;(""UserName"").GetValue());
			f.Clear();
		}, 1000);
	}));
});</textarea></div>");
			}).AppendTo(parent);

			//-----------------------------------

			"Contact Form".Header(3).AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				Div.CreateContainer(div, container=>{
					new Form( container, f=>{
						f.AddClass("well span8");
						Div.CreateRowFluid(f, row=>{
							new Div(row, sp=>{
								sp.ClassName="span5";
								new TextField(sp, (l,i)=>{
									l.Text("FirstName"); i.Name="FirstName"; i.ClassName="span12"; 
								});
								new TextField(sp, (l,i)=>{
									l.Text("LastName"); i.Name="LastName"; i.ClassName="span12"; 
								});

								new TextField(sp, (l,i)=>{
									l.Text("Email address"); i.Name="Email"; i.ClassName="span12"; 
								});

								new SelectField(sp, (l, i)=>{
									l.Text("Subject"); i.Name="Subject";i.ClassName="span12";
									new HtmlOption(i, opt=>{opt.Value=""; opt.Text("Choose One:");});
									new HtmlOption(i, opt=>{opt.Value="1"; opt.Text("General Customer Service");});
									new HtmlOption(i, opt=>{opt.Value="2"; opt.Text("Suggestions");});
									new HtmlOption(i, opt=>{opt.Value="3"; opt.Text("Product Support");});
									new HtmlOption(i, opt=>{opt.Value="4"; opt.Text("Bug");});
								});
							});

							new Div(row, sp=>{
								sp.ClassName="span7";
								new TextAreaField(sp, (l, i)=>{
									l.Text("Message"); 
									i.ClassName="input-xlarge span12"; i.Rows=11; i.Name="Message";
								});
								
							});
							new SubmitButton(row, bt=>{
								bt.AddClass("btn-primary pull-right");
								bt.Text("Send");
							});

							f.Validate(new ValidateOptions().SetSubmitHandler(vf=>{
								Div.CreateAlertSuccessBefore(vf.FirstChild,"message sent");
								vf.Clear();
							}).AddRule((rf,ms)=>{
								rf.Element= f.FindByName<SelectElement>("Subject");
								rf.Rule.Required();
								ms.Required("choose an option");
							}).AddRule((rf,ms)=>{
								rf.Element= f.FindByName<TextElement>("Email");
								rf.Rule.Email();
								ms.Email("write a valid email ");
							}).AddRule((rf,ms)=>{
								rf.Element= f.FindByName<TextElement>("FirstName");
								rf.Rule.Required();
								ms.Required("write your name");
								rf.Rule.Minlength(4);
								ms.Minlength("min 4 chars");
							}));
						});
					});
				});

				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(&nbsp;container,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.AddClass(<span class=""string"">""well&nbsp;span8""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRowFluid(f,&nbsp;row=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class=""string"">""span5""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""FirstName""</span><span>);&nbsp;i.Name=</span><span class=""string"">""FirstName""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""LastName""</span><span>);&nbsp;i.Name=</span><span class=""string"">""LastName""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Email&nbsp;address""</span><span>);&nbsp;i.Name=</span><span class=""string"">""Email""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SelectField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Subject""</span><span>);&nbsp;i.Name=</span><span class=""string"">""Subject""</span><span>;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Choose&nbsp;One:""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""1""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""General&nbsp;Customer&nbsp;Service""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""2""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Suggestions""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""3""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Product&nbsp;Support""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""4""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Bug""</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class=""string"">""span7""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextAreaField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Message""</span><span>);&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=<span class=""string"">""input-xlarge&nbsp;span12""</span><span>;&nbsp;i.Rows=11;&nbsp;i.Name=</span><span class=""string"">""Message""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(row,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.AddClass(<span class=""string"">""btn-primary&nbsp;pull-right""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Send""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Validate(<span class=""keyword"">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(vf=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessBefore(vf.FirstChild,<span class=""string"">""message&nbsp;sent""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vf.Clear();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;SelectElement&gt;(<span class=""string"">""Subject""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class=""string"">""choose&nbsp;an&nbsp;option""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Email();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Email(<span class=""string"">""write&nbsp;a&nbsp;valid&nbsp;email&nbsp;""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class=""string"">""FirstName""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class=""string"">""write&nbsp;your&nbsp;name""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Minlength(4);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Minlength(<span class=""string"">""min&nbsp;4&nbsp;chars""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form( container, f=&gt;{
	f.AddClass(""well span8"");
	Div.CreateRowFluid(f, row=&gt;{
		new Div(row, sp=&gt;{
			sp.ClassName=""span5"";
			new TextField(sp, (l,i)=&gt;{
				l.Text(""FirstName""); i.Name=""FirstName""; i.ClassName=""span12""; 
			});
			new TextField(sp, (l,i)=&gt;{
				l.Text(""LastName""); i.Name=""LastName""; i.ClassName=""span12""; 
			});
			
			new TextField(sp, (l,i)=&gt;{
				l.Text(""Email address""); i.Name=""Email""; i.ClassName=""span12""; 
			});
			
			new SelectField(sp, (l, i)=&gt;{
				l.Text(""Subject""); i.Name=""Subject"";i.ClassName=""span12"";
				new HtmlOption(i, opt=&gt;{opt.Value=""""; opt.Text(""Choose One:"");});
				new HtmlOption(i, opt=&gt;{opt.Value=""1""; opt.Text(""General Customer Service"");});
				new HtmlOption(i, opt=&gt;{opt.Value=""2""; opt.Text(""Suggestions"");});
				new HtmlOption(i, opt=&gt;{opt.Value=""3""; opt.Text(""Product Support"");});
				new HtmlOption(i, opt=&gt;{opt.Value=""4""; opt.Text(""Bug"");});
			});
		});
		
		new Div(row, sp=&gt;{
			sp.ClassName=""span7"";
			new TextAreaField(sp, (l, i)=&gt;{
				l.Text(""Message""); 
				i.ClassName=""input-xlarge span12""; i.Rows=11; i.Name=""Message"";
			});
			
		});
		new SubmitButton(row, bt=&gt;{
			bt.AddClass(""btn-primary pull-right"");
			bt.Text(""Send"");
		});
		
		f.Validate(new ValidateOptions().SetSubmitHandler(vf=&gt;{
			Div.CreateAlertSuccessBefore(vf.FirstChild,""message sent"");
			vf.Clear();
		}).AddRule((rf,ms)=&gt;{
			rf.Element= f.FindByName&lt;SelectElement&gt;(""Subject"");
			rf.Rule.Required();
			ms.Required(""choose an option"");
		}).AddRule((rf,ms)=&gt;{
			rf.Element= f.FindByName&lt;TextElement&gt;(""Email"");
			rf.Rule.Email();
			ms.Email(""write a valid email "");
		}).AddRule((rf,ms)=&gt;{
			rf.Element= f.FindByName&lt;TextElement&gt;(""FirstName"");
			rf.Rule.Required();
			ms.Required(""write your name"");
			rf.Rule.Minlength(4);
			ms.Minlength(""min 4 chars"");
		}));
	});
});</textarea></div>");
			}).AppendTo(parent);
			//-----------------------------------

		}
	}
}