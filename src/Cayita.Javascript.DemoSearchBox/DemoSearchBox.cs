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
			var countryStore1 = new CountryStore ();
			var config1 = new SearchBoxConfig<Country>{
				TextField="Name",
				IndexField="Code",
				LocalFilter= (t,v)=> t.Name.ToUpper().StartsWith(v.ToUpper()),
				ResetButton=true,
				OnRowSelectedHandler=(sb, sr)=>{
					if(sr!=null)
							("selected: "+ sr.Record.Code+" " +sr.Record.Name).LogInfo();
					else
						"nothing selected".LogInfo();
				}
			};
			
			"SearchBox".Header (3).AppendTo (parent);
			
			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore1, DefineColumns(), config1);
				
				div.Append(@"");
				
			}).AppendTo(parent);
			
			countryStore1.Read ();


			//
			var countryStore2 = new CountryStore ();
			var config2 = new SearchBoxConfig<Country>{
				TextField="Name",
				IndexField="Code",
				LocalFilter= (t,v)=> t.Name.ToUpper().StartsWith(v.ToUpper()),
				SearchButton=true,
				ResetButton=true,
			};

			"SearchBox".Header (3).AppendTo (parent);

			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore2, DefineColumns(), config2);

				div.Append(@"");

			}).AppendTo(parent);

			countryStore2.Read ();



			var countryStore3 = new CountryStore ();
			var config3 = new SearchBoxConfig<Country>{
				TextField="Name",
				IndexField="Code",
				ResetButton=true,
			};
			
			"SearchBox".Header (3).AppendTo (parent);
			
			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore3, DefineColumns(), config3);
				
				div.Append(@"");
				
			}).AppendTo(parent);
			
			//countryStore3.Read ();

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

