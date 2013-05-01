using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;

namespace Cayita.Javascript
{

	[IgnoreNamespace]
	public class DemoTabPanel
	{
		public DemoTabPanel ()
		{
		}

		public static void Execute(Element parent)
		{
			
			"Tabs on Top".Header (3).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";

				var tb =new TabPanel(div, cfg=>{
					cfg.Bordered=true;
					cfg.Content.Style.MinHeight="100px";
				});
				tb.AddTab(tab=>{
					tab.Title="First tab";
					Alert.Success("Hello Cayita is awesome").AppendTo(tab.Body);
					tab.Body.Append("Hello first tab".Header(3));
				});

				tb.AddTab(tab=>{
					tab.Title="Second tab";
					tab.Body.AddClass("well");
					tab.Body.Append("Hello second tab");
					tab.Body.Style.Color="red";
				});

				tb.AddTab(tab=>{
					tab.Title="El Coyote";

					tab.Body.Append( new Div( d=>{
						d.ClassName="span2";
						new Image(d,i=>	i.Src="img/coyote.jpg");
					}));
					
					tab.Body.Append(new Div( d=>{
						d.ClassName="span10";
						d.Append(@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
					}));

				});

				div.AppendTo(parent);
				tb.Show(0);

				ShowCodeTop(div);
			}).AppendTo(parent);


			//

			"Tabs on the right".Header (3).AppendTo (parent);
			
			new Div (null, div => {

				div.ClassName = "bs-docs-example";

				new Div(div, well=>{
					well.ClassName="well";

					var tb =new TabPanel(well, cfg=>{
						cfg.Bordered=false;
						cfg.TabsPosition="right";
					});
					tb.AddTab(tab=>{
						tab.Title="First tab";
						tab.Body.Append("Hello first tab".Header(3));
					});
					
					tb.AddTab(tab=>{
						tab.Title="Second tab";
						Alert.Info("Hello Cayita is awesome").AppendTo(tab.Body);
						tab.Body.Style.Color="red";
					});
					
					tb.AddTab(tab=>{
						tab.Title="El Coyote";
						
						tab.Body.Append( new Div( d=>{
							d.ClassName="span2";
							new Image(d,i=>	i.Src="img/coyote.jpg");
						}));
						
						tab.Body.Append(new Div( d=>{
							d.ClassName="span10";
							d.Append(@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
						}));
						
					});

					div.AppendTo(parent);
					tb.Show(2);
					ShowCodeRight(div);
				});


			});

			//
			"Tabs on the bottom".Header (3).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";

				var tb = new TabPanel (div, cfg => {
					cfg.Bordered = true;
					cfg.TabsPosition = "below";
					cfg.Content.Style.MinHeight="200px";
				});
				tb.AddTab (tab => {
					tab.Title = "First tab";
					Alert.Info ("Hello Cayita is awesome").AppendTo (tab.Body);
					tab.Body.Append ("Hello first tab".Header (3));
				});
				
				tb.AddTab (tab => {
					tab.Title = "Second tab";
					tab.Body.Style.Color = "red";
					tab.Body.Append ("Hello second tab".Header (3));
				});
				
				tb.AddTab (tab => {
					tab.Title = "El Coyote";
					
					tab.Body.Append (new Div (d => {
						d.ClassName = "span2";
						new Image (d, i => i.Src = "img/coyote.jpg");
					}));
					
					tab.Body.Append (new Div (d => {
						d.ClassName = "span10";
						d.Append (@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
					}));
					
				});
					
				ShowCodeBottom(div);
			}).AppendTo(parent);

			//
			"Tabs on the left".Header (3).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				
				var tb = new TabPanel (div, cfg => {
					cfg.Bordered = true;
					cfg.TabsPosition = "left";
					cfg.Content.Style.MinHeight="200px";
					cfg.Links.AddClass("c-icons");
				});
				tb.AddTab (tab => {
					tab.Title = "First tab";
					Alert.Info ("Hello Cayita is awesome").AppendTo (tab.Body);
					tab.Body.Append ("Hello first tab".Header (3));
				});
				
				tb.AddTab (tab => {
					tab.Title = "Second tab";
					tab.Body.Style.Color = "red";
					tab.Body.Append ("Hello second tab".Header (3));
				});
				
