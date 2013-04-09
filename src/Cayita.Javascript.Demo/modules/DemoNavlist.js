(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Navbar.DemoNavlist
	var $DemoNavlist = function() {
	};
	$DemoNavlist.execute = function(parent) {
		(new Cayita.UI.Div.$ctor1(null, function(div) {
			div.className = 'bs-docs-example';
			var sb = new Cayita.UI.SideNavBar(div, function(nav) {
				Cayita.UI.Extensions.addHeader(nav, 'Menu');
				Cayita.UI.Extensions.addItem$1(nav, 'Tables');
				Cayita.UI.Extensions.addItem$1(nav, 'Form');
				Cayita.UI.Extensions.addItem$1(nav, 'Navbar');
				Cayita.UI.Extensions.addItem$1(nav, 'Navlist');
				Cayita.UI.Extensions.addHDivider(nav);
				Cayita.UI.Extensions.addItem$1(nav, 'Exit');
				$(nav).on('click', 'a', function(ev) {
					ev.preventDefault();
					$('#div-log').text($(ev.currentTarget).text() + ' clicked');
				});
			});
			sb.element$1().style.maxWidth = '240px';
			sb.element$1().style.padding = '8px 0';
			new Cayita.UI.Div.$ctor1(div, function(d) {
				d.id = 'div-log';
			});
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>var&nbsp;sb&nbsp;=</span><span class="keyword">new</span><span>&nbsp;SideNavBar(div,&nbsp;nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddHeader(<span class="string">"Menu"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Tables"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Form"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Navbar"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Navlist"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddHDivider();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"Exit"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class="string">"a"</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class="string">"#div-log"</span><span>).Text(ev.CurrentTarget.Text()+&nbsp;</span><span class="string">"&nbsp;clicked"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;</span></li><li class=""><span>sb.Element().Style.MaxWidth=<span class="string">"240px"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>sb.Element().Style.Padding=<span class="string">"8px&nbsp;0"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;</span></li><li class="alt"><span><span class="keyword">new</span><span>&nbsp;Div(div,&nbsp;d=&gt;d.ID=</span><span class="string">"div-log"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">var sb =new SideNavBar(div, nav=&gt;{\n\tnav.AddHeader("Menu");\n\tnav.AddItem("Tables");\n\tnav.AddItem("Form");\n\tnav.AddItem("Navbar");\n\tnav.AddItem("Navlist");\n\tnav.AddHDivider();\n\tnav.AddItem("Exit");\n\t\n\tnav.OnClick("a", ev=&gt;{\n\t\tev.PreventDefault();\n\t\tjQuery.Select("#div-log").Text(ev.CurrentTarget.Text()+ " clicked" );\n\t});\n});\n\nsb.Element().Style.MaxWidth="240px";\nsb.Element().Style.Padding="8px 0";\n\nnew Div(div, d=&gt;d.ID="div-log" );</textarea></div>');
		})).appendTo$1(parent);
	};
	ss.registerClass(global, 'DemoNavlist', $DemoNavlist);
})();
