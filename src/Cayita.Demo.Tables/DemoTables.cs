using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using jQueryApi;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoTables
	{

		public DemoTables ()
		{
		}

		public static void Execute (Atom parent){

			Task v= new Task( ()=> Firebug.Console.Log("hello"));
			v.Start ();

			var store = new UserStore ();
			var grid = new UserGrid (parent, store);
			store.Read ();

			var form = new UserForm (parent);

			form.ButtonCreate.Disabled = false;

			form.ButtonCreate.Clicked+= (e) => {
				grid.ClearSelection();
				form.Clear();
			};

			form.ButtonDestroy.Clicked+= (e) => {
				form.Clear();
				var u = store.First(r=>r.Id== int.Parse( grid.SelectedRow.RecordId ));
				store.Remove(u);
			};

			form.Changed+= (e) => {
				form.ButtonSave.Disabled= !form.HasChanges();
			};
				
			form.Updated += (fr, ac) => {
				form.ButtonDestroy.Disabled= ac == FormUpdatedAction.Clear;
				form.ButtonSave.Disabled=true;
			};

			form.SubmitHandler = fr => SubmitHandler (grid, form, store);

			grid.RowSelected += (g, row) => {
				var u =  store.First(r=>r.Id== int.Parse( row.RecordId));
				form.PopulateFrom(u);
			};


			parent.Append("Paged Tables".Header (3));


			var cu = new CustomerStore ();
			new CustomerGrid(parent, cu);
			parent.Append (new StorePager<Customer>(cu));
			cu.Read ();


			parent.Append ("Filters".Header (3));
			var cu2 = new CustomerStore ();
			new TextInput (parent, i=>	{	
				i.Placeholder="Country";
				i.On("keyup", evt=>{
					var st = i.Value.ToUpper();
					cu2.Filter( f=>f.Country.ToUpper().StartsWith(st));
				});
			});

			new CustomerGrid (parent,  cu2);
			parent.Append (new StorePager<Customer>(cu2));
			cu2.Read ();

			parent.Append ("C# code".Header(3));

			var rq =jQuery.GetData<string> ("code/demotables.html");
			rq.Done (s=> {
				var code=new Div();
				code.InnerHTML= s;
				parent.Append(code);
			});



		}

		static void SubmitHandler(Grid<User> grid, UserForm form, UserStore store)
		{
			var u = form.CopyToUser ();
			store.Save (u);
			grid.Select (u.Id, true);
		}

	}
}



