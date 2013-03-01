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
			var ug= UserGrid.Create(parent, new UserStore());
			var uf = new UserForm(parent).Element();

			ug.OnRowSelected+=( (g, sr)=>{
				uf.Load<User>( sr!=null? sr.Record: new User());
			});

			ug.GetStore().Read();


		}
	}
}

