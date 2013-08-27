(function() {
	'use strict';
	global.Cayita = global.Cayita || {};
	global.Cayita.Demo = global.Cayita.Demo || {};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoSearchBox
	var $DemoSearchBox = function() {
	};
	$DemoSearchBox.__typeName = 'DemoSearchBox';
	$DemoSearchBox.execute = function(parent) {
		var countryStore1 = new $Cayita_Demo_CountryStore(null);
		var sb1 = Cayita.UI.SearchBox($Cayita_Demo_Country)(countryStore1, $Cayita_Demo_CountryStore.defineColumnsWithFlags(), new $Cayita_Demo_CountrySearchBoxConfig());
		sb1.localFilter = function(rec, v) {
			return ss.startsWithString(rec.Name.toUpperCase(), v.toUpperCase());
		};
		sb1.add_rowSelected(function(sb, sr) {
			if (ss.isValue(sr)) {
				Alertify.log.info(Cayita.Fn.fmt('selected: {0}-{1} ', [sb.indexValue, sb.textValue]), 5000);
			}
			else {
				Alertify.log.info('nothing selected', 5000);
			}
		});
		countryStore1.read(null, true);
		$(parent).append(Cayita.Fn.header('Local filter I', 4)).append(sb1);
		var countryStore2 = new $Cayita_Demo_CountryStore(null);
		var $t1 = new $Cayita_Demo_CountrySearchBoxConfig();
		$t1.searchButton = true;
		var sb2 = Cayita.UI.SearchBox($Cayita_Demo_Country)(countryStore2, null, $t1);
		sb2.localFilter = function(rec1, v1) {
			return ss.startsWithString(rec1.Name.toUpperCase(), v1.toUpperCase());
		};
		sb2.add_rowSelected(function(sb3, sr1) {
			if (ss.isValue(sr1)) {
				Alertify.log.info(Cayita.Fn.fmt('selected: {0}-{1} ', [sb3.indexValue, sb3.textValue]), 5000);
			}
			else {
				Alertify.log.info('nothing selected', 5000);
			}
		});
		console.log('countrystore2 reading');
		countryStore2.read(null, true);
		console.log('countrystore2 read');
		$(parent).append(Cayita.Fn.header('Local filter II', 4)).append(sb2);
		var countryRemote = new $Cayita_Demo_CountryStore(function(o) {
			o.localPaging = false;
			o.pageNumber = null;
			//no paged for this demo 
		});
		var sb31 = Cayita.UI.SearchBox($Cayita_Demo_Country)(countryRemote, $Cayita_Demo_CountryStore.defineColumnsWithFlags(), new $Cayita_Demo_CountrySearchBoxConfig());
		$(parent).append(Cayita.Fn.header('Remoter filter', 4)).append(sb31);
		parent.append(Cayita.Fn.header('C# code', 3));
		var rq = $.get('code/demosearchbox.html');
		rq.done(function(s) {
			var code = Cayita.UI.Atom('div');
			code.innerHTML = s;
			parent.append(code);
		});
	};
	global.DemoSearchBox = $DemoSearchBox;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.Country
	var $Cayita_Demo_Country = function() {
	};
	$Cayita_Demo_Country.__typeName = 'Cayita.Demo.Country';
	$Cayita_Demo_Country.createInstance = function() {
		return $Cayita_Demo_Country.$ctor();
	};
	$Cayita_Demo_Country.$ctor = function() {
		var $this = new Object();
		$this.Code = null;
		$this.Name = null;
		return $this;
	};
	global.Cayita.Demo.Country = $Cayita_Demo_Country;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.CountrySearchBoxConfig
	var $Cayita_Demo_CountrySearchBoxConfig = function() {
		ss.shallowCopy(Cayita.UI.SearchBoxConfig(), this);
		this.placeholder = 'type country name';
		this.textField = 'Name';
		this.resetButton = true;
		this.minLength = 1;
	};
	$Cayita_Demo_CountrySearchBoxConfig.__typeName = 'Cayita.Demo.CountrySearchBoxConfig';
	global.Cayita.Demo.CountrySearchBoxConfig = $Cayita_Demo_CountrySearchBoxConfig;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.CountryStore
	var $Cayita_Demo_CountryStore = function(options) {
		ss.shallowCopy(Cayita.Data.Store($Cayita_Demo_Country)(), this);
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
	$Cayita_Demo_CountryStore.__typeName = 'Cayita.Demo.CountryStore';
	$Cayita_Demo_CountryStore.defineColumns = function() {
		var columns = [];
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_Country)('Name', 'Country', null, true));
		return columns;
	};
	$Cayita_Demo_CountryStore.defineColumnsWithFlags = function() {
		var columns = [];
		ss.add(columns, Cayita.UI.TableColumn($Cayita_Demo_Country)('Name', 'Country', function(f, c) {
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
	global.Cayita.Demo.CountryStore = $Cayita_Demo_CountryStore;
	ss.initClass($DemoSearchBox, {});
	ss.initClass($Cayita_Demo_Country, {}, Object);
	ss.initClass($Cayita_Demo_CountrySearchBoxConfig, {}, Object);
	ss.initClass($Cayita_Demo_CountryStore, {}, Object, [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList]);
})();
