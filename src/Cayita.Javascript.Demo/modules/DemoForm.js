(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoForm.DemoForm
	var $DemoForm = function() {
	};
	$DemoForm.execute = function(parent) {
		$(parent).append(StringExtensions.header('Default styles', 2));
		(new Cayita.UI.Div.$ctor2(null, function(div) {
			div.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div, function(f) {
				new Cayita.UI.FieldSet.$ctor1(f, function(fs) {
					new Cayita.UI.Legend.$ctor1(fs, function(lg) {
						Extensions.text$1(lg, 'Legend');
					});
					new Cayita.UI.Label.$ctor2(fs, function(lb) {
						Extensions.text$1(lb, 'Label Name');
					});
					new Cayita.UI.InputText.$ctor1(fs, function(input) {
						$(input).attr('placeholder', 'Type something');
					});
					new Cayita.UI.Span.$ctor2(fs, function(sp) {
						sp.className = 'help-block';
						Extensions.text$1(sp, 'Example block-level help text here');
					});
					new Cayita.UI.CheckboxField.$ctor4(fs, function(lb1, cb) {
						Extensions.text$1(lb1, 'check me out');
					});
					new Cayita.UI.SubmitButton.$ctor1(fs, function(bt) {
						Extensions.text$1(bt, 'Submit');
						$(bt).on('click', function(ev) {
							ev.preventDefault();
						});
					});
				});
			});
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;FieldSet(f,&nbsp;fs=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Legend(fs,&nbsp;lg=&gt;&nbsp;lg.Text(</span><span class="string">"Legend"</span><span>)&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(fs,&nbsp;lb=&gt;&nbsp;lb.Text(</span><span class="string">"Label&nbsp;Name"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(fs,&nbsp;input=&gt;&nbsp;input.PlaceHolder(</span><span class="string">"Type&nbsp;something"</span><span>));&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Span(fs,&nbsp;sp&nbsp;=&gt;{&nbsp;sp.ClassName=</span><span class="string">"help-block"</span><span>;&nbsp;sp.Text(</span><span class="string">"Example&nbsp;block-level&nbsp;help&nbsp;text&nbsp;here"</span><span>)&nbsp;;});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(fs,&nbsp;(lb,cb)=&gt;{lb.Text(</span><span class="string">"check&nbsp;me&nbsp;out"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(fs,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Submit"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n  new FieldSet(f, fs=&gt;{\n    new Legend(fs, lg=&gt; lg.Text("Legend") );\n    new Label(fs, lb=&gt; lb.Text("Label Name"));\n    new InputText(fs, input=&gt; input.PlaceHolder("Type something"));\n    new Span(fs, sp =&gt;{ sp.ClassName="help-block"; sp.Text("Example block-level help text here") ;});\n    new CheckboxField(fs, (lb,cb)=&gt;{lb.Text("check me out");});\n    new SubmitButton(fs, bt=&gt;{\n        bt.Text("Submit");\n        bt(ev=&gt;{ev.PreventDefault();});\n    });\n  });\n});</textarea></div>');
		})).appendTo$2(parent);
		//------------------
		$(parent).append(StringExtensions.header('Optional Layouts', 2));
		$(parent).append(StringExtensions.header('Search form', 3));
		(new Cayita.UI.Div.$ctor2(null, function(div1) {
			div1.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div1, function(f1) {
				f1.className = 'form-search';
				new Cayita.UI.InputText.$ctor1(f1, function(input1) {
					input1.className = 'input-medium search-query';
				});
				new Cayita.UI.SubmitButton.$ctor1(f1, function(bt1) {
					Extensions.text$1(bt1, 'Search');
					$(bt1).on('click', function(ev1) {
						ev1.preventDefault();
					});
				});
			});
			$(div1).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-search"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class="string">"input-medium&nbsp;search-query"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Search"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n\tf.ClassName="form-search";\n\tnew InputText(f, input=&gt;{\n\t\tinput.ClassName="input-medium search-query";\n\t});\n\tnew SubmitButton(f, bt=&gt;{\n\t\tbt.Text("Search");\n\t\tbt.OnClick(ev=&gt;{ev.PreventDefault();});\n\t});\n});</textarea></div>');
		})).appendTo$2(parent);
		//---------------------------------
		$(parent).append(StringExtensions.header('Inline Form', 3));
		(new Cayita.UI.Div.$ctor2(null, function(div2) {
			div2.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div2, function(f2) {
				f2.className = 'form-inline';
				new Cayita.UI.InputText.$ctor1(f2, function(input2) {
					input2.className = 'input-small';
					$(input2).attr('placeholder', 'Email');
				});
				new Cayita.UI.InputPassword.$ctor1(f2, function(input3) {
					input3.className = 'input-small';
					$(input3).attr('placeholder', 'Password');
				});
				new Cayita.UI.Label.$ctor2(f2, function(lb2) {
					new Cayita.UI.InputCheckbox.$ctor3(lb2, function(cb1) {
					});
					$(lb2).append('Remember me');
					lb2.className = 'checkbox';
				});
				new Cayita.UI.SubmitButton.$ctor1(f2, function(bt2) {
					Extensions.text$1(bt2, 'Sign in');
					$(bt2).on('click', function(ev2) {
						ev2.preventDefault();
					});
				});
			});
			$(div2).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-inline"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class="string">"input-small"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputPassword(f,&nbsp;input=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.ClassName=<span class="string">"input-small"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class="string">"Password"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Label(f,&nbsp;lb=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputCheckbox(lb,&nbsp;cb=&gt;{});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Append(<span class="string">"Remember&nbsp;me"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.ClassName=<span class="string">"checkbox"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(f,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Sign&nbsp;in"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n\tf.ClassName="form-inline";\n\tnew InputText(f, input=&gt;{\n\t\tinput.ClassName="input-small";\n\t\tinput.PlaceHolder("Email");\n\t});\n\tnew InputPassword(f, input=&gt;{\n\t\tinput.ClassName="input-small";\n\t\tinput.PlaceHolder("Password");\n\t});\n\tnew Label(f, lb=&gt;{\n\t\tnew InputCheckbox(lb, cb=&gt;{});\n\t\tlb.Append("Remember me");\n\t\tlb.ClassName="checkbox";\n\t});\n\tnew SubmitButton(f, bt=&gt;{\n\t\tbt.Text("Sign in");\n\t\tbt.OnClick(ev=&gt;{ev.PreventDefault();});\n\t});\n});</textarea></div>');
		})).appendTo$2(parent);
		//--------------------------------
		$(parent).append(StringExtensions.header('Horizontal Form', 3));
		(new Cayita.UI.Div.$ctor2(null, function(div3) {
			div3.className = 'bs-docs-example';
			new Cayita.UI.Form.$ctor1(div3, function(f3) {
				f3.className = 'form-horizontal';
				new Cayita.UI.TextField.$ctor5(f3, function(label, input4) {
					Extensions.text$1(label, 'Email');
					$(input4).attr('placeholder', 'Email');
				});
				new Cayita.UI.TextField.$ctor5(f3, function(label1, input5) {
					Extensions.text$1(label1, 'Password');
					input5.type = 'password';
					$(input5).attr('placeholder', 'Password');
				});
				new Cayita.UI.CheckboxField.$ctor4(f3, function(lb3, cb2) {
					Extensions.text$1(lb3, 'Remember me');
					new Cayita.UI.SubmitButton.$ctor1(lb3.parentNode, function(bt3) {
						Extensions.text$1(bt3, 'Sign in');
						$(bt3).on('click', function(ev3) {
							ev3.preventDefault();
						});
					});
				});
			});
			$(div3).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(div&nbsp;,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-horizontal"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,&nbsp;(label,input)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Text(<span class="string">"Password"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.Type=<span class="string">"password"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;input.PlaceHolder(<span class="string">"Password"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(f,&nbsp;(lb,cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class="string">"Remember&nbsp;me"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(lb.ParentNode,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Sign&nbsp;in"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.OnClick(ev=&gt;{ev.PreventDefault();});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(div , f=&gt;{\n\tf.ClassName="form-horizontal";\n\tnew TextField(f, (label,input)=&gt;{\n\t\tlabel.Text("Email");\n\t\tinput.PlaceHolder("Email");\n\t});\n\tnew TextField(f, (label,input)=&gt;{\n\t\tlabel.Text("Password");\n\t\tinput.Type="password";\n\t\tinput.PlaceHolder("Password");\n\t});\n\tnew CheckboxField(f, (lb,cb)=&gt;{\n\t\tlb.Text("Remember me");\n\t\tnew SubmitButton(lb.ParentNode, bt=&gt;{\n\t\t\tbt.Text("Sign in");\n\t\t\tbt.OnClick(ev=&gt;{ev.PreventDefault();});\n\t\t});\n\t});\n});</textarea></div>');
		})).appendTo$2(parent);
		//----------------------------------
		$(parent).append(StringExtensions.header('Samples', 2));
		$(parent).append(StringExtensions.header('Login Form', 3));
		(new Cayita.UI.Div.$ctor2(null, function(div4) {
			div4.className = 'bs-docs-example';
			Cayita.UI.Div.createContainer$1(div4, function(container) {
				Cayita.UI.Div.createRow$1(container, function(row) {
					new Cayita.UI.Div.$ctor2(row, function(element) {
						element.className = 'span4 offset3 well';
						new Cayita.UI.Legend.$ctor1(element, function(l) {
							Extensions.text$1(l, 'Login Form');
						});
						new Cayita.UI.Form.$ctor1(element, function(fe) {
							new Cayita.UI.TextField.$ctor6(fe, function(i) {
								$(i).attr('placeholder', 'your username');
								i.name = 'UserName';
								i.className = 'span12';
								$(i).attr('required', true);
								$(i).attr('minlength', 8);
							});
							new Cayita.UI.TextField.$ctor6(fe, function(i1) {
								$(i1).attr('placeholder', 'your password');
								i1.name = 'Password';
								i1.className = 'span12';
								$(i1).attr('required', true);
								$(i1).attr('minlength', 6);
								i1.type = 'password';
							});
							new Cayita.UI.CheckboxField.$ctor4(fe, function(lb4, cb3) {
								Extensions.text$1(lb4, 'Remember me');
								cb3.name = 'Remember';
							});
							new Cayita.UI.SubmitButton.$ctor1(fe, function(b) {
								Extensions.text$1(b, 'Login');
								$(b).addClass('btn-info btn-block');
								$(b).button.defaults.loadingText = '  authenticating ...';
							});
							$(fe).validate(Cayita.Plugins.ValidateOptions.setSubmitHandler(Cayita.Plugins.ValidateOptions.$ctor(), function(f4) {
								var bt4 = Extensions.find(Element).call(null, f4, '[type=submit]');
								$(bt4).button('loading');
								window.setTimeout(function() {
									$(bt4).button('reset');
									Cayita.UI.Alert.success$1(f4, 'Welcome : ' + cayita.fn.getValue(Extensions.findByName(Element).call(null, f4, 'UserName')), false);
									cayita.fn.clearForm(f4);
								}, 1000);
							}));
						});
					});
				});
			});
			$(div4).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(element,&nbsp;fe=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(fe,&nbsp;i=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.PlaceHolder(<span class="string">"your&nbsp;username"</span><span>);&nbsp;&nbsp;i.Name=</span><span class="string">"UserName"</span><span>;&nbsp;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.();i.MinLength(8);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(fe,&nbsp;i=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.PlaceHolder(<span class="string">"your&nbsp;password"</span><span>);&nbsp;&nbsp;i.Name=</span><span class="string">"Password"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Requiered();&nbsp;i.MinLength(6);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Type=<span class="string">"password"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(fe,&nbsp;(lb,&nbsp;cb)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lb.Text(<span class="string">"Remember&nbsp;me"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.Name=<span class="string">"Remember"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(fe,&nbsp;b=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.Text(<span class="string">"Login"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.AddClass(<span class="string">"btn-info&nbsp;btn-block"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;b.LoadingText(<span class="string">"&nbsp;&nbsp;authenticating&nbsp;..."</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;fe.Validate(&nbsp;<span class="keyword">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(f=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bt&nbsp;=f.Find&lt;ButtonElement&gt;(<span class="string">"[type=submit]"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ShowLoadingText();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Window.SetTimeout(()=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ResetLoadingText();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Alert.Success(f,<span class="string">"Welcome&nbsp;:&nbsp;"</span><span>+&nbsp;f.FindByName&lt;InputElement&gt;(</span><span class="string">"UserName"</span><span>).GetValue(),false);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Clear();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;1000);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form(element, fe=&gt;{\n\tnew TextField(fe, i=&gt;{\n\t\ti.PlaceHolder("your username");\ti.Name="UserName";\ti.ClassName="span12";\n\t\ti.Requiered();i.MinLength(8);\n\t});\n\t\n\tnew TextField(fe, i=&gt;{\n\t\ti.PlaceHolder("your password");\ti.Name="Password"; i.ClassName="span12";\n\t\ti.Requiered(); i.MinLength(6);\n\t\ti.Type="password";\n\t});\n\t\n\tnew CheckboxField(fe, (lb, cb)=&gt;{\n\t\tlb.Text("Remember me");\n\t\tcb.Name="Remember";\n\t});\n\t\n\tnew SubmitButton(fe, b=&gt;{\n\t\tb.Text("Login");\n\t\tb.AddClass("btn-info btn-block");\n\t\tb.LoadingText("  authenticating ...");\n\t});\n\t\n\tfe.Validate( new ValidateOptions().SetSubmitHandler(f=&gt;{\n\t\tvar bt =f.Find&lt;ButtonElement&gt;("[type=submit]");\n\t\tbt.ShowLoadingText();\n\t\tWindow.SetTimeout(()=&gt;{\n\t\t\tbt.ResetLoadingText();\n\t\t\tAlert.Success(f,"Welcome : "+ f.FindByName&lt;InputElement&gt;("UserName").GetValue(),false);\n\t\t\tf.Clear();\n\t\t}, 1000);\n\t}));\n});</textarea></div>');
		})).appendTo$2(parent);
		//-----------------------------------
		$(parent).append(StringExtensions.header('Contact Form', 3));
		(new Cayita.UI.Div.$ctor2(null, function(div5) {
			div5.className = 'bs-docs-example';
			Cayita.UI.Div.createContainer$1(div5, function(container1) {
				new Cayita.UI.Form.$ctor1(container1, function(f5) {
					$(f5).addClass('well span8');
					Cayita.UI.Div.createRowFluid$1(f5, function(row1) {
						new Cayita.UI.Div.$ctor2(row1, function(sp1) {
							sp1.className = 'span5';
							new Cayita.UI.TextField.$ctor5(sp1, function(l1, i2) {
								Extensions.text$1(l1, 'FirstName');
								i2.name = 'FirstName';
								i2.className = 'span12';
							});
							new Cayita.UI.TextField.$ctor5(sp1, function(l2, i3) {
								Extensions.text$1(l2, 'LastName');
								i3.name = 'LastName';
								i3.className = 'span12';
							});
							new Cayita.UI.TextField.$ctor5(sp1, function(l3, i4) {
								Extensions.text$1(l3, 'Email address');
								i4.name = 'Email';
								i4.className = 'span12';
							});
							new Cayita.UI.SelectField.$ctor3(sp1, function(l4, i5) {
								Extensions.text$1(l4, 'Subject');
								i5.name = 'Subject';
								i5.className = 'span12';
								new Cayita.UI.HtmlOption.$ctor1(i5, function(opt) {
									opt.value = '';
									Extensions.text$1(opt, 'Choose One:');
								});
								new Cayita.UI.HtmlOption.$ctor1(i5, function(opt1) {
									opt1.value = '1';
									Extensions.text$1(opt1, 'General Customer Service');
								});
								new Cayita.UI.HtmlOption.$ctor1(i5, function(opt2) {
									opt2.value = '2';
									Extensions.text$1(opt2, 'Suggestions');
								});
								new Cayita.UI.HtmlOption.$ctor1(i5, function(opt3) {
									opt3.value = '3';
									Extensions.text$1(opt3, 'Product Support');
								});
								new Cayita.UI.HtmlOption.$ctor1(i5, function(opt4) {
									opt4.value = '4';
									Extensions.text$1(opt4, 'Bug');
								});
							});
						});
						new Cayita.UI.Div.$ctor2(row1, function(sp2) {
							sp2.className = 'span7';
							new Cayita.UI.TextAreaField.$ctor3(sp2, function(l5, i6) {
								Extensions.text$1(l5, 'Message');
								i6.className = 'input-xlarge span12';
								i6.rows = 11;
								i6.name = 'Message';
							});
						});
						new Cayita.UI.SubmitButton.$ctor1(row1, function(bt5) {
							$(bt5).addClass('btn-primary pull-right');
							Extensions.text$1(bt5, 'Send');
						});
						$(f5).validate(Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.setSubmitHandler(Cayita.Plugins.ValidateOptions.$ctor(), function(vf) {
							Cayita.UI.Alert.success$1(vf.firstChild, 'message sent', true);
							cayita.fn.clearForm(vf);
						}), function(rf, ms) {
							rf.element = Extensions.findByName(Element).call(null, f5, 'Subject');
							Cayita.Plugins.Rule.required(rf.rule);
							Cayita.Plugins.Message.required(ms, 'choose an option');
						}), function(rf1, ms1) {
							rf1.element = Extensions.findByName(Element).call(null, f5, 'Email');
							Cayita.Plugins.Rule.email(rf1.rule, null);
							Cayita.Plugins.Message.email(ms1, 'write a valid email ');
						}), function(rf2, ms2) {
							rf2.element = Extensions.findByName(Element).call(null, f5, 'FirstName');
							Cayita.Plugins.Rule.required(rf2.rule);
							Cayita.Plugins.Message.required(ms2, 'write your name');
							Cayita.Plugins.Rule.minlength(rf2.rule, 4);
							Cayita.Plugins.Message.minlength(ms2, 'min 4 chars');
						}));
					});
				});
			});
			$(div5).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Form(&nbsp;container,&nbsp;f=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;f.AddClass(<span class="string">"well&nbsp;span8"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;Div.CreateRowFluid(f,&nbsp;row=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class="string">"span5"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"FirstName"</span><span>);&nbsp;i.Name=</span><span class="string">"FirstName"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"LastName"</span><span>);&nbsp;i.Name=</span><span class="string">"LastName"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(sp,&nbsp;(l,i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Email&nbsp;address"</span><span>);&nbsp;i.Name=</span><span class="string">"Email"</span><span>;&nbsp;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SelectField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Subject"</span><span>);&nbsp;i.Name=</span><span class="string">"Subject"</span><span>;i.ClassName=</span><span class="string">"span12"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">""</span><span>;&nbsp;opt.Text(</span><span class="string">"Choose&nbsp;One:"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"1"</span><span>;&nbsp;opt.Text(</span><span class="string">"General&nbsp;Customer&nbsp;Service"</span><span>);});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"2"</span><span>;&nbsp;opt.Text(</span><span class="string">"Suggestions"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"3"</span><span>;&nbsp;opt.Text(</span><span class="string">"Product&nbsp;Support"</span><span>);});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;HtmlOption(i,&nbsp;opt=&gt;{opt.Value=</span><span class="string">"4"</span><span>;&nbsp;opt.Text(</span><span class="string">"Bug"</span><span>);});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(row,&nbsp;sp=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sp.ClassName=<span class="string">"span7"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextAreaField(sp,&nbsp;(l,&nbsp;i)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Message"</span><span>);&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=<span class="string">"input-xlarge&nbsp;span12"</span><span>;&nbsp;i.Rows=11;&nbsp;i.Name=</span><span class="string">"Message"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;SubmitButton(row,&nbsp;bt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.AddClass(<span class="string">"btn-primary&nbsp;pull-right"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Text(<span class="string">"Send"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Validate(<span class="keyword">new</span><span>&nbsp;ValidateOptions().SetSubmitHandler(vf=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Alert.Success(vf.FirstChild,<span class="string">"message&nbsp;sent"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vf.Clear();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;SelectElement&gt;(<span class="string">"Subject"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class="string">"choose&nbsp;an&nbsp;option"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Email();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Email(<span class="string">"write&nbsp;a&nbsp;valid&nbsp;email&nbsp;"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((rf,ms)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Element=&nbsp;f.FindByName&lt;TextElement&gt;(<span class="string">"FirstName"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Required();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Required(<span class="string">"write&nbsp;your&nbsp;name"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rf.Rule.Minlength(4);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ms.Minlength(<span class="string">"min&nbsp;4&nbsp;chars"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new Form( container, f=&gt;{\n\tf.AddClass("well span8");\n\tDiv.CreateRowFluid(f, row=&gt;{\n\t\tnew Div(row, sp=&gt;{\n\t\t\tsp.ClassName="span5";\n\t\t\tnew TextField(sp, (l,i)=&gt;{\n\t\t\t\tl.Text("FirstName"); i.Name="FirstName"; i.ClassName="span12"; \n\t\t\t});\n\t\t\tnew TextField(sp, (l,i)=&gt;{\n\t\t\t\tl.Text("LastName"); i.Name="LastName"; i.ClassName="span12"; \n\t\t\t});\n\t\t\t\n\t\t\tnew TextField(sp, (l,i)=&gt;{\n\t\t\t\tl.Text("Email address"); i.Name="Email"; i.ClassName="span12"; \n\t\t\t});\n\t\t\t\n\t\t\tnew SelectField(sp, (l, i)=&gt;{\n\t\t\t\tl.Text("Subject"); i.Name="Subject";i.ClassName="span12";\n\t\t\t\tnew HtmlOption(i, opt=&gt;{opt.Value=""; opt.Text("Choose One:");});\n\t\t\t\tnew HtmlOption(i, opt=&gt;{opt.Value="1"; opt.Text("General Customer Service");});\n\t\t\t\tnew HtmlOption(i, opt=&gt;{opt.Value="2"; opt.Text("Suggestions");});\n\t\t\t\tnew HtmlOption(i, opt=&gt;{opt.Value="3"; opt.Text("Product Support");});\n\t\t\t\tnew HtmlOption(i, opt=&gt;{opt.Value="4"; opt.Text("Bug");});\n\t\t\t});\n\t\t});\n\t\t\n\t\tnew Div(row, sp=&gt;{\n\t\t\tsp.ClassName="span7";\n\t\t\tnew TextAreaField(sp, (l, i)=&gt;{\n\t\t\t\tl.Text("Message"); \n\t\t\t\ti.ClassName="input-xlarge span12"; i.Rows=11; i.Name="Message";\n\t\t\t});\n\t\t\t\n\t\t});\n\t\tnew SubmitButton(row, bt=&gt;{\n\t\t\tbt.AddClass("btn-primary pull-right");\n\t\t\tbt.Text("Send");\n\t\t});\n\t\t\n\t\tf.Validate(new ValidateOptions().SetSubmitHandler(vf=&gt;{\n\t\t\tAlert.Success(vf.FirstChild,"message sent");\n\t\t\tvf.Clear();\n\t\t}).AddRule((rf,ms)=&gt;{\n\t\t\trf.Element= f.FindByName&lt;SelectElement&gt;("Subject");\n\t\t\trf.Rule.Required();\n\t\t\tms.Required("choose an option");\n\t\t}).AddRule((rf,ms)=&gt;{\n\t\t\trf.Element= f.FindByName&lt;TextElement&gt;("Email");\n\t\t\trf.Rule.Email();\n\t\t\tms.Email("write a valid email ");\n\t\t}).AddRule((rf,ms)=&gt;{\n\t\t\trf.Element= f.FindByName&lt;TextElement&gt;("FirstName");\n\t\t\trf.Rule.Required();\n\t\t\tms.Required("write your name");\n\t\t\trf.Rule.Minlength(4);\n\t\t\tms.Minlength("min 4 chars");\n\t\t}));\n\t});\n});</textarea></div>');
		})).appendTo$2(parent);
		//-----------------------------------
	};
	ss.registerClass(global, 'DemoForm', $DemoForm);
})();
