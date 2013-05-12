(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.ModuloAuth.App
	var $App = function() {
		this.$1$TopNavBarField = null;
		this.$1$WorkField = null;
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
		$onLogin: function(loginResponse, lf) {
			console.log('App.OnLogin ', loginResponse);
			var a = this.get_$topNavBar().pullRightAnchor();
			Extensions.text$1(a, lf.get_userName());
			Extensions.text$1(this.get_$topNavBar().pullRightParagraph(), '');
			$(this.get_$topNavBar().pullRightParagraph()).append(a);
			lf.close();
			this.$showUserMenu(loginResponse);
		},
		$showTopNavBar: function() {
			this.set_$topNavBar(new Cayita.UI.NavBar.$ctor1(null, 'Cayita.Javascript - demo', 'No logged', '', function(navlist) {
			}));
			document.body.appendChild(this.get_$topNavBar().element$1());
		},
		$showUserMenu: function(lr) {
			var um = Cayita.UI.Div.createContainerFluid$1(null, ss.mkdel(this, function(fluid) {
				Cayita.UI.Div.createRowFluid$1(fluid, ss.mkdel(this, function(row) {
					new Cayita.UI.Div.$ctor2(row, ss.mkdel(this, function(span) {
						span.className = 'span2';
						new Cayita.UI.Div.$ctor2(span, ss.mkdel(this, function(nav) {
							nav.className = 'well sidebar-nav';
							Cayita.UI.HtmlList.createNav$1(nav, ss.mkdel(this, function(list) {
								Extensions.addHeader(list, 'Menu');
								for (var $t1 = 0; $t1 < lr.Roles.length; $t1++) {
									var role = { $: lr.Roles[$t1] };
									Extensions.addItem$1(list, ss.mkdel({ role: role, $this: this }, function(li, anchor) {
										Extensions.text$1(anchor, this.role.$.Title);
										$(anchor).click(ss.mkdel({ role: this.role, $this: this.$this }, function(e) {
											e.preventDefault();
											this.$this.get_$work().empty();
											$.getScript(this.role.$.Directory + '.js', ss.mkdel(this.$this, function(o) {
												MainModule.execute(this.get_$work().element$1());
											}));
										}));
									}));
								}
								Extensions.addItem$1(list, ss.mkdel(this, function(li1, anchor1) {
									Extensions.text$1(anchor1, 'Close Session');
									$(anchor1).click(ss.mkdel(this, function(e1) {
										e1.preventDefault();
										$(document.body).empty();
										$.post('api/Logout', {}, function(cb) {
											console.log('callback', cb);
										}, 'json').success(function(d) {
										}).error(function(request, textStatus, error) {
											console.log('request', request);
											//Div.CreateAlertErrorBefore(Document.Body,
											//                           textStatus+": "+ request.StatusText);
										}).always(ss.mkdel(this, function(a) {
											this.$showTopNavBar();
											this.$showLoginForm();
										}));
									}));
								}));
							}), 'nav-list');
						}));
					}));
					this.set_$work(new Cayita.UI.Div.$ctor2(row, function(work) {
						work.className = 'span10';
						work.id = 'work';
						var m = document.createElement('h3');
						Extensions.text$1(m, 'Welcome');
						work.appendChild(m);
					}));
				}));
			}));
			um.appendTo$2(document.body);
		},
		$showLoginForm: function() {
			var form = new $LoginForm(document.body);
			form.set_onLogin(ss.mkdel(this, this.$onLogin));
			form.show();
		}
	};
	$App.main = function() {
		$(function() {
			var app = new $App();
			app.$showTopNavBar();
			app.$showLoginForm();
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.ModuloAuth.LoginForm
	var $LoginForm = function(parent) {
		this.$1$UserNameField = null;
		this.$1$ParentField = null;
		this.$1$OnLoginField = null;
		this.$1$ContainerField = null;
		this.set_parent(parent);
	};
	$LoginForm.prototype = {
		get_userName: function() {
			return this.$1$UserNameField;
		},
		set_userName: function(value) {
			this.$1$UserNameField = value;
		},
		get_parent: function() {
			return this.$1$ParentField;
		},
		set_parent: function(value) {
			this.$1$ParentField = value;
		},
		get_onLogin: function() {
			return this.$1$OnLoginField;
		},
		set_onLogin: function(value) {
			this.$1$OnLoginField = value;
		},
		get_$container: function() {
			return this.$1$ContainerField;
		},
		set_$container: function(value) {
			this.$1$ContainerField = value;
		},
		close: function() {
			this.get_$container().jQuery().remove();
		},
		show: function() {
			this.set_$container(Cayita.UI.Div.createContainer$1(null, ss.mkdel(this, function(container) {
				Cayita.UI.Div.createRow$1(container, ss.mkdel(this, function(row) {
					//
					new Cayita.UI.Div.$ctor2(row, ss.mkdel(this, function(element) {
						element.className = 'span4 offset4 well';
						new Cayita.UI.Legend.$ctor1(element, function(l) {
							Extensions.text$1(l, 'Login Form');
						});
						new Cayita.UI.Form.$ctor1(element, ss.mkdel(this, function(fe) {
							fe.action = 'json/loginResponse.json';
							fe.method = 'get';
							var cg = Cayita.UI.Div.createControlGroup(fe);
							var user = new Cayita.UI.InputText.$ctor1(cg.element$1(), function(pe) {
								//pe.SetAttribute("data-provide","typeahead");
								pe.className = 'span4';
								$(pe).attr('placeholder', 'your username');
								pe.name = 'UserName';
							});
							cg = Cayita.UI.Div.createControlGroup(fe);
							var pass = new Cayita.UI.InputPassword.$ctor1(cg.element$1(), function(pe1) {
								pe1.className = 'span4';
								$(pe1).attr('placeholder', 'your password');
								pe1.name = 'Password';
							});
							var bt = new Cayita.UI.SubmitButton.$ctor1(fe, function(b) {
								$(b).text('Login');
								$(b).addClass('btn-info btn-block');
								$(b).button.defaults.loadingText = '  authenticating ...';
							});
							var vo = Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.setSubmitHandler(Cayita.Plugins.ValidateOptions.$ctor(), ss.mkdel(this, function(f) {
								bt.showLoadingText();
								$.get(f.action, cayita.fn.serialize(f), function(cb) {
									console.log('callback', cb);
								}, 'json').success(ss.mkdel(this, function(d) {
									this.set_userName(user.element$2().value);
									if (!ss.staticEquals(this.get_onLogin(), null)) {
										this.get_onLogin()(d, this);
									}
								})).error(function(request, textStatus, error) {
									Cayita.UI.Alert.error$1(fe.firstChild, textStatus + ': ' + (ss.startsWithString(request.statusText, 'ValidationException') ? 'Usario/clave no validos' : request.statusText), true);
								}).always(function(a) {
									bt.resetLoadingText();
								});
							})), function(rule, msg) {
								rule.element = pass.element$2();
								Cayita.Plugins.Rule.required(Cayita.Plugins.Rule.minlength(rule.rule, 2));
								Cayita.Plugins.Message.required(Cayita.Plugins.Message.minlength(msg, 'mini 2 chars'), 'your password !');
							}), function(rule1, msg1) {
								rule1.element = user.element$2();
								Cayita.Plugins.Rule.minlength(Cayita.Plugins.Rule.required(rule1.rule), 2);
								Cayita.Plugins.Message.minlength(msg1, 'min 2 chars');
							});
							$(fe).validate(vo);
						}));
					}));
				}));
			})));
			this.get_parent().appendChild(this.get_$container().element$1());
		}
	};
	ss.registerClass(global, 'App', $App);
	ss.registerClass(global, 'LoginForm', $LoginForm);
})();
