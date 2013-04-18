using System;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript
{
	[IgnoreNamespace]
	public class DemoSearchBox
	{
		public DemoSearchBox ()
		{
		}

		public static void Execute(Element parent)
		{

			var countryStore = new CountryStore ();
			var config = new SearchBoxConfig<Country>{
				TextField="Name",
				IndexField="Code",
				LocalFilter= (t,v)=> t.Name.ToUpper().StartsWith(v.ToUpper())
			};

			"SearchBox".Header (3).AppendTo (parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(countryStore, DefineColumns(), config).AppendTo(div);
			}).AppendTo(parent);

			countryStore.Read ();

		}


		public static List<TableColumn<Country>> DefineColumns()
		{
			List<TableColumn<Country>> columns= new List<TableColumn<Country>>();
			columns.Add(new TableColumn<Country>(){
				Header= new TableCell(c=> c.Text("Country")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Name); c.Style.Width="40%";
					}).Element();
				}
			});
			
						
			return columns;
		}



	}
}

