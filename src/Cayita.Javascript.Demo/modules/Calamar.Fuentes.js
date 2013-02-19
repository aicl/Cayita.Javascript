(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Test1.Module
	var $MainModule = function() {
	};
	$MainModule.prototype = {
		$doSomething: function(parent) {
				
		new Cayita.UI.Div.$ctor1(parent, function(div) {
				div.className = 'hero-unit';
				div.innerHTML = ' modulo <h3>Fuentes</h3> en Construcion !!!!';
			});
			
		}
	};
	$MainModule.execute = function(parent) {
		var m = new $MainModule();
		m.$doSomething(parent);
	};
	ss.registerClass(global, 'MainModule', $MainModule);
})();
