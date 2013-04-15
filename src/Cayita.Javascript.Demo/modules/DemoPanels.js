(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Modals.DemoPanels
	var $DemoPanels = function() {
	};
	$DemoPanels.execute = function(parent) {
		$(parent).append(Cayita.UI.StringExtensions.header('Panels', 2));
		(new Cayita.UI.Div.$ctor2(null, function(div) {
			div.className = 'bs-docs-example';
			div.style.paddingLeft = '40px';
			$(div).append(Cayita.UI.Div.createContainer$1(div, function(cf) {
				Cayita.UI.Div.createRow$1(cf, function(rf) {
					new Cayita.UI.Div.$ctor2(rf, function(ld) {
						ld.className = 'span5';
						var apps = (new Cayita.UI.Panel()).caption('Apps').closable(false).resizable(false);
						new Cayita.UI.Div(function(id) {
							id.className = 'c-icons';
							$(id).append('<style>img {height: 40px;}  .c-icon {height: 95px;}</style>');
							var $t1 = $Modals_App.getApps();
							for (var $t2 = 0; $t2 < $t1.length; $t2++) {
								var app = { $: $t1[$t2] };
								new Cayita.UI.Anchor.$ctor3(id, ss.mkdel({ app: app }, function(a) {
									a.className = 'c-icon';
									new Cayita.UI.Image.$ctor2(a, ss.mkdel({ app: this.app }, function(img) {
										img.src = this.app.$.get_icon();
										img.className = 'img-rounded';
									}));
									$(a).on('click', ss.mkdel({ app: this.app }, function(ev) {
										ev.preventDefault();
										Alertify.log.info(this.app.$.get_tittle(), 5000);
									}));
									new Cayita.UI.Span.$ctor2(a, ss.mkdel({ app: this.app }, function(sp) {
										sp.className = 'c-icon-label';
										sp.innerHTML = this.app.$.get_tittle();
									}));
								}));
							}
							apps.append$4(id);
						});
						apps.render(ld);
						var pn = (new Cayita.UI.Panel()).caption('Demo Panel').closable(false).resizable(false).draggable(false);
						new Cayita.UI.Button(function(bt) {
							$(bt).text('Grey background');
							$(bt).on('click', function(evt) {
								pn.body().style.backgroundColor = 'grey';
							});
							pn.append$4(bt);
						});
						new Cayita.UI.Button(function(bt1) {
							$(bt1).text('White background');
							$(bt1).on('click', function(evt1) {
								pn.body().style.backgroundColor = 'white';
							});
							pn.append$4(bt1);
						});
						new Cayita.UI.Button(function(bt2) {
							$(bt2).text('Collapse');
							$(bt2).on('click', function(evt2) {
								pn.collapse();
							});
							pn.append$4(bt2);
						});
						pn.render(ld);
					});
					new Cayita.UI.Div.$ctor2(rf, function(ld1) {
						ld1.className = 'span5';
						var coyote = (new Cayita.UI.Panel()).caption('El Coyote').closable(false).render(ld1).draggable(false).resizable(false);
						new Cayita.UI.Div(function(d) {
							d.className = 'span2';
							new Cayita.UI.Image.$ctor2(d, function(i) {
								i.src = 'img/coyote.jpg';
								i.style.height = '20%';
							});
							coyote.append$4(d);
						});
						new Cayita.UI.Div(function(d1) {
							d1.className = 'span10';
							$(d1).append('<i><b>El <a href=\'https://es.wikipedia.org/wiki/Coyote\' title=\'Coyote\' target=\'_blank\'>Coyote</a> y el <a href=\'https://es.wikipedia.org/wiki/Geococcyx_californianus\' title=\'Geococcyx californianus\' target=\'_blank\'>Correcaminos</a></b></i> (<i><b>Wile E. Coyote</b> and the <b>Road Runner</b></i>) son los personajes de una serie <a href=\'https://es.wikipedia.org/wiki/Estados_Unidos\' title=\'Estados Unidos\' target=\'_blank\'>estadounidense</a> de <a href=\'https://es.wikipedia.org/wiki/Dibujos_animados\' title=\'Dibujos animados\' target=\'_blank\'>dibujos animados</a> creada en el año de <a href=\'https://es.wikipedia.org/wiki/1949\' title=\'1949\' target=\'_blank\'>1949</a> por el animador <a href=\'https://es.wikipedia.org/wiki/Chuck_Jones\' title=\'Chuck Jones\' target=\'_blank\'>Chuck Jones</a> para <a href=\'https://es.wikipedia.org/wiki/Warner_Brothers\' title=\'Warner Brothers\' target=\'_blank\'>Warner Brothers</a>. Chuck Jones se inspiró para crear a estos personajes en un libro de <a href=\'https://es.wikipedia.org/wiki/Mark_Twain\' title=\'Mark Twain\' target=\'_blank\'>Mark Twain</a>, titulado <i>Roughin It</i>, en el que Twain denotaba que los coyotes hambrientos podrían cazar un correcaminos.<br/><a href=\'https://es.wikipedia.org/wiki/El_Coyote_y_el_Correcaminos\' title=\'Coyote\' target=\'_blank\'>El Coyote (wikipedia)</a> ');
							coyote.append$4(d1);
						});
						var tbp = (new Cayita.UI.Panel()).caption('Table').closable(false).draggable(false).resizable(false);
						new Cayita.UI.HtmlTable.$ctor1(function(t) {
							t.className = 'table table-striped table-hover table-condensed';
							new Cayita.UI.TableHeader.$ctor1(t, function(h) {
								new Cayita.UI.TableRow.$ctor1(h, function(tr) {
									new Cayita.UI.TableCell.$ctor3(tr, function(td) {
										$(td).text('Title');
									});
									new Cayita.UI.TableCell.$ctor3(tr, function(td1) {
										$(td1).text('URL');
									});
								});
							});
							var $t3 = $Modals_App.getApps();
							for (var $t4 = 0; $t4 < $t3.length; $t4++) {
								var app1 = { $: $t3[$t4] };
								new Cayita.UI.TableRow.$ctor1(t, ss.mkdel({ app1: app1 }, function(tr1) {
									new Cayita.UI.TableCell.$ctor3(tr1, ss.mkdel({ app1: this.app1 }, function(td2) {
										$(td2).text(this.app1.$.get_tittle());
									}));
									new Cayita.UI.TableCell.$ctor3(tr1, ss.mkdel({ app1: this.app1 }, function(td3) {
										$(td3).text(this.app1.$.get_icon());
									}));
								}));
							}
							tbp.append$4(t);
						});
						tbp.render(ld1);
					});
				});
			}).element());
			$(div).append('');
		})).appendTo$1(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div1) {
			div1.className = 'bs-docs-example';
			var i1 = 1;
			new Cayita.UI.Button.$ctor2(div1, function(bt3) {
				$(bt3).text('Window I');
				$(bt3).on('click', function(evt3) {
					(new Cayita.UI.Panel()).caption('Window ' + (i1++).toString()).left((i1 * 5).toString() + 'px').top((i1 * 15).toString() + 'px').width('300px').height('100px').overlay(true).render(null);
				});
			});
			$(div1).append('');
		})).appendTo$1(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div2) {
			div2.className = 'bs-docs-example';
			new Cayita.UI.Button.$ctor2(div2, function(bt4) {
				$(bt4).text('Window II');
				$(bt4).on('click', function(evt4) {
					(new Cayita.UI.Panel()).caption('Custom Close Icon and Handler').overlay(true).left('20px').top('200px').width('auto').closeIconClass('icon-th-large').closable(true).closeIconHandler(function(p) {
						p.caption('Icon Close Changed !!! ');
						p.closeIconClass('icon-remove-circle');
						p.closeIconHandler(function(pn1) {
							pn1.close();
						});
						p.height('400px');
					}).onCloseHandler(function(p1) {
						Alertify.log.info(Cayita.UI.StringExtensions.header('panel closed ', 3).outerHTML, 5000);
					}).append$3(new Cayita.UI.Button(function(b) {
						$(b).text('Click me');
						b.style.width = '100%';
						b.style.height = '100%';
						$(b).on('click', function(ev1) {
							Alertify.log.info('button clicked!!!', 5000);
						});
					})).render(null);
				});
			});
			$(div2).append('');
		})).appendTo$1(parent);
		(new Cayita.UI.Div.$ctor2(null, function(div3) {
			div3.className = 'bs-docs-example';
			new Cayita.UI.Button.$ctor2(div3, function(bt5) {
				$(bt5).text('Window III');
				$(bt5).on('click', function(evt5) {
					var error = new Cayita.UI.Paragraph.$ctor1(function(p2) {
						p2.style.color = 'red';
						$(p2).append((new Cayita.UI.Icon.$ctor1(function(i2) {
							i2.className = 'icon-minus-sign';
							i2.style.marginTop = '8px';
							i2.style.marginRight = '8px';
						})).element());
						$(p2).append(' panel was closed ');
					});
					var pn2 = (new Cayita.UI.Panel()).caption('No Closable No Collapsible').overlay(true).left('30px').top('400px').width('auto').closable(false).collapsible(false).onCloseHandler(function(p3) {
						error.logInfo(5000);
					});
					pn2.append$3(new Cayita.UI.Button(function(b1) {
						$(b1).text('Click me');
						b1.style.width = '100%';
						b1.style.height = '100%';
						$(b1).on('click', function(be) {
							pn2.closable(true);
							pn2.collapsible(true);
							pn2.caption('Now Closable and Collapsible');
							b1.disabled = true;
						});
					}));
					pn2.render(null);
				});
			});
			$(div3).append('');
		})).appendTo$1(parent);
		;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Modals.App
	var $Modals_App = function() {
		this.$1$TittleField = null;
		this.$1$IconField = null;
	};
	$Modals_App.prototype = {
		get_tittle: function() {
			return this.$1$TittleField;
		},
		set_tittle: function(value) {
			this.$1$TittleField = value;
		},
		get_icon: function() {
			return this.$1$IconField;
		},
		set_icon: function(value) {
			this.$1$IconField = value;
		}
	};
	$Modals_App.getApps = function() {
		var $t1 = [];
		var $t2 = new $Modals_App();
		$t2.set_tittle('Calculator');
		$t2.set_icon('img/calculator.png');
		ss.add($t1, $t2);
		var $t3 = new $Modals_App();
		$t3.set_tittle('Control Panel');
		$t3.set_icon('img/control.png');
		ss.add($t1, $t3);
		var $t4 = new $Modals_App();
		$t4.set_tittle('Firewall Settings');
		$t4.set_icon('img/firewall.png');
		ss.add($t1, $t4);
		var $t5 = new $Modals_App();
		$t5.set_tittle('Spreadsheet');
		$t5.set_icon('img/calc.png');
		ss.add($t1, $t5);
		var $t6 = new $Modals_App();
		$t6.set_tittle('Mail');
		$t6.set_icon('img/mail.png');
		ss.add($t1, $t6);
		var $t7 = new $Modals_App();
		$t7.set_tittle('Jack Sparrow Navigator');
		$t7.set_icon('img/web.png');
		ss.add($t1, $t7);
		var $t8 = new $Modals_App();
		$t8.set_tittle('MonoDevelop');
		$t8.set_icon('img/monodevelop.png');
		ss.add($t1, $t8);
		var $t9 = new $Modals_App();
		$t9.set_tittle('Tomboy');
		$t9.set_icon('img/tomboy.png');
		ss.add($t1, $t9);
		var $t10 = new $Modals_App();
		$t10.set_tittle('Skype');
		$t10.set_icon('img/skype.png');
		ss.add($t1, $t10);
		var a = $t1;
		return a;
	};
	ss.registerClass(global, 'DemoPanels', $DemoPanels);
	ss.registerClass(global, 'Modals.App', $Modals_App);
})();
