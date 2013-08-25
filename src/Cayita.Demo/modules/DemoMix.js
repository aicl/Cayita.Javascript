(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoMix
	var $DemoMix = function() {
	};
	$DemoMix.execute = function(parent) {
		var store = Cayita.Data.Store($Cayita_Demo_MyRecord)();
		store.lastOption.localPaging = true;
		console.log('store', store);
		store.add($Cayita_Demo_MyRecord.Person('Angel Ignacio', 'Colmenares', 47));
		store.add($Cayita_Demo_MyRecord.Person('Claudia', 'Espinel', 44));
		store.add($Cayita_Demo_MyRecord.Person('Billy', 'Espinel', 3));
		var $t1 = store.getEnumerator();
		try {
			while ($t1.moveNext()) {
				var r = $t1.current();
				console.log('record', r.Name);
			}
		}
		finally {
			$t1.dispose();
		}
		console.log('id ', store.get_idProperty());
		console.log('id ', store.get_count());
		console.log('id ', store.get_item(0).Age);
		var api = Cayita.Data.StoreApi($Cayita_Demo_MyRecord)();
		console.log('st.ReadApi', api.get_readApi());
		api.readMethod = 'LEER';
		console.log('st.ReadApi', api.get_readApi());
		api.readMethod = '';
		console.log('st.ReadApi', api.get_readApi());
		api.url = '';
		console.log('st.ReadApi', api.get_readApi());
		api.readMethod = 'LEER';
		console.log('st.ReadApi', api.get_readApi());
		api.set_createApiFn(function() {
			return 'Esta es mi createApiFn';
		});
		console.log('st.CreateApi', api.get_createApi());
		var work = $('#work').empty();
		var countryStore1 = new $Cayita_Demo_MyCountryStore(null);
		var config1 = new $Cayita_Demo_MyCountrySearchBoxConfig();
		var sb1 = Cayita.UI.SearchBox($Cayita_Demo_MyCountry)(countryStore1, $Cayita_Demo_MyCountryStore.defineColumnsWithFlags(), config1);
		sb1.localFilter = function(rec, v) {
			return ss.startsWithString(rec.Name.toUpperCase(), v.toUpperCase());
		};
		work.append(sb1);
		sb1.add_rowSelected(function(sb, sr) {
			if (ss.isValue(sr)) {
				Alertify.log.info(Cayita.Fn.fmt('selected: {0}-{1} ', [sb.indexValue, sb.textValue]), 5000);
			}
			else {
				Alertify.log.info('nothing selected', 5000);
			}
		});
		countryStore1.read(null, true);
		var countryRemote = new $Cayita_Demo_MyCountryStore(function(o) {
			o.localPaging = false;
			o.pageNumber = null;
			o.pageSize = null;
		});
		var sb2 = Cayita.UI.SearchBox($Cayita_Demo_MyCountry)(countryRemote, $Cayita_Demo_MyCountryStore.defineColumnsWithFlags(), config1);
		work.append(sb2);
		var sp = Cayita.UI.StorePager($Cayita_Demo_MyRecord)(store);
		console.log('--------Test sp.Update: ', store.get_totalCount(), store.get_count());
		sp.update();
		work.append(sp);
		var bi = Cayita.UI.ButtonIcon('iconic-home');
		$(bi).addClass('button-large');
		work.append(bi);
		var x = $Cayita_Demo_MyRecord.Person('NoName', 'NoFirst', 0);
		var t = Cayita.UI.Table($Cayita_Demo_MyRecord)();
		t.addRow(x);
		console.log(t);
		work.append(t);
		var grid = Cayita.UI.Grid($Cayita_Demo_MyRecord)(store, null);
		grid.add_rowClicked(function(st, r1) {
			console.log('handler1', r1);
		});
		grid.add_rowClicked(function(st1, r2) {
			console.log('handler2', r2);
		});
		grid.add_keydown(function(st2, k) {
			console.log('keydonw', k);
		});
		work.append(grid);
		var b1 = Cayita.UI.Button('Bootbox.Alert', 'btn', null);
		b1.add_clicked(function(e) {
			bootbox.alert('Mi primer mensage', function() {
				window.alert('alert callback');
			});
		});
		work.append(b1);
		var b2 = Cayita.UI.Button('Bootbox.Confirm', 'btn', null);
		b2.add_clicked(function(e1) {
			bootbox.confirm('Mi primer Confirm', function(c) {
				window.alert('confirm callback ' + c);
			});
		});
		work.append(b2);
		var b3 = Cayita.UI.Button('Bootbox.Prompt', 'btn', null);
		b3.add_clicked(function(e2) {
			bootbox.prompt('Mi primer Prompt', function(s) {
				window.alert('prompt callback ' + s);
			});
		});
		work.append(b3);
		var b4 = Cayita.UI.Button('Bootbox.Dialog I', 'btn', null);
		b4.add_clicked(function(e3) {
			Cayita.Plugins.showBootboxDialog('Mi Dialog I', null, null);
		});
		work.append(b4);
		var b5 = Cayita.UI.Button('Bootbox.Dialog II', 'btn', null);
		b5.add_clicked(function(e4) {
			var $t2 = {};
			$t2.callback = function() {
				window.alert('Dialog callback');
			};
			$t2.label = 'My custom Label';
			Cayita.Plugins.showBootboxDialog('Mi Dialog II', $t2, null);
		});
		work.append(b5);
		var b6 = Cayita.UI.Button('Bootbox.Dialog III', 'btn', null);
		b6.add_clicked(function(e5) {
			var $t3 = {};
			$t3.callback = function() {
				window.alert('Dialog callback');
			};
			$t3.label = 'Go';
			var $t4 = Cayita.Plugins.BootboxOptions();
			$t4.header = 'El titulo grande';
			Cayita.Plugins.showBootboxDialog('Mi Dialog III', $t3, $t4);
		});
		work.append(b6);
		var form = Cayita.UI.Form();
		var $t5 = Cayita.UI.TextField();
		$t5.input.name = 'Name';
		$t5.label.set_text('Nombre');
		form.append($t5);
		var $t6 = Cayita.UI.TextField();
		$t6.input.name = 'First';
		$t6.label.set_text('Apellido');
		form.append($t6);
		var $t7 = Cayita.UI.IntField();
		$t7.input.name = 'Age';
		$t7.label.set_text('Edad');
		form.append($t7);
		var $t8 = Cayita.UI.NumericField();
		$t8.input.name = 'Average';
		$t8.label.set_text('Promedio');
		form.append($t8);
		var lang = Cayita.UI.RadioGroup(String)();
		lang.set_name('FavouriteLanguage');
		lang.set_text('Programming Language');
		lang.addValue('Java', 'Java 6', false);
		lang.addValue('Basic', 'Basic', false);
		lang.addValue('CSharp', 'C #', false);
		lang.addValue('Fortran', 'FORTRAN', false);
		form.append(lang);
		var $t9 = Cayita.UI.CheckField();
		$t9.set_text('Active?');
		$t9.input.name = 'Active';
		form.append($t9);
		var opt1 = Cayita.UI.CheckGroup(ss.Int32)();
		opt1.set_name('Ids');
		opt1.addValue(1, 'Opcion 1', false);
		opt1.addValue(2, 'Opcion 2', false);
		opt1.addValue(3, 'Opcion 3', false);
		opt1.addValue(4, 'Opcion 4', false);
		opt1.addValue(5, 'Opcion 5', false);
		opt1.addValue(6, 'Opcion 6', false);
		form.append(opt1);
		var opt2 = Cayita.UI.SelectInput(ss.Int32)();
		opt2.name = 'Selection';
		opt2.addValue(1, 'Opcion 1', false);
		opt2.addValue(2, 'Opcion 2', false);
		opt2.addValue(3, 'Opcion 3', false);
		opt2.addValue(4, 'Opcion 4', false);
		opt2.addValue(5, 'Opcion 5', false);
		opt2.addValue(6, 'Opcion 6', false);
		form.append(opt2);
		var sel1 = Cayita.UI.SelectInput(ss.Int32)();
		sel1.name = 'MultipleSelection';
		sel1.multiple = true;
		sel1.addValue(1, 'Opcion 1', false);
		sel1.addValue(2, 'Opcion 2', false);
		sel1.addValue(3, 'Opcion 3', false);
		sel1.addValue(4, 'Opcion 4', false);
		sel1.addValue(5, 'Opcion 5', false);
		sel1.addValue(6, 'Opcion 6', false);
		form.append(sel1);
		var dob = Cayita.UI.DateInput();
		dob.name = 'DoB';
		form.append(dob);
		var ll = Cayita.UI.DateInput();
		ll.name = 'LastLog';
		form.append(ll);
		var mr = $Cayita_Demo_MyRecord.Person('NoName', 'NoFirst', 0);
		form.populateFrom(mr);
		work.append(form);
		var pb = Cayita.UI.Button('Click me !', 'btn', null);
		pb.add_clicked(function(e6) {
			form.populate(mr);
			console.log('datos ', mr);
			Cayita.AlertFn.Info(form, 'algun mensaje', false, 5000);
			Cayita.AlertFn.PageAlert(form, 'Page alert', 'success', 15000);
		});
		work.append(pb);
		//
		var nl = Cayita.UI.NavList(null);
		nl.nav.set_header('Soy un Nav List');
		nl.nav.addValue('1', 'Primer item', null, false, null);
		nl.nav.addValue('2', 'Segundo item', function(e7) {
			console.log('click', e7);
		}, false, 'icon-envelope');
		var $t10 = Cayita.UI.NavItem();
		$t10.set_value('3');
		$t10.set_text('Tercer Item');
		$t10.handler = function(e8) {
			nl.nav.set_header('Soy un NaList click 3');
		};
		$t10.set_iconClass('iconic-home');
		nl.nav.addItem($t10);
		nl.nav.addValue('4', 'Cuarto Item', function(e9) {
			console.log('click 4', e9);
			nl.nav.set_header(e9.currentTarget.get_value() + e9.currentTarget.get_text());
		}, false, null);
		nl.nav.addValue('5', 'Quinto Item', function(e10) {
			console.log('click 5', e10);
			nl.nav.disableItem('2', true);
		}, false, null);
		work.append(nl);
		nl.nav.add_selected(function(e11) {
			console.log('nl algun item ha sido seleccionado', e11.currentTarget);
		});
		var nb = Cayita.UI.NavBar();
		var i = 0;
		nb.nav.addValue('1', 'Nav bar 1', function(e12) {
			console.log('Nav bar clicked', e12);
			nb.nav.set_brandText('Hello Brand ' + (++i).toString());
			if (i === 1) {
				nb.nav.add_brandClicked(function(ev) {
					console.log('Brand Clicked ev', ev);
				});
			}
		}, false, null);
		nb.nav.addValue('2', 'Toggle Inverse', function(e13) {
			nb.nav.inverse(!nb.nav.is_inverse());
		}, false, null);
		var dd = Cayita.UI.DropdownMenu();
		dd.set_text('Dropdown..');
		dd.nav.addValue('Item 1 in dd', null, null, null);
		dd.nav.addValue('Item 2 in dd', null, null, null);
		var sm = Cayita.UI.DropdownSubmenu();
		sm.set_text('Sub Menu');
		sm.nav.addValue(' 1 en submenu', null, null, null);
		sm.nav.addValue(' 2 en submenu', null, null, null);
		dd.nav.addDropdownSubmenu(sm);
		nb.nav.addDropdownMenu(dd);
		var f = Cayita.UI.Form();
		f.className = 'navbar-search';
		var tib = Cayita.UI.Input(String)('input', 'text');
		tib.className = 'navbar-query';
		f.append(tib);
		nb.collapse.addElement(f);
		work.append(nb);
		nb.nav.add_brandClicked(function(e14) {
			console.log('Brand Clicked si se vera!!', e14);
		});
		nb.nav.add_selected(function(e15) {
			console.log('Algun item del navbar', e15);
		});
		var nd = new Date();
		console.log('net date', nd);
		var jd = new Date();
		console.log('js date', jd);
		var ff = Cayita.UI.FileField();
		work.append(ff);
		var ifile = Cayita.UI.ImgField();
		var $t12 = ifile.thumbnail;
		var $t11 = Cayita.Plugins.PopoverOptions();
		$t11.content = 'hello popover ';
		$t11.title = 'my Title';
		$t11.placement = 'top';
		Cayita.Plugins.popover($t12, $t11);
		work.append(ifile);
		var tf = Cayita.UI.TextField('TEXTField', null);
		tf.set_text('My label');
		work.append(tf);
		var di = Cayita.UI.DateInput();
		di.set_value(new Date());
		work.append(di);
		var df = Cayita.UI.DateField({ dateFormat: 'dd.mm.yy' }, null, null);
		work.append(df);
		var nf = Cayita.UI.NumericField('NumericField', 'digite su edad');
		nf.input.set_value(12);
		work.append(nf);
		var cbf = Cayita.UI.CheckField('MyName', 'Accept ?');
		work.append(cbf);
		var mf = Cayita.UI.TextField();
		mf.prependAddon(Cayita.UI.Atom('i', null, 'icon-envelope'));
		var $t13 = Cayita.UI.Button();
		$t13.set_text('Hello world');
		mf.appendAddon($t13);
		work.append(mf);
		var cbg = Cayita.UI.CheckGroup(ss.Int32)();
		var $t14 = Cayita.UI.CheckOption(ss.Int32)();
		$t14.input.set_value(1);
		$t14.set_text('Opcion 1');
		cbg.addOption($t14);
		var $t15 = Cayita.UI.CheckOption(ss.Int32)();
		$t15.input.set_value(2);
		$t15.set_text('Opcion 2');
		cbg.addOption($t15);
		cbg.addOption(Cayita.UI.CheckOption(ss.Int32)(3, 'Opcion 2', true));
		cbg.addValue(4, 'Opcion4', false);
		cbg.addValue(5, null, true);
		cbg.addValue(6, null, false);
		work.append(cbg);
		var rdg = Cayita.UI.RadioGroup(ss.Int32)();
		rdg.set_name('MyRadio');
		var $t16 = Cayita.UI.RadioOption(ss.Int32)();
		$t16.input.set_value(1);
		$t16.set_text('Opcion 1');
		rdg.addOption($t16);
		var $t17 = Cayita.UI.RadioOption(ss.Int32)();
		$t17.input.set_value(2);
		$t17.set_text('Opcion 2');
		rdg.addOption($t17);
		rdg.addOption(Cayita.UI.RadioOption(ss.Int32)(3, 'Opcion 3', false));
		rdg.addValue(4, 'Radio 4', false);
		rdg.addValue(5, null, false);
		rdg.addValue(6, null, true);
		work.append(rdg);
		var cbg1 = Cayita.UI.CheckGroup(ss.Int32)();
		var $t18 = Cayita.UI.CheckOption(ss.Int32)();
		$t18.input.set_value(1);
		$t18.set_text('Opcion 1');
		cbg1.addOption($t18);
		var $t19 = Cayita.UI.CheckOption(ss.Int32)();
		$t19.input.set_value(2);
		$t19.set_text('Opcion 2');
		cbg1.addOption($t19);
		cbg1.addOption(Cayita.UI.CheckOption(ss.Int32)(3, 'Opcion 2', true));
		cbg1.addValue(4, 'Opcion4', false);
		cbg1.addValue(5, null, true);
		cbg1.addValue(6, null, false);
		cbg1.add_checked(function(e16) {
			var g = e16.currentTarget;
			cbg.checkValue(g.input.get_value(), g.input.checked);
			rdg.checkValue(g.input.get_value(), g.input.checked);
		});
		work.append(cbg1);
		cbg1.add_handler('check', function(e17) {
			console.log('otro cambio', e17);
		}, Cayita.UI.OptionSelector, null);
		var options = ['Uno', 'Dos', 'Tres'];
		var cbg2 = Cayita.UI.CheckGroup(String)();
		cbg2.loadList(options, false);
		work.append(cbg2);
		var si = Cayita.UI.SelectInput(ss.Int32)();
		si.addOption(function(o1) {
			o1.set_text('Opcion 1');
			o1.set_value(1);
		});
		si.addOption(function(o2) {
			o2.set_text('Opcion 2');
			o2.set_value(2);
		});
		si.addOption(function(o3) {
			o3.set_text('Opcion 3');
			o3.set_value(3);
		});
		si.addOption(function(o4) {
			o4.set_text('Opcion 4');
			o4.set_value(4);
		});
		si.add_changed(function(e18) {
			var s1 = e18.currentTarget;
			console.log('select change..', s1.get_value(), s1.get_selectedOption());
		});
		work.append(si);
		var s2 = Cayita.UI.SelectInput(String)();
		s2.multiple = true;
		s2.addValue('La Primera', null, false);
		s2.addValue('La Segunda', null, false);
		s2.addValue('La Tercera', null, false);
		s2.addValue('La IV', null, false);
		s2.addValue('La V', null, false);
		s2.addValue('Todas', null, false);
		s2.add_clicked(function(e19) {
			var s3 = e19.currentTarget;
			console.log('select change..', s3.get_value(), s3.get_selected());
		});
		work.append(s2);
		var cb1 = Cayita.UI.BooleanCheck();
		work.append(cb1);
		var r11 = Cayita.UI.BooleanRadioInput();
		work.append(r11);
		cb1.add_changed(function(e20) {
			var c1 = e20.target;
			r11.checked = !c1.checked;
		});
		var a = Cayita.UI.Atom('label', null, null);
		a.set_text('Hello World');
		work.append(a);
		console.log(a);
		console.log(a.get_text());
		var b = Cayita.UI.Atom('label', null, null);
		b.set_getTextFn(function(e21, v1) {
			e21.innerHTML = v1;
		});
		b.set_setTextFn(function(e22) {
			return e22.innerHTML;
		});
		b.set_text('Hola Mundo !!!');
		work.append(b);
		console.log('b', b);
		console.log('b.Text', b.get_text());
		var label = Cayita.UI.Label();
		label.innerHTML = 'HOla soy un label';
		label.set_text('Soy el Text de este label');
		label.set_for('SomeField');
		work.append(label);
		var cg1 = Cayita.UI.ControlGroup();
		cg1.label.set_text('Soy un Control group');
		cg1.label.style.cssText = 'color:red;';
		cg1.style.backgroundColor = 'blue';
		cg1.label.set_for('ElIdDeAlgunInput');
		work.append(cg1);
		console.log(cg1);
		console.log(cg1.label);
		console.log(cg1.controls);
		var anchor1 = Cayita.UI.Anchor(null, '#');
		anchor1.set_text('anchor1');
		work.append(anchor1);
		console.log(anchor1);
		var anchor2 = Cayita.UI.Anchor('link', '#', null);
		anchor2.set_text('anchor2');
		work.append(anchor2);
		console.log(anchor2);
		var anchor3 = Cayita.UI.Anchor('link', '#work', null);
		anchor3.set_text('anchor3');
		work.append(anchor3);
		console.log(anchor3);
		var anchor4 = Cayita.UI.Anchor('link', '#', null);
		anchor4.href = '#work';
		anchor4.set_text('anchor4');
		work.append(anchor4);
		console.log(anchor4);
		var ni = Cayita.UI.Input(String)('input', 'text');
		ni.set_value('12');
		work.append(ni);
		console.log('int input', ni, ni.get_value());
		var nni = Cayita.UI.NullableNumericInput();
		nni.set_value(12);
		nni.autoNumeric.getSettings().vMax = 100;
		nni.autoNumeric.getSettings().vMin = 0;
		work.append(nni);
		var numeric = Cayita.UI.NumericInput();
		work.append(numeric);
		console.log('numeric settings', numeric.autoNumeric.getSettings());
		anchor4.add_clicked(function(e23) {
			e23.preventDefault();
			console.log('anchor 4 clicked', e23.target);
			nni.set_value(20);
		});
		numeric.add_changed(function(e24) {
			console.log('numeric changed', e24.target, e24.target.get_value());
			;
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.MyCountry
	var $Cayita_Demo_MyCountry = function() {
	};
	$Cayita_Demo_MyCountry.createInstance = function() {
		return $Cayita_Demo_MyCountry.$ctor();
	};
	$Cayita_Demo_MyCountry.$ctor = function() {
		var $this = new Object();
		$this.Code = null;
		$this.Name = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.MyCountrySearchBoxConfig
	var $Cayita_Demo_MyCountrySearchBoxConfig = function() {
		ss.shallowCopy(Cayita.UI.SearchBoxConfig(), this);
		this.placeholder = 'type country name';
		this.textField = 'Name';
		this.resetButton = true;
		this.minLength = 1;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.MyCountryStore
	var $Cayita_Demo_MyCountryStore = function(options) {
		ss.shallowCopy(Cayita.Data.Store($Cayita_Demo_MyCountry)(), this);
		this.set_idProperty('Code');
		this.api.url = 'json/countriesResponse.json';
		this.api.dataProperty = 'Countries';
		this.api.readMethod = '';
		this.lastOption.pageNumber = 0;
		this.lastOption.pageSize = 10;
		this.lastOption.localPaging = true;
		if (!ss.staticEquals(options, null)) {
			options(this.lastOption);
		}
		var baseReadFn = this.get_readFn();
		this.set_readFn(ss.mkdel(this, function(ro) {
			console.log('0. custom readFn');
			return baseReadFn(ro).done(ss.mkdel(this, function(t) {
				// mimic server side 
				console.log('1. custom read.....', this.lastOption);
				var qp = this.lastOption.get_request();
				if (ss.keyExists(qp, 'Name')) {
					console.log('2. custom read.....', qp);
					var n = qp['Name'].toString();
					Alertify.log.info('Request: ' + n, 5000);
					this.filter(function(f) {
						return ss.startsWithString(f.Name.toUpperCase(), n.toUpperCase());
					});
				}
			}));
			;
		}));
	};
	$Cayita_Demo_MyCountryStore.defineColumns = function() {
		var columns = [];
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_MyCountry)('Name', 'Country', null, true));
		return columns;
	};
	$Cayita_Demo_MyCountryStore.defineColumnsWithFlags = function() {
		var columns = [];
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_MyCountry)('Name', 'Country', function(f, c) {
			var par = Cayita.UI.Atom('p', null, null);
			var img = Cayita.UI.Atom('img', null, null);
			img.src = 'img/flags/' + f.Code.toLowerCase() + '.png';
			img.style.marginRight = '8px';
			par.append(img);
			$(par).append(f.Name);
			c.append(par);
		}, true));
		return columns;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.MyRecord
	var $Cayita_Demo_MyRecord = function() {
	};
	$Cayita_Demo_MyRecord.createInstance = function() {
		return $Cayita_Demo_MyRecord.$ctor();
	};
	$Cayita_Demo_MyRecord.SomeMethod = function($this) {
	};
	$Cayita_Demo_MyRecord.Person = function(name, first, age) {
		var mr = $Cayita_Demo_MyRecord.$ctor();
		mr.Id = ++$Cayita_Demo_MyRecord.$id;
		mr.Name = name;
		mr.First = first;
		mr.Age = age;
		mr.Average = 123456.99;
		mr.FavouriteLanguage = 'CSharp';
		mr.Active = true;
		ss.add(mr.Ids, 1);
		ss.add(mr.Ids, 3);
		ss.add(mr.Ids, 4);
		ss.add(mr.Ids, 6);
		mr.Selection = 3;
		ss.add(mr.MultipleSelection, 2);
		ss.add(mr.MultipleSelection, 3);
		ss.add(mr.MultipleSelection, 5);
		mr.DoB = new Date(1966, 11 - 1, 25);
		return mr;
	};
	$Cayita_Demo_MyRecord.$ctor = function() {
		var $this = new Object();
		$this.Id = 0;
		$this.Name = null;
		$this.First = null;
		$this.Age = 0;
		$this.Average = 0;
		$this.FavouriteLanguage = null;
		$this.Active = false;
		$this.Ids = null;
		$this.Selection = 0;
		$this.MultipleSelection = null;
		$this.DoB = new Date(0);
		$this.LastLog = new Date(0);
		$this.Nullable = null;
		$this.Ids = [];
		$this.MultipleSelection = [];
		return $this;
	};
	ss.registerClass(global, 'DemoMix', $DemoMix);
	ss.registerClass(global, 'Cayita.Demo.MyCountry', $Cayita_Demo_MyCountry, Object);
	ss.registerClass(global, 'Cayita.Demo.MyCountrySearchBoxConfig', $Cayita_Demo_MyCountrySearchBoxConfig, Object);
	ss.registerClass(global, 'Cayita.Demo.MyCountryStore', $Cayita_Demo_MyCountryStore, Object, [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList]);
	ss.registerClass(global, 'Cayita.Demo.MyRecord', $Cayita_Demo_MyRecord, Object);
	$Cayita_Demo_MyRecord.$id = 0;
})();
