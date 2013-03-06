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
			var a = TopNavBar.GetPullRightAnchor().InnerText=lf.UserName;
			TopNavBar.GetPullRightParagraph().InnerText="";
			TopNavBar.GetPullRightParagraph().Append(a);
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
							HtmlList.CreateNavList(nav, list=>{
								list.AddHeader("Menu");
								foreach(var role in lr.Roles){
									 list.AddItem("#",role.Title, (li,anchor)=>{
										anchor.JQuery().Click(e=>{
											e.PreventDefault();
											Work.Empty();
											jQuery.GetScript(role.Directory+".js", (o)=>{
												ExecuteModule(Work.Element());
											});											
										});
									});
								}
								
								list.AddItem("#", "Close Session", (li,anchor)=>{
									anchor.JQuery().Click(e=>{
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
			var form = new LoginForm(Document.Body);
			form.OnLogin=OnLogin;
			form.Show();
		}
		
		
	}
	
	[IgnoreNamespace]
	public class LoginForm{
		
		public LoginForm(Element parent )
		{
			Parent= parent;
		}
		
		public string UserName {get; private set;}
		
		public Element Parent {get;private set;}
				
		public Action<LoginResponse,LoginForm> OnLogin {get;set;}
		
		Div Container {get;set;}
		
		public void Close()
		{
			Container.JQuery().Remove();
		}
		
		public void Show()
		{
			Container = Div.CreateContainer(default(Element), container=>{
				Div.CreateRow(container, row=>{
					//
					new Div(row,element=>{
						
						element.ClassName="span4 offset4 well";
						new Legend(element,  l=>{
							l.InnerText="Login Form";
						});
						
						new Form(element, fe=>{
							fe.Action= "json/loginResponse.json";
							fe.Method = "get";
							
							var cg = Div.CreateControlGroup(fe);
							
							var user= new InputText(cg.Element(), pe=>{
								//pe.SetAttribute("data-provide","typeahead");
								pe.ClassName="span4";
								pe.SetPlaceHolder("your username");
								pe.Name="UserName";
							});
							
							cg = Div.CreateControlGroup(fe);
							var pass =new InputPassword(cg.Element(), pe=>{
								pe.ClassName="span4";
								pe.SetPlaceHolder("your password");
								pe.Name="Password";
							});
							
							var bt = new SubmitButton(fe, b=>{
								b.JQuery().Text("Login");
								b.AddClass("btn-info btn-block");
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

/*
var updater = function(item, type){console.log(arguments); return type=="value"?1:item;};
var data=[];
var input= $("#cyt-input-1");
var th = input.typeahead({source:function(query,callback){console.log(arguments); data.push(query); return data; }, updater: updater});

var highlighter = function(item) {console.log("highlighter", item); return '<strong>' + 'item' + '</strong>'};
var matcher= function(item){ console.log("matcher",item); return true;};
var sorter= function(items){ console.log("sorter",items); return items};
var updater = function(item, type){console.log("updater", arguments); return type=="value"?1:item;};
var source = "json/conceptoResponse.json";
var process= function(items){console.log("process", items); return ["angel", "angelica", "angela", "angie", "claudia", "clara"]}
// process no hace nada !!!
var input= $("#cyt-input-1");
var th = input.typeahead({source:source, process:process, updater: updater, matcher:matcher, sorter:sorter, highlighter:highlighter });

var highlighter = function(item) {console.log("highlighter", item); return '<strong>' + item + '</strong>'};
var matcher= function(item){ console.log("matcher",item); return true;};
var sorter= function(items){ console.log("sorter",items); return items};
var updater = function(item, type){console.log("updater", arguments); return type=="value"?1:item;};
var source = "json/conceptoResponse.json";
//var process= function(items){console.log("process", items); return ["angel", "angelica", "angela", "angie", "claudia", "clara"]}
var input= $("#cyt-input-1"); var data=[];
var th = input.typeahead({source:function(query,process){ data.push(query); process(data); }, updater: updater, matcher:matcher, sorter:sorter  });

var input= $("#cyt-input-1"); 
var data = [{Id:1, Name:"angel"},{Id:2, Name:"angelica"}, {Id:3 , Name:"angela"}];
var matcher= function(item){ console.log("matcher",item); return true;};
var sorter= function(items){ console.log("sorter",items); return items};
var updater = function(item, type){console.log("updater", arguments);  return type=="value"?1:item;};
var highlighter = function(item) {console.log("highlighter", item); return '<strong>' + item.Name + '</strong>'};
var th = input.typeahead({source:function(query,process){ process(data);}, updater: updater, matcher:matcher, sorter:sorter, highlighter:highlighter});

var input= $("#cyt-input-1");  var id;
var data = {"Result":[{"Id":1, "Nombre":"Arriendo" }, {"Id":2, "Nombre":"Celular"}]}
var matcher= function(item){ console.log("matcher",item); return true ;};
var sorter= function(items){ console.log("sorter",items); return items.Result};
var updater = function(item, type){console.log("updater", arguments);  return type=="value"?id:item;};
var highlighter = function(item) {console.log("highlighter", item, item.Id); id=item.Id; return '<strong>' + item.Nombre + '</strong>'};
var th = input.typeahead({source:function(query,process){ process(data);}, updater: updater, matcher:matcher, sorter:sorter, highlighter:highlighter});

*/