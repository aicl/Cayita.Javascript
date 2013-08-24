using System;
using System.Runtime.CompilerServices;

namespace Cayita.Demo
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class UserForm:Form
	{
		[InlineCode("new Cayita.Demo.UI.UserForm({parent})")]
		public UserForm(Atom parent){}

		[IntrinsicProperty]
		public ButtonIcon ButtonCreate{ get; internal set; }
		[IntrinsicProperty]
		public ButtonIcon ButtonSave{ get; internal set; }
		[IntrinsicProperty]
		public ButtonIcon ButtonDestroy{ get; internal set; }

		[IntrinsicProperty]
		public Func<User> CopyToUser{ get; internal set; }

	}

	public partial class UI
	{
		[PreserveCase]
		public static  UserForm UserForm (Atom parent)
		{
			var f = new Form ().As<UserForm>();

			f.ClassName="form-horizontal";
			f.Append("<style>.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  </style>");
			new Div(f, tb=>{
				tb.ClassName="nav";
				f.ButtonCreate=new ButtonIcon(tb, bt=>{bt.IconClass="icon-file icon-large"; bt.Disabled=true;});
				f.ButtonSave=new ButtonIcon(tb, bt=>{bt.IconClass="icon-save icon-large"; bt.Disabled=true; bt.Type="submit";});
				f.ButtonDestroy=new ButtonIcon(tb, bt=>{bt.IconClass="icon-remove icon-large"; bt.Disabled=true; });
			});

			new NumericInput (f, i => {
				i.Name = "Id";
				i.Hidden = true;
			});

			new TextField(f, i=>{i.Name="Name"; i.Text="Name"; i.Required=true;});
			new TextField(f, i=>{i.Name="City"; i.Text="City"; i.Required=true;});
			new TextField(f, i=>{i.Name="Address"; i.Text="Address"; });
			new DateField(f, i=>{i.Name="DoB"; i.Text="Birthday"; i.Picker.DateFormat="dd.mm.yy"; i.Required=true; });
			new EmailField(f, i=>{i.Name="Email"; i.Text="Email"; i.Required=true;});
			new IntField(f, i=>{i.Name="Rating"; i.Text="Rating"; });
			new RadioGroup<string> (f, rg => {
				rg.Required = true;
				rg.Text = "Level";
				rg.Name = "Level";
				rg.Add ("A");
				rg.Add ("B");
				rg.Add ("C");
			});

			new CheckField(f, i=>{i.Name="IsActive"; i.Input.Text="Is active?";});
			f.JQuery.Find("label[class='control-label']").CSS("width", "80px");

			f.CopyToUser= ()=>{
				User u = new User();
				f.Populate (u);
				return u;
			};

			parent.Append (f);
			return f;

		}
	}

}


