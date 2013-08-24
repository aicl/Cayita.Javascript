using System;
using System.Runtime.CompilerServices;
using jQueryApi;


namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoNavbar
	{
		public DemoNavbar ()
		{
		}

		public static void Execute(Atom parent)
		{
			var nb =new NavBar ();
			nb.BrandText="App Title";
			nb.Add ("Home");
			nb.Add ("License");
			nb.Add ("Contact");

			var dd = new DropdownMenu ();
			dd.Text = "Config";
			dd.Nav.Add ("Users");
			dd.Nav.Add ("Groups");

			nb.Add (dd);

			var log = new Div ();
			var code = new Div ();

			new Div (d=>{
				d.ClassName="bs-docs-example";
				d.JQuery.Append(nb).Append(log).Append("C# code".Header(4)).Append(code);
				parent.Append(d);
			});

			nb.Selected += (e) => {
				var i = e.CurrentTarget.As<NavItem> ();
				log.Text=  "{0} Clicked".Fmt(i.Text); 
			};

			var rq =jQuery.GetData<string> ("code/demonavbar.html");
			rq.Done (s=> code.Text=s);

		}
	}
}

