using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoModals
	{
		public DemoModals ()
		{
		}

		public static void Execute (Atom parent){

			var nb =new NavList ();
					
			nb.Add ("Simple Bootbox Dialog", handler: e=> Bootbox.Dialog("cayita is awesome"));
			nb.Add ("Custom Bootbox.Dialog I", handler:  CustomDialog_1);
			nb.Add ("Custom Bootbox.Dialog 2", handler:  CustomDialog_2);
			nb.Add ("Custom Bootbox.Dialog 3", handler:  CustomDialog_3);
			nb.AddDivider ();

			nb.Add ("Alert", handler: e=> Bootbox.Alert("Alert!",()=> "Alert callback...".LogInfo()));
			nb.Add ("Confirm", handler: e=> Bootbox.Confirm("Confirm...",(c)=> ("Confirm callback "+c).LogInfo()));
			nb.Add ("Prompt", handler: e=> Bootbox.Prompt("Pormpt...",(s)=> ("Prompt callback "+s).LogInfo()));

			var code = new Div ();

			new Div (d=>{
				d.ClassName="bs-docs-example";
				d.JQuery.Append(nb).Append("C# code".Header(4)).Append(code);
				parent.Append(d);
			});

			var rq =jQuery.GetData<string> ("code/demomodals.html");
			rq.Done (s=> code.InnerHTML=s);

		}

		static void CustomDialog_1(jQueryEvent e){
			var i = e.CurrentTarget.As<NavItem> ();

			Bootbox.Dialog (i.Text,  new BootboxHandler {
				Callback=()=> i.Text.LogInfo(),
				Label="My Custom Label"

			});
		}

		static void CustomDialog_2(jQueryEvent e){
			var i = e.CurrentTarget.As<NavItem> ();

			Bootbox.Dialog (i.Text,  new BootboxHandler {
				Callback=()=> i.Text.LogInfo(),
				Label="Go",
				Class = "btn-info"
			},
			new BootboxOptions{
				Header="Custom Header"
			});
		}

		static void CustomDialog_3(jQueryEvent e){
			var item = e.CurrentTarget.As<NavItem> ();

			var dd = new Div(c=>{
				new TextField(c, i=>i.Placeholder="name");
				new CheckField(c,i=>{
					i.Input.Text="I like cayita";
					i.Input.Checked=true;
					i.Input.Disabled=true;
				});
				new TextAreaInput(c, i=>i.Value="cayita is amazing ...");
			});

			Bootbox.Dialog (dd,  new BootboxHandler {
				Callback=()=> item.Text.LogInfo(),
				Label="Go",
				Class="btn-info",

			},
			new BootboxOptions {
				Header=item.Text,
				Classes="modal-large",
				OnEscape=()=> "Esc pressed".LogInfo()
			});

		}
	}
}

