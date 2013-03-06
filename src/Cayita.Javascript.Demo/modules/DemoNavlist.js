(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Navbar.DemoNavlist
	var $DemoNavlist = function() {
	};
	$DemoNavlist.execute = function(parent) {
		(new Cayita.UI.Div.$ctor1(null, function(div) {
			div.className = 'bs-docs-example';
			var sb = new Cayita.UI.SideNavBar(div, function(nav) {
				Cayita.UI.Ext.addHeader(nav, 'Menu');
				Cayita.UI.Ext.addItem$1(nav, '#', 'Tables', function(li, anchor) {
				});
				Cayita.UI.Ext.addItem$1(nav, '#', 'Form', function(li1, anchor1) {
				});
				Cayita.UI.Ext.addItem$1(nav, '#', 'Navbar', function(li2, anchor2) {
				});
				Cayita.UI.Ext.addItem$1(nav, '#', 'Navlist', function(li3, anchor3) {
				});
				Cayita.UI.Ext.addHDivider(nav);
				Cayita.UI.Ext.addItem$1(nav, '#', 'Exit', function(li4, anchor4) {
				});
				$(nav).on('click', 'a', function(ev) {
					ev.preventDefault();
					$('#div-log').empty();
					$('#div-log').text(ev.currentTarget.innerText + ' clicked');
				});
			});
			sb.element$1().style.maxWidth = '240px';
			sb.element$1().style.padding = '8px 0';
			new Cayita.UI.Div.$ctor1(div, function(d) {
				d.id = 'div-log';
			});
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>var&nbsp;sb&nbsp;=</span><span class="keyword">new</span><span>&nbsp;SideNavBar(div,&nbsp;nav=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddHeader(<span class="string">"Menu"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"#"</span><span>,</span><span class="string">"Tables"</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"#"</span><span>,</span><span class="string">"Form"</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"#"</span><span>,</span><span class="string">"Navbar"</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"#"</span><span>,</span><span class="string">"Navlist"</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddHDivider();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.AddItem(<span class="string">"#"</span><span>,</span><span class="string">"Exit"</span><span>,&nbsp;(li,anchor)=&gt;{});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;nav.OnClick(<span class="string">"a"</span><span>,&nbsp;ev=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ev.PreventDefault();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class="string">"#div-log"</span><span>).Empty();&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jQuery.Select(<span class="string">"#div-log"</span><span>).Text(ev.CurrentTarget.InnerText+&nbsp;</span><span class="string">"&nbsp;clicked"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;</span></li><li class="alt"><span>sb.Element().Style.MaxWidth=<span class="string">"240px"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>sb.Element().Style.Padding=<span class="string">"8px&nbsp;0"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;</span></li><li class=""><span><span class="keyword">new</span><span>&nbsp;Div(div,&nbsp;d=&gt;d.ID=</span><span class="string">"div-log"</span><span>&nbsp;);&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">var sb =new SideNavBar(div, nav=&gt;{\n\tnav.AddHeader("Menu");\n\tnav.AddItem("#","Tables", (li,anchor)=&gt;{});\n\tnav.AddItem("#","Form", (li,anchor)=&gt;{});\n\tnav.AddItem("#","Navbar", (li,anchor)=&gt;{});\n\tnav.AddItem("#","Navlist", (li,anchor)=&gt;{});\n\tnav.AddHDivider();\n\tnav.AddItem("#","Exit", (li,anchor)=&gt;{});\n\t\n\tnav.OnClick("a", ev=&gt;{\n\t\tev.PreventDefault();\n\t\tjQuery.Select("#div-log").Empty();\n\t\tjQuery.Select("#div-log").Text(ev.CurrentTarget.InnerText+ " clicked" );\n\t});\n});\n\nsb.Element().Style.MaxWidth="240px";\nsb.Element().Style.Padding="8px 0";\n\nnew Div(div, d=&gt;d.ID="div-log" );</textarea></div>');
		})).appendTo(parent);
	};
	ss.registerClass(global, 'DemoNavlist', $DemoNavlist);
})();
