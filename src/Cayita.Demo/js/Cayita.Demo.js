(function() {
	'use strict';
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.App
	var $App = function() {
		this.$1$TopNavBarField = null;
		this.$1$MenuItemsField = null;
		this.$1$WorkField = null;
		this.$modules = [];
	};
	$App.__typeName = 'App';
	$App.main = function() {
		$(function() {
			var app = new $App();
			app.$showTopNavBar();
			app.$buildMenuItems();
			app.$showMenu();
			app.$goHome();
		});
	};
	global.App = $App;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.MenuItem
	var $MenuItem = function() {
		this.$1$ClassField = null;
		this.$1$TitleField = null;
		this.$1$FileField = null;
	};
	$MenuItem.__typeName = 'MenuItem';
	global.MenuItem = $MenuItem;
	ss.initClass($App, {
		get_$topNavBar: function() {
			return this.$1$TopNavBarField;
		},
		set_$topNavBar: function(value) {
			this.$1$TopNavBarField = value;
		},
		get_$menuItems: function() {
			return this.$1$MenuItemsField;
		},
		set_$menuItems: function(value) {
			this.$1$MenuItemsField = value;
		},
		get_$work: function() {
			return this.$1$WorkField;
		},
		set_$work: function(value) {
			this.$1$WorkField = value;
		},
		$buildMenuItems: function() {
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
			var $t20 = this.get_$menuItems();
			var $t19 = new $MenuItem();
			$t19.set_title('Mix');
			$t19.set_file('modules/DemoMix.js');
			$t19.set_class('DemoMix');
			ss.add($t20, $t19);
		},
		$showMenu: function() {
			Cayita.UI.CreateContainerFluid(ss.mkdel(this, function(fluid) {
				Cayita.UI.CreateRowFluid$1(fluid, ss.mkdel(this, function(row) {
					Cayita.UI.Atom('div', null, null, null, ss.mkdel(this, function(span) {
						span.className = 'span2';
						var navlist = Cayita.UI.NavList(span);
						navlist.nav.set_header('Main Menu');
						navlist.nav.addDivider('divider');
						var $t1 = this.get_$menuItems();
						for (var $t2 = 0; $t2 < $t1.length; $t2++) {
							var item = { $: $t1[$t2] };
							navlist.nav.addValue(item.$.get_title(), null, ss.mkdel({ item: item, $this: this }, function(e) {
								e.preventDefault();
								$(this.$this.get_$work()).empty();
								if (ss.contains(this.$this.$modules, this.item.$.get_class())) {
									var $t3 = this.$this;
									var $t4 = this.$this.get_$work();
									window[this.item.$.get_class()]['execute']($t4);
								}
								else {
									$.getScript(this.item.$.get_file(), ss.mkdel({ item: this.item, $this: this.$this }, function(o) {
										ss.add(this.$this.$modules, this.item.$.get_class());
										var $t5 = this.$this;
										var $t6 = this.$this.get_$work();
										window[this.item.$.get_class()]['execute']($t6);
									}));
								}
							}), false, null);
						}
					}), row);
					this.set_$work(Cayita.UI.Atom('div', null, null, null, function(w) {
						w.id = 'work';
						w.className = 'span10';
						w.append(Cayita.Fn.header('Welcome', 3));
					}, row));
				}));
				document.body.appendChild(fluid);
			}));
		},
		$showTopNavBar: function() {
			this.set_$topNavBar(Cayita.UI.NavBar());
			this.get_$topNavBar().nav.set_brandText('Cayita Demo');
			this.get_$topNavBar().nav.addValue('Home', null, ss.mkdel(this, this.$goHomeClick), false, null);
			this.get_$topNavBar().nav.addValue('License', null, ss.mkdel(this, this.$goLicense), false, null);
			this.get_$topNavBar().nav.addValue('Contact', null, ss.mkdel(this, this.$goContact), false, null);
			this.get_$topNavBar().nav.addValue('About', null, ss.mkdel(this, this.$goAbout), false, null);
			this.get_$topNavBar().nav.inverse(true);
			$(this.get_$topNavBar()).addClass('navbar-fixed-top');
			document.body.appendChild(this.get_$topNavBar());
		},
		$goHomeClick: function(evt) {
			evt.preventDefault();
			this.$goHome();
		},
		$goHome: function() {
			$(this.get_$work()).empty();
			var rq = $.get('code/demohome.html');
			rq.done(ss.mkdel(this, function(s) {
				this.get_$work().innerHTML = s;
			}));
		},
		$goLicense: function(evt) {
			evt.preventDefault();
			$(this.get_$work()).empty();
			$(this.get_$work()).append('<div class="well">\n\t\t\t             <p>Copyright AICL.</p>\n\t\t\t             <p>Licensed under the Apache License, Version 2.0 (the "License"); you may not use this work except in compliance with the License. You may obtain a copy of the License in the LICENSE file, or at:</p><p><a target="_blank" href="http://www.apache.org/licenses/LICENSE-2.0">http://www.apache.org/licenses/LICENSE-2.0</a></p><p>Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.</p></div>');
		},
		$goContact: function(evt) {
			evt.preventDefault();
			$(this.get_$work()).empty();
			$(this.get_$work()).append('<div class="well">\n\t<p><a target="_blank" href="https://github.com/angelcolmenares">https://github.com/angelcolmenares</a>\n\t<p><a target="_blank" href="https://github.com/aicl">https://github.com/aicl</a>\n\t</p></div>');
		},
		$goAbout: function(evt) {
			evt.preventDefault();
			$(this.get_$work()).empty();
			$(this.get_$work()).append('<div class="well">\n<p>Cayita is a library for building responsive webapps using C#  as base language and the Saltarelle compiler \n<a href="http://www.saltarelle-compiler.com" target="_blank">\nhttp://www.saltarelle-compiler.com\n</a>\n</p>\n</p></div>');
		}
	});
	ss.initClass($MenuItem, {
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
	});
})();
