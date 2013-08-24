using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoNavlist
	{
		public DemoNavlist ()
		{
		}

		public static void Execute(Atom parent)
		{

			var nb =new NavList ();

			nb.Add ("Tables");
			nb.Add ("Forms");
			nb.Add ("Modals");
			nb.Add ("Panels");
			nb.AddDivider ();
			nb.Add ("Exit");


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

			var rq =jQuery.GetData<string> ("code/demonavlist.html");
			rq.Done (s=> code.Text=s);

		}
	}
}

