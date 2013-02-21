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
			$this.rl.mail = true;
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
		$this.rules[rulefor.element.name] = rulefor.rule.rl;
		$this.messages[rulefor.element.name] = msg.msg;
		return $this;
	};
	$ValidateOptions.$ctor = function() {
		var $this = {};
		$this.submitHandler = null;
		$this.highlight = null;
		$this.unhighlight = null;
		$this.success = null;
		$this.messages = {};
		$this.rules = {};
		$ValidateOptions.setHighlightHandler($this, function(element) {
			$(element).closest('.control-group').removeClass('success').addClass('error');
		});
		$ValidateOptions.setSuccessHandler($this, function(label) {
			label.closest('.control-group').removeClass('error').addClass('success');
		});
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Ajax.AppError
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
	// Cayita.Javascript.Ajax.ResponseError
	var $Cayita_Ajax_ResponseError = function() {
	};
	$Cayita_Ajax_ResponseError.createInstance = function() {
		return $Cayita_Ajax_ResponseError.$ctor();
	};
	$Cayita_Ajax_ResponseError.$ctor = function() {
		var $this = {};
		$this.ResponseStatus = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Ajax.ResponseStatus
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
			this.$createFunc = ss.mkdel(this, function(record) {
				var $t7 = this.$1$OnStoreRequestField;
				var $t6 = $Cayita_Data_StoreRequest.$ctor();
				$t6.action = 0;
				$t6.state = 0;
				$t7(this, $t6);
				return $.post(this.$createApi.url, record, function(cb) {
				}, this.$createApi.dataType).done(ss.mkdel(this, function(scb) {
					var r = this.$createApi.dataProperty;
					var data1 = scb;
					if (Array.isArray(data1[r])) {
						var $t8 = ss.getEnumerator(ss.cast(data1[r], ss.IList));
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
						ss.add(this.$st, ss.cast(data1[r], T));
						var $t12 = this.$1$OnStoreChangedField;
						var $t11 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
						$t11.newData = ss.cast(data1[r], T);
						$t11.oldData = ss.cast(data1[r], T);
						$t11.action = 0;
						$t12(this, $t11);
					}
				})).fail(ss.mkdel(this, function(f) {
					var $t14 = this.$1$OnStoreErrorField;
					var $t13 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t13.action = 0;
					$t13.request = f;
					$t14(this, $t13);
				})).always(ss.mkdel(this, function(t) {
					var $t16 = this.$1$OnStoreRequestField;
					var $t15 = $Cayita_Data_StoreRequest.$ctor();
					$t15.action = 0;
					$t15.state = 1;
					$t16(this, $t15);
				}));
			});
			this.$readFunc = ss.mkdel(this, function(readOptions) {
				var $t18 = this.$1$OnStoreRequestField;
				var $t17 = $Cayita_Data_StoreRequest.$ctor();
				$t17.action = 1;
				$t17.state = 0;
				$t18(this, $t17);
				return $.get(this.$readApi.url, this.requestObject(readOptions), function(cb1) {
				}, this.$readApi.dataType).done(ss.mkdel(this, function(scb1) {
					var r1 = this.$readApi.dataProperty;
					var data2 = scb1;
					if (Array.isArray(data2[r1])) {
						var $t19 = ss.getEnumerator(ss.cast(data2[r1], ss.IList));
						try {
							while ($t19.moveNext()) {
								var item1 = $t19.current();
								ss.add(this.$st, item1);
							}
						}
						finally {
							$t19.dispose();
						}
					}
					else {
						ss.add(this.$st, ss.cast(data2[r1], T));
					}
					var tc = ss.cast(data2[this.$readApi.totalCountProperty], ss.Int32);
					this.$totalCount = (ss.isValue(tc) ? ss.Nullable.unbox(tc) : this.$st.length);
					console.log('Store Done data, tc totalCount ', data2, tc, this.$totalCount);
					var $t21 = this.$1$OnStoreChangedField;
					var $t20 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t20.action = 1;
					$t21(this, $t20);
				})).fail(ss.mkdel(this, function(f1) {
					var $t23 = this.$1$OnStoreErrorField;
					var $t22 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t22.action = 1;
					$t22.request = f1;
					$t23(this, $t22);
				})).always(ss.mkdel(this, function(f2) {
					var $t25 = this.$1$OnStoreRequestField;
					var $t24 = $Cayita_Data_StoreRequest.$ctor();
					$t24.action = 1;
					$t24.state = 1;
					$t25(this, $t24);
				}));
			});
			this.$updateFunc = ss.mkdel(this, function(record1) {
				var $t27 = this.$1$OnStoreRequestField;
				var $t26 = $Cayita_Data_StoreRequest.$ctor();
				$t26.action = 2;
				$t26.state = 0;
				$t27(this, $t26);
				return $.post(this.$updateApi.url, record1, function(cb2) {
				}, this.$updateApi.dataType).done(ss.mkdel(this, function(scb2) {
					var r2 = this.$updateApi.dataProperty;
					var data3 = scb2;
					if (Array.isArray(data3[r2])) {
						var $t28 = ss.getEnumerator(ss.cast(data3[r2], ss.IList));
						try {
							while ($t28.moveNext()) {
								var item2 = $t28.current();
								var i = { $: item2 };
								var ur = Enumerable.from(this.$st).first(function(f3) {
									return ss.referenceEquals(f3[this.$idProperty], i.$[this.$idProperty]);
								});
								var old = ss.createInstance(T);
								cayita.fn.populateFrom(old, ur);
								cayita.fn.populateFrom(ur, item2);
								var $t30 = this.$1$OnStoreChangedField;
								var $t29 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
								$t29.newData = ur;
								$t29.oldData = old;
								$t29.action = 2;
								$t30(this, $t29);
							}
						}
						finally {
							$t28.dispose();
						}
					}
					else {
						var i1 = data3[r2];
						var ur1 = Enumerable.from(this.$st).first(function(f4) {
							return ss.referenceEquals(f4[this.$idProperty], i1[this.$idProperty]);
						});
						var old1 = ss.createInstance(T);
						cayita.fn.populateFrom(old1, ur1);
						cayita.fn.populateFrom(ur1, ss.cast(data3[r2], T));
						var $t32 = this.$1$OnStoreChangedField;
						var $t31 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
						$t31.newData = ur1;
						$t31.oldData = old1;
						$t31.action = 2;
						$t32(this, $t31);
					}
				})).fail(ss.mkdel(this, function(f5) {
					var $t34 = this.$1$OnStoreErrorField;
					var $t33 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t33.action = 2;
					$t33.request = f5;
					$t34(this, $t33);
				})).always(ss.mkdel(this, function(f6) {
					var $t36 = this.$1$OnStoreRequestField;
					var $t35 = $Cayita_Data_StoreRequest.$ctor();
					$t35.action = 2;
					$t35.state = 1;
					$t36(this, $t35);
				}));
			});
			this.$destroyFunc = ss.mkdel(this, function(record2) {
				var $t38 = this.$1$OnStoreRequestField;
				var $t37 = $Cayita_Data_StoreRequest.$ctor();
				$t37.action = 3;
				$t37.state = 0;
				$t38(this, $t37);
				var req = {};
				req[this.$idProperty] = record2[this.$idProperty];
				return $.post(this.$destroyApi.url, req, function(cb3) {
				}, this.$destroyApi.dataType).done(ss.mkdel(this, function(scb3) {
					var dr = Enumerable.from(this.$st).first(function(f7) {
						return ss.referenceEquals(f7[this.$idProperty], record2[this.$idProperty]);
					});
					ss.remove(this.$st, dr);
					var $t40 = this.$1$OnStoreChangedField;
					var $t39 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
					$t39.newData = dr;
					$t39.oldData = dr;
					$t39.action = 3;
					$t40(this, $t39);
				})).fail(ss.mkdel(this, function(f8) {
					var $t42 = this.$1$OnStoreErrorField;
					var $t41 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t41.action = 3;
					$t41.request = f8;
					$t42(this, $t41);
				})).always(ss.mkdel(this, function(f9) {
					var $t44 = this.$1$OnStoreRequestField;
					var $t43 = $Cayita_Data_StoreRequest.$ctor();
					$t43.action = 3;
					$t43.state = 1;
					$t44(this, $t43);
				}));
			});
			this.$patchFunc = ss.mkdel(this, function(record3) {
				var $t46 = this.$1$OnStoreRequestField;
				var $t45 = $Cayita_Data_StoreRequest.$ctor();
				$t45.action = 4;
				$t45.state = 0;
				$t46(this, $t45);
				return $.post(this.$patchApi.url, record3, function(cb4) {
				}, this.$patchApi.dataType).done(ss.mkdel(this, function(scb4) {
					var r3 = this.$updateApi.dataProperty;
					var data4 = scb4;
					if (!!data4[r3].IsArray()) {
						var $t47 = ss.getEnumerator(ss.cast(data4[r3], ss.IList));
						try {
							while ($t47.moveNext()) {
								var item3 = $t47.current();
								var i2 = { $: item3 };
								var ur2 = Enumerable.from(this.$st).first(function(f10) {
									return ss.referenceEquals(f10[this.$idProperty], i2.$[this.$idProperty]);
								});
								var old2 = ss.createInstance(T);
								cayita.fn.populateFrom(old2, ur2);
								cayita.fn.populateFrom(ur2, item3);
								var $t49 = this.$1$OnStoreChangedField;
								var $t48 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
								$t48.newData = ur2;
								$t48.oldData = old2;
								$t48.action = 4;
								$t49(this, $t48);
							}
						}
						finally {
							$t47.dispose();
						}
					}
					else {
						var i3 = data4[r3];
						var ur3 = Enumerable.from(this.$st).first(function(f11) {
							return ss.referenceEquals(f11[this.$idProperty], i3[this.$idProperty]);
						});
						var old3 = ss.createInstance(T);
						cayita.fn.populateFrom(old3, ur3);
						cayita.fn.populateFrom(ur3, ss.cast(data4[r3], T));
						var $t51 = this.$1$OnStoreChangedField;
						var $t50 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
						$t50.newData = ur3;
						$t50.oldData = old3;
						$t50.action = 4;
						$t51(this, $t50);
					}
				})).fail(ss.mkdel(this, function(f12) {
					var $t53 = this.$1$OnStoreErrorField;
					var $t52 = ss.makeGenericType($Cayita_Data_StoreError$1, [T]).$ctor();
					$t52.action = 4;
					$t52.request = f12;
					$t53(this, $t52);
				})).always(ss.mkdel(this, function(f13) {
					var $t55 = this.$1$OnStoreRequestField;
					var $t54 = $Cayita_Data_StoreRequest.$ctor();
					$t54.action = 4;
					$t54.state = 1;
					$t55(this, $t54);
				}));
			});
		};
		$type.prototype = {
			setIdProperty: function(value) {
				this.$idProperty = value;
			},
			getRecordIdProperty: function() {
				return this.$idProperty;
			},
			getTotalCount: function() {
				return this.$totalCount;
			},
			setCreateFunc: function(createFunc) {
				this.$createFunc = createFunc;
			},
			setReadFunc: function(readFunc) {
				this.$readFunc = readFunc;
			},
			setUpdateFunc: function(updateFunc) {
				this.$updateFunc = updateFunc;
			},
			setDestroyFunc: function(destroyFunc) {
				this.$destroyFunc = destroyFunc;
			},
			setPatchFunc: function(patchFunc) {
				this.$patchFunc = patchFunc;
			},
			setCreateApi: function(api) {
				api(this.$createApi);
			},
			setReadApi: function(api) {
				api(this.$readApi);
			},
			getReadApi: function() {
				return this.$readApi;
			},
			setUpdateApi: function(api) {
				api(this.$updateApi);
			},
			setDestroyApi: function(api) {
				api(this.$destroyApi);
			},
			setPatchApi: function(api) {
				api(this.$patchApi);
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
				$Cayita_UI_Ext.loadTo(T).call(null, form, record);
				this.create$2(record);
			},
			read: function(options) {
				var readOptions = $Cayita_Data_ReadOptions.$ctor();
				if (!ss.staticEquals(options, null)) {
					options(readOptions);
				}
				if (ss.isValue(readOptions.pageNumber) && (!ss.isValue(readOptions.pageSize) || ss.isValue(readOptions.pageSize) && ss.Nullable.unbox(readOptions.pageSize) === 0)) {
					readOptions.pageSize = this.$defaultPageSize;
				}
				this.$lastOption = readOptions;
				return this.$readFunc(readOptions);
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
				if (ss.isValue(readOptions.pageSize)) {
					ro[readOptions.pageSizeParam] = readOptions.pageSize;
				}
				if (ss.isValue(readOptions.pageNumber)) {
					ro[readOptions.pageNumberParam] = readOptions.pageNumber;
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
				return this.$st.length;
			},
			add: function(item) {
				ss.add(this.$st, item);
				var $t2 = this.$1$OnStoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = item;
				$t1.oldData = item;
				$t1.action = 5;
				$t1.index = this.$st.length - 1;
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
				return ss.getEnumerator(this.$st);
			},
			load: function(data, append) {
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
				if (ss.isNullOrUndefined(this.$lastOption) || this.$st.length === this.$totalCount) {
					return false;
				}
				return ss.Int32.div(this.$totalCount, ss.Nullable.unbox(this.$lastOption.pageSize)) < ss.Nullable.unbox(this.$lastOption.pageNumber);
			},
			hasPreviousPage: function() {
				return !(ss.isNullOrUndefined(this.$lastOption) || this.$st.length === this.$totalCount || !ss.isValue(this.$lastOption.pageNumber) || ss.isValue(this.$lastOption.pageNumber) && ss.Nullable.unbox(this.$lastOption.pageNumber) === 0);
			},
			getNextPage: function() {
				if (this.hasNextPage()) {
					this.$lastOption.pageNumber = ss.Nullable.add(this.$lastOption.pageNumber, 1);
				}
				return this.$readFunc(this.$lastOption);
			},
			getPreviousPage: function() {
				if (this.hasNextPage()) {
					this.$lastOption.pageNumber = ss.Nullable.sub(this.$lastOption.pageNumber, 1);
				}
				return this.$readFunc(this.$lastOption);
			},
			refresh: function() {
				return this.$readFunc(this.$lastOption);
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
			return Object;
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
			$this.url = 'api/' + ss.getTypeName(T);
			$this.dataType = 'json';
			$this.dataProperty = 'Result';
			$this.totalCountProperty = 'TotalCount';
			$this.htmlProperty = 'Html';
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_Data_StoreApi$1, [T], function() {
			return Object;
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
			return Object;
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
			return Object;
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
	$Cayita_Javascript_Data_StoreChangedAction.prototype = { created: 0, read: 1, updated: 2, destroyed: 3, patched: 4, added: 5, inserted: 6, replaced: 7, removed: 8, cleared: 9, loaded: 10 };
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreChangedAction', $Cayita_Javascript_Data_StoreChangedAction, false);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreErrorAction
	var $Cayita_Javascript_Data_StoreErrorAction = function() {
	};
	$Cayita_Javascript_Data_StoreErrorAction.prototype = { create: 0, read: 1, update: 2, destroy: 3, patch: 4 };
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreErrorAction', $Cayita_Javascript_Data_StoreErrorAction, false);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreRequestAction
	var $Cayita_Javascript_Data_StoreRequestAction = function() {
	};
	$Cayita_Javascript_Data_StoreRequestAction.prototype = { create: 0, read: 1, update: 2, destroy: 3, patch: 4 };
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreRequestAction', $Cayita_Javascript_Data_StoreRequestAction, false);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Data.StoreRequestState
	var $Cayita_Javascript_Data_StoreRequestState = function() {
	};
	$Cayita_Javascript_Data_StoreRequestState.prototype = { started: 0, finished: 1 };
	ss.registerEnum(global, 'Cayita.Javascript.Data.StoreRequestState', $Cayita_Javascript_Data_StoreRequestState, false);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Anchor
	var $Cayita_UI_Anchor = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent);
	};
	$Cayita_UI_Anchor.prototype = {
		$init: function(parent) {
			this.createElement('a', parent, $Cayita_UI_ElementConfig.$ctor());
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
		$Cayita_UI_ButtonBase.$ctor1.call(this, parent, $Cayita_UI_ButtonConfig.$ctor(), 'button');
	};
	$Cayita_UI_Button.$ctor1 = function(parent, element) {
		$Cayita_UI_ButtonBase.$ctor1.call(this, parent, $Cayita_UI_ButtonConfig.$ctor(), 'button');
		element(this.element$1());
	};
	$Cayita_UI_Button.$ctor1.prototype = $Cayita_UI_Button.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ButtonBase
	var $Cayita_UI_ButtonBase = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_ButtonBase.prototype = {
		createButton: function(parent, config, type) {
			this.createElement('button', parent, config);
			if (!ss.isNullOrEmptyString(type)) {
				this.element$1().type = type;
			}
			if (!ss.isNullOrEmptyString(config.text)) {
				this.text(config.text);
			}
			if (!ss.isNullOrEmptyString(config.loadingText)) {
				this.loadingText(config.loadingText);
			}
		},
		text: function(value) {
			this.jSelect().text(value);
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
	$Cayita_UI_ButtonBase.$ctor1 = function(parent, config, type) {
		$Cayita_UI_ElementBase.call(this);
		this.createButton(parent, config, type);
	};
	$Cayita_UI_ButtonBase.$ctor1.prototype = $Cayita_UI_ButtonBase.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ButtonConfig
	var $Cayita_UI_ButtonConfig = function() {
	};
	$Cayita_UI_ButtonConfig.createInstance = function() {
		return $Cayita_UI_ButtonConfig.$ctor();
	};
	$Cayita_UI_ButtonConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.text = null;
		$this.loadingText = null;
		$this.cssClass = 'btn';
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.CheckboxConfig
	var $Cayita_UI_CheckboxConfig = function() {
	};
	$Cayita_UI_CheckboxConfig.createInstance = function() {
		return $Cayita_UI_CheckboxConfig.$ctor();
	};
	$Cayita_UI_CheckboxConfig.$ctor = function() {
		var $this = $Cayita_UI_InputConfig.$ctor();
		$this.checked = false;
		$this.value = 'true';
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.CheckboxField
	var $Cayita_UI_CheckboxField = function(parent, field) {
		$Cayita_UI_CheckboxField.$ctor1.call(this, parent.element(), field);
	};
	$Cayita_UI_CheckboxField.prototype = {
		getControGroup: function() {
			return this.$controlGroup;
		},
		getControls: function() {
			return this.$controls;
		}
	};
	$Cayita_UI_CheckboxField.$ctor1 = function(parent, field) {
		this.$controlGroup = null;
		this.$controls = null;
		$Cayita_UI_InputCheckbox.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.$controls = $Cayita_UI_Div.createControls$1(cgDiv, ss.mkdel(this, function(ctdiv) {
				var $t1 = $Cayita_UI_LabelConfig.$ctor();
				$t1.cssClass = 'checkbox';
				var label = new $Cayita_UI_Label(ctdiv, $t1);
				this.init(null, $Cayita_UI_CheckboxConfig.$ctor());
				label.forField$1(this.element$2().id);
				field(label.element(), this.element$2());
				label.element().appendChild(this.element$2());
			}));
		}));
	};
	$Cayita_UI_CheckboxField.$ctor2 = function(parent, textLabel, field) {
		this.$controlGroup = null;
		this.$controls = null;
		$Cayita_UI_InputCheckbox.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.$controls = $Cayita_UI_Div.createControls$1(cgDiv, ss.mkdel(this, function(ctdiv) {
				var $t1 = $Cayita_UI_LabelConfig.$ctor();
				$t1.cssClass = 'checkbox';
				$t1.textLabel = textLabel;
				var label = new $Cayita_UI_Label(ctdiv, $t1);
				this.init(null, $Cayita_UI_CheckboxConfig.$ctor());
				label.forField$1(this.element$2().id);
				field(this.element$2());
				label.element().appendChild(this.element$2());
			}));
		}));
	};
	$Cayita_UI_CheckboxField.$ctor1.prototype = $Cayita_UI_CheckboxField.$ctor2.prototype = $Cayita_UI_CheckboxField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Div
	var $Cayita_UI_Div = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('div', parent, $Cayita_UI_DivConfig.$ctor());
	};
	$Cayita_UI_Div.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Div.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('div', parent, $Cayita_UI_DivConfig.$ctor());
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
	$Cayita_UI_Div.createAlertError = function(parent, message) {
		var div = new $Cayita_UI_Div.$ctor1(parent, function(de) {
			de.className = 'alert alert-error';
			new $Cayita_UI_Anchor.$ctor1(de, function(element) {
				element.href = '#';
				element.className = 'close';
				element.setAttribute('data-dismiss', 'alert');
				element.innerText = '×';
			});
			$(de).append(message);
		});
		return div;
	};
	$Cayita_UI_Div.createAlertErrorBefore = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertErrorTemplate(), message)).insertBefore(element);
	};
	$Cayita_UI_Div.alertErrorTemplate = function() {
		return '<div class=\'alert alert-error\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Div.createAlertErrorAfter = function(element, message) {
		return $(ss.formatString($Cayita_UI_Div.alertErrorTemplate(), message)).insertAfter(element);
	};
	$Cayita_UI_Div.createPageAlertError = function(element, message) {
		var div = new $Cayita_UI_Div.$ctor1(element, function(de) {
			de.className = 'page-alert';
			$Cayita_UI_Div.createAlertError(de, message);
		});
		return div;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.DivConfig
	var $Cayita_UI_DivConfig = function() {
	};
	$Cayita_UI_DivConfig.createInstance = function() {
		return $Cayita_UI_DivConfig.$ctor();
	};
	$Cayita_UI_DivConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ElementBase
	var $Cayita_UI_ElementBase = function() {
		this.$element_ = null;
	};
	$Cayita_UI_ElementBase.prototype = {
		createElement: function(tagName, parent, config) {
			if (ss.isNullOrUndefined(config)) {
				config = $Cayita_UI_ElementConfig.$ctor();
			}
			this.$element_ = document.createElement(tagName);
			this.$element_.id = this.createId(tagName);
			if (!config.visible) {
				this.$element_.style.display = 'none';
			}
			if (!ss.isNullOrEmptyString(config.name)) {
				this.$element_.setAttribute('name', config.name);
			}
			this.className$1(config.cssClass);
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
		jSelect: function() {
			return $(this.$element_);
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
		appendTo: function(parent) {
			$(parent).append(this.$element_);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ElementConfig
	var $Cayita_UI_ElementConfig = function() {
	};
	$Cayita_UI_ElementConfig.createInstance = function() {
		return $Cayita_UI_ElementConfig.$ctor();
	};
	$Cayita_UI_ElementConfig.$ctor = function() {
		var $this = {};
		$this.visible = false;
		$this.cssClass = null;
		$this.name = null;
		$this.visible = true;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.Extensions
	var $Cayita_UI_Ext = function() {
	};
	$Cayita_UI_Ext.load$1 = function(T) {
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
		return function(form, data) {
			var o = data;
			var inputs = $('[name]', form).get();
			for (var $t1 = 0; $t1 < inputs.length; $t1++) {
				var input = inputs[$t1];
				var ie = input;
				if (ss.isNullOrEmptyString(ie.name)) {
					continue;
				}
				try {
					o[ie.name] = cayita.fn.getValue(ie);
				}
				catch ($t2) {
				}
			}
		};
	};
	$Cayita_UI_Ext.load = function(T) {
		return function(form, data) {
			var d = data;
			var inputs = $('[name]', form).get();
			for (var $t1 = 0; $t1 < inputs.length; $t1++) {
				var input = inputs[$t1];
				var ie = input;
				if (ss.isNullOrEmptyString(ie.name)) {
					continue;
				}
				cayita.fn.setValue(ie, d[ie.name]);
			}
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
	$Cayita_UI_Ext.load$2 = function(T) {
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
						}
					}));
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Form
	var $Cayita_UI_Form = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('form', parent, $Cayita_UI_FormConfig.$ctor());
	};
	$Cayita_UI_Form.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Form.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('form', parent, $Cayita_UI_FormConfig.$ctor());
		element(this.element$1());
	};
	$Cayita_UI_Form.$ctor1.prototype = $Cayita_UI_Form.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.FormConfig
	var $Cayita_UI_FormConfig = function() {
	};
	$Cayita_UI_FormConfig.createInstance = function() {
		return $Cayita_UI_FormConfig.$ctor();
	};
	$Cayita_UI_FormConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.method = null;
		$this.action = null;
		$this.acceptCharset = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.HtmlGrid
	var $Cayita_UI_HtmlGrid$1 = function(T) {
		var $type = function(parent, element, store, columns) {
			this.$columns = null;
			this.$store = null;
			this.$table = null;
			this.$selectedrow = null;
			this.$readRequestStarted = null;
			this.$readRequestFinished = null;
			this.$readRequestMessage = null;
			this.$3$OnRowSelectedField = null;
			$Cayita_UI_HtmlTable.call(this);
			this.createElement('table', parent, $Cayita_UI_ElementConfig.$ctor());
			this.$table = this.element$1();
			this.$table.className = 'table table-striped table-hover table-condensed';
			this.$table.setAttribute('data-provides', 'rowlink');
			element(this.$table);
			this.$columns = columns;
			this.$store = store;
			this.$3$OnRowSelectedField = function(grid, row) {
			};
			$(this.$table).on('click', 'tbody tr', ss.mkdel(this, function(e) {
				var row1 = e.currentTarget;
				this.$selectRowImp(row1, true);
			}));
			this.render();
			var $t1 = $Cayita_UI_RequestMessage.$ctor();
			$t1.target = this.$table.tBodies[0];
			$t1.message = 'Reading' + ss.getTypeName(T);
			this.$readRequestMessage = $t1;
			this.$readRequestStarted = ss.mkdel(this, function(grid1) {
				var sp = new $Cayita_UI_SpinnerIcon(function(div, icon) {
					div.style.position = 'fixed';
					div.style.zIndex = 10000;
					div.style.opacity = '0.7';
					div.style.height = (grid1.$table.clientHeight + 30).toString() + 'px';
					div.style.width = grid1.$table.clientWidth.toString() + 'px';
				}, this.$readRequestMessage.message);
				$(this.$readRequestMessage.target).insertBefore(sp.element$1());
				return sp.element$1();
			});
			this.$readRequestFinished = function(grid2, el) {
				$(el).remove();
			};
			store.add_onStoreChanged(ss.mkdel(this, function(st, dt) {
				switch (dt.action) {
					case 0: {
						$Cayita_UI_Ext.createRow(T).call(null, this.$table, dt.newData, columns, store.getRecordIdProperty());
						break;
					}
					case 1: {
						console.log('HtmlGrid: cargando filas en el grid 1 ', store, store.get_count());
						$Cayita_UI_Ext.load$2(T).call(null, this.$table, store, columns, store.getRecordIdProperty(), false);
						this.selectRow(true);
						break;
					}
					case 2: {
						$Cayita_UI_Ext.updateRow(T).call(null, this.$table, dt.newData, columns, store.getRecordIdProperty());
						break;
					}
					case 3: {
						var recordId = dt.oldData[store.getRecordIdProperty()];
						$('tr[record-id=' + recordId + ']', this.$table).remove();
						this.selectRow(true);
						break;
					}
					case 4: {
						$Cayita_UI_Ext.updateRow(T).call(null, this.$table, dt.newData, columns, store.getRecordIdProperty());
						break;
					}
					case 5: {
						$Cayita_UI_Ext.createRow(T).call(null, this.$table, dt.newData, columns, store.getRecordIdProperty());
						break;
					}
					case 7: {
						$Cayita_UI_Ext.updateRow(T).call(null, this.$table, dt.newData, columns, store.getRecordIdProperty());
						break;
					}
					case 6: {
						$Cayita_UI_Ext.createRow(T).call(null, this.$table, dt.newData, columns, store.getRecordIdProperty());
						break;
					}
					case 8: {
						var id = dt.oldData[store.getRecordIdProperty()];
						$('tr[record-id=' + id + ']', this.$table).remove();
						this.selectRow(true);
						break;
					}
					case 10: {
						$Cayita_UI_Ext.load$2(T).call(null, this.$table, store, columns, store.getRecordIdProperty(), false);
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
			store.add_onStoreRequest(ss.mkdel(this, function(st1, request) {
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
		};
		$type.prototype = {
			setReadRequestMessage: function(message) {
				message(this.$readRequestMessage);
				return this;
			},
			getSelectedRow: function() {
				return this.$selectedrow;
			},
			render: function() {
				$Cayita_UI_Ext.createHeader(T).call(null, this.$table, this.$columns);
				$Cayita_UI_Ext.load$2(T).call(null, this.$table, this.$store, this.$columns, this.$store.getRecordIdProperty(), false);
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
		this.createElement((ordered ? 'ol' : 'ul'), parent, $Cayita_UI_ListConfig.$ctor());
	};
	$Cayita_UI_HtmlList.$ctor1 = function(parent, element, ordered) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement((ordered ? 'ol' : 'ul'), parent, $Cayita_UI_ListConfig.$ctor());
		element(this.element());
	};
	$Cayita_UI_HtmlList.$ctor1.prototype = $Cayita_UI_HtmlList.prototype;
	$Cayita_UI_HtmlList.creatNavList = function(parent) {
		var l = new $Cayita_UI_HtmlList.$ctor1(parent, function(e) {
			e.className = 'nav nav-list';
		}, false);
		return l;
	};
	$Cayita_UI_HtmlList.creatNavList$1 = function(parent, element) {
		var nl = $Cayita_UI_HtmlList.creatNavList(parent);
		element(nl.element());
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
			this.createElement('option', parent, $Cayita_UI_ElementConfig.$ctor());
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
			this.createElement('select', parent, $Cayita_UI_ElementConfig.$ctor());
		},
		element$1: function() {
			return this.element();
		},
		load: function(T) {
			return function(data, func) {
				$Cayita_UI_Ext.load$1(T).call(null, this.element$1(), data, func, false);
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
		this.createElement('table', parent, $Cayita_UI_ElementConfig.$ctor());
		element(this.element$1());
	};
	$Cayita_UI_HtmlTable.$ctor1 = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('table', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_HtmlTable.$ctor2.prototype = $Cayita_UI_HtmlTable.$ctor1.prototype = $Cayita_UI_HtmlTable.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Icon
	var $Cayita_UI_Icon = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('i', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_Icon.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('i', parent, $Cayita_UI_ElementConfig.$ctor());
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
	// Cayita.Javascript.UI.Input
	var $Cayita_UI_Input = function(parent, config) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent.element(), config, '');
	};
	$Cayita_UI_Input.$ctor2 = function(parent, config, element) {
		$Cayita_UI_Input.$ctor3.call(this, parent.element(), config, element);
	};
	$Cayita_UI_Input.$ctor3 = function(parent, config, element) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, config, '');
		element(this.element$1());
	};
	$Cayita_UI_Input.$ctor1 = function(parent, config) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, config, '');
	};
	$Cayita_UI_Input.$ctor2.prototype = $Cayita_UI_Input.$ctor3.prototype = $Cayita_UI_Input.$ctor1.prototype = $Cayita_UI_Input.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputBase
	var $Cayita_UI_InputBase = function() {
		$Cayita_UI_ElementBase.call(this);
	};
	$Cayita_UI_InputBase.prototype = {
		createInput: function(parent, config, type) {
			this.createElement('input', parent, config);
			if (!ss.isNullOrEmptyString(type)) {
				this.element$1().type = type;
			}
			this.placeHolder$1(config.placeholder);
			this.required$1(config.required);
			if (!ss.isNullOrEmptyString(config.relativeSize)) {
				this.relativeSize(config.relativeSize);
			}
			if (!ss.isNullOrEmptyString(config.gridSize)) {
				this.gridSize(config.gridSize);
			}
			if (!ss.isNullOrEmptyString(config.value)) {
				this.value$1(config.value);
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
	$Cayita_UI_InputBase.$ctor1 = function(parent, config, type) {
		$Cayita_UI_ElementBase.call(this);
		this.createInput(parent, config, type);
	};
	$Cayita_UI_InputBase.$ctor1.prototype = $Cayita_UI_InputBase.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputCheckbox
	var $Cayita_UI_InputCheckbox = function() {
		$Cayita_UI_InputBase.call(this);
	};
	$Cayita_UI_InputCheckbox.prototype = {
		init: function(parent, config) {
			this.createInput(parent, config, 'checkbox');
			this.element$2().checked = config.checked;
		},
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputCheckbox.$ctor2 = function(parent, element) {
		$Cayita_UI_InputBase.call(this);
		var $t1 = $Cayita_UI_CheckboxConfig.$ctor();
		$t1.value = 'true';
		this.init(parent, $t1);
		element(this.element$2());
	};
	$Cayita_UI_InputCheckbox.$ctor1 = function(parent) {
		$Cayita_UI_InputBase.call(this);
		var $t1 = $Cayita_UI_CheckboxConfig.$ctor();
		$t1.value = 'true';
		this.init(parent, $t1);
	};
	$Cayita_UI_InputCheckbox.$ctor2.prototype = $Cayita_UI_InputCheckbox.$ctor1.prototype = $Cayita_UI_InputCheckbox.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.InputConfig
	var $Cayita_UI_InputConfig = function() {
	};
	$Cayita_UI_InputConfig.createInstance = function() {
		return $Cayita_UI_InputConfig.$ctor();
	};
	$Cayita_UI_InputConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.placeholder = null;
		$this.required = false;
		$this.relativeSize = null;
		$this.gridSize = null;
		$this.value = null;
		return $this;
	};
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
		$Cayita_UI_InputBase.$ctor1.call(this, parent, $Cayita_UI_TextConfig.$ctor(), 'text');
		element(this.element$2());
	};
	$Cayita_UI_InputText.$ctor1 = function(parent) {
		$Cayita_UI_InputBase.$ctor1.call(this, parent, $Cayita_UI_TextConfig.$ctor(), 'text');
	};
	$Cayita_UI_InputText.$ctor2.prototype = $Cayita_UI_InputText.$ctor1.prototype = $Cayita_UI_InputText.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Label
	var $Cayita_UI_Label = function(parent, config) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
	};
	$Cayita_UI_Label.prototype = {
		$init: function(parent, config) {
			this.createElement('label', parent, config);
			if (!ss.isNullOrEmptyString(config.textLabel)) {
				this.textLabel$1(config.textLabel);
			}
			if (!ss.isNullOrEmptyString(config.forField)) {
				this.forField$1(config.forField);
			}
		},
		textLabel$1: function(textLabel) {
			this.element().innerText = textLabel;
		},
		textLabel: function() {
			return this.element().innerText;
		},
		forField$1: function(fieldName) {
			if (!ss.isNullOrEmptyString(fieldName)) {
				this.element().setAttribute('for', fieldName);
			}
			else {
				this.element().removeAttribute('for');
			}
		},
		forField: function() {
			var forF = this.element().getAttribute('for');
			return (ss.isNullOrUndefined(forF) ? '' : forF.toString());
		}
	};
	$Cayita_UI_Label.$ctor1 = function(parent, config, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
		element(this.element());
	};
	$Cayita_UI_Label.$ctor1.prototype = $Cayita_UI_Label.prototype;
	$Cayita_UI_Label.createControlLabel = function(parent, textLabel, forField, visible) {
		return $Cayita_UI_Label.create(parent, textLabel, forField, 'control-label', visible);
	};
	$Cayita_UI_Label.create = function(parent, textLabel, forField, cssClass, visible) {
		var $t1 = $Cayita_UI_LabelConfig.$ctor();
		$t1.visible = visible;
		$t1.textLabel = textLabel;
		$t1.forField = forField;
		$t1.cssClass = cssClass;
		var l = new $Cayita_UI_Label(parent, $t1);
		return l;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.LabelConfig
	var $Cayita_UI_LabelConfig = function() {
	};
	$Cayita_UI_LabelConfig.createInstance = function() {
		return $Cayita_UI_LabelConfig.$ctor();
	};
	$Cayita_UI_LabelConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.textLabel = null;
		$this.forField = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Legend
	var $Cayita_UI_Legend = function(parent, config) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
	};
	$Cayita_UI_Legend.prototype = {
		$init: function(parent, config) {
			this.createElement('legend', parent, config);
			if (!ss.isNullOrEmptyString(config.text)) {
				this.text$1(config.text);
			}
		},
		text$1: function(textLegend) {
			this.element().innerText = textLegend;
		},
		text: function() {
			return this.element().innerText;
		}
	};
	$Cayita_UI_Legend.$ctor1 = function(parent, config, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
		element(this.element());
	};
	$Cayita_UI_Legend.$ctor1.prototype = $Cayita_UI_Legend.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.LegendConfig
	var $Cayita_UI_LegendConfig = function() {
	};
	$Cayita_UI_LegendConfig.createInstance = function() {
		return $Cayita_UI_LegendConfig.$ctor();
	};
	$Cayita_UI_LegendConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.text = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ListConfig
	var $Cayita_UI_ListConfig = function() {
	};
	$Cayita_UI_ListConfig.createInstance = function() {
		return $Cayita_UI_ListConfig.$ctor();
	};
	$Cayita_UI_ListConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.ordered = false;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ListItem
	var $Cayita_UI_ListItem = function(parent, config) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
		if (!ss.isNullOrEmptyString(config.item)) {
			this.jSelect().text(config.item);
		}
	};
	$Cayita_UI_ListItem.prototype = {
		$init: function(parent, config) {
			this.createElement('li', parent, config);
		},
		item: function(item) {
			this.jSelect().text(item);
		}
	};
	$Cayita_UI_ListItem.$ctor1 = function(parent, config, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
		element(this.element());
	};
	$Cayita_UI_ListItem.$ctor1.prototype = $Cayita_UI_ListItem.prototype;
	$Cayita_UI_ListItem.createNavListItem = function(parent, href, item) {
		var il = new $Cayita_UI_ListItem(parent, $Cayita_UI_ListItemConfig.$ctor());
		new $Cayita_UI_Anchor.$ctor1(il.element(), function(a) {
			a.href = href;
			a.innerText = item;
		});
		return il;
	};
	$Cayita_UI_ListItem.createNavListItem$1 = function(parent, href, item, element) {
		var il = new $Cayita_UI_ListItem(parent, $Cayita_UI_ListItemConfig.$ctor());
		var anchor = new $Cayita_UI_Anchor.$ctor1(il.element(), function(a) {
			a.href = href;
			a.innerText = item;
		});
		element(il.element(), anchor.element$1());
		return il;
	};
	$Cayita_UI_ListItem.createNavHeader = function(parent, item) {
		var $t1 = $Cayita_UI_ListItemConfig.$ctor();
		$t1.cssClass = 'nav-header';
		$t1.item = item;
		return new $Cayita_UI_ListItem(parent, $t1);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ListItemConfig
	var $Cayita_UI_ListItemConfig = function() {
	};
	$Cayita_UI_ListItemConfig.createInstance = function() {
		return $Cayita_UI_ListItemConfig.$ctor();
	};
	$Cayita_UI_ListItemConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.item = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.Paragraph
	var $Cayita_UI_Paragraph = function(parent, config) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
	};
	$Cayita_UI_Paragraph.prototype = {
		$init: function(parent, config) {
			this.createElement('p', parent, config);
			if (!ss.isNullOrEmptyString(config.text)) {
				this.text$1(config.text);
			}
		},
		text$1: function(text) {
			this.jSelect().text(text);
		},
		text: function() {
			return this.jSelect().text();
		}
	};
	$Cayita_UI_Paragraph.$ctor1 = function(parent, config, element) {
		$Cayita_UI_ElementBase.call(this);
		this.$init(parent, config);
		element(this.element());
	};
	$Cayita_UI_Paragraph.$ctor1.prototype = $Cayita_UI_Paragraph.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.ParagraphConfig
	var $Cayita_UI_ParagraphConfig = function() {
	};
	$Cayita_UI_ParagraphConfig.createInstance = function() {
		return $Cayita_UI_ParagraphConfig.$ctor();
	};
	$Cayita_UI_ParagraphConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		$this.text = null;
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
		$Cayita_UI_ButtonBase.$ctor1.call(this, parent, $Cayita_UI_ButtonConfig.$ctor(), 'reset');
	};
	$Cayita_UI_ResetButton.$ctor1 = function(parent, element) {
		$Cayita_UI_ButtonBase.$ctor1.call(this, parent, $Cayita_UI_ButtonConfig.$ctor(), 'reset');
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
			return Object;
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
		getControGroup: function() {
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
				this.label.forField$1(this.element$1().id);
				field(this.label.element(), this.element$1());
			}));
		}));
	};
	$Cayita_UI_SelectField.$ctor2 = function(parent, field) {
		this.controlGroup = null;
		this.label = null;
		this.controls = null;
		$Cayita_UI_HtmlSelect.call(this);
		this.controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cgDiv) {
			this.label = $Cayita_UI_Label.createControlLabel(null, '', null, true);
			this.controls = new $Cayita_UI_Div.$ctor1(cgDiv, ss.mkdel(this, function(ctDiv) {
				this.init(ctDiv);
				this.label.forField$1(this.element$1().id);
				field(this.element$1());
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
				this.label = $Cayita_UI_Label.createControlLabel(null, '', null, true);
				this.controls = new $Cayita_UI_Div.$ctor1(cgDiv, ss.mkdel(this, function(ctDiv) {
					this.init(ctDiv);
					this.label.forField$1(this.element$1().id);
				}));
			}));
			element(this.element$1());
			this.$init(store, optionFunc, defaultOption);
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
						case 10: {
							this.selectOption();
							this.render();
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
				$Cayita_UI_Ext.load$1(T).call(null, this.$se, this.$store, this.$optionFunc, append);
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
					this.label.forField$1(this.element$1().id);
				}));
			}));
			element(this.label.element(), this.element$1());
			this.$init(store, optionFunc, defaultOption);
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
	// Cayita.Javascript.UI.Span
	var $Cayita_UI_Span = function(parent, config) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('span', parent, $Cayita_UI_SpanConfig.$ctor());
	};
	$Cayita_UI_Span.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('span', parent, $Cayita_UI_SpanConfig.$ctor());
		element(this.element());
	};
	$Cayita_UI_Span.$ctor1.prototype = $Cayita_UI_Span.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SpanConfig
	var $Cayita_UI_SpanConfig = function() {
	};
	$Cayita_UI_SpanConfig.createInstance = function() {
		return $Cayita_UI_SpanConfig.$ctor();
	};
	$Cayita_UI_SpanConfig.$ctor = function() {
		var $this = $Cayita_UI_ElementConfig.$ctor();
		return $this;
	};
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
		this.createElement('div', parent, $Cayita_UI_ElementConfig.$ctor());
		this.element$1().className = 'well well-large lead';
		this.$icon = (new $Cayita_UI_Icon.$ctor1(this.element$1(), function(i) {
			i.className = 'icon-spinner icon-spin icon-2x pull-left';
		})).element();
		config(this.element$1(), this.$icon);
		$(this.element$1()).append(message);
	};
	$Cayita_UI_SpinnerIcon.$ctor1.prototype = $Cayita_UI_SpinnerIcon.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.SubmitButton
	var $Cayita_UI_SubmitButton = function(parent) {
		$Cayita_UI_ButtonBase.$ctor1.call(this, parent, $Cayita_UI_ButtonConfig.$ctor(), 'submit');
	};
	$Cayita_UI_SubmitButton.$ctor1 = function(parent, element) {
		$Cayita_UI_ButtonBase.$ctor1.call(this, parent, $Cayita_UI_ButtonConfig.$ctor(), 'submit');
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
		this.createElement('tbody', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableCell
	var $Cayita_UI_TableCell = function() {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', null, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_TableCell.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TableCell.$ctor3 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', parent, $Cayita_UI_ElementConfig.$ctor());
		element(this.element$1());
	};
	$Cayita_UI_TableCell.$ctor2 = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_TableCell.$ctor1 = function(element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('td', null, $Cayita_UI_ElementConfig.$ctor());
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
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_TableColumn$1, [T], function() {
			return Object;
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
		this.createElement('tfoot', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_TableFooter.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_TableFooter.$ctor1 = function(parent, element) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('tfoot', parent, $Cayita_UI_ElementConfig.$ctor());
		element(this.element$2());
	};
	$Cayita_UI_TableFooter.$ctor1.prototype = $Cayita_UI_TableFooter.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableHeader
	var $Cayita_UI_TableHeader = function(parent) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('thead', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_TableHeader.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_TableHeader.$ctor1 = function(parent, element) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('thead', parent, $Cayita_UI_ElementConfig.$ctor());
		element(this.element$2());
	};
	$Cayita_UI_TableHeader.$ctor1.prototype = $Cayita_UI_TableHeader.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TableRow
	var $Cayita_UI_TableRow = function(parent) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('tr', parent, $Cayita_UI_ElementConfig.$ctor());
	};
	$Cayita_UI_TableRow.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TableRow.$ctor1 = function(parent, element) {
		$Cayita_UI_ElementBase.call(this);
		this.createElement('tr', parent, $Cayita_UI_ElementConfig.$ctor());
		element(this.element$1());
	};
	$Cayita_UI_TableRow.$ctor1.prototype = $Cayita_UI_TableRow.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TextConfig
	var $Cayita_UI_TextConfig = function() {
	};
	$Cayita_UI_TextConfig.createInstance = function() {
		return $Cayita_UI_TextConfig.$ctor();
	};
	$Cayita_UI_TextConfig.$ctor = function() {
		var $this = $Cayita_UI_InputConfig.$ctor();
		$this.minLength = null;
		$this.maxLength = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TextField
	var $Cayita_UI_TextField = function(parent, field) {
		$Cayita_UI_TextField.$ctor1.call(this, parent.element(), field);
	};
	$Cayita_UI_TextField.prototype = {
		getControGroup: function() {
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
			this.$controls = $Cayita_UI_Div.createControls$1(cge, ss.mkdel(this, function(cte) {
				this.createInput(cte, $Cayita_UI_TextConfig.$ctor(), 'text');
				this.$label.forField$1(this.element$2().id);
				field(this.$label.element(), this.element$2());
			}));
		}));
	};
	$Cayita_UI_TextField.$ctor2 = function(parent, field) {
		this.$controlGroup = null;
		this.$label = null;
		this.$controls = null;
		$Cayita_UI_InputText.call(this);
		this.$controlGroup = $Cayita_UI_Div.createControlGroup$1(parent, ss.mkdel(this, function(cge) {
			this.$label = $Cayita_UI_Label.createControlLabel(null, '', null, true);
			this.$controls = new $Cayita_UI_Div.$ctor1(cge, ss.mkdel(this, function(cte) {
				this.createInput(cte, $Cayita_UI_TextConfig.$ctor(), 'text');
				this.$label.forField$1(this.element$2().id);
				field(this.element$2());
			}));
		}));
	};
	$Cayita_UI_TextField.$ctor1.prototype = $Cayita_UI_TextField.$ctor2.prototype = $Cayita_UI_TextField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Javascript.UI.TopNavBar
	var $Cayita_UI_TopNavBar = function(parent, brandText, rightText, rightLinkText, navlist) {
		this.$containerFluid = null;
		this.$navCollapse = null;
		this.$brand = null;
		this.$pullRightParagraph = null;
		this.$pullRightAnchor = null;
		this.$navList = null;
		$Cayita_UI_Div.call(this, parent);
		this.element$1().className = 'navbar navbar-inverse navbar-fixed-top';
		new $Cayita_UI_Div.$ctor1(this.element$1(), ss.mkdel(this, function(inner) {
			inner.className = 'navbar-inner';
			this.$containerFluid = $Cayita_UI_Div.createContainerFluid$1(inner, ss.mkdel(this, function(fluid) {
				new $Cayita_UI_Anchor.$ctor1(fluid, function(anchor) {
					anchor.className = 'btn btn-navbar';
					anchor.setAttribute('data-toggle', 'collapse');
					anchor.setAttribute('data-target', '.nav-collapse');
					for (var i = 0; i < 3; i++) {
						var $t1 = $Cayita_UI_SpanConfig.$ctor();
						$t1.cssClass = 'icon-bar';
						new $Cayita_UI_Span(anchor, $t1);
					}
				});
				this.$brand = new $Cayita_UI_Anchor.$ctor1(fluid, function(brnd) {
					brnd.href = '#';
					brnd.innerText = brandText;
					brnd.className = 'brand';
				});
				this.$navCollapse = new $Cayita_UI_Div.$ctor1(fluid, ss.mkdel(this, function(collapse) {
					collapse.className = 'nav-collapse collapse';
					var $t2 = $Cayita_UI_ParagraphConfig.$ctor();
					$t2.text = rightText;
					$t2.cssClass = 'navbar-text pull-right';
					this.$pullRightParagraph = (new $Cayita_UI_Paragraph.$ctor1(collapse, $t2, ss.mkdel(this, function(paragraph) {
						this.$pullRightAnchor = new $Cayita_UI_Anchor.$ctor1(paragraph, function(a) {
							a.href = '#';
							a.className = 'navbar-link';
							a.innerText = rightLinkText;
						});
					}))).element();
					this.$navList = $Cayita_UI_HtmlList.creatNavList$1(collapse, navlist);
				}));
			}));
		}));
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
	ss.registerClass(global, 'Message', $Message);
	ss.registerClass(global, 'MessageFor', $MessageFor);
	ss.registerClass(global, 'Range', $Range);
	ss.registerClass(global, 'Rule', $Rule);
	ss.registerClass(global, 'RuleFor', $RuleFor);
	ss.registerClass(global, 'ValidateOptions', $ValidateOptions);
	ss.registerClass(global, 'Cayita.Ajax.AppError', $Cayita_Ajax_AppError);
	ss.registerClass(global, 'Cayita.Ajax.ResponseError', $Cayita_Ajax_ResponseError);
	ss.registerClass(global, 'Cayita.Ajax.ResponseStatus', $Cayita_Ajax_ResponseStatus);
	ss.registerClass(global, 'Cayita.Data.ReadOptions', $Cayita_Data_ReadOptions);
	ss.registerClass(global, 'Cayita.Data.StoreRequest', $Cayita_Data_StoreRequest);
	ss.registerClass(global, 'Cayita.Javascript.ModuleBase', $Cayita_Javascript_ModuleBase);
	ss.registerClass(global, 'Cayita.UI.ElementBase', $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Anchor', $Cayita_UI_Anchor, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.ButtonBase', $Cayita_UI_ButtonBase, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Button', $Cayita_UI_Button, $Cayita_UI_ButtonBase);
	ss.registerClass(global, 'Cayita.UI.ElementConfig', $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.ButtonConfig', $Cayita_UI_ButtonConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.InputConfig', $Cayita_UI_InputConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.CheckboxConfig', $Cayita_UI_CheckboxConfig, $Cayita_UI_InputConfig);
	ss.registerClass(global, 'Cayita.UI.InputBase', $Cayita_UI_InputBase, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.InputCheckbox', $Cayita_UI_InputCheckbox, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.CheckboxField', $Cayita_UI_CheckboxField, $Cayita_UI_InputCheckbox);
	ss.registerClass(global, 'Cayita.UI.Div', $Cayita_UI_Div, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.DivConfig', $Cayita_UI_DivConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.Ext', $Cayita_UI_Ext);
	ss.registerClass(global, 'Cayita.UI.Form', $Cayita_UI_Form, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.FormConfig', $Cayita_UI_FormConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.HtmlList', $Cayita_UI_HtmlList, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlOption', $Cayita_UI_HtmlOption, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlSelect', $Cayita_UI_HtmlSelect, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.HtmlTable', $Cayita_UI_HtmlTable, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.Icon', $Cayita_UI_Icon, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.IconAnchor', $Cayita_UI_IconAnchor, $Cayita_UI_Anchor);
	ss.registerClass(global, 'Cayita.UI.IconButton', $Cayita_UI_IconButton, $Cayita_UI_Button);
	ss.registerClass(global, 'Cayita.UI.Input', $Cayita_UI_Input, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.InputText', $Cayita_UI_InputText, $Cayita_UI_InputBase);
	ss.registerClass(global, 'Cayita.UI.InputPassword', $Cayita_UI_InputPassword, $Cayita_UI_InputText);
	ss.registerClass(global, 'Cayita.UI.Label', $Cayita_UI_Label, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.LabelConfig', $Cayita_UI_LabelConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.Legend', $Cayita_UI_Legend, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.LegendConfig', $Cayita_UI_LegendConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.ListConfig', $Cayita_UI_ListConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.ListItem', $Cayita_UI_ListItem, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.ListItemConfig', $Cayita_UI_ListItemConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.Paragraph', $Cayita_UI_Paragraph, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.ParagraphConfig', $Cayita_UI_ParagraphConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.RequestMessage', $Cayita_UI_RequestMessage);
	ss.registerClass(global, 'Cayita.UI.ResetButton', $Cayita_UI_ResetButton, $Cayita_UI_ButtonBase);
	ss.registerClass(global, 'Cayita.UI.SelectedRow', $Cayita_UI_SelectedRow);
	ss.registerClass(global, 'Cayita.UI.SelectField', $Cayita_UI_SelectField, $Cayita_UI_HtmlSelect);
	ss.registerClass(global, 'Cayita.UI.Span', $Cayita_UI_Span, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.SpanConfig', $Cayita_UI_SpanConfig, $Cayita_UI_ElementConfig);
	ss.registerClass(global, 'Cayita.UI.SpinnerIcon', $Cayita_UI_SpinnerIcon, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.SubmitButton', $Cayita_UI_SubmitButton, $Cayita_UI_ButtonBase);
	ss.registerClass(global, 'Cayita.UI.SystemExt', $Cayita_UI_SystemExt);
	ss.registerClass(global, 'Cayita.UI.TableBody', $Cayita_UI_TableBody, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TableCell', $Cayita_UI_TableCell, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TableFooter', $Cayita_UI_TableFooter, $Cayita_UI_HtmlTable);
	ss.registerClass(global, 'Cayita.UI.TableHeader', $Cayita_UI_TableHeader, $Cayita_UI_HtmlTable);
	ss.registerClass(global, 'Cayita.UI.TableRow', $Cayita_UI_TableRow, $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.TextConfig', $Cayita_UI_TextConfig, $Cayita_UI_InputConfig);
	ss.registerClass(global, 'Cayita.UI.TextField', $Cayita_UI_TextField, $Cayita_UI_InputText);
	ss.registerClass(global, 'Cayita.UI.TopNavBar', $Cayita_UI_TopNavBar, $Cayita_UI_Div);
	$Cayita_UI_ElementBase.$tags = new (ss.makeGenericType(ss.Dictionary$2, [String, ss.Int32]))();
})();
