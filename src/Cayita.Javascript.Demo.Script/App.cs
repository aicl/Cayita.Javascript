using System;
using jQueryApi;
using Cayita.Javascript;
using Cayita.Javascript.UI;
using System.Html;
using Cayita.Javascript.Plugins;
using System.Runtime.CompilerServices;
using Aicl.Calamar.Scripts.Modelos;

namespace Aicl.Calamar.Scripts.ModuloAuth
{
	[IgnoreNamespace]
	public class App
	{
		TopNavBar TopNavBar {get;set;}
		Div Work {get;set;}


		public static void Main ()
		{
			jQuery.OnDocumentReady( ()=>{
				
				var app = new App();
				app.ShowTopNavBar();
				app.ShowLoginForm();
			});
		}
		
		void OnLogin(LoginResponse loginResponse, LoginForm lf)
		{
			Cayita.Javascript.Firebug.Console.Log("App.OnLogin ", loginResponse);
			var a = TopNavBar.GetPullRightAnchor().JSelect().Text(lf.UserName);
			TopNavBar.GetPullRightParagraph().JSelect().Text("");
			TopNavBar.GetPullRightParagraph().JSelect().Append(a);
			lf.Close();
			ShowUserMenu(loginResponse);
			
		}
		
		void ShowTopNavBar()
		{
			TopNavBar= new TopNavBar(default(Element),"Cayita.Javascript - demo","No logged","",navlist=>{
				
			});
			Document.Body.AppendChild(TopNavBar.Element());
			
		}
		
		void ShowUserMenu(LoginResponse lr)
		{
			
			var um= Div.CreateContainerFluid(default(Element), fluid=>{
				Div.CreateRowFluid(fluid,  row=>{
					new Div(row,  span=>{
						span.ClassName="span2";
						new Div(span, nav=>{
							nav.ClassName="well sidebar-nav";
							HtmlList.CreatNavList(nav, list=>{
								ListItem.CreateNavHeader(list, "Menu");
								foreach(var role in lr.Roles){
									ListItem.CreateNavListItem(list,"#",role.Title, (li,anchor)=>{
										anchor.JSelect().Click(e=>{
											e.PreventDefault();
											Work.Empty();
											jQuery.GetScript(role.Directory+".js", (o)=>{
												ExecuteModule(Work.Element());
											});											
										});
									});
								}
								
								ListItem.CreateNavListItem(list,"#", "Close Session", (li,anchor)=>{
									anchor.JSelect().Click(e=>{
										e.PreventDefault();
										Document.Body.Empty();
										jQuery.Post("api/Logout", new {}, cb=>{
											Cayita.Javascript.Firebug.Console.Log("callback", cb);
										},"json")
											.Success(d=>{
												
											})
												.Error((request,  textStatus,  error)=>{
													Cayita.Javascript.Firebug.Console.Log("request", request );
													//Div.CreateAlertErrorBefore(Document.Body,
													//                           textStatus+": "+ request.StatusText);
												})
												.Always(a=>{
													ShowTopNavBar();
													ShowLoginForm();
												});
									});
								});
							});
						});
					});

					Work= new Div(row,  work=>{
						work.ClassName="span10";
						work.ID="work";
						var m = Document.CreateElement("h3");
						m.InnerText="Welcome";
						work.AppendChild(m);
					});
				});
			});
			um.AppendTo(Document.Body);
		}
		[InlineCode("MainModule.execute({parent})")]
		void ExecuteModule(Element parent){}
		
		void ShowLoginForm()
		{
			var form = new LoginForm(Document.Body, 
			                         new FormConfig{
				Action="json/loginResponse.json",
				Method="get"
			});
			
			form.OnLogin=OnLogin;
			form.Show();
			
		}
		
		
	}
	
	[IgnoreNamespace]
	public class LoginForm{
		
		public LoginForm(Element parent, FormConfig config )
		{
			Parent= parent;
			Config= config;
		}
		
		public string UserName {get; private set;}
		
		public Element Parent {get;private set;}
		
		public FormConfig Config {get;private set;}
		
		public Action<LoginResponse,LoginForm> OnLogin {get;set;}
		
		Div Container {get;set;}
		
		public void Close()
		{
			Container.JSelect().Remove();
		}
		
		public void Show()
		{
			Container = Div.CreateContainer(default(Element), container=>{
				Div.CreateRow(container, row=>{
					//
					new Div(row,element=>{
						
						element.ClassName="span4 offset4 well";
						new Legend(element, new LegendConfig{Text="Login Form"});
						
						new Form(element, fe=>{
							fe.Action= Config.Action;
							fe.Method = Config.Method;
							
							var cg = Div.CreateControlGroup(fe);
							
							var user= new InputText(cg.Element(), pe=>{
								pe.ClassName="span4";
								pe.SetPlaceHolder("your user name (type anything)");
								pe.Name="UserName";
							});
							
							cg = Div.CreateControlGroup(fe);
							var pass =new InputPassword(cg.Element(), pe=>{
								pe.ClassName="span4";
								pe.SetPlaceHolder("your Password (type anything)");
								pe.Name="Password";
							});
							
							var bt = new SubmitButton(fe, b=>{
								b.JSelect().Text("Login");
								b.ClassName="btn btn-info btn-block";
								b.LoadingText("  authenticating ...");
							});
							
							var vo = new ValidateOptions()
								.SetSubmitHandler( f=>{
									
									bt.ShowLoadingText();
									
									jQuery.GetData<LoginResponse>(f.Action, f.Serialize(), cb=>{
										Cayita.Javascript.Firebug.Console.Log("callback", cb);
									},"json")
										.Success(d=>{
											UserName= user.Element().Value;
											if(OnLogin!=null) OnLogin(d,this);
											
										})
											.Error((request,  textStatus,  error)=>{
												Div.CreateAlertErrorBefore(fe.Elements[0],textStatus+": "
												                           +( request.StatusText.StartsWith("ValidationException")?
												  "Usario/clave no validos":
												  request.StatusText));
											})
											.Always(a=>{
												bt.ResetLoadingText();
											})										;
									
									
								})
									.AddRule((rule, msg)=>{
										rule.Element=pass.Element();
										rule.Rule.Minlength(2).Required();
										msg.Minlength("mini 2 chars").Required("your password !");
									})
									
									.AddRule( (rule, msg)=> {
										rule.Element= user.Element();
										rule.Rule.Required().Minlength(2);
										msg.Minlength("min 2 chars");
									});
							
							fe.Validate(vo);			
							
						});
						
					});
					
				});
			});	
			Parent.AppendChild(Container.Element());
		}		
	}
			
}

