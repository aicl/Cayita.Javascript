(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoTables
	var $DemoTables = function() {
	};
	$DemoTables.execute = function(parent) {
		var v = new ss.Task(function() {
			console.log('hello');
		});
		v.start();
		var store = new $Cayita_Demo_UserStore();
		var grid = new Cayita.Demo.UI.UserGrid(parent, store, null);
		store.read(null, true);
		var form = new Cayita.Demo.UI.UserForm(parent);
		form.buttonCreate.disabled = false;
		form.buttonCreate.add_clicked(function(e) {
			grid.clearSelection();
			form.clear();
		});
		form.buttonDestroy.add_clicked(function(e1) {
			form.clear();
			var u = Enumerable.from(store).first(function(r) {
				return r.Id === parseInt(grid.selectedRow.get_recordId());
			});
			store.remove(u);
		});
		form.add_changed(function(e2) {
			form.buttonSave.disabled = !form.hasChanges();
		});
		form.add_updated(function(fr, ac) {
			form.buttonDestroy.disabled = ac === 0;
			form.buttonSave.disabled = true;
		});
		form.submitHandler = function(fr1) {
			$DemoTables.$submitHandler(grid, form, store);
		};
		grid.add_rowSelected(function(g, row) {
			var u1 = Enumerable.from(store).first(function(r1) {
				return r1.Id === parseInt(row.get_recordId());
			});
			form.populateFrom(u1);
		});
		parent.append(Cayita.Fn.header('Paged Tables', 3));
		var cu = new $Cayita_Demo_CustomerStore();
		new Cayita.Demo.UI.CustomerGrid(parent, cu, null);
		parent.append(Cayita.UI.StorePager($Cayita_Demo_Customer)(cu));
		cu.read(null, true);
		parent.append(Cayita.Fn.header('Filters', 3));
		var cu2 = new $Cayita_Demo_CustomerStore();
		Cayita.UI.Input(String)('input', 'text', null, null, null, function(i) {
			i.placeholder = 'Country';
			i.add_handler('keyup', function(evt) {
				var st = i.get_value().toUpperCase();
				cu2.filter(function(f) {
					return ss.startsWithString(f.Country.toUpperCase(), st);
				});
			}, '', null);
		}, parent);
		new Cayita.Demo.UI.CustomerGrid(parent, cu2, null);
		parent.append(Cayita.UI.StorePager($Cayita_Demo_Customer)(cu2));
		cu2.read(null, true);
		parent.append(Cayita.Fn.header('C# code', 3));
		var rq = $.get('code/demotables.html');
		rq.done(function(s) {
			var code = Cayita.UI.Atom('div');
			code.innerHTML = s;
			parent.append(code);
		});
	};
	$DemoTables.$submitHandler = function(grid, form, store) {
		var u = form.copyToUser();
		store.save(u);
		grid.selectRow(u.Id, true);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.Customer
	var $Cayita_Demo_Customer = function() {
	};
	$Cayita_Demo_Customer.createInstance = function() {
		return $Cayita_Demo_Customer.$ctor();
	};
	$Cayita_Demo_Customer.$ctor = function() {
		var $this = new Object();
		$this.Id = null;
		$this.CompanyName = null;
		$this.ContactName = null;
		$this.Country = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.CustomerStore
	var $Cayita_Demo_CustomerStore = function() {
		ss.shallowCopy(Cayita.Data.Store($Cayita_Demo_Customer)(), this);
		this.api.url = 'json/customersResponse.json';
		this.api.readMethod = '';
		this.api.dataProperty = 'Customers';
		this.lastOption.pageNumber = 0;
		this.lastOption.pageSize = 10;
		this.lastOption.localPaging = true;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.UI
	var $Cayita_Demo_UI = function() {
	};
	$Cayita_Demo_UI.CustomerGrid = function(parent, store, columns) {
		var g = Cayita.UI.Grid($Cayita_Demo_Customer).call(null, store, columns || $Cayita_Demo_UI.get_customerDefaultColumns());
		if (ss.isValue(parent)) {
			parent.append(g);
		}
		return g;
	};
	$Cayita_Demo_UI.get_customerDefaultColumns = function() {
		var columns = [];
		var $t1 = Cayita.UI.TableColumn($Cayita_Demo_Customer)();
		var $t2 = Cayita.UI.TableCellAtom();
		$t2.set_value('Company');
		$t1.header = $t2;
		$t1.value = function(u) {
			var c = Cayita.UI.TableCellAtom();
			c.style.width = '40%';
			c.set_value(u.CompanyName);
			return c;
		};
		ss.add(columns, $t1);
		var $t3 = Cayita.UI.TableColumn($Cayita_Demo_Customer)();
		var $t4 = Cayita.UI.TableCellAtom();
		$t4.set_value('Contact');
		$t3.header = $t4;
		$t3.value = function(u1) {
			var c1 = Cayita.UI.TableCellAtom();
			c1.style.width = '40%';
			c1.set_value(u1.ContactName);
			return c1;
		};
		ss.add(columns, $t3);
		var $t5 = Cayita.UI.TableColumn($Cayita_Demo_Customer)();
		var $t6 = Cayita.UI.TableCellAtom();
		$t6.set_value('Country');
		$t5.header = $t6;
		$t5.value = function(u2) {
			var c2 = Cayita.UI.TableCellAtom();
			c2.set_value(u2.Country);
			return c2;
		};
		ss.add(columns, $t5);
		return columns;
	};
	$Cayita_Demo_UI.UserForm = function(parent) {
		var f = Cayita.UI.Form();
		f.className = 'form-horizontal';
		$(f).append('<style>.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  </style>');
		Cayita.UI.Atom('div', null, null, null, function(tb) {
			tb.className = 'nav';
			f.buttonCreate = Cayita.UI.ButtonIcon(null, function(bt) {
				bt.set_iconClass('icon-file icon-large');
				bt.disabled = true;
			}, tb);
			f.buttonSave = Cayita.UI.ButtonIcon(null, function(bt1) {
				bt1.set_iconClass('icon-save icon-large');
				bt1.disabled = true;
				bt1.type = 'submit';
			}, tb);
			f.buttonDestroy = Cayita.UI.ButtonIcon(null, function(bt2) {
				bt2.set_iconClass('icon-remove icon-large');
				bt2.disabled = true;
			}, tb);
		}, f);
		Cayita.UI.NumericInput(null, null, null, null, function(i) {
			i.name = 'Id';
			i.do_hide(true);
		}, f);
		Cayita.UI.TextField(null, null, function(i1) {
			i1.input.name = 'Name';
			i1.set_text('Name');
			i1.input.required = true;
		}, f);
		Cayita.UI.TextField(null, null, function(i2) {
			i2.input.name = 'City';
			i2.set_text('City');
			i2.input.required = true;
		}, f);
		Cayita.UI.TextField(null, null, function(i3) {
			i3.input.name = 'Address';
			i3.set_text('Address');
		}, f);
		Cayita.UI.DateField(null, null, null, function(i4) {
			i4.input.name = 'DoB';
			i4.set_text('Birthday');
			i4.get_picker().datepicker('option', 'dateFormat', 'dd.mm.yy');
			i4.input.required = true;
		}, f);
		Cayita.UI.EmailField(null, null, function(i5) {
			i5.input.name = 'Email';
			i5.set_text('Email');
			i5.input.required = true;
		}, f);
		Cayita.UI.IntField(null, null, function(i6) {
			i6.input.name = 'Rating';
			i6.set_text('Rating');
		}, f);
		Cayita.UI.RadioGroup(String)(function(rg) {
			rg.required(true);
			rg.set_text('Level');
			rg.set_name('Level');
			rg.addValue('A', null, false);
			rg.addValue('B', null, false);
			rg.addValue('C', null, false);
		}, f);
		Cayita.UI.CheckField(null, null, function(i7) {
			i7.input.name = 'IsActive';
			i7.input.set_text('Is active?');
		}, f);
		$(f).find('label[class=\'control-label\']').css('width', '80px');
		f.copyToUser = function() {
			var u = $Cayita_Demo_User.$ctor();
			f.populate(u);
			return u;
		};
		parent.append(f);
		return f;
	};
	$Cayita_Demo_UI.UserGrid = function(parent, store, columns) {
		var g = Cayita.UI.Grid($Cayita_Demo_User)(store, columns || $Cayita_Demo_UI.get_userDefaultColumns());
		parent.append(g);
		return g;
	};
	$Cayita_Demo_UI.get_userDefaultColumns = function() {
		var columns = [];
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('Name', 'Name', function(u, c) {
			c.set_value(u.Name);
		}, true));
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('City', 'City', function(u1, c1) {
			c1.set_value(u1.City);
		}, true));
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('Address', 'Address', function(u2, c2) {
			c2.set_value(u2.Address);
		}, true));
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('Birthday', 'Birthday', function(u3, c3) {
			c3.set_value(ss.formatDate(u3.DoB, 'dd.MM.yyyy'));
		}, true));
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('Email', 'Email', function(u4, c4) {
			c4.set_value(u4.Email);
		}, true));
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('Rating', 'Rating', function(u5, c5) {
			c5.set_value(u5.Rating);
			var $t1 = Cayita.Plugins.NumericOptions();
			$t1.mDec = 0;
			Cayita.Plugins.AutoNumeric(c5, $t1);
			c5.style.textAlign = 'center';
		}, true));
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_User)('Level', 'Level', function(u6, c6) {
			c6.set_value(u6.Level);
			c6.style.color = ((u6.Level === 'A') ? 'green' : ((u6.Level === 'B') ? 'orange' : 'red'));
			c6.style.textAlign = 'center';
		}, true));
		var $t2 = Cayita.UI.TableColumn($Cayita_Demo_User)();
		var $t3 = Cayita.UI.TableCellAtom();
		$t3.set_value('Active?');
		$t2.header = $t3;
		$t2.value = function(u7) {
			var c7 = Cayita.UI.TableCellAtom();
			c7.style.textAlign = 'center';
			c7.append(Cayita.UI.Atom('i', null, (u7.IsActive ? 'icon-ok-circle' : 'icon-ban-circle')));
			return c7;
		};
		$t2.afterCellCreated = function(f, row) {
			row.style.color = (f.IsActive ? 'black' : 'grey');
			$(row).addClass(((f.Rating >= 10000) ? 'success' : ((f.Rating <= 5000) ? 'warning' : '')));
		};
		ss.add(columns, $t2);
		return columns;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.User
	var $Cayita_Demo_User = function() {
	};
	$Cayita_Demo_User.createInstance = function() {
		return $Cayita_Demo_User.$ctor();
	};
	$Cayita_Demo_User.$ctor = function() {
		var $this = new Object();
		$this.Id = 0;
		$this.Name = null;
		$this.Address = null;
		$this.City = null;
		$this.Email = null;
		$this.DoB = new Date(0);
		$this.IsActive = false;
		$this.Level = null;
		$this.UserName = null;
		$this.Password = null;
		$this.Rating = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.UserStore
	var $Cayita_Demo_UserStore = function() {
		ss.shallowCopy(Cayita.Data.Store($Cayita_Demo_User)(), this);
		this.api.url = 'json/userResponse.json';
		this.api.readMethod = '';
		this.api.converters['DoB'] = function(u) {
			return Cayita.Fn.normalize(u.DoB);
		};
	};
	$Cayita_Demo_UserStore.prototype = {
		save: function(u) {
			if (u.Id === 0) {
				u.Id = --$Cayita_Demo_UserStore.$id;
				this.add(u);
			}
			else {
				this.replace(u);
			}
		}
	};
	ss.registerClass(global, 'DemoTables', $DemoTables);
	ss.registerClass(global, 'Cayita.Demo.Customer', $Cayita_Demo_Customer, Object);
	ss.registerClass(global, 'Cayita.Demo.CustomerStore', $Cayita_Demo_CustomerStore, Object, [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList]);
	ss.registerClass(global, 'Cayita.Demo.UI', $Cayita_Demo_UI);
	ss.registerClass(global, 'Cayita.Demo.User', $Cayita_Demo_User, Object);
	ss.registerClass(global, 'Cayita.Demo.UserStore', $Cayita_Demo_UserStore, Object, [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList]);
	$Cayita_Demo_UserStore.$id = 0;
})();
