using Cayita.UI;
using System.Html;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class CustomerGrid:HtmlGrid<Customer>
	{
		CustomerStore us;
		
		public CustomerGrid (Element parent, CustomerStore store)
			:this(parent, store, DefineColumns())
		{
		}
		
		public CustomerGrid (Element parent, CustomerStore store, List<TableColumn<Customer>> columns)
			:base( store, columns)
		{
			AppendTo(parent);
			us=store;
		}
		
		public new  CustomerStore GetStore(){
			return us;
		}
		
		public static List<TableColumn<Customer>> DefineColumns()
		{
			List<TableColumn<Customer>> columns= new List<TableColumn<Customer>>();
			columns.Add(new TableColumn<Customer>(){
				Header= new TableCell(c=> c.Text("Company")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.CompanyName); c.Style.Width="40%";
					}).Element();
				}
			});
			
			columns.Add(new TableColumn<Customer>(){
				Header= new TableCell(c=> c.Text("Contact")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.ContactName); c.Style.Width="40%";
					}).Element();
				}
			});

			columns.Add(new TableColumn<Customer>(){
				Header= new TableCell(c=> c.Text("Country")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Country);
					}).Element();
				}
			});

			return columns;
		}
		
	}
}