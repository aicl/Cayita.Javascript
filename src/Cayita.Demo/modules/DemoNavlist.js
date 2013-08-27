(function() {
	'use strict';
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Demo.DemoNavlist
	var $DemoNavlist = function() {
	};
	$DemoNavlist.__typeName = 'DemoNavlist';
	$DemoNavlist.execute = function(parent) {
		var nb = Cayita.UI.NavList(null);
		nb.nav.addValue('Tables', null, null, false, null);
		nb.nav.addValue('Forms', null, null, false, null);
		nb.nav.addValue('Modals', null, null, false, null);
		nb.nav.addValue('Panels', null, null, false, null);
		nb.nav.addDivider('divider');
		nb.nav.addValue('Exit', null, null, false, null);
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
		var rq = $.get('code/demonavlist.html');
		rq.done(function(s) {
			code.set_text(s);
		});
	};
	global.DemoNavlist = $DemoNavlist;
	ss.initClass($DemoNavlist, {});
})();
