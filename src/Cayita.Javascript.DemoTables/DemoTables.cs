using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;
using System.Collections.Generic;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class DemoTables
	{
		public DemoTables (){}

		public static void Execute(Element parent)
		{
			var ug= UserGrid.Create(parent, new UserStore());
			var uf = new UserForm(parent, new List<RadioItem>(
				new RadioItem[]{
				new RadioItem{Text="A", Value="A"},
				new RadioItem{Text="B", Value="B"},
				new RadioItem{Text="C", Value="C"}
			})).Element();

			ug.OnRowSelected+=( (g, sr)=>{
				uf.Load<User>( sr!=null? sr.Record: new User());
			});

			ug.GetStore().Read();


		}
	}
}

