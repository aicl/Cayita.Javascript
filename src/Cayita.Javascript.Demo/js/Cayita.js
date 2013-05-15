(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Extensions
	var $Extensions = function() {
	};
	$Extensions.load = function(T) {
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
	$Extensions.createOption = function(T) {
		return function(cb, data, func) {
			$(cb).append(func(data));
		};
	};
	$Extensions.updateOption = function(T) {
		return function(cb, data, func, recordIdProperty) {
			var old = $('option[value=' + $SystemExtensions.get(data, recordIdProperty) + ']', cb);
			cb.replaceChild(func(data), old[0]);
		};
	};
	$Extensions.removeOption = function(T) {
		return function(cb, data, recordIdProperty) {
			$('option[value=' + $SystemExtensions.get(data, recordIdProperty) + ']', cb).remove();
		};
	};
	$Extensions.loadTo = function(T) {
		return function(form) {
			var data = ss.createInstance(T);
			cayita.fn.loadTo(form, data);
			return data;
		};
	};
	$Extensions.find = function(T) {
		return function(form, selector) {
			return $(selector, form)[0];
		};
	};
	$Extensions.findByName = function(T) {
		return function(form, name) {
			return $('[name=' + name + ']', form)[0];
		};
	};
	$Extensions.findById = function(T) {
		return function(form, id) {
			return $('[id=' + id + ']', form)[0];
		};
	};
	$Extensions.createRow = function(T) {
		return function(table, data, columns, recordIdProperty) {
			var r = new $Cayita_UI_TableRow.$ctor1(null, function(row) {
				row.setAttribute('record-id', $SystemExtensions.get(data, recordIdProperty));
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
	$Extensions.updateRow = function(T) {
		return function(table, data, columns, recordIdProperty) {
			var row = $('tr[record-id=' + $SystemExtensions.get(data, recordIdProperty) + ']', table).empty();
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
	$Extensions.removeRow = function(T) {
		return function(table, data, recordIdProperty) {
			var d = data;
			$('tr[record-id=' + d[recordIdProperty] + ']', table).remove();
		};
	};
	$Extensions.createHeader = function(T) {
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
	$Extensions.createFooter = function(T) {
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
	$Extensions.load$1 = function(T) {
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
			var fbody = document.createDocumentFragment();
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = { $: $t1.current() };
					(new $Cayita_UI_TableRow.$ctor1(null, ss.mkdel({ d: d }, function(row) {
						row.setAttribute('record-id', $SystemExtensions.get(this.d.$, recordIdProperty));
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
					}))).appendTo$1(fbody);
				}
			}
			finally {
				$t1.dispose();
			}
			body.appendChild(fbody);
		};
	};
	$Extensions.addItem$2 = function(parent, item) {
		var il = new $Cayita_UI_ListItem(parent);
		new $Cayita_UI_Anchor.$ctor3(il.element$1(), function(a) {
			a.href = '#';
			$Extensions.text$1(a, item);
		});
	};
	$Extensions.addItem$4 = function(parent, item, action) {
		var il = new $Cayita_UI_ListItem(parent);
		new $Cayita_UI_Anchor.$ctor3(il.element$1(), function(a) {
			a.href = '#';
			$Extensions.text$1(a, item);
			$(a).on('click', function(evt) {
				action(evt);
			});
		});
	};
	$Extensions.addItem$1 = function(parent, element) {
		var il = new $Cayita_UI_ListItem(parent);
		var anchor = new $Cayita_UI_Anchor.$ctor3(il.element$1(), function(a) {
			a.href = '#';
		});
		element(il.element$1(), anchor.element$1());
	};
	$Extensions.addHeader = function(parent, item) {
		new $Cayita_UI_ListItem.$ctor1(parent, function(l) {
			l.className = 'nav-header';
			$Extensions.text$1(l, item);
		});
	};
	$Extensions.addHDivider = function(parent) {
		new $Cayita_UI_ListItem.$ctor1(parent, function(l) {
			l.className = 'divider';
		});
	};
	$Extensions.addItem$3 = function(parent, item, menu) {
		var il = new $Cayita_UI_ListItem(parent);
		il.className$1('dropdown');
		new $Cayita_UI_Anchor.$ctor3(il.element$1(), function(a) {
			a.href = '#';
			a.tabIndex = -1;
			a.className = 'dropdown-toggle';
			a.setAttribute('role', 'button');
			a.setAttribute('data-toggle', 'dropdown');
			$Extensions.text$1(a, item);
			$(a).append(ss.formatString('<b class="caret{0}"></b>', (!$(parent).hasClass('nav-list') ? '' : ' pull-right')));
		});
		il.append$1(menu);
	};
	$Extensions.addItem = function(parent, submenu) {
		$(parent).append(submenu.element());
	};
	$Extensions.send = function(fd, url) {
		return $.ajax({ url: url, type: 'POST', data: fd, processData: false, contentType: '' });
	};
	$Extensions.text$1 = function(element, value) {
		var ctxt = $('ctxt', element);
		if (ctxt.length === 0) {
			var txt = document.createElement('ctxt');
			$(element).append(txt);
			ctxt = $(txt);
		}
		return ctxt.html(ss.coalesce(value, ''));
	};
	$Extensions.text = function(element) {
		return $('ctxt', element).text();
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.StringExtensions
	var $StringExtensions = function() {
	};
	$StringExtensions.header$1 = function(text, size, parent) {
		var h = document.createElement('h' + size.toString());
		h.innerHTML = text;
		parent.appendChild(h);
		return h;
	};
	$StringExtensions.header$2 = function(text, size, parent) {
		var h = document.createElement('h' + size.toString());
		h.innerHTML = text;
		parent.append(h);
		return h;
	};
	$StringExtensions.header = function(text, size) {
		var h = document.createElement('h' + size.toString());
		h.innerHTML = text;
		return h;
	};
	$StringExtensions.paragraph$1 = function(text, parent) {
		var h = document.createElement('p');
		h.innerHTML = text;
		parent.appendChild(h);
		return h;
	};
	$StringExtensions.paragraph$2 = function(text, parent) {
		var h = document.createElement('p');
		h.innerHTML = text;
		parent.append(h);
		return h;
	};
	$StringExtensions.paragraph = function(text) {
		var h = document.createElement('p');
		h.innerHTML = text;
		return h;
	};
	////////////////////////////////////////////////////////////////////////////////
	// System.SystemExtensions
	var $SystemExtensions = function() {
	};
	$SystemExtensions.toJsDate = function(date) {
		if (ss.staticEquals(date, null)) {
			return null;
		}
		var tick = parseInt(date.toString());
		var d = new Date(tick);
		return new Date(d.getUTCFullYear(), d.getUTCMonth() + 1, d.getUTCDate(), d.getUTCHours(), d.getUTCMinutes(), d.getUTCSeconds());
	};
	$SystemExtensions.get = function(obj, property) {
		return obj[property];
	};
	$SystemExtensions.get$1 = function(T) {
		return function(obj, property) {
			return ss.cast(obj[property], T);
		};
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.ImgUpload
	var $Cayita_ImgUpload = function(parent) {
		this.$cfg = null;
		this.$img = null;
		this.$divNew = null;
		this.$divExists = null;
		ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_ImgUpload]).call(this, parent);
		this.$init(new $Cayita_ImgUploadConfig());
	};
	$Cayita_ImgUpload.prototype = {
		$init: function(config) {
			this.$cfg = config;
			var e = this.element();
			(new $Cayita_UI_Div(ss.mkdel(this, function(d) {
				d.className = 'fileupload-new thumbnail';
				d.style.width = this.$cfg.get_imgWidth();
				d.style.height = this.$cfg.get_imgHeight();
				this.$img = (new $Cayita_UI_Image.$ctor2(d, ss.mkdel(this, function(i) {
					i.src = this.$cfg.get_imgSrc();
				}))).element$1();
				this.$divNew = d;
			}))).appendTo$2(e);
			(new $Cayita_UI_Div(ss.mkdel(this, function(d1) {
				d1.className = 'fileupload-preview fileupload-exists thumbnail';
				d1.style.width = this.$cfg.get_imgWidth();
				d1.style.height = this.$cfg.get_imgHeight();
				d1.style.lineHeight = '20px';
				this.$divExists = d1;
			}))).appendTo$2(e);
			(new $Cayita_UI_Div(ss.mkdel(this, function(d2) {
				new $Cayita_UI_Span.$ctor2(d2, ss.mkdel(this, function(sp) {
					sp.className = 'btn btn-file';
					new $Cayita_UI_Span.$ctor2(sp, ss.mkdel(this, function(sl) {
						sl.className = 'fileupload-new';
						new $Cayita_UI_Icon.$ctor3(sl, ss.mkdel(this, function(i1) {
							i1.className = this.$cfg.get_selectIconClass();
						}));
						var t = document.createElement('ctxt');
						$(sl).append(t);
						t.innerHTML = ss.coalesce(this.$cfg.get_selectText(), '');
					}));
					new $Cayita_UI_Span.$ctor2(sp, ss.mkdel(this, function(sl1) {
						sl1.className = 'fileupload-exists';
						new $Cayita_UI_Icon.$ctor3(sl1, ss.mkdel(this, function(i2) {
							i2.className = this.$cfg.get_selectIconClass();
						}));
						var t1 = document.createElement('ctxt');
						$(sl1).append(t1);
						t1.innerHTML = ss.coalesce(this.$cfg.get_selectText(), '');
					}));
					this.createInput(sp, this.$cfg);
				}));
				new $Cayita_UI_Anchor.$ctor3(d2, ss.mkdel(this, function(a) {
					a.className = 'btn fileupload-exists';
					a.setAttribute('data-dismiss', 'fileupload');
					new $Cayita_UI_Icon.$ctor3(a, ss.mkdel(this, function(i3) {
						i3.className = this.$cfg.get_removeIconClass();
					}));
					var t2 = document.createElement('ctxt');
					$(a).append(t2);
					t2.innerHTML = ss.coalesce(this.$cfg.get_removeText(), '');
				}));
			}))).appendTo$2(e);
		},
		imgSrc: function(src) {
			this.$cfg.set_imgSrc(src);
			this.$img.src = src;
			return this;
		},
		imgWidth: function(width) {
			this.$cfg.set_imgWidth(width);
			this.$divNew.style.width = width;
			this.$divExists.style.width = width;
			return this;
		},
		imgHeight: function(height) {
			this.$cfg.set_imgHeight(height);
			this.$divNew.style.height = height;
			this.$divExists.style.height = height;
			return this;
		}
	};
	$Cayita_ImgUpload.$ctor2 = function(parent, config) {
		this.$cfg = null;
		this.$img = null;
		this.$divNew = null;
		this.$divExists = null;
		ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_ImgUpload]).call(this, parent);
		var c = new $Cayita_ImgUploadConfig();
		config(c);
		this.$init(c);
	};
	$Cayita_ImgUpload.$ctor1 = function(parent, config) {
		this.$cfg = null;
		this.$img = null;
		this.$divNew = null;
		this.$divExists = null;
		ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_ImgUpload]).call(this, parent);
		this.$init(config);
	};
	$Cayita_ImgUpload.$ctor2.prototype = $Cayita_ImgUpload.$ctor1.prototype = $Cayita_ImgUpload.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.ImgUploadConfig
	var $Cayita_ImgUploadConfig = function() {
		this.$2$ImgSrcField = null;
		this.$2$ImgWidthField = null;
		this.$2$ImgHeightField = null;
		$Cayita_UI_FileUploadConfig.call(this);
		this.set_accept('image/*');
		this.set_imgSrc('http://www.placehold.it/200x150/EFEFEF/AAAAAA&text=no+image');
		this.set_imgWidth('200px');
		this.set_imgHeight('150px');
	};
	$Cayita_ImgUploadConfig.prototype = {
		get_imgSrc: function() {
			return this.$2$ImgSrcField;
		},
		set_imgSrc: function(value) {
			this.$2$ImgSrcField = value;
		},
		get_imgWidth: function() {
			return this.$2$ImgWidthField;
		},
		set_imgWidth: function(value) {
			this.$2$ImgWidthField = value;
		},
		get_imgHeight: function() {
			return this.$2$ImgHeightField;
		},
		set_imgHeight: function(value) {
			this.$2$ImgHeightField = value;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.PasswordField
	var $Cayita_PasswordField = function() {
		$Cayita_PasswordField.$ctor2.call(this, null);
	};
	$Cayita_PasswordField.$ctor1 = function(parent) {
		$Cayita_PasswordField.$ctor2.call(this, parent.element());
	};
	$Cayita_PasswordField.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_PasswordField]).$ctor2.call(this, parent);
		this.type('password');
	};
	$Cayita_PasswordField.$ctor1.prototype = $Cayita_PasswordField.$ctor2.prototype = $Cayita_PasswordField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.AjaxResponse
	var $Cayita_Data_AjaxResponse = function() {
	};
	$Cayita_Data_AjaxResponse.createInstance = function() {
		return $Cayita_Data_AjaxResponse.$ctor();
	};
	$Cayita_Data_AjaxResponse.$ctor = function() {
		var $this = {};
		$this.ResponseStatus = null;
		$this.Status = 0;
		$this.StatusText = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.AppError
	var $Cayita_Data_AppError = function() {
	};
	$Cayita_Data_AppError.createInstance = function() {
		return $Cayita_Data_AppError.$ctor();
	};
	$Cayita_Data_AppError.$ctor = function() {
		var $this = {};
		$this.ErrorCode = null;
		$this.FieldName = null;
		$this.Message = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.ReadOptions
	var $Cayita_Data_ReadOptions = function() {
	};
	$Cayita_Data_ReadOptions.createInstance = function() {
		return $Cayita_Data_ReadOptions.$ctor();
	};
	$Cayita_Data_ReadOptions.getRequestObject = function($this) {
		var ro = {};
		if (!ss.isNullOrEmptyString($this.orderBy)) {
			ro[$this.orderByParam] = $this.orderBy;
		}
		if (!ss.isNullOrEmptyString($this.orderType)) {
			ro[$this.orderTypeParam] = $this.orderType;
		}
		if (!$this.localPaging) {
			if (ss.isValue($this.pageNumber)) {
				ro[$this.pageNumberParam] = $this.pageNumber;
			}
			if (ss.isValue($this.pageSize)) {
				ro[$this.pageSizeParam] = $this.pageSize;
			}
		}
		var $t1 = new ss.ObjectEnumerator($this.queryParams);
		try {
			while ($t1.moveNext()) {
				var kv = $t1.current();
				ro[kv.key] = kv.value;
			}
		}
		finally {
			$t1.dispose();
		}
		cayita.fn.populateFrom(ro, $this.dynamicQueryParams);
		cayita.fn.populateFrom(ro, $this.query_);
		return ro;
	};
	$Cayita_Data_ReadOptions.query = function(T) {
		return function($this, query) {
			cayita.fn.populateFrom($this.query_, query);
		};
	};
	$Cayita_Data_ReadOptions.$ctor = function() {
		var $this = {};
		$this.query_ = {};
		$this.pageNumber = null;
		$this.pageSize = null;
		$this.queryParams = null;
		$this.orderBy = null;
		$this.orderType = null;
		$this.pageSizeParam = null;
		$this.pageNumberParam = null;
		$this.localPaging = false;
		$this.orderByParam = null;
		$this.orderTypeParam = null;
		$this.dynamicQueryParams = null;
		$this.queryParams = {};
		$this.pageSizeParam = 'limit';
		$this.pageNumberParam = 'page';
		$this.dynamicQueryParams = {};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.ResponseStatus
	var $Cayita_Data_ResponseStatus = function() {
	};
	$Cayita_Data_ResponseStatus.createInstance = function() {
		return $Cayita_Data_ResponseStatus.$ctor();
	};
	$Cayita_Data_ResponseStatus.$ctor = function() {
		var $this = {};
		$this.ErrorCode = null;
		$this.Message = null;
		$this.Errors = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.Store
	var $Cayita_Data_Store$1 = function(T) {
		var $type = function() {
			this.$st = [];
			this.$createFunc = null;
			this.$readFunc = null;
			this.$updateFunc = null;
			this.$destroyFunc = null;
			this.$patchFunc = null;
			this.$filterFunc = function(d) {
				return true;
			};
			var $t1 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t1.url = 'api/' + ss.getTypeName(T) + '/create';
			this.$createApi = $t1;
			var $t1 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t1.url = 'api/' + ss.getTypeName(T) + '/read';
			this.$readApi = $t1;
			var $t1 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t1.url = 'api/' + ss.getTypeName(T) + '/update';
			this.$updateApi = $t1;
			var $t1 = ss.makeGenericType($Cayita_Data_StoreApi$1, [String]).$ctor();
			$t1.url = 'api/' + ss.getTypeName(T) + '/destroy';
			this.$destroyApi = $t1;
			var $t1 = ss.makeGenericType($Cayita_Data_StoreApi$1, [T]).$ctor();
			$t1.url = 'api/' + ss.getTypeName(T) + '/patch';
			this.$patchApi = $t1;
			this.$lastOption = $Cayita_Data_ReadOptions.$ctor();
			this.$defaultPageSize = 10;
			this.$totalCount = 0;
			this.$idProperty = 'Id';
			this.$1$StoreChangedField = function(st, d) {
			};
			this.$1$StoreErrorField = function(st, d) {
			};
			this.$1$StoreRequestedField = function(st, d) {
			};
			this.$createFunc = ss.mkdel(this, function(record) {
				var $t2 = this.$1$StoreRequestedField;
				var $t1 = $Cayita_Data_StoreRequestedData.$ctor();
				$t1.action = 0;
				$t1.state = 0;
				$t2(this, $t1);
				var req = $.post(this.$createApi.url, record, function(cb) {
				}, this.$createApi.dataType);
				req.done(ss.mkdel(this, function(scb) {
					var r = this.$createApi.dataProperty;
					var data = scb;
					var res = ss.coalesce(data[r], data);
					if (Array.isArray(res)) {
						var $t3 = ss.getEnumerator(ss.cast(res, ss.IList));
						try {
							while ($t3.moveNext()) {
								var item = $t3.current();
								ss.add(this.$st, item);
								this.onStoreChanged$1(item, item, 0, 0);
							}
						}
						finally {
							$t3.dispose();
						}
					}
					else {
						ss.add(this.$st, ss.cast(res, T));
						this.onStoreChanged$1(ss.cast(res, T), ss.cast(res, T), 0, 0);
					}
				}));
				req.fail(ss.mkdel(this, function(f) {
					var $t5 = this.$1$StoreErrorField;
					var $t4 = ss.makeGenericType($Cayita_Data_StoreErrorData$1, [T]).$ctor();
					$t4.action = 0;
					$t4.request = req;
					$t5(this, $t4);
				}));
				req.always(ss.mkdel(this, function(t) {
					var $t7 = this.$1$StoreRequestedField;
					var $t6 = $Cayita_Data_StoreRequestedData.$ctor();
					$t6.action = 0;
					$t6.state = 1;
					$t7(this, $t6);
				}));
				return req;
			});
			this.$readFunc = ss.mkdel(this, function(readOptions) {
				var $t9 = this.$1$StoreRequestedField;
				var $t8 = $Cayita_Data_StoreRequestedData.$ctor();
				$t8.action = 1;
				$t8.state = 0;
				$t9(this, $t8);
				var req1 = $.get(this.$readApi.url, $Cayita_Data_ReadOptions.getRequestObject(readOptions), function(cb1) {
				}, this.$readApi.dataType);
				req1.done(ss.mkdel(this, function(scb1) {
					var r1 = this.$readApi.dataProperty;
					var data1 = scb1;
					var res1 = ss.coalesce(data1[r1], data1);
					if (Array.isArray(res1)) {
						var $t10 = ss.getEnumerator(ss.cast(res1, ss.IList));
						try {
							while ($t10.moveNext()) {
								var item1 = $t10.current();
								var $t11 = new ss.ObjectEnumerator(this.$readApi.converters);
								try {
									while ($t11.moveNext()) {
										var kv = $t11.current();
										item1[kv.key] = kv.value(item1);
									}
								}
								finally {
									$t11.dispose();
								}
								ss.add(this.$st, item1);
							}
						}
						finally {
							$t10.dispose();
						}
					}
					else {
						ss.add(this.$st, ss.cast(res1, T));
					}
					var tc = ss.cast(data1[this.$readApi.totalCountProperty], ss.Int32);
					this.$totalCount = (ss.isValue(tc) ? ss.Nullable.unbox(tc) : Enumerable.from(this.$st).count(this.$filterFunc));
					this.onStoreChanged(1);
				}));
				req1.fail(ss.mkdel(this, function(f1) {
					var $t13 = this.$1$StoreErrorField;
					var $t12 = ss.makeGenericType($Cayita_Data_StoreErrorData$1, [T]).$ctor();
					$t12.action = 1;
					$t12.request = req1;
					$t13(this, $t12);
				}));
				req1.always(ss.mkdel(this, function(f2) {
					var $t15 = this.$1$StoreRequestedField;
					var $t14 = $Cayita_Data_StoreRequestedData.$ctor();
					$t14.action = 1;
					$t14.state = 1;
					$t15(this, $t14);
				}));
				return req1;
			});
			this.$updateFunc = ss.mkdel(this, function(record1) {
				var $t17 = this.$1$StoreRequestedField;
				var $t16 = $Cayita_Data_StoreRequestedData.$ctor();
				$t16.action = 2;
				$t16.state = 0;
				$t17(this, $t16);
				var req2 = $.post(this.$updateApi.url, record1, function(cb2) {
				}, this.$updateApi.dataType);
				req2.done(ss.mkdel(this, function(scb2) {
					var r2 = this.$updateApi.dataProperty;
					var data2 = scb2;
					var res2 = ss.coalesce(data2[r2], data2);
					if (Array.isArray(res2)) {
						var $t18 = ss.getEnumerator(ss.cast(res2, ss.IList));
						try {
							while ($t18.moveNext()) {
								var item2 = { $: $t18.current() };
								var ur = Enumerable.from(this.$st).first(ss.mkdel({ item2: item2, $this: this }, function(f3) {
									return ss.referenceEquals($SystemExtensions.get(f3, this.$this.$idProperty), $SystemExtensions.get(this.item2.$, this.$this.$idProperty));
								}));
								var old = ss.createInstance(T);
								cayita.fn.populateFrom(old, ur);
								cayita.fn.populateFrom(ur, item2.$);
								this.onStoreChanged$1(ur, old, 2, 0);
							}
						}
						finally {
							$t18.dispose();
						}
					}
					else {
						var ur1 = Enumerable.from(this.$st).first(ss.mkdel(this, function(f4) {
							return !!ss.referenceEquals($SystemExtensions.get(f4, this.$idProperty), res2.Get(this.$idProperty));
						}));
						var old1 = ss.createInstance(T);
						cayita.fn.populateFrom(old1, ur1);
						cayita.fn.populateFrom(ur1, ss.cast(res2, T));
						this.onStoreChanged$1(ur1, old1, 2, 0);
					}
				}));
				req2.fail(ss.mkdel(this, function(f5) {
					var $t20 = this.$1$StoreErrorField;
					var $t19 = ss.makeGenericType($Cayita_Data_StoreErrorData$1, [T]).$ctor();
					$t19.action = 2;
					$t19.request = req2;
					$t20(this, $t19);
				}));
				req2.always(ss.mkdel(this, function(f6) {
					var $t22 = this.$1$StoreRequestedField;
					var $t21 = $Cayita_Data_StoreRequestedData.$ctor();
					$t21.action = 2;
					$t21.state = 1;
					$t22(this, $t21);
				}));
				return req2;
			});
			this.$destroyFunc = ss.mkdel(this, function(record2) {
				var $t24 = this.$1$StoreRequestedField;
				var $t23 = $Cayita_Data_StoreRequestedData.$ctor();
				$t23.action = 3;
				$t23.state = 0;
				$t24(this, $t23);
				var data3 = {};
				data3[this.$idProperty] = $SystemExtensions.get(record2, this.$idProperty);
				var req3 = $.post(this.$destroyApi.url, data3, function(cb3) {
				}, this.$destroyApi.dataType);
				req3.done(ss.mkdel(this, function(scb3) {
					var dr = Enumerable.from(this.$st).first(ss.mkdel(this, function(f7) {
						return ss.referenceEquals($SystemExtensions.get(f7, this.$idProperty), $SystemExtensions.get(record2, this.$idProperty));
					}));
					ss.remove(this.$st, dr);
					this.onStoreChanged$1(dr, dr, 3, 0);
				}));
				req3.fail(ss.mkdel(this, function(f8) {
					var $t26 = this.$1$StoreErrorField;
					var $t25 = ss.makeGenericType($Cayita_Data_StoreErrorData$1, [T]).$ctor();
					$t25.action = 3;
					$t26(this, $t25);
				}));
				req3.always(ss.mkdel(this, function(f9) {
					var $t28 = this.$1$StoreRequestedField;
					var $t27 = $Cayita_Data_StoreRequestedData.$ctor();
					$t27.action = 3;
					$t27.state = 1;
					$t28(this, $t27);
				}));
				return req3;
			});
			this.$patchFunc = ss.mkdel(this, function(record3) {
				var $t30 = this.$1$StoreRequestedField;
				var $t29 = $Cayita_Data_StoreRequestedData.$ctor();
				$t29.action = 4;
				$t29.state = 0;
				$t30(this, $t29);
				var req4 = $.post(this.$patchApi.url, record3, function(cb4) {
				}, this.$patchApi.dataType);
				req4.done(ss.mkdel(this, function(scb4) {
					var r3 = this.$updateApi.dataProperty;
					var data4 = scb4;
					var res3 = ss.coalesce(data4[r3], data4);
					if (!!res3.IsArray()) {
						var $t31 = ss.getEnumerator(ss.cast(res3, ss.IList));
						try {
							while ($t31.moveNext()) {
								var item3 = { $: $t31.current() };
								var ur2 = Enumerable.from(this.$st).first(ss.mkdel({ item3: item3, $this: this }, function(f10) {
									return ss.referenceEquals($SystemExtensions.get(f10, this.$this.$idProperty), $SystemExtensions.get(this.item3.$, this.$this.$idProperty));
								}));
								var old2 = ss.createInstance(T);
								cayita.fn.populateFrom(old2, ur2);
								cayita.fn.populateFrom(ur2, item3.$);
								this.onStoreChanged$1(ur2, old2, 4, 0);
							}
						}
						finally {
							$t31.dispose();
						}
					}
					else {
						var ur3 = Enumerable.from(this.$st).first(ss.mkdel(this, function(f11) {
							return !!ss.referenceEquals($SystemExtensions.get(f11, this.$idProperty), res3.Get(this.$idProperty));
						}));
						var old3 = ss.createInstance(T);
						cayita.fn.populateFrom(old3, ur3);
						cayita.fn.populateFrom(ur3, ss.cast(res3, T));
						this.onStoreChanged$1(ur3, old3, 4, 0);
					}
				}));
				req4.fail(ss.mkdel(this, function(f12) {
					var $t33 = this.$1$StoreErrorField;
					var $t32 = ss.makeGenericType($Cayita_Data_StoreErrorData$1, [T]).$ctor();
					$t32.action = 4;
					$t32.request = req4;
					$t33(this, $t32);
				}));
				req4.always(ss.mkdel(this, function(f13) {
					var $t35 = this.$1$StoreRequestedField;
					var $t34 = $Cayita_Data_StoreRequestedData.$ctor();
					$t34.action = 4;
					$t34.state = 1;
					$t35(this, $t34);
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
			read: function(options, clear) {
				if (clear) {
					ss.clear(this.$st);
				}
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
			indexOf: function(item) {
				return ss.indexOf(this.$st, item);
			},
			insert: function(index, item) {
				ss.insert(this.$st, index, item);
				this.onStoreChanged$1(item, item, 6, index);
			},
			removeAt: function(index) {
				var item = this.get_item(index);
				ss.removeAt(this.$st, index);
				this.onStoreChanged$1(item, item, 8, index);
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
					return ss.referenceEquals($SystemExtensions.get(f, self.$idProperty).toString(), recordId.toString());
				});
				var index = ss.indexOf(this.$st, source);
				var old = cayita.fn.clone(source);
				record(source);
				this.onStoreChanged$1(source, old, 7, index);
			},
			replace: function(record) {
				var self = this;
				var source = Enumerable.from(this.$st).first(function(f) {
					return ss.referenceEquals($SystemExtensions.get(f, self.$idProperty).toString(), $SystemExtensions.get(record, self.$idProperty).toString());
				});
				var index = ss.indexOf(this.$st, source);
				var old = cayita.fn.clone(source);
				cayita.fn.populateFrom(source, record);
				this.onStoreChanged$1(source, old, 7, index);
			},
			get_count: function() {
				return ((ss.isValue(this.$lastOption) && this.$lastOption.localPaging && ss.isValue(this.$lastOption.pageSize) && ss.Nullable.unbox(this.$lastOption.pageSize) < Enumerable.from(this.$st).count(this.$filterFunc)) ? ss.Nullable.unbox(this.$lastOption.pageSize) : Enumerable.from(this.$st).count(this.$filterFunc));
			},
			add: function(item) {
				ss.add(this.$st, item);
				this.onStoreChanged$1(item, item, 5, this.getTotalCount() - 1);
			},
			clear: function() {
				ss.clear(this.$st);
				this.onStoreChanged(9);
			},
			contains: function(item) {
				return ss.contains(this.$st, item);
			},
			remove: function(item) {
				var index = ss.indexOf(this.$st, item);
				var r = ss.remove(this.$st, item);
				if (r) {
					this.onStoreChanged$1(item, item, 8, index);
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
				this.$totalCount = Enumerable.from(this.$st).count(this.$filterFunc);
				this.onStoreChanged(10);
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
					this.onStoreChanged(1);
				}
			},
			readNextPage: function(checkForNext) {
				if (checkForNext && !this.hasNextPage()) {
					return;
				}
				this.$lastOption.pageNumber = ss.Nullable.add(this.$lastOption.pageNumber, 1);
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					this.onStoreChanged(1);
				}
			},
			readPreviousPage: function(checkForPrevious) {
				if (checkForPrevious && !this.hasPreviousPage()) {
					return;
				}
				this.$lastOption.pageNumber = ss.Nullable.sub(this.$lastOption.pageNumber, 1);
				if (!this.$lastOption.localPaging) {
					this.$readFunc(this.$lastOption);
				}
				else {
					this.onStoreChanged(1);
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
					this.onStoreChanged(1);
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
					this.onStoreChanged(1);
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
				var $t2 = this.$1$StoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.action = 11;
				$t2(this, $t1);
			},
			add_storeChanged: function(value) {
				this.$1$StoreChangedField = ss.delegateCombine(this.$1$StoreChangedField, value);
			},
			remove_storeChanged: function(value) {
				this.$1$StoreChangedField = ss.delegateRemove(this.$1$StoreChangedField, value);
			},
			add_storeError: function(value) {
				this.$1$StoreErrorField = ss.delegateCombine(this.$1$StoreErrorField, value);
			},
			remove_storeError: function(value) {
				this.$1$StoreErrorField = ss.delegateRemove(this.$1$StoreErrorField, value);
			},
			add_storeRequested: function(value) {
				this.$1$StoreRequestedField = ss.delegateCombine(this.$1$StoreRequestedField, value);
			},
			remove_storeRequested: function(value) {
				this.$1$StoreRequestedField = ss.delegateRemove(this.$1$StoreRequestedField, value);
			},
			onStoreChanged$1: function(newData, oldData, action, index) {
				var $t2 = this.$1$StoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.newData = newData;
				$t1.oldData = oldData;
				$t1.action = action;
				$t1.index = index;
				$t2(this, $t1);
			},
			onStoreChanged: function(action) {
				var $t2 = this.$1$StoreChangedField;
				var $t1 = ss.makeGenericType($Cayita_Data_StoreChangedData$1, [T]).$ctor();
				$t1.action = action;
				$t2(this, $t1);
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
	// Cayita.Data.StoreApi
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
	// Cayita.Data.StoreChangedAction
	var $Cayita_Data_StoreChangedAction = function() {
	};
	$Cayita_Data_StoreChangedAction.prototype = { created: 0, read: 1, updated: 2, destroyed: 3, patched: 4, added: 5, inserted: 6, replaced: 7, removed: 8, cleared: 9, loaded: 10, filtered: 11 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.StoreChangedData
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
	// Cayita.Data.StoreErrorAction
	var $Cayita_Data_StoreErrorAction = function() {
	};
	$Cayita_Data_StoreErrorAction.prototype = { create: 0, read: 1, update: 2, destroy: 3, patch: 4 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.StoreErrorData
	var $Cayita_Data_StoreErrorData$1 = function(T) {
		var $type = function() {
		};
		$type.$ctor = function() {
			var $this = {};
			$this.action = 0;
			$this.request = null;
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_Data_StoreErrorData$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.Data.StoreErrorData$1', $Cayita_Data_StoreErrorData$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.StoreRequestedAction
	var $Cayita_Data_StoreRequestedAction = function() {
	};
	$Cayita_Data_StoreRequestedAction.prototype = { create: 0, read: 1, update: 2, destroy: 3, patch: 4 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.StoreRequestedData
	var $Cayita_Data_StoreRequestedData = function() {
	};
	$Cayita_Data_StoreRequestedData.$ctor = function() {
		var $this = {};
		$this.action = 0;
		$this.state = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Data.StoreRequestedState
	var $Cayita_Data_StoreRequestedState = function() {
	};
	$Cayita_Data_StoreRequestedState.prototype = { started: 0, finished: 1 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins.Message
	var $Cayita_Plugins_Message = function() {
	};
	$Cayita_Plugins_Message.createInstance = function() {
		return $Cayita_Plugins_Message.$ctor();
	};
	$Cayita_Plugins_Message.remote = function($this, message) {
		$this.msg.remote = message;
		return $this;
	};
	$Cayita_Plugins_Message.required = function($this, message) {
		$this.msg.required = message;
		return $this;
	};
	$Cayita_Plugins_Message.email = function($this, message) {
		$this.msg.email = message;
		return $this;
	};
	$Cayita_Plugins_Message.url = function($this, message) {
		$this.msg.url = message;
		return $this;
	};
	$Cayita_Plugins_Message.date = function($this, message) {
		$this.msg.date = message;
		return $this;
	};
	$Cayita_Plugins_Message.dateISO = function($this, message) {
		$this.msg.dateISO = message;
		return $this;
	};
	$Cayita_Plugins_Message.number = function($this, message) {
		$this.msg.number = message;
		return $this;
	};
	$Cayita_Plugins_Message.digits = function($this, message) {
		$this.msg.digits = message;
		return $this;
	};
	$Cayita_Plugins_Message.creditcard = function($this, message) {
		$this.msg.creditcard = message;
		return $this;
	};
	$Cayita_Plugins_Message.equalTo = function($this, message) {
		$this.msg.equalTo = message;
		return $this;
	};
	$Cayita_Plugins_Message.maxlength = function($this, message) {
		$this.msg.maxlength = message;
		return $this;
	};
	$Cayita_Plugins_Message.minlength = function($this, message) {
		$this.msg.minlength = message;
		return $this;
	};
	$Cayita_Plugins_Message.max = function($this, message) {
		$this.msg.max = message;
		return $this;
	};
	$Cayita_Plugins_Message.min = function($this, message) {
		$this.msg.min = message;
		return $this;
	};
	$Cayita_Plugins_Message.range = function($this, message) {
		$this.msg.range = message;
		return $this;
	};
	$Cayita_Plugins_Message.rangelength = function($this, message) {
		$this.msg.rangelength = message;
		return $this;
	};
	$Cayita_Plugins_Message.$ctor = function() {
		var $this = {};
		$this.msg = {};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins.MessageFor
	var $Cayita_Plugins_MessageFor = function() {
	};
	$Cayita_Plugins_MessageFor.createInstance = function() {
		return $Cayita_Plugins_MessageFor.$ctor();
	};
	$Cayita_Plugins_MessageFor.input = function(T) {
		return function($this, input) {
			$this.element = input.element$1();
		};
	};
	$Cayita_Plugins_MessageFor.$ctor = function() {
		var $this = {};
		$this.element = null;
		$this.message = null;
		$this.message = $Cayita_Plugins_Message.$ctor();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins.Range
	var $Cayita_Plugins_Range = function() {
	};
	$Cayita_Plugins_Range.createInstance = function() {
		return $Cayita_Plugins_Range.$ctor();
	};
	$Cayita_Plugins_Range.$ctor = function() {
		var $this = {};
		$this.top = 0;
		$this.bottom = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins.Rule
	var $Cayita_Plugins_Rule = function() {
	};
	$Cayita_Plugins_Rule.createInstance = function() {
		return $Cayita_Plugins_Rule.$ctor();
	};
	$Cayita_Plugins_Rule.remote = function($this, url) {
		$this.rl.url = url;
		return $this;
	};
	$Cayita_Plugins_Rule.remote$1 = function($this, url, method) {
		$this.rl.url = { url: url, method: method };
		return $this;
	};
	$Cayita_Plugins_Rule.required = function($this) {
		$this.rl.required = true;
		return $this;
	};
	$Cayita_Plugins_Rule.required$1 = function($this, handler) {
		$this.rl.required = handler;
		return $this;
	};
	$Cayita_Plugins_Rule.email = function($this, dependCallback) {
		if (ss.staticEquals(dependCallback, null)) {
			$this.rl = { email: true, required: true };
		}
		else {
			$this.rl.mail = { depends: dependCallback };
		}
		return $this;
	};
	$Cayita_Plugins_Rule.url = function($this) {
		$this.rl.url = true;
		return $this;
	};
	$Cayita_Plugins_Rule.date = function($this) {
		$this.rl.date = true;
		return $this;
	};
	$Cayita_Plugins_Rule.dateISO = function($this) {
		$this.rl.dateISO = true;
		return $this;
	};
	$Cayita_Plugins_Rule.number = function($this) {
		$this.rl.number = true;
		return $this;
	};
	$Cayita_Plugins_Rule.digits = function($this) {
		$this.rl.digits = true;
		return $this;
	};
	$Cayita_Plugins_Rule.creditcard = function($this, dependCallback) {
		if (!ss.staticEquals(dependCallback, null)) {
			$this.rl.creditcard = true;
		}
		else {
			$this.rl.creditcard = { depends: dependCallback };
		}
		return $this;
	};
	$Cayita_Plugins_Rule.equalTo = function($this, element) {
		$this.rl.equalTo = '#' + element.id;
		return $this;
	};
	$Cayita_Plugins_Rule.maxlength = function($this, value) {
		$this.rl.maxlength = value;
		return $this;
	};
	$Cayita_Plugins_Rule.minlength = function($this, value) {
		$this.rl.minlength = value;
		return $this;
	};
	$Cayita_Plugins_Rule.max = function($this, value) {
		$this.rl.max = value;
		return $this;
	};
	$Cayita_Plugins_Rule.min = function($this, value) {
		$this.rl.min = value;
		return $this;
	};
	$Cayita_Plugins_Rule.range = function($this, range) {
		$this.rl.range = [range.bottom, range.top];
		return $this;
	};
	$Cayita_Plugins_Rule.rangeLength = function($this, range) {
		$this.rl.rangelength = [range.bottom, range.top];
		return $this;
	};
	$Cayita_Plugins_Rule.$ctor = function() {
		var $this = {};
		$this.rl = {};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins.RuleFor
	var $Cayita_Plugins_RuleFor = function() {
	};
	$Cayita_Plugins_RuleFor.createInstance = function() {
		return $Cayita_Plugins_RuleFor.$ctor();
	};
	$Cayita_Plugins_RuleFor.input = function(T) {
		return function($this, input) {
			$this.element = input.element$1();
		};
	};
	$Cayita_Plugins_RuleFor.$ctor = function() {
		var $this = {};
		$this.element = null;
		$this.rule = null;
		$this.rule = $Cayita_Plugins_Rule.$ctor();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins.ValidateOptions
	var $Cayita_Plugins_ValidateOptions = function() {
	};
	$Cayita_Plugins_ValidateOptions.createInstance = function() {
		return $Cayita_Plugins_ValidateOptions.$ctor();
	};
	$Cayita_Plugins_ValidateOptions.setErrorClass = function($this, className) {
		$this.errorClass = className;
		return $this;
	};
	$Cayita_Plugins_ValidateOptions.setValidClass = function($this, className) {
		$this.validClass = className;
		return $this;
	};
	$Cayita_Plugins_ValidateOptions.setSubmitHandler = function($this, handler) {
		$this.submitHandler = handler;
		return $this;
	};
	$Cayita_Plugins_ValidateOptions.setHighlightHandler = function($this, handler) {
		$this.highlight = handler;
		return $this;
	};
	$Cayita_Plugins_ValidateOptions.setUnhighlightHandler = function($this, handler) {
		$this.unhighlight = handler;
		return $this;
	};
	$Cayita_Plugins_ValidateOptions.setSuccessHandler = function($this, handler) {
		$this.success = handler;
		return $this;
	};
	$Cayita_Plugins_ValidateOptions.addRule = function($this, rule) {
		var rulefor = $Cayita_Plugins_RuleFor.$ctor();
		var msg = $Cayita_Plugins_Message.$ctor();
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
	$Cayita_Plugins_ValidateOptions.$ctor = function() {
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
		$Cayita_Plugins_ValidateOptions.setHighlightHandler($this, function(element) {
			$(element).closest('.control-group').removeClass($this.validClass).addClass($this.errorClass);
		});
		$Cayita_Plugins_ValidateOptions.setSuccessHandler($this, function(label) {
			label.closest('.control-group').removeClass($this.errorClass).addClass($this.validClass);
		});
		$Cayita_Plugins_ValidateOptions.setUnhighlightHandler($this, function(element1) {
			$(element1).closest('.control-group').removeClass($this.errorClass);
		});
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Alert
	var $Cayita_UI_Alert = function() {
	};
	$Cayita_UI_Alert.errorTemplate = function() {
		return '<div class=\'alert alert-block alert-error\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Alert.error$1 = function(element, message, before) {
		var jq = $(ss.formatString($Cayita_UI_Alert.errorTemplate(), message));
		return (before ? jq.insertBefore(element) : jq.insertAfter(element));
	};
	$Cayita_UI_Alert.error = function(message) {
		return $(ss.formatString($Cayita_UI_Alert.errorTemplate(), message));
	};
	$Cayita_UI_Alert.successTemplate = function() {
		return '<div class=\'alert alert-block alert-success\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Alert.success$1 = function(element, message, before) {
		var jq = $(ss.formatString($Cayita_UI_Alert.successTemplate(), message));
		return (before ? jq.insertBefore(element) : jq.insertAfter(element));
	};
	$Cayita_UI_Alert.success = function(message) {
		return $(ss.formatString($Cayita_UI_Alert.successTemplate(), message));
	};
	$Cayita_UI_Alert.infoTemplate = function() {
		return '<div class=\'alert alert-block alert-info\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Alert.info$1 = function(element, message, before) {
		var jq = $(ss.formatString($Cayita_UI_Alert.infoTemplate(), message));
		return (before ? jq.insertBefore(element) : jq.insertAfter(element));
	};
	$Cayita_UI_Alert.info = function(message) {
		return $(ss.formatString($Cayita_UI_Alert.infoTemplate(), message));
	};
	$Cayita_UI_Alert.warningTemplate = function() {
		return '<div class=\'alert alert-block\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_UI_Alert.warning = function(element, message, before) {
		var jq = $(ss.formatString($Cayita_UI_Alert.warningTemplate(), message));
		return (before ? jq.insertBefore(element) : jq.insertAfter(element));
	};
	$Cayita_UI_Alert.pageAlert = function(message, type) {
		var div = new $Cayita_UI_Div(function(de) {
			de.className = ss.formatString('alert{0}', (ss.isNullOrEmptyString(type) ? '' : ('alert-' + type)));
			new $Cayita_UI_Anchor.$ctor3(de, function(element) {
				element.href = '#';
				element.className = 'close';
				element.setAttribute('data-dismiss', 'alert');
				$Extensions.text$1(element, '×');
			});
			$(de).append(message);
		});
		div.appendTo$2(document.body);
		return div;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Anchor
	var $Cayita_UI_Anchor = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Anchor]).call(this);
		this.$init(null);
	};
	$Cayita_UI_Anchor.prototype = {
		$init: function(parent) {
			this.createElement('a', parent);
			this.element$1().href = '#';
		},
		element$1: function() {
			return this.element();
		},
		href: function(url) {
			this.element$1().href = url;
			return this;
		}
	};
	$Cayita_UI_Anchor.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Anchor]).call(this);
		this.$init(null);
		element(this.element$1());
	};
	$Cayita_UI_Anchor.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Anchor]).call(this);
		this.$init(parent);
		element(this.element$1());
	};
	$Cayita_UI_Anchor.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Anchor]).call(this);
		this.$init(parent);
	};
	$Cayita_UI_Anchor.$ctor1.prototype = $Cayita_UI_Anchor.$ctor3.prototype = $Cayita_UI_Anchor.$ctor2.prototype = $Cayita_UI_Anchor.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Bootbox
	var $Cayita_UI_Bootbox = function() {
	};
	$Cayita_UI_Bootbox.dialog$3 = function(message, options, buttons) {
		bootbox.dialog(message, buttons || [], options);
	};
	$Cayita_UI_Bootbox.dialog$4 = function(message, options, buttons) {
		var opt = $Cayita_UI_DialogOptions.$ctor();
		if (!ss.staticEquals(options, null)) {
			options(opt);
		}
		var bt = [];
		if (!ss.staticEquals(buttons, null)) {
			buttons(bt);
		}
		bootbox.dialog(message, bt, opt);
	};
	$Cayita_UI_Bootbox.dialog$2 = function(body, options, buttons) {
		$Cayita_UI_Bootbox.dialog$5($(body), options, buttons);
	};
	$Cayita_UI_Bootbox.dialog$1 = function(body, options, buttons) {
		$Cayita_UI_Bootbox.dialog$5(body.jQuery(), options, buttons);
	};
	$Cayita_UI_Bootbox.dialog$5 = function(body, options, buttons) {
		var opt = $Cayita_UI_DialogOptions.$ctor();
		if (!ss.staticEquals(options, null)) {
			options(opt);
		}
		var bt = [];
		if (!ss.staticEquals(buttons, null)) {
			buttons(bt);
		}
		bootbox.dialog(body, bt, opt);
	};
	$Cayita_UI_Bootbox.dialog = function(message, caption) {
		var $t1 = $Cayita_UI_DialogOptions.$ctor();
		$t1.header = caption;
		bootbox.dialog(message, [], $t1);
	};
	$Cayita_UI_Bootbox.error = function(message, caption) {
		var $t1 = $Cayita_UI_DialogOptions.$ctor();
		$t1.header = ss.formatString('<p style="color:red;"><i class="icon-minus-sign" style="margin-top:8px;margin-right:8px;"></i>{0}</p>', caption);
		bootbox.dialog(message, [], $t1);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Button
	var $Cayita_UI_Button = function(element) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_Button]).call(this);
		this.createButton(null, 'button');
		element(this.element$1());
	};
	$Cayita_UI_Button.$ctor2 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_Button]).call(this);
		this.createButton(parent, 'button');
		element(this.element$1());
	};
	$Cayita_UI_Button.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_Button]).call(this);
		this.createButton(parent, 'button');
	};
	$Cayita_UI_Button.$ctor2.prototype = $Cayita_UI_Button.$ctor1.prototype = $Cayita_UI_Button.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.ButtonBase
	var $Cayita_UI_ButtonBase$1 = function(T) {
		var $type = function() {
			this.$3$ClickedField = function(b, e) {
			};
			ss.makeGenericType($Cayita_UI_ElementBase$1, [T]).call(this);
		};
		$type.prototype = {
			createButton: function(parent, type) {
				this.createElement('button', parent);
				var el = this.element$1();
				if (!ss.isNullOrEmptyString(type)) {
					$(el).attr('type', type);
				}
				el.className = 'btn';
				$(el).on('click', ss.mkdel(this, function(evt) {
					this.onClicked(evt);
				}));
			},
			add_clicked: function(value) {
				this.$3$ClickedField = ss.delegateCombine(this.$3$ClickedField, value);
			},
			remove_clicked: function(value) {
				this.$3$ClickedField = ss.delegateRemove(this.$3$ClickedField, value);
			},
			onClicked: function(evt) {
				this.$3$ClickedField(this, evt);
			},
			loadingText: function(value) {
				$(this.element$1()).button.defaults.loadingText = value;
				return this;
			},
			showLoadingText: function() {
				$(this.element$1()).button('loading');
				return this;
			},
			resetLoadingText: function() {
				$(this.element$1()).button('reset');
				return this;
			},
			toggle: function() {
				$(this.element$1()).toggle();
				return this;
			},
			element$1: function() {
				return ss.cast(this.element(), Element);
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_ButtonBase$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_ElementBase$1, [T]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.ButtonBase$1', $Cayita_UI_ButtonBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.CheckboxField
	var $Cayita_UI_CheckboxField = function() {
		$Cayita_UI_CheckboxField.$ctor3.call(this, null);
	};
	$Cayita_UI_CheckboxField.prototype = {
		get_label: function() {
			return this.$5$LabelField;
		},
		set_label: function(value) {
			this.$5$LabelField = value;
		},
		get_input: function() {
			return this.$5$InputField;
		},
		set_input: function(value) {
			this.$5$InputField = value;
		},
		text$5: function(value) {
			this.get_label().text$1(value);
			return this;
		},
		text$4: function() {
			return this.get_label().text();
		},
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_CheckboxField.$ctor1 = function(parent) {
		$Cayita_UI_CheckboxField.$ctor3.call(this, parent.element());
	};
	$Cayita_UI_CheckboxField.$ctor3 = function(parent) {
		this.$5$LabelField = null;
		this.$5$InputField = null;
		ss.makeGenericType($Cayita_UI_Field$1, [$Cayita_UI_CheckboxField]).call(this, parent, 'checkbox', false, 'input');
		this.set_input(this.element$2());
		this.element$2().value = 'true';
		this.set_label(new $Cayita_UI_Label.$ctor2(this.get_controls().element$1(), ss.mkdel(this, function(l) {
			l.className = 'checkbox';
			$(l).attr('for', this.element$2().id);
			$(l).append(this.element$2());
		})));
	};
	$Cayita_UI_CheckboxField.$ctor2 = function(field) {
		$Cayita_UI_CheckboxField.$ctor4.call(this, null, field);
	};
	$Cayita_UI_CheckboxField.$ctor4 = function(parent, field) {
		$Cayita_UI_CheckboxField.$ctor3.call(this, parent);
		field(this.get_label().element$1(), this.element$2());
		this.get_label().for$2(this.element$2().id);
	};
	$Cayita_UI_CheckboxField.$ctor5 = function(parent, label, fieldname) {
		$Cayita_UI_CheckboxField.$ctor3.call(this, parent);
		this.get_label().text$1(label);
		this.name$1(fieldname);
	};
	$Cayita_UI_CheckboxField.$ctor1.prototype = $Cayita_UI_CheckboxField.$ctor3.prototype = $Cayita_UI_CheckboxField.$ctor2.prototype = $Cayita_UI_CheckboxField.$ctor4.prototype = $Cayita_UI_CheckboxField.$ctor5.prototype = $Cayita_UI_CheckboxField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.CheckGroup
	var $Cayita_UI_CheckGroup = function() {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_CheckGroup, $Cayita_UI_InputCheckbox]).call(this, 'checkbox', null, null, null, null, true);
	};
	$Cayita_UI_CheckGroup.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_CheckGroup, $Cayita_UI_InputCheckbox]).call(this, 'checkbox', parent, null, null, null, true);
	};
	$Cayita_UI_CheckGroup.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_CheckGroup, $Cayita_UI_InputCheckbox]).call(this, 'checkbox', parent.element(), null, null, null, true);
	};
	$Cayita_UI_CheckGroup.$ctor2.prototype = $Cayita_UI_CheckGroup.$ctor1.prototype = $Cayita_UI_CheckGroup.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.ClickedRow
	var $Cayita_UI_ClickedRow$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = ss.makeGenericType($Cayita_UI_SelectedRow$1, [T]).$ctor();
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_ClickedRow$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_SelectedRow$1, [T]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.ClickedRow$1', $Cayita_UI_ClickedRow$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.DialogButton
	var $Cayita_UI_DialogButton = function() {
	};
	$Cayita_UI_DialogButton.createInstance = function() {
		return $Cayita_UI_DialogButton.$ctor();
	};
	$Cayita_UI_DialogButton.$ctor = function() {
		var $this = {};
		$this.label = null;
		$this.class = null;
		$this.callback = null;
		$this.callback = function() {
		};
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.DialogOptions
	var $Cayita_UI_DialogOptions = function() {
	};
	$Cayita_UI_DialogOptions.createInstance = function() {
		return $Cayita_UI_DialogOptions.$ctor();
	};
	$Cayita_UI_DialogOptions.$ctor = function() {
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
	// Cayita.UI.Div
	var $Cayita_UI_Div = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Div]).call(this);
		this.createElement('div', null);
		element(this.element$1());
	};
	$Cayita_UI_Div.prototype = {
		element$1: function() {
			return this.element();
		},
		append$5: function(T) {
			return function(content) {
				this.append(T).call(this, content);
				return this;
			};
		}
	};
	$Cayita_UI_Div.$ctor2 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Div]).call(this);
		this.createElement('div', parent);
		element(this.element$1());
	};
	$Cayita_UI_Div.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Div]).call(this);
		this.createElement('div', parent);
	};
	$Cayita_UI_Div.$ctor2.prototype = $Cayita_UI_Div.$ctor1.prototype = $Cayita_UI_Div.prototype;
	$Cayita_UI_Div.createControlGroup = function(parent) {
		return new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'control-group';
		});
	};
	$Cayita_UI_Div.createControlGroup$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'control-group';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createControls = function(parent) {
		return new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'controls';
		});
	};
	$Cayita_UI_Div.createControls$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'controls';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createContainer = function(parent) {
		return new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'container';
		});
	};
	$Cayita_UI_Div.createContainer$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'container';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createContainerFluid = function(parent) {
		return new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'container-fluid';
		});
	};
	$Cayita_UI_Div.createContainerFluid$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'container-fluid';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createRow = function(parent) {
		return new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'row';
		});
	};
	$Cayita_UI_Div.createRow$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'row';
		});
		element(d.element$1());
		return d;
	};
	$Cayita_UI_Div.createRowFluid = function(parent) {
		return new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'row-fluid';
		});
	};
	$Cayita_UI_Div.createRowFluid$1 = function(parent, element) {
		var d = new $Cayita_UI_Div.$ctor2(parent, function(div) {
			div.className = 'row-fluid';
		});
		element(d.element$1());
		return d;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.DropDownMenu
	var $Cayita_UI_DropDownMenu = function(list) {
		$Cayita_UI_DropDownMenu.$ctor1.call(this, null, list);
	};
	$Cayita_UI_DropDownMenu.prototype = {
		appendTo$3: function(parent) {
			$(parent).append(this.element()).addClass('dropdown');
			return this;
		}
	};
	$Cayita_UI_DropDownMenu.$ctor1 = function(parent, list) {
		$Cayita_UI_HtmlList.call(this, parent, false);
		var el = this.element$1();
		el.className = 'dropdown-menu';
		el.setAttribute('role', 'menu');
		list(this.element$1());
	};
	$Cayita_UI_DropDownMenu.$ctor1.prototype = $Cayita_UI_DropDownMenu.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.DropDownSubmenu
	var $Cayita_UI_DropDownSubmenu = function(item, list) {
		$Cayita_UI_DropDownSubmenu.$ctor1.call(this, null, item, list);
	};
	$Cayita_UI_DropDownSubmenu.prototype = {
		appendTo$3: function(parent) {
			parent.append$1(this);
			return this;
		}
	};
	$Cayita_UI_DropDownSubmenu.$ctor1 = function(parent, item, list) {
		$Cayita_UI_ListItem.call(this, parent);
		var li = this.element$1();
		li.className = 'dropdown-submenu';
		new $Cayita_UI_Anchor.$ctor3(li, function(a) {
			a.href = '#';
			a.tabIndex = -1;
			$Extensions.text$1(a, item);
		});
		new $Cayita_UI_HtmlList.$ctor1(li, function(nl) {
			nl.className = 'dropdown-menu';
			list(nl);
		}, false);
	};
	$Cayita_UI_DropDownSubmenu.$ctor1.prototype = $Cayita_UI_DropDownSubmenu.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.ElementBase
	var $Cayita_UI_ElementBase = function() {
		this.$element_ = null;
		this.$1$StyleField = null;
		this.$1$IDField = null;
	};
	$Cayita_UI_ElementBase.prototype = {
		get_style: function() {
			return this.$1$StyleField;
		},
		set_style: function(value) {
			this.$1$StyleField = value;
		},
		get_id: function() {
			return this.$1$IDField;
		},
		set_id: function(value) {
			this.$1$IDField = value;
		},
		setElement: function(element) {
			this.$element_ = element;
		},
		createElement: function(tagName, parent) {
			this.$element_ = document.createElement(tagName);
			this.$element_.id = this.createId(tagName);
			if (ss.isValue(parent)) {
				$(parent).append(this.$element_);
			}
			this.set_id(this.$element_.id);
			this.set_style(this.$element_.style);
		},
		createId: function(tagName) {
			var id = {};
			$Cayita_UI_ElementBase.$tags.tryGetValue(tagName, id);
			$Cayita_UI_ElementBase.$tags.set_item(tagName, ++id.$);
			return ss.formatString('c-{0}-{1}', tagName, id.$);
		},
		selectorById: function() {
			return '#' + this.$element_.id;
		},
		className: function() {
			return this.$element_.className;
		},
		element: function() {
			return this.$element_;
		},
		jQuery: function() {
			return $(this.$element_);
		},
		jQuery$1: function(selector) {
			return $(selector, this.$element_);
		},
		isVisible: function() {
			return $(this.$element_).is(':visible');
		},
		draggableObject: function() {
			return $(this.$element_).draggable();
		},
		resizableObject: function() {
			return $(this.$element_).resizable();
		},
		getId: function() {
			return this.$element_.id;
		},
		append: function(T) {
			return function(content) {
				var e = ss.createInstance(T);
				$(this.$element_).append(e.$element_);
				content(e);
				return this;
			};
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.ElementBase
	var $Cayita_UI_ElementBase$1 = function(T) {
		var $type = function() {
			$Cayita_UI_ElementBase.call(this);
		};
		$type.prototype = {
			className$1: function(cssClass) {
				this.element().className = cssClass;
				return this;
			},
			addClass: function(cssClass) {
				this.jQuery().addClass(cssClass);
				return this;
			},
			removeClass: function() {
				this.jQuery().removeClass();
				return this;
			},
			removeClass$1: function(cssClass) {
				this.jQuery().removeClass(cssClass);
				return this;
			},
			disable: function(disable) {
				this.element().disabled = disable;
				return this;
			},
			append$3: function(content) {
				this.jQuery().append(content);
				return this;
			},
			append$2: function(content) {
				this.jQuery().append(content);
				return this;
			},
			append$1: function(content) {
				this.jQuery().append(content.element());
				return this;
			},
			append$4: function(content) {
				this.jQuery().append(content);
				return this;
			},
			show: function() {
				$(this.element()).show();
				return this;
			},
			hide: function() {
				$(this.element()).hide();
				return this;
			},
			slideToggle: function() {
				$(this.element()).slideToggle();
				return this;
			},
			fadeIn: function() {
				$(this.element()).fadeIn();
				return this;
			},
			fadeOut: function() {
				$(this.element()).fadeOut();
				return this;
			},
			fadeToggle: function() {
				$(this.element()).fadeToggle();
				return this;
			},
			remove: function() {
				$(this.element()).remove();
				return this;
			},
			empty: function() {
				$(this.element()).empty();
				return this;
			},
			appendTo$2: function(parent) {
				$(parent || document.body).append(this.element());
				return this;
			},
			appendTo$1: function(parent) {
				parent.appendChild(this.element());
				return this;
			},
			appendTo: function(parent) {
				$(parent.element()).append(this.element());
				return this;
			},
			text$1: function(text) {
				$Extensions.text$1(this.element(), text);
				return this;
			},
			text: function() {
				return $Extensions.text(this.element());
			},
			iconClass: function(iconClass) {
				var i = this.jQuery$1('i');
				if (i.length === 0) {
					var ie = document.createElement('i');
					this.append$2(ie);
					i = $(ie);
				}
				i.addClass(ss.coalesce(iconClass, ''));
				return this;
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_ElementBase$1, [T], function() {
			return $Cayita_UI_ElementBase;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.ElementBase$1', $Cayita_UI_ElementBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Field
	var $Cayita_UI_Field$1 = function(TField) {
		var $type = function(parent, type, append, tagname) {
			this.$4$ControlLabelField = null;
			this.$4$ControlsField = null;
			this.$4$ControlGroupField = null;
			ss.makeGenericType($Cayita_UI_InputBase$1, [TField]).$ctor1.call(this, parent, type, tagname);
			this.set_controlGroup((new $Cayita_UI_Div.$ctor1(parent)).className$1('control-group'));
			this.set_controlLabel((new $Cayita_UI_Label.$ctor1(null)).className$1('control-label'));
			this.set_controls((new $Cayita_UI_Div.$ctor1(null)).className$1('controls'));
			if (append) {
				this.appendTo(this.get_controls());
			}
			this.get_controlGroup().append$1(this.get_controlLabel());
			this.get_controlGroup().append$1(this.get_controls());
		};
		$type.prototype = {
			get_controlLabel: function() {
				return this.$4$ControlLabelField;
			},
			set_controlLabel: function(value) {
				this.$4$ControlLabelField = value;
			},
			get_controls: function() {
				return this.$4$ControlsField;
			},
			set_controls: function(value) {
				this.$4$ControlsField = value;
			},
			get_controlGroup: function() {
				return this.$4$ControlGroupField;
			},
			set_controlGroup: function(value) {
				this.$4$ControlGroupField = value;
			},
			text$3: function(value) {
				this.get_controlLabel().text$1(value);
				return this;
			},
			text$2: function() {
				return this.get_controlLabel().text();
			},
			appendTo$3: function(parent) {
				this.get_controlGroup().appendTo(parent);
				return this;
			},
			slideToggle$1: function() {
				this.get_controlGroup().slideToggle();
				return this;
			},
			hide$1: function() {
				this.get_controlGroup().hide();
				return this;
			},
			show$1: function() {
				this.get_controlGroup().show();
				return this;
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_Field$1, [TField], function() {
			return ss.makeGenericType($Cayita_UI_InputBase$1, [TField]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.Field$1', $Cayita_UI_Field$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.FieldSet
	var $Cayita_UI_FieldSet = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_FieldSet]).call(this);
		this.createElement('fieldset', parent);
	};
	$Cayita_UI_FieldSet.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_FieldSet]).call(this);
		this.createElement('fieldset', parent);
		element(this.element());
	};
	$Cayita_UI_FieldSet.$ctor1.prototype = $Cayita_UI_FieldSet.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.FileUpload
	var $Cayita_UI_FileUpload = function(parent) {
		this.$cfg = null;
		ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_UI_FileUpload]).call(this, parent);
		this.$init(new $Cayita_UI_FileUploadConfig());
	};
	$Cayita_UI_FileUpload.prototype = {
		$init: function(config) {
			this.$cfg = config;
			(new $Cayita_UI_Div(ss.mkdel(this, function(d) {
				d.className = 'input-append';
				new $Cayita_UI_Div.$ctor2(d, ss.mkdel(this, function(inpt) {
					inpt.className = 'uneditable-input span' + this.$cfg.get_spanSize();
					new $Cayita_UI_Icon.$ctor3(inpt, function(i) {
						i.className = 'icon-file fileupload-exists';
					});
					new $Cayita_UI_Span.$ctor2(inpt, function(s) {
						s.className = 'fileupload-preview';
					});
				}));
				new $Cayita_UI_Span.$ctor2(d, ss.mkdel(this, function(sp) {
					sp.className = 'btn btn-file';
					new $Cayita_UI_Span.$ctor2(sp, ss.mkdel(this, function(sl) {
						sl.className = 'fileupload-new';
						new $Cayita_UI_Icon.$ctor3(sl, ss.mkdel(this, function(i1) {
							i1.className = this.$cfg.get_selectIconClass();
						}));
						var t = document.createElement('ctxt');
						$(sl).append(t);
						t.innerHTML = ss.coalesce(this.$cfg.get_selectText(), '');
					}));
					new $Cayita_UI_Span.$ctor2(sp, ss.mkdel(this, function(sl1) {
						sl1.className = 'fileupload-exists';
						new $Cayita_UI_Icon.$ctor3(sl1, ss.mkdel(this, function(i2) {
							i2.className = this.$cfg.get_selectIconClass();
						}));
						var t1 = document.createElement('ctxt');
						$(sl1).append(t1);
						t1.innerHTML = ss.coalesce(this.$cfg.get_selectText(), '');
					}));
					this.createInput(sp, this.$cfg);
				}));
				new $Cayita_UI_Anchor.$ctor3(d, ss.mkdel(this, function(a) {
					a.className = 'btn fileupload-exists';
					a.setAttribute('data-dismiss', 'fileupload');
					new $Cayita_UI_Icon.$ctor3(a, ss.mkdel(this, function(i3) {
						i3.className = this.$cfg.get_removeIconClass();
					}));
					var t2 = document.createElement('ctxt');
					$(a).append(t2);
					t2.innerHTML = ss.coalesce(this.$cfg.get_removeText(), '');
				}));
			}))).appendTo$2(this.element());
		}
	};
	$Cayita_UI_FileUpload.$ctor2 = function(parent, config) {
		this.$cfg = null;
		ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_UI_FileUpload]).call(this, parent);
		var c = new $Cayita_UI_FileUploadConfig();
		config(c);
		this.$init(c);
	};
	$Cayita_UI_FileUpload.$ctor1 = function(parent, config) {
		this.$cfg = null;
		ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_UI_FileUpload]).call(this, parent);
		this.$init(config);
	};
	$Cayita_UI_FileUpload.$ctor2.prototype = $Cayita_UI_FileUpload.$ctor1.prototype = $Cayita_UI_FileUpload.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.FileUpload
	var $Cayita_UI_FileUpload$1 = function(T) {
		var $type = function(parent) {
			this.$3$InputField = null;
			this.$3$FileSelectedField = function(f) {
			};
			ss.makeGenericType($Cayita_UI_ElementBase$1, [T]).call(this);
			this.createElement('div', parent);
			var e = this.element();
			e.className = 'fileupload fileupload-new';
			e.setAttribute('data-provides', 'fileupload');
			this.jQuery().on('change.fileupload', ss.mkdel(this, function(evt) {
				this.onFileSelected();
			}));
		};
		$type.prototype = {
			get_input: function() {
				return this.$3$InputField;
			},
			set_input: function(value) {
				this.$3$InputField = value;
			},
			add_fileSelected: function(value) {
				this.$3$FileSelectedField = ss.delegateCombine(this.$3$FileSelectedField, value);
			},
			remove_fileSelected: function(value) {
				this.$3$FileSelectedField = ss.delegateRemove(this.$3$FileSelectedField, value);
			},
			onFileSelected: function() {
				this.$3$FileSelectedField(this);
			},
			createInput: function(sp, cfg) {
				new $Cayita_UI_InputFile.$ctor2(sp, ss.mkdel(this, function(i) {
					i.name = cfg.get_fieldname();
					i.accept = cfg.get_accept();
					i.multiple = cfg.get_multiple();
					this.set_input(i);
				}));
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_FileUpload$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_ElementBase$1, [T]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.FileUpload$1', $Cayita_UI_FileUpload$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.FileUploadConfig
	var $Cayita_UI_FileUploadConfig = function() {
		this.$1$SelectTextField = null;
		this.$1$SelectIconClassField = null;
		this.$1$RemoveTextField = null;
		this.$1$RemoveIconClassField = null;
		this.$1$FieldnameField = null;
		this.$1$SpanSizeField = 0;
		this.$1$AcceptField = null;
		this.$1$MultipleField = false;
		this.set_selectIconClass('icon-folder-open');
		this.set_removeIconClass('icon-remove');
		this.set_fieldname('');
		this.set_accept('');
		//PlaceHolder = "";
		this.set_spanSize(3);
	};
	$Cayita_UI_FileUploadConfig.prototype = {
		get_selectText: function() {
			return this.$1$SelectTextField;
		},
		set_selectText: function(value) {
			this.$1$SelectTextField = value;
		},
		get_selectIconClass: function() {
			return this.$1$SelectIconClassField;
		},
		set_selectIconClass: function(value) {
			this.$1$SelectIconClassField = value;
		},
		get_removeText: function() {
			return this.$1$RemoveTextField;
		},
		set_removeText: function(value) {
			this.$1$RemoveTextField = value;
		},
		get_removeIconClass: function() {
			return this.$1$RemoveIconClassField;
		},
		set_removeIconClass: function(value) {
			this.$1$RemoveIconClassField = value;
		},
		get_fieldname: function() {
			return this.$1$FieldnameField;
		},
		set_fieldname: function(value) {
			this.$1$FieldnameField = value;
		},
		get_spanSize: function() {
			return this.$1$SpanSizeField;
		},
		set_spanSize: function(value) {
			this.$1$SpanSizeField = value;
		},
		get_accept: function() {
			return this.$1$AcceptField;
		},
		set_accept: function(value) {
			this.$1$AcceptField = value;
		},
		get_multiple: function() {
			return this.$1$MultipleField;
		},
		set_multiple: function(value) {
			this.$1$MultipleField = value;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Form
	var $Cayita_UI_Form = function(parent) {
		this.$3$DataChangedField = function(f) {
		};
		this.$val = $Cayita_Plugins_ValidateOptions.$ctor();
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Form]).call(this);
		this.$init(parent);
	};
	$Cayita_UI_Form.prototype = {
		add_dataChanged: function(value) {
			this.$3$DataChangedField = ss.delegateCombine(this.$3$DataChangedField, value);
		},
		remove_dataChanged: function(value) {
			this.$3$DataChangedField = ss.delegateRemove(this.$3$DataChangedField, value);
		},
		onDataChanged: function() {
			this.$3$DataChangedField(this);
		},
		$init: function(parent) {
			this.createElement('form', parent);
			$(this.element$1()).on('change', 'input', ss.mkdel(this, function(evt) {
				this.onDataChanged();
			}));
		},
		element$1: function() {
			return this.element();
		},
		formData: function() {
			return new FormData(this.element$1());
		},
		validate: function() {
			$(this.element$1()).validate(this.$val);
			return this;
		},
		addRule: function(rule) {
			$Cayita_Plugins_ValidateOptions.addRule(this.$val, rule);
			return this;
		},
		setSubmitHanlder: function(form) {
			$Cayita_Plugins_ValidateOptions.setSubmitHandler(this.$val, ss.mkdel(this, function(f) {
				form(this);
			}));
			return this;
		},
		findSubmit: function() {
			return $Extensions.find(Element).call(null, this.element$1(), '[type=submit]');
		},
		reset: function() {
			this.element$1().reset();
			return this;
		},
		load: function(T) {
			return function(data) {
				cayita.fn.loadForm(this.element$1(), data);
				return this;
			};
		},
		loadTo: function(T) {
			return function() {
				return $Extensions.loadTo(T).call(null, this.element$1());
			};
		},
		hasChanged: function() {
			return cayita.fn.hasChanged(this.element$1());
		}
	};
	$Cayita_UI_Form.$ctor1 = function(parent, element) {
		this.$3$DataChangedField = function(f) {
		};
		this.$val = $Cayita_Plugins_ValidateOptions.$ctor();
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Form]).call(this);
		this.$init(parent);
		element(this.element$1());
	};
	$Cayita_UI_Form.$ctor1.prototype = $Cayita_UI_Form.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.GroupBase
	var $Cayita_UI_GroupBase$2 = function(TField, TInput) {
		var $type = function(type, parent, text, fieldName, items, inline) {
			this.$3$ControlsField = null;
			this.$3$ControlLabelField = null;
			this.$3$InputField = null;
			this.$nm = null;
			this.$il = false;
			this.$tp = null;
			ss.makeGenericType($Cayita_UI_ElementBase$1, [TField]).call(this);
			this.$tp = type;
			this.$nm = fieldName;
			this.$il = inline;
			this.$init(parent);
			if (!ss.isNullOrEmptyString(text)) {
				this.get_controlLabel().text$1(text);
			}
			if (ss.isValue(items)) {
				var $t1 = ss.getEnumerator(items);
				try {
					while ($t1.moveNext()) {
						var item = $t1.current();
						this.$addItem(item);
					}
				}
				finally {
					$t1.dispose();
				}
			}
		};
		$type.prototype = {
			get_controls: function() {
				return this.$3$ControlsField;
			},
			set_controls: function(value) {
				this.$3$ControlsField = value;
			},
			get_controlLabel: function() {
				return this.$3$ControlLabelField;
			},
			set_controlLabel: function(value) {
				this.$3$ControlLabelField = value;
			},
			get_input: function() {
				return this.$3$InputField;
			},
			set_input: function(value) {
				this.$3$InputField = value;
			},
			$init: function(parent) {
				this.createElement('div', parent);
				this.element$1().className = 'control-group';
				this.set_controlLabel((new $Cayita_UI_Label.$ctor1(null)).className$1('control-label'));
				this.set_controls((new $Cayita_UI_Div.$ctor1(null)).className$1('controls'));
				this.append$1(this.get_controlLabel());
				this.append$1(this.get_controls());
			},
			inline: function(inline) {
				this.$il = inline;
				var l = this.get_controls().jQuery$1('label.' + this.$tp);
				if (this.$il) {
					l.addClass('inline');
				}
				else {
					l.removeClass('inline');
				}
				return this;
			},
			name$1: function(name) {
				this.$nm = name;
				this.get_controls().jQuery$1('[type=' + this.$tp + ']').attr('name', name);
				return this;
			},
			name: function() {
				return this.$nm;
			},
			text$3: function(text) {
				this.get_controlLabel().text$1(text);
				return this;
			},
			text$2: function() {
				return this.get_controlLabel().text();
			},
			add: function(item) {
				this.$addItem(item);
				return this;
			},
			element$1: function() {
				return this.element();
			},
			$addItem: function(item) {
				this.set_input(ss.createInstance(TInput).value$1(item.value));
				(new $Cayita_UI_Label.$ctor1(this.get_controls().element$1())).className$1(this.$tp + (this.$il ? ' inline' : '')).text$1(item.text).for$2(this.get_input().get_id()).append$1(this.get_input());
				if (!ss.isNullOrEmptyString(this.$nm)) {
					this.get_input().name$1(this.$nm);
				}
			}
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_GroupBase$2, [TField, TInput], function() {
			return ss.makeGenericType($Cayita_UI_ElementBase$1, [TField]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.GroupBase$2', $Cayita_UI_GroupBase$2, 2);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.GroupItem
	var $Cayita_UI_GroupItem = function() {
	};
	$Cayita_UI_GroupItem.createInstance = function() {
		return $Cayita_UI_GroupItem.$ctor();
	};
	$Cayita_UI_GroupItem.$ctor = function() {
		var $this = {};
		$this.text = null;
		$this.value = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.HtmlGrid
	var $Cayita_UI_HtmlGrid$1 = function(T) {
		var $type = function(parent) {
			this.$columns = null;
			this.$store = null;
			this.$table = null;
			this.$selectedrow = null;
			this.$readRequestStarted = null;
			this.$readRequestFinished = null;
			this.$readRequestMessage = null;
			var $t1 = [];
			ss.add($t1, 33);
			ss.add($t1, 34);
			ss.add($t1, 35);
			ss.add($t1, 36);
			ss.add($t1, 38);
			ss.add($t1, 40);
			this.$nvkeys = $t1;
			this.$4$RowSelectedField = function(g, r) {
			};
			this.$4$RowClickedField = function(g, r) {
			};
			this.$4$KeyDownField = function(g, e) {
			};
			$Cayita_UI_HtmlTable.call(this);
			this.$init(parent, new (ss.makeGenericType($Cayita_Data_Store$1, [T]))(), null);
		};
		$type.prototype = {
			$init: function(parent, datastore, cols) {
				this.createElement('table', parent);
				this.$table = this.element$1();
				this.$table.tabIndex = -1;
				this.$table.className = 'table table-striped table-hover table-condensed';
				this.$table.setAttribute('data-provides', 'rowlink');
				this.$columns = cols || ss.makeGenericType($Cayita_UI_TableColumn$1, [T]).buildColumns(true);
				this.$store = datastore;
				$(this.$table).on('click', 'tbody tr', ss.mkdel(this, function(e) {
					var row = e.currentTarget;
					this.$selectRowImp(row, true, true);
				}));
				$(this.$table).keydown(ss.mkdel(this, this.keydownHandler));
				$Extensions.createHeader(T).call(null, this.$table, this.$columns);
				var $t1 = $Cayita_UI_RequestMessage.$ctor();
				$t1.target = this.$table;
				$t1.message = 'Reading ' + ss.getTypeName(T);
				this.$readRequestMessage = $t1;
				this.$readRequestStarted = ss.mkdel(this, function(grid) {
					var sp = new $Cayita_UI_SpinnerIcon(function(div, icon) {
						div.style.position = 'fixed';
						div.style.zIndex = 10000;
						div.style.opacity = '0.6';
						div.style.height = '90%';
						div.style.width = '77%';
					}, this.$readRequestMessage.message);
					$(this.$readRequestMessage.target).append(sp.element$2());
					return sp.element$2();
				});
				this.$readRequestFinished = function(grid1, el) {
					$(el).remove();
				};
				this.$store.add_storeChanged(ss.mkdel(this, function(st, dt) {
					switch (dt.action) {
						case 0: {
							$Extensions.createRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 11:
						case 10:
						case 1: {
							$Extensions.load$1(T).call(null, this.$table, this.$store, this.$columns, this.$store.getRecordIdProperty(), false);
							this.selectRow(true);
							break;
						}
						case 2: {
							$Extensions.updateRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 3: {
							var recordId = $SystemExtensions.get(dt.oldData, this.$store.getRecordIdProperty());
							$('tr[record-id=' + recordId + ']', this.$table).remove();
							this.selectRow(true);
							break;
						}
						case 4: {
							$Extensions.updateRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 5: {
							$Extensions.createRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 7: {
							$Extensions.updateRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 6: {
							$Extensions.createRow(T).call(null, this.$table, dt.newData, this.$columns, this.$store.getRecordIdProperty());
							break;
						}
						case 8: {
							var id = $SystemExtensions.get(dt.oldData, this.$store.getRecordIdProperty());
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
				this.$store.add_storeRequested(ss.mkdel(this, function(st1, request) {
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
			navKeyHandler: function(evt) {
				evt.preventDefault();
				switch (evt.which) {
					case 34: {
						//page_down
						this.$store.readNextPage(true);
						break;
					}
					case 33: {
						//page_up
						this.$store.readPreviousPage(true);
						break;
					}
					case 35: {
						// end
						break;
					}
					case 36: {
						// home
						break;
					}
					case 38: {
						//up
						this.previousRow();
						break;
					}
					case 40: {
						this.nextRow();
						break;
					}
					default: {
						break;
					}
				}
			},
			keydownHandler: function(evt) {
				if (ss.contains(this.$nvkeys, evt.which)) {
					this.navKeyHandler(evt);
					return;
				}
				this.onKeyDown(evt);
			},
			nextRow: function() {
				var row;
				if (ss.isNullOrUndefined(this.$selectedrow)) {
					var jfr = $('tbody tr', this.$table).first();
					if (jfr.length === 0) {
						return;
					}
					row = jfr.get(0);
				}
				else {
					row = this.$selectedrow.row.nextSibling;
					if (ss.isNullOrUndefined(row)) {
						this.$store.readNextPage(true);
					}
				}
				this.$selectRowImp(row, true, false);
			},
			previousRow: function() {
				var row;
				if (ss.isNullOrUndefined(this.$selectedrow)) {
					var jfr = $('tbody tr', this.$table).last();
					if (jfr.length === 0) {
						return;
					}
					row = jfr.get(0);
				}
				else {
					row = this.$selectedrow.row.previousSibling;
					if (ss.isNullOrUndefined(row)) {
						if (ss.isNullOrUndefined(row)) {
							this.$store.readPreviousPage(true);
						}
					}
				}
				this.$selectRowImp(row, true, false);
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
				$Extensions.load$1(T).call(null, this.$table, this.$store, this.$columns, this.$store.getRecordIdProperty(), false);
				this.selectRow(true);
			},
			selectRow$1: function(recordId, trigger) {
				var row = $('tr[record-id=' + recordId + ']', this.$table).get(0);
				this.$selectRowImp(row, trigger, false);
			},
			selectRow: function(trigger) {
				$('tbody tr', this.$table).removeClass('info');
				this.$selectedrow = null;
				if (trigger) {
					this.onRowSelected(this.$selectedrow);
				}
			},
			$selectRowImp: function(row, triggerSelected, triggerClicked) {
				if (ss.isNullOrUndefined(row)) {
					return;
				}
				var self = this;
				$('tbody tr', this.$table).removeClass('info');
				$(row).addClass('info');
				var record = Enumerable.from(this.$store).first(function(f) {
					return ss.referenceEquals($SystemExtensions.get(f, self.$store.getRecordIdProperty()).toString(), row.getAttribute('record-id'));
				});
				var $t1 = ss.makeGenericType($Cayita_UI_ClickedRow$1, [T]).$ctor();
				$t1.recordId = row.getAttribute('record-id');
				$t1.row = row;
				$t1.record = record;
				this.$selectedrow = $t1;
				if (triggerClicked) {
					this.onRowClicked(this.$selectedrow);
				}
				if (triggerSelected) {
					this.onRowSelected(this.$selectedrow);
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
			add_rowSelected: function(value) {
				this.$4$RowSelectedField = ss.delegateCombine(this.$4$RowSelectedField, value);
			},
			remove_rowSelected: function(value) {
				this.$4$RowSelectedField = ss.delegateRemove(this.$4$RowSelectedField, value);
			},
			add_rowClicked: function(value) {
				this.$4$RowClickedField = ss.delegateCombine(this.$4$RowClickedField, value);
			},
			remove_rowClicked: function(value) {
				this.$4$RowClickedField = ss.delegateRemove(this.$4$RowClickedField, value);
			},
			add_keyDown: function(value) {
				this.$4$KeyDownField = ss.delegateCombine(this.$4$KeyDownField, value);
			},
			remove_keyDown: function(value) {
				this.$4$KeyDownField = ss.delegateRemove(this.$4$KeyDownField, value);
			},
			onRowSelected: function(row) {
				this.$4$RowSelectedField(this, row);
			},
			onRowClicked: function(row) {
				this.$4$RowClickedField(this, row);
			},
			onKeyDown: function(evt) {
				this.$4$KeyDownField(this, evt);
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
			var $t1 = [];
			ss.add($t1, 33);
			ss.add($t1, 34);
			ss.add($t1, 35);
			ss.add($t1, 36);
			ss.add($t1, 38);
			ss.add($t1, 40);
			this.$nvkeys = $t1;
			this.$4$RowSelectedField = function(g, r) {
			};
			this.$4$RowClickedField = function(g, r) {
			};
			this.$4$KeyDownField = function(g, e) {
			};
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
	// Cayita.UI.HtmlList
	var $Cayita_UI_HtmlList = function(parent, ordered) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlList]).call(this);
		this.createElement((ordered ? 'ol' : 'ul'), parent);
	};
	$Cayita_UI_HtmlList.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_HtmlList.$ctor1 = function(parent, element, ordered) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlList]).call(this);
		this.createElement((ordered ? 'ol' : 'ul'), parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlList.$ctor1.prototype = $Cayita_UI_HtmlList.prototype;
	$Cayita_UI_HtmlList.createNav = function(parent, navType) {
		var l = new $Cayita_UI_HtmlList.$ctor1(parent, function(e) {
			e.className = ss.formatString('nav{0}', (ss.isNullOrEmptyString(navType) ? '' : (' ' + navType)));
			$(e).on('click', 'li', function(ev) {
				$('li', e).removeClass('active');
				$(ev.currentTarget).addClass('active');
			});
		}, false);
		return l;
	};
	$Cayita_UI_HtmlList.createNav$1 = function(parent, element, navType) {
		var nl = $Cayita_UI_HtmlList.createNav(parent, navType);
		element(nl.element$1());
		return nl;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.HtmlOption
	var $Cayita_UI_HtmlOption = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlOption]).call(this);
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
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlOption]).call(this);
		this.$init(parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlOption.$ctor1.prototype = $Cayita_UI_HtmlOption.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.HtmlTable
	var $Cayita_UI_HtmlTable = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlTable]).call(this);
	};
	$Cayita_UI_HtmlTable.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_HtmlTable.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlTable]).call(this);
		this.createElement('table', parent);
		element(this.element$1());
	};
	$Cayita_UI_HtmlTable.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlTable]).call(this);
		this.createElement('table', parent);
	};
	$Cayita_UI_HtmlTable.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlTable]).call(this);
		this.createElement('table', null);
		element(this.element$1());
	};
	$Cayita_UI_HtmlTable.$ctor3.prototype = $Cayita_UI_HtmlTable.$ctor2.prototype = $Cayita_UI_HtmlTable.$ctor1.prototype = $Cayita_UI_HtmlTable.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Icon
	var $Cayita_UI_Icon = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Icon]).call(this);
		this.createElement('i', null);
	};
	$Cayita_UI_Icon.prototype = {
		element$1: function() {
			return ss.cast(this.element(), Element);
		}
	};
	$Cayita_UI_Icon.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Icon]).call(this);
		this.createElement('i', null);
		element(this.element$1());
	};
	$Cayita_UI_Icon.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Icon]).call(this);
		this.createElement('i', parent);
		element(this.element$1());
	};
	$Cayita_UI_Icon.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Icon]).call(this);
		this.createElement('i', parent);
	};
	$Cayita_UI_Icon.$ctor1.prototype = $Cayita_UI_Icon.$ctor3.prototype = $Cayita_UI_Icon.$ctor2.prototype = $Cayita_UI_Icon.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.IconAnchor
	var $Cayita_UI_IconAnchor = function(parent, element) {
		$Cayita_UI_Anchor.$ctor2.call(this, parent);
		var i = new $Cayita_UI_Icon.$ctor2(this.element$1());
		element(this.element$1(), i.element$1());
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.IconButton
	var $Cayita_UI_IconButton = function(parent, element) {
		$Cayita_UI_Button.$ctor1.call(this, parent);
		this.element$1().className = 'btn';
		var i = new $Cayita_UI_Icon.$ctor2(this.element$1());
		element(this.element$1(), i.element$1());
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Image
	var $Cayita_UI_Image = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Image]).call(this);
		this.createElement('img', null);
	};
	$Cayita_UI_Image.prototype = {
		element$1: function() {
			return this.element();
		},
		src: function(url) {
			this.element$1().src = url;
			return this;
		}
	};
	$Cayita_UI_Image.$ctor1 = function(image) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Image]).call(this);
		this.createElement('img', null);
		image(this.element$1());
	};
	$Cayita_UI_Image.$ctor2 = function(parent, image) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Image]).call(this);
		this.createElement('img', parent);
		image(this.element$1());
	};
	$Cayita_UI_Image.$ctor1.prototype = $Cayita_UI_Image.$ctor2.prototype = $Cayita_UI_Image.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Input
	var $Cayita_UI_Input = function(parent, type) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_Input]).$ctor1.call(this, parent, type, 'input');
	};
	$Cayita_UI_Input.$ctor1 = function(parent, element, type) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_Input]).$ctor1.call(this, parent, type, 'input');
		element(this.element$1());
	};
	$Cayita_UI_Input.$ctor1.prototype = $Cayita_UI_Input.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputBase
	var $Cayita_UI_InputBase$1 = function(T) {
		var $type = function() {
			ss.makeGenericType($Cayita_UI_ElementBase$1, [T]).call(this);
			this.createInput(null, 'text', 'input');
		};
		$type.prototype = {
			createInput: function(parent, type, tagname) {
				this.createElement(tagname, parent);
				if (!ss.isNullOrEmptyString(type)) {
					this.element$1().type = type;
				}
			},
			type: function(type) {
				this.element$1().type = type;
				return this;
			},
			placeHolder$1: function(placeholder) {
				if (!ss.isNullOrEmptyString(placeholder)) {
					this.element$1().setAttribute('placeholder', placeholder);
				}
				else {
					this.element$1().removeAttribute('placeholder');
				}
				return this;
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
				return this;
			},
			required: function() {
				var rq = this.element$1().getAttribute('required');
				return (ss.isNullOrUndefined(rq) ? false : ((rq.toString() === 'required' || rq.toString() === 'true') ? true : false));
			},
			relativeSize: function(relativeSize) {
				this.addClass(relativeSize);
				return this;
			},
			gridSize: function(gridSize) {
				this.addClass(gridSize);
				return this;
			},
			value$1: function(value) {
				cayita.fn.setValue(this.element$1(), value);
				return this;
			},
			value: function() {
				return cayita.fn.getValue(this.element$1());
			},
			element$1: function() {
				return this.element();
			},
			name$1: function(name) {
				this.element$1().name = name;
				return this;
			},
			name: function() {
				return this.element$1().name;
			}
		};
		$type.$ctor1 = function(parent, type, tagname) {
			ss.makeGenericType($Cayita_UI_ElementBase$1, [T]).call(this);
			this.createInput(parent, type, tagname);
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_InputBase$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_ElementBase$1, [T]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.InputBase$1', $Cayita_UI_InputBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputCheckbox
	var $Cayita_UI_InputCheckbox = function() {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputCheckbox]).call(this);
		this.init(null);
	};
	$Cayita_UI_InputCheckbox.prototype = {
		init: function(parent) {
			this.createInput(parent, 'checkbox', 'input');
			this.element$2().value = 'true';
		},
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputCheckbox.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputCheckbox]).call(this);
		this.init(null);
		element(this.element$2());
		this.element$2();
	};
	$Cayita_UI_InputCheckbox.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputCheckbox]).call(this);
		this.init(parent);
		element(this.element$2());
		this.element$2();
	};
	$Cayita_UI_InputCheckbox.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputCheckbox]).call(this);
		this.init(parent);
	};
	$Cayita_UI_InputCheckbox.$ctor1.prototype = $Cayita_UI_InputCheckbox.$ctor3.prototype = $Cayita_UI_InputCheckbox.$ctor2.prototype = $Cayita_UI_InputCheckbox.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputFile
	var $Cayita_UI_InputFile = function() {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputFile]).call(this);
	};
	$Cayita_UI_InputFile.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputFile.$ctor2 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputFile]).$ctor1.call(this, parent, 'file', 'input');
		element(this.element$2());
	};
	$Cayita_UI_InputFile.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputFile]).$ctor1.call(this, parent, 'file', 'input');
	};
	$Cayita_UI_InputFile.$ctor2.prototype = $Cayita_UI_InputFile.$ctor1.prototype = $Cayita_UI_InputFile.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputHidden
	var $Cayita_UI_InputHidden = function() {
		$Cayita_UI_InputHidden.$ctor1.call(this, null, null);
	};
	$Cayita_UI_InputHidden.$ctor1 = function(parent, name) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputHidden]).$ctor1.call(this, parent, 'text', 'input');
		if (!ss.isNullOrEmptyString(name)) {
			this.element$1().name = name;
		}
	};
	$Cayita_UI_InputHidden.$ctor1.prototype = $Cayita_UI_InputHidden.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputPassword
	var $Cayita_UI_InputPassword = function(parent) {
		$Cayita_UI_InputText.$ctor2.call(this, parent, 'text');
		this.element$2().type = 'password';
	};
	$Cayita_UI_InputPassword.$ctor1 = function(parent, element) {
		$Cayita_UI_InputPassword.call(this, parent);
		element(this.element$2());
	};
	$Cayita_UI_InputPassword.$ctor1.prototype = $Cayita_UI_InputPassword.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputRadio
	var $Cayita_UI_InputRadio = function() {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputRadio]).call(this);
		this.init(null);
	};
	$Cayita_UI_InputRadio.prototype = {
		init: function(parent) {
			this.createInput(parent, 'radio', 'input');
		},
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputRadio.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputRadio]).call(this);
		this.init(null);
		element(this.element$2());
		this.element$2();
	};
	$Cayita_UI_InputRadio.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputRadio]).call(this);
		this.init(parent);
		element(this.element$2());
		this.element$2();
	};
	$Cayita_UI_InputRadio.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputRadio]).call(this);
		this.init(parent);
	};
	$Cayita_UI_InputRadio.$ctor1.prototype = $Cayita_UI_InputRadio.$ctor3.prototype = $Cayita_UI_InputRadio.$ctor2.prototype = $Cayita_UI_InputRadio.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputSelect
	var $Cayita_UI_InputSelect = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_InputSelect]).call(this);
		this.init(null);
	};
	$Cayita_UI_InputSelect.prototype = {
		init: function(parent) {
			this.createElement('select', parent);
		},
		element$1: function() {
			return this.element();
		},
		load: function(T) {
			return function(data, func) {
				$Extensions.load(T).call(null, this.element$1(), data, func, false);
				return this;
			};
		},
		selectItem: function(value) {
			$('option[value=' + value + ']', this.element$1()).attr('selected', true);
			return this;
		}
	};
	$Cayita_UI_InputSelect.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_InputSelect]).call(this);
		this.init(parent);
	};
	$Cayita_UI_InputSelect.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_InputSelect]).call(this);
		this.init(null);
		element(this.element$1());
	};
	$Cayita_UI_InputSelect.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_InputSelect]).call(this);
		this.init(parent);
		element(this.element$1());
	};
	$Cayita_UI_InputSelect.$ctor2.prototype = $Cayita_UI_InputSelect.$ctor1.prototype = $Cayita_UI_InputSelect.$ctor3.prototype = $Cayita_UI_InputSelect.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputText
	var $Cayita_UI_InputText = function() {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputText]).call(this);
	};
	$Cayita_UI_InputText.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputText.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputText]).$ctor1.call(this, parent, 'text', 'input');
		element(this.element$2());
	};
	$Cayita_UI_InputText.$ctor2 = function(parent, type) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputText]).$ctor1.call(this, parent, 'text', 'input');
	};
	$Cayita_UI_InputText.$ctor1.prototype = $Cayita_UI_InputText.$ctor2.prototype = $Cayita_UI_InputText.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.InputTextArea
	var $Cayita_UI_InputTextArea = function() {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputTextArea]).call(this);
	};
	$Cayita_UI_InputTextArea.prototype = {
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_InputTextArea.$ctor2 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputTextArea]).$ctor1.call(this, parent, 'textarea', 'input');
		this.createElement('textarea', parent);
		element(this.element$2());
	};
	$Cayita_UI_InputTextArea.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputTextArea]).call(this);
		this.createElement('textarea', parent);
	};
	$Cayita_UI_InputTextArea.$ctor2.prototype = $Cayita_UI_InputTextArea.$ctor1.prototype = $Cayita_UI_InputTextArea.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Label
	var $Cayita_UI_Label = function(element) {
		$Cayita_UI_Label.$ctor2.call(this, null, element);
	};
	$Cayita_UI_Label.prototype = {
		textLabel$1: function(textLabel) {
			$Extensions.text$1(this.element$1(), textLabel);
			return this;
		},
		textLabel: function() {
			return $Extensions.text(this.element$1());
		},
		for$2: function(fieldId) {
			$(this.element$1()).attr('for', fieldId);
			return this;
		},
		for$1: function() {
			return $(this.element$1()).attr('for');
		},
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Label.$ctor2 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Label]).call(this);
		this.createElement('label', parent);
		element(this.element$1());
	};
	$Cayita_UI_Label.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Label]).call(this);
		this.createElement('label', parent);
	};
	$Cayita_UI_Label.$ctor2.prototype = $Cayita_UI_Label.$ctor1.prototype = $Cayita_UI_Label.prototype;
	$Cayita_UI_Label.createControlLabel = function(parent, textLabel, forField, visible) {
		return new $Cayita_UI_Label.$ctor2(parent, function(lb) {
			$Extensions.text$1(lb, textLabel);
			lb.className = 'control-label';
			if (!ss.isNullOrEmptyString(forField)) {
				$(lb).attr('for', forField);
			}
			if (!visible) {
				$(lb).hide();
			}
		});
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Legend
	var $Cayita_UI_Legend = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Legend]).call(this);
		this.createElement('legend', parent);
	};
	$Cayita_UI_Legend.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Legend]).call(this);
		this.createElement('legend', parent);
		element(this.element());
	};
	$Cayita_UI_Legend.$ctor1.prototype = $Cayita_UI_Legend.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.ListItem
	var $Cayita_UI_ListItem = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_ListItem]).call(this);
		this.$init(parent);
	};
	$Cayita_UI_ListItem.prototype = {
		$init: function(parent) {
			this.createElement('li', parent);
		},
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_ListItem.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_ListItem]).call(this);
		this.$init(parent);
		element(this.element$1());
	};
	$Cayita_UI_ListItem.$ctor1.prototype = $Cayita_UI_ListItem.prototype;
	$Cayita_UI_ListItem.createNavListItem = function(parent, href, item) {
		var il = new $Cayita_UI_ListItem(parent);
		new $Cayita_UI_Anchor.$ctor3(il.element$1(), function(a) {
			a.href = href;
			$Extensions.text$1(a, item);
		});
		return il;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.NavBar
	var $Cayita_UI_NavBar = function(parent, brandText, navlist) {
		$Cayita_UI_NavBar.$ctor1.call(this, parent, brandText, '', '', navlist);
	};
	$Cayita_UI_NavBar.prototype = {
		containerFluid: function() {
			return this.$ctFluid;
		},
		navCollapse: function() {
			return this.$nCollapse;
		},
		brand: function() {
			return this.$bElement;
		},
		pullRightParagraph: function() {
			return this.$pullRP;
		},
		pullRightAnchor: function() {
			return this.$pRA;
		},
		navLinks: function() {
			return this.$nList;
		}
	};
	$Cayita_UI_NavBar.$ctor1 = function(parent, brandText, rightText, rightLinkText, navlist) {
		this.$ctFluid = null;
		this.$nCollapse = null;
		this.$bElement = null;
		this.$pullRP = null;
		this.$pRA = null;
		this.$nList = null;
		$Cayita_UI_Div.$ctor1.call(this, parent);
		this.element$1().className = 'navbar';
		new $Cayita_UI_Div.$ctor2(this.element$1(), ss.mkdel(this, function(inner) {
			inner.className = 'navbar-inner';
			this.$ctFluid = $Cayita_UI_Div.createContainerFluid$1(inner, ss.mkdel(this, function(fluid) {
				new $Cayita_UI_Anchor.$ctor3(fluid, function(anchor) {
					anchor.className = 'btn btn-navbar';
					anchor.setAttribute('data-toggle', 'collapse');
					anchor.setAttribute('data-target', '.nav-collapse');
					for (var i = 0; i < 3; i++) {
						new $Cayita_UI_Span.$ctor2(anchor, function(span) {
							span.className = 'icon-bar';
						});
					}
				});
				this.$bElement = (new $Cayita_UI_Anchor.$ctor3(fluid, function(brnd) {
					brnd.href = '#';
					$Extensions.text$1(brnd, brandText);
					brnd.className = 'brand';
				})).element$1();
				this.$nCollapse = (new $Cayita_UI_Div.$ctor2(fluid, ss.mkdel(this, function(collapse) {
					collapse.className = 'nav-collapse collapse';
					this.$pullRP = (new $Cayita_UI_Paragraph.$ctor3(collapse, ss.mkdel(this, function(paragraph) {
						paragraph.className = 'navbar-text pull-right';
						$Extensions.text$1(paragraph, rightText);
						this.$pRA = (new $Cayita_UI_Anchor.$ctor3(paragraph, function(a) {
							a.href = '#';
							a.className = 'navbar-link';
							$Extensions.text$1(a, rightLinkText);
						})).element$1();
					}))).element$1();
					this.$nList = $Cayita_UI_HtmlList.createNav$1(collapse, navlist, '').element$1();
				}))).element$1();
			})).element$1();
		}));
	};
	$Cayita_UI_NavBar.$ctor1.prototype = $Cayita_UI_NavBar.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.NavList
	var $Cayita_UI_NavList = function(parent, navlist) {
		this.$nav = null;
		$Cayita_UI_Div.$ctor1.call(this, parent);
		this.element$1().className = 'well sidebar-nav';
		this.$nav = $Cayita_UI_HtmlList.createNav$1(this.element$1(), navlist, 'nav-list').element$1();
	};
	$Cayita_UI_NavList.prototype = {
		navLinks: function() {
			return this.$nav;
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Panel
	var $Cayita_UI_Panel = function() {
		this.$pc = null;
		this.$captionElement = null;
		this.$closeIcon = null;
		this.$collapseIcon = null;
		this.$dobject = null;
		this.$robject = null;
		this.$3$ClosedField = function(p) {
		};
		this.$3$CollapsedField = function(p, s) {
		};
		this.$3$ToggledField = function(p, s) {
		};
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Panel]).call(this);
		this.$init($Cayita_UI_PanelConfig.$ctor());
	};
	$Cayita_UI_Panel.prototype = {
		$init: function(config) {
			var self = this;
			this.$pc = config;
			this.setElement(this.$pc.container);
			if (ss.staticEquals(this.$pc.closeIconHandler, null)) {
				this.$pc.closeIconHandler = function(p) {
					p.close();
				};
			}
			if (ss.staticEquals(this.$pc.collapseIconHandler, null)) {
				this.$pc.collapseIconHandler = function(p1, collapsed) {
					p1.collapse();
				};
			}
			this.$closeIcon = new $Cayita_UI_Icon.$ctor3(this.$pc.header, ss.mkdel(this, function(icon) {
				icon.className = this.$pc.closeIconClass;
				$(icon).on('click', ss.mkdel(this, function(evt) {
					evt.preventDefault();
					this.$pc.closeIconHandler(self);
				}));
				if (!this.$pc.closable) {
					$(icon).hide();
				}
			}));
			this.$collapseIcon = new $Cayita_UI_Icon.$ctor3(this.$pc.header, ss.mkdel(this, function(icon1) {
				icon1.className = this.$pc.collapseIconClass;
				$(icon1).on('click', ss.mkdel(this, function(evt1) {
					evt1.preventDefault();
					this.$pc.collapseIconHandler(self, !$(this.$pc.body).is(':visible'));
				}));
				if (!this.$pc.collapsible) {
					$(icon1).hide();
				}
			}));
			this.$captionElement = $StringExtensions.header(this.$pc.caption, 6);
			$(this.$pc.header).append(this.$captionElement);
			$(this.$pc.container).css('left', this.$pc.left).css('top', this.$pc.top);
			$(this.$pc.body).css('width', this.$pc.width).css('height', this.$pc.height);
			$(this.$pc.container).css('z-index', '0');
			this.$initDraggable();
			if (!this.$pc.draggable) {
				this.$dobject.draggable('destroy');
			}
			this.$initResizable();
			if (!this.$pc.resizable) {
				this.$robject.resizable('destroy');
			}
			$(this.$pc.container).click(ss.mkdel(this, function(evt2) {
				var zI = $(this.$pc.container).css('z-index');
				var hZ = parseInt(zI);
				var hE = this.$pc.container;
				$('.c-panel').each(function(index, element) {
					var cZ = parseInt($(element).css('z-index'));
					if (cZ > hZ) {
						hE = element;
						hZ = cZ;
					}
				});
				$(hE).css('z-index', zI);
				$(this.$pc.container).css('z-index', ((hZ > 0) ? hZ.toString() : '1'));
			}));
			if (this.$pc.overlay) {
				$(this.$pc.container).css('position', 'fixed');
			}
		},
		caption: function(text) {
			this.$pc.caption = text;
			$Extensions.text$1(this.$captionElement, text);
			return this;
		},
		render: function(parent) {
			this.appendTo$2(parent);
			return this;
		},
		overlay: function(value) {
			this.$pc.overlay = value;
			if (value) {
				$(this.$pc.container).css('position', 'fixed');
			}
			else {
				$(this.$pc.container).css('position', 'relative');
			}
			return this;
		},
		closable: function(value) {
			this.$pc.closable = value;
			if (value) {
				this.$closeIcon.jQuery().show();
			}
			else {
				this.$closeIcon.jQuery().hide();
			}
			return this;
		},
		collapsible: function(value) {
			this.$pc.collapsible = value;
			if (value) {
				this.$collapseIcon.jQuery().show();
			}
			else {
				this.$collapseIcon.jQuery().hide();
			}
			return this;
		},
		draggable: function(value) {
			this.$pc.draggable = value;
			if (value) {
				this.$initDraggable();
			}
			else {
				this.$dobject.draggable('destroy');
			}
			return this;
		},
		resizable: function(value) {
			this.$pc.resizable = value;
			if (value) {
				this.$initResizable();
			}
			else {
				this.$robject.resizable('destroy');
			}
			return this;
		},
		body: function() {
			return this.$pc.body;
		},
		closedHandler: function(value) {
			this.add_closed(value);
			return this;
		},
		collapsedHandler: function(value) {
			this.add_collapsed(value);
			return this;
		},
		closeIconHandler: function(value) {
			this.$pc.closeIconHandler = value;
			return this;
		},
		collapseIconHandler: function(value) {
			this.$pc.collapseIconHandler = value;
			return this;
		},
		closeIconClass: function(value) {
			this.$pc.closeIconClass = value;
			this.$closeIcon.className$1(value);
			return this;
		},
		collapseIconClass: function(value) {
			this.$pc.collapseIconClass = value;
			if ($(this.$pc.body).is(':visible')) {
				this.$collapseIcon.className$1(value);
			}
			return this;
		},
		expandIconClass: function(value) {
			this.$pc.expandIconClass = value;
			if (!$(this.$pc.body).is(':visible')) {
				this.$collapseIcon.className$1(value);
			}
			return this;
		},
		left: function(value) {
			this.$pc.top = value;
			$(this.$pc.container).css('left', value);
			return this;
		},
		top: function(value) {
			this.$pc.top = value;
			$(this.$pc.container).css('top', value);
			return this;
		},
		width: function(value) {
			this.$pc.width = value;
			$(this.$pc.container).css('width', value);
			return this;
		},
		height: function(value) {
			this.$pc.height = value;
			$(this.$pc.body).css('height', value);
			return this;
		},
		collapse: function() {
			var collapsed = !$(this.$pc.body).is(':visible');
			this.onCollapsed(collapsed);
			$(this.$pc.body).toggle();
			this.$collapseIcon.className$1((!collapsed ? this.$pc.collapseIconClass : this.$pc.expandIconClass));
			return this;
		},
		toggle: function() {
			var visible = $(this.$pc.container).is(':visible');
			this.onToggled(visible);
			$(this.$pc.container).toggle();
			return this;
		},
		close: function() {
			this.onClosed();
			$(this.$pc.container).remove();
		},
		append$7: function(content) {
			$(this.$pc.body).append(content);
			return this;
		},
		append$6: function(content) {
			$(this.$pc.body).append(content);
			return this;
		},
		append$5: function(T) {
			return function(content) {
				$(this.$pc.body).append(content.element());
				return this;
			};
		},
		element$1: function() {
			return this.$pc.container;
		},
		add_closed: function(value) {
			this.$3$ClosedField = ss.delegateCombine(this.$3$ClosedField, value);
		},
		remove_closed: function(value) {
			this.$3$ClosedField = ss.delegateRemove(this.$3$ClosedField, value);
		},
		onClosed: function() {
			this.$3$ClosedField(this);
		},
		add_collapsed: function(value) {
			this.$3$CollapsedField = ss.delegateCombine(this.$3$CollapsedField, value);
		},
		remove_collapsed: function(value) {
			this.$3$CollapsedField = ss.delegateRemove(this.$3$CollapsedField, value);
		},
		onCollapsed: function(collapsed) {
			this.$3$CollapsedField(this, collapsed);
		},
		add_toggled: function(value) {
			this.$3$ToggledField = ss.delegateCombine(this.$3$ToggledField, value);
		},
		remove_toggled: function(value) {
			this.$3$ToggledField = ss.delegateRemove(this.$3$ToggledField, value);
		},
		onToggled: function(toggled) {
			this.$3$ToggledField(this, toggled);
		},
		$initDraggable: function() {
			this.$dobject = $(this.$pc.container).draggable();
			this.$dobject.draggable('option', 'stack', '.c-panel');
			this.$dobject.draggable('option', 'addClasses', false);
			this.$dobject.draggable('option', 'containment', 'parent');
			this.$dobject.draggable('option', 'distance', 10);
			this.$dobject.draggable('option', 'handle', this.$pc.header);
		},
		$initResizable: function() {
			this.$robject = $(this.$pc.body).resizable();
			this.$robject.resizable('option', 'alsoResize', $(this.$pc.container));
		}
	};
	$Cayita_UI_Panel.$ctor2 = function(config) {
		this.$pc = null;
		this.$captionElement = null;
		this.$closeIcon = null;
		this.$collapseIcon = null;
		this.$dobject = null;
		this.$robject = null;
		this.$3$ClosedField = function(p) {
		};
		this.$3$CollapsedField = function(p, s) {
		};
		this.$3$ToggledField = function(p, s) {
		};
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Panel]).call(this);
		var p = $Cayita_UI_PanelConfig.$ctor();
		config(p);
		this.$init(p);
	};
	$Cayita_UI_Panel.$ctor1 = function(config) {
		this.$pc = null;
		this.$captionElement = null;
		this.$closeIcon = null;
		this.$collapseIcon = null;
		this.$dobject = null;
		this.$robject = null;
		this.$3$ClosedField = function(p) {
		};
		this.$3$CollapsedField = function(p, s) {
		};
		this.$3$ToggledField = function(p, s) {
		};
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Panel]).call(this);
		this.$init(config);
	};
	$Cayita_UI_Panel.$ctor2.prototype = $Cayita_UI_Panel.$ctor1.prototype = $Cayita_UI_Panel.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.PanelConfig
	var $Cayita_UI_PanelConfig = function() {
	};
	$Cayita_UI_PanelConfig.createInstance = function() {
		return $Cayita_UI_PanelConfig.$ctor();
	};
	$Cayita_UI_PanelConfig.$ctor = function() {
		var $this = {};
		$this.overlay = false;
		$this.resizable = false;
		$this.draggable = false;
		$this.closable = false;
		$this.collapsible = false;
		$this.left = null;
		$this.top = null;
		$this.width = null;
		$this.height = null;
		$this.caption = null;
		$this.closeIconClass = null;
		$this.collapseIconClass = null;
		$this.expandIconClass = null;
		$this.container = null;
		$this.header = null;
		$this.body = null;
		$this.closeIconHandler = null;
		$this.collapseIconHandler = null;
		$this.closeIconClass = 'icon-remove-circle';
		$this.collapseIconClass = 'icon-circle-arrow-up';
		$this.expandIconClass = 'icon-circle-arrow-down';
		$this.caption = '';
		$this.overlay = false;
		$this.resizable = true;
		$this.draggable = true;
		$this.closable = true;
		$this.collapsible = true;
		$this.left = '';
		$this.top = '';
		$this.width = '';
		$this.height = '';
		$this.container = (new $Cayita_UI_Div.$ctor2(null, function(ct) {
			ct.className = 'c-panel';
			$this.header = (new $Cayita_UI_Div.$ctor2(ct, function(hd) {
				hd.className = 'c-panel-header';
			})).element$1();
			$this.body = (new $Cayita_UI_Div.$ctor2(ct, function(bd) {
				bd.className = 'c-panel-content';
			})).element$1();
		})).element$1();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Paragraph
	var $Cayita_UI_Paragraph = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Paragraph]).call(this);
		this.createElement('p', null);
	};
	$Cayita_UI_Paragraph.prototype = {
		element$1: function() {
			return this.element();
		},
		logInfo: function(delay) {
			Alertify.log.info(this.element$1().outerHTML, delay);
		},
		logSuccess: function(delay) {
			Alertify.log.info(this.element$1().outerHTML, delay);
		},
		logError: function(delay) {
			Alertify.log.error(this.element$1().outerHTML, delay);
		}
	};
	$Cayita_UI_Paragraph.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Paragraph]).call(this);
		this.createElement('p', null);
		element(this.element$1());
	};
	$Cayita_UI_Paragraph.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Paragraph]).call(this);
		this.createElement('p', parent);
		element(this.element$1());
	};
	$Cayita_UI_Paragraph.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Paragraph]).call(this);
		this.createElement('p', parent);
	};
	$Cayita_UI_Paragraph.$ctor1.prototype = $Cayita_UI_Paragraph.$ctor3.prototype = $Cayita_UI_Paragraph.$ctor2.prototype = $Cayita_UI_Paragraph.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.RadioGroup
	var $Cayita_UI_RadioGroup = function() {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_RadioGroup, $Cayita_UI_InputRadio]).call(this, 'radio', null, null, null, null, true);
	};
	$Cayita_UI_RadioGroup.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_RadioGroup, $Cayita_UI_InputRadio]).call(this, 'radio', parent, null, null, null, true);
	};
	$Cayita_UI_RadioGroup.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_RadioGroup, $Cayita_UI_InputRadio]).call(this, 'radio', parent.element(), null, null, null, true);
	};
	$Cayita_UI_RadioGroup.$ctor3 = function(parent, text, fieldName, items, inline) {
		ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_RadioGroup, $Cayita_UI_InputRadio]).call(this, 'radio', parent, text, fieldName, items, inline);
	};
	$Cayita_UI_RadioGroup.$ctor2.prototype = $Cayita_UI_RadioGroup.$ctor1.prototype = $Cayita_UI_RadioGroup.$ctor3.prototype = $Cayita_UI_RadioGroup.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.RequestMessage
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
	// Cayita.UI.ResetButton
	var $Cayita_UI_ResetButton = function(parent) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_ResetButton]).call(this);
		this.createButton(parent, 'reset');
	};
	$Cayita_UI_ResetButton.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_ResetButton]).call(this);
		this.createButton(parent, 'reset');
		element(this.element$1());
	};
	$Cayita_UI_ResetButton.$ctor1.prototype = $Cayita_UI_ResetButton.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.SearchBox
	var $Cayita_UI_SearchBox$1 = function(T) {
		var $type = function(store, config, columns) {
			$type.$ctor1.call(this, null, store, config, columns);
		};
		$type.prototype = {
			$reset: function(all) {
				if (all) {
					this.$te.value = '';
					this.$he.value = '';
				}
				if (!ss.isNullOrEmptyString(this.$searchText)) {
					this.$searchText = null;
					this.$searchIndex = null;
					this.onRowSelected(null);
				}
			},
			$init: function(store, config, columns) {
				this.$cfg = config;
				if (ss.isNullOrEmptyString(this.$cfg.indexField)) {
					this.$cfg.indexField = store.getRecordIdProperty();
				}
				this.$main = this.element$1();
				this.$he = (new $Cayita_UI_Input.$ctor1(this.$main, ss.mkdel(this, function(e) {
					$(e).hide();
					e.name = this.$cfg.name;
					if (this.$cfg.required) {
						$(e).attr('required', true);
					}
				}), 'text')).element$1();
				this.$te = (new $Cayita_UI_InputText.$ctor1(this.$main, ss.mkdel(this, function(e1) {
					e1.className = 'search-query';
					$(e1).attr('placeholder', this.$cfg.placeHolder);
					$(e1).keyup(ss.mkdel(this, function(evt) {
						var k = evt.which;
						//down enter numpad_enter
						if (k === 40 || k === 13 || k === 108) {
							if (!$(this.$body).is(':visible')) {
								$(this.$body).show();
							}
							this.$gr.jQuery().focus();
							return;
						}
						// esc
						if (k === 27) {
							this.$he.value = this.$searchIndex;
							this.$te.value = this.$searchText;
							if ($(this.$body).is(':visible')) {
								$(this.$body).hide();
							}
							return;
						}
						// end home left 
						//numpad_add numpad_decimal numpad_divid numpad_multiply numpad_substract
						// page_down page_up right up tab
						if (k === 35 || k === 36 || k === 37 || k === 107 || k === 110 || k === 11 || k === 106 || k === 109 || k === 34 || k === 33 || k === 39 || k === 38 || k === 9) {
							return;
						}
						if (!this.$cfg.searchButton || !ss.staticEquals(this.$cfg.localFilter, null)) {
							var b = ss.mkdel(this, function() {
								this.$search(store);
								if (!$(this.$body).is(':visible')) {
									$(this.$body).show();
								}
							});
							cayita.fn.delay(b, this.$cfg.delay);
						}
					}));
				}))).element$2();
				//search button
				new $Cayita_UI_IconButton(this.$main, ss.mkdel(this, function(b1, ibn) {
					if (!this.$cfg.searchButton) {
						$(b1).hide();
					}
					ibn.className = this.$cfg.searchIconClassName;
					$(b1).on('click', ss.mkdel(this, function(e2) {
						this.$search(store);
						$(this.$body).toggle();
						if ($(this.$body).is(':visible')) {
							this.$gr.jQuery().focus();
						}
					}));
				}));
				// reset button
				new $Cayita_UI_IconButton(this.$main, ss.mkdel(this, function(b2, ibn1) {
					if (!this.$cfg.resetButton) {
						$(b2).hide();
					}
					ibn1.className = this.$cfg.resetIconClassName;
					$(b2).on('click', ss.mkdel(this, function(e3) {
						this.$reset(true);
					}));
				}));
				this.$body = (new $Cayita_UI_Div.$ctor2(this.$main, function(e4) {
					$(e4).hide();
					e4.className = 'c-search-body';
				})).element$1();
				if (ss.isNullOrUndefined(columns)) {
					columns = [];
					ss.add(columns, ss.makeGenericType($Cayita_UI_TableColumn$1, [T]).$ctor1(this.$cfg.textField, null, null, false));
				}
				this.$gr = new (ss.makeGenericType($Cayita_UI_HtmlGrid$1, [T]).$ctor1)(this.$body, store, columns);
				if (this.$cfg.paged) {
					new (ss.makeGenericType($Cayita_UI_StorePaging$1, [T]))(this.$body, store);
				}
				this.$gr.add_rowClicked(ss.mkdel(this, function(g, sr) {
					this.$readSelectedRow(sr);
				}));
				this.$gr.add_keyDown(ss.mkdel(this, function(g1, evt1) {
					var k1 = evt1.which;
					if (k1 === 27) {
						$(this.$body).hide();
						return;
					}
					if (k1 === 13 || k1 === 107) {
						var sr1 = g1.getSelectedRow();
						this.$readSelectedRow(sr1);
						return;
					}
				}));
				if (!ss.staticEquals(this.$cfg.rowSelectedHandler, null)) {
					this.add_rowSelected(this.$cfg.rowSelectedHandler);
				}
			},
			$readSelectedRow: function(sr) {
				if (ss.isNullOrUndefined(sr)) {
					return;
				}
				cayita.fn.setValue(this.$he, $SystemExtensions.get(sr.record, this.$cfg.indexField));
				cayita.fn.setValue(this.$te, $SystemExtensions.get(sr.record, this.$cfg.textField));
				this.$searchText = this.$te.value;
				this.$searchIndex = this.$he.value;
				$(this.$body).hide();
				this.onRowSelected(sr);
			},
			$search: function(store) {
				if (!ss.referenceEquals(this.$te.value, this.$searchText)) {
					var st = this.$te.value;
					if (ss.staticEquals(this.$cfg.localFilter, null)) {
						if (st.length < this.$cfg.minLength) {
							return;
						}
						store.read(ss.mkdel(this, function(opt) {
							opt.queryParams[this.$cfg.textField] = st;
						}), true);
					}
					else {
						store.filter(ss.mkdel(this, function(t) {
							return this.$cfg.localFilter(t, st);
						}));
					}
					this.$reset(false);
				}
			},
			$delay: function() {
				var timer = 0;
				return function(callback, delay) {
					window.clearTimeout(timer);
					timer = window.setTimeout(callback, delay);
				};
			},
			add_rowSelected: function(value) {
				this.$4$RowSelectedField = ss.delegateCombine(this.$4$RowSelectedField, value);
			},
			remove_rowSelected: function(value) {
				this.$4$RowSelectedField = ss.delegateRemove(this.$4$RowSelectedField, value);
			},
			onRowSelected: function(row) {
				this.$4$RowSelectedField(this, row);
			}
		};
		$type.$ctor1 = function(parent, store, config, columns) {
			this.$cfg = null;
			this.$te = null;
			this.$he = null;
			this.$main = null;
			this.$body = null;
			this.$gr = null;
			this.$searchText = null;
			this.$searchIndex = null;
			this.$4$RowSelectedField = function(s, r) {
			};
			$Cayita_UI_Div.$ctor1.call(this, parent);
			this.$init(store, config, columns);
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_SearchBox$1, [T], function() {
			return $Cayita_UI_Div;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SearchBox$1', $Cayita_UI_SearchBox$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.SearchBoxConfig
	var $Cayita_UI_SearchBoxConfig$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = {};
			$this.indexField = null;
			$this.textField = null;
			$this.name = null;
			$this.required = false;
			$this.paged = false;
			$this.localFilter = null;
			$this.searchButton = false;
			$this.resetButton = false;
			$this.delay = 0;
			$this.minLength = 0;
			$this.searchIconClassName = null;
			$this.resetIconClassName = null;
			$this.rowSelectedHandler = null;
			$this.placeHolder = null;
			$this.indexField = 'Id';
			$this.name = '';
			$this.paged = true;
			$this.delay = 400;
			$this.searchIconClassName = 'icon-search';
			$this.resetIconClassName = 'icon-remove';
			$this.minLength = 4;
			return $this;
		};
		ss.registerGenericClassInstance($type, $Cayita_UI_SearchBoxConfig$1, [T], function() {
			return null;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SearchBoxConfig$1', $Cayita_UI_SearchBoxConfig$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.SelectedOption
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
	// Cayita.UI.SelectedRow
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
	// Cayita.UI.SelectedRow
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
	// Cayita.UI.SelectField
	var $Cayita_UI_SelectField = function(field) {
		ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]).$ctor2.call(this, null, field);
	};
	$Cayita_UI_SelectField.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]).$ctor4.call(this, parent, 'select-one');
	};
	$Cayita_UI_SelectField.$ctor3 = function(parent, field) {
		ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]).$ctor2.call(this, parent, field);
	};
	$Cayita_UI_SelectField.$ctor1 = function(field) {
		ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]).$ctor3.call(this, null, field);
	};
	$Cayita_UI_SelectField.$ctor4 = function(parent, field) {
		ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]).$ctor3.call(this, parent, field);
	};
	$Cayita_UI_SelectField.$ctor5 = function(parent, label, fieldname) {
		ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]).$ctor5.call(this, parent, label, fieldname);
	};
	$Cayita_UI_SelectField.$ctor2.prototype = $Cayita_UI_SelectField.$ctor3.prototype = $Cayita_UI_SelectField.$ctor1.prototype = $Cayita_UI_SelectField.$ctor4.prototype = $Cayita_UI_SelectField.$ctor5.prototype = $Cayita_UI_SelectField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.SelectField
	var $Cayita_UI_SelectField$1 = function(T) {
		var $type = function(parent, field, store, optionFunc, defaultOption) {
			this.$optionFunc = null;
			this.$store = null;
			this.$se = null;
			this.$selectedoption = null;
			this.$defaultoption = null;
			this.$6$OptionSelectedField = function(sf, opt) {
			};
			ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$type]).$ctor3.call(this, parent, field);
			this.$init(store, optionFunc, defaultOption);
		};
		$type.prototype = {
			$init: function(store, optionFunc, defaultOption) {
				this.$store = store;
				this.$optionFunc = optionFunc;
				this.$se = this.get_input();
				this.$defaultoption = defaultOption || ss.makeGenericType($Cayita_UI_SelectedOption$1, [T]).$ctor();
				$(this.$se).on('change', ss.mkdel(this, function(evt) {
					var option = $(this.$se).find('option:selected')[0];
					this.$selectedOptionImp(option, true);
				}));
				this.render();
				store.add_storeChanged(ss.mkdel(this, function(st, dt) {
					switch (dt.action) {
						case 0: {
							$Extensions.createOption(T).call(null, this.$se, dt.newData, optionFunc);
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
							$Extensions.updateOption(T).call(null, this.$se, dt.newData, optionFunc, store.getRecordIdProperty());
							break;
						}
						case 3: {
							$Extensions.removeOption(T).call(null, this.$se, dt.oldData, store.getRecordIdProperty());
							this.selectOption();
							break;
						}
						case 4: {
							$Extensions.updateOption(T).call(null, this.$se, dt.newData, optionFunc, store.getRecordIdProperty());
							break;
						}
						case 5: {
							$Extensions.createOption(T).call(null, this.$se, dt.newData, optionFunc);
							break;
						}
						case 7: {
							$Extensions.updateOption(T).call(null, this.$se, dt.newData, optionFunc, store.getRecordIdProperty());
							break;
						}
						case 6: {
							$Extensions.createOption(T).call(null, this.$se, dt.newData, optionFunc);
							break;
						}
						case 8: {
							$Extensions.removeOption(T).call(null, this.$se, dt.oldData, store.getRecordIdProperty());
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
					$Extensions.createOption(T).call(null, this.$se, this.$defaultoption.record, ss.mkdel(this, function(f) {
						return this.$defaultoption.option;
					}));
				}
				$Extensions.load(T).call(null, this.$se, this.$store, this.$optionFunc, append);
				if (!ss.isNullOrEmptyString(this.$defaultoption.option.value)) {
					var $t1 = this.$se;
					$('option[value=' + this.$defaultoption.option.value + ']', $t1).attr('selected', true);
				}
			},
			getSelectedOption: function() {
				return this.$selectedoption;
			},
			add_optionSelected: function(value) {
				this.$6$OptionSelectedField = ss.delegateCombine(this.$6$OptionSelectedField, value);
			},
			remove_optionSelected: function(value) {
				this.$6$OptionSelectedField = ss.delegateRemove(this.$6$OptionSelectedField, value);
			},
			onOptionSelected: function(option) {
				this.$6$OptionSelectedField(this, option);
			},
			selectOption$1: function(value, trigger) {
				var option = $('option[value=' + value + ']', this.$se).attr('selected', true)[0];
				this.$selectedOptionImp(option, true);
			},
			selectOption: function() {
				$('option:selected', this.$se).prop('selected', false);
				this.$selectedoption = null;
				this.onOptionSelected(this.$selectedoption);
			},
			$selectedOptionImp: function(option, trigger) {
				var recordId = option.value;
				if (!ss.isNullOrEmptyString(recordId)) {
					var self = this;
					var record = Enumerable.from(this.$store).first(function(f) {
						return ss.referenceEquals($SystemExtensions.get(f, self.$store.getRecordIdProperty()).toString(), option.value);
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
					this.onOptionSelected(this.$selectedoption);
				}
			}
		};
		$type.$ctor1 = function(parent, element, store, optionFunc, defaultOption) {
			this.$optionFunc = null;
			this.$store = null;
			this.$se = null;
			this.$selectedoption = null;
			this.$defaultoption = null;
			this.$6$OptionSelectedField = function(sf, opt) {
			};
			ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$type]).$ctor2.call(this, parent, element);
			this.$init(store, optionFunc, defaultOption);
		};
		$type.$ctor1.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_SelectField$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$type]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SelectField$1', $Cayita_UI_SelectField$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.SelectFieldBase
	var $Cayita_UI_SelectFieldBase$1 = function(T) {
		var $type = function(field) {
			$type.$ctor2.call(this, null, field);
		};
		$type.prototype = {
			get_input: function() {
				return this.$5$InputField;
			},
			set_input: function(value) {
				this.$5$InputField = value;
			},
			element$2: function() {
				return this.element$1();
			}
		};
		$type.$ctor4 = function(parent, type) {
			this.$5$InputField = null;
			ss.makeGenericType($Cayita_UI_Field$1, [T]).call(this, parent, type, true, 'select');
			this.set_input(this.element$2());
		};
		$type.$ctor2 = function(parent, field) {
			$type.$ctor4.call(this, parent, 'select-one');
			field(this.get_controlLabel().element$1(), this.element$2());
			this.get_controlLabel().for$2(this.element$2().id);
			if (ss.isNullOrEmptyString(this.get_controlLabel().textLabel())) {
				this.get_controlLabel().hide();
			}
		};
		$type.$ctor1 = function(field) {
			$type.$ctor3.call(this, null, field);
		};
		$type.$ctor3 = function(parent, field) {
			$type.$ctor4.call(this, parent, 'select-one');
			field(this.element$2());
			this.get_controlLabel().for$2(this.element$2().id).hide();
		};
		$type.$ctor5 = function(parent, label, fieldname) {
			$type.$ctor4.call(this, parent, 'select-one');
			this.get_controlLabel().text$1(label);
			this.name$1(fieldname);
		};
		$type.$ctor4.prototype = $type.$ctor2.prototype = $type.$ctor1.prototype = $type.$ctor3.prototype = $type.$ctor5.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_SelectFieldBase$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_Field$1, [T]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.SelectFieldBase$1', $Cayita_UI_SelectFieldBase$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Span
	var $Cayita_UI_Span = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Span]).call(this);
		this.createElement('span', null);
	};
	$Cayita_UI_Span.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_Span.$ctor2 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Span]).call(this);
		this.createElement('span', parent);
		element(this.element$1());
	};
	$Cayita_UI_Span.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Span]).call(this);
		this.createElement('span', parent);
	};
	$Cayita_UI_Span.$ctor2.prototype = $Cayita_UI_Span.$ctor1.prototype = $Cayita_UI_Span.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.SpinnerIcon
	var $Cayita_UI_SpinnerIcon = function(config, message) {
		$Cayita_UI_SpinnerIcon.$ctor1.call(this, null, config, message);
	};
	$Cayita_UI_SpinnerIcon.prototype = {
		element$2: function() {
			return this.element$1();
		},
		icon: function() {
			return this.$ic;
		}
	};
	$Cayita_UI_SpinnerIcon.$ctor1 = function(parent, config, message) {
		this.$ic = null;
		$Cayita_UI_Div.$ctor1.call(this, parent);
		this.element$2().className = 'well well-large lead';
		this.$ic = (new $Cayita_UI_Icon.$ctor3(this.element$2(), function(i) {
			i.className = 'icon-spinner icon-spin icon-2x pull-left';
		})).element$1();
		config(this.element$2(), this.$ic);
		$(this.element$2()).append(message);
	};
	$Cayita_UI_SpinnerIcon.$ctor1.prototype = $Cayita_UI_SpinnerIcon.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.StorePaging
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
			$Cayita_UI_Div.$ctor1.call(this, parent);
			this.$store_ = store;
			this.$element = this.element$1();
			this.$divnav = new $Cayita_UI_Div.$ctor2(this.$element, ss.mkdel(this, function(d) {
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
						this.$store_.readPreviousPage(true);
					}));
					$(b1).addClass('btn-small');
					i1.className = 'icon-angle-left';
				}))).element$1();
				this.$next = (new $Cayita_UI_IconButton(d, ss.mkdel(this, function(b2, i2) {
					b2.disabled = true;
					$(b2).on('click', ss.mkdel(this, function(evt2) {
						this.$store_.readNextPage(true);
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
			new $Cayita_UI_Div.$ctor2(this.$element, ss.mkdel(this, function(d1) {
				d1.className = 'btn-group form-inline label';
				this.$page = (new $Cayita_UI_Label.$ctor2(d1, ss.mkdel(this, function(l) {
					l.className = 'checkbox';
					l.style.paddingRight = '2px';
					$Extensions.text$1(l, this.$pText);
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
				}), 'text')).element$1();
				this.$totalPages = (new $Cayita_UI_Label.$ctor2(d1, ss.mkdel(this, function(l1) {
					l1.className = 'checkbox';
					l1.style.paddingLeft = '2px';
					$Extensions.text$1(l1, this.$ofText + ' {0}');
					l1.style.fontSize = '98%';
				}))).element$1();
			}));
			new $Cayita_UI_Div.$ctor2(this.$element, ss.mkdel(this, function(d2) {
				d2.className = 'btn-group form-inline label';
				this.$info = (new $Cayita_UI_Label.$ctor2(d2, ss.mkdel(this, function(l2) {
					l2.className = 'checkbox';
					l2.style.paddingRight = '2px';
					$Extensions.text$1(l2, this.$infoTmpl);
					l2.style.fontSize = '98%';
				}))).element$1();
			}));
			store.add_storeChanged(ss.mkdel(this, function(st, dt) {
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
				var lo = this.$store_.getLastOption();
				var pageNumber = (ss.isValue(lo.pageNumber) ? ss.Nullable.unbox(lo.pageNumber) : 0);
				var pageSize = (ss.isValue(lo.pageSize) ? ss.Nullable.unbox(lo.pageSize) : this.$store_.getTotalCount());
				var from_ = pageNumber * pageSize + 1;
				var to_ = pageNumber * pageSize + pageSize;
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
				$Extensions.text$1(this.$page, this.$pText);
				cayita.fn.setValue(this.$currentPage, ((pageNumber < pagesCount) ? (pageNumber + 1) : pagesCount));
				$Extensions.text$1(this.$totalPages, this.$ofText + ' ' + pagesCount);
				$Extensions.text$1(this.$info, ss.formatString(this.$infoTmpl, from_, to_, this.$store_.getTotalCount()));
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
	// Cayita.UI.SubmitButton
	var $Cayita_UI_SubmitButton = function(parent) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_SubmitButton]).call(this);
		this.createButton(parent, 'submit');
	};
	$Cayita_UI_SubmitButton.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_SubmitButton]).call(this);
		this.createButton(parent, 'submit');
		element(this.element$1());
	};
	$Cayita_UI_SubmitButton.$ctor1.prototype = $Cayita_UI_SubmitButton.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.Tab
	var $Cayita_UI_Tab = function() {
	};
	$Cayita_UI_Tab.createInstance = function() {
		return $Cayita_UI_Tab.$ctor();
	};
	$Cayita_UI_Tab.$ctor = function() {
		var $this = {};
		$this.title = null;
		$this.name = null;
		$this.body = null;
		$this.title = '';
		$this.name = '';
		$this.body = (new $Cayita_UI_Div.$ctor1(null)).className$1('tab-pane');
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TableBody
	var $Cayita_UI_TableBody = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableBody]).call(this);
		this.createElement('tbody', parent);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TableCell
	var $Cayita_UI_TableCell = function() {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableCell]).call(this);
		this.createElement('td', null);
	};
	$Cayita_UI_TableCell.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TableCell.$ctor3 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableCell]).call(this);
		this.createElement('td', parent);
		element(this.element$1());
	};
	$Cayita_UI_TableCell.$ctor2 = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableCell]).call(this);
		this.createElement('td', parent);
	};
	$Cayita_UI_TableCell.$ctor1 = function(element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableCell]).call(this);
		this.createElement('td', null);
		element(this.element$1());
	};
	$Cayita_UI_TableCell.$ctor3.prototype = $Cayita_UI_TableCell.$ctor2.prototype = $Cayita_UI_TableCell.$ctor1.prototype = $Cayita_UI_TableCell.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TableColumn
	var $Cayita_UI_TableColumn$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.buildColumns = function(autoHeader) {
			var cols = [];
			var o = ss.createInstance(T);
			var props = cayita.fn.getProperties(o);
			for (var $t1 = 0; $t1 < props.length; $t1++) {
				var p = props[$t1];
				ss.add(cols, $type.$ctor1(p, null, null, autoHeader));
			}
			return cols;
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
		$type.$ctor1 = function(index, header, val, autoHeader) {
			var $this = {};
			$this.header = null;
			$this.value = null;
			$this.footer = null;
			$this.hidden = false;
			$this.afterCellCreate = null;
			if (ss.isNullOrEmptyString(header) && autoHeader) {
				header = index;
			}
			if (!ss.isNullOrEmptyString(header)) {
				$this.header = (new $Cayita_UI_TableCell.$ctor1(function(c) {
					$Extensions.text$1(c, header);
				})).element$1();
			}
			if (ss.staticEquals(val, null)) {
				val = function(t, c1) {
					$(c1).text($SystemExtensions.get(t, index));
				};
			}
			$this.value = function(t1) {
				var cell = (new $Cayita_UI_TableCell()).element$1();
				val(t1, cell);
				return cell;
			};
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
	// Cayita.UI.TableFooter
	var $Cayita_UI_TableFooter = function(parent) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('tfoot', parent);
	};
	$Cayita_UI_TableFooter.$ctor1 = function(parent, element) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('tfoot', parent);
		element(this.element$1());
	};
	$Cayita_UI_TableFooter.$ctor1.prototype = $Cayita_UI_TableFooter.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TableHeader
	var $Cayita_UI_TableHeader = function(parent) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('thead', parent);
	};
	$Cayita_UI_TableHeader.$ctor1 = function(parent, element) {
		$Cayita_UI_HtmlTable.call(this);
		this.createElement('thead', parent);
		element(this.element$1());
	};
	$Cayita_UI_TableHeader.$ctor1.prototype = $Cayita_UI_TableHeader.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TableRow
	var $Cayita_UI_TableRow = function(parent) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableRow]).call(this);
		this.createElement('tr', parent);
	};
	$Cayita_UI_TableRow.prototype = {
		element$1: function() {
			return this.element();
		}
	};
	$Cayita_UI_TableRow.$ctor1 = function(parent, element) {
		ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableRow]).call(this);
		this.createElement('tr', parent);
		element(this.element$1());
	};
	$Cayita_UI_TableRow.$ctor1.prototype = $Cayita_UI_TableRow.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TabPanel
	var $Cayita_UI_TabPanel = function(parent) {
		this.$cfg = null;
		this.$tabs = [];
		this.$4$TabShownField = function(p, ac, pr) {
		};
		this.$4$TabShowField = function(p, ac, pr) {
		};
		this.$4$TabClickedField = null;
		$Cayita_UI_Div.$ctor1.call(this, parent);
		this.$init($Cayita_UI_TabPanelConfig.$ctor());
	};
	$Cayita_UI_TabPanel.prototype = {
		$init: function(config) {
			var el = this.element$1();
			el.className = ss.formatString('tabbable{0}{1}', (config.bordered ? ' tabbable-bordered' : ''), ' tabs-' + config.tabsPosition);
			if (config.tabsPosition !== 'below') {
				$(el).append(config.links).append(config.content);
			}
			else {
				$(el).append(config.content).append(config.links);
			}
			this.$cfg = config;
			this.jQuery$1('a[data-toggle=\'tab\']').on('shown', ss.mkdel(this, function(evt) {
				this.onTabShown(this.$getTab(evt.target), this.$getTab(evt.relatedTarget));
			}));
			this.jQuery$1('a[data-toggle=\'tab\']').on('show', ss.mkdel(this, function(evt1) {
				this.onTabShow(this.$getTab(evt1.target), this.$getTab(evt1.relatedTarget));
			}));
			this.jQuery$1('a[data-toggle=\'tab\']').on('Click', ss.mkdel(this, function(evt2) {
				if (!ss.staticEquals(this.$4$TabClickedField, null)) {
					evt2.preventDefault();
					this.$4$TabClickedField(this, this.$getTab(evt2.target));
				}
			}));
		},
		$getTab: function(anchor) {
			return (ss.isValue(anchor) ? Enumerable.from(this.$tabs).first(function(f) {
				return ss.referenceEquals('#' + f.body.get_id(), anchor.href);
			}) : null);
		},
		addTab$1: function(title) {
			var $t1 = $Cayita_UI_Tab.$ctor();
			$t1.title = title;
			this.addTab($t1);
		},
		addTab: function(tab) {
			ss.add(this.$tabs, tab);
			$Extensions.addItem$1(this.$cfg.links, function(i, a) {
				a.href = '#' + tab.body.get_id();
				a.setAttribute('data-toggle', 'tab');
				$Extensions.text$1(a, tab.title);
			});
			$(this.$cfg.content).append(tab.body.element());
		},
		addTab$2: function(tab, anchor) {
			var t = $Cayita_UI_Tab.$ctor();
			tab(t);
			ss.add(this.$tabs, t);
			$Extensions.addItem$1(this.$cfg.links, function(i, a) {
				a.href = '#' + t.body.get_id();
				a.setAttribute('data-toggle', 'tab');
				if (!ss.staticEquals(anchor, null)) {
					anchor(a);
				}
				else {
					$Extensions.text$1(a, t.title);
				}
			});
			$(this.$cfg.content).append(t.body.element());
		},
		getTab: function(index) {
			return $Cayita_UI_Tab.$ctor();
		},
		show$2: function(index) {
			var t = this.$tabs[index];
			var jq = $(this.$cfg.links);
			console.log('jq ', jq);
			var $t1 = this.$cfg.links;
			var jq2 = $('a[href=\'#' + t.body.get_id() + '\']', $t1);
			console.log('jq2 ', jq2);
			console.log('t.Body.ID ', t.body.get_id());
			var $t2 = this.$cfg.links;
			$('a[href=\'#' + t.body.get_id() + '\']', $t2).tab('show');
		},
		show$1: function(tab) {
			var $t1 = this.$cfg.links;
			$('a[href=\'#' + tab.body.get_id() + '\']', $t1).tab('show');
		},
		add_tabShown: function(value) {
			this.$4$TabShownField = ss.delegateCombine(this.$4$TabShownField, value);
		},
		remove_tabShown: function(value) {
			this.$4$TabShownField = ss.delegateRemove(this.$4$TabShownField, value);
		},
		onTabShown: function(active, previous) {
			this.$4$TabShownField(this, active, previous);
		},
		add_tabShow: function(value) {
			this.$4$TabShowField = ss.delegateCombine(this.$4$TabShowField, value);
		},
		remove_tabShow: function(value) {
			this.$4$TabShowField = ss.delegateRemove(this.$4$TabShowField, value);
		},
		onTabShow: function(active, previous) {
			this.$4$TabShowField(this, active, previous);
		},
		add_tabClicked: function(value) {
			this.$4$TabClickedField = ss.delegateCombine(this.$4$TabClickedField, value);
		},
		remove_tabClicked: function(value) {
			this.$4$TabClickedField = ss.delegateRemove(this.$4$TabClickedField, value);
		},
		onTabClicked: function(tab) {
			if (!ss.staticEquals(this.$4$TabClickedField, null)) {
				this.$4$TabClickedField(this, tab);
			}
		}
	};
	$Cayita_UI_TabPanel.$ctor2 = function(parent, config) {
		this.$cfg = null;
		this.$tabs = [];
		this.$4$TabShownField = function(p, ac, pr) {
		};
		this.$4$TabShowField = function(p, ac, pr) {
		};
		this.$4$TabClickedField = null;
		$Cayita_UI_Div.$ctor1.call(this, parent);
		var c = $Cayita_UI_TabPanelConfig.$ctor();
		config(c);
		this.$init(c);
	};
	$Cayita_UI_TabPanel.$ctor1 = function(parent, config) {
		this.$cfg = null;
		this.$tabs = [];
		this.$4$TabShownField = function(p, ac, pr) {
		};
		this.$4$TabShowField = function(p, ac, pr) {
		};
		this.$4$TabClickedField = null;
		$Cayita_UI_Div.$ctor1.call(this, parent);
		this.$init(config);
	};
	$Cayita_UI_TabPanel.$ctor2.prototype = $Cayita_UI_TabPanel.$ctor1.prototype = $Cayita_UI_TabPanel.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TabPanelConfig
	var $Cayita_UI_TabPanelConfig = function() {
	};
	$Cayita_UI_TabPanelConfig.createInstance = function() {
		return $Cayita_UI_TabPanelConfig.$ctor();
	};
	$Cayita_UI_TabPanelConfig.$ctor = function() {
		var $this = {};
		$this.bordered = false;
		$this.tabsPosition = null;
		$this.navType = null;
		$this.stacked = false;
		$this.links = null;
		$this.content = null;
		$this.bordered = false;
		$this.tabsPosition = 'top';
		$this.navType = 'tabs';
		new $Cayita_UI_HtmlList.$ctor1(null, function(l) {
			l.className = ss.formatString('nav nav-{0}{1}', $this.navType, ($this.stacked ? ' nav-stacked' : ''));
			$this.links = l;
		}, false);
		new $Cayita_UI_Div.$ctor2(null, function(d) {
			d.className = 'tab-content';
			$this.content = d;
		});
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TextAreaField
	var $Cayita_UI_TextAreaField = function(field) {
		$Cayita_UI_TextAreaField.$ctor3.call(this, null, field);
	};
	$Cayita_UI_TextAreaField.prototype = {
		get_input: function() {
			return this.$5$InputField;
		},
		set_input: function(value) {
			this.$5$InputField = value;
		},
		element$2: function() {
			return this.element$1();
		}
	};
	$Cayita_UI_TextAreaField.$ctor2 = function(parent) {
		this.$5$InputField = null;
		ss.makeGenericType($Cayita_UI_Field$1, [$Cayita_UI_TextAreaField]).call(this, parent, null, true, 'textarea');
		this.set_input(this.element$2());
	};
	$Cayita_UI_TextAreaField.$ctor3 = function(parent, field) {
		$Cayita_UI_TextAreaField.$ctor2.call(this, parent);
		field(this.get_controlLabel().element$1(), this.element$2());
		this.get_controlLabel().for$2(this.element$2().id);
		if (ss.isNullOrEmptyString(this.get_controlLabel().textLabel())) {
			this.get_controlLabel().hide();
		}
	};
	$Cayita_UI_TextAreaField.$ctor1 = function(field) {
		$Cayita_UI_TextAreaField.$ctor4.call(this, null, field);
	};
	$Cayita_UI_TextAreaField.$ctor4 = function(parent, field) {
		$Cayita_UI_TextAreaField.$ctor2.call(this, parent);
		field(this.element$2());
		this.get_controlLabel().for$2(this.element$2().id).hide();
	};
	$Cayita_UI_TextAreaField.$ctor5 = function(parent, label, fieldname) {
		$Cayita_UI_TextAreaField.$ctor2.call(this, parent);
		this.get_controlLabel().text$1(label);
		this.name$1(fieldname);
	};
	$Cayita_UI_TextAreaField.$ctor2.prototype = $Cayita_UI_TextAreaField.$ctor3.prototype = $Cayita_UI_TextAreaField.$ctor1.prototype = $Cayita_UI_TextAreaField.$ctor4.prototype = $Cayita_UI_TextAreaField.$ctor5.prototype = $Cayita_UI_TextAreaField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TextField
	var $Cayita_UI_TextField = function() {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor2.call(this, null);
	};
	$Cayita_UI_TextField.$ctor1 = function(parent) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor2.call(this, parent.element());
	};
	$Cayita_UI_TextField.$ctor4 = function(parent) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor2.call(this, parent);
	};
	$Cayita_UI_TextField.$ctor2 = function(field) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor3.call(this, null, field);
	};
	$Cayita_UI_TextField.$ctor5 = function(parent, field) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor2.call(this, parent);
	};
	$Cayita_UI_TextField.$ctor3 = function(field) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor4.call(this, null, field);
	};
	$Cayita_UI_TextField.$ctor6 = function(parent, field) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor4.call(this, parent, field);
	};
	$Cayita_UI_TextField.$ctor7 = function(parent, label, fieldname) {
		ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]).$ctor5.call(this, parent, label, fieldname);
	};
	$Cayita_UI_TextField.$ctor1.prototype = $Cayita_UI_TextField.$ctor4.prototype = $Cayita_UI_TextField.$ctor2.prototype = $Cayita_UI_TextField.$ctor5.prototype = $Cayita_UI_TextField.$ctor3.prototype = $Cayita_UI_TextField.$ctor6.prototype = $Cayita_UI_TextField.$ctor7.prototype = $Cayita_UI_TextField.prototype;
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI.TextFieldBase
	var $Cayita_UI_TextFieldBase$1 = function(T) {
		var $type = function(field) {
			$type.$ctor3.call(this, null, field);
		};
		$type.prototype = {
			get_input: function() {
				return this.$5$InputField;
			},
			set_input: function(value) {
				this.$5$InputField = value;
			},
			element$2: function() {
				return this.element$1();
			}
		};
		$type.$ctor2 = function(parent) {
			this.$5$InputField = null;
			ss.makeGenericType($Cayita_UI_Field$1, [T]).call(this, parent, 'text', true, 'input');
			this.set_input(this.element$2());
		};
		$type.$ctor3 = function(parent, field) {
			$type.$ctor2.call(this, parent);
			field(this.get_controlLabel().element$1(), this.element$2());
			this.get_controlLabel().for$2(this.element$2().id);
			if (ss.isNullOrEmptyString(this.get_controlLabel().textLabel())) {
				this.get_controlLabel().hide();
			}
		};
		$type.$ctor1 = function(field) {
			$type.$ctor4.call(this, null, field);
		};
		$type.$ctor4 = function(parent, field) {
			$type.$ctor2.call(this, parent);
			field(this.element$2());
			this.get_controlLabel().for$2(this.element$2().id).hide();
		};
		$type.$ctor5 = function(parent, label, fieldname) {
			$type.$ctor2.call(this, parent);
			this.get_controlLabel().text$1(label);
			this.name$1(fieldname);
		};
		$type.$ctor2.prototype = $type.$ctor3.prototype = $type.$ctor1.prototype = $type.$ctor4.prototype = $type.$ctor5.prototype = $type.prototype;
		ss.registerGenericClassInstance($type, $Cayita_UI_TextFieldBase$1, [T], function() {
			return ss.makeGenericType($Cayita_UI_Field$1, [T]);
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Cayita.UI.TextFieldBase$1', $Cayita_UI_TextFieldBase$1, 1);
	ss.registerClass(global, 'Extensions', $Extensions);
	ss.registerClass(global, 'StringExtensions', $StringExtensions);
	ss.registerClass(global, 'SystemExtensions', $SystemExtensions);
	ss.registerClass(global, 'Cayita.ImgUpload', $Cayita_ImgUpload, ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_ImgUpload]));
	ss.registerClass(global, 'Cayita.UI.FileUploadConfig', $Cayita_UI_FileUploadConfig);
	ss.registerClass(global, 'Cayita.ImgUploadConfig', $Cayita_ImgUploadConfig, $Cayita_UI_FileUploadConfig);
	ss.registerClass(global, 'Cayita.PasswordField', $Cayita_PasswordField, ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_PasswordField]));
	ss.registerClass(global, 'Cayita.Data.AjaxResponse', $Cayita_Data_AjaxResponse);
	ss.registerClass(global, 'Cayita.Data.AppError', $Cayita_Data_AppError);
	ss.registerClass(global, 'Cayita.Data.ReadOptions', $Cayita_Data_ReadOptions);
	ss.registerClass(global, 'Cayita.Data.ResponseStatus', $Cayita_Data_ResponseStatus);
	ss.registerEnum(global, 'Cayita.Data.StoreChangedAction', $Cayita_Data_StoreChangedAction);
	ss.registerEnum(global, 'Cayita.Data.StoreErrorAction', $Cayita_Data_StoreErrorAction);
	ss.registerEnum(global, 'Cayita.Data.StoreRequestedAction', $Cayita_Data_StoreRequestedAction);
	ss.registerClass(global, 'Cayita.Data.StoreRequestedData', $Cayita_Data_StoreRequestedData);
	ss.registerEnum(global, 'Cayita.Data.StoreRequestedState', $Cayita_Data_StoreRequestedState);
	ss.registerClass(global, 'Cayita.Plugins.Message', $Cayita_Plugins_Message);
	ss.registerClass(global, 'Cayita.Plugins.MessageFor', $Cayita_Plugins_MessageFor);
	ss.registerClass(global, 'Cayita.Plugins.Range', $Cayita_Plugins_Range);
	ss.registerClass(global, 'Cayita.Plugins.Rule', $Cayita_Plugins_Rule);
	ss.registerClass(global, 'Cayita.Plugins.RuleFor', $Cayita_Plugins_RuleFor);
	ss.registerClass(global, 'Cayita.Plugins.ValidateOptions', $Cayita_Plugins_ValidateOptions);
	ss.registerClass(global, 'Cayita.UI.Alert', $Cayita_UI_Alert);
	ss.registerClass(global, 'Cayita.UI.Anchor', $Cayita_UI_Anchor, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Anchor]));
	ss.registerClass(global, 'Cayita.UI.Bootbox', $Cayita_UI_Bootbox);
	ss.registerClass(global, 'Cayita.UI.Button', $Cayita_UI_Button, ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_Button]));
	ss.registerClass(global, 'Cayita.UI.CheckboxField', $Cayita_UI_CheckboxField, ss.makeGenericType($Cayita_UI_Field$1, [$Cayita_UI_CheckboxField]));
	ss.registerClass(global, 'Cayita.UI.CheckGroup', $Cayita_UI_CheckGroup, ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_CheckGroup, $Cayita_UI_InputCheckbox]));
	ss.registerClass(global, 'Cayita.UI.DialogButton', $Cayita_UI_DialogButton);
	ss.registerClass(global, 'Cayita.UI.DialogOptions', $Cayita_UI_DialogOptions);
	ss.registerClass(global, 'Cayita.UI.Div', $Cayita_UI_Div, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Div]));
	ss.registerClass(global, 'Cayita.UI.HtmlList', $Cayita_UI_HtmlList, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlList]));
	ss.registerClass(global, 'Cayita.UI.DropDownMenu', $Cayita_UI_DropDownMenu, $Cayita_UI_HtmlList);
	ss.registerClass(global, 'Cayita.UI.ListItem', $Cayita_UI_ListItem, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_ListItem]));
	ss.registerClass(global, 'Cayita.UI.DropDownSubmenu', $Cayita_UI_DropDownSubmenu, $Cayita_UI_ListItem);
	ss.registerClass(global, 'Cayita.UI.ElementBase', $Cayita_UI_ElementBase);
	ss.registerClass(global, 'Cayita.UI.FieldSet', $Cayita_UI_FieldSet, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_FieldSet]));
	ss.registerClass(global, 'Cayita.UI.FileUpload', $Cayita_UI_FileUpload, ss.makeGenericType($Cayita_UI_FileUpload$1, [$Cayita_UI_FileUpload]));
	ss.registerClass(global, 'Cayita.UI.Form', $Cayita_UI_Form, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Form]));
	ss.registerClass(global, 'Cayita.UI.GroupItem', $Cayita_UI_GroupItem);
	ss.registerClass(global, 'Cayita.UI.HtmlOption', $Cayita_UI_HtmlOption, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlOption]));
	ss.registerClass(global, 'Cayita.UI.HtmlTable', $Cayita_UI_HtmlTable, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_HtmlTable]));
	ss.registerClass(global, 'Cayita.UI.Icon', $Cayita_UI_Icon, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Icon]));
	ss.registerClass(global, 'Cayita.UI.IconAnchor', $Cayita_UI_IconAnchor, $Cayita_UI_Anchor);
	ss.registerClass(global, 'Cayita.UI.IconButton', $Cayita_UI_IconButton, $Cayita_UI_Button);
	ss.registerClass(global, 'Cayita.UI.Image', $Cayita_UI_Image, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Image]));
	ss.registerClass(global, 'Cayita.UI.Input', $Cayita_UI_Input, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_Input]));
	ss.registerClass(global, 'Cayita.UI.InputCheckbox', $Cayita_UI_InputCheckbox, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputCheckbox]));
	ss.registerClass(global, 'Cayita.UI.InputFile', $Cayita_UI_InputFile, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputFile]));
	ss.registerClass(global, 'Cayita.UI.InputHidden', $Cayita_UI_InputHidden, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputHidden]));
	ss.registerClass(global, 'Cayita.UI.InputText', $Cayita_UI_InputText, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputText]));
	ss.registerClass(global, 'Cayita.UI.InputPassword', $Cayita_UI_InputPassword, $Cayita_UI_InputText);
	ss.registerClass(global, 'Cayita.UI.InputRadio', $Cayita_UI_InputRadio, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputRadio]));
	ss.registerClass(global, 'Cayita.UI.InputSelect', $Cayita_UI_InputSelect, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_InputSelect]));
	ss.registerClass(global, 'Cayita.UI.InputTextArea', $Cayita_UI_InputTextArea, ss.makeGenericType($Cayita_UI_InputBase$1, [$Cayita_UI_InputTextArea]));
	ss.registerClass(global, 'Cayita.UI.Label', $Cayita_UI_Label, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Label]));
	ss.registerClass(global, 'Cayita.UI.Legend', $Cayita_UI_Legend, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Legend]));
	ss.registerClass(global, 'Cayita.UI.NavBar', $Cayita_UI_NavBar, $Cayita_UI_Div);
	ss.registerClass(global, 'Cayita.UI.NavList', $Cayita_UI_NavList, $Cayita_UI_Div);
	ss.registerClass(global, 'Cayita.UI.Panel', $Cayita_UI_Panel, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Panel]));
	ss.registerClass(global, 'Cayita.UI.PanelConfig', $Cayita_UI_PanelConfig);
	ss.registerClass(global, 'Cayita.UI.Paragraph', $Cayita_UI_Paragraph, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Paragraph]));
	ss.registerClass(global, 'Cayita.UI.RadioGroup', $Cayita_UI_RadioGroup, ss.makeGenericType($Cayita_UI_GroupBase$2, [$Cayita_UI_RadioGroup, $Cayita_UI_InputRadio]));
	ss.registerClass(global, 'Cayita.UI.RequestMessage', $Cayita_UI_RequestMessage);
	ss.registerClass(global, 'Cayita.UI.ResetButton', $Cayita_UI_ResetButton, ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_ResetButton]));
	ss.registerClass(global, 'Cayita.UI.SelectedRow', $Cayita_UI_SelectedRow);
	ss.registerClass(global, 'Cayita.UI.SelectField', $Cayita_UI_SelectField, ss.makeGenericType($Cayita_UI_SelectFieldBase$1, [$Cayita_UI_SelectField]));
	ss.registerClass(global, 'Cayita.UI.Span', $Cayita_UI_Span, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_Span]));
	ss.registerClass(global, 'Cayita.UI.SpinnerIcon', $Cayita_UI_SpinnerIcon, $Cayita_UI_Div);
	ss.registerClass(global, 'Cayita.UI.SubmitButton', $Cayita_UI_SubmitButton, ss.makeGenericType($Cayita_UI_ButtonBase$1, [$Cayita_UI_SubmitButton]));
	ss.registerClass(global, 'Cayita.UI.Tab', $Cayita_UI_Tab);
	ss.registerClass(global, 'Cayita.UI.TableBody', $Cayita_UI_TableBody, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableBody]));
	ss.registerClass(global, 'Cayita.UI.TableCell', $Cayita_UI_TableCell, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableCell]));
	ss.registerClass(global, 'Cayita.UI.TableFooter', $Cayita_UI_TableFooter, $Cayita_UI_HtmlTable);
	ss.registerClass(global, 'Cayita.UI.TableHeader', $Cayita_UI_TableHeader, $Cayita_UI_HtmlTable);
	ss.registerClass(global, 'Cayita.UI.TableRow', $Cayita_UI_TableRow, ss.makeGenericType($Cayita_UI_ElementBase$1, [$Cayita_UI_TableRow]));
	ss.registerClass(global, 'Cayita.UI.TabPanel', $Cayita_UI_TabPanel, $Cayita_UI_Div);
	ss.registerClass(global, 'Cayita.UI.TabPanelConfig', $Cayita_UI_TabPanelConfig);
	ss.registerClass(global, 'Cayita.UI.TextAreaField', $Cayita_UI_TextAreaField, ss.makeGenericType($Cayita_UI_Field$1, [$Cayita_UI_TextAreaField]));
	ss.registerClass(global, 'Cayita.UI.TextField', $Cayita_UI_TextField, ss.makeGenericType($Cayita_UI_TextFieldBase$1, [$Cayita_UI_TextField]));
	$Cayita_UI_ElementBase.$tags = new (ss.makeGenericType(ss.Dictionary$2, [String, ss.Int32]))();
})();
