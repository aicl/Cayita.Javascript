using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita.Demo
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CustomerGrid:Grid<Customer>
	{
		[InlineCode("new Cayita.Demo.UI.CustomerGrid({parent},{store},{columns})")]
		public CustomerGrid (Atom parent,CustomerStore store, List<TableColumn<Customer>> columns=null):base(store, columns)
		{
		}
	}


	public static partial class UI
	{
		[PreserveCase]
		public static CustomerGrid CustomerGrid(Atom parent, CustomerStore store,List<TableColumn<Customer>> columns=null )
		{
			var g = Cayita.UI.Grid<Customer> (store, columns??CustomerDefaultColumns ).As<CustomerGrid> ();
			if (parent != null)
				parent.Append (g);
			return g;
		}

		public static List<TableColumn<Customer>> CustomerDefaultColumns {

			get {

				List<TableColumn<Customer>> columns= new List<TableColumn<Customer>>();
				columns.Add (new TableColumn<Customer>(){
					Header= new TableCellAtom(){Value="Company"},
					Value = u=> { 
						var c =new TableCellAtom(); 
						c.Style.Width="40%";
						c.Value= u.CompanyName;
						return c;
					}

				});

				columns.Add(new TableColumn<Customer>(){
					Header= new TableCellAtom(){Value="Contact"},
					Value = u=> { 
						var c =new TableCellAtom(); 
						c.Style.Width="40%";
						c.Value= u.ContactName;
						return c;
					}
				});

				columns.Add(new TableColumn<Customer>(){
					Header= new TableCellAtom(){Value="Country"},
					Value = u=> { 
						var c =new TableCellAtom(); 
						c.Value= u.Country;
						return c;
					}
				});

				return columns;
			}
		}

	}
	
}



