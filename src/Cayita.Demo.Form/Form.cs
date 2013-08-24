using System.Runtime.CompilerServices;
using Cayita;
using System.Html;
using jQueryApi;

namespace Cayita.Demo

{
	[IgnoreNamespace]
	public class DemoForm
	{
		public DemoForm(){}

		public static void Execute(Atom parent)
		{
			var form = new Form ();
			new Fieldset (form, fs => {
				new Legend (fs,"Legend");
				new Label(fs, "LabelText");
				new TextInput(fs, i=>{
					i.Placeholder="type something";
					i.Name="text";
				});

				new Span(fs, s=>{s.Text="Example block-level help text here"; s.ClassName="help-block";});

				new CheckField(fs, cf=>{
					cf.Name="allow";
					cf.Input.Text="Check me";
					cf.Input.Checked=true;
				});

				new SubmitButton(fs, b=>{
					b.Text="Send";
					b.Clicked+= (e) =>{ 
						e.PreventDefault();
						form.JQuery.Serialize().LogInfo();
					};
				});
				form.Append(fs);
			});

			parent.JQuery.Append("Default styles".Header (3)).Append (form);

			var sform = new Form ();
			new TextInput (sform, i => {
				i.Name="stext";
				i.Placeholder="search for";
				i.Required=true;
				i.ClassName="input-medium search-query";
				i.MaxLength=8;
				i.MinLength=3;
			});

			new SubmitButton(sform, b=>{
				b.Text="Search...";
				b.Clicked+= (e) =>{ 
					if(!sform.CheckValidity()) return ;
					sform.JQuery.Serialize().LogInfo();
				};
			});

			parent.JQuery.Append("Optional Layouts".Header (3)).Append("Search Form".Header(4)).Append (sform);

			var lform = new Form ();
			lform.SubmitHandler = f =>  f.JQuery.Serialize().LogInfo() ;
			lform.ClassName = "form-inline";
			new EmailInput (lform, i => {
				i.Placeholder = "your email";
				i.Required=true;
				i.Name="email";
			});

			new PasswordInput (lform, i => {
				i.Placeholder = "your password";
				i.Required=true;
				i.Name="password";
				i.MinLength=4;
			});

			new CheckInput (lform,i =>{
				i.Name="remember";
				i.Text="Remember?";
				i.Checked=true;
			});
					
			new SubmitButton (lform, b => b.Text = "submit");
	
			parent.JQuery.Append("Inline Form".Header(4)).Append (lform);

			new Form (f=>{
				f.ClassName="form-horizontal";

				new EmailField(f,i=>{
					i.Text="Email";
					i.Placeholder="your email";
					i.Input.Required=true;
					i.Name="email";
				});

				new PasswordField(f,i=>{
					i.Text="Password";
					i.Placeholder="your password";
					i.Input.Required=true;
					i.Input.MinLength=4;
					i.Name="password";
				});

				new CheckField(f, i=>{
					i.Input.Text="Remember";
					i.Input.Checked=true;
					i.Name="remember";
					new SubmitButton(i.Controls, b=>	b.Text="Login");
				});

				f.SubmitHandler= fr=> fr.JQuery.Serialize().LogInfo();

				parent.JQuery.Append("Horizontal Form".Header(4)).Append (f);
			});


			var login = new Div ("span4 offset3 well");
			login.Append (new Legend("Login Form"));

			new Form (login, f => {
				var nm = new TextField(f);
				nm.Placeholder="user name";
				nm.Name ="username";
				nm.Input.ClassName="span12";
				nm.Input.Required=true;
				nm.Input.MinLength=8;

				var pwd = new PasswordField(f);
				pwd.Placeholder="password";
				pwd.Name ="password";
				pwd.Input.ClassName="span12";
				pwd.Input.Required=true;
				pwd.Input.MinLength=6;
				pwd.Input.MaxLength=10;

				var rmb = new CheckField(f);
				rmb.Name="remember";
				rmb.Input.Text="Remember";

				var sb = new SubmitButton(f);
				sb.Text="Login";
				sb.AddClass("btn-info btn-block");

				f.SubmitHandler= fr=>{
					sb.Disabled=true;
					Window.SetTimeout(()=>{  
						sb.Disabled=false;
						"Welcome {0}".Fmt(nm.Value).LogSuccess();
						f.Reset();
					}, 1000);  
				};

			});

			parent.JQuery.Append ("Samples".Header(3)).Append ("Login Form".Header(4))
				.Append (UI.CreateContainer(ct=> UI.CreateRow(ct, rw=> rw.Append(login))));

			var contact = new Div ("container");
			new Form (contact, f=>{
				f.ClassName="well span8";
				UI.CreateRowFluid(f, row=>{
					new Div(row, p=>{
						p.ClassName="span5";
						new TextField(p, tf=>{tf.Name="firstname"; tf.Required=true; tf.Text="FirstName"; tf.Input.ClassName="span12"; });
						new TextField(p, tf=>{tf.Name="lastname"; tf.Required=true; tf.Text="LastName"; tf.Input.ClassName="span12"; });
						new EmailField(p, tf=>{tf.Name="email"; tf.Required=true; tf.Text="Email";tf.Input.ClassName="span12";});

						new SelectField<string>(p, sf=>{
							sf.Text="Subject";
							sf.Name="subject";
							sf.Input.ClassName="span12";
							sf.Input.Add("", "Choose one...");
							sf.Input.Add("1", "General Customer Service");
							sf.Input.Add("2", "Suggestions");
							sf.Input.Add("3", "Product suport");
							sf.Input.Add("4", "Bug");
							sf.Input.Required=true;
						});

					});
					new Div(row, p=>{
						p.ClassName="span7";
						new TextAreaField(p, tf=>{tf.Name="message"; tf.Rows=11; tf.Text="Message";tf.Input.ClassName="span12";});
					});

					new SubmitButton(row, bt=>{  
						bt.AddClass("btn-primary pull-right");  
						bt.Text="Send";  
					});  
				});

				f.SubmitHandler=fr=> AlertFn.Success(fr.FirstChild,"Message sent",true, 5000);
			});

			parent.JQuery.Append("Conctact Form".Header(4)).Append (contact);

			parent.Append ("C# code".Header(3));

			var rq =jQuery.GetData<string> ("code/demoform.html");
			rq.Done (s=> {
				var code=new Div();
				code.InnerHTML= s;
				parent.Append(code);
			});

		
		}
	}
}

//https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/Forms/Data_form_validation?redirectlocale=en-US&redirectslug=HTML%2FForms%2FData_form_validation


