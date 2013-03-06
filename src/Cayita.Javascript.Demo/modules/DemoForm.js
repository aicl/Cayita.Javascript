(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoForm.DemoForm
	var $DemoForm = function() {
	};
	$DemoForm.execute = function(parent) {
		$(document.createElement('h2')).text('Default styles').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div) {
			div.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div, function(f) {
				new Cayita.UI.FieldSet.$ctor1(f, function(fs) {
					new Cayita.UI.Legend.$ctor1(fs, function(lg) {
						$(lg).text('Legend');
					});
					new Cayita.UI.Label.$ctor1(fs, function(lb) {
						$(lb).text('Label Name');
					});
					new Cayita.UI.InputText.$ctor2(fs, function(input) {
						$(input).attr('placeholder', 'Type something');
					});
					new Cayita.UI.Span.$ctor1(fs, function(sp) {
						sp.className = 'help-block';
						$(sp).text('Example block-level help text here');
					});
					new Cayita.UI.CheckboxField.$ctor1(fs, function(lb1, cb) {
						$(lb1).text('check me out');
					});
					new Cayita.UI.SubmitButton.$ctor1(fs, function(bt) {
						$(bt).text('Submit');
						$(bt).on('click', function(ev) {
							ev.preventDefault();
						});
					});
				});
			});
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;FieldSet(f,&nbsp;fs=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Legend(fs,&nbsp;lg=&gt;&nbsp;lg.Text(</span><span class="string">"Legend"</span><span>)&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(fs,&nbsp;lb=&gt;&nbsp;lb.Text(</span><span class="string">"Label&nbsp;Name"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(fs,&nbsp;input=&gt;&nbsp;input.SetPlaceHolder(</span><span class="string">"Type&nbsp;something"</span><span>));&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Span(fs,&nbsp;sp&nbsp;=&gt;{&nbsp;sp.ClassName=</span><span class="string">"help-block"</span><span>;&nbsp;sp.Text(</span><span class="string">"Example&nbsp;block-level&nbsp;help&nbsp;text&nbsp;here"</span><span>)&nbsp;;});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(fs,&nbsp;(lb,cb)=&gt;{lb.Text(</span><span class="string">"check&nbsp;me&nbsp;out"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(fs,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Submit"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n  new FieldSet(f, fs=&gt;{\n    new Legend(fs, lg=&gt; lg.Text("Legend") );\n    new Label(fs, lb=&gt; lb.Text("Label Name"));\n    new InputText(fs, input=&gt; input.SetPlaceHolder("Type something"));\n    new Span(fs, sp =&gt;{ sp.ClassName="help-block"; sp.Text("Example block-level help text here") ;});\n    new CheckboxField(fs, (lb,cb)=&gt;{lb.Text("check me out");});\n    new SubmitButton(fs, bt=&gt;{\n        bt.Text("Submit");\n        bt(ev=&gt;{ev.PreventDefault();});\n    });\n  });\n});</textarea></div>');
		})).appendTo(parent);
		//------------------
		$(document.createElement('h2')).text('Optional Layouts').appendTo(parent);
		$(document.createElement('h3')).text('Search form').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div1) {
			div1.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div1, function(f1) {
				f1.className = 'form-search';
				new Cayita.UI.InputText.$ctor2(f1, function(input1) {
					input1.className = 'input-medium search-query';
				});
				new Cayita.UI.SubmitButton.$ctor1(f1, function(bt1) {
					$(bt1).text('Search');
					$(bt1).on('click', function(ev1) {
						ev1.preventDefault();
					});
				});
			});
			$(div1).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-search"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class="string">"input-medium&nbsp;search-query"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Search"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n\tf.ClassName="form-search";\n\tnew InputText(f, input=&gt;{\n\t\tinput.ClassName="input-medium search-query";\n\t});\n\tnew SubmitButton(f, bt=&gt;{\n\t\tbt.Text("Search");\n\t\tbt.OnClick(ev=&gt;{ev.PreventDefault();});\n\t});\n});</textarea></div>');
		})).appendTo(parent);
		//---------------------------------
		$(document.createElement('h3')).text('Inline Form').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div2) {
			div2.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div2, function(f2) {
				f2.className = 'form-inline';
				new Cayita.UI.InputText.$ctor2(f2, function(input2) {
					input2.className = 'input-small';
					$(input2).attr('placeholder', 'Email');
				});
				new Cayita.UI.InputPassword.$ctor1(f2, function(input3) {
					input3.className = 'input-small';
					$(input3).attr('placeholder', 'Password');
				});
				new Cayita.UI.Label.$ctor1(f2, function(lb2) {
					new Cayita.UI.InputCheckbox.$ctor2(lb2, function(cb1) {
					});
					$(lb2).append('Remember me');
					lb2.className = 'checkbox';
				});
				new Cayita.UI.SubmitButton.$ctor1(f2, function(bt2) {
					$(bt2).text('Sign in');
					$(bt2).on('click', function(ev2) {
						ev2.preventDefault();
					});
				});
			});
			$(div2).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-inline"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class="string">"input-small"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputPassword(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class="string">"input-small"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class="string">"Password"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(f,&nbsp;lb=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputCheckbox(lb,&nbsp;cb=&gt;{});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Append(<span class="string">"Remember&nbsp;me"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.ClassName=<span class="string">"checkbox"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Sign&nbsp;in"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n\tf.ClassName="form-inline";\n\tnew InputText(f, input=&gt;{\n\t\tinput.ClassName="input-small";\n\t\tinput.SetPlaceHolder("Email");\n\t});\n\tnew InputPassword(f, input=&gt;{\n\t\tinput.ClassName="input-small";\n\t\tinput.SetPlaceHolder("Password");\n\t});\n\tnew Label(f, lb=&gt;{\n\t\tnew InputCheckbox(lb, cb=&gt;{});\n\t\tlb.Append("Remember me");\n\t\tlb.ClassName="checkbox";\n\t});\n\tnew SubmitButton(f, bt=&gt;{\n\t\tbt.Text("Sign in");\n\t\tbt.OnClick(ev=&gt;{ev.PreventDefault();});\n\t});\n});</textarea></div>');
		})).appendTo(parent);
		//--------------------------------
		$(document.createElement('h3')).text('Horizontal Form').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div3) {
			div3.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div3, function(f3) {
				f3.className = 'form-horizontal';
				new Cayita.UI.TextField.$ctor1(f3, function(label, input4) {
					$(label).text('Email');
					$(input4).attr('placeholder', 'Email');
				});
				new Cayita.UI.TextField.$ctor1(f3, function(label1, input5) {
					$(label1).text('Password');
					input5.type = 'password';
					$(input5).attr('placeholder', 'Password');
				});
				new Cayita.UI.CheckboxField.$ctor1(f3, function(lb3, cb2) {
					$(lb3).text('Remember me');
					new Cayita.UI.SubmitButton.$ctor1(lb3.parentNode, function(bt3) {
						$(bt3).text('Sign in');
						$(bt3).on('click', function(ev3) {
							ev3.preventDefault();
						});
					});
				});
			});
			$(div3).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-horizontal"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class="string">"Password"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.Type=<span class="string">"password"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.SetPlaceHolder(<span class="string">"Password"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(f,&nbsp;(lb,cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class="string">"Remember&nbsp;me"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(lb.ParentNode,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Sign&nbsp;in"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n\tf.ClassName="form-horizontal";\n\tnew TextField(f, (label,input)=&gt;{\n\t\tlabel.Text("Email");\n\t\tinput.SetPlaceHolder("Email");\n\t});\n\tnew TextField(f, (label,input)=&gt;{\n\t\tlabel.Text("Password");\n\t\tinput.Type="password";\n\t\tinput.SetPlaceHolder("Password");\n\t});\n\tnew CheckboxField(f, (lb,cb)=&gt;{\n\t\tlb.Text("Remember me");\n\t\tnew SubmitButton(lb.ParentNode, bt=&gt;{\n\t\t\tbt.Text("Sign in");\n\t\t\tbt.OnClick(ev=&gt;{ev.PreventDefault();});\n\t\t});\n\t});\n});</textarea></div>');
		})).appendTo(parent);
		//----------------------------------
		$(document.createElement('h2')).text('Samples').appendTo(parent);
		$(document.createElement('h3')).text('Login Form').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div4) {
			div4.className = 'bs-docs-example';
			Cayita.UI.Div.createContainer$1(div4, function(container) {
				Cayita.UI.Div.createRow$1(container, function(row) {
					new Cayita.UI.Div.$ctor1(row, function(element) {
						element.className = 'span4 offset3 well';
						new Cayita.UI.Legend.$ctor1(element, function(l) {
							$(l).text('Login Form');
						});
						new Cayita.UI.Form.$ctor1(element, function(fe) {
							Cayita.UI.Div.createControlGroup$1(fe, function(cg) {
								new Cayita.UI.InputText.$ctor2(cg, function(pe) {
									$(pe).attr('placeholder', 'your username');
									pe.name = 'UserName';
									pe.className = 'span12';
									$(pe).attr('required', true);
									$(pe).attr('minlength', 8);
								});
							});
							Cayita.UI.Div.createControlGroup$1(fe, function(cg1) {
								new Cayita.UI.InputPassword.$ctor1(cg1, function(pe1) {
									$(pe1).attr('placeholder', 'your password');
									pe1.name = 'Password';
									pe1.className = 'span12';
									$(pe1).attr('required', true);
									$(pe1).attr('minlength', 6);
								});
							});
							new Cayita.UI.CheckboxField.$ctor1(fe, function(lb4, cb3) {
								$(lb4).text('Remember me');
								cb3.name = 'Remember';
							});
							new Cayita.UI.SubmitButton.$ctor1(fe, function(b) {
								$(b).text('Login');
								$(b).addClass('btn-info btn-block');
								$(b).button.defaults.loadingText = '  authenticating ...';
							});
							$(fe).validate(ValidateOptions.setSubmitHandler(ValidateOptions.$ctor(), function(f4) {
								var bt4 = Cayita.UI.Ext.find(Element).call(null, f4, '[type=submit]');
								$(bt4).button('loading');
								window.setTimeout(function() {
									$(bt4).button('reset');
									Cayita.UI.Div.createAlertSuccessAfter(f4, 'Welcome : ' + cayita.fn.getValue(Cayita.UI.Ext.findByName(Element).call(null, f4, 'UserName')));
									f4.reset();
								}, 1000);
							}));
						});
					});
				});
			});
			//
			$(div4).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Div.CreateContainer(div,&nbsp;container=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRow(container,&nbsp;row=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,element=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;element.ClassName=<span class="string">"span4&nbsp;offset3&nbsp;well"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Legend(element,&nbsp;&nbsp;l=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.InnerText=<span class="string">"Login&nbsp;Form"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Form(element,&nbsp;fe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateControlGroup(fe,cg=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(cg,&nbsp;pe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetPlaceHolder(<span class="string">"your&nbsp;username"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Name=<span class="string">"UserName"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.ClassName=<span class="string">"span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetRequired();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetMinLength(8);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateControlGroup(fe,&nbsp;cg=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputPassword(cg,&nbsp;pe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetPlaceHolder(<span class="string">"your&nbsp;password"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.Name=<span class="string">"Password"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.ClassName=<span class="string">"span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetRequired();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pe.SetMinLength(6);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(fe,&nbsp;(lb,&nbsp;cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class="string">"Remember&nbsp;me"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.Name=<span class="string">"Remember"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(fe,&nbsp;b=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Text(<span class="string">"Login"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.AddClass(<span class="string">"btn-info&nbsp;btn-block"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.LoadingText(<span class="string">"&nbsp;&nbsp;authenticating&nbsp;..."</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fe.Validate(&nbsp;<span class="keyword">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bt&nbsp;=f.Find&lt;ButtonElement&gt;(<span class="string">"[type=submit]"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ShowLoadingText();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Window.SetTimeout(()=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ResetLoadingText();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessAfter(f,<span class="string">"Welcome&nbsp;:&nbsp;"</span><span>+&nbsp;f.FindByName&lt;InputElement&gt;(</span><span class="string">"UserName"</span><span>).GetValue());&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Reset();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;1000);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">Div.CreateContainer(div, container=&gt;{\n\tDiv.CreateRow(container, row=&gt;{\n\t\tnew Div(row,element=&gt;{\n\t\t\telement.ClassName="span4 offset3 well";\n\t\t\tnew Legend(element,  l=&gt;{\n\t\t\t\tl.InnerText="Login Form";\n\t\t\t});\n\t\t\t\n\t\t\tnew Form(element, fe=&gt;{\n\t\t\t\tDiv.CreateControlGroup(fe,cg=&gt;{\n\t\t\t\t\tnew InputText(cg, pe=&gt;{\n\t\t\t\t\t\tpe.SetPlaceHolder("your username");\n\t\t\t\t\t\tpe.Name="UserName";\n\t\t\t\t\t\tpe.ClassName="span12";\n\t\t\t\t\t\tpe.SetRequired();\n\t\t\t\t\t\tpe.SetMinLength(8);\n\t\t\t\t\t});\n\t\t\t\t});\n\t\t\t\t\n\t\t\t\tDiv.CreateControlGroup(fe, cg=&gt;{\n\t\t\t\t\tnew InputPassword(cg, pe=&gt;{\n\t\t\t\t\t\tpe.SetPlaceHolder("your password");\n\t\t\t\t\t\tpe.Name="Password";\n\t\t\t\t\t\tpe.ClassName="span12";\n\t\t\t\t\t\tpe.SetRequired();\n\t\t\t\t\t\tpe.SetMinLength(6);\n\t\t\t\t\t});\n\t\t\t\t});\n\t\t\t\t\n\t\t\t\tnew CheckboxField(fe, (lb, cb)=&gt;{\n\t\t\t\t\tlb.Text("Remember me");\n\t\t\t\t\tcb.Name="Remember";\n\t\t\t\t});\n\t\t\t\t\n\t\t\t\tnew SubmitButton(fe, b=&gt;{\n\t\t\t\t\tb.Text("Login");\n\t\t\t\t\tb.AddClass("btn-info btn-block");\n\t\t\t\t\tb.LoadingText("  authenticating ...");\n\t\t\t\t});\n\t\t\t\t\n\t\t\t\tfe.Validate( new ValidateOptions().SetSubmitHandler(f=&gt;{\n\t\t\t\t\tvar bt =f.Find&lt;ButtonElement&gt;("[type=submit]");\n\t\t\t\t\tbt.ShowLoadingText();\n\t\t\t\t\tWindow.SetTimeout(()=&gt;{\n\t\t\t\t\t\tbt.ResetLoadingText();\n\t\t\t\t\t\tDiv.CreateAlertSuccessAfter(f,"Welcome : "+ f.FindByName&lt;InputElement&gt;("UserName").GetValue());\n\t\t\t\t\t\tf.Reset();\n\t\t\t\t\t}, 1000);\n\t\t\t\t}));\n\t\t\t});\n\t\t});\n\t});\n});\t</textarea></div>');
		})).appendTo(parent);
		//-----------------------------------
		$(document.createElement('h3')).text('Contact Form').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div5) {
			div5.className = 'bs-docs-example';
			Cayita.UI.Div.createContainer$1(div5, function(container1) {
				new Cayita.UI.Form.$ctor1(container1, function(f5) {
					$(f5).addClass('well span8');
					Cayita.UI.Div.createRowFluid$1(f5, function(row1) {
						new Cayita.UI.Div.$ctor1(row1, function(sp1) {
							sp1.className = 'span5';
							new Cayita.UI.Label.$ctor1(sp1, function(l1) {
								$(l1).text('FirstName');
							});
							new Cayita.UI.InputText.$ctor2(sp1, function(i) {
								i.className = 'span12';
								$(i).attr('required', true);
							});
							new Cayita.UI.Label.$ctor1(sp1, function(l2) {
								$(l2).text('LastName');
							});
							new Cayita.UI.InputText.$ctor2(sp1, function(i1) {
								i1.className = 'span12';
							});
							new Cayita.UI.Label.$ctor1(sp1, function(l3) {
								$(l3).text('Email address');
							});
							new Cayita.UI.InputText.$ctor2(sp1, function(i2) {
								i2.className = 'span12';
								i2.name = 'Email';
							});
							new Cayita.UI.Label.$ctor1(sp1, function(l4) {
								$(l4).text('Subject');
							});
							new Cayita.UI.HtmlSelect.$ctor2(sp1, function(sl) {
								sl.name = 'Subject';
								sl.className = 'span12';
								new Cayita.UI.HtmlOption.$ctor1(sl, function(opt) {
									opt.value = '';
									$(opt).text('Choose One:');
								});
								new Cayita.UI.HtmlOption.$ctor1(sl, function(opt1) {
									opt1.value = '1';
									$(opt1).text('General Customer Service');
								});
								new Cayita.UI.HtmlOption.$ctor1(sl, function(opt2) {
									opt2.value = '2';
									$(opt2).text('Suggestions');
								});
								new Cayita.UI.HtmlOption.$ctor1(sl, function(opt3) {
									opt3.value = '3';
									$(opt3).text('Product Support');
								});
								new Cayita.UI.HtmlOption.$ctor1(sl, function(opt4) {
									opt4.value = '4';
									$(opt4).text('Bug');
								});
							});
						});
						new Cayita.UI.Div.$ctor1(row1, function(sp2) {
							sp2.className = 'span7';
							new Cayita.UI.Label.$ctor1(sp2, function(l5) {
								$(l5).text('Message');
							});
							new Cayita.UI.TextArea.$ctor1(sp2, function(ta) {
								ta.className = 'input-xlarge span12';
								ta.rows = 11;
							});
						});
						new Cayita.UI.SubmitButton.$ctor1(row1, function(bt5) {
							$(bt5).addClass('btn-primary pull-right');
							$(bt5).text('Send');
						});
						$(f5).validate(ValidateOptions.addRule(ValidateOptions.addRule(ValidateOptions.setSubmitHandler(ValidateOptions.$ctor(), function(vf) {
							Cayita.UI.Div.createAlertSuccessBefore(vf.firstChild, 'message sent');
							vf.reset();
						}), function(rf, ms) {
							rf.element = Cayita.UI.Ext.findByName(Element).call(null, f5, 'Subject');
							Rule.required(rf.rule);
							Message.required(ms, 'choose an option');
						}), function(rf1, ms1) {
							rf1.element = Cayita.UI.Ext.findByName(Element).call(null, f5, 'Email');
							Rule.email(rf1.rule, null);
							Message.email(ms1, 'write a valid email ');
						}));
					});
				});
			});
			$(div5).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(&nbsp;container,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.AddClass(<span class="string">"well&nbsp;span8"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRowFluid(f,&nbsp;row=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class="string">"span5"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(sp,&nbsp;l=&gt;l.Text(</span><span class="string">"FirstName"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(sp,&nbsp;i=&gt;{i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;i.SetRequired();});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(sp,&nbsp;l=&gt;l.Text(</span><span class="string">"LastName"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(sp,&nbsp;i=&gt;i.ClassName=</span><span class="string">"span12"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(sp,&nbsp;l=&gt;l.Text(</span><span class="string">"Email&nbsp;address"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(sp,&nbsp;i=&gt;{&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;i.Name=</span><span class="string">"Email"</span><span>;&nbsp;});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(sp,&nbsp;l=&gt;l.Text(</span><span class="string">"Subject"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlSelect(sp,&nbsp;sl=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sl.Name=<span class="string">"Subject"</span><span>;sl.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(sl,&nbsp;opt=&gt;{opt.Value=</span><span class="string">""</span><span>;&nbsp;opt.Text(</span><span class="string">"Choose&nbsp;One:"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(sl,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"1"</span><span>;&nbsp;opt.Text(</span><span class="string">"General&nbsp;Customer&nbsp;Service"</span><span>);});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(sl,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"2"</span><span>;&nbsp;opt.Text(</span><span class="string">"Suggestions"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(sl,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"3"</span><span>;&nbsp;opt.Text(</span><span class="string">"Product&nbsp;Support"</span><span>);});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(sl,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"4"</span><span>;&nbsp;opt.Text(</span><span class="string">"Bug"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class="string">"span7"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(sp,&nbsp;l=&gt;l.Text(</span><span class="string">"Message"</span><span>));&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextArea(sp,&nbsp;ta=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ta.ClassName=<span class="string">"input-xlarge&nbsp;span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ta.Rows=11;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(row,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.AddClass(<span class="string">"btn-primary&nbsp;pull-right"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Send"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Validate(<span class="keyword">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(vf=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateAlertSuccessBefore(vf.FirstChild,<span class="string">"message&nbsp;sent"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vf.Reset();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;SelectElement&gt;(<span class="string">"Subject"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class="string">"choose&nbsp;an&nbsp;option"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;SelectElement&gt;(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Email();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Email(<span class="string">"write&nbsp;a&nbsp;valid&nbsp;&nbsp;email&nbsp;"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form( container, f=&gt;{\n\tf.AddClass("well span8");\n\tDiv.CreateRowFluid(f, row=&gt;{\n\t\tnew Div(row, sp=&gt;{\n\t\t\tsp.ClassName="span5";\n\t\t\tnew Label(sp, l=&gt;l.Text("FirstName"));\n\t\t\tnew InputText(sp, i=&gt;{i.ClassName="span12"; i.SetRequired();});\n\t\t\tnew Label(sp, l=&gt;l.Text("LastName"));\n\t\t\tnew InputText(sp, i=&gt;i.ClassName="span12");\n\t\t\tnew Label(sp, l=&gt;l.Text("Email address"));\n\t\t\tnew InputText(sp, i=&gt;{ i.ClassName="span12"; i.Name="Email"; });\n\t\t\tnew Label(sp, l=&gt;l.Text("Subject"));\n\t\t\tnew HtmlSelect(sp, sl=&gt;{\n\t\t\t\tsl.Name="Subject";sl.ClassName="span12";\n\t\t\t\tnew HtmlOption(sl, opt=&gt;{opt.Value=""; opt.Text("Choose One:");});\n\t\t\t\tnew HtmlOption(sl, opt=&gt;{opt.Value="1"; opt.Text("General Customer Service");});\n\t\t\t\tnew HtmlOption(sl, opt=&gt;{opt.Value="2"; opt.Text("Suggestions");});\n\t\t\t\tnew HtmlOption(sl, opt=&gt;{opt.Value="3"; opt.Text("Product Support");});\n\t\t\t\tnew HtmlOption(sl, opt=&gt;{opt.Value="4"; opt.Text("Bug");});\n\t\t\t});\n\t\t});\n\t\t\n\t\tnew Div(row, sp=&gt;{\n\t\t\tsp.ClassName="span7";\n\t\t\tnew Label(sp, l=&gt;l.Text("Message"));\n\t\t\tnew TextArea(sp, ta=&gt;{\n\t\t\t\tta.ClassName="input-xlarge span12";\n\t\t\t\tta.Rows=11;\n\t\t\t});\n\t\t\t\n\t\t});\n\t\tnew SubmitButton(row, bt=&gt;{\n\t\t\tbt.AddClass("btn-primary pull-right");\n\t\t\tbt.Text("Send");\n\t\t});\n\t\t\n\t\tf.Validate(new ValidateOptions().SetSubmitHandler(vf=&gt;{\n\t\t\tDiv.CreateAlertSuccessBefore(vf.FirstChild,"message sent");\n\t\t\tvf.Reset();\n\t\t}).AddRule((rf,ms)=&gt;{\n\t\t\trf.Element= f.FindByName&lt;SelectElement&gt;("Subject");\n\t\t\trf.Rule.Required();\n\t\t\tms.Required("choose an option");\n\t\t}).AddRule((rf,ms)=&gt;{\n\t\t\trf.Element= f.FindByName&lt;SelectElement&gt;("Email");\n\t\t\trf.Rule.Email();\n\t\t\tms.Email("write a valid  email ");\n\t\t}));\n\t});\n});</textarea></div>');
		})).appendTo(parent);
		//-----------------------------------
	};
	ss.registerClass(global, 'DemoForm', $DemoForm);
})();
