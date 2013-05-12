(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Navbar.DemoNavbar
	var $DemoNavbar = function() {
	};
	$DemoNavbar.execute = function(parent) {
		(new Cayita.UI.Div.$ctor2(null, function(div) {
			div.className = 'bs-docs-example';
			new Cayita.UI.NavBar(div, 'App Title', function(nav) {
				Extensions.addItem$2(nav, 'Home');
				Extensions.addItem$2(nav, 'License');
				Extensions.addItem$2(nav, 'Contact');
				Extensions.addItem$3(nav, 'Config', new Cayita.UI.DropDownMenu(function(l) {
					Extensions.addItem$2(l, 'Users');
					Extensions.addItem$2(l, 'Groups');
					Extensions.addItem(l, new Cayita.UI.DropDownSubmenu('More Options', function(sm) {
						Extensions.addItem$2(sm, 'Option 1');
						Extensions.addItem$2(sm, 'Option 2');
					}));
				}));
				Extensions.addItem$2(nav, 'About');
				$(nav).on('click', 'a', function(ev) {
					ev.preventDefault();
					$('#div-log').text(Extensions.text(ev.currentTarget) + ' clicked');
				});
			});
			new Cayita.UI.Div.$ctor2(div, function(d) {
				d.id = 'div-log';
			});
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-cpp"><li class="alt"><span><span class="keyword">new</span><span>&nbsp;NavBar(div,</span><span class="string">"App&nbsp;Title"</span><span>,nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Home"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"License"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Contact"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Config"</span><span>,&nbsp;</span><span class="keyword">new</span><span>&nbsp;Menu(l=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.AddItem(<span class="string">"Users"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.AddItem(<span class="string">"Groups"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.AddItem(<span class="keyword">new</span><span>&nbsp;SubMenu(</span><span class="string">"More&nbsp;Options"</span><span>,&nbsp;sm=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sm.AddItem(<span class="string">"Option&nbsp;1"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sm.AddItem(<span class="string">"Option&nbsp;2"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"About"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class="string">"a"</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class="string">"#div-log"</span><span>).Text(ev.CurrentTarget.Text()+&nbsp;</span><span class="string">"&nbsp;clicked"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">new NavBar(div,"App Title",nav=&gt;{\n\tnav.AddItem("Home");\n\tnav.AddItem("License");\n\tnav.AddItem("Contact");\n\tnav.AddItem("Config", new Menu(l=&gt;{\n\t\tl.AddItem("Users");\n\t\tl.AddItem("Groups");\n\t\tl.AddItem(new SubMenu("More Options", sm=&gt;{\n\t\t\tsm.AddItem("Option 1");\n\t\t\tsm.AddItem("Option 2");\n\t\t}));\n\t}));\n\tnav.AddItem("About");\n\t\n\tnav.OnClick("a", ev=&gt;{\n\t\tev.PreventDefault();\n\t\tjQuery.Select("#div-log").Text(ev.CurrentTarget.Text()+ " clicked" );\n\t});\n\t\n});</textarea></div>');
		})).appendTo$2(parent);
	};
	ss.registerClass(global, 'DemoNavbar', $DemoNavbar);
})();
