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
			"SearchBox Local I".Header (3).AppendTo (parent);

			var countryStore1 = new CountryStore ( o=>o.LocalPaging=true);
			var config1 = new SearchBoxConfig<Country>{
				PlaceHolder="type country name",
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
			
						
			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore1, DefineColumnsWithFlags(), config1);
				div.Append(@"");
				
			}).AppendTo(parent);
			
			countryStore1.Read ();

			//
			"SearchBox Local II".Header (3).AppendTo (parent);

			var countryStore2 = new CountryStore (o=>o.LocalPaging=true);
			var config2 = new SearchBoxConfig<Country>{
				PlaceHolder="type country name",
				TextField="Name",
				IndexField="Code",
				LocalFilter= (t,v)=> t.Name.ToUpper().StartsWith(v.ToUpper()),
				SearchButton=true,
				ResetButton=true,
			};

			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore2, DefineColumns(), config2);

				div.Append(@"");

			}).AppendTo(parent);

			countryStore2.Read ();

			
			"SearchBox Remote".Header (3).AppendTo (parent);

			var countryStore3 = new CountryStore (o=>{o.PageSize=null; o.PageNumber=null;});
			var config3 = new SearchBoxConfig<Country>{
				PlaceHolder="type country name",
				TextField="Name",
				IndexField="Code",
				ResetButton=true,
				MinLength=1
			};

			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore3, DefineColumns(), config3);
				
				div.Append(@"");
				
			}).AppendTo(parent);

		}


		public static List<TableColumn<Country>> DefineColumns()
		{
			List<TableColumn<Country>> columns= new List<TableColumn<Country>>();
			columns.Add(new TableColumn<Country>(){
				Header= new TableCell(c=> c.Text("Country")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Name);
					}).Element();
				}
			});
			
						
			return columns;
		}

		public static List<TableColumn<Country>> DefineColumnsWithFlags()
		{
			List<TableColumn<Country>> columns= new List<TableColumn<Country>>();
			columns.Add(new TableColumn<Country>(){
				Header= new TableCell(c=> c.Text("Country")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						//c.SetValue(f.Name); c.Style.Width="40%";
						new Paragraph (c, p=>{
							
							p.Append( new Image(i=>{
								i.Src= "img/flags/"+f.Code.ToLower()+".png";
								i.Style.MarginRight="8px";
							}));
							p.Append(f.Name);
						});
						
						
					}).Element();
				}
			});
			
			
			return columns;
		}


	}
}
// rowclicked => click on a row
// row selected =>  click on a row o selected by keyboard
// EnterOnRow = > presss enter on a selected row...
// keyOnRow  