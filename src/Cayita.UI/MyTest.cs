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
			
			var div = new Element<Div> ().Append (new Span (s=>{
				s.Text("Hola Munod 0");
				s.Style.Color="white";
				s.Style.BackgroundColor="black";
			}))
				.Apply (d => {
					d.Style(st=>{ st.BorderColor="red"; st.BackgroundColor="blue"; });

				});
			
			Firebug.Console.Log ("div", div);
			
			var div1 = new Element<Div> ().Append (new Span ().Text("HELLO WORLD") )
				.Apply (d => {
					d.Style(st=>{ st.BorderColor="red"; st.BackgroundColor="blue"; });

				});
			
			Firebug.Console.Log ("div1", div1);
			
			var div2 = new Element<Div> ()
				.Append<Span> (c => {
					c.Apply( e=> {e.Text("hola mundo").Style(st=>st.Color="green"); });
				});
			
			Firebug.Console.Log ("div2", div2);
			
			var div3 = new Element<Div> ()
				.Append<Span> (c => {
					c.Apply(e=>e.Text("hola mundo"));
				})
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
						i.Value="ESTO ES ROJO";
					}))
					.Append(new InputPassword(i=>{
						i.PlaceHolder("password2");
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
		}
	}
}

