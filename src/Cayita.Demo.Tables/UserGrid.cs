using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Demo
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class UserGrid:Grid<User>
	{
		[InlineCode("new Cayita.Demo.UI.UserGrid({parent},{store},{columns})")]
		public UserGrid(Atom parent, UserStore store, List<TableColumn<User>> columns=null):base(store, columns)
		{
		}
	}


	public partial class UI{

		[PreserveCase]
		public static UserGrid UserGrid(Atom parent, UserStore store, List<TableColumn<User>> columns=null)
		{
			var g =   new Grid<User>(store, columns ?? UserDefaultColumns).As<UserGrid>();
			parent.Append (g);
			return g;
		}

		public static List<TableColumn<User>> UserDefaultColumns{

			get
			{
				List<TableColumn<User>> columns = new List<TableColumn<User>> ();
				columns.Add (new TableColumn<User>("Name", "Name", (u,c)=>{
					c.Value= u.Name;
				}));

				columns.Add (new TableColumn<User>("City", "City", (u,c)=>{
					c.Value= u.City;
				}));

				columns.Add (new TableColumn<User>("Address", "Address", (u,c)=>{
					c.Value= u.Address;
				}));

				columns.Add (new TableColumn<User>("Birthday", "Birthday", (u,c)=>{
					c.Value=  u.DoB.ToString("dd.MM.yyyy");
				}));

				columns.Add (new TableColumn<User>("Email", "Email", (u,c)=>{
					c.Value= u.Email;
				}));

				columns.Add (new TableColumn<User>("Rating", "Rating", (u,c)=>{
					c.Value= u.Rating;
					Plugins.AutoNumeric(c, new NumericOptions{DecimalPlaces=0});
					c.Style.TextAlign="center";
				}));

				columns.Add (new TableColumn<User>("Level", "Level", (u,c)=>{
					c.Value=u.Level;
					c.Style.Color= u.Level=="A"?"green": u.Level=="B"?"orange": "red";
					c.Style.TextAlign="center";
				}));

				columns.Add (new TableColumn<User>{
					Header=new TableCellAtom{Value="Active?"},
					Value = u=> { 
						var c =new TableCellAtom(); 
						c.Style.TextAlign="center";
						c.Append( new CssIcon( u.IsActive?"icon-ok-circle": "icon-ban-circle"));
						return c;
					},
					AfterCellCreated= (f,row)=>{
						row.Style.Color= f.IsActive?"black":"grey";
						row.AddClass(f.Rating>=10000? "success": f.Rating<=5000?"warning":"");
					}
				});
				return columns;
			}
		}

	}

}
