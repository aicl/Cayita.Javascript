using System;
using Cayita.Javascript.UI;
using System.Html;
using Cayita.Javascript.Data;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class UserGrid:HtmlGrid<User>
	{
		public UserGrid (Element parent, UserStore store, List<TableColumn<User>> columns)
			:base(parent, store, columns)
		{
		}

		public static UserGrid Create(Element parent, UserStore store)
		{
			return new UserGrid(parent, store, DefineColumns());
		}

		public static List<TableColumn<User>> DefineColumns()
		{
			List<TableColumn<User>> columns= new List<TableColumn<User>>();
			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Name")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.Name);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("City")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.City);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Birthday")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.DoB.ToString());
					}).Element();
				}
			});

			return columns;
		}

	}
}

