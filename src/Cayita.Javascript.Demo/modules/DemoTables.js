(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.Customer
	var $Customer = function() {
	};
	$Customer.createInstance = function() {
		return $Customer.$ctor();
	};
	$Customer.$ctor = function() {
		var $this = {};
		$this.Id = null;
		$this.CompanyName = null;
		$this.ContactName = null;
		$this.Country = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.CustomerGrid
	var $CustomerGrid = function(parent, store) {
		$CustomerGrid.$ctor1.call(this, parent, store, $CustomerGrid.defineColumns());
	};
	$CustomerGrid.prototype = {
		getStore$1: function() {
			return this.$us;
		}
	};
	$CustomerGrid.$ctor1 = function(parent, store, columns) {
		this.$us = null;
		ss.makeGenericType(Cayita.UI.HtmlGrid$1, [$Customer]).$ctor1.call(this, null, store, columns);
		this.appendTo(parent);
		this.$us = store;
	};
	$CustomerGrid.$ctor1.prototype = $CustomerGrid.prototype;
	$CustomerGrid.defineColumns = function() {
		var columns = [];
		var $t1 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$Customer]).$ctor();
		$t1.header = (new Cayita.UI.TableCell.$ctor1(function(c) {
			$(c).text('Company');
		})).element$1();
		$t1.value = function(f) {
			return (new Cayita.UI.TableCell.$ctor1(function(c1) {
				$(c1).text(f.CompanyName);
				c1.style.width = '40%';
			})).element$1();
		};
		ss.add(columns, $t1);
		var $t2 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$Customer]).$ctor();
		$t2.header = (new Cayita.UI.TableCell.$ctor1(function(c2) {
			$(c2).text('Contact');
		})).element$1();
		$t2.value = function(f1) {
			return (new Cayita.UI.TableCell.$ctor1(function(c3) {
				$(c3).text(f1.ContactName);
				c3.style.width = '40%';
			})).element$1();
		};
		ss.add(columns, $t2);
		var $t3 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$Customer]).$ctor();
		$t3.header = (new Cayita.UI.TableCell.$ctor1(function(c4) {
			$(c4).text('Country');
		})).element$1();
		$t3.value = function(f2) {
			return (new Cayita.UI.TableCell.$ctor1(function(c5) {
				$(c5).text(f2.Country);
			})).element$1();
		};
		ss.add(columns, $t3);
		return columns;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.CustomerStore
	var $CustomerStore = function() {
		ss.makeGenericType(Cayita.Data.Store$1, [$Customer]).call(this);
		this.setReadApi(function(api) {
			api.url = 'json/customersResponse.json';
			api.dataProperty = 'Customers';
		});
	};
	$CustomerStore.prototype = {
		read$1: function() {
			return this.read(function(ro) {
				ro.localPaging = true;
				ro.pageNumber = 0;
				ro.pageSize = 10;
			});
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.DemoTables
	var $DemoTables = function() {
	};
	$DemoTables.execute = function(parent) {
		$(document.createElement('h3')).text('CRUD').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div) {
			div.className = 'bs-docs-example';
			$DemoTables.$uGrid = new $UserGrid(div, new $UserStore());
			$DemoTables.$uForm = new $UserForm(div, $DemoTables.$getLevelOptions());
		})).appendTo(parent);
		$DemoTables.$uForm.getCreateButton().disabled = false;
		$($DemoTables.$uForm.getCreateButton()).on('click', function(evt) {
			$DemoTables.$uGrid.selectRow(true);
		});
		$($DemoTables.$uForm.getDestroyButton()).on('click', function(evt1) {
			$DemoTables.$uGrid.getStore$1().remove($DemoTables.$uGrid.getSelectedRow().record);
		});
		$($DemoTables.$uForm.element$1()).on('change', 'input', function(e) {
			$DemoTables.$uForm.getSaveButton().disabled = !cayita.fn.dataChanged($DemoTables.$uForm.element$1());
		});
		$DemoTables.$uGrid.add_onRowSelected(function(g, sr) {
			$DemoTables.$uForm.getSaveButton().disabled = true;
			if (ss.isValue(sr)) {
				cayita.fn.loadForm($DemoTables.$uForm.element$1(), sr.record);
				$DemoTables.$uForm.getDestroyButton().disabled = false;
			}
			else {
				cayita.fn.loadForm($DemoTables.$uForm.element$1(), $User.$ctor());
				$DemoTables.$uForm.getDestroyButton().disabled = true;
			}
		});
		var vo = ValidateOptions.addRule(ValidateOptions.addRule(ValidateOptions.addRule(ValidateOptions.setSubmitHandler(ValidateOptions.$ctor(), function(form) {
			var user = Cayita.UI.Ext.loadTo($User).call(null, form);
			$DemoTables.$uGrid.getStore$1().save(user);
			$DemoTables.$uGrid.selectRow$1(user.Id, true);
		}), function(r, m) {
			r.element = Cayita.UI.Ext.findByName(Element).call(null, $DemoTables.$uForm.element$1(), 'Name');
			Rule.required(r.rule);
			Rule.minlength(r.rule, 6);
			Message.required(m, 'write username');
			Message.minlength(m, 'min 6 chars');
		}), function(r1, m1) {
			r1.element = Cayita.UI.Ext.findByName(Element).call(null, $DemoTables.$uForm.element$1(), 'Email');
			Rule.email(r1.rule, null);
			Message.email(m1, 'write a valid email address');
		}), function(r2, m2) {
			r2.element = Cayita.UI.Ext.findByName(Element).call(null, $DemoTables.$uForm.element$1(), 'Rating');
			cayita.fn.autoNumeric(r2.element, { mDec: 0, wEmpty: 'zero' });
			Rule.max(r2.rule, 10000);
			Rule.min(r2.rule, 0);
		});
		$($DemoTables.$uForm.element$1()).validate(vo);
		$DemoTables.$uGrid.getStore$1().read(null);
		$DemoTables.$showCodeCrud(parent);
		$(document.createElement('h3')).text('Paged Tables').appendTo(parent);
		(new Cayita.UI.Div.$ctor1(null, function(div1) {
			div1.className = 'bs-docs-example';
			new Cayita.UI.Div.$ctor1(div1, function(ct) {
				ct.style.minHeight = '300px';
				$DemoTables.$cGrid = new $CustomerGrid(ct, new $CustomerStore());
			});
			new (ss.makeGenericType(Cayita.UI.StorePaging$1, [$Customer]))(div1, $DemoTables.$cGrid.getStore$1());
		})).appendTo(parent);
		$DemoTables.$cGrid.getStore$1().read$1();
		$(document.createElement('h3')).text('Filters').appendTo(parent);
		var gc = null;
		(new Cayita.UI.Div.$ctor1(null, function(div2) {
			div2.className = 'bs-docs-example';
			new Cayita.UI.InputText.$ctor2(div2, function(e1) {
				$(e1).attr('placeholder', 'Country');
				$(e1).on('change', function(evt2) {
					gc.getStore$1().filter(function(f) {
						return ss.startsWithString(f.Country, e1.value);
					});
				});
			});
			new Cayita.UI.Div.$ctor1(div2, function(ct1) {
				ct1.style.minHeight = '300px';
				gc = new $CustomerGrid(ct1, new $CustomerStore());
				new (ss.makeGenericType(Cayita.UI.StorePaging$1, [$Customer]))(div2, gc.getStore$1());
				gc.getStore$1().read$1();
			});
		})).appendTo(parent);
	};
	$DemoTables.$getLevelOptions = function() {
		var $t1 = Cayita.UI.RadioItem.$ctor();
		$t1.text = 'A';
		$t1.value = 'A';
		var $t2 = Cayita.UI.RadioItem.$ctor();
		$t2.text = 'B';
		$t2.value = 'B';
		var $t3 = Cayita.UI.RadioItem.$ctor();
		$t3.text = 'C';
		$t3.value = 'C';
		return ss.arrayClone([$t1, $t2, $t3]);
	};
	$DemoTables.$showCodeCrud = function(parent) {
		(new Cayita.UI.Div.$ctor1(null, function(div) {
			div.className = 'bs-docs-code';
			$(document.createElement('h3')).text('User.cs').appendTo(div);
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""><span>[Serializable]&nbsp;&nbsp;</span></li><li class="alt"><span>[PreserveMemberCase]&nbsp;&nbsp;</span></li><li class=""><span><span class="keyword">public</span><span>&nbsp;&nbsp;</span><span class="keyword">class</span><span>&nbsp;User&nbsp;&nbsp;</span></span></li><li class="alt"><span>{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;User(){}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">int</span><span>&nbsp;Id&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;Name&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;Address&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;City&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;Email&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;DateTime&nbsp;DoB&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">bool</span><span>&nbsp;IsActive&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;Level&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;UserName&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">string</span><span>&nbsp;Password&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">int</span><span>&nbsp;Rating&nbsp;{&nbsp;</span><span class="keyword">get</span><span>;&nbsp;</span><span class="keyword">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""><span>}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;</span></li><li class=""><span>[IgnoreNamespace]&nbsp;&nbsp;</span></li><li class="alt"><span><span class="keyword">public</span><span>&nbsp;</span><span class="keyword">class</span><span>&nbsp;UserStore:Store&lt;User&gt;&nbsp;&nbsp;</span></span></li><li class=""><span>{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">static</span><span>&nbsp;</span><span class="keyword">int</span><span>&nbsp;id=0;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;UserStore():</span><span class="keyword">base</span><span>()&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetReadApi(api=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;api.Url=<span class="string">"json/userResponse.json"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;api.Converters[<span class="string">"DoB"</span><span>]=&nbsp;(u)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;u.DoB.ConvertToDate();&nbsp;</span><span class="comment">//&nbsp;convert&nbsp;from&nbsp;&nbsp;"DoB":"\\/Date(13651200000+0000)\\/"&nbsp;into&nbsp;date&nbsp;</span><span>&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">void</span><span>&nbsp;Save(User&nbsp;record)&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">if</span><span>(&nbsp;record.Id==0)&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;record.Id=--id;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(record);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">else</span><span>&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Replace(record);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>}&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">[IgnoreNamespace]\n[Serializable]\n[PreserveMemberCase]\npublic  class User\n{\n\tpublic User(){}\n\tpublic int Id { get; set; }\n\tpublic string Name { get; set; }\n\tpublic string Address { get; set; }\n\tpublic string City { get; set; }\n\tpublic string Email { get; set; }\n\tpublic DateTime DoB { get; set; }\n\tpublic bool IsActive { get; set; }\n\tpublic string Level { get; set; }\n\tpublic string UserName { get; set; }\n\tpublic string Password { get; set; }\n\tpublic int Rating { get; set; }\n}\n\n[IgnoreNamespace]\npublic class UserStore:Store&lt;User&gt;\n{\n\tstatic int id=0;\n\t\n\tpublic UserStore():base()\n\t{\n\t\tSetReadApi(api=&gt;{\n\t\t\tapi.Url="json/userResponse.json";\n\t\t\tapi.Converters["DoB"]= (u)=&gt;{\n\t\t\t\treturn u.DoB.ConvertToDate(); // convert from  "DoB":"\\/Date(13651200000+0000)\\/" into date \n\t\t\t};\n\t\t});\n\t}\n\t\n\tpublic void Save(User record)\n\t{\n\t\tif( record.Id==0)\n\t\t{\n\t\t\trecord.Id=--id;\n\t\t\tAdd(record);\n\t\t}\n\t\telse\n\t\t{\n\t\t\tReplace(record);\n\t\t}\n\t}\t\n}</textarea></div>');
			$(document.createElement('h3')).text('UserGrid.cs').appendTo(div);
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""><span><span class="keyword">public</span><span>&nbsp;</span><span class="keyword">class</span><span>&nbsp;UserGrid:HtmlGrid&lt;User&gt;&nbsp;&nbsp;</span></span></li><li class="alt"><span>{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;UserStore&nbsp;us;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;UserGrid&nbsp;(Element&nbsp;parent,&nbsp;UserStore&nbsp;store)&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<span class="keyword">this</span><span>(parent,&nbsp;store,&nbsp;DefineColumns())&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;UserGrid&nbsp;(Element&nbsp;parent,&nbsp;UserStore&nbsp;store,&nbsp;List&lt;TableColumn&lt;User&gt;&gt;&nbsp;columns)&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<span class="keyword">base</span><span>(</span><span class="keyword">null</span><span>,&nbsp;store,&nbsp;columns)&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppendTo(parent);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;us=store;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;&nbsp;UserStore&nbsp;GetStore(){&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;us;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">static</span><span>&nbsp;List&lt;TableColumn&lt;User&gt;&gt;&nbsp;DefineColumns()&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TableColumn&lt;User&gt;&gt;&nbsp;columns=&nbsp;<span class="keyword">new</span><span>&nbsp;List&lt;TableColumn&lt;User&gt;&gt;();&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Name"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Name);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"City"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.City);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Address"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Address);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Birthday"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.DoB.ToString(<span class="string">"dd.MM.yyyy"</span><span>));&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Email"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Email);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Rating"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Rating.ToString());&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.AutoNumeric(<span class="keyword">new</span><span>&nbsp;{mDec=0});&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.TextAlign=<span class="string">"center"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Level"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Level);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.Color=&nbsp;f.Level==<span class="string">"A"</span><span>?</span><span class="string">"green"</span><span>:&nbsp;f.Level==</span><span class="string">"B"</span><span>?</span><span class="string">"orange"</span><span>:&nbsp;</span><span class="string">"red"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.TextAlign=<span class="string">"center"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class="keyword">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class="keyword">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class="string">"Active&nbsp;?"</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;</span><span class="keyword">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.TextAlign=<span class="string">"center"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Append(&nbsp;<span class="keyword">new</span><span>&nbsp;Icon(c,&nbsp;i=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=&nbsp;f.IsActive?&nbsp;<span class="string">"icon-ok-circle"</span><span>:&nbsp;</span><span class="string">"icon-ban-circle"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element());&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AfterCellCreate=&nbsp;(f,row)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row.Style.Color=&nbsp;f.IsActive?<span class="string">"black"</span><span>:</span><span class="string">"grey"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row.AddClass(f.Rating&gt;=10000?&nbsp;<span class="string">"success"</span><span>:&nbsp;f.Rating&lt;=5000?</span><span class="string">"warning"</span><span>:</span><span class="string">""</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;columns;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>}&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">[IgnoreNamespace]\npublic class UserGrid:HtmlGrid&lt;User&gt;\n{\n\tUserStore us;\n\t\n\tpublic UserGrid (Element parent, UserStore store)\n\t\t:this(parent, store, DefineColumns())\n\t{\n\t}\n\t\n\tpublic UserGrid (Element parent, UserStore store, List&lt;TableColumn&lt;User&gt;&gt; columns)\n\t\t:base(null, store, columns)\n\t{\n\t\tAppendTo(parent);\n\t\tus=store;\n\t}\n\t\n\tpublic new  UserStore GetStore(){\n\t\treturn us;\n\t}\n\t\n\tpublic static List&lt;TableColumn&lt;User&gt;&gt; DefineColumns()\n\t{\n\t\tList&lt;TableColumn&lt;User&gt;&gt; columns= new List&lt;TableColumn&lt;User&gt;&gt;();\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Name")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.Name);\n\t\t\t\t}).Element();\n\t\t\t}\n\t\t});\n\t\t\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("City")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.City);\n\t\t\t\t}).Element();\n\t\t\t}\n\t\t});\n\t\t\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Address")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.Address);\n\t\t\t\t}).Element();\n\t\t\t}\n\t\t});\n\t\t\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Birthday")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.DoB.ToString("dd.MM.yyyy"));\n\t\t\t\t}).Element();\n\t\t\t}\n\t\t});\n\t\t\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Email")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.Email);\n\t\t\t\t}).Element();\n\t\t\t}\n\t\t});\n\t\t\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Rating")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.Rating.ToString());\n\t\t\t\t\tc.AutoNumeric(new {mDec=0});\n\t\t\t\t\tc.Style.TextAlign="center";\n\t\t\t\t}).Element();\n\t\t\t},\n\t\t\t\n\t\t});\n\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Level")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.SetValue(f.Level);\n\t\t\t\t\tc.Style.Color= f.Level=="A"?"green": f.Level=="B"?"orange": "red";\n\t\t\t\t\tc.Style.TextAlign="center";\n\t\t\t\t}).Element();\n\t\t\t}\n\t\t});\n\t\t\n\t\tcolumns.Add(new TableColumn&lt;User&gt;(){\n\t\t\tHeader= new TableCell(c=&gt; c.Text("Active ?")).Element(),\n\t\t\tValue= (f)=&gt;{\n\t\t\t\treturn new TableCell( c=&gt;{\n\t\t\t\t\tc.Style.TextAlign="center";\n\t\t\t\t\tc.Append( new Icon(c, i=&gt;{\n\t\t\t\t\t\ti.ClassName= f.IsActive? "icon-ok-circle": "icon-ban-circle";\n\t\t\t\t\t}).Element());\n\t\t\t\t\t\n\t\t\t\t}).Element();\n\t\t\t},\n\t\t\tAfterCellCreate= (f,row)=&gt;{\n\t\t\t\trow.Style.Color= f.IsActive?"black":"grey";\n\t\t\t\trow.AddClass(f.Rating&gt;=10000? "success": f.Rating&lt;=5000?"warning":"");\n\t\t\t}\n\t\t});\n\t\t\n\t\treturn columns;\n\t}\t\n}\n</textarea></div>');
			$(document.createElement('h3')).text('UserForm.cs').appendTo(div);
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""><span><span class="keyword">public</span><span>&nbsp;</span><span class="keyword">class</span><span>&nbsp;UserForm:Form&nbsp;&nbsp;</span></span></li><li class="alt"><span>{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;FormElement&nbsp;f;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;ButtonElement&nbsp;GetSaveButton()&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;f.FindById&lt;ButtonElement&gt;(</span><span class="string">"btn-save"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;ButtonElement&nbsp;GetDestroyButton()&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;f.FindById&lt;ButtonElement&gt;(</span><span class="string">"btn-destroy"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;ButtonElement&nbsp;GetCreateButton()&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;f.FindById&lt;ButtonElement&gt;(</span><span class="string">"btn-create"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;UserForm&nbsp;(Element&nbsp;parent,&nbsp;List&lt;RadioItem&gt;&nbsp;levelOptions):</span><span class="keyword">base</span><span>(</span><span class="keyword">null</span><span>)&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f&nbsp;=&nbsp;Element();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class="string">"form-horizontal"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Append(<span class="string">"&lt;style&gt;.form-horizontal&nbsp;.controls&nbsp;{&nbsp;margin-left:&nbsp;100px;&nbsp;}&nbsp;@media&nbsp;(max-width:&nbsp;480px)&nbsp;{&nbsp;.form-horizontal&nbsp;.controls&nbsp;{&nbsp;margin-left:&nbsp;0px;&nbsp;}&nbsp;}&nbsp;&nbsp;&lt;/style&gt;"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(f,&nbsp;tb=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.ClassName=&nbsp;<span class="string">"nav"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;IconButton(tb,&nbsp;(bt,&nbsp;ibn)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ibn.ClassName=<span class="string">"icon-file&nbsp;icon-large"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ID=<span class="string">"btn-create"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Disabled=<span class="keyword">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;IconButton(tb,&nbsp;(bt,&nbsp;ibn)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ibn.ClassName=<span class="string">"icon-save&nbsp;icon-large"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ID=<span class="string">"btn-save"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Type(<span class="string">"submit"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Disabled=<span class="keyword">true</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;IconButton(tb,&nbsp;(bt,&nbsp;ibn)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ibn.ClassName=<span class="string">"icon-remove&nbsp;icon-large"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ID=<span class="string">"btn-destroy"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Disabled=<span class="keyword">true</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;InputText(f,&nbsp;e=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"Id"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Hide();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.IsNumeric();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Name"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"Name"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"City"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"City"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Address"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"Address"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Birthday"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"DoB"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Datepicker(<span class="keyword">new</span><span>&nbsp;{&nbsp;&nbsp;dateFormat=&nbsp;</span><span class="string">"dd.mm.yy"</span><span>&nbsp;});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"Email"</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Rating"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"Rating"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.AutoNumeric();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;RadioField(f,&nbsp;</span><span class="string">"Level"</span><span>,&nbsp;</span><span class="string">"Level"</span><span>,&nbsp;levelOptions);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;CheckboxField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class="string">"Is&nbsp;Active?"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class="string">"IsActive"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.JQuery(<span class="string">"label[class=\'control-label\']"</span><span>).CSS(</span><span class="string">"width"</span><span>,&nbsp;</span><span class="string">"80px"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppendTo(parent);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>}&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">[IgnoreNamespace]\npublic class UserForm:Form\n{\n\tFormElement f;\n\t\n\tpublic ButtonElement GetSaveButton()\n\t{\n\t\treturn f.FindById&lt;ButtonElement&gt;("btn-save");\n\t}\n\t\n\tpublic ButtonElement GetDestroyButton()\n\t{\n\t\treturn f.FindById&lt;ButtonElement&gt;("btn-destroy");\n\t}\n\t\n\tpublic ButtonElement GetCreateButton()\n\t{\n\t\treturn f.FindById&lt;ButtonElement&gt;("btn-create");\n\t}\n\t\n\tpublic UserForm (Element parent, List&lt;RadioItem&gt; levelOptions):base(null)\n\t{\n\t\tf = Element();\n\t\t\n\t\tf.ClassName="form-horizontal";\n\t\tf.Append("&lt;style&gt;.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  &lt;/style&gt;");\n\t\t\n\t\tnew Div(f, tb=&gt;{\n\t\t\ttb.ClassName= "nav";\n\t\t\tnew IconButton(tb, (bt, ibn)=&gt;{\n\t\t\t\tibn.ClassName="icon-file icon-large";\n\t\t\t\tbt.ID="btn-create";\n\t\t\t\tbt.Disabled=true;\n\t\t\t});\n\t\t\t\n\t\t\tnew IconButton(tb, (bt, ibn)=&gt;{\n\t\t\t\tibn.ClassName="icon-save icon-large";\n\t\t\t\tbt.ID="btn-save";\n\t\t\t\tbt.Type("submit");\n\t\t\t\tbt.Disabled=true;\n\t\t\t});\n\t\t\t\n\t\t\tnew IconButton(tb, (bt, ibn)=&gt;{\n\t\t\t\tibn.ClassName="icon-remove icon-large";\n\t\t\t\tbt.ID="btn-destroy";\n\t\t\t\tbt.Disabled=true;\n\t\t\t});\n\t\t});\n\t\t\n\t\tnew InputText(f, e=&gt;{\n\t\t\te.Name="Id";\n\t\t\te.Hide();\n\t\t\te.IsNumeric();\n\t\t}); \n\t\t\n\t\tnew TextField(f,(l, e)=&gt;{\n\t\t\tl.Text("Name");\n\t\t\te.Name="Name";\n\t\t}); \n\t\t\n\t\tnew TextField(f,(l, e)=&gt;{\n\t\t\tl.Text("City");\n\t\t\te.Name="City";\n\t\t}); \n\t\t\n\t\tnew TextField(f,(l, e)=&gt;{\n\t\t\tl.Text("Address");\n\t\t\te.Name="Address";\n\t\t}); \n\t\t\n\t\tnew TextField(f,(l, e)=&gt;{\n\t\t\tl.Text("Birthday");\n\t\t\te.Name="DoB";\n\t\t\te.Datepicker(new {  dateFormat= "dd.mm.yy" });\n\t\t}); \n\t\t\n\t\tnew TextField(f,(l, e)=&gt;{\n\t\t\tl.Text("Email");\n\t\t\te.Name="Email";\n\t\t}); \n\t\t\n\t\tnew TextField(f,(l, e)=&gt;{\n\t\t\tl.Text("Rating");\n\t\t\te.Name="Rating";\n\t\t\te.AutoNumeric();\n\t\t}); \n\t\t\n\t\tnew RadioField(f, "Level", "Level", levelOptions);\n\t\t\n\t\tnew CheckboxField(f,(l, e)=&gt;{\n\t\t\tl.Text("Is Active?");\n\t\t\te.Name="IsActive";\n\t\t}); \n\t\t\n\t\tf.JQuery("label[class=\'control-label\']").CSS("width", "80px");\n\t\tAppendTo(parent);\n\t}\n}</textarea></div>');
			$(document.createElement('h3')).text('DemoTables.cs').appendTo(div);
			$(div).append('<div class="dp-highlighter"><div class="bar"><div class="tools"><a href="#" onclick="dp.sh.Toolbar.Command(\'ViewSource\',this);return false;">view plain</a><a href="#" onclick="dp.sh.Toolbar.Command(\'CopyToClipboard\',this);return false;">copy to clipboard</a><a href="#" onclick="dp.sh.Toolbar.Command(\'PrintSource\',this);return false;">print</a><a href="#" onclick="dp.sh.Toolbar.Command(\'About\',this);return false;">?</a></div></div><ol start="1" class="dp-c"><li class="alt"><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""><span><span class="keyword">public</span><span>&nbsp;</span><span class="keyword">class</span><span>&nbsp;DemoTables&nbsp;&nbsp;</span></span></li><li class="alt"><span>{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;DemoTables&nbsp;(){}&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">static</span><span>&nbsp;UserGrid&nbsp;uGrid;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">static</span><span>&nbsp;UserForm&nbsp;uForm;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">public</span><span>&nbsp;</span><span class="keyword">static</span><span>&nbsp;</span><span class="keyword">void</span><span>&nbsp;Execute(Element&nbsp;parent)&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;Div(</span><span class="keyword">null</span><span>,&nbsp;div=&gt;{&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;div.ClassName=<span class="string">"bs-docs-example"</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid=&nbsp;<span class="keyword">new</span><span>&nbsp;UserGrid(div,&nbsp;</span><span class="keyword">new</span><span>&nbsp;UserStore());&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm&nbsp;=&nbsp;<span class="keyword">new</span><span>&nbsp;UserForm(div,&nbsp;GetLevelOptions());&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetCreateButton().Disabled=<span class="keyword">false</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetCreateButton().OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.SelectRow();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetDestroyButton().OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.GetStore().Remove(&nbsp;uGrid.GetSelectedRow().Record&nbsp;);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().OnChange(e=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetSaveButton().Disabled=!uForm.Element().DataChanged();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.OnRowSelected+=(&nbsp;(g,&nbsp;sr)=&gt;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetSaveButton().Disabled=<span class="keyword">true</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">if</span><span>(sr!=</span><span class="keyword">null</span><span>)&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().Load&lt;User&gt;(&nbsp;sr.Record);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetDestroyButton().Disabled=<span class="keyword">false</span><span>;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">else</span><span>&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().Load&lt;User&gt;(&nbsp;<span class="keyword">new</span><span>&nbsp;User());&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetDestroyButton().Disabled=<span class="keyword">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;vo&nbsp;=&nbsp;<span class="keyword">new</span><span>&nbsp;ValidateOptions()&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SetSubmitHandler(&nbsp;form=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;form.LoadTo&lt;User&gt;();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.GetStore().Save(user);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.SelectRow(&nbsp;user.Id);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((r,m)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element=&nbsp;uForm.Element().FindByName&lt;InputElement&gt;(<span class="string">"Name"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Required();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Minlength(6);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Required(<span class="string">"write&nbsp;username"</span><span>);&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Minlength(<span class="string">"min&nbsp;6&nbsp;chars"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((r,m)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element=&nbsp;uForm.Element().FindByName&lt;InputElement&gt;(<span class="string">"Email"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Email();&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Email(<span class="string">"write&nbsp;a&nbsp;valid&nbsp;email&nbsp;address"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((r,m)=&gt;{&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element=&nbsp;uForm.Element().FindByName&lt;InputElement&gt;(<span class="string">"Rating"</span><span>);&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element.AutoNumeric(<span class="keyword">new</span><span>&nbsp;{mDec=0,&nbsp;&nbsp;wEmpty=&nbsp;</span><span class="string">"zero"</span><span>});&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Max(10000);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Min(0);&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().Validate(vo);&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.GetStore().Read();&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">static</span><span>&nbsp;&nbsp;List&lt;RadioItem&gt;&nbsp;GetLevelOptions()&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">return</span><span>&nbsp;&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;List&lt;RadioItem&gt;(&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;RadioItem[]{&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;RadioItem{Text=</span><span class="string">"A"</span><span>,&nbsp;Value=</span><span class="string">"A"</span><span>},&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;RadioItem{Text=</span><span class="string">"B"</span><span>,&nbsp;Value=</span><span class="string">"B"</span><span>},&nbsp;&nbsp;</span></span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="keyword">new</span><span>&nbsp;RadioItem{Text=</span><span class="string">"C"</span><span>,&nbsp;Value=</span><span class="string">"C"</span><span>}&nbsp;&nbsp;</span></span></li><li class=""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class="alt"><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""><span>}&nbsp;&nbsp;</span></li></ol><textarea style="display:none;" class="originalCode">[IgnoreNamespace]\npublic class DemoTables\n{\n\tpublic DemoTables (){}\n\t\n\tstatic UserGrid uGrid;\n\tstatic UserForm uForm;\n\t\n\tpublic static void Execute(Element parent)\n\t{\n\t\tnew Div(null, div=&gt;{\n\t\t\tdiv.ClassName="bs-docs-example";\n\t\t\tuGrid= new UserGrid(div, new UserStore());\n\t\t\tuForm = new UserForm(div, GetLevelOptions());\n\t\t}).AppendTo(parent);\n\t\t\n\t\tuForm.GetCreateButton().Disabled=false;\n\t\t\n\t\tuForm.GetCreateButton().OnClick(evt=&gt;{\n\t\t\tuGrid.SelectRow();\n\t\t});\n\t\t\n\t\tuForm.GetDestroyButton().OnClick(evt=&gt;{\n\t\t\tuGrid.GetStore().Remove( uGrid.GetSelectedRow().Record );\n\t\t});\n\t\t\n\t\tuForm.Element().OnChange(e=&gt;{\n\t\t\tuForm.GetSaveButton().Disabled=!uForm.Element().DataChanged();\n\t\t});\n\t\t\n\t\tuGrid.OnRowSelected+=( (g, sr)=&gt;{\n\t\t\tuForm.GetSaveButton().Disabled=true;\n\t\t\tif(sr!=null)\n\t\t\t{\n\t\t\t\tuForm.Element().Load&lt;User&gt;( sr.Record);\n\t\t\t\tuForm.GetDestroyButton().Disabled=false;\n\t\t\t}\n\t\t\telse\n\t\t\t{\n\t\t\t\tuForm.Element().Load&lt;User&gt;( new User());\n\t\t\t\tuForm.GetDestroyButton().Disabled=true;\n\t\t\t}\n\t\t});\n\t\t\n\t\tvar vo = new ValidateOptions()\n\t\t\t.SetSubmitHandler( form=&gt;{\n\t\t\t\tvar user = form.LoadTo&lt;User&gt;();\n\t\t\t\tuGrid.GetStore().Save(user);\n\t\t\t\tuGrid.SelectRow( user.Id);\n\t\t\t}).AddRule((r,m)=&gt;{\n\t\t\t\tr.Element= uForm.Element().FindByName&lt;InputElement&gt;("Name");\n\t\t\t\tr.Rule.Required();\n\t\t\t\tr.Rule.Minlength(6);\n\t\t\t\tm.Required("write username");\n\t\t\t\tm.Minlength("min 6 chars");\n\t\t\t}).AddRule((r,m)=&gt;{\n\t\t\t\tr.Element= uForm.Element().FindByName&lt;InputElement&gt;("Email");\n\t\t\t\tr.Rule.Email();\n\t\t\t\tm.Email("write a valid email address");\n\t\t\t}).AddRule((r,m)=&gt;{\n\t\t\t\tr.Element= uForm.Element().FindByName&lt;InputElement&gt;("Rating");\n\t\t\t\tr.Element.AutoNumeric(new {mDec=0,  wEmpty= "zero"});\n\t\t\t\tr.Rule.Max(10000);\n\t\t\t\tr.Rule.Min(0);\n\t\t\t});\n\t\t\n\t\tuForm.Element().Validate(vo);\n\t\t\n\t\tuGrid.GetStore().Read();\n\t}\n\t\n\tstatic  List&lt;RadioItem&gt; GetLevelOptions()\n\t{\n\t\treturn \n\t\t\tnew List&lt;RadioItem&gt;(\n\t\t\t\tnew RadioItem[]{\n\t\t\t\tnew RadioItem{Text="A", Value="A"},\n\t\t\t\tnew RadioItem{Text="B", Value="B"},\n\t\t\t\tnew RadioItem{Text="C", Value="C"}\n\t\t\t});\n\t}\n}</textarea></div>');
		})).appendTo(parent);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.User
	var $User = function() {
	};
	$User.createInstance = function() {
		return $User.$ctor();
	};
	$User.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Name = null;
		$this.Address = null;
		$this.City = null;
		$this.Email = null;
		$this.DoB = new Date(0);
		$this.IsActive = false;
		$this.Level = null;
		$this.UserName = null;
		$this.Password = null;
		$this.Rating = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.UserForm
	var $UserForm = function(parent, levelOptions) {
		this.$f = null;
		Cayita.UI.Form.call(this, null);
		this.$f = this.element$1();
		this.$f.className = 'form-horizontal';
		$(this.$f).append('<style>.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  </style>');
		new Cayita.UI.Div.$ctor1(this.$f, function(tb) {
			tb.className = 'nav';
			new Cayita.UI.IconButton(tb, function(bt, ibn) {
				ibn.className = 'icon-file icon-large';
				bt.id = 'btn-create';
				bt.disabled = true;
			});
			new Cayita.UI.IconButton(tb, function(bt1, ibn1) {
				ibn1.className = 'icon-save icon-large';
				bt1.id = 'btn-save';
				$(bt1).attr('type', 'submit');
				bt1.disabled = true;
			});
			new Cayita.UI.IconButton(tb, function(bt2, ibn2) {
				ibn2.className = 'icon-remove icon-large';
				bt2.id = 'btn-destroy';
				bt2.disabled = true;
			});
		});
		new Cayita.UI.InputText.$ctor2(this.$f, function(e) {
			e.name = 'Id';
			$(e).hide();
			$(e).attr('data-type', 'numeric');
		});
		new Cayita.UI.TextField(this.$f, function(l, e1) {
			$(l).text('Name');
			e1.name = 'Name';
		});
		new Cayita.UI.TextField(this.$f, function(l1, e2) {
			$(l1).text('City');
			e2.name = 'City';
		});
		new Cayita.UI.TextField(this.$f, function(l2, e3) {
			$(l2).text('Address');
			e3.name = 'Address';
		});
		new Cayita.UI.TextField(this.$f, function(l3, e4) {
			$(l3).text('Birthday');
			e4.name = 'DoB';
			cayita.fn.datepicker(e4, { dateFormat: 'dd.mm.yy' });
		});
		new Cayita.UI.TextField(this.$f, function(l4, e5) {
			$(l4).text('Email');
			e5.name = 'Email';
		});
		new Cayita.UI.TextField(this.$f, function(l5, e6) {
			$(l5).text('Rating');
			e6.name = 'Rating';
			cayita.fn.autoNumeric(e6, null);
		});
		new Cayita.UI.RadioField(this.$f, 'Level', 'Level', levelOptions, true);
		new Cayita.UI.CheckboxField(this.$f, function(l6, e7) {
			$(l6).text('Is Active?');
			e7.name = 'IsActive';
		});
		$('label[class=\'control-label\']', this.$f).css('width', '80px');
		this.appendTo(parent);
	};
	$UserForm.prototype = {
		getSaveButton: function() {
			return Cayita.UI.Ext.findById(Element).call(null, this.$f, 'btn-save');
		},
		getDestroyButton: function() {
			return Cayita.UI.Ext.findById(Element).call(null, this.$f, 'btn-destroy');
		},
		getCreateButton: function() {
			return Cayita.UI.Ext.findById(Element).call(null, this.$f, 'btn-create');
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.UserGrid
	var $UserGrid = function(parent, store) {
		$UserGrid.$ctor1.call(this, parent, store, $UserGrid.defineColumns());
	};
	$UserGrid.prototype = {
		getStore$1: function() {
			return this.$us;
		}
	};
	$UserGrid.$ctor1 = function(parent, store, columns) {
		this.$us = null;
		ss.makeGenericType(Cayita.UI.HtmlGrid$1, [$User]).$ctor1.call(this, null, store, columns);
		this.appendTo(parent);
		this.$us = store;
	};
	$UserGrid.$ctor1.prototype = $UserGrid.prototype;
	$UserGrid.defineColumns = function() {
		var columns = [];
		var $t1 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t1.header = (new Cayita.UI.TableCell.$ctor1(function(c) {
			$(c).text('Name');
		})).element$1();
		$t1.value = function(f) {
			return (new Cayita.UI.TableCell.$ctor1(function(c1) {
				$(c1).text(f.Name);
			})).element$1();
		};
		ss.add(columns, $t1);
		var $t2 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t2.header = (new Cayita.UI.TableCell.$ctor1(function(c2) {
			$(c2).text('City');
		})).element$1();
		$t2.value = function(f1) {
			return (new Cayita.UI.TableCell.$ctor1(function(c3) {
				$(c3).text(f1.City);
			})).element$1();
		};
		ss.add(columns, $t2);
		var $t3 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t3.header = (new Cayita.UI.TableCell.$ctor1(function(c4) {
			$(c4).text('Address');
		})).element$1();
		$t3.value = function(f2) {
			return (new Cayita.UI.TableCell.$ctor1(function(c5) {
				$(c5).text(f2.Address);
			})).element$1();
		};
		ss.add(columns, $t3);
		var $t4 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t4.header = (new Cayita.UI.TableCell.$ctor1(function(c6) {
			$(c6).text('Birthday');
		})).element$1();
		$t4.value = function(f3) {
			return (new Cayita.UI.TableCell.$ctor1(function(c7) {
				$(c7).text(ss.formatDate(f3.DoB, 'dd.MM.yyyy'));
			})).element$1();
		};
		ss.add(columns, $t4);
		var $t5 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t5.header = (new Cayita.UI.TableCell.$ctor1(function(c8) {
			$(c8).text('Email');
		})).element$1();
		$t5.value = function(f4) {
			return (new Cayita.UI.TableCell.$ctor1(function(c9) {
				$(c9).text(f4.Email);
			})).element$1();
		};
		ss.add(columns, $t5);
		var $t6 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t6.header = (new Cayita.UI.TableCell.$ctor1(function(c10) {
			$(c10).text('Rating');
		})).element$1();
		$t6.value = function(f5) {
			return (new Cayita.UI.TableCell.$ctor1(function(c11) {
				$(c11).text(f5.Rating.toString());
				cayita.fn.autoNumeric(c11, { mDec: 0 });
				c11.style.textAlign = 'center';
			})).element$1();
		};
		ss.add(columns, $t6);
		var $t7 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t7.header = (new Cayita.UI.TableCell.$ctor1(function(c12) {
			$(c12).text('Level');
		})).element$1();
		$t7.value = function(f6) {
			return (new Cayita.UI.TableCell.$ctor1(function(c13) {
				$(c13).text(f6.Level);
				c13.style.color = ((f6.Level === 'A') ? 'green' : ((f6.Level === 'B') ? 'orange' : 'red'));
				c13.style.textAlign = 'center';
			})).element$1();
		};
		ss.add(columns, $t7);
		var $t8 = ss.makeGenericType(Cayita.UI.TableColumn$1, [$User]).$ctor();
		$t8.header = (new Cayita.UI.TableCell.$ctor1(function(c14) {
			$(c14).text('Active ?');
		})).element$1();
		$t8.value = function(f7) {
			return (new Cayita.UI.TableCell.$ctor1(function(c15) {
				c15.style.textAlign = 'center';
				$(c15).append((new Cayita.UI.Icon.$ctor1(c15, function(i) {
					i.className = (f7.IsActive ? 'icon-ok-circle' : 'icon-ban-circle');
				})).element());
			})).element$1();
		};
		$t8.afterCellCreate = function(f8, row) {
			row.style.color = (f8.IsActive ? 'black' : 'grey');
			$(row).addClass(((f8.Rating >= 10000) ? 'success' : ((f8.Rating <= 5000) ? 'warning' : '')));
		};
		ss.add(columns, $t8);
		return columns;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.DemoTables.UserStore
	var $UserStore = function() {
		ss.makeGenericType(Cayita.Data.Store$1, [$User]).call(this);
		this.setReadApi(function(api) {
			api.url = 'json/userResponse.json';
			api.converters['DoB'] = function(u) {
				return cayita.fn.convertToDate(u.DoB);
				// convert from  "DoB":"\/Date(13651200000+0000)\/" into date 
			};
		});
	};
	$UserStore.prototype = {
		save: function(record) {
			if (record.Id === 0) {
				record.Id = --$UserStore.$id;
				this.add(record);
			}
			else {
				this.replace(record);
			}
		}
	};
	ss.registerClass(global, 'Customer', $Customer);
	ss.registerClass(global, 'CustomerGrid', $CustomerGrid, ss.makeGenericType(Cayita.UI.HtmlGrid$1, [$Customer]));
	ss.registerClass(global, 'CustomerStore', $CustomerStore, ss.makeGenericType(Cayita.Data.Store$1, [$Customer]), ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList);
	ss.registerClass(global, 'DemoTables', $DemoTables);
	ss.registerClass(global, 'User', $User);
	ss.registerClass(global, 'UserForm', $UserForm, Cayita.UI.Form);
	ss.registerClass(global, 'UserGrid', $UserGrid, ss.makeGenericType(Cayita.UI.HtmlGrid$1, [$User]));
	ss.registerClass(global, 'UserStore', $UserStore, ss.makeGenericType(Cayita.Data.Store$1, [$User]), ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList);
	$UserStore.$id = 0;
	$DemoTables.$uGrid = null;
	$DemoTables.$cGrid = null;
	$DemoTables.$uForm = null;
})();
