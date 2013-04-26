using jQueryApi;
using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Cayita.UI;

namespace Cayita.Javascritp.App
{

	[IgnoreNamespace]
	public class MenuItem
	{
		public string Class {get;set;}
		public string Title {get;set;}
		public string File {get;set;}
	}

	[IgnoreNamespace]
	public class App
	{
		TopNavBar TopNavBar {get;set;}
		Div Work {get;set;}
		List<MenuItem> MenuItems {get;set;}

		List<string>  modules = new List<string>();

		public static void Main ()
		{

			jQuery.OnDocumentReady (() => {

				var app = new App ();
				app.GetMenuItems ();
				app.ShowTopNavBar ();
				app.ShowMenu ();
				app.GoHome();
			});

		}

		void GetMenuItems ()
		{
			MenuItems= new List<MenuItem>();
			MenuItems.Add(new MenuItem{Title="Forms", File="modules/DemoForm.js", Class="DemoForm"});
			MenuItems.Add(new MenuItem{Title="Tables", File="modules/DemoTables.js", Class="DemoTables"});
			MenuItems.Add(new MenuItem{Title="Navbar", File="modules/DemoNavbar.js", Class="DemoNavbar"});
			MenuItems.Add(new MenuItem{Title="Navlist", File="modules/DemoNavlist.js", Class="DemoNavlist"});
			MenuItems.Add(new MenuItem{Title="Modals", File="modules/DemoModals.js", Class="DemoModals"});
			MenuItems.Add(new MenuItem{Title="Panels", File="modules/DemoPanels.js", Class="DemoPanels"});
			MenuItems.Add(new MenuItem{Title="SearchBox", File="modules/DemoSearchBox.js", Class="DemoSearchBox"});

		}
		
		void ShowTopNavBar()
		{
			TopNavBar= new TopNavBar(null,"Cayita.Javascript - demo","","",nav=>{

				nav.AddItem((l,a)=>{
					a.Text("Home");
					a.OnClick(GoHomeClick);
				});
				nav.AddItem((l,a)=>{
					a.Text("Licence");
					a.OnClick(GoLicence);
				});
				nav.AddItem((l,a)=>{
					a.Text("Contact");
					a.OnClick(GoContact);
				});
				nav.AddItem((l,a)=>{
					a.Text("About");
					a.OnClick(GoAbout);
				});

			});

			TopNavBar.AddClass("navbar-inverse navbar-fixed-top").AppendTo (Document.Body);
		}

		void ShowMenu()
		{	
			Div.CreateContainerFluid(default(Element), fluid=>{
				Div.CreateRowFluid(fluid,  row=>{
					new Div(row,  span=>{
						span.ClassName="span2";
						new SideNavBar(span, list=>{

							list.AddHeader( "Main Menu");
							list.AddHDivider();
							foreach(var item in MenuItems){
								list.AddItem( (li,anchor)=>{
									anchor.Text(item.Title);
									anchor.OnClick(e=>{
										e.PreventDefault();
										Work.Empty();
										if(modules.Contains(item.Class))
										{
											ExecuteModule(Work.Element(), item.Class);
										}
										else
										{
											jQuery.GetScript(item.File, (o)=>{
												modules.Add(item.Class);
												ExecuteModule(Work.Element(), item.Class);
											});											
										}
									});
								});
							}
						});
					});
					
					Work= new Div(row,  work=>{
						work.ClassName="span10";
						work.ID="work";
						work.AppendChild("Welcome".Header(3));
					});
				});
			}).AppendTo(Document.Body);

		}

		[InlineCode("window[{className}]['execute']({parent})")]
		void ExecuteModule(Element parent, string className){}


