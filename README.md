Cayita is a CSharp library for the Saltarelle compiler (http://www.saltarelle-compiler.com), based on jQuery and Twitter's bootstrap, for writing responsive webapps that run in any modern web browser, using your favourite programming tools: C# and Visual Studio/Monodevelop.)

Saltarelle compiler allows you to write apps  that run in any modern web browser, using your favourite programming tools:  C# and Visual Studio or Monodevelop.

Saltarelle compiler gives you  all the advantages of C#: OP, static type checking, IntelliSense (that really works) and lambda expressions when writing code for the browser. 

Cayita extends the Saltarelle.Web.dll  library adding some new usefull methods and classes, that streamline  coding your app  using only the C # language.

Form  example (includes validation!)
=========================== 

```csharp
new Form( container, f=>{  
    f.AddClass("well span8");  
    Div.CreateRowFluid(f, row=>{  
        new Div(row, sp=>{  
            sp.ClassName="span5";  
            new TextField(sp, (l,i)=>{  
                l.Text("FirstName"); i.Name="FirstName"; i.ClassName="span12";   
            });  
            new TextField(sp, (l,i)=>{  
                l.Text("LastName"); i.Name="LastName"; i.ClassName="span12";   
            });  
              
            new TextField(sp, (l,i)=>{  
                l.Text("Email address"); i.Name="Email"; i.ClassName="span12";   
            });  
              
            new SelectField(sp, (l, i)=>{  
                l.Text("Subject"); i.Name="Subject";i.ClassName="span12";  
                new HtmlOption(i, opt=>{opt.Value=""; opt.Text("Choose One:");});  
                new HtmlOption(i, opt=>{opt.Value="1"; opt.Text("General Customer Service");});  
                new HtmlOption(i, opt=>{opt.Value="2"; opt.Text("Suggestions");});  
                new HtmlOption(i, opt=>{opt.Value="3"; opt.Text("Product Support");});  
                new HtmlOption(i, opt=>{opt.Value="4"; opt.Text("Bug");});  
            });  
        });  
          
        new Div(row, sp=>{  
            sp.ClassName="span7";  
            new TextAreaField(sp, (l, i)=>{  
                l.Text("Message");   
                i.ClassName="input-xlarge span12"; i.Rows=11; i.Name="Message";  
            });  
              
        });  
        new SubmitButton(row, bt=>{  
            bt.AddClass("btn-primary pull-right");  
            bt.Text("Send");  
        });  
          
        f.Validate(new ValidateOptions().SetSubmitHandler(vf=>{  
            Div.CreateAlertSuccessBefore(vf.FirstChild,"message sent");  
            vf.Clear();  
        }).AddRule((rf,ms)=>{  
            rf.Element= f.FindByName<SelectElement>("Subject");  
            rf.Rule.Required();  
            ms.Required("choose an option");  
        }).AddRule((rf,ms)=>{  
            rf.Element= f.FindByName<TextElement>("Email");  
            rf.Rule.Email();  
            ms.Email("write a valid email ");  
        }).AddRule((rf,ms)=>{  
            rf.Element= f.FindByName<TextElement>("FirstName");  
            rf.Rule.Required();  
            ms.Required("write your name");  
            rf.Rule.Minlength(4);  
            ms.Minlength("min 4 chars");  
        }));  
    });  
});  
```
![demo img](https://raw.github.com/aicl/aicl.github.com/master/img/form.demo-1.png)

##Requirements:
* **Development**
* Saltarelle compiler.
* Saltarelle.jQuery.dll
* Saltarelle.jQuery.UI.dll  
* Saltarelle.Web.dll
* Saltarelle.Linq.dll
* Cayita.Javascript.dll
* Saltarelle mscorlib.dll
* **Production**
* Cayita.js
* Saltarelle mscorlib.js  & linq.js (http://www.saltarelle-compiler.com)
* jquery-1.9.1.js (http://jquery.com)
* Draggable, Resizable and Calendar plugins from jQuery UI 1.10.2 (http://jqueryui.com)
* autonumeric-1.8.7.js (http://www.decorplanit.com/plugin/)
* jQuery Validation Plugin - v1.11.0 - 2/4/2013  (https://github.com/jzaefferer/jquery-validation)
* Twitter Boostrap (Jasny version http://jasny.github.com/bootstrap/)
* Font Awesome (http://fortawesome.github.com/Font-Awesome/)
* alertify (http://fabien-d.github.io/alertify.js/)
* bootbox (http://bootboxjs.com/)

##Demo
Demo at (https://googledrive.com/host/0B5PxAJVNHVdKaGFMczUxX2RRSkk/index.html)

##Instructions
* Install saltarelle compiler (http://www.saltarelle-compiler.com/getting-started)
* Add a reference to Cayita.Javascript.dll
* enjoy !
