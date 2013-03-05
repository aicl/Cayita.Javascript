using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;
using System.Collections.Generic;
using Cayita.Javascript.Plugins;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class DemoTables
	{
		public DemoTables (){}

		public static void Execute(Element parent)
		{
			var ug= UserGrid.Create(parent, new UserStore());

			var uf = new UserForm(parent, new List<RadioItem>(
				new RadioItem[]{
				new RadioItem{Text="A", Value="A"},
				new RadioItem{Text="B", Value="B"},
				new RadioItem{Text="C", Value="C"}
			}));

			uf.GetCreateButton().Disabled=false;

			uf.GetCreateButton().OnClick(evt=>{
				ug.SelectRow();
			});

			uf.GetDestroyButton().OnClick(evt=>{
				ug.GetStore().Remove( ug.GetSelectedRow().Record);
			});


			uf.Element().OnChange(e=>{
				uf.GetSaveButton().Disabled=!uf.Element().DataChanged();
			});


			ug.OnRowSelected+=( (g, sr)=>{

				uf.GetSaveButton().Disabled=true;
				if(sr!=null)
				{
					uf.Element().Load<User>( sr.Record);
					uf.GetDestroyButton().Disabled=false;
				}
				else
				{
					uf.Element().Load<User>( new User());
					uf.GetDestroyButton().Disabled=true;
				}

			});

			var vo = new ValidateOptions()
				.SetSubmitHandler( form=>{
					var user = form.LoadTo<User>();
					ug.GetStore().Save(user);
					ug.SelectRow( user.Id);
				});

			uf.Element().Validate(vo);

			ug.GetStore().Read();


		}
	}
}