				tb.AddTab (tab => 
					tab.Body.Append (new Div (d => {
						d.ClassName = "span10";
						d.Append (@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
					}))				
				, a=>{

					a.ClassName="c-icon";
					new Image(a, img=>{
						img.Src="img/coyote.jpg";
						img.Style.Height="106px";
					});

					new Span(a, sp=>{
						sp.ClassName="c-icon-label";
						sp.InnerHTML="El Coyote";
					});

				});
				ShowCodeLeft(div);
				
			}).AppendTo(parent);
		}

		static void ShowCodeTop(Element parent)
		{
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span>var&nbsp;tb&nbsp;=</span><span class=""keyword"">new</span><span>&nbsp;TabPanel(div,&nbsp;cfg=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Bordered=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Content.Style.MinHeight=<span class=""string"">""100px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span>tb.AddTab(tab=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title=<span class=""string"">""First&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;Alert.Success(<span class=""string"">""Hello&nbsp;Cayita&nbsp;is&nbsp;awesome""</span><span>).AppendTo(tab.Body);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(<span class=""string"">""Hello&nbsp;first&nbsp;tab""</span><span>.Header(3));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>tb.AddTab(tab=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title=<span class=""string"">""Second&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.AddClass(<span class=""string"">""well""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(<span class=""string"">""Hello&nbsp;second&nbsp;tab""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Style.Color=<span class=""string"">""red""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>tb.AddTab(tab=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title=<span class=""string"">""El&nbsp;Coyote""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;d=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName=<span class=""string"">""span2""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Image(d,i=&gt;&nbsp;&nbsp;i.Src=</span><span class=""string"">""img/coyote.jpg""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;d=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName=<span class=""string"">""span10""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.Append(@""&lt;i&gt;&lt;b&gt;El&nbsp;&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/Coyote'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Coyote&lt;/a&gt;&nbsp;y&nbsp;el&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Geococcyx_californianus'</span><span>&nbsp;title=</span><span class=""string"">'Geococcyx&nbsp;californianus'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt;&nbsp;(&lt;i&gt;&lt;b&gt;Wile&nbsp;E.&nbsp;Coyote&lt;/b&gt;&nbsp;and&nbsp;the&nbsp;&lt;b&gt;Road&nbsp;Runner&lt;/b&gt;&lt;/i&gt;)&nbsp;son&nbsp;los&nbsp;personajes&nbsp;de&nbsp;una&nbsp;serie&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Estados_Unidos'</span><span>&nbsp;title=</span><span class=""string"">'Estados&nbsp;Unidos'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;estadounidense&lt;/a&gt;&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Dibujos_animados'</span><span>&nbsp;title=</span><span class=""string"">'Dibujos&nbsp;animados'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;dibujos&nbsp;animados&lt;/a&gt;&nbsp;creada&nbsp;en&nbsp;el&nbsp;año&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/1949'</span><span>&nbsp;title=</span><span class=""string"">'1949'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;1949&lt;/a&gt;&nbsp;por&nbsp;el&nbsp;animador&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Chuck_Jones'</span><span>&nbsp;title=</span><span class=""string"">'Chuck&nbsp;Jones'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Chuck&nbsp;Jones&lt;/a&gt;&nbsp;para&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Warner_Brothers'</span><span>&nbsp;title=</span><span class=""string"">'Warner&nbsp;Brothers'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Warner&nbsp;Brothers&lt;/a&gt;.&nbsp;Chuck&nbsp;Jones&nbsp;se&nbsp;inspiró&nbsp;para&nbsp;crear&nbsp;a&nbsp;estos&nbsp;personajes&nbsp;en&nbsp;un&nbsp;libro&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Mark_Twain'</span><span>&nbsp;title=</span><span class=""string"">'Mark&nbsp;Twain'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Mark&nbsp;Twain&lt;/a&gt;,&nbsp;titulado&nbsp;&lt;i&gt;Roughin&nbsp;It&lt;/i&gt;,&nbsp;en&nbsp;el&nbsp;que&nbsp;Twain&nbsp;denotaba&nbsp;que&nbsp;los&nbsp;coyotes&nbsp;hambrientos&nbsp;podrían&nbsp;cazar&nbsp;un&nbsp;correcaminos.&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;El&nbsp;Coyote&nbsp;(wikipedia)&lt;/a&gt;&nbsp;"");&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>div.AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""alt""><span>tb.Show(0);&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">var tb =new TabPanel(div, cfg=&gt;{
	cfg.Bordered=true;
	cfg.Content.Style.MinHeight=""100px"";
});
tb.AddTab(tab=&gt;{
	tab.Title=""First tab"";
	Alert.Success(""Hello Cayita is awesome"").AppendTo(tab.Body);
	tab.Body.Append(""Hello first tab"".Header(3));
});

tb.AddTab(tab=&gt;{
	tab.Title=""Second tab"";
	tab.Body.AddClass(""well"");
	tab.Body.Append(""Hello second tab"");
	tab.Body.Style.Color=""red"";
});

tb.AddTab(tab=&gt;{
	tab.Title=""El Coyote"";
	
	tab.Body.Append( new Div( d=&gt;{
		d.ClassName=""span2"";
		new Image(d,i=&gt;	i.Src=""img/coyote.jpg"");
	}));
	
	tab.Body.Append(new Div( d=&gt;{
		d.ClassName=""span10"";
		d.Append(@""&lt;i&gt;&lt;b&gt;El &lt;a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'&gt;Coyote&lt;/a&gt; y el &lt;a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt; (&lt;i&gt;&lt;b&gt;Wile E. Coyote&lt;/b&gt; and the &lt;b&gt;Road Runner&lt;/b&gt;&lt;/i&gt;) son los personajes de una serie &lt;a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'&gt;estadounidense&lt;/a&gt; de &lt;a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'&gt;dibujos animados&lt;/a&gt; creada en el año de &lt;a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'&gt;1949&lt;/a&gt; por el animador &lt;a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'&gt;Chuck Jones&lt;/a&gt; para &lt;a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'&gt;Warner Brothers&lt;/a&gt;. Chuck Jones se inspiró para crear a estos personajes en un libro de &lt;a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'&gt;Mark Twain&lt;/a&gt;, titulado &lt;i&gt;Roughin It&lt;/i&gt;, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.&lt;br/&gt;&lt;a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'&gt;El Coyote (wikipedia)&lt;/a&gt; "");
	}));
	
});

div.AppendTo(parent);
tb.Show(0);</textarea></div>");
		}

		static void ShowCodeRight(Element parent)
		{
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Div(div,&nbsp;well=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;well.ClassName=<span class=""string"">""well""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tb&nbsp;=<span class=""keyword"">new</span><span>&nbsp;TabPanel(well,&nbsp;cfg=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cfg.Bordered=<span class=""keyword"">false</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cfg.TabsPosition=<span class=""string"">""right""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tb.AddTab(tab=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Title=<span class=""string"">""First&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(<span class=""string"">""Hello&nbsp;first&nbsp;tab""</span><span>.Header(3));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tb.AddTab(tab=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Title=<span class=""string"">""Second&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Alert.Info(<span class=""string"">""Hello&nbsp;Cayita&nbsp;is&nbsp;awesome""</span><span>).AppendTo(tab.Body);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Style.Color=<span class=""string"">""red""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tb.AddTab(tab=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Title=<span class=""string"">""El&nbsp;Coyote""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;d=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName=<span class=""string"">""span2""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Image(d,i=&gt;&nbsp;&nbsp;i.Src=</span><span class=""string"">""img/coyote.jpg""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append(<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;d=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName=<span class=""string"">""span10""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.Append(@""&lt;i&gt;&lt;b&gt;El&nbsp;&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/Coyote'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Coyote&lt;/a&gt;&nbsp;y&nbsp;el&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Geococcyx_californianus'</span><span>&nbsp;title=</span><span class=""string"">'Geococcyx&nbsp;californianus'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt;&nbsp;(&lt;i&gt;&lt;b&gt;Wile&nbsp;E.&nbsp;Coyote&lt;/b&gt;&nbsp;and&nbsp;the&nbsp;&lt;b&gt;Road&nbsp;Runner&lt;/b&gt;&lt;/i&gt;)&nbsp;son&nbsp;los&nbsp;personajes&nbsp;de&nbsp;una&nbsp;serie&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Estados_Unidos'</span><span>&nbsp;title=</span><span class=""string"">'Estados&nbsp;Unidos'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;estadounidense&lt;/a&gt;&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Dibujos_animados'</span><span>&nbsp;title=</span><span class=""string"">'Dibujos&nbsp;animados'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;dibujos&nbsp;animados&lt;/a&gt;&nbsp;creada&nbsp;en&nbsp;el&nbsp;año&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/1949'</span><span>&nbsp;title=</span><span class=""string"">'1949'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;1949&lt;/a&gt;&nbsp;por&nbsp;el&nbsp;animador&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Chuck_Jones'</span><span>&nbsp;title=</span><span class=""string"">'Chuck&nbsp;Jones'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Chuck&nbsp;Jones&lt;/a&gt;&nbsp;para&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Warner_Brothers'</span><span>&nbsp;title=</span><span class=""string"">'Warner&nbsp;Brothers'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Warner&nbsp;Brothers&lt;/a&gt;.&nbsp;Chuck&nbsp;Jones&nbsp;se&nbsp;inspiró&nbsp;para&nbsp;crear&nbsp;a&nbsp;estos&nbsp;personajes&nbsp;en&nbsp;un&nbsp;libro&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Mark_Twain'</span><span>&nbsp;title=</span><span class=""string"">'Mark&nbsp;Twain'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Mark&nbsp;Twain&lt;/a&gt;,&nbsp;titulado&nbsp;&lt;i&gt;Roughin&nbsp;It&lt;/i&gt;,&nbsp;en&nbsp;el&nbsp;que&nbsp;Twain&nbsp;denotaba&nbsp;que&nbsp;los&nbsp;coyotes&nbsp;hambrientos&nbsp;podrían&nbsp;cazar&nbsp;un&nbsp;correcaminos.&nbsp;&nbsp;</span></span></li><li class=""""><span>&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;El&nbsp;Coyote&nbsp;(wikipedia)&lt;/a&gt;&nbsp;"");&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;div.AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tb.Show(2);&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Div(div, well=&gt;{
	well.ClassName=""well"";
	
	var tb =new TabPanel(well, cfg=&gt;{
		cfg.Bordered=false;
		cfg.TabsPosition=""right"";
	});
	tb.AddTab(tab=&gt;{
		tab.Title=""First tab"";
		tab.Body.Append(""Hello first tab"".Header(3));
	});
	
	tb.AddTab(tab=&gt;{
		tab.Title=""Second tab"";
		Alert.Info(""Hello Cayita is awesome"").AppendTo(tab.Body);
		tab.Body.Style.Color=""red"";
	});
	
	tb.AddTab(tab=&gt;{
		tab.Title=""El Coyote"";
		
		tab.Body.Append( new Div( d=&gt;{
			d.ClassName=""span2"";
			new Image(d,i=&gt;	i.Src=""img/coyote.jpg"");
		}));
		
		tab.Body.Append(new Div( d=&gt;{
			d.ClassName=""span10"";
			d.Append(@""&lt;i&gt;&lt;b&gt;El &lt;a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'&gt;Coyote&lt;/a&gt; y el &lt;a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt; (&lt;i&gt;&lt;b&gt;Wile E. Coyote&lt;/b&gt; and the &lt;b&gt;Road Runner&lt;/b&gt;&lt;/i&gt;) son los personajes de una serie &lt;a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'&gt;estadounidense&lt;/a&gt; de &lt;a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'&gt;dibujos animados&lt;/a&gt; creada en el año de &lt;a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'&gt;1949&lt;/a&gt; por el animador &lt;a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'&gt;Chuck Jones&lt;/a&gt; para &lt;a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'&gt;Warner Brothers&lt;/a&gt;. Chuck Jones se inspiró para crear a estos personajes en un libro de &lt;a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'&gt;Mark Twain&lt;/a&gt;, titulado &lt;i&gt;Roughin It&lt;/i&gt;, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.&lt;br/&gt;&lt;a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'&gt;El Coyote (wikipedia)&lt;/a&gt; "");
		}));
		
	});
	
	div.AppendTo(parent);
	tb.Show(2);
});</textarea></div>");
		}

		static void ShowCodeBottom(Element parent)
		{
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span>var&nbsp;tb&nbsp;=&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TabPanel&nbsp;(div,&nbsp;cfg&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Bordered&nbsp;=&nbsp;<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.TabsPosition&nbsp;=&nbsp;<span class=""string"">""below""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Content.Style.MinHeight=<span class=""string"">""200px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li><li class=""""><span>tb.AddTab&nbsp;(tab&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title&nbsp;=&nbsp;<span class=""string"">""First&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;Alert.Info&nbsp;(<span class=""string"">""Hello&nbsp;Cayita&nbsp;is&nbsp;awesome""</span><span>).AppendTo&nbsp;(tab.Body);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""string"">""Hello&nbsp;first&nbsp;tab""</span><span>.Header&nbsp;(3));&nbsp;&nbsp;</span></span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>tb.AddTab&nbsp;(tab&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title&nbsp;=&nbsp;<span class=""string"">""Second&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Style.Color&nbsp;=&nbsp;<span class=""string"">""red""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""string"">""Hello&nbsp;second&nbsp;tab""</span><span>.Header&nbsp;(3));&nbsp;&nbsp;</span></span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>tb.AddTab&nbsp;(tab&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title&nbsp;=&nbsp;<span class=""string"">""El&nbsp;Coyote""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;(d&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName&nbsp;=&nbsp;<span class=""string"">""span2""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Image&nbsp;(d,&nbsp;i&nbsp;=&gt;&nbsp;i.Src&nbsp;=&nbsp;</span><span class=""string"">""img/coyote.jpg""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;(d&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName&nbsp;=&nbsp;<span class=""string"">""span10""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.Append&nbsp;(@""&lt;i&gt;&lt;b&gt;El&nbsp;&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/Coyote'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Coyote&lt;/a&gt;&nbsp;y&nbsp;el&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Geococcyx_californianus'</span><span>&nbsp;title=</span><span class=""string"">'Geococcyx&nbsp;californianus'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt;&nbsp;(&lt;i&gt;&lt;b&gt;Wile&nbsp;E.&nbsp;Coyote&lt;/b&gt;&nbsp;and&nbsp;the&nbsp;&lt;b&gt;Road&nbsp;Runner&lt;/b&gt;&lt;/i&gt;)&nbsp;son&nbsp;los&nbsp;personajes&nbsp;de&nbsp;una&nbsp;serie&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Estados_Unidos'</span><span>&nbsp;title=</span><span class=""string"">'Estados&nbsp;Unidos'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;estadounidense&lt;/a&gt;&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Dibujos_animados'</span><span>&nbsp;title=</span><span class=""string"">'Dibujos&nbsp;animados'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;dibujos&nbsp;animados&lt;/a&gt;&nbsp;creada&nbsp;en&nbsp;el&nbsp;año&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/1949'</span><span>&nbsp;title=</span><span class=""string"">'1949'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;1949&lt;/a&gt;&nbsp;por&nbsp;el&nbsp;animador&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Chuck_Jones'</span><span>&nbsp;title=</span><span class=""string"">'Chuck&nbsp;Jones'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Chuck&nbsp;Jones&lt;/a&gt;&nbsp;para&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Warner_Brothers'</span><span>&nbsp;title=</span><span class=""string"">'Warner&nbsp;Brothers'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Warner&nbsp;Brothers&lt;/a&gt;.&nbsp;Chuck&nbsp;Jones&nbsp;se&nbsp;inspiró&nbsp;para&nbsp;crear&nbsp;a&nbsp;estos&nbsp;personajes&nbsp;en&nbsp;un&nbsp;libro&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Mark_Twain'</span><span>&nbsp;title=</span><span class=""string"">'Mark&nbsp;Twain'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Mark&nbsp;Twain&lt;/a&gt;,&nbsp;titulado&nbsp;&lt;i&gt;Roughin&nbsp;It&lt;/i&gt;,&nbsp;en&nbsp;el&nbsp;que&nbsp;Twain&nbsp;denotaba&nbsp;que&nbsp;los&nbsp;coyotes&nbsp;hambrientos&nbsp;podrían&nbsp;cazar&nbsp;un&nbsp;correcaminos.&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;El&nbsp;Coyote&nbsp;(wikipedia)&lt;/a&gt;&nbsp;"");&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">var tb = new TabPanel (div, cfg =&gt; {
	cfg.Bordered = true;
	cfg.TabsPosition = ""below"";
	cfg.Content.Style.MinHeight=""200px"";
});
tb.AddTab (tab =&gt; {
	tab.Title = ""First tab"";
	Alert.Info (""Hello Cayita is awesome"").AppendTo (tab.Body);
	tab.Body.Append (""Hello first tab"".Header (3));
});

tb.AddTab (tab =&gt; {
	tab.Title = ""Second tab"";
	tab.Body.Style.Color = ""red"";
	tab.Body.Append (""Hello second tab"".Header (3));
});

tb.AddTab (tab =&gt; {
	tab.Title = ""El Coyote"";
	
	tab.Body.Append (new Div (d =&gt; {
		d.ClassName = ""span2"";
		new Image (d, i =&gt; i.Src = ""img/coyote.jpg"");
	}));
	
	tab.Body.Append (new Div (d =&gt; {
		d.ClassName = ""span10"";
		d.Append (@""&lt;i&gt;&lt;b&gt;El &lt;a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'&gt;Coyote&lt;/a&gt; y el &lt;a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt; (&lt;i&gt;&lt;b&gt;Wile E. Coyote&lt;/b&gt; and the &lt;b&gt;Road Runner&lt;/b&gt;&lt;/i&gt;) son los personajes de una serie &lt;a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'&gt;estadounidense&lt;/a&gt; de &lt;a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'&gt;dibujos animados&lt;/a&gt; creada en el año de &lt;a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'&gt;1949&lt;/a&gt; por el animador &lt;a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'&gt;Chuck Jones&lt;/a&gt; para &lt;a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'&gt;Warner Brothers&lt;/a&gt;. Chuck Jones se inspiró para crear a estos personajes en un libro de &lt;a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'&gt;Mark Twain&lt;/a&gt;, titulado &lt;i&gt;Roughin It&lt;/i&gt;, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.&lt;br/&gt;&lt;a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'&gt;El Coyote (wikipedia)&lt;/a&gt; "");
	}));
	
});</textarea></div>");
		}

		static void ShowCodeLeft(Element parent)
		{
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span>var&nbsp;tb&nbsp;=&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TabPanel&nbsp;(div,&nbsp;cfg&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Bordered&nbsp;=&nbsp;<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.TabsPosition&nbsp;=&nbsp;<span class=""string"">""left""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Content.Style.MinHeight=<span class=""string"">""200px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;cfg.Links.AddClass(<span class=""string"">""c-icons""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>});&nbsp;&nbsp;</span></li><li class=""alt""><span>tb.AddTab&nbsp;(tab&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title&nbsp;=&nbsp;<span class=""string"">""First&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;Alert.Info&nbsp;(<span class=""string"">""Hello&nbsp;Cayita&nbsp;is&nbsp;awesome""</span><span>).AppendTo&nbsp;(tab.Body);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""string"">""Hello&nbsp;first&nbsp;tab""</span><span>.Header&nbsp;(3));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>tb.AddTab&nbsp;(tab&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Title&nbsp;=&nbsp;<span class=""string"">""Second&nbsp;tab""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Style.Color&nbsp;=&nbsp;<span class=""string"">""red""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""string"">""Hello&nbsp;second&nbsp;tab""</span><span>.Header&nbsp;(3));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>tb.AddTab&nbsp;(tab&nbsp;=&gt;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tab.Body.Append&nbsp;(<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;(d&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName&nbsp;=&nbsp;<span class=""string"">""span10""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;d.Append&nbsp;(@""&lt;i&gt;&lt;b&gt;El&nbsp;&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/Coyote'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Coyote&lt;/a&gt;&nbsp;y&nbsp;el&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Geococcyx_californianus'</span><span>&nbsp;title=</span><span class=""string"">'Geococcyx&nbsp;californianus'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt;&nbsp;(&lt;i&gt;&lt;b&gt;Wile&nbsp;E.&nbsp;Coyote&lt;/b&gt;&nbsp;and&nbsp;the&nbsp;&lt;b&gt;Road&nbsp;Runner&lt;/b&gt;&lt;/i&gt;)&nbsp;son&nbsp;los&nbsp;personajes&nbsp;de&nbsp;una&nbsp;serie&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Estados_Unidos'</span><span>&nbsp;title=</span><span class=""string"">'Estados&nbsp;Unidos'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;estadounidense&lt;/a&gt;&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Dibujos_animados'</span><span>&nbsp;title=</span><span class=""string"">'Dibujos&nbsp;animados'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;dibujos&nbsp;animados&lt;/a&gt;&nbsp;creada&nbsp;en&nbsp;el&nbsp;año&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/1949'</span><span>&nbsp;title=</span><span class=""string"">'1949'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;1949&lt;/a&gt;&nbsp;por&nbsp;el&nbsp;animador&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Chuck_Jones'</span><span>&nbsp;title=</span><span class=""string"">'Chuck&nbsp;Jones'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Chuck&nbsp;Jones&lt;/a&gt;&nbsp;para&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Warner_Brothers'</span><span>&nbsp;title=</span><span class=""string"">'Warner&nbsp;Brothers'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Warner&nbsp;Brothers&lt;/a&gt;.&nbsp;Chuck&nbsp;Jones&nbsp;se&nbsp;inspiró&nbsp;para&nbsp;crear&nbsp;a&nbsp;estos&nbsp;personajes&nbsp;en&nbsp;un&nbsp;libro&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Mark_Twain'</span><span>&nbsp;title=</span><span class=""string"">'Mark&nbsp;Twain'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Mark&nbsp;Twain&lt;/a&gt;,&nbsp;titulado&nbsp;&lt;i&gt;Roughin&nbsp;It&lt;/i&gt;,&nbsp;en&nbsp;el&nbsp;que&nbsp;Twain&nbsp;denotaba&nbsp;que&nbsp;los&nbsp;coyotes&nbsp;hambrientos&nbsp;podrían&nbsp;cazar&nbsp;un&nbsp;correcaminos.&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;El&nbsp;Coyote&nbsp;(wikipedia)&lt;/a&gt;&nbsp;"");&nbsp;&nbsp;</span></span></li><li class=""""><span>}))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;a=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;a.ClassName=<span class=""string"">""c-icon""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Image(a,&nbsp;img=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.Src=<span class=""string"">""img/coyote.jpg""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.Style.Height=<span class=""string"">""106px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Span(a,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class=""string"">""c-icon-label""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.InnerHTML=<span class=""string"">""El&nbsp;Coyote""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">var tb = new TabPanel (div, cfg =&gt; {
	cfg.Bordered = true;
	cfg.TabsPosition = ""left"";
	cfg.Content.Style.MinHeight=""200px"";
	cfg.Links.AddClass(""c-icons"");
});
tb.AddTab (tab =&gt; {
	tab.Title = ""First tab"";
	Alert.Info (""Hello Cayita is awesome"").AppendTo (tab.Body);
	tab.Body.Append (""Hello first tab"".Header (3));
});

tb.AddTab (tab =&gt; {
	tab.Title = ""Second tab"";
	tab.Body.Style.Color = ""red"";
	tab.Body.Append (""Hello second tab"".Header (3));
});

tb.AddTab (tab =&gt; 
           tab.Body.Append (new Div (d =&gt; {
	d.ClassName = ""span10"";
	d.Append (@""&lt;i&gt;&lt;b&gt;El &lt;a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'&gt;Coyote&lt;/a&gt; y el &lt;a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt; (&lt;i&gt;&lt;b&gt;Wile E. Coyote&lt;/b&gt; and the &lt;b&gt;Road Runner&lt;/b&gt;&lt;/i&gt;) son los personajes de una serie &lt;a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'&gt;estadounidense&lt;/a&gt; de &lt;a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'&gt;dibujos animados&lt;/a&gt; creada en el año de &lt;a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'&gt;1949&lt;/a&gt; por el animador &lt;a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'&gt;Chuck Jones&lt;/a&gt; para &lt;a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'&gt;Warner Brothers&lt;/a&gt;. Chuck Jones se inspiró para crear a estos personajes en un libro de &lt;a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'&gt;Mark Twain&lt;/a&gt;, titulado &lt;i&gt;Roughin It&lt;/i&gt;, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.&lt;br/&gt;&lt;a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'&gt;El Coyote (wikipedia)&lt;/a&gt; "");
}))				
           , a=&gt;{
	
	a.ClassName=""c-icon"";
	new Image(a, img=&gt;{
		img.Src=""img/coyote.jpg"";
		img.Style.Height=""106px"";
	});
	
	new Span(a, sp=&gt;{
		sp.ClassName=""c-icon-label"";
		sp.InnerHTML=""El Coyote"";
	});
	
});</textarea></div>");
		}
	}
}
