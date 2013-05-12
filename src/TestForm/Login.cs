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

			var username = new TextField (i => {
				i.PlaceHolder("your username");  i.Name="UserName";  i.ClassName="span12";
			}).AppendTo(form);

			var password= new TextField (i => {
				i.PlaceHolder("your password");  i.Name="Password";  i.ClassName="span12";
				i.Type="password";
			}).AppendTo(form);

			new SubmitButton ()
				.Text("Login")
					.AddClass("btn-info btn-block")
					.LoadingText("  authenticating ...")
					.AppendTo(form);  

			form.AddRule ((r,m) => {
				r.Input(username.Input);
				r.Rule.Required();
				r.Rule.Minlength(4);
				m.Required("se requiere el nombre de usuario");
				m.Minlength("minimo 4 caracteres");
			});

			form.AddRule ((r,m) => {
				r.Input(password.Input);
				r.Rule.Required();
				r.Rule.Minlength(2);
				m.Required("se requiere la contraseña");
				m.Minlength("minimo 2 caracteres");
			});

			form.SetSubmitHanlder (f => {
				Firebug.Console.Log(" este es mi submit !!!");
				f.Append( Alert.Info("Bienvenido " + username.Input.Value()) );
				form.Reset();
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

