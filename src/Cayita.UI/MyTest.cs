using System;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{
	public class Test
	{
		public static void Main()
		{
			jQuery.OnDocumentReady (() => {
				new Test();
			});
		}

		public Test()
		{
		
			
			var div2 = new Element<Div> ()
				.Append<IconButton> (c => {
					c.Apply( ib=>{
						ib.Button(b=>b.Append("button-text"));
						ib.Icon(i=>i.ClassName("icon-th-large"));

					});
				})
					.Append<IconAnchor> (c => {
						c.Apply( ib=>{
							ib.Anchor(a=> a.Append(" ** Text **"));
						ib.Icon(i=>i.ClassName("icon-th-large"));
						
					});
				})
					.Append( new IconButton()
					        .Icon(i=>i.ClassName("icon-th-large"))
					        .Button(b=>b.Append(" on more ..")));

			div2.AppendTo (Document.Body);

			
			var div3 = new Element<Div> ()
				.Append( new Span(s=>{s.Text("Hola mundo"); s.Style.Color="blue"; })
				)
					.Append<Span>(e =>{
						e.Apply(m=>{m.Text("hello word").Style().Color="orange";});
					})
					.Append( new Input( t=>{
						t.Name="NOMBRE";
						t.AddClass("input-class");
						t.Value="Un valor INicia";
					}))
					.Append( new InputText().Apply(i=>{
						i.ClassName="input-class";
						i.Style.Color="red";
						i.Style.MarginBottom="0px";
						i.Value="ESTO ES ROJO";
					}))
					.Append(new InputPassword(i=>{
						i.PlaceHolder("password2");
						i.Style.MarginBottom="0px";
					}))
					.Append<Anchor>(a=>{
						a.Apply(ae=>{
							ae.Element().OnClick(ev=>Window.Alert("Click"));
						});
						a.Append( new Icon(i=> i.ClassName="icon-th-large" ));
						a.Append( new Span(s=>s.Text("Helo !!!")));
					})
					.Append( new Button(b=>{b.Text("Button"); b.OnClick(ev=>Window.Alert("Click"));
					}));
			
			Firebug.Console.Log ("div3", div3);
			
			div3.AppendTo (Document.Body);


			var div4 = new Element<Div> ()
				.Append<Label> (c => { 
					c.Apply(l=> { l.JQuery().Text("Check "); l.ClassName("checkbox"); });
					c.Append( new InputCheckBox(cb=>cb.Checked=true));
				})
					.Append<Label> (c => { 
						c.Apply(l=> {
							l.For("opt-id-1").JQuery().Text("Opt 1 "); 
							l.ClassName("radio");
						});
						c.Append( new InputRadio(r=>{r.Name="Option"; r.ID="opt-id-1";}));
					})
					.Append<Label> (c => { 
						c.Apply(l=> {
							l.For("opt-id-2").JQuery().Text("Opt 2 "); 
							l.ClassName("radio");
						});
						c.Append( new InputRadio(r=>{r.Name="Option"; r.ID="opt-id-2";} ));
					})
					.Append<Div>(cg=>{
						cg.ClassName("control-group");
						cg.Append(new Label(l=>{
							l.InnerText="Options:";l.ClassName="control-label";  
							l.Style.Padding="5px"; l.Style.CssFloat="left";
						}));
						cg.Append<Div>(ct=>{
							ct.ClassName("controls");
							ct.Append( new Label(l=>{
								l.ClassName="radio inline";
								l.Text("Option 1");
								l.Append(new InputRadio(r=>{ r.Name="Option"; r.Value="1";}));
							}));
							ct.Append( new Label(l=>{
								l.ClassName="radio inline";
								l.Text("Option 2");
								l.Append(new InputRadio(r=>{ r.Name="Option"; r.Value="2";}));
							}));
						});
					});
			
			div4.AppendTo (Document.Body);
		}
	}
}

