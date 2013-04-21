using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;

namespace Modals
{
	public class App
	{
		public App(){}
		public string Tittle { get; set; }
		public string Icon { get; set; }
	
		public static List<App> GetApps()
		{
			var a = new List<App> (){
				new App{Tittle="Calculator", Icon="img/calculator.png"},
				new App{Tittle="Control Panel", Icon="img/control.png"},
				new App{Tittle="Firewall Settings", Icon="img/firewall.png"},
				new App{Tittle="Spreadsheet", Icon="img/calc.png"},
				new App{Tittle="Mail", Icon="img/mail.png"},
				new App{Tittle="Jack Sparrow Navigator", Icon="img/web.png"},
				new App{Tittle="MonoDevelop", Icon="img/monodevelop.png"},
				new App{Tittle="Tomboy", Icon="img/tomboy.png"},
				new App{Tittle="Skype", Icon="img/skype.png"}
			} ;
			return a;
		}
	}



	[IgnoreNamespace]
	public class DemoPanels
	{
		public DemoPanels ()
		{
		}
		
		public static void Execute(Element parent)
		{
			"Panels".Header (2).AppendTo (parent);
			
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				div.Style.PaddingLeft="40px";
				div.Append( Div.CreateContainer(div, cf=>{
					Div.CreateRow(cf, rf=>{
						new Div(rf, ld=>{
							ld.ClassName="span5";
							var apps = new Panel().Caption("Apps").Closable(false).Resizable(false);
							new Div(id=>{
								id.ClassName="c-icons";
								id.Append("<style>img {height: 40px;}  .c-icon {height: 95px;}</style>");
								foreach(var app in App.GetApps()){
									new Anchor( id, a=>{
										a.ClassName="c-icon";
										new Image(a, img=>{
											img.Src=app.Icon;
											img.ClassName="img-rounded";
										});
										a.OnClick(ev=>{
											ev.PreventDefault();
											app.Tittle.LogInfo();										
										});
										new Span(a, sp=>{
											sp.ClassName="c-icon-label";
											sp.InnerHTML=app.Tittle;
										});
										
									});
								}
								apps.Append(id);
							});
							apps.Render(ld);

							var pn =new Panel().Caption("Demo Panel").Closable(false).Resizable(false).Draggable(false);

							new Button( bt=>{
								bt.Text("Grey background");
							
								bt.OnClick(evt=>{
									pn.Body().Style.BackgroundColor="grey";
								});
								pn.Append(bt);
							});

							new Button( bt=>{
								bt.Text("White background");
								
								bt.OnClick(evt=>{
									pn.Body().Style.BackgroundColor="white";
								});
								pn.Append(bt);
							});


							new Button( bt=>{
								bt.Text("Collapse");
								
								bt.OnClick(evt=>{
									pn.Collapse();
								});
								pn.Append(bt);
							});


							pn.Render(ld);

						});

						new Div(rf, ld=>{
							ld.ClassName="span5";
							var coyote = new Panel()
								.Caption("El Coyote")
									.Closable(false).Render(ld).Draggable(false).Resizable(false);

							new Div( d=>{
								d.ClassName="span2";
								new Image(d,i=>{
									i.Src="img/coyote.jpg";
									i.Style.Height="20%";
								});
								coyote.Append(d);
							});

							new Div( d=>{
								d.ClassName="span10";
								d.Append(@"<i><b>El <a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'>Coyote</a> y el <a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'>estadounidense</a> de <a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'>dibujos animados</a> creada en el año de <a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'>1949</a> por el animador <a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'>Chuck Jones</a> para <a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'>El Coyote (wikipedia)</a> ");
								coyote.Append(d);
							});


							var tbp= new Panel().Caption("Table").Closable(false).Draggable(false).Resizable(false);

							new HtmlTable(t=>{
								t.ClassName="table table-striped table-hover table-condensed";
								new TableHeader(t, h=>{
									new TableRow(h, tr=>{
										new TableCell(tr, td=> td.SetValue("Title"));
										new TableCell(tr, td=> td.SetValue("URL"));
										        
									});
								});
						
								foreach (var app in App.GetApps())
								{
									new TableRow(t, tr=>{
										new TableCell(tr, td=> td.SetValue(app.Tittle));
										new TableCell(tr, td=> td.SetValue(app.Icon));
									});
								}
								tbp.Append(t);
							});

							tbp.Render(ld);

						});
					});


				}));
				
				ShowCodePanels(div);
				
			}).AppendTo(parent);


			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				var i=1;

