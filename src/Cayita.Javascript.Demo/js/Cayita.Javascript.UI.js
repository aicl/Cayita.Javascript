(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Plugins.Message
	var $Message = function() {
	};
	$Message.createInstance = function() {
		return $Message.$ctor();
	};
	$Message.remote = function($this, message) {
		$this.msg.remote = message;
		return $this;
	};
	$Message.required = function($this, message) {
		$this.msg.required = message;
		return $this;
	};
	$Message.email = function($this, message) {
		$this.msg.email = message;
		return $this;
	};
	$Message.url = function($this, message) {
		$this.msg.url = message;
		return $this;
	};
	$Message.date = function($this, message) {
		$this.msg.date = message;
		return $this;
	};
	$Message.dateISO = function($this, message) {
		$this.msg.dateISO = message;
		return $this;
	};
	$Message.number = function($this, message) {
		$this.msg.number = message;
		return $this;
	};
	$Message.digits = function($this, message) {
		$this.msg.digits = message;
		return $this;
	};
	$Message.creditcard = function($this, message) {
		$this.msg.creditcard = message;
		return $this;
	};
	$Message.equalTo = function($this, message) {
		$this.msg.equalTo = message;
		return $this;
	};
	$Message.maxlength = function($this, message) {
		$this.msg.maxlength = message;
		return $this;
	};
	$Message.minlength = function($this, message) {
		$this.msg.minlength = message;
		return $this;
	};
	$Message.max = function($this, message) {
		$this.msg.max = message;
		return $this;
	};
	$Message.min = function($this, message) {
		$this.msg.min = message;
		return $this;
	};
	$Message.range = function($this, message) {
		$this.msg.range = message;
		return $this;
	};
	$Message.rangelength = function($this, message) {
		$this.msg.rangelength = message;
		return $this;
	};
	$Message.$ctor = function() {
		var $this = {};
		$this.msg = {};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Plugins.MessageFor
	var $MessageFor = function() {
	};
	$MessageFor.createInstance = function() {
		return $MessageFor.$ctor();
	};
	$MessageFor.$ctor = function() {
		var $this = {};
		$this.element = null;
		$this.message = null;
		$this.message = $Message.$ctor();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Plugins.Range
	var $Range = function() {
	};
	$Range.createInstance = function() {
		return $Range.$ctor();
	};
	$Range.$ctor = function() {
		var $this = {};
		$this.top = 0;
		$this.bottom = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Plugins.Rule
	var $Rule = function() {
	};
	$Rule.createInstance = function() {
		return $Rule.$ctor();
	};
	$Rule.remote = function($this, url) {
		$this.rl.url = url;
		return $this;
	};
	$Rule.remote$1 = function($this, url, method) {
		$this.rl.url = { url: url, method: method };
		return $this;
	};
	$Rule.required = function($this) {
		$this.rl.required = true;
		return $this;
	};
	$Rule.required$1 = function($this, handler) {
		$this.rl.required = handler;
		return $this;
	};
	$Rule.email = function($this, dependCallback) {
		if (ss.staticEquals(dependCallback, null)) {
			$this.rl = { email: true, required: true };
		}
		else {
			$this.rl.mail = { depends: dependCallback };
		}
		return $this;
	};
	$Rule.url = function($this) {
		$this.rl.url = true;
		return $this;
	};
	$Rule.date = function($this) {
		$this.rl.date = true;
		return $this;
	};
	$Rule.dateISO = function($this) {
		$this.rl.dateISO = true;
		return $this;
	};
	$Rule.number = function($this) {
		$this.rl.number = true;
		return $this;
	};
	$Rule.digits = function($this) {
		$this.rl.digits = true;
		return $this;
	};
	$Rule.creditcard = function($this, dependCallback) {
		if (!ss.staticEquals(dependCallback, null)) {
			$this.rl.creditcard = true;
		}
		else {
			$this.rl.creditcard = { depends: dependCallback };
		}
		return $this;
	};
	$Rule.equalTo = function($this, element) {
		$this.rl.equalTo = '#' + element.id;
		return $this;
	};
	$Rule.maxlength = function($this, value) {
		$this.rl.maxlength = value;
		return $this;
	};
	$Rule.minlength = function($this, value) {
		$this.rl.minlength = value;
		return $this;
	};
	$Rule.max = function($this, value) {
		$this.rl.max = value;
		return $this;
	};
	$Rule.min = function($this, value) {
		$this.rl.min = value;
		return $this;
	};
	$Rule.range = function($this, range) {
		$this.rl.range = [range.bottom, range.top];
		return $this;
	};
	$Rule.rangeLength = function($this, range) {
		$this.rl.rangelength = [range.bottom, range.top];
		return $this;
	};
	$Rule.$ctor = function() {
		var $this = {};
		$this.rl = {};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Plugins.RuleFor
	var $RuleFor = function() {
	};
	$RuleFor.createInstance = function() {
		return $RuleFor.$ctor();
	};
	$RuleFor.$ctor = function() {
		var $this = {};
		$this.element = null;
		$this.rule = null;
		$this.rule = $Rule.$ctor();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Plugins.ValidateOptions
	var $ValidateOptions = function() {
	};
	$ValidateOptions.createInstance = function() {
		return $ValidateOptions.$ctor();
	};
	$ValidateOptions.setErrorClass = function($this, className) {
		$this.errorClass = className;
		return $this;
	};
	$ValidateOptions.setValidClass = function($this, className) {
		$this.validClass = className;
		return $this;
	};
	$ValidateOptions.setSubmitHandler = function($this, handler) {
		$this.submitHandler = handler;
		return $this;
	};
	$ValidateOptions.setHighlightHandler = function($this, handler) {
		$this.highlight = handler;
		return $this;
	};
	$ValidateOptions.setUnhighlightHandler = function($this, handler) {
		$this.unhighlight = handler;
		return $this;
	};
	$ValidateOptions.setSuccessHandler = function($this, handler) {
		$this.success = handler;
		return $this;
	};
	$ValidateOptions.addRule = function($this, rule) {
		var rulefor = $RuleFor.$ctor();
		var msg = $Message.$ctor();
		rule(rulefor, msg);
		if (!rulefor.element.hasAttribute('autonumeric')) {
			$this.rules[rulefor.element.name] = rulefor.rule.rl;
		}
		else {
			if (!!ss.isValue(rulefor.rule.rl.max)) {
				cayita.fn.autoNumeric(rulefor.element, { vMax: rulefor.rule.rl.max });
			}
			if (!!ss.isValue(rulefor.rule.rl.min)) {
				cayita.fn.autoNumeric(rulefor.element, { vMin: rulefor.rule.rl.min });
			}
			if (!!ss.isValue(rulefor.rule.rl.range)) {
				cayita.fn.autoNumeric(rulefor.element, { vMin: rulefor.rule.rl.range.Bottom, vMax: rulefor.rule.rl.range.Top });
			}
		}
		$this.messages[rulefor.element.name] = msg.msg;
		return $this;
	};
	$ValidateOptions.$ctor = function() {
		var $this = {};
		$this.submitHandler = null;
		$this.highlight = null;
		$this.unhighlight = null;
		$this.success = null;
		$this.validClass = null;
		$this.errorClass = null;
		$this.messages = {};
		$this.rules = {};
		$this.errorClass = 'error';
		$this.validClass = 'success';
		$ValidateOptions.setHighlightHandler($this, function(element) {
			$(element).closest('.control-group').removeClass($this.validClass).addClass($this.errorClass);
		});
		$ValidateOptions.setSuccessHandler($this, function(label) {
			label.closest('.control-group').removeClass($this.errorClass).addClass($this.validClass);
		});
		$ValidateOptions.setUnhighlightHandler($this, function(element1) {
			$(element1).closest('.control-group').removeClass($this.errorClass);
		});
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.AjaxResponse
	var $Cayita_Ajax_AjaxResponse = function() {
	};
	$Cayita_Ajax_AjaxResponse.createInstance = function() {
		return $Cayita_Ajax_AjaxResponse.$ctor();
	};
	$Cayita_Ajax_AjaxResponse.$ctor = function() {
		var $this = {};
		$this.ResponseStatus = null;
		$this.Status = 0;
		$this.StatusText = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.AppError
	var $Cayita_Ajax_AppError = function() {
	};
	$Cayita_Ajax_AppError.createInstance = function() {
		return $Cayita_Ajax_AppError.$ctor();
	};
	$Cayita_Ajax_AppError.$ctor = function() {
		var $this = {};
		$this.ErrorCode = null;
		$this.FieldName = null;
		$this.Message = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.ResponseStatus
	var $Cayita_Ajax_ResponseStatus = function() {
	};
	$Cayita_Ajax_ResponseStatus.createInstance = function() {
		return $Cayita_Ajax_ResponseStatus.$ctor();
	};
	$Cayita_Ajax_ResponseStatus.$ctor = function() {
		var $this = {};
		$this.ErrorCode = null;
		$this.Message = null;
		$this.Errors = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.ReadOptions
	var $Cayita_Data_ReadOptions = function() {
	};
	$Cayita_Data_ReadOptions.createInstance = function() {
		return $Cayita_Data_ReadOptions.$ctor();
	};
	$Cayita_Data_ReadOptions.$ctor = function() {
		var $this = {};
		$this.pageNumber = null;
		$this.pageSize = null;
		$this.queryString = null;
		$this.orderBy = null;
		$this.orderType = null;
		$this.pageSizeParam = null;
		$this.pageNumberParam = null;
		$this.localPaging = false;
		$this.orderByParam = null;
		$this.orderTypeParam = null;
		$this.request = null;
		$this.queryString = {};
		$this.pageSizeParam = 'limit';
		$this.pageNumberParam = 'page';
		$this.request = {};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.Store
	var $Cayita_Data_Store$1 = function(T) {
		var $type = function() {
			this.$st = [];
			this.$createFunc = null;
			this.$readFunc = null;
			this.$updateFunc = null;
			this.$destroyFunc = null;
			this.$patchFunc = null;
			this.$filterFunc = null;
			this.$createApi = null;
			this.$readApi = null;
			this.$updateApi = null;
			this.$destroyApi = null;
			this.$patchApi = null;
			this.$lastOption = null;
			this.$defaultPageSize = 10;
			this.$totalCount = 0;
			this.$idProperty = 'Id';
			this.$1$OnStoreChangedField = null;
			this.$1$OnStoreErrorField = null;
			this.$1$OnStoreRequestField = null;
			this.$1$OnStoreChangedField = function(store, data) {
			};
			this.$1$OnStoreErrorField = function(store1, request) {
			};
			this.$1$OnStoreRequestField = function(store2, state) {
			};
			this.$filterFunc = function(d) {
				return true;
			};
			var $t1 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t1.url = 'api/' + ss.getTypeName(T) + '/create';
			this.$createApi = $t1;
			var $t2 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t2.url = 'api/' + ss.getTypeName(T) + '/read';
			this.$readApi = $t2;
			var $t3 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t3.url = 'api/' + ss.getTypeName(T) + '/update';
			this.$updateApi = $t3;
			var $t4 = ss.makeGenericType($Cayita_Data_StoreApi$1, [String]).$ctor();
			$t4.url = 'api/' + ss.getTypeName(T) + '/destroy';
			this.$destroyApi = $t4;
			var $t5 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t5.url = 'api/' + ss.getTypeName(T) + '/patch';
			this.$patchApi = $t5;
			this.$lastOption = $Cayita_Data_ReadOptions.$ctor();
			this.$createFunc = ss.mkdel(this, function(record) {
				var $t7 = this.$1$OnStoreRequestField;
				var $t6 = $Cayita_Data_StoreRequest.$ctor();
				$t6.action = 0;
				$t6.state = 0;
				$t7(this, $t6);
				var req = $.post(this.$createApi.url, record, function(cb) {
				}, this.$createApi.dataType);
				req.done(ss.mkdel(this, function(scb) {
					var r = this.$createApi.dataProperty;
					var data1 = scb;
					var res = ss.coalesce(data1[r], data1);
					if (Array.isArray(res)) {
						var $t8 = ss.getEnumerator(ss.cast(res, ss.IList));
						try {
							while ($t8.moveNext()) {
								var item = $t8.current();
								ss.add(this.$st, item);
								var $t10 = this.$1$OnStoreChangedField;
								var $t9 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
								$t9.newData = item;
								$t9.oldData = item;
								$t9.action = 0;
								$t10(this, $t9);
							}
						}
						finally {
							$t8.dispose();
						}
					}
					else {
						ss.add(this.$st, ss.cast(res, T));
						var $t12 = this.$1$OnStoreChangedField;
						var $t11 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
						$t11.newData = ss.cast(res, T);
						$t11.oldData = ss.cast(res, T);
						$t11.action = 0;
						$t12(this, $t11);
					}
				}));
				req.fail(ss.mkdel(this, function(f) {
					var $t14 = this.$1$OnStoreErrorField;
					var $t13 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t13.action = 0;
					$t13.request = req;
					$t14(this, $t13);
				}));
				req.always(ss.mkdel(this, function(t) {
					console.log('create always');
					var $t16 = this.$1$OnStoreRequestField;
					var $t15 = $Cayita_Data_StoreRequest.$ctor();
					$t15.action = 0;
					$t15.state = 1;
					$t16(this, $t15);
				}));
				return req;
			});
			this.$readFunc = ss.mkdel(this, function(readOptions) {
				var $t18 = this.$1$OnStoreRequestField;
				var $t17 = $Cayita_Data_StoreRequest.$ctor();
				$t17.action = 1;
				$t17.state = 0;
				$t18(this, $t17);
				var req1 = $.get(this.$readApi.url, this.requestObject(readOptions), function(cb1) {
				}, this.$readApi.dataType);
				req1.done(ss.mkdel(this, function(scb1) {
					var r1 = this.$readApi.dataProperty;
					var data2 = scb1;
					var res1 = ss.coalesce(data2[r1], data2);
					if (Array.isArray(res1)) {
						var $t19 = ss.getEnumerator(ss.cast(res1, ss.IList));
						try {
							while ($t19.moveNext()) {
								var item1 = $t19.current();
								var $t20 = new ss.ObjectEnumerator(this.$readApi.converters);
								try {
									while ($t20.moveNext()) {
										var kv = $t20.current();
										item1[kv.key] = kv.value(item1);
									}
								}
								finally {
									$t20.dispose();
								}
								ss.add(this.$st, item1);
							}
						}
						finally {
							$t19.dispose();
						}
					}
					else {
						ss.add(this.$st, ss.cast(res1, T));
					}
					var tc = ss.cast(data2[this.$readApi.totalCountProperty], ss.Int32);
					this.$totalCount = (ss.isValue(tc) ? ss.Nullable.unbox(tc) : Enumerable.from(this.$st).count(this.$filterFunc));
					var $t22 = this.$1$OnStoreChangedField;
					var $t21 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t21.action = 1;
					$t22(this, $t21);
				}));
				req1.fail(ss.mkdel(this, function(f1) {
					var $t24 = this.$1$OnStoreErrorField;
					var $t23 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t23.action = 1;
					$t23.request = req1;
					$t24(this, $t23);
				}));
				req1.always(ss.mkdel(this, function(f2) {
					var $t26 = this.$1$OnStoreRequestField;
					var $t25 = $Cayita_Data_StoreRequest.$ctor();
					$t25.action = 1;
					$t25.state = 1;
					$t26(this, $t25);
				}));
				return req1;
			});
			this.$updateFunc = ss.mkdel(this, function(record1) {
				var $t28 = this.$1$OnStoreRequestField;
				var $t27 = $Cayita_Data_StoreRequest.$ctor();
				$t27.action = 2;
				$t27.state = 0;
				$t28(this, $t27);
				var req2 = $.post(this.$updateApi.url, record1, function(cb2) {
				}, this.$updateApi.dataType);
				req2.done(ss.mkdel(this, function(scb2) {
					var r2 = this.$updateApi.dataProperty;
					var data3 = scb2;
					var res2 = ss.coalesce(data3[r2], data3);
					if (Array.isArray(res2)) {
						var $t29 = ss.getEnumerator(ss.cast(res2, ss.IList));
						try {
							while ($t29.moveNext()) {
								var item2 = $t29.current();
								var i = { $: item2 };
								var ur = Enumerable.from(this.$st).first(function(f3) {
									return !!ss.referenceEquals(f3[this.$idProperty], i.$[this.$idProperty]);
								});
								var old = ss.createInstance(T);
								cayita.fn.populateFrom(old, ur);
								cayita.fn.populateFrom(ur, item2);
								var $t31 = this.$1$OnStoreChangedField;
								var $t30 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
								$t30.newData = ur;
								$t30.oldData = old;
								$t30.action = 2;
								$t31(this, $t30);
							}
						}
						finally {
							$t29.dispose();
						}
					}
					else {
						var i1 = res2;
						var ur1 = Enumerable.from(this.$st).first(function(f4) {
							return !!ss.referenceEquals(f4[this.$idProperty], i1[this.$idProperty]);
						});
						var old1 = ss.createInstance(T);
						cayita.fn.populateFrom(old1, ur1);
						cayita.fn.populateFrom(ur1, ss.cast(res2, T));
						var $t33 = this.$1$OnStoreChangedField;
						var $t32 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
						$t32.newData = ur1;
						$t32.oldData = old1;
						$t32.action = 2;
						$t33(this, $t32);
					}
				}));
				req2.fail(ss.mkdel(this, function(f5) {
					var $t35 = this.$1$OnStoreErrorField;
					var $t34 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t34.action = 2;
					$t34.request = req2;
					$t35(this, $t34);
				}));
				req2.always(ss.mkdel(this, function(f6) {
					var $t37 = this.$1$OnStoreRequestField;
					var $t36 = $Cayita_Data_StoreRequest.$ctor();
					$t36.action = 2;
					$t36.state = 1;
					$t37(this, $t36);
				}));
				return req2;
			});
			this.$destroyFunc = ss.mkdel(this, function(record2) {
				var $t39 = this.$1$OnStoreRequestField;
				var $t38 = $Cayita_Data_StoreRequest.$ctor();
				$t38.action = 3;
				$t38.state = 0;
				$t39(this, $t38);
				var data4 = {};
				data4[this.$idProperty] = record2[this.$idProperty];
				var req3 = $.post(this.$destroyApi.url, data4, function(cb3) {
				}, this.$destroyApi.dataType);
				req3.done(ss.mkdel(this, function(scb3) {
					var dr = Enumerable.from(this.$st).first(function(f7) {
						return !!ss.referenceEquals(f7[this.$idProperty], record2[this.$idProperty]);
					});
					ss.remove(this.$st, dr);
					var $t41 = this.$1$OnStoreChangedField;
					var $t40 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t40.newData = dr;
					$t40.oldData = dr;
					$t40.action = 3;
					$t41(this, $t40);
				}));
				req3.fail(ss.mkdel(this, function(f8) {
					var $t43 = this.$1$OnStoreErrorField;
					var $t42 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t42.action = 3;
					$t43(this, $t42);
				}));
				req3.always(ss.mkdel(this, function(f9) {
					var $t45 = this.$1$OnStoreRequestField;
					var $t44 = $Cayita_Data_StoreRequest.$ctor();
					$t44.action = 3;
					$t44.state = 1;
					$t45(this, $t44);
				}));
				return req3;
			});
			this.$patchFunc = ss.mkdel(this, function(record3) {
				var $t47 = this.$1$OnStoreRequestField;
				var $t46 = $Cayita_Data_StoreRequest.$ctor();
				$t46.action = 4;
				$t46.state = 0;
				$t47(this, $t46);
				var req4 = $.post(this.$patchApi.url, record3, function(cb4) {
				}, this.$patchApi.dataType);
				req4.done(ss.mkdel(this, function(scb4) {
					var r3 = this.$updateApi.dataProperty;
					var data5 = scb4;
					var res3 = ss.coalesce(data5[r3], data5);
					if (!!res3.IsArray()) {
						var $t48 = ss.getEnumerator(ss.cast(res3, ss.IList));
						try {
							while ($t48.moveNext()) {
								var item3 = $t48.current();
								var i2 = { $: item3 };
								var ur2 = Enumerable.from(this.$st).first(function(f10) {
									return !!ss.referenceEquals(f10[this.$idProperty], i2.$[this.$idProperty]);
								});
								var old2 = ss.createInstance(T);
								cayita.fn.populateFrom(old2, ur2);
								cayita.fn.populateFrom(ur2, item3);
								var $t50 = this.$1$OnStoreChangedField;
								var $t49 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
								$t49.newData = ur2;
								$t49.oldData = old2;
								$t49.action = 4;
								$t50(this, $t49);
							}
						}
						finally {
							$t48.dispose();
						}
					}
					else {
						var i3 = res3;
						var ur3 = Enumerable.from(this.$st).first(function(f11) {
							return !!ss.referenceEquals(f11[this.$idProperty], i3[this.$idProperty]);
						});
						var old3 = ss.createInstance(T);
						cayita.fn.populateFrom(old3, ur3);
						cayita.fn.populateFrom(ur3, ss.cast(res3, T));
						var $t52 = this.$1$OnStoreChangedField;
						var $t51 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
						$t51.newData = ur3;
						$t51.oldData = old3;
						$t51.action = 4;
						$t52(this, $t51);
					}
				}));
				req4.fail(ss.mkdel(this, function(f12) {
					var $t54 = this.$1$OnStoreErrorField;
					var $t53 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t53.action = 4;
					$t53.request = req4;
					$t54(this, $t53);
				}));
				req4.always(ss.mkdel(this, function(f13) {
					var $t56 = this.$1$OnStoreRequestField;
					var $t55 = $Cayita_Data_StoreRequest.$ctor();
					$t55.action = 4;
					$t55.state = 1;
					$t56(this, $t55);
				}));
				return req4;
			});
		};
		$type.prototype = {
			setIdProperty: function(value) {
				this.$idProperty = value;
				return this;
			},
			getRecordIdProperty: function() {
				return this.$idProperty;
			},
			getTotalCount: function() {
				return this.$totalCount;
			},
			setCreateFunc: function(createFunc) {
				this.$createFunc = createFunc;
				return this;
			},
			setReadFunc: function(readFunc) {
				this.$readFunc = readFunc;
				return this;
			},
			setUpdateFunc: function(updateFunc) {
				this.$updateFunc = updateFunc;
				return this;
			},
			setDestroyFunc: function(destroyFunc) {
				this.$destroyFunc = destroyFunc;
				return this;
			},
			setPatchFunc: function(patchFunc) {
				this.$patchFunc = patchFunc;
				return this;
			},
			setCreateApi: function(api) {
				api(this.$createApi);
				return this;
			},
			setReadApi: function(api) {
				api(this.$readApi);
				return this;
			},
			setUpdateApi: function(api) {
				api(this.$updateApi);
				return this;
			},
			setDestroyApi: function(api) {
				api(this.$destroyApi);
				return this;
			},
			setPatchApi: function(api) {
				api(this.$patchApi);
				return this;
			},
			create: function(config) {
				var record = ss.createInstance(T);
				config(record);
				this.create$2(record);
			},
			create$2: function(record) {
				this.$createFunc(record);
			},
			create$1: function(form) {
				var record = ss.createInstance(T);
				cayita.fn.loadTo(form, record);
				this.create$2(record);
			},
			read: function(options) {
				if (!ss.staticEquals(options, null)) {
					options(this.$lastOption);
				}
				if (ss.isValue(this.$lastOption.pageNumber) && (!ss.isValue(this.$lastOption.pageSize) || ss.isValue(this.$lastOption.pageSize) && ss.Nullable.unbox(this.$lastOption.pageSize) === 0)) {
					this.$lastOption.pageSize = this.$defaultPageSize;
				}
				return this.$readFunc(this.$lastOption);
			},
			update: function(record) {
				return this.$updateFunc(record);
			},
			destroy: function(config) {
				var record = ss.createInstance(T);
				config(record);
				return this.$destroyFunc(record);
			},
			patch: function(record) {
				return this.$patchFunc(record);
			},
			requestObject: function(readOptions) {
				var ro = {};
				if (!ss.isNullOrEmptyString(readOptions.orderBy)) {
					ro[readOptions.orderByParam] = readOptions.orderBy;
				}
				if (!ss.isNullOrEmptyString(readOptions.orderType)) {
					ro[readOptions.orderTypeParam] = readOptions.orderType;
				}
				if (!readOptions.localPaging) {
					if (ss.isValue(readOptions.pageNumber)) {
						ro[readOptions.pageNumberParam] = readOptions.pageNumber;
					}
					if (ss.isValue(readOptions.pageSize)) {
						ro[readOptions.pageSizeParam] = readOptions.pageSize;
					}
				}
				cayita.fn.populateFrom(ro, readOptions.request);
				return ro;
			},
			indexOf: function(item) {
				return ss.indexOf(this.$st, item);
			},
			insert: function(index, item) {
				ss.insert(this.$st, index, item);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = item;
				$t1.oldData = item;
				$t1.action = 6;
				$t1.index = index;
				$t2(this, $t1);
			},
			removeAt: function(index) {
				var item = this.get_item(index);
				ss.removeAt(this.$st, index);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = item;
				$t1.oldData = item;
				$t1.action = 8;
				$t1.index = index;
				$t2(this, $t1);
			},
			get_item: function(index) {
				return this.$st[index];
			},
			set_item: function(index, value) {
				this.$st[index] = value;
			},
			replace$1: function(recordId, record) {
				var self = this;
				var source = Enumerable.from(this.$st).first(function(f) {
					return ss.referenceEquals(f[self.$idProperty].toString(), recordId.toString());
				});
				var index = ss.indexOf(this.$st, source);
				var old = cayita.fn.clone(source);
				record(source);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = source;
				$t1.oldData = old;
				$t1.action = 7;
				$t1.index = index;
				$t2(this, $t1);
			},
			replace: function(record) {
				var self = this;
				var source = Enumerable.from(this.$st).first(function(f) {
					return ss.referenceEquals(f[self.$idProperty].toString(), record[self.$idProperty].toString());
				});
				var index = ss.indexOf(this.$st, source);
				var old = cayita.fn.clone(source);
				cayita.fn.populateFrom(source, record);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = source;
				$t1.oldData = old;
				$t1.action = 7;
				$t1.index = index;
				$t2(this, $t1);
			},
			get_count: function() {
				return ((ss.isValue(this.$lastOption) && this.$lastOption.localPaging && ss.isValue(this.$lastOption.pageSize) && ss.Nullable.unbox(this.$lastOption.pageSize) < Enumerable.from(this.$st).count(this.$filterFunc)) ? ss.Nullable.unbox(this.$lastOption.pageSize) : Enumerable.from(this.$st).count(this.$filterFunc));
			},
			add: function(item) {
				ss.add(this.$st, item);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = item;
				$t1.oldData = item;
				$t1.action = 5;
				$t1.index = this.getTotalCount() - 1;
				$t2(this, $t1);
			},
			clear: function() {
				ss.clear(this.$st);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.action = 9;
				$t2(this, $t1);
			},
			contains: function(item) {
				return ss.contains(this.$st, item);
			},
			remove: function(item) {
				var index = ss.indexOf(this.$st, item);
				var r = ss.remove(this.$st, item);
				if (r) {
					var $t2 = this.$1$OnStoreChangedField;
					var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t1.oldData = item;
					$t1.newData = item;
					$t1.action = 8;
					$t1.index = index;
					$t2(this, $t1);
				}
				return r;
			},
			getEnumerator: function() {
				var lo = this.$lastOption;
				if (lo.localPaging && ss.isValue(lo.pageNumber) && ss.isValue(lo.pageSize)) {
					return Enumerable.from(this.$st).where(this.$filterFunc).skip(ss.Nullable.unbox(lo.pageNumber) * ss.Nullable.unbox(lo.pageSize)).take(ss.Nullable.unbox(lo.pageSize)).getEnumerator();
				}
				return Enumerable.from(this.$st).where(this.$filterFunc).getEnumerator();
			},
			load: function(data, options, append) {
				if (!ss.staticEquals(options, null)) {
					options(this.$lastOption);
				}
				if (ss.isValue(this.$lastOption.pageNumber) && (!ss.isValue(this.$lastOption.pageSize) || ss.isValue(this.$lastOption.pageSize) && ss.Nullable.unbox(this.$lastOption.pageSize) === 0)) {
					this.$lastOption.pageSize = this.$defaultPageSize;
				}
				if (!append) {
					ss.clear(this.$st);
				}
				ss.arrayAddRange(this.$st, data);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.action = 10;
				$t2(this, $t1);
			},
			getLastOption: function() {
				return this.$lastOption;
			},
			getDefaultPageSize: function() {
				return this.$defaultPageSize;
			},
			setDefaultPageSize: function(value) {
				this.$defaultPageSize = value;
			},
			hasNextPage: function() {
				if (this.get_count() === this.$totalCount || !ss.isValue(this.$lastOption.pageNumber)) {
					return false;
				}
				return ss.Nullable.unbox(this.$lastOption.pageNumber) + 1 < this.getPagesCount();
			},
			hasPreviousPage: function() {
				return !(this.get_count() === this.$totalCount || !ss.isValue(this.$lastOption.pageNumber) || ss.isValue(this.$lastOption.pageNumber) && ss.Nullable.unbox(this.$lastOption.pageNumber) === 0);
			},
			readFirstPage: function() {
				if (ss.isValue(this.$lastOption.pageNumber)) {
					this.$lastOption.pageNumber = 0;
				}
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					var $t2 = this.$1$OnStoreChangedField;
					var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t1.action = 1;
					$t2(this, $t1);
				}
			},
			readNextPage: function() {
				if (this.hasNextPage()) {
					this.$lastOption.pageNumber = ss.Nullable.add(this.$lastOption.pageNumber, 1);
				}
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					var $t2 = this.$1$OnStoreChangedField;
					var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t1.action = 1;
					$t2(this, $t1);
				}
			},
			readPreviousPage: function() {
				if (this.hasPreviousPage()) {
					this.$lastOption.pageNumber = ss.Nullable.sub(this.$lastOption.pageNumber, 1);
				}
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					var $t2 = this.$1$OnStoreChangedField;
					var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t1.action = 1;
					$t2(this, $t1);
				}
			},
			readLastPage: function() {
				if (ss.isValue(this.$lastOption.pageNumber)) {
					this.$lastOption.pageNumber = this.getPagesCount() - 1;
				}
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					var $t2 = this.$1$OnStoreChangedField;
					var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t1.action = 1;
					$t2(this, $t1);
				}
			},
			readPage: function(page) {
				if (ss.isValue(this.$lastOption.pageNumber)) {
					this.$lastOption.pageNumber = ((page < 0) ? 0 : ((page >= this.getPagesCount()) ? (this.getPagesCount() - 1) : page));
				}
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					var $t2 = this.$1$OnStoreChangedField;
					var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t1.action = 1;
					$t2(this, $t1);
				}
			},
			getPagesCount: function() {
				return ss.Int32.trunc(Math.ceil(this.$totalCount / (ss.isValue(this.$lastOption.pageSize) ? ss.Nullable.unbox(this.$lastOption.pageSize) : this.$st.length)));
			},
			refresh: function() {
				return this.$readFunc(this.$lastOption);
			},
			filter: function(filter) {
				this.$filterFunc = filter;
				this.$totalCount = Enumerable.from(this.$st).count(this.$filterFunc);
				if (ss.isValue(this.$lastOption.pageNumber)) {
					this.$lastOption.pageNumber = 0;
				}
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.action = 11;
				$t2(this, $t1);
			},
			add_onStoreChanged: function(value) {
				this.$1$OnStoreChangedField = ss.delegateCombine(this.$1$OnStoreChangedField, value);
			},
			remove_onStoreChanged: function(value) {
				this.$1$OnStoreChangedField = ss.delegateRemove(this.$1$OnStoreChangedField, value);
			},
			add_onStoreError: function(value) {
				this.$1$OnStoreErrorField = ss.delegateCombine(this.$1$OnStoreErrorField, value);
			},
			remove_onStoreError: function(value) {
				this.$1$OnStoreErrorField = ss.delegateRemove(this.$1$OnStoreErrorField, value);
			},
			add_onStoreRequest: function(value) {
				this.$1$OnStoreRequestField = ss.delegateCombine(this.$1$OnStoreRequestField, value);
			},
			remove_onStoreRequest: function(value) {
				this.$1$OnStoreRequestField = ss.delegateRemove(this.$1$OnStoreRequestField, value);
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_Data_Store$1, [T], function() {
			return null;
		}, function() {
			return [ss.IEnumerable, ss.IEnumerable, ss.ICollection, ss.IList];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.Data.Store$1', $Cayita_Data_Store$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreApi
	var $Cayita_Data_StoreApi$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = {};
			$this.url = null;
			$this.dataType = null;
			$this.dataProperty = null;
			$this.totalCountProperty = null;
			$this.htmlProperty = null;
			$this.converters = null;
			$this.url = 'api/' + ss.getTypeName(T);
			$this.dataType = 'json';
			$this.dataProperty = 'Result';
			$this.totalCountProperty = 'TotalCount';
			$this.htmlProperty = 'Html';
			$this.converters = {};
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_Data_StoreApi$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.Data.StoreApi$1', $Cayita_Data_StoreApi$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreChangedData
	var $Cayita_Data_StoreChangedData$1 = function(T) {
		var $type = function() {
		};
		$type.$ctor = function() {
			var $this = {};
			$this.newData = ss.getDefaultValue(T);
			$this.oldData = ss.getDefaultValue(T);
			$this.action = 0;
			$this.index = 0;
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_Data_StoreChangedData$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.Data.StoreChangedData$1', $Cayita_Data_StoreChangedData$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreError
	var $Cayita_Data_StoreError$1 = function(T) {
		var $type = function() {
		};
		$type.$ctor = function() {
			var $this = {};
			$this.action = 0;
			$this.request = null;
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_Data_StoreError$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.Data.StoreError$1', $Cayita_Data_StoreError$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreRequest
	var $Cayita_Data_StoreRequest = function() {
	};
	$Cayita_Data_StoreRequest.$ctor = function() {
		var $this = {};
		$this.action = 0;
		$this.state = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.ModuleBase
	var $Cayita_Javascript_ModuleBase = function() {
	};
	$Cayita_Javascript_ModuleBase.prototype = { execute: null };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreChangedAction
	var $Cayita_Javascript_Data_StoreChangedAction = function() {
	};
	$Cayita_Javascript_Data_StoreChangedAction.prototype = { created: 0, read: 1, updated: 2, destroyed: 3, patched: 4, added: 5, inserted: 6, replaced: 7, removed: 8, cleared: 9, loaded: 10, filtered: 11 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreErrorAction
	var $Cayita_Javascript_Data_StoreErrorAction = function() {
	};
	$Cayita_Javascript_Data_StoreErrorAction.prototype = { create: 0, read: 1, update: 2, destroy: 3, patch: 4 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreRequestAction
	var $Cayita_Javascript_Data_StoreRequestAction = function() {
	};
	$Cayita_Javascript_Data_StoreRequestAction.prototype = { create: 0, read: 1, update: 2, destroy: 3, patch: 4 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreRequestState
	var $Cayita_Javascript_Data_StoreRequestState = function() {
	};
	$Cayita_Javascript_Data_StoreRequestState.prototype = { started: 0, finished: 1 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Bootbox
	var $Cayita_Javascript_UI_Bootbox = function() {
	};
	$Cayita_Javascript_UI_Bootbox.dialog$2 = function(message, options, buttons) {
		bootbox.dialog(message, buttons || [], options);
	};
	$Cayita_Javascript_UI_Bootbox.dialog$3 = function(message, options, buttons) {
		var opt = $Cayita_Javascript_UI_DialogOptions.$ctor();
		if (!ss.staticEquals(options, null)) {
			options(opt);
		}
		var bt = [];
		if (!ss.staticEquals(buttons, null)) {
			buttons(bt);
		}
		bootbox.dialog(message, bt, opt);
	};
	$Cayita_Javascript_UI_Bootbox.dialog$1 = function(body, options, buttons) {
		$Cayita_Javascript_UI_Bootbox.dialog$3(body.innerHTML, options, buttons);
	};
	$Cayita_Javascript_UI_Bootbox.dialog = function(message) {
		bootbox.dialog(message, [], $Cayita_Javascript_UI_DialogOptions.$ctor());
	};
	$Cayita_Javascript_UI_Bootbox.error = function(message, caption) {
		var $t1 = $Cayita_Javascript_UI_DialogOptions.$ctor();
		$t1.header = ss.formatString('<p style="color:red;"><i class="icon-minus-sign" style="margin-top:8px;margin-right:8px;"></i>{0}</p>', caption);
		bootbox.dialog(message, [], $t1);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.DialogButton
	var $Cayita_Javascript_UI_DialogButton = function() {
	};
	$Cayita_Javascript_UI_DialogButton.createInstance = function() {
		return $Cayita_Javascript_UI_DialogButton.$ctor();
	};
	$Cayita_Javascript_UI_DialogButton.$ctor = function() {
		var $this = {};
		$this.label = null;
		$this.class = null;
		$this.callback = null;
		$this.callback = function() {
		};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.DialogOptions
	var $Cayita_Javascript_UI_DialogOptions = function() {
	};
	$Cayita_Javascript_UI_DialogOptions.createInstance = function() {
		return $Cayita_Javascript_UI_DialogOptions.$ctor();
	};
	$Cayita_Javascript_UI_DialogOptions.$ctor = function() {
		var $this = {};
		$this.header = null;
		$this.animate = null;
		$this.classes = null;
		$this.onEscape = null;
		$this.header = null;
		$this.classes = null;
		$this.onEscape = function() {
		};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Anchor
	var $Cayita_UI_Anchor = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent);
	};
	$Cayita_UI_Anchor.prototype = {
		$init: function(parent) {
			this.createElement('a', parent);
			this.element$1().href = '#';
		},
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Anchor.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent);
		element(this.element$1());
	};
	$Cayita_UI_Anchor.$ctor1.prototype = $Cayita_UI_Anchor.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Button
	var $Cayita_UI_Button = function(parent) {
		$Cayita_UI_ButtonBase.call(this);
		this.createButton(parent, 'button');
	};
	$Cayita_UI_Button.$ctor1 = function(parent, element) {
		$Cayita_UI_ButtonBase.call(this);
		this.createButton(parent, 'button');
		element(this.element$1());
	};
	$Cayita_UI_Button.$ctor1.prototype = $Cayita_UI_Button.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ButtonBase
	var $Cayita_UI_ButtonBase = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_ButtonBase.prototype = {
		createButton: function(parent, type) {
			this.createElement('button', parent);
			if (!ss.isNullOrEmptyString(type)) {
				$(this.element$1()).attr('type', type);
			}
			this.element$1().className = 'btn';
		},
		text: function(value) {
			$(this.element$1()).text(value);
		},
		loadingText: function(value) {
			$(this.element$1()).button.defaults.loadingText = value;
		},
		showLoadingText: function() {
			return $(this.element$1()).button('loading');
		},
		resetLoadingText: function() {
			return $(this.element$1()).button('reset');
		},
		toggle: function() {
			return $(this.element$1()).toggle();
		},
		element$1: function() {
			return ss.cast(this.element(), Element);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.CheckboxField
	var $Cayita_UI_CheckboxField = function(parent, field) {
		this.$controlGroup = null;
		this.$controls = null;
		$Cayita_UI_InputCheckbox.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.$controls = $Cayita_UI_Div.createControls$1(cgDiv, ss.mkdel(this, function(ctdiv) {
				var label = new $Cayita_UI_Label.$ctor1(ctdiv, function(lb) {
					lb.className = 'checkbox';
				});
				this.init(null);
				field(label.element$1(), this.element$2());
				label.forField$1(this.element$2().id);
				label.element$1().appendChild(this.element$2());
			}));
		}));
	};
	$Cayita_UI_CheckboxField.prototype = {
		getControlGroup: function() {
			return this.$controlGroup;
		},
		getControls: function() {
			return this.$controls;
		}
	};
	$Cayita_UI_CheckboxField.$ctor1 = function(parent, textLabel, field) {
		this.$controlGroup = null;
		this.$controls = null;
		$Cayita_UI_InputCheckbox.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.$controls = $Cayita_UI_Div.createControls$1(cgDiv, ss.mkdel(this, function(ctdiv) {
				var label = new $Cayita_UI_Label.$ctor1(ctdiv, function(lb) {
					lb.className = 'checkbox';
					$(lb).text(textLabel);
				});
				this.init(null);
				field(this.element$2());
				label.forField$1(this.element$2().id);
				label.element$1().appendChild(this.element$2());
			}));
		}));
	};
	$Cayita_UI_CheckboxField.$ctor1.prototype = $Cayita_UI_CheckboxField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Div
	var $Cayita_UI_Div = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('div', parent);
	};
	$Cayita_UI_Div.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Div.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('div', parent);
		element(this.element$1());
	};
	$Cayita_UI_Div.$ctor1.prototype = $Cayita_UI_Div.prototype;
	$Cayita_UI_Div.createControlGroup = function(parent) {
		return new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'control-group';
		});
	};
	$Cayita_UI_Div.createControlGroup$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'control-group';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createControls = function(parent) {
		return new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'controls';
		});
	};
	$Cayita_UI_Div.createControls$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'controls';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createContainer = function(parent) {
		return new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'container';
		});
	};
	$Cayita_UI_Div.createContainer$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'container';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createContainerFluid = function(parent) {
		return new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'container-fluid';
		});
	};
	$Cayita_UI_Div.createContainerFluid$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'container-fluid';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createRow = function(parent) {
		return new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'row';
		});
	};
	$Cayita_UI_Div.createRow$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'row';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createRowFluid = function(parent) {
		return new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'row-fluid';
		});
	};
	$Cayita_UI_Div.createRowFluid$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor1(parent, function(div) {
			div.className = 'row-fluid';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createAlert = function(parent, message, type) {
		var div = new $Cayita_UI_Div.$ctor1(parent, function(de) {
			de.className = 'alert alert-' + type;
			new $Cayita_UI_Anchor.$ctor1(de, function(element) {
				element.href = '#';
				element.className = 'close';
				element.setAttribute('data-dismiss', 'alert');
				$(element).text('×');
			});
			$(de).append(message);
		});
		return div;
	};
	$Cayita_UI_Div.alertErrorTemplate = function() {
		return '<div class=\'alert alert-block alert-error\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Div.createAlertErrorBefore = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertErrorTemplate(), message)).insertBefore(element);
	};
	$Cayita_UI_Div.createAlertErrorAfter = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertErrorTemplate(), message)).insertAfter(element);
	};
	$Cayita_UI_Div.alertSuccessTemplate = function() {
		return '<div class=\'alert alert-block alert-success\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Div.createAlertSuccessBefore = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertSuccessTemplate(), message)).insertBefore(element);
	};
	$Cayita_UI_Div.createAlertSuccessAfter = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertSuccessTemplate(), message)).insertAfter(element);
	};
	$Cayita_UI_Div.alertInfoTemplate = function() {
		return '<div class=\'alert alert-block alert-info\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Div.createAlertInfoBefore = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertInfoTemplate(), message)).insertBefore(element);
	};
	$Cayita_UI_Div.createAlertInfoAfter = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertInfoTemplate(), message)).insertAfter(element);
	};
	$Cayita_UI_Div.createPageAlertError = function(element, message) {
		var div = new $Cayita_UI_Div.$ctor1(element, function(de) {
			de.className = 'page-alert';
			$Cayita_UI_Div.createAlert(de, message, 'error');
		});
		return div;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ElementBase
	var $Cayita_UI_ElementBase = function() {
		this.$element_ = null;
	};
	$Cayita_UI_ElementBase.prototype = {
		createElement: function(tagName, parent) {
			this.$element_ = document.createElement(tagName);
			this.$element_.id = this.createId(tagName);
			if (ss.isValue(parent)) {
				$(parent).append(this.$element_);
			}
		},
		createId: function(tagName) {
			var id = {};
			$Cayita_UI_ElementBase.$tags.tryGetValue(tagName, id);
			$Cayita_UI_ElementBase.$tags.set_item(tagName, ++id.$);
			return ss.formatString('cyt-{0}-{1}', tagName, id.$);
		},
		selectorById: function() {
			return '#' + this.$element_.id;
		},
		className$1: function(cssClass) {
			if (!ss.isNullOrEmptyString(cssClass)) {
				this.$element_.className = cssClass;
			}
		},
		className: function() {
			return this.$element_.className;
		},
		addClass: function(cssClass) {
			return $(this.$element_).addClass(cssClass);
		},
		removeClass$1: function(cssClass) {
			return $(this.$element_).removeClass(cssClass);
		},
		removeClass: function() {
			return $(this.$element_).removeClass();
		},
		element: function() {
			return this.$element_;
		},
		show: function() {
			return $(this.$element_).show();
		},
		hide: function() {
			return $(this.$element_).hide();
		},
		slideToggle: function() {
			return $(this.$element_).slideToggle();
		},
		fadeIn: function() {
			return $(this.$element_).fadeIn();
		},
		fadeOut: function() {
			return $(this.$element_).fadeOut();
		},
		fadeToggle: function() {
			return $(this.$element_).fadeToggle();
		},
		jQuery: function() {
			return $(this.$element_);
		},
		jQuery$1: function(selector) {
			return $(selector, this.$element_);
		},
		remove: function() {
			return $(this.$element_).remove();
		},
		empty: function() {
			return $(this.$element_).empty();
		},
		name$1: function(name) {
			if (!ss.isNullOrEmptyString(name)) {
				this.$element_.setAttribute('name', name);
			}
			else {
				this.$element_.removeAttribute('name');
			}
		},
		name: function() {
			var name = this.$element_.getAttribute('name');
			return (ss.isNullOrUndefined(name) ? '' : name.toString());
		},
		appendTo$1: function(parent) {
			$(parent).append(this.$element_);
		},
		appendTo: function(parent) {
			parent.appendChild(this.$element_);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Extensions
	var $Cayita_UI_Ext = function() {
	};
	$Cayita_UI_Ext.load = function(T) {
		return function(cb, data, func, append) {
			if (!append) {
				$(cb).empty();
			}
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = $t1.current();
					$(cb).append(func(d));
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	$Cayita_UI_Ext.createOption = function(T) {
		return function(cb, data, func) {
			$(cb).append(func(data));
		};
	};
	$Cayita_UI_Ext.updateOption = function(T) {
		return function(cb, data, func, recordIdProperty) {
			var d = data;
			var old = $('option[value=' + d[recordIdProperty] + ']', cb);
			cb.replaceChild(func(data), old[0]);
		};
	};
	$Cayita_UI_Ext.removeOption = function(T) {
		return function(cb, data, recordIdProperty) {
			var d = data;
			$('option[value=' + d[recordIdProperty] + ']', cb).remove();
		};
	};
	$Cayita_UI_Ext.loadTo = function(T) {
		return function(form) {
			var data = ss.createInstance(T);
			cayita.fn.loadTo(form, data);
			return data;
		};
	};
	$Cayita_UI_Ext.find = function(T) {
		return function(form, selector) {
			return $(selector, form)[0];
		};
	};
	$Cayita_UI_Ext.findByName = function(T) {
		return function(form, name) {
			return $('[name=' + name + ']', form)[0];
		};
	};
	$Cayita_UI_Ext.findById = function(T) {
		return function(form, id) {
			return $('[id=' + id + ']', form)[0];
		};
	};
	$Cayita_UI_Ext.createRow = function(T) {
		return function(table, data, columns, recordIdProperty) {
			var r = new $Cayita_UI_TableRow.$ctor1(null, function(row) {
				row.setAttribute('record-id', data[recordIdProperty]);
				row.className = 'rowlink';
				for (var $t1 = 0; $t1 < columns.length; $t1++) {
					var col = columns[$t1];
					var c = col.value(data);
					if (col.hidden) {
						$(c).hide();
					}
					$(row).append(c);
					if (!ss.staticEquals(col.afterCellCreate, null)) {
						col.afterCellCreate(data, row);
					}
				}
			});
			$(table).append(r.element$1());
		};
	};
	$Cayita_UI_Ext.updateRow = function(T) {
		return function(table, data, columns, recordIdProperty) {
			var d = data;
			var row = $('tr[record-id=' + d[recordIdProperty] + ']', table).empty();
			for (var $t1 = 0; $t1 < columns.length; $t1++) {
				var col = columns[$t1];
				var c = col.value(data);
				if (col.hidden) {
					$(c).hide();
				}
				row.append(c);
				if (!ss.staticEquals(col.afterCellCreate, null)) {
					col.afterCellCreate(data, row.get(0));
				}
			}
		};
	};
	$Cayita_UI_Ext.removeRow = function(T) {
		return function(table, data, recordIdProperty) {
			var d = data;
			$('tr[record-id=' + d[recordIdProperty] + ']', table).remove();
		};
	};
	$Cayita_UI_Ext.createHeader = function(T) {
		return function(table, columns) {
			new $Cayita_UI_TableHeader.$ctor1(table, function(th) {
				new $Cayita_UI_TableRow.$ctor1(th, function(row) {
					for (var $t1 = 0; $t1 < columns.length; $t1++) {
						var col = columns[$t1];
						if (ss.isNullOrUndefined(col.header)) {
							continue;
						}
						var c = col.header;
						if (col.hidden) {
							$(c).hide();
						}
						$(row).append(c);
					}
				});
			});
		};
	};
	$Cayita_UI_Ext.createFooter = function(T) {
		return function(table, columns) {
			new $Cayita_UI_TableFooter.$ctor1(table, function(tf) {
				new $Cayita_UI_TableRow.$ctor1(tf, function(row) {
					for (var $t1 = 0; $t1 < columns.length; $t1++) {
						var col = columns[$t1];
						if (ss.isNullOrUndefined(col.footer)) {
							continue;
						}
						var c = col.footer;
						if (col.hidden) {
							$(c).hide();
						}
						$(row).append(c);
					}
				});
			});
		};
	};
	$Cayita_UI_Ext.load$1 = function(T) {
		return function(table, data, columns, recordIdProperty, append) {
			var body;
			if (table.tBodies.length === 0) {
				body = (new $Cayita_UI_TableBody(table)).element();
			}
			else {
				body = table.tBodies[0];
				if (!append) {
					$(body).empty();
				}
			}
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = { $: $t1.current() };
					new $Cayita_UI_TableRow.$ctor1(body, ss.mkdel({ d: d }, function(row) {
						row.setAttribute('record-id', this.d.$[recordIdProperty]);
						row.className = 'rowlink';
						for (var $t2 = 0; $t2 < columns.length; $t2++) {
							var col = columns[$t2];
							var c = col.value(this.d.$);
							if (col.hidden) {
								$(c).hide();
							}
							$(row).append(c);
							if (!ss.staticEquals(col.afterCellCreate, null)) {
								col.afterCellCreate(this.d.$, row);
							}
						}
					}));
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	$Cayita_UI_Ext.addItem$2 = function(parent, href, item) {
		var il = new $Cayita_UI_ListItem(parent);
		new $Cayita_UI_Anchor.$ctor1(il.element(), function(a) {
			a.href = href;
			$(a).text(item);
		});
	};
	$Cayita_UI_Ext.addItem$1 = function(parent, item) {
		var il = new $Cayita_UI_ListItem(parent);
		new $Cayita_UI_Anchor.$ctor1(il.element(), function(a) {
			a.href = '#';
			$(a).text(item);
		});
	};
	$Cayita_UI_Ext.addItem = function(parent, element) {
		var il = new $Cayita_UI_ListItem(parent);
		var anchor = new $Cayita_UI_Anchor.$ctor1(il.element(), function(a) {
			a.href = '#';
		});
		element(il.element(), anchor.element$1());
	};
	$Cayita_UI_Ext.addHeader = function(parent, item) {
		new $Cayita_UI_ListItem.$ctor1(parent, function(l) {
			l.className = 'nav-header';
			$(l).text(item);
		});
	};
	$Cayita_UI_Ext.addHDivider = function(parent) {
		new $Cayita_UI_ListItem.$ctor1(parent, function(l) {
			l.className = 'divider';
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.FieldSet
	var $Cayita_UI_FieldSet = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('fieldset', parent);
	};
	$Cayita_UI_FieldSet.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('fieldset', parent);
		element(this.element());
	};
	$Cayita_UI_FieldSet.$ctor1.prototype = $Cayita_UI_FieldSet.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Form
	var $Cayita_UI_Form = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('form', parent);
	};
	$Cayita_UI_Form.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Form.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('form', parent);
		element(this.element$1());
	};
	$Cayita_UI_Form.$ctor1.prototype = $Cayita_UI_Form.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.HtmlGrid
	var $Cayita_UI_HtmlGrid$1 = function(T) {
		var $type = function(parent) {
			this.$columns = null;
			this.$store = null;
			this.$table = null;
			this.$selectedrow = null;
			this.$readRequestStarted = null;
			this.$readRequestFinished = null;
			this.$readRequestMessage = null;
			this.$3$OnRowSelectedField = null;
			$Cayita_UI_HtmlTable.call(this);
			this.$init(parent, new (ss.makeGenericType($Cayita_Data_Store$1, [T]))(), []);
		};
		$type.prototype = {
			$init: function(parent, datastore, tablecolumns) {
				this.createElement('table', parent);
				this.$table = this.element$1();
				this.$table.className = 'table table-striped table-hover table-condensed';
				this.$table.setAttribute('data-provides', 'rowlink');
				this.$columns = tablecolumns;
				this.$store = datastore;
				this.$3$OnRowSelectedField = function(grid, row) {
				};
				$(this.$table).on('click', 'tbody tr', ss.mkdel(this, function(e) {
					var row1 = e.currentTarget;
					this.$selectRowImp(row1, true);
				}));
				this.render();
				var $t1 = $Cayita_UI_RequestMessage.$ctor();
				$t1.target = this.$table.tBodies[0];
				$t1.message = 'Reading ' + ss.getTypeName(T);
				this.$readRequestMessage = $t1;
				this.$readRequestStarted = ss.mkdel(this, function(grid1) {
					var sp = new $Cayita_UI_SpinnerIcon(function(div, icon) {
						div.style.position = 'fixed';
						div.style.zIndex = 10000;
						div.style.opacity = '0.7';
						div.style.height = (grid1.$table.clientHeight + 30).toString() + 'px';
						div.style.width = grid1.$table.clientWidth.toString() + 'px';
					}, this.$readRequestMessage.message);
					$(this.$readRequestMessage.target).append(sp.element$1());
					return sp.element$1();
				});
				this.$readRequestFinished = function(grid2, el) {
					$(el).remove();
				};
				this.$store.add_onStoreChanged(ss.mkdel(this, function(st, dt) {
					switch (dt.action) {
						case 0: {
							$Cayita_UI_Ext.createRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 11:
						case 10:
						case 1: {
							$Cayita_UI_Ext.load$1(T).call(null, this.$table, this.$store, this.$columns, this.$store.getRecordIdProperty(), false);
							this.selectRow(true);
							break;
						}
						case 2: {
							$Cayita_UI_Ext.updateRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 3: {
							var recordId = dt.oldData[this.$store.getRecordIdProperty()];
							$('tr[record-id=' + recordId + ']', this.$table).remove();
							this.selectRow(true);
							break;
						}
						case 4: {
							$Cayita_UI_Ext.updateRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 5: {
							$Cayita_UI_Ext.createRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 7: {
							$Cayita_UI_Ext.updateRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 6: {
							$Cayita_UI_Ext.createRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 8: {
							var id = dt.oldData[this.$store.getRecordIdProperty()];
							$('tr[record-id=' + id + ']', this.$table).remove();
							this.selectRow(true);
							break;
						}
						case 9: {
							$(this.$table.tBodies[0]).empty();
							this.selectRow(true);
							break;
						}
					}
				}));
				this.$store.add_onStoreRequest(ss.mkdel(this, function(st1, request) {
					switch (request.action) {
						case 0: {
							break;
						}
						case 1: {
							if (request.state === 0) {
								this.$readRequestMessage.htmlElement = this.$readRequestStarted(this);
							}
							else {
								this.$readRequestFinished(this, this.$readRequestMessage.htmlElement);
							}
							break;
						}
						case 2: {
							break;
						}
						case 3: {
							break;
						}
						case 4: {
							break;
						}
					}
				}));
			},
			getStore: function() {
				return this.$store;
			},
			setReadRequestMessage: function(message) {
				message(this.$readRequestMessage);
				return this;
			},
			getSelectedRow: function() {
				return this.$selectedrow;
			},
			render: function() {
				$Cayita_UI_Ext.createHeader(T).call(null, this.$table, this.$columns);
				//table.Load<T>(store, columns, store.GetRecordIdProperty());
			},
			selectRow$1: function(recordId, trigger) {
				var row = $('tr[record-id=' + recordId + ']', this.$table).get(0);
				this.$selectRowImp(row, trigger);
			},
			selectRow: function(trigger) {
				$('tbody tr', this.$table).removeClass('info');
				this.$selectedrow = null;
				if (trigger) {
					this.$3$OnRowSelectedField(this, this.$selectedrow);
				}
			},
			$selectRowImp: function(row, trigger) {
				var self = this;
				$('tbody tr', this.$table).removeClass('info');
				$(row).addClass('info');
				var record = Enumerable.from(this.$store).first(function(f) {
					return ss.referenceEquals(f[self.$store.getRecordIdProperty()].toString(), row.getAttribute('record-id'));
				});
				var $t1 = ss.makeGenericType($Cayita_UI_SelectedRow$1, [T]).$ctor();
				$t1.recordId = row.getAttribute('record-id');
				$t1.row = row;
				$t1.record = record;
				this.$selectedrow = $t1;
				if (trigger) {
					this.$3$OnRowSelectedField(this, this.$selectedrow);
				}
			},
			hideColumn: function(columnIndex) {
				this.$columns[columnIndex++].hidden = true;
				$(this.$table).find('td:nth-child(' + columnIndex + '),th:nth-child(' + columnIndex + ')').hide();
			},
			showColumn: function(columnIndex) {
				this.$columns[columnIndex++].hidden = false;
				$(this.$table).find('td:nth-child(' + columnIndex + '),th:nth-child(' + columnIndex + ')').show();
			},
			add_onRowSelected: function(value) {
				this.$3$OnRowSelectedField = ss.delegateCombine(this.$3$OnRowSelectedField, value);
			},
			remove_onRowSelected: function(value) {
				this.$3$OnRowSelectedField = ss.delegateRemove(this.$3$OnRowSelectedField, value);
			}
		};
		$type.$ctor1 = function(parent, store, columns) {
			this.$columns = null;
			this.$store = null;
			this.$table = null;
			this.$selectedrow = null;
			this.$readRequestStarted = null;
			this.$readRequestFinished = null;
			this.$readRequestMessage = null;
			this.$3$OnRowSelectedField = null;
			$Cayita_UI_HtmlTable.call(this);
			this.$init(parent, store, columns);
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_HtmlGrid$1, [T], function() {
			return $Cayita_UI_HtmlTable;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.HtmlGrid$1', $Cayita_UI_HtmlGrid$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.HtmlList
	var $Cayita_UI_HtmlList = function(parent, ordered) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement((ordered ? 'ol' : 'ul'), parent);
	};
	$Cayita_UI_HtmlList.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_HtmlList.$ctor1 = function(parent, element, ordered) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement((ordered ? 'ol' : 'ul'), parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlList.$ctor1.prototype = $Cayita_UI_HtmlList.prototype;
	$Cayita_UI_HtmlList.createNavList = function(parent) {
		var l = new $Cayita_UI_HtmlList.$ctor1(parent, function(e) {
			e.className = 'nav nav-list';
			$(e).on('click', 'li', function(ev) {
				$('li', e).removeClass('active');
				$(ev.currentTarget).addClass('active');
			});
		}, false);
		return l;
	};
	$Cayita_UI_HtmlList.createNavList$1 = function(parent, element) {
		var nl = $Cayita_UI_HtmlList.createNavList(parent);
		element(nl.element$1());
		return nl;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.HtmlOption
	var $Cayita_UI_HtmlOption = function(element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(null);
		element(this.element$1());
	};
	$Cayita_UI_HtmlOption.prototype = {
		$init: function(parent) {
			this.createElement('option', parent);
		},
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_HtmlOption.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlOption.$ctor1.prototype = $Cayita_UI_HtmlOption.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.HtmlSelect
	var $Cayita_UI_HtmlSelect = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_HtmlSelect.prototype = {
		init: function(parent) {
			this.createElement('select', parent);
		},
		element$1: function() {
			return this.element();
		},
		load: function(T) {
			return function(data, func) {
				$Cayita_UI_Ext.load(T).call(null, this.element$1(), data, func, false);
			};
		},
		selectItem: function(value) {
			return $('option[value=' + value + ']', this.element$1()).attr('selected', true);
		}
	};
	$Cayita_UI_HtmlSelect.$ctor1 = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.init(parent);
	};
	$Cayita_UI_HtmlSelect.$ctor2 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.init(parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlSelect.$ctor1.prototype = $Cayita_UI_HtmlSelect.$ctor2.prototype = $Cayita_UI_HtmlSelect.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.HtmlTable
	var $Cayita_UI_HtmlTable = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_HtmlTable.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_HtmlTable.$ctor2 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('table', parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlTable.$ctor1 = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('table', parent);
	};
	$Cayita_UI_HtmlTable.$ctor2.prototype = $Cayita_UI_HtmlTable.$ctor1.prototype = $Cayita_UI_HtmlTable.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Icon
	var $Cayita_UI_Icon = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('i', parent);
	};
	$Cayita_UI_Icon.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('i', parent);
		element(this.element());
	};
	$Cayita_UI_Icon.$ctor1.prototype = $Cayita_UI_Icon.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.IconAnchor
	var $Cayita_UI_IconAnchor = function(parent, element) {
		$Cayita_UI_Anchor.call(this, parent);
		this.element$1().className = 'btn';
		var i = new $Cayita_UI_Icon(this.element$1());
		element(this.element$1(), i.element());
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.IconButton
	var $Cayita_UI_IconButton = function(parent, element) {
		$Cayita_UI_Button.call(this, parent);
		this.element$1().className = 'btn';
		var i = new $Cayita_UI_Icon(this.element$1());
		element(this.element$1(), i.element());
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Image
	var $Cayita_UI_Image = function(parent, image) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('img', parent);
		image(this.element$1());
	};
	$Cayita_UI_Image.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Input
	var $Cayita_UI_Input = function(parent) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, 'text');
	};
	$Cayita_UI_Input.$ctor1 = function(parent, element) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, 'text');
		element(this.element$1());
	};
	$Cayita_UI_Input.$ctor1.prototype = $Cayita_UI_Input.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputBase
	var $Cayita_UI_InputBase = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_InputBase.prototype = {
		createInput: function(parent, type) {
			this.createElement('input', parent);
			if (!ss.isNullOrEmptyString(type)) {
				this.element$1().type = type;
			}
		},
		placeHolder$1: function(placeholder) {
			if (!ss.isNullOrEmptyString(placeholder)) {
				this.element$1().setAttribute('placeholder', placeholder);
			}
			else {
				this.element$1().removeAttribute('placeholder');
			}
		},
		placeHolder: function() {
			var placeholder = this.element$1().getAttribute('placeholder');
			return (ss.isNullOrUndefined(placeholder) ? '' : placeholder.toString());
		},
		required$1: function(required) {
			if (required) {
				this.element$1().setAttribute('required', 'true');
			}
			else {
				this.element$1().removeAttribute('required');
			}
		},
		required: function() {
			var rq = this.element$1().getAttribute('required');
			return (ss.isNullOrUndefined(rq) ? false : ((rq.toString() === 'required' || rq.toString() === 'true') ? true : false));
		},
		relativeSize: function(relativeSize) {
			this.addClass(relativeSize);
		},
		gridSize: function(gridSize) {
			this.addClass(gridSize);
		},
		value$1: function(value) {
			cayita.fn.setValue(this.element$1(), value);
		},
		value: function() {
			return cayita.fn.getValue(this.element$1());
		},
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_InputBase.$ctor1 = function(parent, type) {
		$Cayita_UI_ElementBase.call(this);
		this.createInput(parent, type);
	};
	$Cayita_UI_InputBase.$ctor1.prototype = $Cayita_UI_InputBase.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputCheckbox
	var $Cayita_UI_InputCheckbox = function() {
		$Cayita_UI_InputBase.call(this);
	};
	$Cayita_UI_InputCheckbox.prototype = {
		init: function(parent) {
			this.createInput(parent, 'checkbox');
			this.element$2().value = 'true';
		},
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputCheckbox.$ctor2 = function(parent, element) {
		$Cayita_UI_InputBase.call(this);
		this.init(parent);
		element(this.element$2());
		this.element$2();
	};
	$Cayita_UI_InputCheckbox.$ctor1 = function(parent) {
		$Cayita_UI_InputBase.call(this);
		this.init(parent);
	};
	$Cayita_UI_InputCheckbox.$ctor2.prototype = $Cayita_UI_InputCheckbox.$ctor1.prototype = $Cayita_UI_InputCheckbox.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputPassword
	var $Cayita_UI_InputPassword = function(parent) {
		$Cayita_UI_InputText.$ctor1.call(this, parent);
		this.element$2().type = 'password';
	};
	$Cayita_UI_InputPassword.$ctor1 = function(parent, element) {
		$Cayita_UI_InputPassword.call(this, parent);
		element(this.element$2());
	};
	$Cayita_UI_InputPassword.$ctor1.prototype = $Cayita_UI_InputPassword.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputRadio
	var $Cayita_UI_InputRadio = function(parent, field) {
		$Cayita_UI_InputBase.call(this);
		new $Cayita_UI_Label.$ctor1(parent, ss.mkdel(this, function(lb) {
			lb.className = 'radio inline';
			this.createInput(null, 'radio');
			lb.setAttribute('for', this.element$2().id);
			field(lb, this.element$2());
			$(lb).append(this.element$2());
		}));
	};
	$Cayita_UI_InputRadio.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputText
	var $Cayita_UI_InputText = function() {
		$Cayita_UI_InputBase.call(this);
	};
	$Cayita_UI_InputText.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputText.$ctor2 = function(parent, element) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, 'text');
		element(this.element$2());
	};
	$Cayita_UI_InputText.$ctor1 = function(parent) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, 'text');
	};
	$Cayita_UI_InputText.$ctor2.prototype = $Cayita_UI_InputText.$ctor1.prototype = $Cayita_UI_InputText.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Label
	var $Cayita_UI_Label = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('label', parent);
	};
	$Cayita_UI_Label.prototype = {
		textLabel$1: function(textLabel) {
			$(this.element$1()).text(textLabel);
		},
		textLabel: function() {
			return $(this.element$1()).text();
		},
		forField$1: function(fieldId) {
			if (!ss.isNullOrEmptyString(fieldId)) {
				this.element$1().setAttribute('for', fieldId);
			}
			else {
				this.element$1().removeAttribute('for');
			}
		},
		forField: function() {
			var forF = this.element$1().getAttribute('for');
			return (ss.isNullOrUndefined(forF) ? '' : forF.toString());
		},
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Label.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('label', parent);
		element(this.element$1());
	};
	$Cayita_UI_Label.$ctor1.prototype = $Cayita_UI_Label.prototype;
	$Cayita_UI_Label.createControlLabel = function(parent, textLabel, forField, visible) {
		return new $Cayita_UI_Label.$ctor1(parent, function(lb) {
			$(lb).text(textLabel);
			lb.className = 'control-label';
			if (!ss.isNullOrEmptyString(forField)) {
				lb.setAttribute('for', forField);
			}
			if (!visible) {
				$(lb).hide();
			}
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Legend
	var $Cayita_UI_Legend = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('legend', parent);
	};
	$Cayita_UI_Legend.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('legend', parent);
		element(this.element());
	};
	$Cayita_UI_Legend.$ctor1.prototype = $Cayita_UI_Legend.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ListItem
	var $Cayita_UI_ListItem = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent);
	};
	$Cayita_UI_ListItem.prototype = {
		$init: function(parent) {
			this.createElement('li', parent);
		}
	};
	$Cayita_UI_ListItem.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent);
		element(this.element());
	};
	$Cayita_UI_ListItem.$ctor1.prototype = $Cayita_UI_ListItem.prototype;
	$Cayita_UI_ListItem.createNavListItem = function(parent, href, item) {
		var il = new $Cayita_UI_ListItem(parent);
		new $Cayita_UI_Anchor.$ctor1(il.element(), function(a) {
			a.href = href;
			$(a).text(item);
		});
		return il;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Paragraph
	var $Cayita_UI_Paragraph = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('p', parent);
	};
	$Cayita_UI_Paragraph.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('p', parent);
		element(this.element());
	};
	$Cayita_UI_Paragraph.$ctor1.prototype = $Cayita_UI_Paragraph.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.RadioField
	var $Cayita_UI_RadioField = function(parent, label, fieldName, items, inline) {
		this.$element = null;
		this.$controls = null;
		$Cayita_UI_Div.call(this, parent);
		this.$element = this.element$1();
		this.$element.className = 'control-group';
		$Cayita_UI_Label.createControlLabel(this.$element, label, null, true);
		this.$controls = $Cayita_UI_Div.createControls$1(this.$element, function(ct) {
			var $t1 = ss.getEnumerator(items);
			try {
				while ($t1.moveNext()) {
					var item = { $: $t1.current() };
					new $Cayita_UI_InputRadio(ct, ss.mkdel({ item: item }, function(lb, rd) {
						$(lb).text(this.item.$.text);
						if (!inline) {
							$(lb).removeClass('inline');
						}
						rd.name = fieldName;
						cayita.fn.setValue(rd, this.item.$.value);
					}));
				}
			}
			finally {
				$t1.dispose();
			}
		});
	};
	$Cayita_UI_RadioField.prototype = {
		getControls: function() {
			return this.$controls;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.RadioItem
	var $Cayita_UI_RadioItem = function() {
	};
	$Cayita_UI_RadioItem.createInstance = function() {
		return $Cayita_UI_RadioItem.$ctor();
	};
	$Cayita_UI_RadioItem.$ctor = function() {
		var $this = {};
		$this.text = null;
		$this.value = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.RequestMessage
	var $Cayita_UI_RequestMessage = function() {
	};
	$Cayita_UI_RequestMessage.createInstance = function() {
		return $Cayita_UI_RequestMessage.$ctor();
	};
	$Cayita_UI_RequestMessage.$ctor = function() {
		var $this = {};
		$this.target = null;
		$this.message = null;
		$this.htmlElement = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ResetButton
	var $Cayita_UI_ResetButton = function(parent) {
		$Cayita_UI_ButtonBase.call(this);
		this.createButton(parent, 'reset');
	};
	$Cayita_UI_ResetButton.$ctor1 = function(parent, element) {
		$Cayita_UI_ButtonBase.call(this);
		this.createButton(parent, 'reset');
		element(this.element$1());
	};
	$Cayita_UI_ResetButton.$ctor1.prototype = $Cayita_UI_ResetButton.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SelectedOption
	var $Cayita_UI_SelectedOption$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = {};
			$this.option = null;
			$this.record = ss.getDefaultValue(T);
			$this.record = ss.createInstance(T);
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_SelectedOption$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SelectedOption$1', $Cayita_UI_SelectedOption$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SelectedRow
	var $Cayita_UI_SelectedRow = function() {
	};
	$Cayita_UI_SelectedRow.createInstance = function() {
		return $Cayita_UI_SelectedRow.$ctor();
	};
	$Cayita_UI_SelectedRow.$ctor = function() {
		var $this = {};
		$this.recordId = null;
		$this.row = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SelectedRow
	var $Cayita_UI_SelectedRow$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = $Cayita_UI_SelectedRow.$ctor();
			$this.record = ss.getDefaultValue(T);
			$this.record = ss.createInstance(T);
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_SelectedRow$1, [T], function() {
			return $Cayita_UI_SelectedRow;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SelectedRow$1', $Cayita_UI_SelectedRow$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SelectField
	var $Cayita_UI_SelectField = function() {
		this.controlGroup = null;
		this.label = null;
		this.controls = null;
		$Cayita_UI_HtmlSelect.call(this);
	};
	$Cayita_UI_SelectField.prototype = {
		getControlGroup: function() {
			return this.controlGroup;
		},
		getControls: function() {
			return this.controls;
		},
		getLabel: function() {
			return this.label;
		}
	};
	$Cayita_UI_SelectField.$ctor1 = function(parent, field) {
		this.controlGroup = null;
		this.label = null;
		this.controls = null;
		$Cayita_UI_HtmlSelect.call(this);
		this.controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.label = $Cayita_UI_Label.createControlLabel(cgDiv, '', null, true);
			this.controls = $Cayita_UI_Div.createControls$1(cgDiv, ss.mkdel(this, function(ctDiv) {
				this.init(ctDiv);
				field(this.label.element$1(), this.element$1());
				this.label.forField$1(this.element$1().id);
			}));
			if (ss.isNullOrEmptyString(this.label.textLabel())) {
				this.label.hide();
			}
		}));
	};
	$Cayita_UI_SelectField.$ctor2 = function(parent, field) {
		this.controlGroup = null;
		this.label = null;
		this.controls = null;
		$Cayita_UI_HtmlSelect.call(this);
		this.controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.label = $Cayita_UI_Label.createControlLabel(cgDiv, '', null, true);
			this.label.hide();
			this.controls = new $Cayita_UI_Div.$ctor1(cgDiv, ss.mkdel(this, function(ctDiv) {
				this.init(ctDiv);
				field(this.element$1());
				this.label.forField$1(this.element$1().id);
			}));
		}));
	};
	$Cayita_UI_SelectField.$ctor1.prototype = $Cayita_UI_SelectField.$ctor2.prototype = $Cayita_UI_SelectField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SelectField
	var $Cayita_UI_SelectField$1 = function(T) {
		var $type = function(parent, element, store, optionFunc, defaultOption) {
			this.$optionFunc = null;
			this.$store = null;
			this.$se = null;
			this.$selectedoption = null;
			this.$defaultoption = null;
			this.$4$OnOptionSelectedField = null;
			$Cayita_UI_SelectField.call(this);
			this.controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
				this.label = $Cayita_UI_Label.createControlLabel(cgDiv, '', null, true);
				this.label.hide();
				this.controls = new $Cayita_UI_Div.$ctor1(cgDiv, ss.mkdel(this, function(ctDiv) {
					this.init(ctDiv);
					element(this.element$1());
					this.label.forField$1(this.element$1().id);
					this.$init(store, optionFunc, defaultOption);
				}));
			}));
		};
		$type.prototype = {
			$init: function(store, optionFunc, defaultOption) {
				this.$store = store;
				this.$optionFunc = optionFunc;
				this.$se = this.element$1();
				this.$4$OnOptionSelectedField = function(sf, opt) {
				};
				this.$defaultoption = defaultOption || ss.makeGenericType($Cayita_UI_SelectedOption$1, [T]).$ctor();
				$(this.$se).on('change', ss.mkdel(this, function(evt) {
					var option = $(this.$se).find('option:selected')[0];
					this.$selectedOptionImp(option, true);
				}));
				this.render();
				store.add_onStoreChanged(ss.mkdel(this, function(st, dt) {
					switch (dt.action) {
						case 0: {
							$Cayita_UI_Ext.createOption(T).call(null, this.$se, dt.newData, optionFunc);
							break;
						}
						case 11:
						case 10:
						case 1: {
							this.selectOption();
							this.render();
							break;
						}
						case 2: {
							$Cayita_UI_Ext.updateOption(T).call(null, this.$se, dt.newData, optionFunc, store.getRecordIdProperty());
							break;
						}
						case 3: {
							$Cayita_UI_Ext.removeOption(T).call(null, this.$se, dt.oldData, store.getRecordIdProperty());
							this.selectOption();
							break;
						}
						case 4: {
							$Cayita_UI_Ext.updateOption(T).call(null, this.$se, dt.newData, optionFunc, store.getRecordIdProperty());
							break;
						}
						case 5: {
							$Cayita_UI_Ext.createOption(T).call(null, this.$se, dt.newData, optionFunc);
							break;
						}
						case 7: {
							$Cayita_UI_Ext.updateOption(T).call(null, this.$se, dt.newData, optionFunc, store.getRecordIdProperty());
							break;
						}
						case 6: {
							$Cayita_UI_Ext.createOption(T).call(null, this.$se, dt.newData, optionFunc);
							break;
						}
						case 8: {
							$Cayita_UI_Ext.removeOption(T).call(null, this.$se, dt.oldData, store.getRecordIdProperty());
							this.selectOption();
							break;
						}
						case 9: {
							$(this.$se).empty();
							this.selectOption();
							break;
						}
					}
				}));
			},
			render: function() {
				var append = false;
				if (ss.isValue(this.$defaultoption.option) && ss.isNullOrEmptyString(this.$defaultoption.option.value)) {
					append = true;
					$Cayita_UI_Ext.createOption(T).call(null, this.$se, this.$defaultoption.record, ss.mkdel(this, function(f) {
						return this.$defaultoption.option;
					}));
				}
				$Cayita_UI_Ext.load(T).call(null, this.$se, this.$store, this.$optionFunc, append);
				if (!ss.isNullOrEmptyString(this.$defaultoption.option.value)) {
					var $t1 = this.$se;
					$('option[value=' + this.$defaultoption.option.value + ']', $t1).attr('selected', true);
				}
			},
			getSelectedOption: function() {
				return this.$selectedoption;
			},
			add_onOptionSelected: function(value) {
				this.$4$OnOptionSelectedField = ss.delegateCombine(this.$4$OnOptionSelectedField, value);
			},
			remove_onOptionSelected: function(value) {
				this.$4$OnOptionSelectedField = ss.delegateRemove(this.$4$OnOptionSelectedField, value);
			},
			selectOption$1: function(value, trigger) {
				var option = $('option[value=' + value + ']', this.$se).attr('selected', true)[0];
				this.$selectedOptionImp(option, true);
			},
			selectOption: function() {
				$('option:selected', this.$se).prop('selected', false);
				this.$selectedoption = null;
				this.$4$OnOptionSelectedField(this, this.$selectedoption);
			},
			$selectedOptionImp: function(option, trigger) {
				var self = this;
				var recordId = option.value;
				if (!ss.isNullOrEmptyString(recordId)) {
					var record = Enumerable.from(this.$store).first(function(f) {
						return ss.referenceEquals(f[self.$store.getRecordIdProperty()].toString(), option.value);
					});
					var $t1 = ss.makeGenericType($Cayita_UI_SelectedOption$1, [T]).$ctor();
					$t1.option = option;
					$t1.record = record;
					this.$selectedoption = $t1;
				}
				else {
					this.$selectedoption = null;
				}
				if (trigger) {
					this.$4$OnOptionSelectedField(this, this.$selectedoption);
				}
			}
		};
		$type.$ctor1 = function(parent, element, store, optionFunc, defaultOption) {
			this.$optionFunc = null;
			this.$store = null;
			this.$se = null;
			this.$selectedoption = null;
			this.$defaultoption = null;
			this.$4$OnOptionSelectedField = null;
			$Cayita_UI_SelectField.call(this);
			this.controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
				this.label = $Cayita_UI_Label.createControlLabel(cgDiv, '', null, true);
				this.controls = $Cayita_UI_Div.createControls$1(cgDiv, ss.mkdel(this, function(ctDiv) {
					this.init(ctDiv);
					element(this.label.element$1(), this.element$1());
					this.label.forField$1(this.element$1().id);
					this.$init(store, optionFunc, defaultOption);
				}));
				if (ss.isNullOrEmptyString(this.label.textLabel())) {
					this.label.hide();
				}
			}));
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_SelectField$1, [T], function() {
			return $Cayita_UI_SelectField;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SelectField$1', $Cayita_UI_SelectField$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SideNavBar
	var $Cayita_UI_SideNavBar = function(parent, navlist) {
		this.$navList = null;
		$Cayita_UI_Div.call(this, parent);
		this.element$1().className = 'well sidebar-nav';
		this.$navList = $Cayita_UI_HtmlList.createNavList$1(this.element$1(), navlist);
	};
	$Cayita_UI_SideNavBar.prototype = {
		getNavList: function() {
			return this.$navList;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Span
	var $Cayita_UI_Span = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('span', parent);
	};
	$Cayita_UI_Span.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('span', parent);
		element(this.element());
	};
	$Cayita_UI_Span.$ctor1.prototype = $Cayita_UI_Span.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SpinnerIcon
	var $Cayita_UI_SpinnerIcon = function(config, message) {
		$Cayita_UI_SpinnerIcon.$ctor1.call(this, null, config, message);
	};
	$Cayita_UI_SpinnerIcon.prototype = {
		element$1: function() {
			return this.element();
		},
		getIcon: function() {
			return this.$icon;
		}
	};
	$Cayita_UI_SpinnerIcon.$ctor1 = function(parent, config, message) {
		this.$icon = null;
		$Cayita_UI_ElementBase.call(this);
		this.createElement('div', parent);
		this.element$1().className = 'well well-large lead';
		this.$icon = (new $Cayita_UI_Icon.$ctor1(this.element$1(), function(i) {
			i.className = 'icon-spinner icon-spin icon-2x pull-left';
		})).element();
		config(this.element$1(), this.$icon);
		$(this.element$1()).append(message);
	};
	$Cayita_UI_SpinnerIcon.$ctor1.prototype = $Cayita_UI_SpinnerIcon.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.StorePaging
	var $Cayita_UI_StorePaging$1 = function(T) {
		var $type = function(parent, store) {
			this.$divnav = null;
			this.$pText = 'page';
			this.$ofText = 'of';
			this.$infoTmpl = 'from {0} to {1} of {2}';
			this.$store_ = null;
			this.$element = null;
			this.$first = null;
			this.$prev = null;
			this.$next = null;
			this.$last = null;
			this.$page = null;
			this.$totalPages = null;
			this.$info = null;
			this.$currentPage = null;
			$Cayita_UI_Div.call(this, parent);
			this.$store_ = store;
			this.$element = this.element$1();
			this.$divnav = new $Cayita_UI_Div.$ctor1(this.$element, ss.mkdel(this, function(d) {
				d.className = 'btn-group';
				this.$first = (new $Cayita_UI_IconButton(d, ss.mkdel(this, function(b, i) {
					b.disabled = true;
					$(b).on('click', ss.mkdel(this, function(evt) {
						this.$store_.readFirstPage();
					}));
					$(b).addClass('btn-small');
					i.className = 'icon-double-angle-left';
				}))).element$1();
				this.$prev = (new $Cayita_UI_IconButton(d, ss.mkdel(this, function(b1, i1) {
					b1.disabled = true;
					$(b1).on('click', ss.mkdel(this, function(evt1) {
						this.$store_.readPreviousPage();
					}));
					$(b1).addClass('btn-small');
					i1.className = 'icon-angle-left';
				}))).element$1();
				this.$next = (new $Cayita_UI_IconButton(d, ss.mkdel(this, function(b2, i2) {
					b2.disabled = true;
					$(b2).on('click', ss.mkdel(this, function(evt2) {
						this.$store_.readNextPage();
					}));
					$(b2).addClass('btn-small');
					i2.className = 'icon-angle-right';
				}))).element$1();
				this.$last = (new $Cayita_UI_IconButton(d, ss.mkdel(this, function(b3, i3) {
					b3.disabled = true;
					$(b3).on('click', ss.mkdel(this, function(evt3) {
						this.$store_.readLastPage();
					}));
					$(b3).addClass('btn-small');
					i3.className = 'icon-double-angle-right';
				}))).element$1();
			}));
			new $Cayita_UI_Div.$ctor1(this.$element, ss.mkdel(this, function(d1) {
				d1.className = 'btn-group form-inline label';
				this.$page = (new $Cayita_UI_Label.$ctor1(d1, ss.mkdel(this, function(l) {
					l.className = 'checkbox';
					l.style.paddingRight = '2px';
					$(l).text(this.$pText);
					l.style.fontSize = '98%';
				}))).element$1();
				this.$currentPage = (new $Cayita_UI_Input.$ctor1(d1, ss.mkdel(this, function(i4) {
					i4.className = 'input-mini';
					i4.style.padding = '0px';
					i4.style.height = '18px';
					cayita.fn.autoNumeric(i4, { mDec: 0, wEmpty: 'empty', vMin: 0 });
					i4.style.textAlign = 'center';
					i4.style.fontSize = '97%';
					i4.style.width = '45px';
					$(i4).keypress(ss.mkdel(this, function(evt4) {
						if (evt4.which === 13) {
							this.$store_.readPage(cayita.fn.getValue(i4) - 1);
						}
					}));
				}))).element$1();
				this.$totalPages = (new $Cayita_UI_Label.$ctor1(d1, ss.mkdel(this, function(l1) {
					l1.className = 'checkbox';
					l1.style.paddingLeft = '2px';
					$(l1).text(this.$ofText + ' {0}');
					l1.style.fontSize = '98%';
				}))).element$1();
			}));
			new $Cayita_UI_Div.$ctor1(this.$element, ss.mkdel(this, function(d2) {
				d2.className = 'btn-group form-inline label';
				this.$info = (new $Cayita_UI_Label.$ctor1(d2, ss.mkdel(this, function(l2) {
					l2.className = 'checkbox';
					l2.style.paddingRight = '2px';
					$(l2).text(this.$infoTmpl);
					l2.style.fontSize = '98%';
				}))).element$1();
			}));
			store.add_onStoreChanged(ss.mkdel(this, function(st, dt) {
				this.update();
			}));
		};
		$type.prototype = {
			navigator: function() {
				return this.$divnav;
			},
			pageText: function(text) {
				this.$pText = text;
				return this;
			},
			ofTotalText: function(text) {
				this.$ofText = text;
				return this;
			},
			infoTemplate: function(text) {
				this.$infoTmpl = text;
				return this;
			},
			update: function() {
				//currentPage.SetValue (1);
				var lo = this.$store_.getLastOption();
				var pageNumber = (ss.isValue(lo.pageNumber) ? ss.Nullable.unbox(lo.pageNumber) : 0);
				var pageSize = (ss.isValue(lo.pageSize) ? ss.Nullable.unbox(lo.pageSize) : 0);
				var from_ = pageNumber * pageSize + 1;
				var to_ = pageNumber * pageSize + (ss.isValue(lo.pageSize) ? ss.Nullable.unbox(lo.pageSize) : 0);
				var pagesCount = this.$store_.getPagesCount();
				if (to_ > this.$store_.getTotalCount()) {
					to_ = this.$store_.getTotalCount();
				}
				if (to_ === 0) {
					from_ = 0;
				}
				this.$first.disabled = !this.$store_.hasPreviousPage();
				this.$prev.disabled = !this.$store_.hasPreviousPage();
				this.$next.disabled = !this.$store_.hasNextPage();
				this.$last.disabled = !this.$store_.hasNextPage();
				$(this.$page).text(this.$pText);
				cayita.fn.setValue(this.$currentPage, pageNumber + 1);
				//currentPage.AutoNumeric(new {vMax=pagesCount});
				$(this.$totalPages).text(this.$ofText + ' ' + pagesCount.toString());
				$(this.$info).text(ss.formatString(this.$infoTmpl, from_, to_, this.$store_.getTotalCount()));
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_StorePaging$1, [T], function() {
			return $Cayita_UI_Div;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.StorePaging$1', $Cayita_UI_StorePaging$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SubmitButton
	var $Cayita_UI_SubmitButton = function(parent) {
		$Cayita_UI_ButtonBase.call(this);
		this.createButton(parent, 'submit');
	};
	$Cayita_UI_SubmitButton.$ctor1 = function(parent, element) {
		$Cayita_UI_ButtonBase.call(this);
		this.createButton(parent, 'submit');
		element(this.element$1());
	};
	$Cayita_UI_SubmitButton.$ctor1.prototype = $Cayita_UI_SubmitButton.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// System.SystemExtensions
	var $Cayita_UI_SystemExt = function() {
	};
	$Cayita_UI_SystemExt.toJsDate = function(date) {
		if (ss.staticEquals(date, null)) {
			return null;
		}
		var tick = parseInt(date.toString());
		var d = new Date(tick);
		return new Date(d.getUTCFullYear(), d.getUTCMonth() + 1, d.getUTCDate(), d.getUTCHours(), d.getUTCMinutes(), d.getUTCSeconds());
	};
	$Cayita_UI_SystemExt.format = function(date, format) {
		if (ss.staticEquals(date, null)) {
			return '';
		}
		return ss.formatDate(date, format);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableBody
	var $Cayita_UI_TableBody = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('tbody', parent);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableCell
	var $Cayita_UI_TableCell = function() {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', null);
	};
	$Cayita_UI_TableCell.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TableCell.$ctor3 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', parent);
		element(this.element$1());
	};
	$Cayita_UI_TableCell.$ctor2 = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', parent);
	};
	$Cayita_UI_TableCell.$ctor1 = function(element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', null);
		element(this.element$1());
	};
	$Cayita_UI_TableCell.$ctor3.prototype = $Cayita_UI_TableCell.$ctor2.prototype = $Cayita_UI_TableCell.$ctor1.prototype = $Cayita_UI_TableCell.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableColumn
	var $Cayita_UI_TableColumn$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = {};
			$this.header = null;
			$this.value = null;
			$this.footer = null;
			$this.hidden = false;
			$this.afterCellCreate = null;
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_TableColumn$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.TableColumn$1', $Cayita_UI_TableColumn$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableFooter
	var $Cayita_UI_TableFooter = function(parent) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('tfoot', parent);
	};
	$Cayita_UI_TableFooter.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_TableFooter.$ctor1 = function(parent, element) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('tfoot', parent);
		element(this.element$2());
	};
	$Cayita_UI_TableFooter.$ctor1.prototype = $Cayita_UI_TableFooter.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableHeader
	var $Cayita_UI_TableHeader = function(parent) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('thead', parent);
	};
	$Cayita_UI_TableHeader.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_TableHeader.$ctor1 = function(parent, element) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('thead', parent);
		element(this.element$2());
	};
	$Cayita_UI_TableHeader.$ctor1.prototype = $Cayita_UI_TableHeader.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableRow
	var $Cayita_UI_TableRow = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('tr', parent);
	};
	$Cayita_UI_TableRow.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TableRow.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('tr', parent);
		element(this.element$1());
	};
	$Cayita_UI_TableRow.$ctor1.prototype = $Cayita_UI_TableRow.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TextArea
	var $Cayita_UI_TextArea = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_TextArea.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TextArea.$ctor2 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('textarea', parent);
		element(this.element$1());
	};
	$Cayita_UI_TextArea.$ctor1 = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('textarea', parent);
	};
	$Cayita_UI_TextArea.$ctor2.prototype = $Cayita_UI_TextArea.$ctor1.prototype = $Cayita_UI_TextArea.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TextAreaField
	var $Cayita_UI_TextAreaField = function(parent, field) {
		this.$controlGroup = null;
		this.$label = null;
		this.$controls = null;
		$Cayita_UI_TextArea.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cge) {
			this.$label = $Cayita_UI_Label.createControlLabel(cge, '', null, true);
			this.$controls = $Cayita_UI_Div.createControls$1(cge, ss.mkdel(this, function(cte) {
				this.createElement('textarea', cte);
				field(this.$label.element$1(), this.element$1());
				this.$label.forField$1(this.element$1().id);
			}));
			if (ss.isNullOrEmptyString(this.$label.textLabel())) {
				this.$label.hide();
			}
		}));
	};
	$Cayita_UI_TextAreaField.prototype = {
		getControlGroup: function() {
			return this.$controlGroup;
		},
		getControls: function() {
			return this.$controls;
		},
		getLabel: function() {
			return this.$label;
		}
	};
	$Cayita_UI_TextAreaField.$ctor1 = function(parent, field) {
		this.$controlGroup = null;
		this.$label = null;
		this.$controls = null;
		$Cayita_UI_TextArea.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cge) {
			this.$label = $Cayita_UI_Label.createControlLabel(cge, '', null, true);
			this.$label.hide();
			this.$controls = new $Cayita_UI_Div.$ctor1(cge, ss.mkdel(this, function(cte) {
				this.createElement('textarea', cte);
				field(this.element$1());
				this.$label.forField$1(this.element$1().id);
			}));
		}));
	};
	$Cayita_UI_TextAreaField.$ctor2 = function(parent, label, fieldname) {
		$Cayita_UI_TextAreaField.call(this, parent, function(l, f) {
			$(l).text(label);
			f.name = fieldname;
		});
	};
	$Cayita_UI_TextAreaField.$ctor1.prototype = $Cayita_UI_TextAreaField.$ctor2.prototype = $Cayita_UI_TextAreaField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TextField
	var $Cayita_UI_TextField = function(parent, field) {
		this.$controlGroup = null;
		this.$label = null;
		this.$controls = null;
		$Cayita_UI_InputText.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cge) {
			this.$label = $Cayita_UI_Label.createControlLabel(cge, '', null, true);
			this.$controls = $Cayita_UI_Div.createControls$1(cge, ss.mkdel(this, function(cte) {
				this.createInput(cte, 'text');
				field(this.$label.element$1(), this.element$2());
				this.$label.forField$1(this.element$2().id);
			}));
			if (ss.isNullOrEmptyString(this.$label.textLabel())) {
				this.$label.hide();
			}
		}));
	};
	$Cayita_UI_TextField.prototype = {
		getControlGroup: function() {
			return this.$controlGroup;
		},
		getControls: function() {
			return this.$controls;
		},
		getLabel: function() {
			return this.$label;
		}
	};
	$Cayita_UI_TextField.$ctor1 = function(parent, field) {
		this.$controlGroup = null;
		this.$label = null;
		this.$controls = null;
		$Cayita_UI_InputText.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cge) {
			this.$label = $Cayita_UI_Label.createControlLabel(cge, '', null, true);
			this.$label.hide();
			this.$controls = new $Cayita_UI_Div.$ctor1(cge, ss.mkdel(this, function(cte) {
				this.createInput(cte, 'text');
				field(this.element$2());
				this.$label.forField$1(this.element$2().id);
			}));
		}));
	};
	$Cayita_UI_TextField.$ctor2 = function(parent, label, fieldname) {
		$Cayita_UI_TextField.call(this, parent, function(l, f) {
			$(l).text(label);
			f.name = fieldname;
		});
	};
	$Cayita_UI_TextField.$ctor1.prototype = $Cayita_UI_TextField.$ctor2.prototype = $Cayita_UI_TextField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TopNavBar
	var $Cayita_UI_TopNavBar = function(parent, brandText, navlist) {
		$Cayita_UI_TopNavBar.$ctor1.call(this, parent, brandText, '', '', navlist);
	};
	$Cayita_UI_TopNavBar.prototype = {
		getContainerFluid: function() {
			return this.$containerFluid;
		},
		getNavCollapse: function() {
			return this.$navCollapse;
		},
		getBrand: function() {
			return this.$brand;
		},
		getPullRightParagraph: function() {
			return this.$pullRightParagraph;
		},
		getPullRightAnchor: function() {
			return this.$pullRightAnchor;
		},
		getNavList: function() {
			return this.$navList;
		}
	};
	$Cayita_UI_TopNavBar.$ctor1 = function(parent, brandText, rightText, rightLinkText, navlist) {
		this.$containerFluid = null;
		this.$navCollapse = null;
		this.$brand = null;
		this.$pullRightParagraph = null;
		this.$pullRightAnchor = null;
		this.$navList = null;
		$Cayita_UI_Div.call(this, parent);
		this.element$1().className = 'navbar';
		new $Cayita_UI_Div.$ctor1(this.element$1(), ss.mkdel(this, function(inner) {
			inner.className = 'navbar-inner';
			this.$containerFluid = $Cayita_UI_Div.createContainerFluid$1(inner, ss.mkdel(this, function(fluid) {
				new $Cayita_UI_Anchor.$ctor1(fluid, function(anchor) {
					anchor.className = 'btn btn-navbar';
					anchor.setAttribute('data-toggle', 'collapse');
					anchor.setAttribute('data-target', '.nav-collapse');
					for (var i = 0; i < 3; i++) {
						new $Cayita_UI_Span.$ctor1(anchor, function(span) {
							span.className = 'icon-bar';
						});
					}
				});
				this.$brand = (new $Cayita_UI_Anchor.$ctor1(fluid, function(brnd) {
					brnd.href = '#';
					$(brnd).text(brandText);
					brnd.className = 'brand';
				})).element$1();
				this.$navCollapse = new $Cayita_UI_Div.$ctor1(fluid, ss.mkdel(this, function(collapse) {
					collapse.className = 'nav-collapse collapse';
					this.$pullRightParagraph = (new $Cayita_UI_Paragraph.$ctor1(collapse, ss.mkdel(this, function(paragraph) {
						paragraph.className = 'navbar-text pull-right';
						$(paragraph).text(rightText);
						this.$pullRightAnchor = (new $Cayita_UI_Anchor.$ctor1(paragraph, function(a) {
							a.href = '#';
							a.className = 'navbar-link';
							$(a).text(rightLinkText);
						})).element$1();
					}))).element();
					this.$navList = $Cayita_UI_HtmlList.createNavList$1(collapse, navlist);
					this.$navList.removeClass$1('nav-list');
				}));
			}));
		}));
	};
	$Cayita_UI_TopNavBar.$ctor1.prototype = $Cayita_UI_TopNavBar.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// jQueryApi.ReqExtensions
	var $jQueryApi_ReqExtensions = function() {
	};
	ss.registerClass(global, 'Message', $Message);
	ss.registerClass(global, 'MessageFor', $MessageFor);
	ss.registerClass(global, 'Range', $Range);
	ss.registerClass(global, 'Rule', $Rule);
	ss.registerClass(global, 'RuleFor', $RuleFor);
	ss.registerClass(global, 'ValidateOptions', $ValidateOptions);
	ss.registerClass(global, 'Cayita.Ajax.AjaxResponse', $Cayita_Ajax_AjaxResponse);
	ss.registerClass(global, 'Cayita.Ajax.AppError', $Cayita_Ajax_AppError);
	ss.registerClass(global, 'Cayita.Ajax.ResponseStatus', $Cayita_Ajax_ResponseStatus);
	ss.registerClass(global, 'Cayita.Data.ReadOptions', $Cayita_Data_ReadOptions);
	ss.registerClass(global, 'Cayita.Data.StoreRequest', $Cayita_Data_StoreRequest);
	ss.registerClass(global, 'Cayita.Javascript.ModuleBase', $Cayita_Javascript_ModuleBase);
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreChangedAction', $Cayita_Javascript_Data_StoreChangedAction);
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreErrorAction', $Cayita_Javascript_Data_StoreErrorAction);
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreRequestAction', $Cayita_Javascript_Data_StoreRequestAction);
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreRequestState', $Cayita_Javascript_Data_StoreRequestState);
	ss.registerClass(global, 'Cayita.Javascript.UI.Bootbox', $Cayita_Javascript_UI_Bootbox);
	ss.registerClass(global, 'Cayita.Javascript.UI.DialogButton', $Cayita_Javascript_UI_DialogButton);
	ss.registerClass(global, 'Cayita.Javascript.UI.DialogOptions', $Cayita_Javascript_UI_DialogOptions);
	ss.registerClass(global, 'Cayita.UI.ElementBase', $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Anchor', $Cayita_UI_Anchor, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.ButtonBase', $Cayita_UI_ButtonBase, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Button', $Cayita_UI_Button, $Cayita_UI_ButtonBase);
	ss.registerClass(global, 'Cayita.UI.InputBase', $Cayita_UI_InputBase, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.InputCheckbox', $Cayita_UI_InputCheckbox, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.CheckboxField', $Cayita_UI_CheckboxField, $Cayita_UI_InputCheckbox);
	ss.registerClass(global, 'Cayita.UI.Div', $Cayita_UI_Div, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Ext', $Cayita_UI_Ext);
	ss.registerClass(global, 'Cayita.UI.FieldSet', $Cayita_UI_FieldSet, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Form', $Cayita_UI_Form, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlList', $Cayita_UI_HtmlList, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlOption', $Cayita_UI_HtmlOption, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlSelect', $Cayita_UI_HtmlSelect, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlTable', $Cayita_UI_HtmlTable, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Icon', $Cayita_UI_Icon, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.IconAnchor', $Cayita_UI_IconAnchor, $Cayita_UI_Anchor);
	ss.registerClass(global, 'Cayita.UI.IconButton', $Cayita_UI_IconButton, $Cayita_UI_Button);
	ss.registerClass(global, 'Cayita.UI.Image', $Cayita_UI_Image, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Input', $Cayita_UI_Input, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.InputText', $Cayita_UI_InputText, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.InputPassword', $Cayita_UI_InputPassword, $Cayita_UI_InputText);
	ss.registerClass(global, 'Cayita.UI.InputRadio', $Cayita_UI_InputRadio, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.Label', $Cayita_UI_Label, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Legend', $Cayita_UI_Legend, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.ListItem', $Cayita_UI_ListItem, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Paragraph', $Cayita_UI_Paragraph, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.RadioField', $Cayita_UI_RadioField, $Cayita_UI_Div);
	ss.registerClass(global, 'Cayita.UI.RadioItem', $Cayita_UI_RadioItem);
	ss.registerClass(global, 'Cayita.UI.RequestMessage', $Cayita_UI_RequestMessage);
	ss.registerClass(global, 'Cayita.UI.ResetButton', $Cayita_UI_ResetButton, $Cayita_UI_ButtonBase);
	ss.registerClass(global, 'Cayita.UI.SelectedRow', $Cayita_UI_SelectedRow);
	ss.registerClass(global, 'Cayita.UI.SelectField', $Cayita_UI_SelectField, $Cayita_UI_HtmlSelect);
	ss.registerClass(global, 'Cayita.UI.SideNavBar', $Cayita_UI_SideNavBar, $Cayita_UI_Div);
	ss.registerClass(global, 'Cayita.UI.Span', $Cayita_UI_Span, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.SpinnerIcon', $Cayita_UI_SpinnerIcon, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.SubmitButton', $Cayita_UI_SubmitButton, $Cayita_UI_ButtonBase);
	ss.registerClass(global, 'Cayita.UI.SystemExt', $Cayita_UI_SystemExt);
	ss.registerClass(global, 'Cayita.UI.TableBody', $Cayita_UI_TableBody, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TableCell', $Cayita_UI_TableCell, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TableFooter', $Cayita_UI_TableFooter, $Cayita_UI_HtmlTable);
	ss.registerClass(global, 'Cayita.UI.TableHeader', $Cayita_UI_TableHeader, $Cayita_UI_HtmlTable);
	ss.registerClass(global, 'Cayita.UI.TableRow', $Cayita_UI_TableRow, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TextArea', $Cayita_UI_TextArea, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TextAreaField', $Cayita_UI_TextAreaField, $Cayita_UI_TextArea);
	ss.registerClass(global, 'Cayita.UI.TextField', $Cayita_UI_TextField, $Cayita_UI_InputText);
	ss.registerClass(global, 'Cayita.UI.TopNavBar', $Cayita_UI_TopNavBar, $Cayita_UI_Div);
	ss.registerClass(global, 'jQueryApi.ReqExtensions', $jQueryApi_ReqExtensions);
	$Cayita_UI_ElementBase.$tags = new (ss.makeGenericType(ss.Dictionary$2, [String, ss.Int32]))();
})();
