(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascritp.App.App
	var $App = function() {
		this.$1$TopNavBarField = null;
		this.$1$WorkField = null;
		this.$1$MenuItemsField = null;
		this.$modules = [];
	};
	$App.prototype = {
		get_$topNavBar: function() {
			return this.$1$TopNavBarField;
		},
		set_$topNavBar: function(value) {
			this.$1$TopNavBarField = value;
		},
		get_$work: function() {
			return this.$1$WorkField;
		},
		set_$work: function(value) {
			this.$1$WorkField = value;
		},
		get_$menuItems: function() {
			return this.$1$MenuItemsField;
		},
		set_$menuItems: function(value) {
			this.$1$MenuItemsField = value;
		},
		$getMenuItems: function() {
			this.set_$menuItems([]);
			var $t2 = this.get_$menuItems();
			var $t1 = new $MenuItem();
			$t1.set_title('Forms');
			$t1.set_file('modules/DemoForm.js');
			$t1.set_class('DemoForm');
			ss.add($t2, $t1);
			var $t4 = this.get_$menuItems();
			var $t3 = new $MenuItem();
			$t3.set_title('Tables');
			$t3.set_file('modules/DemoTables.js');
			$t3.set_class('DemoTables');
			ss.add($t4, $t3);
			var $t6 = this.get_$menuItems();
			var $t5 = new $MenuItem();
			$t5.set_title('Navbar');
			$t5.set_file('modules/DemoNavbar.js');
			$t5.set_class('DemoNavbar');
			ss.add($t6, $t5);
			var $t8 = this.get_$menuItems();
			var $t7 = new $MenuItem();
			$t7.set_title('Navlist');
			$t7.set_file('modules/DemoNavlist.js');
			$t7.set_class('DemoNavlist');
			ss.add($t8, $t7);
			var $t10 = this.get_$menuItems();
			var $t9 = new $MenuItem();
			$t9.set_title('Modals');
			$t9.set_file('modules/DemoModals.js');
			$t9.set_class('DemoModals');
			ss.add($t10, $t9);
			var $t12 = this.get_$menuItems();
			var $t11 = new $MenuItem();
			$t11.set_title('Panels');
			$t11.set_file('modules/DemoPanels.js');
			$t11.set_class('DemoPanels');
			ss.add($t12, $t11);
			var $t14 = this.get_$menuItems();
			var $t13 = new $MenuItem();
			$t13.set_title('SearchBox');
			$t13.set_file('modules/DemoSearchBox.js');
			$t13.set_class('DemoSearchBox');
			ss.add($t14, $t13);
			var $t16 = this.get_$menuItems();
			var $t15 = new $MenuItem();
			$t15.set_title('TabPanel');
			$t15.set_file('modules/DemoTabPanel.js');
			$t15.set_class('DemoTabPanel');
			ss.add($t16, $t15);
			var $t18 = this.get_$menuItems();
			var $t17 = new $MenuItem();
			$t17.set_title('File Upload');
			$t17.set_file('modules/DemoFileUpload.js');
			$t17.set_class('DemoFileUpload');
			ss.add($t18, $t17);
		},
		$showTopNavBar: function() {
			this.set_$topNavBar(new Cayita.UI.NavBar.$ctor1(null, 'Cayita - demo', '', '', ss.mkdel(this, function(nav) {
				Extensions.addItem$4(nav, 'Home', ss.mkdel(this, this.$goHomeClick));
				Extensions.addItem$4(nav, 'License', ss.mkdel(this, this.$goLicense));
				Extensions.addItem$4(nav, 'Contact', ss.mkdel(this, this.$goContact));
				Extensions.addItem$4(nav, 'About', ss.mkdel(this, this.$goAbout));
			})));
			this.get_$topNavBar().addClass$1('navbar-inverse navbar-fixed-top').appendTo$1(document.body);
		},
		$showMenu: function() {
			Cayita.UI.Div.createContainerFluid$1(null, ss.mkdel(this, function(fluid) {
				Cayita.UI.Div.createRowFluid$1(fluid, ss.mkdel(this, function(row) {
					new Cayita.UI.Div.$ctor2(row, ss.mkdel(this, function(span) {
						span.className = 'span2';
						new Cayita.UI.NavList(span, ss.mkdel(this, function(list) {
							Extensions.addHeader(list, 'Main Menu');
							Extensions.addHDivider(list);
							var $t1 = this.get_$menuItems();
							for (var $t2 = 0; $t2 < $t1.length; $t2++) {
								var item = { $: $t1[$t2] };
								Extensions.addItem$4(list, item.$.get_title(), ss.mkdel({ item: item, $this: this }, function(e) {
									e.preventDefault();
									this.$this.get_$work().empty();
									if (ss.contains(this.$this.$modules, this.item.$.get_class())) {
										var $t3 = this.$this;
										var $t4 = this.$this.get_$work().element$1();
										window[this.item.$.get_class()]['execute']($t4);
									}
									else {
										$.getScript(this.item.$.get_file(), ss.mkdel({ item: this.item, $this: this.$this }, function(o) {
											ss.add(this.$this.$modules, this.item.$.get_class());
											var $t5 = this.$this;
											var $t6 = this.$this.get_$work().element$1();
											window[this.item.$.get_class()]['execute']($t6);
										}));
									}
								}));
							}
						}));
					}));
					this.set_$work(new Cayita.UI.Div.$ctor2(row, function(work) {
						work.className = 'span10';
						work.id = 'work';
						work.appendChild(StringExtensions.header('Welcome', 3));
					}));
				}));
			})).appendTo$1(document.body);
		},
		$goHomeClick: function(evt) {
			evt.preventDefault();
			this.$goHome();
		},
		$goHome: function() {
			this.get_$work().empty();
			this.get_$work().append$3('<p>Cayita is a CSharp library for the \n<a href="http://www.saltarelle-compiler.com" target="_blank">Saltarelle compiler </a>,\n based on jQuery and Twitter\'s bootstrap, for writing responsive webapps  that run in any modern web browser,\n using your favourite programming tools: C# and Visual Studio/Monodevelop.)\n</p>\n\n<p>Saltarelle compiler gives you  all the advantages of C#:  static type checking, IntelliSense (that really works) and lambda expressions when writing code for the browser. </p>\n\n<p>Cayita extends the Saltarelle.Web.dll  library adding some new usefull methods and classes, that streamline  coding your app  using only the C # language.</p>\n<h3> Form example (includes validation!)</h3>\n<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-cpp"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(&nbsp;container,&nbsp;f=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.AddClass(<span class="string">"well&nbsp;span8"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRowFluid(f,&nbsp;row=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class="string">"span5"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"FirstName"</span><span>);&nbsp;i.Name=</span><span class="string">"FirstName"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"LastName"</span><span>);&nbsp;i.Name=</span><span class="string">"LastName"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Email&nbsp;address"</span><span>);&nbsp;i.Name=</span><span class="string">"Email"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SelectField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Subject"</span><span>);&nbsp;i.Name=</span><span class="string">"Subject"</span><span>;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">""</span><span>;&nbsp;opt.Text(</span><span class="string">"Choose&nbsp;One:"</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"1"</span><span>;&nbsp;opt.Text(</span><span class="string">"General&nbsp;Customer&nbsp;Service"</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"2"</span><span>;&nbsp;opt.Text(</span><span class="string">"Suggestions"</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"3"</span><span>;&nbsp;opt.Text(</span><span class="string">"Product&nbsp;Support"</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"4"</span><span>;&nbsp;opt.Text(</span><span class="string">"Bug"</span><span>);});&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class="string">"span7"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextAreaField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Message"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=<span class="string">"input-xlarge&nbsp;span12"</span><span>;&nbsp;i.Rows=11;&nbsp;i.Name=</span><span class="string">"Message"</span><span>;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(row,&nbsp;bt=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.AddClass(<span class="string">"btn-primary&nbsp;pull-right"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Send"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Validate(<span class="keyword">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(vf=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessBefore(vf.FirstChild,<span class="string">"message&nbsp;sent"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vf.Clear();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;SelectElement&gt;(<span class="string">"Subject"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class="string">"choose&nbsp;an&nbsp;option"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class="string">"Email"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Email();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Email(<span class="string">"write&nbsp;a&nbsp;valid&nbsp;email&nbsp;"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class="string">"FirstName"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class="string">"write&nbsp;your&nbsp;name"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Minlength(4);&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Minlength(<span class="string">"min&nbsp;4&nbsp;chars"</span><span>);&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form( container, f=&gt;{  \n    f.AddClass("well span8");  \n    Div.CreateRowFluid(f, row=&gt;{  \n        new Div(row, sp=&gt;{  \n            sp.ClassName="span5";  \n            new TextField(sp, (l,i)=&gt;{  \n                l.Text("FirstName"); i.Name="FirstName"; i.ClassName="span12";   \n            });  \n            new TextField(sp, (l,i)=&gt;{  \n                l.Text("LastName"); i.Name="LastName"; i.ClassName="span12";   \n            });  \n              \n            new TextField(sp, (l,i)=&gt;{  \n                l.Text("Email address"); i.Name="Email"; i.ClassName="span12";   \n            });  \n              \n            new SelectField(sp, (l, i)=&gt;{  \n                l.Text("Subject"); i.Name="Subject";i.ClassName="span12";  \n                new HtmlOption(i, opt=&gt;{opt.Value=""; opt.Text("Choose One:");});  \n                new HtmlOption(i, opt=&gt;{opt.Value="1"; opt.Text("General Customer Service");});  \n                new HtmlOption(i, opt=&gt;{opt.Value="2"; opt.Text("Suggestions");});  \n                new HtmlOption(i, opt=&gt;{opt.Value="3"; opt.Text("Product Support");});  \n                new HtmlOption(i, opt=&gt;{opt.Value="4"; opt.Text("Bug");});  \n            });  \n        });  \n          \n        new Div(row, sp=&gt;{  \n            sp.ClassName="span7";  \n            new TextAreaField(sp, (l, i)=&gt;{  \n                l.Text("Message");   \n                i.ClassName="input-xlarge span12"; i.Rows=11; i.Name="Message";  \n            });  \n              \n        });  \n        new SubmitButton(row, bt=&gt;{  \n            bt.AddClass("btn-primary pull-right");  \n            bt.Text("Send");  \n        });  \n          \n        f.Validate(new ValidateOptions().SetSubmitHandler(vf=&gt;{  \n            Div.CreateAlertSuccessBefore(vf.FirstChild,"message sent");  \n            vf.Clear();  \n        }).AddRule((rf,ms)=&gt;{  \n            rf.Element= f.FindByName&lt;SelectElement&gt;("Subject");  \n            rf.Rule.Required();  \n            ms.Required("choose an option");  \n        }).AddRule((rf,ms)=&gt;{  \n            rf.Element= f.FindByName&lt;TextElement&gt;("Email");  \n            rf.Rule.Email();  \n            ms.Email("write a valid email ");  \n        }).AddRule((rf,ms)=&gt;{  \n            rf.Element= f.FindByName&lt;TextElement&gt;("FirstName");  \n            rf.Rule.Required();  \n            ms.Required("write your name");  \n            rf.Rule.Minlength(4);  \n            ms.Minlength("min 4 chars");  \n        }));  \n    });  \n});  </textarea></div>\n<img src="img/form.demo-1.png"/>\n<h3>Requirements:</h3>\n<h4>Development</h4>\n<ul>\n<li>Saltarelle compiler</li>\n<li>Saltarelle.jQuery.dll</li>\n<li>Saltarelle.jQuery.UI.dll</li> \n<li>Saltarelle.Web.dll</li>\n<li>Saltarelle.Linq.dll</li>\n<li>Cayita.Javascript.dll</li>\n<li>mscorlib.dll</li>\n</ul>\n<h4>Production</h4>\n<ul>\n<li>Cayita.js & Cayita.css</li>\n<li>Saltarelle mscorlib.js & linq.js <a href="http://www.saltarelle-compiler.com/" target="_blank">\nhttp://www.saltarelle-compiler.com/</a></li>\n<li>jquery-1.9.1.js <a href="http://jquery.com/" target="_blank">\nhttp://jquery.com/</a></li>\n<li>Draggable, Resizable and Calendar plugins from jQuery UI 1.10.2 <a href="http://jqueryui.com/" target="_blank">\nhttp://jqueryui.com/</a></li>\n<li>autonumeric-1.8.7.js <a href="http://www.decorplanit.com/plugin" target="_blank" >\nhttp://www.decorplanit.com/plugin</a></li>\n<li>jQuery Validation Plugin - v1.11.0 - 2/4/2013 <a href="https://github.com/jzaefferer/jquery-validation" target="_blank">\nhttps://github.com/jzaefferer/jquery-validation</a></li>\n<li>Twitter Boostrap - Jasny version <a href="http://jasny.github.com/bootstrap" target="_blank">\nhttp://jasny.github.com/bootstrap</a></li>\n<li>Font Awesome <a href="http://fortawesome.github.com/Font-Awesome" target="_blank">\nhttp://fortawesome.github.com/Font-Awesome</a></li>\n<li>alertify <a href="http://fabien-d.github.io/alertify.js" target="_blank">\nhttp://fabien-d.github.io/alertify.js</a></li>\n<li>bootbox <a href="http://bootboxjs.com" target="_blank">\nhttp://bootboxjs.com</a></li>\n</ul>\n<h3>Demo</h3>\nthis site is entirely written in CSharp\n\n<h3>Source code</h3>\nfull source code is avalaible at github <a href="https://github.com/aicl/Cayita.Javascript" target="_blank">\nhttps://github.com/aicl/Cayita.Javascript</a>\n\n<h3>Instructions</h3>\n<ul>\n<li>Install saltarelle compiler <a href="http://www.saltarelle-compiler.com/getting-started" target="_blank">\nhttp://www.saltarelle-compiler.com/getting-started</a></li>\n<li>Add a reference to Cayita.Javascript.dll</li>\n<li>enjoy !</li>\n</ul>\n');
		},
		$goLicense: function(evt) {
			evt.preventDefault();
			this.get_$work().empty();
			this.get_$work().append$3('<div class="well">\n<p>Copyright AICL.</p>\n<p>Licensed under the Apache License, Version 2.0 (the "License"); you may not use this work except in compliance with the License. You may obtain a copy of the License in the LICENSE file, or at:</p><p><a target="_blank" href="http://www.apache.org/licenses/LICENSE-2.0">http://www.apache.org/licenses/LICENSE-2.0</a></p><p>Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.</p></div>');
		},
		$goContact: function(evt) {
			evt.preventDefault();
			this.get_$work().empty();
			this.get_$work().append$3('<div class="well">\n<p><a target="_blank" href="https://github.com/angelcolmenares">https://github.com/angelcolmenares</a>\n<p><a target="_blank" href="https://github.com/aicl">https://github.com/aicl</a>\n</p></div>');
		},
		$goAbout: function(evt) {
			evt.preventDefault();
			this.get_$work().empty();
			this.get_$work().append$3('<div class="well">\n<p>Cayita is a library for building Webapps using C#  as base language and the Saltarelle compiler \n<a href="http://www.saltarelle-compiler.com" target="_blank">\nhttp://www.saltarelle-compiler.com\n</a>\n</p>\n</p></div>');
		}
	};
	$App.main = function() {
		$(function() {
			var app = new $App();
			app.$getMenuItems();
			app.$showTopNavBar();
			app.$showMenu();
			app.$goHome();
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascritp.App.MenuItem
	var $MenuItem = function() {
		this.$1$ClassField = null;
		this.$1$TitleField = null;
		this.$1$FileField = null;
	};
	$MenuItem.prototype = {
		get_class: function() {
			return this.$1$ClassField;
		},
		set_class: function(value) {
			this.$1$ClassField = value;
		},
		get_title: function() {
			return this.$1$TitleField;
		},
		set_title: function(value) {
			this.$1$TitleField = value;
		},
		get_file: function() {
			return this.$1$FileField;
		},
		set_file: function(value) {
			this.$1$FileField = value;
		}
	};
	ss.registerClass(global, 'App', $App);
	ss.registerClass(global, 'MenuItem', $MenuItem);
})();
