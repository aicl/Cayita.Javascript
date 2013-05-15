using Cayita.UI;
using System.Html;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class UserGrid:HtmlGrid<User>
	{
		UserStore us;

		public UserGrid (Element parent, UserStore store)
			:this(parent, store, DefineColumns())
		{
		}

		public UserGrid (Element parent, UserStore store, List<TableColumn<User>> columns)
			:base( store, columns)
		{
			AppendTo(parent);
			us=store;
		}

		public new  UserStore GetStore(){
			return us;
		}

		public static List<TableColumn<User>> DefineColumns()
		{
			List<TableColumn<User>> columns= new List<TableColumn<User>>();
			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Name")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Name);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("City")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.City);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Address")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Address);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Birthday")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.DoB.ToString("dd.MM.yyyy"));
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Email")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Email);
					}).Element();
				}
			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Rating")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Rating.ToString());
						c.AutoNumeric(new {mDec=0});
						c.Style.TextAlign="center";
					}).Element();
				},

			});

			columns.Add(new TableColumn<User>(){
				Header= new TableCell(c=> c.Text("Level")).Element(),
				Value= (f)=>{
					return new TableCell( c=>{
						c.SetValue(f.Level);
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
					row.AddClass(f.Rating>=10000? "success": f.Rating<=5000?"warning":"");
				}
			});

			return columns;
		}

	}
}