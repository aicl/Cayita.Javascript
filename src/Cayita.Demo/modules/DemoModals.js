(function() {
	'use strict';
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoModals
	var $DemoModals = function() {
	};
	$DemoModals.__typeName = 'DemoModals';
	$DemoModals.execute = function(parent) {
		var nb = Cayita.UI.NavList(null);
		nb.nav.addValue('Simple Bootbox Dialog', null, function(e) {
			Cayita.Plugins.showBootboxDialog('cayita is awesome', null, null);
			null;
		}, false, null);
		nb.nav.addValue('Custom Bootbox.Dialog I', null, $DemoModals.$customDialog_1, false, null);
		nb.nav.addValue('Custom Bootbox.Dialog 2', null, $DemoModals.$customDialog_2, false, null);
		nb.nav.addValue('Custom Bootbox.Dialog 3', null, $DemoModals.$customDialog_3, false, null);
		nb.nav.addDivider('divider');
		nb.nav.addValue('Alert', null, function(e1) {
			bootbox.alert('Alert!', function() {
				Alertify.log.info('Alert callback...', 5000);
				null;
			});
		}, false, null);
		nb.nav.addValue('Confirm', null, function(e2) {
			bootbox.confirm('Confirm...', function(c) {
				Alertify.log.info('Confirm callback ' + c, 5000);
				null;
			});
		}, false, null);
		nb.nav.addValue('Prompt', null, function(e3) {
			bootbox.prompt('Pormpt...', function(s) {
				Alertify.log.info('Prompt callback ' + s, 5000);
				null;
			});
		}, false, null);
		var code = Cayita.UI.Atom('div');
		Cayita.UI.Atom('div', null, null, null, function(d) {
			d.className = 'bs-docs-example';
			$(d).append(nb).append(Cayita.Fn.header('C# code', 4)).append(code);
			parent.append(d);
		});
		var rq = $.get('code/demomodals.html');
		rq.done(function(s1) {
			code.innerHTML = s1;
		});
	};
	$DemoModals.$customDialog_1 = function(e) {
		var i = e.currentTarget;
		var $t2 = i.get_text();
		var $t1 = {};
		$t1.callback = function() {
			Alertify.log.info(i.get_text(), 5000);
			null;
		};
		$t1.label = 'My Custom Label';
		Cayita.Plugins.showBootboxDialog($t2, $t1, null);
	};
	$DemoModals.$customDialog_2 = function(e) {
		var i = e.currentTarget;
		var $t2 = i.get_text();
		var $t1 = {};
		$t1.callback = function() {
			Alertify.log.info(i.get_text(), 5000);
			null;
		};
		$t1.label = 'Go';
		$t1.class = 'btn-info';
		var $t3 = Cayita.Plugins.BootboxOptions();
		$t3.header = 'Custom Header';
		Cayita.Plugins.showBootboxDialog($t2, $t1, $t3);
	};
	$DemoModals.$customDialog_3 = function(e) {
		var item = e.currentTarget;
		var dd = Cayita.UI.Atom('div', null, null, null, function(c) {
			Cayita.UI.TextField(null, null, function(i) {
				i.input.placeholder = 'name';
				null;
			}, c);
			Cayita.UI.CheckField(null, null, function(i1) {
				i1.input.set_text('I like cayita');
				i1.input.checked = true;
				i1.input.disabled = true;
			}, c);
			Cayita.UI.Input(String)('textarea', null, null, null, null, function(i2) {
				i2.set_value('cayita is amazing ...');
				null;
			}, c);
		});
		var $t1 = {};
		$t1.callback = function() {
			Alertify.log.info(item.get_text(), 5000);
			null;
		};
		$t1.label = 'Go';
		$t1.class = 'btn-info';
		var $t2 = Cayita.Plugins.BootboxOptions();
		$t2.header = item.get_text();
		$t2.classes = 'modal-large';
		$t2.onEscape = function() {
			Alertify.log.info('Esc pressed', 5000);
			null;
		};
		bootbox.dialog(dd, $t1, $t2);
	};
	global.DemoModals = $DemoModals;
	ss.initClass($DemoModals, {});
})();
