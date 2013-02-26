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

			var title=Document.CreateElement("h2");
			title.Text("Default styles");
			parent.Append(title);
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

			})
				.AppendTo(parent);



		}
		
		/*
		<form>
			<fieldset>
				<legend>Legend</legend>
				<label>Label name</label>
				<input type="text" placeholder="Type something…">
				<span class="help-block">Example block-level help text here.</span>
				<label class="checkbox">
				<input type="checkbox"> Check me out
				</label>
				<button type="submit" class="btn">Submit</button>
				</fieldset>
				</form>
				]*/
	}
}

