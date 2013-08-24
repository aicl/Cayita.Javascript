Cayita is a CSharp library for the Saltarelle compiler (http://www.saltarelle-compiler.com), based on jQuery and Twitter's bootstrap, for writing responsive webapps that run in any modern web browser, using your favourite programming tools: C# and Visual Studio/Monodevelop.)

Saltarelle compiler allows you to write apps  that run in any modern web browser, using your favourite programming tools:  C# and Visual Studio or Monodevelop.

Saltarelle compiler gives you  all the advantages of C#: OP, static type checking, IntelliSense (that really works) and lambda expressions when writing code for the browser. 

Cayita extends the Saltarelle.Web.dll  library adding some new usefull methods and classes, that streamline  coding your app  using only the C # language.

Form  sample
=========================== 

```csharp
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
