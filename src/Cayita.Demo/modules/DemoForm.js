(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoForm
	var $DemoForm = function() {
	};
	$DemoForm.execute = function(parent) {
		var form = Cayita.UI.Form();
		Cayita.UI.Atom('fieldset', null, null, null, function(fs) {
			Cayita.UI.Atom('legend', null, null, 'Legend', null, fs);
			Cayita.UI.Label(null, 'LabelText', null, fs);
			Cayita.UI.Input(String)('input', 'text', null, null, null, function(i) {
				i.placeholder = 'type something';
				i.name = 'text';
			}, fs);
			Cayita.UI.Atom('span', null, null, null, function(s) {
				s.set_text('Example block-level help text here');
				s.className = 'help-block';
			}, fs);
			Cayita.UI.CheckField(null, null, function(cf) {
				cf.input.name = 'allow';
				cf.input.set_text('Check me');
				cf.input.checked = true;
			}, fs);
			Cayita.UI.SubmitButton(null, function(b) {
				b.set_text('Send');
				b.add_clicked(function(e) {
					e.preventDefault();
					Alertify.log.info($(form).serialize(), 5000);
				});
			}, fs);
			form.append(fs);
		}, form);
		$(parent).append(Cayita.Fn.header('Default styles', 3)).append(form);
		var sform = Cayita.UI.Form();
		Cayita.UI.Input(String)('input', 'text', null, null, null, function(i1) {
			i1.name = 'stext';
			i1.placeholder = 'search for';
			i1.required = true;
			i1.className = 'input-medium search-query';
			i1.maxLength = 8;
			i1.set_minLength(3);
		}, sform);
		Cayita.UI.SubmitButton(null, function(b1) {
			b1.set_text('Search...');
			b1.add_clicked(function(e1) {
				if (!sform.checkValidity()) {
					return;
				}
				Alertify.log.info($(sform).serialize(), 5000);
			});
		}, sform);
		$(parent).append(Cayita.Fn.header('Optional Layouts', 3)).append(Cayita.Fn.header('Search Form', 4)).append(sform);
		var lform = Cayita.UI.Form();
		lform.submitHandler = function(f) {
			Alertify.log.info($(f).serialize(), 5000);
		};
		lform.className = 'form-inline';
		Cayita.UI.Input(String)('input', 'email', null, null, null, function(i2) {
			i2.placeholder = 'your email';
			i2.required = true;
			i2.name = 'email';
		}, lform);
		Cayita.UI.Input(String)('input', 'password', null, null, null, function(i3) {
			i3.placeholder = 'your password';
			i3.required = true;
			i3.name = 'password';
			i3.set_minLength(4);
		}, lform);
		Cayita.UI.BooleanCheck(null, null, null, function(i4) {
			i4.name = 'remember';
			i4.set_text('Remember?');
			i4.checked = true;
		}, lform);
		Cayita.UI.SubmitButton(null, function(b2) {
			b2.set_text('submit');
		}, lform);
		$(parent).append(Cayita.Fn.header('Inline Form', 4)).append(lform);
		Cayita.UI.Form(null, function(f1) {
			f1.className = 'form-horizontal';
			Cayita.UI.EmailField(null, null, function(i5) {
				i5.set_text('Email');
				i5.input.placeholder = 'your email';
				i5.input.required = true;
				i5.input.name = 'email';
			}, f1);
			Cayita.UI.PasswordField(null, null, function(i6) {
				i6.set_text('Password');
				i6.input.placeholder = 'your password';
				i6.input.required = true;
				i6.input.set_minLength(4);
				i6.input.name = 'password';
			}, f1);
			Cayita.UI.CheckField(null, null, function(i7) {
				i7.input.set_text('Remember');
				i7.input.checked = true;
				i7.input.name = 'remember';
				var $t1 = i7.controls;
				Cayita.UI.SubmitButton(null, function(b3) {
					b3.set_text('Login');
				}, $t1);
			}, f1);
			f1.submitHandler = function(fr) {
				Alertify.log.info($(fr).serialize(), 5000);
			};
			$(parent).append(Cayita.Fn.header('Horizontal Form', 4)).append(f1);
		});
		var login = Cayita.UI.Atom('div', null, 'span4 offset3 well');
		login.append(Cayita.UI.Atom('legend', null, null, 'Login Form'));
		Cayita.UI.Form(login, function(f2) {
			var nm = Cayita.UI.TextField(null, null, null, f2);
			nm.input.placeholder = 'user name';
			nm.input.name = 'username';
			nm.input.className = 'span12';
			nm.input.required = true;
			nm.input.set_minLength(8);
			var pwd = Cayita.UI.PasswordField(null, null, null, f2);
			pwd.input.placeholder = 'password';
			pwd.input.name = 'password';
			pwd.input.className = 'span12';
			pwd.input.required = true;
			pwd.input.set_minLength(6);
			pwd.input.maxLength = 10;
			var rmb = Cayita.UI.CheckField(null, null, null, f2);
			rmb.input.name = 'remember';
			rmb.input.set_text('Remember');
			var sb = Cayita.UI.SubmitButton(null, null, f2);
			sb.set_text('Login');
			$(sb).addClass('btn-info btn-block');
			f2.submitHandler = function(fr1) {
				sb.disabled = true;
				window.setTimeout(function() {
					sb.disabled = false;
					Alertify.log.success(Cayita.Fn.fmt('Welcome {0}', [nm.input.get_value()]), 5000);
					f2.reset();
				}, 1000);
			};
		});
		$(parent).append(Cayita.Fn.header('Samples', 3)).append(Cayita.Fn.header('Login Form', 4)).append(Cayita.UI.CreateContainer(function(ct) {
			Cayita.UI.CreateRow$1(ct, function(rw) {
				rw.append(login);
			});
		}));
		var contact = Cayita.UI.Atom('div', null, 'container');
		Cayita.UI.Form(contact, function(f3) {
			f3.className = 'well span8';
			Cayita.UI.CreateRowFluid$1(f3, function(row) {
				Cayita.UI.Atom('div', null, null, null, function(p) {
					p.className = 'span5';
					Cayita.UI.TextField(null, null, function(tf) {
						tf.input.name = 'firstname';
						tf.input.required = true;
						tf.set_text('FirstName');
						tf.input.className = 'span12';
					}, p);
					Cayita.UI.TextField(null, null, function(tf1) {
						tf1.input.name = 'lastname';
						tf1.input.required = true;
						tf1.set_text('LastName');
						tf1.input.className = 'span12';
					}, p);
					Cayita.UI.EmailField(null, null, function(tf2) {
						tf2.input.name = 'email';
						tf2.input.required = true;
						tf2.set_text('Email');
						tf2.input.className = 'span12';
					}, p);
					Cayita.UI.SelectField(String)(null, function(sf) {
						sf.set_text('Subject');
						sf.input.name = 'subject';
						sf.input.className = 'span12';
						sf.input.addValue('', 'Choose one...', false);
						sf.input.addValue('1', 'General Customer Service', false);
						sf.input.addValue('2', 'Suggestions', false);
						sf.input.addValue('3', 'Product suport', false);
						sf.input.addValue('4', 'Bug', false);
						sf.input.required = true;
					}, p);
				}, row);
				Cayita.UI.Atom('div', null, null, null, function(p1) {
					p1.className = 'span7';
					Cayita.UI.TextAreaField(null, null, function(tf3) {
						tf3.input.name = 'message';
						tf3.input.rows = 11;
						tf3.set_text('Message');
						tf3.input.className = 'span12';
					}, p1);
				}, row);
				Cayita.UI.SubmitButton(null, function(bt) {
					$(bt).addClass('btn-primary pull-right');
					bt.set_text('Send');
				}, row);
			});
			f3.submitHandler = function(fr2) {
				Cayita.AlertFn.Success(fr2.firstChild, 'Message sent', true, 5000);
			};
		});
		$(parent).append(Cayita.Fn.header('Conctact Form', 4)).append(contact);
		parent.append(Cayita.Fn.header('C# code', 3));
		var rq = $.get('code/demoform.html');
		rq.done(function(s1) {
			var code = Cayita.UI.Atom('div');
			code.innerHTML = s1;
			parent.append(code);
		});
	};
	ss.registerClass(global, 'DemoForm', $DemoForm);
})();
