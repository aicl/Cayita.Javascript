using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;
using jQueryApi;
using Cayita.Javascript.Plugins;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class DemoTables
	{
		public DemoTables (){}

		public static void Execute(Element parent)
		{
			var ug= UserGrid.Create(null, new UserStore());
			ug.AppendTo(parent);
			ug.GetStore().Read();

			var u = new User();
			ug.GetStore().Create(u);

			Cayita.Javascript.Firebug.Console.Log("user", new User());
		}
	}
}