		void GoHomeClick(jQueryEvent evt)
		{
			evt.PreventDefault ();
			GoHome ();
		}
		void GoHome()
		{
			Work.Empty ();
			Work.Append (@"<p>Cayita is a library for building Webapps using C#  as base language and the Saltarelle compiler ( <a href=""http://www.saltarelle-compiler.com"" target=""_blank"">http://www.saltarelle-compiler.com</a>)
</p>

<p>Saltarelle compiler allows you to write apps  that run in any modern web browser, using your favourite programming tools:  C# and Visual Studio or Monodevelop.</p>

<p>Saltarelle compiler gives you  all the advantages of C#:  static type checking, IntelliSense (that really works) and lambda expressions when writing code for the browser. </p>

<p>Cayita extends the Saltarelle.Web.dll  library adding some new usefull methods and classes, that streamline  coding your app  using only the C # language.</p>
<h3> Form example (includes validation!)</h3>
<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">new</span><span>&nbsp;Form(&nbsp;container,&nbsp;f=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.AddClass(<span class=""string"">""well&nbsp;span8""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRowFluid(f,&nbsp;row=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class=""string"">""span5""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""FirstName""</span><span>);&nbsp;i.Name=</span><span class=""string"">""FirstName""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""LastName""</span><span>);&nbsp;i.Name=</span><span class=""string"">""LastName""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Email&nbsp;address""</span><span>);&nbsp;i.Name=</span><span class=""string"">""Email""</span><span>;&nbsp;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SelectField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Subject""</span><span>);&nbsp;i.Name=</span><span class=""string"">""Subject""</span><span>;i.ClassName=</span><span class=""string"">""span12""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Choose&nbsp;One:""</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""1""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""General&nbsp;Customer&nbsp;Service""</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""2""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Suggestions""</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""3""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Product&nbsp;Support""</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class=""string"">""4""</span><span>;&nbsp;opt.Text(</span><span class=""string"">""Bug""</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class=""string"">""span7""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextAreaField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Message""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=<span class=""string"">""input-xlarge&nbsp;span12""</span><span>;&nbsp;i.Rows=11;&nbsp;i.Name=</span><span class=""string"">""Message""</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SubmitButton(row,&nbsp;bt=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.AddClass(<span class=""string"">""btn-primary&nbsp;pull-right""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class=""string"">""Send""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Validate(<span class=""keyword"">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(vf=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessBefore(vf.FirstChild,<span class=""string"">""message&nbsp;sent""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vf.Clear();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;SelectElement&gt;(<span class=""string"">""Subject""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class=""string"">""choose&nbsp;an&nbsp;option""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Email();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Email(<span class=""string"">""write&nbsp;a&nbsp;valid&nbsp;email&nbsp;""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class=""string"">""FirstName""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class=""string"">""write&nbsp;your&nbsp;name""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Minlength(4);&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Minlength(<span class=""string"">""min&nbsp;4&nbsp;chars""</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>});&nbsp;&nbsp;&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">new Form( container, f=&gt;{  
    f.AddClass(""well span8"");  
    Div.CreateRowFluid(f, row=&gt;{  
        new Div(row, sp=&gt;{  
            sp.ClassName=""span5"";  
            new TextField(sp, (l,i)=&gt;{  
                l.Text(""FirstName""); i.Name=""FirstName""; i.ClassName=""span12"";   
            });  
            new TextField(sp, (l,i)=&gt;{  
                l.Text(""LastName""); i.Name=""LastName""; i.ClassName=""span12"";   
            });  
              
            new TextField(sp, (l,i)=&gt;{  
                l.Text(""Email address""); i.Name=""Email""; i.ClassName=""span12"";   
            });  
              
            new SelectField(sp, (l, i)=&gt;{  
                l.Text(""Subject""); i.Name=""Subject"";i.ClassName=""span12"";  
                new HtmlOption(i, opt=&gt;{opt.Value=""""; opt.Text(""Choose One:"");});  
                new HtmlOption(i, opt=&gt;{opt.Value=""1""; opt.Text(""General Customer Service"");});  
                new HtmlOption(i, opt=&gt;{opt.Value=""2""; opt.Text(""Suggestions"");});  
                new HtmlOption(i, opt=&gt;{opt.Value=""3""; opt.Text(""Product Support"");});  
                new HtmlOption(i, opt=&gt;{opt.Value=""4""; opt.Text(""Bug"");});  
            });  
        });  
          
        new Div(row, sp=&gt;{  
            sp.ClassName=""span7"";  
            new TextAreaField(sp, (l, i)=&gt;{  
                l.Text(""Message"");   
                i.ClassName=""input-xlarge span12""; i.Rows=11; i.Name=""Message"";  
            });  
              
        });  
        new SubmitButton(row, bt=&gt;{  
            bt.AddClass(""btn-primary pull-right"");  
            bt.Text(""Send"");  
        });  
          
        f.Validate(new ValidateOptions().SetSubmitHandler(vf=&gt;{  
            Div.CreateAlertSuccessBefore(vf.FirstChild,""message sent"");  
            vf.Clear();  
        }).AddRule((rf,ms)=&gt;{  
            rf.Element= f.FindByName&lt;SelectElement&gt;(""Subject"");  
            rf.Rule.Required();  
            ms.Required(""choose an option"");  
        }).AddRule((rf,ms)=&gt;{  
            rf.Element= f.FindByName&lt;TextElement&gt;(""Email"");  
            rf.Rule.Email();  
            ms.Email(""write a valid email "");  
        }).AddRule((rf,ms)=&gt;{  
            rf.Element= f.FindByName&lt;TextElement&gt;(""FirstName"");  
            rf.Rule.Required();  
            ms.Required(""write your name"");  
            rf.Rule.Minlength(4);  
            ms.Minlength(""min 4 chars"");  
        }));  
    });  
});  </textarea></div>
<img src=""img/form.demo-1.png""/>
<h3>Requirements:</h3>
<h4>Development</h4>
<ul>
<li>Saltarelle compiler</li>
<li>Saltarelle.jQuery.dll</li>
<li>Saltarelle.jQuery.UI.dll</li> 
<li>Saltarelle.Web.dll</li>
<li>Saltarelle.Linq.dll</li>
<li>Cayita.Javascript.dll</li>
<li>mscorlib.dll</li>
</ul>
<h4>Production</h4>
<ul>
<li>Cayita.js & Cayita.css</li>
<li>Saltarelle mscorlib.js & linq.js <a href=""http://www.saltarelle-compiler.com/"" target=""_blank"">
http://www.saltarelle-compiler.com/</a></li>
<li>jquery-1.9.1.js <a href=""http://jquery.com/"" target=""_blank"">
http://jquery.com/</a></li>
<li>Draggable, Resizable and Calendar plugins from jQuery UI 1.10.2 <a href=""http://jqueryui.com/"" target=""_blank"">
http://jqueryui.com/</a></li>
<li>autonumeric-1.8.7.js <a href=""http://www.decorplanit.com/plugin"" target=""_blank"" >
http://www.decorplanit.com/plugin</a></li>
<li>jQuery Validation Plugin - v1.11.0 - 2/4/2013 <a href=""https://github.com/jzaefferer/jquery-validation"" target=""_blank"">
https://github.com/jzaefferer/jquery-validation</a></li>
<li>Twitter Boostrap - Jasny version <a href=""http://jasny.github.com/bootstrap"" target=""_blank"">
http://jasny.github.com/bootstrap</a></li>
<li>Font Awesome <a href=""http://fortawesome.github.com/Font-Awesome"" target=""_blank"">
http://fortawesome.github.com/Font-Awesome</a></li>
<li>alertify <a href=""http://fabien-d.github.io/alertify.js"" target=""_blank"">
http://fabien-d.github.io/alertify.js</a></li>
<li>bootbox <a href=""http://bootboxjs.com"" target=""_blank"">
http://bootboxjs.com</a></li>
</ul>
<h3>Demo</h3>
this site is entirely written in CSharp

<h3>Source code</h3>
full source code is avalaible at github <a href=""https://github.com/aicl/Cayita.Javascript"" target=""_blank"">
https://github.com/aicl/Cayita.Javascript</a>

<h3>Instructions</h3>
<ul>
<li>Install saltarelle compiler <a href=""http://www.saltarelle-compiler.com/getting-started"" target=""_blank"">
http://www.saltarelle-compiler.com/getting-started</a></li>
<li>Add a reference to Cayita.Javascript.dll</li>
<li>enjoy !</li>
</ul>
");

		}
		
		void GoLicence(jQueryEvent evt)
		{
			"Licence".LogInfo ();
		}
		
		void GoContact(jQueryEvent evt)
		{
			"Contact".LogInfo ();
		}
		
		void GoAbout(jQueryEvent evt)
		{
			"About".LogInfo ();
		}

	}
}

