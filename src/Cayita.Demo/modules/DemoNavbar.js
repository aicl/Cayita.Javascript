(function() {
	'use strict';
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoNavbar
	var $DemoNavbar = function() {
	};
	$DemoNavbar.__typeName = 'DemoNavbar';
	$DemoNavbar.execute = function(parent) {
		var nb = Cayita.UI.NavBar();
		nb.nav.set_brandText('App Title');
		nb.nav.addValue('Home', null, null, false, null);
		nb.nav.addValue('License', null, null, false, null);
		nb.nav.addValue('Contact', null, null, false, null);
		var dd = Cayita.UI.DropdownMenu();
		dd.set_text('Config');
		dd.nav.addValue('Users', null, null, null);
		dd.nav.addValue('Groups', null, null, null);
		nb.nav.addDropdownMenu(dd);
		var log = Cayita.UI.Atom('div');
		var code = Cayita.UI.Atom('div');
		Cayita.UI.Atom('div', null, null, null, function(d) {
			d.className = 'bs-docs-example';
			$(d).append(nb).append(log).append(Cayita.Fn.header('C# code', 4)).append(code);
			parent.append(d);
		});
		nb.nav.add_selected(function(e) {
			var i = e.currentTarget;
			log.set_text(Cayita.Fn.fmt('{0} Clicked', [i.get_text()]));
		});
		var rq = $.get('code/demonavbar.html');
		rq.done(function(s) {
			code.set_text(s);
		});
	};
	global.DemoNavbar = $DemoNavbar;
	ss.initClass($DemoNavbar, {});
})();
