(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Navbar.DemoNavbar
	var $DemoNavbar = function() {
	};
	$DemoNavbar.execute = function(parent) {
		(new Cayita.UI.Div.$ctor1(null, function(div) {
			div.className = 'bs-docs-example';
			new Cayita.UI.TopNavBar(div, 'App Title', function(nav) {
				Cayita.UI.Ext.addItem$1(nav, 'Home');
				Cayita.UI.Ext.addItem$1(nav, 'License');
				Cayita.UI.Ext.addItem$1(nav, 'Contact');
				Cayita.UI.Ext.addItem$1(nav, 'About');
				$(nav).on('click', 'a', function(ev) {
					ev.preventDefault();
					$('#div-log').text($(ev.currentTarget).text() + ' clicked');
				});
			});
			new Cayita.UI.Div.$ctor1(div, function(d) {
				d.id = 'div-log';
			});
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;TopNavBar(div,</span><span class="string">"App&nbsp;Title"</span><span>,nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Home"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"License"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Contact"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"About"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class="string">"a"</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class="string">"#div-log"</span><span>).Text(ev.CurrentTarget.Text()+&nbsp;</span><span class="string">"&nbsp;clicked"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Div(div,&nbsp;d=&gt;d.ID=</span><span class="string">"div-log"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">new TopNavBar(div,"App Title",nav=&gt;{\n\tnav.AddItem("Home");\n\tnav.AddItem("License");\n\tnav.AddItem("Contact");\n\tnav.AddItem("About");\n\t\n\tnav.OnClick("a", ev=&gt;{\n\t\tev.PreventDefault();\n\t\tjQuery.Select("#div-log").Text(ev.CurrentTarget.Text()+ " clicked" );\n\t});\n\t\n});\nnew Div(div, d=&gt;d.ID="div-log" );</textarea></div>');
		})).appendTo(parent);
	};
	ss.registerClass(global, 'DemoNavbar', $DemoNavbar);
})();
