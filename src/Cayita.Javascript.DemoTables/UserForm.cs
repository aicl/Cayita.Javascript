using System.Runtime.CompilerServices;
using Cayita.UI;
using System.Html;
using System.Collections.Generic;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class UserForm:Form
	{
		FormElement f;

		public ButtonElement GetSaveButton()
		{
			return f.FindById<ButtonElement>("btn-save");
		}

		public ButtonElement GetDestroyButton()
		{
			return f.FindById<ButtonElement>("btn-destroy");
		}

		public ButtonElement GetCreateButton()
		{
			return f.FindById<ButtonElement>("btn-create");
		}

		public UserForm (Element parent, List<RadioItem> levelOptions):base(null)
		{
			f = Element();

			f.ClassName="form-horizontal";
			f.Append("<style>.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  </style>");

			new Div(f, tb=>{
				tb.ClassName= "nav";
				new IconButton(tb, (bt, ibn)=>{
					ibn.ClassName="icon-file icon-large";
					bt.ID="btn-create";
					bt.Disabled=true;
				});

				new IconButton(tb, (bt, ibn)=>{
					ibn.ClassName="icon-save icon-large";
					bt.ID="btn-save";
					bt.Type("submit");
					bt.Disabled=true;
				});

				new IconButton(tb, (bt, ibn)=>{
					ibn.ClassName="icon-remove icon-large";
					bt.ID="btn-destroy";
					bt.Disabled=true;
				});
			});

			new InputText(f, e=>{
				e.Name="Id";
				e.Hide();
				e.IsNumeric();
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Name");
				e.Name="Name";
			}); 

			new TextField(f,(l, e)=>{
				l.Text("City");
				e.Name="City";
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Address");
				e.Name="Address";
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Birthday");
				e.Name="DoB";
				e.Datepicker(new {  dateFormat= "dd.mm.yy" });
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Email");
				e.Name="Email";
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Rating");
				e.Name="Rating";
				e.AutoNumeric();
			}); 

			new RadioField(f, "Level", "Level", levelOptions);

			new CheckboxField(f,(l, e)=>{
				l.Text("Is Active?");
				e.Name="IsActive";
			}); 

			f.JQuery("label[class='control-label']").CSS("width", "80px");
			AppendTo(parent);
		}
	}
}