				new Button(div, bt=>{
					bt.Text("Window I");
					bt.OnClick(evt=>{
						new Panel()
							.Caption("Window " +(i++).ToString())
								.Left((i*5).ToString()+"px")
								.Top((i*15).ToString()+"px")
								.Width("300px")
								.Height("100px")
								.Overlay(true)
								.Render();
					});
				});

				ShowCodeWin1(div);


			}).AppendTo(parent);
				

			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				
				new Button (div, bt => {
					bt.Text ("Window II");
					bt.OnClick (evt => {
						
						new Panel ()
							.Caption ("Custom Close Icon and Handler")
								.Overlay (true)
								.Left ("20px")
								.Top ("200px")
								.Width ("auto")
								.CloseIconClass ("icon-th-large")
								.Closable (true)
								.CloseIconHandler (p => { 
							p.Caption ("Icon Close Changed !!! ");
							p.CloseIconClass ("icon-remove-circle");
							p.CloseIconHandler (pn => pn.Close ());
							p.Height ("400px");
						})
								.OnCloseHandler (p => {
							"panel closed ".Header (3).LogInfo (); })
								.Append (new Button (b => {
							b.Text ("Click me");
							b.Style.Width = "100%";
							b.Style.Height = "100%";
							b.OnClick (ev => "button clicked!!!".LogInfo ());
						}))
								.Render ();						
					});
					
				});

				ShowCodeWin2(div);

			}).AppendTo (parent);


			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				
				new Button (div, bt => {
					bt.Text ("Window III");
					bt.OnClick (evt => {


						var error= new Paragraph (p=>{
							p.Style.Color="red";
							p.Append( new Icon(i=>{
								i.ClassName="icon-minus-sign";
								i.Style.MarginTop="8px";
								i.Style.MarginRight="8px";
							}));
							p.Append(" panel was closed ");
						});

						var pn=new Panel ()
							.Caption ("No Closable No Collapsible")
								.Overlay (true)
								.Left ("30px")
								.Top ("400px")
								.Width ("auto")
								.Closable (false)
								.Collapsible(false)
								.OnCloseHandler (p => error.LogInfo () );
						pn.Append( new Button( b=>{
							b.Text("Click me");
							b.Style.Width="100%"; b.Style.Height="100%";
							b.OnClick(be=>{
								pn.Closable(true);
								pn.Collapsible(true);
								pn.Caption("Now Closable and Collapsible");
								b.Disabled=true;
							});
						}));
						pn.Render ();						
					});
					
				});
				
				ShowCodeWin3(div);
				
			}).AppendTo (parent);;


		}


		static void ShowCodePanels(Element parent)
		{
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span>Div.CreateRow(cf,&nbsp;rf=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(rf,&nbsp;ld=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ld.ClassName=<span class=""string"">""span5""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;apps&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Panel().Caption(</span><span class=""string"">""Apps""</span><span>).Closable(</span><span class=""keyword"">false</span><span>).Resizable(</span><span class=""keyword"">false</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(id=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id.ClassName=<span class=""string"">""c-icons""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id.Append(<span class=""string"">""&lt;style&gt;img&nbsp;{height:&nbsp;40px;}&nbsp;&nbsp;.c-icon&nbsp;{height:&nbsp;95px;}&lt;/style&gt;""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach(var&nbsp;app&nbsp;in&nbsp;App.GetApps()){&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Anchor(&nbsp;id,&nbsp;a=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a.ClassName=<span class=""string"">""c-icon""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Image(a,&nbsp;img=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.Src=app.Icon;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.ClassName=<span class=""string"">""img-rounded""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a.OnClick(ev=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.Tittle.LogInfo();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Span(a,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class=""string"">""c-icon-label""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.InnerHTML=app.Tittle;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;apps.Append(id);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;apps.Render(ld);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;pn&nbsp;=<span class=""keyword"">new</span><span>&nbsp;Panel().Caption(</span><span class=""string"">""Demo&nbsp;Panel""</span><span>).Closable(</span><span class=""keyword"">false</span><span>).Resizable(</span><span class=""keyword"">false</span><span>).Draggable(</span><span class=""keyword"">false</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Button(&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Grey&nbsp;background""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Body().Style.BackgroundColor=<span class=""string"">""grey""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Append(bt);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Button(&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""White&nbsp;background""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Body().Style.BackgroundColor=<span class=""string"">""white""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Append(bt);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Button(&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Collapse""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Collapse();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Append(bt);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Render(ld);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(rf,&nbsp;ld=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ld.ClassName=<span class=""string"">""span5""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;coyote&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Panel()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Caption(<span class=""string"">""El&nbsp;Coyote""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Closable(<span class=""keyword"">false</span><span>).Render(ld).Draggable(</span><span class=""keyword"">false</span><span>).Resizable(</span><span class=""keyword"">false</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;d=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName=<span class=""string"">""span2""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Image(d,i=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Src=<span class=""string"">""img/coyote.jpg""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Style.Height=<span class=""string"">""20%""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;coyote.Append(d);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;d=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.ClassName=<span class=""string"">""span10""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.Append(@""&lt;i&gt;&lt;b&gt;El&nbsp;&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/Coyote'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Coyote&lt;/a&gt;&nbsp;y&nbsp;el&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Geococcyx_californianus'</span><span>&nbsp;title=</span><span class=""string"">'Geococcyx&nbsp;californianus'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt;&nbsp;(&lt;i&gt;&lt;b&gt;Wile&nbsp;E.&nbsp;Coyote&lt;/b&gt;&nbsp;and&nbsp;the&nbsp;&lt;b&gt;Road&nbsp;Runner&lt;/b&gt;&lt;/i&gt;)&nbsp;son&nbsp;los&nbsp;personajes&nbsp;de&nbsp;una&nbsp;serie&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Estados_Unidos'</span><span>&nbsp;title=</span><span class=""string"">'Estados&nbsp;Unidos'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;estadounidense&lt;/a&gt;&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Dibujos_animados'</span><span>&nbsp;title=</span><span class=""string"">'Dibujos&nbsp;animados'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;dibujos&nbsp;animados&lt;/a&gt;&nbsp;creada&nbsp;en&nbsp;el&nbsp;año&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/1949'</span><span>&nbsp;title=</span><span class=""string"">'1949'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;1949&lt;/a&gt;&nbsp;por&nbsp;el&nbsp;animador&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Chuck_Jones'</span><span>&nbsp;title=</span><span class=""string"">'Chuck&nbsp;Jones'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Chuck&nbsp;Jones&lt;/a&gt;&nbsp;para&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Warner_Brothers'</span><span>&nbsp;title=</span><span class=""string"">'Warner&nbsp;Brothers'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Warner&nbsp;Brothers&lt;/a&gt;.&nbsp;Chuck&nbsp;Jones&nbsp;se&nbsp;inspiró&nbsp;para&nbsp;crear&nbsp;a&nbsp;estos&nbsp;personajes&nbsp;en&nbsp;un&nbsp;libro&nbsp;de&nbsp;&lt;a&nbsp;href=</span><span class=""string"">'https://es.wikipedia.org/wiki/Mark_Twain'</span><span>&nbsp;title=</span><span class=""string"">'Mark&nbsp;Twain'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;Mark&nbsp;Twain&lt;/a&gt;,&nbsp;titulado&nbsp;&lt;i&gt;Roughin&nbsp;It&lt;/i&gt;,&nbsp;en&nbsp;el&nbsp;que&nbsp;Twain&nbsp;denotaba&nbsp;que&nbsp;los&nbsp;coyotes&nbsp;hambrientos&nbsp;podrían&nbsp;cazar&nbsp;un&nbsp;correcaminos.&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&lt;a&nbsp;href=<span class=""string"">'https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos'</span><span>&nbsp;title=</span><span class=""string"">'Coyote'</span><span>&nbsp;target=</span><span class=""string"">'_blank'</span><span>&gt;El&nbsp;Coyote&nbsp;(wikipedia)&lt;/a&gt;&nbsp;"");&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;coyote.Append(d);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;tbp=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Panel().Caption(</span><span class=""string"">""Table""</span><span>).Closable(</span><span class=""keyword"">false</span><span>).Draggable(</span><span class=""keyword"">false</span><span>).Resizable(</span><span class=""keyword"">false</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlTable(t=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;t.ClassName=<span class=""string"">""table&nbsp;table-striped&nbsp;table-hover&nbsp;table-condensed""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableHeader(t,&nbsp;h=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableRow(h,&nbsp;tr=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(tr,&nbsp;td=&gt;&nbsp;td.SetValue(</span><span class=""string"">""Title""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(tr,&nbsp;td=&gt;&nbsp;td.SetValue(</span><span class=""string"">""URL""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(var&nbsp;app&nbsp;in&nbsp;App.GetApps())&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableRow(t,&nbsp;tr=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(tr,&nbsp;td=&gt;&nbsp;td.SetValue(app.Tittle));&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(tr,&nbsp;td=&gt;&nbsp;td.SetValue(app.Icon));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbp.Append(t);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbp.Render(ld);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>})&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">Div.CreateRow(cf, rf=&gt;{
	new Div(rf, ld=&gt;{
		ld.ClassName=""span5"";
		var apps = new Panel().Caption(""Apps"").Closable(false).Resizable(false);
		new Div(id=&gt;{
			id.ClassName=""c-icons"";
			id.Append(""&lt;style&gt;img {height: 40px;}  .c-icon {height: 95px;}&lt;/style&gt;"");
			foreach(var app in App.GetApps()){
				new Anchor( id, a=&gt;{
					a.ClassName=""c-icon"";
					new Image(a, img=&gt;{
						img.Src=app.Icon;
						img.ClassName=""img-rounded"";
					});
					a.OnClick(ev=&gt;{
						ev.PreventDefault();
						app.Tittle.LogInfo();										
					});
					new Span(a, sp=&gt;{
						sp.ClassName=""c-icon-label"";
						sp.InnerHTML=app.Tittle;
					});
					
				});
			}
			apps.Append(id);
		});
		apps.Render(ld);
		
		var pn =new Panel().Caption(""Demo Panel"").Closable(false).Resizable(false).Draggable(false);
		
		new Button( bt=&gt;{
			bt.Text(""Grey background"");
			
			bt.OnClick(evt=&gt;{
				pn.Body().Style.BackgroundColor=""grey"";
			});
			pn.Append(bt);
		});
		
		new Button( bt=&gt;{
			bt.Text(""White background"");
			
			bt.OnClick(evt=&gt;{
				pn.Body().Style.BackgroundColor=""white"";
			});
			pn.Append(bt);
		});
		
		
		new Button( bt=&gt;{
			bt.Text(""Collapse"");
			
			bt.OnClick(evt=&gt;{
				pn.Collapse();
			});
			pn.Append(bt);
		});
		
		
		pn.Render(ld);
		
	});
	
	new Div(rf, ld=&gt;{
		ld.ClassName=""span5"";
		var coyote = new Panel()
			.Caption(""El Coyote"")
				.Closable(false).Render(ld).Draggable(false).Resizable(false);
		
		new Div( d=&gt;{
			d.ClassName=""span2"";
			new Image(d,i=&gt;{
				i.Src=""img/coyote.jpg"";
				i.Style.Height=""20%"";
			});
			coyote.Append(d);
		});
		
		new Div( d=&gt;{
			d.ClassName=""span10"";
			d.Append(@""&lt;i&gt;&lt;b&gt;El &lt;a href='https://es.wikipedia.org/wiki/Coyote' title='Coyote' target='_blank'&gt;Coyote&lt;/a&gt; y el &lt;a href='https://es.wikipedia.org/wiki/Geococcyx_californianus' title='Geococcyx californianus' target='_blank'&gt;Correcaminos&lt;/a&gt;&lt;/b&gt;&lt;/i&gt; (&lt;i&gt;&lt;b&gt;Wile E. Coyote&lt;/b&gt; and the &lt;b&gt;Road Runner&lt;/b&gt;&lt;/i&gt;) son los personajes de una serie &lt;a href='https://es.wikipedia.org/wiki/Estados_Unidos' title='Estados Unidos' target='_blank'&gt;estadounidense&lt;/a&gt; de &lt;a href='https://es.wikipedia.org/wiki/Dibujos_animados' title='Dibujos animados' target='_blank'&gt;dibujos animados&lt;/a&gt; creada en el año de &lt;a href='https://es.wikipedia.org/wiki/1949' title='1949' target='_blank'&gt;1949&lt;/a&gt; por el animador &lt;a href='https://es.wikipedia.org/wiki/Chuck_Jones' title='Chuck Jones' target='_blank'&gt;Chuck Jones&lt;/a&gt; para &lt;a href='https://es.wikipedia.org/wiki/Warner_Brothers' title='Warner Brothers' target='_blank'&gt;Warner Brothers&lt;/a&gt;. Chuck Jones se inspiró para crear a estos personajes en un libro de &lt;a href='https://es.wikipedia.org/wiki/Mark_Twain' title='Mark Twain' target='_blank'&gt;Mark Twain&lt;/a&gt;, titulado &lt;i&gt;Roughin It&lt;/i&gt;, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.&lt;br/&gt;&lt;a href='https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos' title='Coyote' target='_blank'&gt;El Coyote (wikipedia)&lt;/a&gt; "");
			coyote.Append(d);
		});
		
		
		var tbp= new Panel().Caption(""Table"").Closable(false).Draggable(false).Resizable(false);
		
		new HtmlTable(t=&gt;{
			t.ClassName=""table table-striped table-hover table-condensed"";
			new TableHeader(t, h=&gt;{
				new TableRow(h, tr=&gt;{
					new TableCell(tr, td=&gt; td.SetValue(""Title""));
					new TableCell(tr, td=&gt; td.SetValue(""URL""));
					
				});
			});
			
			foreach (var app in App.GetApps())
			{
				new TableRow(t, tr=&gt;{
					new TableCell(tr, td=&gt; td.SetValue(app.Tittle));
					new TableCell(tr, td=&gt; td.SetValue(app.Icon));
				});
			}
			tbp.Append(t);
		});
		
		tbp.Render(ld);
		
		
	});
	
})</textarea></div>");
		}

		static void ShowCodeWin1(Element parent ){

			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span>var&nbsp;i=1;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Button(div,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Window&nbsp;I""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Panel()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Caption(<span class=""string"">""Window&nbsp;""</span><span>&nbsp;+(i++).ToString())&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Left((i*5).ToString()+<span class=""string"">""px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Top((i*15).ToString()+<span class=""string"">""px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Width(<span class=""string"">""300px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Height(<span class=""string"">""100px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Overlay(<span class=""keyword"">true</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Render();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">var i=1;

new Button(div, bt=&gt;{
	bt.Text(""Window I"");
	bt.OnClick(evt=&gt;{
		new Panel()
			.Caption(""Window "" +(i++).ToString())
				.Left((i*5).ToString()+""px"")
				.Top((i*15).ToString()+""px"")
				.Width(""300px"")
				.Height(""100px"")
				.Overlay(true)
				.Render();
	});
});</textarea></div>");
		}

		static void ShowCodeWin2(Element parent){
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Button&nbsp;(div,&nbsp;bt&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Text&nbsp;(<span class=""string"">""Window&nbsp;II""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick&nbsp;(evt&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Panel&nbsp;()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Caption&nbsp;(<span class=""string"">""Custom&nbsp;Close&nbsp;Icon&nbsp;and&nbsp;Handler""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Overlay&nbsp;(<span class=""keyword"">true</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Left&nbsp;(<span class=""string"">""20px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Top&nbsp;(<span class=""string"">""200px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Width&nbsp;(<span class=""string"">""auto""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CloseIconClass&nbsp;(<span class=""string"">""icon-th-large""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Closable&nbsp;(<span class=""keyword"">true</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CloseIconHandler&nbsp;(p&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Caption&nbsp;(<span class=""string"">""Icon&nbsp;Close&nbsp;Changed&nbsp;!!!&nbsp;""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.CloseIconClass&nbsp;(<span class=""string"">""icon-remove-circle""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.CloseIconHandler&nbsp;(pn&nbsp;=&gt;&nbsp;pn.Close&nbsp;());&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Height&nbsp;(<span class=""string"">""400px""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;})&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.OnCloseHandler&nbsp;(p&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""panel&nbsp;closed&nbsp;""</span><span>.Header&nbsp;(3).LogInfo&nbsp;();&nbsp;})&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Append&nbsp;(<span class=""keyword"">new</span><span>&nbsp;Button&nbsp;(b&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Text&nbsp;(<span class=""string"">""Click&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Style.Width&nbsp;=&nbsp;<span class=""string"">""100%""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Style.Height&nbsp;=&nbsp;<span class=""string"">""100%""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.OnClick&nbsp;(ev&nbsp;=&gt;&nbsp;<span class=""string"">""button&nbsp;clicked!!!""</span><span>.LogInfo&nbsp;());&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}))&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Render&nbsp;();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Button (div, bt =&gt; {
	bt.Text (""Window II"");
	bt.OnClick (evt =&gt; {
		
		new Panel ()
			.Caption (""Custom Close Icon and Handler"")
				.Overlay (true)
				.Left (""20px"")
				.Top (""200px"")
				.Width (""auto"")
				.CloseIconClass (""icon-th-large"")
				.Closable (true)
				.CloseIconHandler (p =&gt; { 
					p.Caption (""Icon Close Changed !!! "");
					p.CloseIconClass (""icon-remove-circle"");
					p.CloseIconHandler (pn =&gt; pn.Close ());
					p.Height (""400px"");
				})
				.OnCloseHandler (p =&gt; {
					""panel closed "".Header (3).LogInfo (); })
				.Append (new Button (b =&gt; {
					b.Text (""Click me"");
					b.Style.Width = ""100%"";
					b.Style.Height = ""100%"";
					b.OnClick (ev =&gt; ""button clicked!!!"".LogInfo ());
				}))
				.Render ();						
	});
	
});</textarea></div>");

		}

		static void ShowCodeWin3(Element parent){
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Button&nbsp;(div,&nbsp;bt&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Text&nbsp;(<span class=""string"">""Window&nbsp;III""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick&nbsp;(evt&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;error=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Paragraph&nbsp;(p=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Style.Color=<span class=""string"">""red""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Append(&nbsp;<span class=""keyword"">new</span><span>&nbsp;Icon(i=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=<span class=""string"">""icon-minus-sign""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Style.MarginTop=<span class=""string"">""8px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Style.MarginRight=<span class=""string"">""8px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Append(<span class=""string"">""&nbsp;panel&nbsp;was&nbsp;closed&nbsp;""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;pn=<span class=""keyword"">new</span><span>&nbsp;Panel&nbsp;()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Caption&nbsp;(<span class=""string"">""No&nbsp;Closable&nbsp;No&nbsp;Collapsible""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Overlay&nbsp;(<span class=""keyword"">true</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Left&nbsp;(<span class=""string"">""30px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Top&nbsp;(<span class=""string"">""400px""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Width&nbsp;(<span class=""string"">""auto""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Closable&nbsp;(<span class=""keyword"">false</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Collapsible(<span class=""keyword"">false</span><span>)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.OnCloseHandler&nbsp;(p&nbsp;=&gt;&nbsp;error.LogInfo&nbsp;()&nbsp;);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Append(&nbsp;<span class=""keyword"">new</span><span>&nbsp;Button(&nbsp;b=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Text(<span class=""string"">""Click&nbsp;me""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Style.Width=<span class=""string"">""100%""</span><span>;&nbsp;b.Style.Height=</span><span class=""string"">""100%""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.OnClick(be=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Closable(<span class=""keyword"">true</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Collapsible(<span class=""keyword"">true</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Caption(<span class=""string"">""Now&nbsp;Closable&nbsp;and&nbsp;Collapsible""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Disabled=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pn.Render&nbsp;();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Button (div, bt =&gt; {
	bt.Text (""Window III"");
	bt.OnClick (evt =&gt; {

		var error= new Paragraph (p=&gt;{
			p.Style.Color=""red"";
			p.Append( new Icon(i=&gt;{
				i.ClassName=""icon-minus-sign"";
				i.Style.MarginTop=""8px"";
				i.Style.MarginRight=""8px"";
			}));
			p.Append("" panel was closed "");
		});
		
		var pn=new Panel ()
			.Caption (""No Closable No Collapsible"")
				.Overlay (true)
				.Left (""30px"")
				.Top (""400px"")
				.Width (""auto"")
				.Closable (false)
				.Collapsible(false)
				.OnCloseHandler (p =&gt; error.LogInfo () );
		pn.Append( new Button( b=&gt;{
			b.Text(""Click me"");
			b.Style.Width=""100%""; b.Style.Height=""100%"";
			b.OnClick(be=&gt;{
				pn.Closable(true);
				pn.Collapsible(true);
				pn.Caption(""Now Closable and Collapsible"");
				b.Disabled=true;
			});
		}));
		pn.Render ();						
	});
	
});</textarea></div>");
			
		}

	}
}



/*
new Div(null, div=>{
	div.ClassName="bs-docs-example";

	div.Append( new Button(div,b=>{
		b.Text("Simple Modal Dialog I");
		b.OnClick(evt=> Bootbox.Dialog("Your App Text: cayita is awesome....") );
	}));

	div.Append(@');
					
}).AppendTo(parent);
*/
