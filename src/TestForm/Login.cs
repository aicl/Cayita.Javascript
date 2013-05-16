using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using jQueryApi;

namespace TestForm
{
	[IgnoreNamespace]
	public class Login
	{
		public Login ()
		{
		}

		public static void Execute (Element parent)
		{

			var form = new Form ();

			var username = new TextField (form)
				.PlaceHolder ("your username")
					.Name ("UserName");

			var password = new PasswordField (form)
				.PlaceHolder ("your password")
					.Name ("Password");

			var text = new TextField (form)
				.PlaceHolder ("your comments")
					.Text ("Comments");

			new CheckboxField (form).Text ("check me ");


			new RadioGroup (form)
				.Text ("your favourite language")
					.Name ("language").
					Add (new GroupItem{Text="CSharp",Value="1"})
					.Add (new GroupItem{Text="Java",Value="2"});

			new RadioGroup ()
				.Text ("your favourite programming language")
					.AddClass("well")
					.Name ("language")
					.Add (new GroupItem{Text="CSharp",Value="1"})
					.Add (new GroupItem{Text="Java",Value="2"})
					.Inline (false)
					.AppendTo (form);

			var cbg = new CheckGroup (form)
				.AddClass ("well")
					.Text("languages")
					.Add (new GroupItem{Text="English", Value="1"})
					.Add (new GroupItem{Text="Spanish", Value="2"})
					.Inline (false);

			cbg.Style.CssText = "color:darkblue;font-weight: bold"; 
			cbg.ControlLabel.Style.CssText = "font-weight: bold"; 



			new SubmitButton ()
				.Text("Login")
					.AddClass("btn-info btn-block")
					.LoadingText("  authenticating ...")
					.AppendTo(form);  

			form.AddRule ((r,m) => {
				r.Input(username);
				r.Rule.Required();
				r.Rule.Minlength(4);
				m.Required("se requiere el nombre de usuario");
				m.Minlength("minimo 4 caracteres");
			});

			form.AddRule ((r,m) => {
				r.Input(password);
				r.Rule.Required();
				r.Rule.Minlength(2);
				m.Required("se requiere la contraseña");
				m.Minlength("minimo 2 caracteres");
			});

			form.SetSubmitHanlder (f => {
				Firebug.Console.Log(" este es mi submit !!!");
				f.Append( Alert.Info("Bienvenido " + username.Value()) );
				//form.Reset();
				text.SlideToggle();
			});

			form.Validate ();

			form.AppendTo (parent);

			/*
			new Form(element, fe=>{  
				new TextField(fe, i=>{  
					i.PlaceHolder("your username");  i.Name="UserName";  i.ClassName="span12";
				});  
				
				new TextField(fe, i=>{  
					i.PlaceHolder("your password");  i.Name="Password"; i.ClassName="span12";  
					i.Required(); i.MinLength(6);  
					i.Type="password";  
				});  
				
				new CheckboxField(fe, (lb, cb)=>{  
					lb.Text("Remember me");  
					cb.Name="Remember";  
				});  
				
				new SubmitButton(fe, b=>{  
					b.Text("Login");  
					b.AddClass("btn-info btn-block");  
					b.LoadingText("  authenticating ...");  
				});  
				
				fe.Validate( new ValidateOptions().SetSubmitHandler(f=>{  
					var bt =f.Find<ButtonElement>("[type=submit]");  
					bt.ShowLoadingText();  
					Window.SetTimeout(()=>{  
						bt.ResetLoadingText();  
						Alert.Success(f,"Welcome : "+ f.FindByName<InputElement>("UserName").GetValue(),false);  
						f.Clear();  
					}, 1000);  
				}));  
			});  

*/

		}

	}
}

