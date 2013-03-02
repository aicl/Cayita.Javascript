using System;
using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class UserForm:Form
	{
		public UserForm (Element parent):base(null)
		{
			var f = Element();

			f.ClassName="form-horizontal";
			f.Append("<style>.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  </style>");


			new Div(f, tb=>{
				tb.ClassName= "nav";
				new IconButton(tb, (bt, ibn)=>{
					ibn.ClassName="icon-file icon-large";
					bt.ID="btn-create";
				});

				new IconButton(tb, (bt, ibn)=>{
					ibn.ClassName="icon-save icon-large";
					bt.ID="btn-save";
					bt.Type("submit");
				});

				new IconButton(tb, (bt, ibn)=>{
					ibn.ClassName="icon-remove icon-large";
					bt.ID="btn-destroy";
				});
			});

			new InputText(f, e=>{
				e.Name="Id";
				e.Hide();
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
				e.DatepickerInit(new { closeText= "Close", dateFormat= "dd.mm.yy" });
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Email");
				e.Name="Email";
			}); 

			new TextField(f,(l, e)=>{
				l.Text("Rating");
				e.Name="Rating";
				e.AutoNumericInit(new {mDec=0});
			}); 

		
			new CheckboxField(f,(l, e)=>{
				l.Text("Is Active?");
				e.Name="Active";
			}); 

			f.JQuery("label").CSS("width", "80px");
			AppendTo(parent);
		}
	}
}

