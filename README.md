Cayita is a library for building javascript apps using C#  as base language and the [Saltarelle] compiler ( http://www.saltarelle-compiler.com)

Saltarelle compiler allows you to write apps  that run in any modern web browser, using your favourite programming tools:  C# and Visual Studio or Monodevelop.

Saltarelle compiler gives you  all the advantages of C#:  static type checking, IntelliSense (that really works) and lambda expressions when writing code for the browser. 

Cayita extends the Saltarelle.Web.dll  library adding some new usefull methods and classes, that streamline  coding your app  using only the C # language.

Form  example (includes validation!)
=========================== 

```csharp

new Form( container, f=>{  
    f.AddClass("well span8");  
    Div.CreateRowFluid(f, row=>{  
        new Div(row, sp=>{  
            sp.ClassName="span5";  
            new Label(sp, l=>l.Text("FirstName"));  
            new InputText(sp, i=>{i.ClassName="span12"; i.SetRequired();});  
            new Label(sp, l=>l.Text("LastName"));  
            new InputText(sp, i=>i.ClassName="span12");  
            new Label(sp, l=>l.Text("Email address"));  
            new InputText(sp, i=>{ i.ClassName="span12"; i.Name="Email"; });  
            new Label(sp, l=>l.Text("Subject"));  
            new HtmlSelect(sp, sl=>{  
                sl.Name="Subject";sl.ClassName="span12";  
                new HtmlOption(sl, opt=>{opt.Value=""; opt.Text("Choose One:");});  
                new HtmlOption(sl, opt=>{opt.Value="1"; opt.Text("General Customer Service");});  
                new HtmlOption(sl, opt=>{opt.Value="2"; opt.Text("Suggestions");});  
                new HtmlOption(sl, opt=>{opt.Value="3"; opt.Text("Product Support");});  
                new HtmlOption(sl, opt=>{opt.Value="4"; opt.Text("Bug");});  
            });  
        });  
          
        new Div(row, sp=>{  
            sp.ClassName="span7";  
            new Label(sp, l=>l.Text("Message"));  
            new TextArea(sp, ta=>{  
                ta.ClassName="input-xlarge span12";  
                ta.Rows=11;  
            });  
              
        });  
        new SubmitButton(row, bt=>{  
            bt.AddClass("btn-primary pull-right");  
            bt.Text("Send");  
        });  
          
        f.Validate(new ValidateOptions().SetSubmitHandler(vf=>{  
            Div.CreateAlertSuccessBefore(vf.FirstChild,"message sent");  
            vf.Reset();  
        }).AddRule((rf,ms)=>{  
            rf.Element= f.FindByName<SelectElement>("Subject");  
            rf.Rule.Required();  
            ms.Required("choose an option");  
        }).AddRule((rf,ms)=>{  
            rf.Element= f.FindByName<SelectElement>("Email");  
            rf.Rule.Email();  
            ms.Email("write a valid  email ");  
        }));  
    });  
});  
```
![imagen](https://docs.google.com/file/d/0B5PxAJVNHVdKRnpQS2dxVXg1eTA/edit?usp=sharing&pli=1)

Requirements:
Development
Saltarelle compiler.
Saltarelle.jQuery.dll 
Saltarelle.Web.dll
Saltarelle.Linq.dll
Cayita.Javascript.dll
mscorlib.dll

Production
Cayita.Javascript.UI.js
mscorlib.js ( from saltarelle)
linq.js ( from saltarelle)
jquery-1.9.1.js
autonumeric-1.8.7.js (http://www.decorplanit.com/plugin/)
jQuery Validation Plugin - v1.11.0 - 2/4/2013  (https://github.com/jzaefferer/jquery-validation)
Calendar plugin from jQuery UI 1.10.1
Jasny version of Twitter Boostrap (http://jasny.github.com/bootstrap/)
Font Awesome (http://fortawesome.github.com/Font-Awesome/)


Demo at (https://googledrive.com/host/0B5PxAJVNHVdKaGFMczUxX2RRSkk/index.html)

