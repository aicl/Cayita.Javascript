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
				Header= new TableCell(c=> c.Text("Address")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.Address);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Birthday")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.DoB.ToString("dd.MM.yyyy"));
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Email")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.Email);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Rating")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.Rating.ToString());
						c.AutoNumericInit(new {mDec=0});
						c.Style.TextAlign="center";
					}).Element();
				},

				AfterCellCreate= (f,row)=>{
					row.AddClass(f.Rating==10? "success": f.Rating<=5?"warning":"");
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Level")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Text(f.Level);
						c.Style.Color= f.Level=="A"?"green": f.Level=="B"?"orange": "red";
						c.Style.TextAlign="center";
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Active ?")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.Style.TextAlign="center";
						c.Append( new Icon(c, i=>{
							i.ClassName= f.IsActive? "icon-ok-circle": "icon-ban-circle";
						}).Element());

					}).Element();
				},
				AfterCellCreate= (f,row)=>{
					row.Style.Color= f.IsActive?"black":"grey";
				}
			});

			return columns;
		}

	}
}

