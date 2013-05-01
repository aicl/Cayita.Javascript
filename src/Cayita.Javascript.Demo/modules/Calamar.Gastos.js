(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.ModuloGastos.MainModule
	var $MainModule = function() {
		this.$sq = 0;
		this.$1$SearchDivField = null;
		this.$1$FormDivField = null;
		this.$1$GridDivField = null;
		this.$1$FormField = null;
		this.$1$GridGastosField = null;
		this.$1$StoreGastosField = null;
		this.$1$SelectedGastoField = null;
		this.$1$ColumnsField = null;
		this.$1$BNewField = null;
		this.$1$BDeleteField = null;
		this.$1$BListField = null;
		this.$1$StoreConceptosField = null;
		this.$1$StoreFuentesField = null;
		this.$cbConcepto = null;
		this.$cbFuente = null;
	};
	$MainModule.prototype = {
		get_$searchDiv: function() {
			return this.$1$SearchDivField;
		},
		set_$searchDiv: function(value) {
			this.$1$SearchDivField = value;
		},
		get_$formDiv: function() {
			return this.$1$FormDivField;
		},
		set_$formDiv: function(value) {
			this.$1$FormDivField = value;
		},
		get_$gridDiv: function() {
			return this.$1$GridDivField;
		},
		set_$gridDiv: function(value) {
			this.$1$GridDivField = value;
		},
		get_$form: function() {
			return this.$1$FormField;
		},
		set_$form: function(value) {
			this.$1$FormField = value;
		},
		get_$gridGastos: function() {
			return this.$1$GridGastosField;
		},
		set_$gridGastos: function(value) {
			this.$1$GridGastosField = value;
		},
		get_$storeGastos: function() {
			return this.$1$StoreGastosField;
		},
		set_$storeGastos: function(value) {
			this.$1$StoreGastosField = value;
		},
		get_$selectedGasto: function() {
			return this.$1$SelectedGastoField;
		},
		set_$selectedGasto: function(value) {
			this.$1$SelectedGastoField = value;
		},
		get_$columns: function() {
			return this.$1$ColumnsField;
		},
		set_$columns: function(value) {
			this.$1$ColumnsField = value;
		},
		get_$bNew: function() {
			return this.$1$BNewField;
		},
		set_$bNew: function(value) {
			this.$1$BNewField = value;
		},
		get_$bDelete: function() {
			return this.$1$BDeleteField;
		},
		set_$bDelete: function(value) {
			this.$1$BDeleteField = value;
		},
		get_$bList: function() {
			return this.$1$BListField;
		},
		set_$bList: function(value) {
			this.$1$BListField = value;
		},
		get_$storeConceptos: function() {
			return this.$1$StoreConceptosField;
		},
		set_$storeConceptos: function(value) {
			this.$1$StoreConceptosField = value;
		},
		get_$storeFuentes: function() {
			return this.$1$StoreFuentesField;
		},
		set_$storeFuentes: function(value) {
			this.$1$StoreFuentesField = value;
		},
		$defineStores: function() {
			this.set_$storeConceptos(new (ss.makeGenericType(Cayita.Data.Store$1, [Calamar.Model.Concepto]))());
			this.get_$storeConceptos().setReadApi(function(api) {
				api.url = 'json/conceptoResponse.json';
			});
			this.set_$storeFuentes(new (ss.makeGenericType(Cayita.Data.Store$1, [Calamar.Model.Fuente]))());
			this.get_$storeFuentes().setReadApi(function(api1) {
				api1.url = 'json/fuenteResponse.json';
			});
			this.set_$storeGastos(new (ss.makeGenericType(Cayita.Data.Store$1, [Calamar.Model.Gasto]))());
			this.get_$storeGastos().setReadApi(function(api2) {
				api2.url = 'json/gastoResponse.json';
			});
		},
		$paint: function(parent) {
			new Cayita.UI.Div.$ctor2(parent, function(div) {
				div.className = 'span6 offset2 well';
				$(div).hide();
			});
			this.set_$searchDiv(new Cayita.UI.Div.$ctor2(null, ss.mkdel(this, function(searchdiv) {
				searchdiv.className = 'span6 offset2 nav';
				var inputFecha = (new Cayita.UI.InputText.$ctor2(searchdiv, function(ip) {
					ip.className = 'input-medium search-query';
					ip.setAttribute('data-mask', '99.99.9999');
					$(ip).attr('placeholder', 'dd.mm.aaaa');
				})).element$2();
				new Cayita.UI.IconButton(searchdiv, ss.mkdel(this, function(abn, ibn) {
					ibn.className = 'icon-search icon-large';
					$(abn).click(ss.mkdel(this, function(evt) {
						if (!cayita.fn.isDateFormatted(inputFecha.value)) {
							Cayita.UI.Alert.error$1(this.get_$searchDiv().element$1(), 'Digite una fecha valida', false);
							return;
						}
						this.$loadGastos(cayita.fn.toServerDate(inputFecha.value));
					}));
				}));
				this.set_$bNew(new Cayita.UI.IconButton(searchdiv, ss.mkdel(this, function(abn1, ibn1) {
					ibn1.className = 'icon-plus-sign icon-large';
					$(abn1).click(ss.mkdel(this, function(evt1) {
						this.get_$formDiv().fadeIn();
						this.get_$gridDiv().fadeOut();
						this.get_$form().element$1().reset();
						this.get_$bDelete().element$1().disabled = true;
					}));
				})));
				this.set_$bDelete(new Cayita.UI.IconButton(searchdiv, ss.mkdel(this, function(abn2, ibn2) {
					ibn2.className = 'icon-remove-sign icon-large';
					abn2.disabled = true;
					$(abn2).click(ss.mkdel(this, function(evt2) {
						this.$removeRow();
					}));
				})));
				this.set_$bList(new Cayita.UI.IconButton(searchdiv, ss.mkdel(this, function(abn3, ibn3) {
					ibn3.className = 'icon-reorder icon-large';
					abn3.disabled = true;
					$(abn3).click(ss.mkdel(this, function(evt3) {
						this.get_$formDiv().hide();
						this.get_$gridDiv().fadeIn();
						abn3.disabled = true;
					}));
				})));
			})));
			this.get_$searchDiv().appendTo$1(parent);
			this.set_$formDiv(new Cayita.UI.Div.$ctor2(null, ss.mkdel(this, function(formdiv) {
				formdiv.className = 'span6 offset2 well';
				this.set_$form(new Cayita.UI.Form.$ctor1(formdiv, ss.mkdel(this, function(f) {
					f.className = 'form-horizontal';
					var inputId = new Cayita.UI.InputText.$ctor2(f, function(e) {
						e.name = 'Id';
						$(e).hide();
					});
					var $t2 = ss.makeGenericType(Cayita.UI.SelectField$1, [Calamar.Model.Concepto]);
					var $t3 = function(e1) {
						e1.name = 'IdConcepto';
						e1.className = 'span12';
					};
					var $t4 = this.get_$storeConceptos();
					var $t5 = function(fc) {
						return (new Cayita.UI.HtmlOption(function(opt) {
							opt.value = fc.Id.toString();
							opt.text = fc.Nombre;
						})).element$1();
					};
					var $t1 = ss.makeGenericType(Cayita.UI.SelectedOption$1, [Calamar.Model.Concepto]).$ctor();
					$t1.option = (new Cayita.UI.HtmlOption(function(o) {
						o.value = '';
						o.text = 'Select Concepto ...';
					})).element$1();
					this.$cbConcepto = new $t2(f, $t3, $t4, $t5, $t1);
					var $t7 = ss.makeGenericType(Cayita.UI.SelectField$1, [Calamar.Model.Fuente]);
					var $t8 = function(e2) {
						e2.name = 'IdFuente';
						e2.className = 'span12';
					};
					var $t9 = this.get_$storeFuentes();
					var $t10 = function(fc1) {
						return (new Cayita.UI.HtmlOption(function(opt1) {
							opt1.value = fc1.Id.toString();
							opt1.text = fc1.Nombre;
						})).element$1();
					};
					var $t6 = ss.makeGenericType(Cayita.UI.SelectedOption$1, [Calamar.Model.Fuente]).$ctor();
					$t6.option = (new Cayita.UI.HtmlOption(function(o1) {
						o1.value = '';
						o1.text = 'Select Fuente ...';
					})).element$1();
					this.$cbFuente = new $t7(f, $t8, $t9, $t10, $t6);
					var fieldValor = new Cayita.UI.TextField.$ctor1(f, function(field) {
						field.className = 'span12';
						field.name = 'Valor';
						$(field).attr('placeholder', '$$$$$$$$$$');
						cayita.fn.autoNumeric(field, null);
					});
					new Cayita.UI.TextField.$ctor1(f, function(field1) {
						field1.className = 'span12';
						field1.name = 'Beneficiario';
						$(field1).attr('placeholder', 'Pagado a ....');
					});
					new Cayita.UI.TextField.$ctor1(f, function(field2) {
						field2.className = 'span12';
						field2.name = 'Descripcion';
						$(field2).attr('placeholder', 'Descripcion');
					});
					var bt = new Cayita.UI.SubmitButton.$ctor1(f, function(b) {
						$(b).text('Guardar');
						$(b).button.defaults.loadingText = ' Guardando ...';
						$(b).addClass('btn-info btn-block');
					});
					var vo = Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.addRule(Cayita.Plugins.ValidateOptions.setSubmitHandler(Cayita.Plugins.ValidateOptions.$ctor(), ss.mkdel(this, function(form) {
						bt.showLoadingText();
						var result = Calamar.Model.Gasto.$ctor();
						cayita.fn.loadTo(form, result);
						console.log('guardando', cayita.fn.serialize(form), result);
						if (ss.isNullOrEmptyString(inputId.value())) {
							this.$appendRow(result);
						}
						else {
							try {
								this.$updateRow(result);
							}
							catch ($t11) {
								var e3 = ss.Exception.wrap($t11);
								console.log('ex ', e3);
							}
						}
						form.reset();
						bt.resetLoadingText();
					})), function(rule, msg) {
						rule.element = fieldValor.textElement();
						Cayita.Plugins.Rule.required(rule.rule);
						Cayita.Plugins.Message.required(msg, 'Digite el valor del gasto');
					}), ss.mkdel(this, function(rule1, msg1) {
						rule1.element = this.$cbConcepto.selectElement();
						Cayita.Plugins.Rule.required(rule1.rule);
						Cayita.Plugins.Message.required(msg1, 'Seleccione el concepto');
					})), ss.mkdel(this, function(rule2, msg2) {
						rule2.element = this.$cbFuente.selectElement();
						Cayita.Plugins.Rule.required(rule2.rule);
						Cayita.Plugins.Message.required(msg2, 'Seleccione al fuente del pago');
					}));
					$(f).validate(vo);
				})));
			})));
			this.get_$formDiv().appendTo$1(parent);
			this.set_$gridDiv(new Cayita.UI.Div.$ctor2(null, ss.mkdel(this, function(gdiv) {
				gdiv.className = 'span10';
				this.set_$gridGastos(new (ss.makeGenericType(Cayita.UI.HtmlGrid$1, [Calamar.Model.Gasto]).$ctor1)(gdiv, this.get_$storeGastos(), this.get_$columns()));
				$(gdiv).hide();
			})));
			this.get_$gridDiv().appendTo$1(parent);
		},
		$loadGastos: function(date) {
			//StoreGastos.Read().Always(a=>{
			this.get_$formDiv().hide();
			this.get_$gridDiv().fadeIn();
			//});
		},
		$removeRow: function() {
			this.get_$storeGastos().remove(this.get_$gridGastos().getSelectedRow().record);
			this.get_$bDelete().element$1().disabled = true;
			this.get_$bList().element$1().disabled = true;
			this.get_$formDiv().hide();
			this.get_$gridDiv().fadeIn();
		},
		$appendRow: function(data) {
			data.Id = ++this.$sq;
			this.get_$storeGastos().add(data);
			this.get_$bDelete().element$1().disabled = true;
			this.get_$bList().element$1().disabled = false;
		},
		$updateRow: function(data) {
			this.get_$storeGastos().replace(data);
			this.get_$bList().element$1().disabled = true;
			this.get_$formDiv().hide();
			this.get_$gridDiv().fadeIn();
		},
		$gridEvents: function() {
			this.get_$gridGastos().add_onRowSelected(ss.mkdel(this, function(gd, sr) {
				this.get_$bDelete().element$1().disabled = false;
				this.get_$bList().element$1().disabled = false;
				this.get_$form().element$1().reset();
				if (ss.isValue(sr)) {
					cayita.fn.loadForm(this.get_$form().element$1(), sr.record);
				}
				this.get_$gridDiv().hide();
				$(this.get_$formDiv().element$1()).fadeIn();
			}));
		},
		$defineTableColumns: function() {
			this.set_$columns([]);
			var $t2 = this.get_$columns();
			var $t1 = ss.makeGenericType(Cayita.UI.TableColumn$1, [Calamar.Model.Gasto]).$ctor();
			$t1.header = (new Cayita.UI.TableCell.$ctor1(function(cell) {
				new Cayita.UI.Anchor.$ctor3(cell, function(a) {
					$(a).text('Concepto');
				});
			})).element$1();
			$t1.value = ss.mkdel(this, function(f) {
				return (new Cayita.UI.TableCell.$ctor1(ss.mkdel(this, function(cell1) {
					new Cayita.UI.Anchor.$ctor3(cell1, ss.mkdel(this, function(a1) {
						$(a1).text(Enumerable.from(this.get_$storeConceptos()).firstOrDefault(function(q) {
							return ss.referenceEquals(q.Id.toString(), f.IdConcepto.toString());
						}, ss.getDefaultValue(Calamar.Model.Concepto)).Nombre);
					}));
				}))).element$1();
			});
			ss.add($t2, $t1);
			var $t4 = this.get_$columns();
			var $t3 = ss.makeGenericType(Cayita.UI.TableColumn$1, [Calamar.Model.Gasto]).$ctor();
			$t3.header = (new Cayita.UI.TableCell.$ctor1(function(cell2) {
				$(cell2).text('Fuente');
			})).element$1();
			$t3.value = ss.mkdel(this, function(f1) {
				return (new Cayita.UI.TableCell.$ctor1(ss.mkdel(this, function(cell3) {
					$(cell3).text(Enumerable.from(this.get_$storeFuentes()).firstOrDefault(function(q1) {
						return ss.referenceEquals(q1.Id.toString(), f1.IdFuente.toString());
					}, ss.getDefaultValue(Calamar.Model.Fuente)).Nombre);
				}))).element$1();
			});
			ss.add($t4, $t3);
			var $t6 = this.get_$columns();
			var $t5 = ss.makeGenericType(Cayita.UI.TableColumn$1, [Calamar.Model.Gasto]).$ctor();
			$t5.header = (new Cayita.UI.TableCell.$ctor1(function(cell4) {
				$(cell4).text('Valor');
				cell4.style.textAlign = 'right';
			})).element$1();
			$t5.value = function(f2) {
				return (new Cayita.UI.TableCell.$ctor1(function(cell5) {
					$(cell5).text(f2.Valor.toString());
					cayita.fn.autoNumeric(cell5, null);
				})).element$1();
			};
			ss.add($t6, $t5);
			var $t8 = this.get_$columns();
			var $t7 = ss.makeGenericType(Cayita.UI.TableColumn$1, [Calamar.Model.Gasto]).$ctor();
			$t7.header = (new Cayita.UI.TableCell.$ctor1(function(cell6) {
				$(cell6).text('Pagado a');
			})).element$1();
			$t7.value = function(f3) {
				return (new Cayita.UI.TableCell.$ctor1(function(cell7) {
					$(cell7).text(f3.Beneficiario);
				})).element$1();
			};
			ss.add($t8, $t7);
			var $t10 = this.get_$columns();
			var $t9 = ss.makeGenericType(Cayita.UI.TableColumn$1, [Calamar.Model.Gasto]).$ctor();
			$t9.header = (new Cayita.UI.TableCell.$ctor1(function(cell8) {
				$(cell8).text('Detalle');
			})).element$1();
			$t9.value = function(f4) {
				return (new Cayita.UI.TableCell.$ctor1(function(cell9) {
					$(cell9).text(f4.Descripcion);
				})).element$1();
			};
			ss.add($t10, $t9);
		}
	};
	$MainModule.execute = function(parent) {
		var m = new $MainModule();
		m.$defineStores();
		m.$defineTableColumns();
		m.$paint(parent);
		m.get_$storeConceptos().read(null, true);
		m.get_$storeFuentes().read(null, true);
		m.$gridEvents();
	};
	ss.registerClass(global, 'MainModule', $MainModule);
})();
