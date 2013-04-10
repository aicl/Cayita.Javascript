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
		},
		$showTopNavBar: function() {
			this.set_$topNavBar(new Cayita.UI.TopNavBar.$ctor1(null, 'Cayita.Javascript - demo', '', '', function(nav) {
				Cayita.UI.Extensions.addItem$1(nav, 'Home');
				Cayita.UI.Extensions.addItem$1(nav, 'License');
				Cayita.UI.Extensions.addItem$1(nav, 'Contact');
				Cayita.UI.Extensions.addItem$1(nav, 'About');
			}));
			this.get_$topNavBar().addClass('navbar-inverse navbar-fixed-top').appendTo(document.body);
		},
		$showMenu: function() {
			Cayita.UI.Div.createContainerFluid$1(null, ss.mkdel(this, function(fluid) {
				Cayita.UI.Div.createRowFluid$1(fluid, ss.mkdel(this, function(row) {
					new Cayita.UI.Div.$ctor1(row, ss.mkdel(this, function(span) {
						span.className = 'span2';
						new Cayita.UI.SideNavBar(span, ss.mkdel(this, function(list) {
							Cayita.UI.Extensions.addHeader(list, 'Main Menu');
							Cayita.UI.Extensions.addHDivider(list);
							var $t1 = this.get_$menuItems();
							for (var $t2 = 0; $t2 < $t1.length; $t2++) {
								var item = { $: $t1[$t2] };
								Cayita.UI.Extensions.addItem(list, ss.mkdel({ item: item, $this: this }, function(li, anchor) {
									$(anchor).text(this.item.$.get_title());
									$(anchor).on('click', ss.mkdel({ item: this.item, $this: this.$this }, function(e) {
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
								}));
							}
						}));
					}));
					this.set_$work(new Cayita.UI.Div.$ctor1(row, function(work) {
						work.className = 'span10';
						work.id = 'work';
						work.appendChild(Cayita.UI.StringExtensions.header('Welcome', 3));
					}));
				}));
			})).appendTo$1(document.body);
		}
	};
	$App.main = function() {
		$(function() {
			var app = new $App();
			app.$getMenuItems();
			app.$showTopNavBar();
			app.$showMenu();
			//
			//				Bootbox.Dialog("Este es un simple menaje");
			//
			//				
			//
			//				Bootbox.Error("ha ocurrido un grave error");
			//				Bootbox.Dialog("Message Text", new DialogOptions{Header="Header Text"});
			//				
			//				Bootbox.Dialog("Message from App", opt=>{
			//				opt.Header="Your Header Text";},
			//				bt=>bt.Add(new DialogButton(){Label="Button Text", Class="btn btn-success"} ));
			//				
			//				var d = new Div(null, div=>{
			//				div.ClassName="span3";
			//				new Span(div, sp=>sp.Text("!!! span !!!"));
			//				new TextField(div, field=>{
			//				field.SetPlaceHolder("just a field");
			//				
			//				});
			//				new CheckboxField(div,"Check..", cb=>{
			//				cb.Checked=true;
			//				});
			//				new TextArea(div, area=>{
			//				area.Value="cayita is amazing,  some text ...";
			//				});
			//				new Button(div, bt=>{
			//				bt.OnClick(evt=>Bootbox.Alert("BUTTON CLICK"));
			//				bt.Text("Info Button");
			//				
			//				});
			//				});
			//				
			//				
			//				Bootbox.Dialog(d, opt=>{
			//				opt.Header="large-modal";
			//				opt.Classes="modal-large";
			//				},
			//				bt=>bt.Add(new DialogButton{Label="My super Button", Callback=()=> Bootbox.Prompt("simple prompt")} ));
			(new Cayita.UI.Panel()).render(null).onCollapseHandler(function(p, cl) {
				Alertify.log.info('previous panel state:' + (cl ? 'collapsed' : 'expanded'), 5000);
			});
			(new Cayita.UI.Panel()).caption('Panel Caption I').render(null);
			(new Cayita.UI.Panel()).caption('Panel Caption II').closable(true).render(null);
			(new Cayita.UI.Panel()).caption('Panel Caption III').closable(true).render(null);
			(new Cayita.UI.Panel()).caption('Panel Caption IV').closable(true).onCloseHandler(function(p1) {
				Alertify.log.info('Panel closed ', 5000);
			}).render(null);
			(new Cayita.UI.Panel()).caption('Panel Caption V').closeIconClass('icon-th-large').closable(true).closeIconHandler(function(p2) {
				p2.caption('* V now Overlay !');
				p2.closeIconClass('icon-remove-circle');
				p2.closeIconHandler(function(pn) {
					pn.close();
				});
				p2.width('auto');
				p2.height('400px');
				p2.left('10px');
				p2.top('100px');
				p2.overlay(true);
			}).onCloseHandler(function(p3) {
				Alertify.log.info(Cayita.UI.StringExtensions.header('panel closed ', 3).outerHTML, 5000);
			}).render(null);
			(new Cayita.UI.Panel()).caption('Overlay').left('40%').top('10%').width('auto').height('400px').overlay(true).render(null).append$4('Hello World!').append$3(Cayita.UI.StringExtensions.header('Hello World!', 3)).append$2(new Cayita.UI.Panel()).append$2((new Cayita.UI.Panel()).append$2(new Cayita.UI.Button.$ctor1(null, function(bt) {
				$(bt).text('Click me');
				bt.style.width = '100%';
				bt.style.height = '100%';
				$(bt).on('click', function(evt) {
					Alertify.log.info('button clicked!!!', 0);
				});
			})));
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
