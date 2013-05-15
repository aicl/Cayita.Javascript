(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Modals.DemoModals
	var $DemoModals = function() {
	};
	$DemoModals.execute = function(parent) {
		$(parent).append(StringExtensions.header('Modals', 2));
		(new Cayita.UI.Div.$ctor2(null, function(div) {
			div.className = 'bs-docs-example';
			$(div).append((new Cayita.UI.Button.$ctor2(div, function(b) {
				Extensions.text$1(b, 'Simple Modal Dialog I');
				$(b).on('click', function(evt) {
					Cayita.UI.Bootbox.dialog('Your App Text: cayita is awesome....', '<br/>');
				});
			})).element());
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Dialog(</span><span class="string">"Your&nbsp;App&nbsp;Text:&nbsp;cayita&nbsp;is&nbsp;awesome...."</span><span>);&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Dialog("Your App Text: cayita is awesome....");</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div1) {
			div1.className = 'bs-docs-example';
			$(div1).append((new Cayita.UI.Button.$ctor2(div1, function(b1) {
				Extensions.text$1(b1, 'Simple Modal Dialog II');
				$(b1).on('click', function(evt1) {
					Cayita.UI.Bootbox.dialog('Your App Text: cayita is awesome....', 'Cayita Dialog');
				});
			})).element());
			$(div1).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Dialog(</span><span class="string">"Your&nbsp;App&nbsp;Text:&nbsp;cayita&nbsp;is&nbsp;awesome...."</span><span>,&nbsp;</span><span class="string">"Cayita&nbsp;Dialog"</span><span>)&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Dialog("Your App Text: cayita is awesome....", "Cayita Dialog")</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div2) {
			div2.className = 'bs-docs-example';
			$(div2).append((new Cayita.UI.Button.$ctor2(div2, function(b2) {
				Extensions.text$1(b2, 'Custom Dialog I');
				$(b2).on('click', function(evt2) {
					Cayita.UI.Bootbox.dialog$4('Message from App', function(opt) {
						opt.header = 'Your Header Text';
						opt.onEscape = function() {
							Alertify.log.info('ESC pressed', 5000);
						};
					}, function(bt) {
						var $t1 = Cayita.UI.DialogButton.$ctor();
						$t1.label = 'OK';
						$t1.class = 'btn btn-success';
						$t1.callback = function() {
							Alertify.log.info('OK clicked', 5000);
						};
						ss.add(bt, $t1);
					});
				});
			})).element());
			$(div2).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Dialog(</span><span class="string">"Message&nbsp;from&nbsp;App"</span><span>,opt=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.Header=<span class="string">"Your&nbsp;Header&nbsp;Text"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.OnEscape=()=&gt;&nbsp;<span class="string">"ESC&nbsp;pressed"</span><span>.LogInfo();&nbsp;&nbsp;</span></span></li><li class=""><span>},&nbsp;&nbsp;</span></li><li class="alt"><span>bt=&gt;bt.Add(&nbsp;<span class="keyword">new</span><span>&nbsp;DialogButton(){&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;Label=<span class="string">"OK"</span><span>,&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;Class=<span class="string">"btn&nbsp;btn-success"</span><span>,&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;Callback=&nbsp;()=&gt;&nbsp;<span class="string">"OK&nbsp;clicked"</span><span>.LogInfo()&nbsp;&nbsp;</span></span></li><li class="alt"><span>}));&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Dialog("Message from App",opt=&gt;{\n\topt.Header="Your Header Text";\n\topt.OnEscape=()=&gt; "ESC pressed".LogInfo();\n},\nbt=&gt;bt.Add( new DialogButton(){\n\tLabel="OK", \n\tClass="btn btn-success",\n\tCallback= ()=&gt; "OK clicked".LogInfo()\n}));</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div3) {
			div3.className = 'bs-docs-example';
			$(div3).append((new Cayita.UI.Button.$ctor2(div3, function(b3) {
				Extensions.text$1(b3, 'Custom Dialog II');
				$(b3).on('click', function(evt3) {
					var d = new Cayita.UI.Div.$ctor2(null, function(dd) {
						dd.className = 'span3';
						new Cayita.UI.TextField.$ctor6(dd, function(field) {
							$(field).attr('placeholder', 'Your Name');
						});
						new Cayita.UI.CheckboxField.$ctor4(dd, function(cbl, cbi) {
							Extensions.text$1(cbl, 'I like cayita');
							cbi.checked = true;
							cbi.disabled = true;
						});
						new Cayita.UI.InputTextArea.$ctor2(dd, function(area) {
							area.value = 'cayita is amazing ...';
						});
					});
					Cayita.UI.Bootbox.dialog$1(d, function(opt1) {
						opt1.header = 'large-modal';
						opt1.classes = 'modal-large';
						opt1.onEscape = function() {
							Alertify.log.info('ESC pressed', 5000);
						};
					}, function(bt1) {
						var $t2 = Cayita.UI.DialogButton.$ctor();
						$t2.label = 'Cancel';
						$t2.callback = function() {
							Alertify.log.error('Cancel pressed. Click here to delete message', 0);
						};
						ss.add(bt1, $t2);
						var $t3 = Cayita.UI.DialogButton.$ctor();
						$t3.label = 'Save';
						$t3.callback = function() {
							Alertify.log.success('Save pressed', 5000);
						};
						ss.add(bt1, $t3);
					});
				});
			})).element());
			$(div3).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>var&nbsp;d&nbsp;=&nbsp;</span><span class="keyword">new</span><span>&nbsp;Div(</span><span class="keyword">null</span><span>,&nbsp;dd=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;dd.ClassName=<span class="string">"span3"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(dd,&nbsp;field=&gt;field.PlaceHolder(</span><span class="string">"Your&nbsp;Name"</span><span>));&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(dd,(cbl,cbi&nbsp;)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbl.Text(<span class="string">"I&nbsp;like&nbsp;cayita"</span><span>);&nbsp;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbi.Checked=<span class="keyword">true</span><span>;&nbsp;cbi.Disabled=</span><span class="keyword">true</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputTextArea(dd,&nbsp;area=&gt;&nbsp;&nbsp;area.Value=</span><span class="string">"cayita&nbsp;is&nbsp;amazing&nbsp;..."</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;</span></li><li class="alt"><span>Bootbox.Dialog(d,&nbsp;opt=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.Header=<span class="string">"large-modal"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.Classes=<span class="string">"modal-large"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;opt.OnEscape=&nbsp;()=&gt;&nbsp;<span class="string">"ESC&nbsp;pressed"</span><span>.LogInfo();&nbsp;&nbsp;</span></span></li><li class="alt"><span>},&nbsp;&nbsp;</span></li><li class=""><span>bt=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Add(<span class="keyword">new</span><span>&nbsp;DialogButton{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label=<span class="string">"Cancel"</span><span>,&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Callback=()=&gt;&nbsp;<span class="string">"Cancel&nbsp;pressed.&nbsp;Click&nbsp;here&nbsp;to&nbsp;delete&nbsp;message"</span><span>.LogError()&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;bt.Add(&nbsp;<span class="keyword">new</span><span>&nbsp;DialogButton{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label=<span class="string">"Save"</span><span>,&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Callback=&nbsp;()=&gt;&nbsp;<span class="string">"Save&nbsp;pressed"</span><span>.LogSuccess()&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>});&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">var d = new Div(null, dd=&gt;{\n\tdd.ClassName="span3";\n\tnew TextField(dd, field=&gt;field.PlaceHolder("Your Name"));\n\tnew CheckboxField(dd,(cbl,cbi )=&gt;{\n\t\tcbl.Text("I like cayita"); \n\t\tcbi.Checked=true; cbi.Disabled=true;\n\t});\n\tnew InputTextArea(dd, area=&gt;\tarea.Value="cayita is amazing ...");\n});\n\nBootbox.Dialog(d, opt=&gt;{\n\topt.Header="large-modal";\n\topt.Classes="modal-large";\n\topt.OnEscape= ()=&gt; "ESC pressed".LogInfo();\n},\nbt=&gt;{\n\tbt.Add(new DialogButton{\n\t\tLabel="Cancel",\n\t\tCallback=()=&gt; "Cancel pressed. Click here to delete message".LogError()\n\t});\n\tbt.Add( new DialogButton{\n\t\tLabel="Save",\n\t\tCallback= ()=&gt; "Save pressed".LogSuccess()\n\t});\n});\n</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div4) {
			div4.className = 'bs-docs-example';
			$(div4).append((new Cayita.UI.Button.$ctor2(div4, function(b4) {
				Extensions.text$1(b4, 'Error Dialog ');
				$(b4).on('click', function(evt4) {
					Cayita.UI.Bootbox.error('You must use cayita', 'Error !!!');
				});
			})).element());
			$(div4).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Error(</span><span class="string">"You&nbsp;must&nbsp;use&nbsp;cayita"</span><span>,&nbsp;</span><span class="string">"Error&nbsp;!!!"</span><span>)&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Error("You must use cayita", "Error !!!")</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div5) {
			div5.className = 'bs-docs-example';
			$(div5).append((new Cayita.UI.Button.$ctor2(div5, function(b5) {
				Extensions.text$1(b5, 'Alert ');
				$(b5).on('click', function(evt5) {
					bootbox.alert('User is over quota', 'OK', null);
				});
			})).element());
			$(div5).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Alert(</span><span class="string">"User&nbsp;is&nbsp;over&nbsp;quota"</span><span>)&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Alert("User is over quota")</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div6) {
			div6.className = 'bs-docs-example';
			$(div6).append((new Cayita.UI.Button.$ctor2(div6, function(b6) {
				Extensions.text$1(b6, 'Prompt');
				$(b6).on('click', function(evt6) {
					bootbox.prompt('Your name?', 'Cancel', 'OK', function(r) {
						Alertify.log.info('Your name is:' + r, 5000);
					}, '');
				});
			})).element());
			$(div6).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Prompt(</span><span class="string">"Your&nbsp;name?"</span><span>,&nbsp;callback:r=&gt;(</span><span class="string">"Your&nbsp;name&nbsp;is:"</span><span>+&nbsp;r).LogInfo())&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Prompt("Your name?", callback:r=&gt;("Your name is:"+ r).LogInfo())</textarea></div>');
		})).appendTo$2(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div7) {
			div7.className = 'bs-docs-example';
			$(div7).append((new Cayita.UI.Button.$ctor2(div7, function(b7) {
				Extensions.text$1(b7, 'Confirm');
				$(b7).on('click', function(evt7) {
					bootbox.confirm('Are you sure?', 'Cancel', 'OK', function(res) {
						Alertify.log.info((res ? 'OK' : 'Cancel') + ' pressed', 5000);
					});
				});
			})).element());
			$(div7).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>Bootbox.Confirm(</span><span class="string">"Are&nbsp;you&nbsp;sure?"</span><span>,&nbsp;callback:&nbsp;res=&gt;&nbsp;(res?</span><span class="string">"OK"</span><span>:</span><span class="string">"Cancel"</span><span>+</span><span class="string">"&nbsp;pressed"</span><span>).LogInfo()&nbsp;)&nbsp;&nbsp;</span></span></li></ol><textarea style="display:none;" class="originalCode">Bootbox.Confirm("Are you sure?", callback: res=&gt; (res?"OK":"Cancel"+" pressed").LogInfo() )</textarea></div>');
		})).appendTo$2(parent);
	};
	ss.registerClass(global, 'DemoModals', $DemoModals);
})();
