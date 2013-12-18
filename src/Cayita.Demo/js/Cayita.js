(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.AlertFn
	var $Cayita_AlertFn = function() {
	};
	$Cayita_AlertFn.ErrorTemplate = function() {
		return '<div class=\'alert alert-block alert-error\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>';
	};
	$Cayita_AlertFn.Error = function(element, message, before, delay) {
		$Cayita_AlertFn.$Imp(element, message, before, delay, $Cayita_AlertFn.ErrorTmpl);
	};
	$Cayita_AlertFn.Success = function(element, message, before, delay) {
		$Cayita_AlertFn.$Imp(element, message, before, delay, $Cayita_AlertFn.SuccessTmpl);
	};
	$Cayita_AlertFn.Info = function(element, message, before, delay) {
		$Cayita_AlertFn.$Imp(element, message, before, delay, $Cayita_AlertFn.InfoTmpl);
	};
	$Cayita_AlertFn.Warning = function(element, message, before, delay) {
		$Cayita_AlertFn.$Imp(element, message, before, delay, $Cayita_AlertFn.WarningTmpl);
	};
	$Cayita_AlertFn.PageAlert = function(parent, message, type, delay) {
		var jq = $($Cayita_AlertFn.PageAlertTmpl(message, type));
		var j = $('.page-alert', parent);
		if (j.length === 0) {
			j = $($Cayita_Fn.fmt('<div class=\'page-alert\' style=\'z-index:{0};position:fixed;\'></div>', [$Cayita_AlertFn.PageAlertZIndex]));
			$(parent).append(j);
		}
		j.append(jq);
		if (delay > 0) {
			$Cayita_Fn.runAfter(function() {
				jq.remove();
			}, delay);
		}
	};
	$Cayita_AlertFn.$Imp = function(element, message, before, delay, tmplFn) {
		var jq = $(tmplFn(message));
		if (before) {
			jq.insertBefore(element);
		}
		else {
			jq.insertAfter(element);
		}
		if (delay > 0) {
			$Cayita_Fn.runAfter(function() {
				jq.remove();
			}, delay);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.JData.Data
	var $Cayita_Data = function() {
	};
	$Cayita_Data.StoreChangedData = function(T) {
		return function() {
			return { newData: null, oldData: null, action: 0, index: -1 };
		};
	};
	$Cayita_Data.StoreFailedData = function(T) {
		return function() {
			return { action: 0, request: null };
		};
	};
	$Cayita_Data.StoreRequestedData = function(T) {
		return function() {
			return { action: 0, state: 0 };
		};
	};
	$Cayita_Data.ReadOptions = function() {
		var o = { pageSizeParam: 'limit', pageNumberParam: 'page', orderByParam: 'orderby', orderTypeParam: 'ordertype', pageSize: null, orderBy: null, pageNumber: null, localPaging: false, query: {}, dynamicQuery: {} };
		var df = {};
		o.get_request = function() {
			var ro = {};
			if (!ss.isNullOrEmptyString(o.orderBy)) {
				ro[o.orderByParam] = o.orderBy;
			}
			if (!ss.isNullOrEmptyString(o.orderType)) {
				ro[o.orderTypeParam] = o.orderType;
			}
			if (!o.localPaging) {
				if (ss.isValue(o.pageNumber)) {
					ro[o.pageNumberParam] = ss.Nullable.unbox(o.pageNumber);
				}
				if (ss.isValue(o.pageSize)) {
					ro[o.pageSizeParam] = o.pageSize;
				}
			}
			var $t1 = new ss.ObjectEnumerator(o.query);
			try {
				while ($t1.moveNext()) {
					var kv = $t1.current();
					ro[kv.key] = kv.value;
				}
			}
			finally {
				$t1.dispose();
			}
			$Cayita_Fn.copyFrom(ro, o.dynamicQuery);
			$Cayita_Fn.copyFrom(ro, df);
			return ro;
		};
		o.set_dataForm = function(s) {
			ss.clearKeys(df);
			$Cayita_Fn.copyFrom(df, s);
		};
		return o;
	};
	$Cayita_Data.StoreApi = function(T) {
		return function() {
			var s = { url: 'api/' + ss.getTypeName(T), dataType: 'json', dataProperty: 'Result', totalCountProperty: 'TotalCount', htmlProperty: 'Html', converters: {}, createMethod: 'create', readMethod: 'read', updateMethod: 'update', destroyMethod: 'destroy', patchMethod: 'patch' };
			var createApiFn = function() {
				return $Cayita_Fn.fmt('{0}{1}', [(!ss.isNullOrEmptyString(s.url) ? s.url : ''), (!ss.isNullOrEmptyString(s.createMethod) ? ((!ss.isNullOrEmptyString(s.url) ? '/' : '') + s.createMethod) : '')]);
			};
			var readApiFn = function() {
				return $Cayita_Fn.fmt('{0}{1}', [(!ss.isNullOrEmptyString(s.url) ? s.url : ''), (!ss.isNullOrEmptyString(s.readMethod) ? ((!ss.isNullOrEmptyString(s.url) ? '/' : '') + s.readMethod) : '')]);
			};
			var updateApiFn = function() {
				return $Cayita_Fn.fmt('{0}{1}', [(!ss.isNullOrEmptyString(s.url) ? s.url : ''), (!ss.isNullOrEmptyString(s.updateMethod) ? ((!ss.isNullOrEmptyString(s.url) ? '/' : '') + s.updateMethod) : '')]);
			};
			var destroyApiFn = function() {
				return $Cayita_Fn.fmt('{0}{1}', [(!ss.isNullOrEmptyString(s.url) ? s.url : ''), (!ss.isNullOrEmptyString(s.destroyMethod) ? ((!ss.isNullOrEmptyString(s.url) ? '/' : '') + s.destroyMethod) : '')]);
			};
			var patchApiFn = function() {
				return $Cayita_Fn.fmt('{0}{1}', [(!ss.isNullOrEmptyString(s.url) ? s.url : ''), (!ss.isNullOrEmptyString(s.patchMethod) ? ((!ss.isNullOrEmptyString(s.url) ? '/' : '') + s.patchMethod) : '')]);
			};
			s.get_createApiFn = function() {
				return createApiFn;
			};
			s.set_createApiFn = function(v) {
				createApiFn = v;
			};
			s.get_createApi = function() {
				return createApiFn();
			};
			s.get_readApiFn = function() {
				return readApiFn;
			};
			s.set_readApiFn = function(v1) {
				readApiFn = v1;
			};
			s.get_readApi = function() {
				return readApiFn();
			};
			s.get_updateApiFn = function() {
				return updateApiFn;
			};
			s.set_updateApiFn = function(v2) {
				updateApiFn = v2;
			};
			s.get_updateApi = function() {
				return updateApiFn();
			};
			s.get_destroyApiFn = function() {
				return destroyApiFn;
			};
			s.set_destroyApiFn = function(v3) {
				destroyApiFn = v3;
			};
			s.get_destroyApi = function() {
				return destroyApiFn();
			};
			s.get_patchApiFn = function() {
				return patchApiFn;
			};
			s.set_patchApiFn = function(v4) {
				patchApiFn = v4;
			};
			s.get_patchApi = function() {
				return patchApiFn();
			};
			return s;
		};
	};
	$Cayita_Data.Store = function(T) {
		return function() {
			var o = [];
			o.lastOption = Cayita.Data.ReadOptions();
			o.api = Cayita.Data.StoreApi(T)();
			var filterFn = function(d) {
				return true;
			};
			var totalCount = 0;
			var idProperty = 'Id';
			var defaultPageSize = 10;
			var ls = [];
			var storeChanged = function(st, d1) {
			};
			var storeRequested = function(st1, d2) {
			};
			var storeFailed = function(st2, d3) {
			};
			var onStoreFailed = function(store, action, rq) {
				var $t1 = Cayita.Data.StoreFailedData(T)();
				$t1.action = action;
				$t1.request = rq;
				storeFailed(store, $t1);
			};
			var onStoreRequested = function(store1, action1, state) {
				var $t2 = Cayita.Data.StoreRequestedData();
				$t2.action = action1;
				$t2.state = state;
				storeRequested(store1, $t2);
			};
			var onStoreChanged = function(store2, action2, ndata, odata, index) {
				var $t3 = Cayita.Data.StoreChangedData(T)();
				$t3.action = action2;
				$t3.newData = ndata;
				$t3.oldData = odata;
				$t3.index = (ss.isValue(index) ? ss.Nullable.unbox(index) : -1);
				storeChanged(store2, $t3);
			};
			var createFn = function(record) {
				onStoreRequested(o, 1, 1);
				var req = $.post(o.api.get_createApi(), record, function(cb) {
				}, o.api.dataType);
				req.done(function(scb) {
					var r = o.api.dataProperty;
					var data = scb;
					var res = ss.coalesce(data[r], data);
					if (Array.isArray(res)) {
						var $t4 = ss.getEnumerator(ss.cast(res, ss.IList));
						try {
							while ($t4.moveNext()) {
								var item = $t4.current();
								ss.add(ls, item);
								onStoreChanged(o, 1, item, item, ss.indexOf(ls, item));
							}
						}
						finally {
							$t4.dispose();
						}
					}
					else {
						ss.add(ls, ss.cast(res, T));
						onStoreChanged(o, 1, ss.cast(res, T), ss.cast(res, T), ss.cast(ss.indexOf(ls, ss.cast(res, T)), ss.Int32));
					}
				});
				req.fail(function(f) {
					onStoreFailed(o, 1, req);
				});
				req.always(function(t) {
					onStoreRequested(o, 1, 2);
				});
				return req;
			};
			var readFn = function(readOptions) {
				onStoreRequested(o, 2, 1);
				var req1 = $.get(o.api.get_readApi(), readOptions.get_request(), function(cb1) {
				}, o.api.dataType);
				req1.done(function(scb1) {
					var r1 = o.api.dataProperty;
					var data1 = scb1;
					var res1 = ss.coalesce(data1[r1], data1);
					if (Array.isArray(res1)) {
						var $t5 = ss.getEnumerator(ss.cast(res1, ss.IList));
						try {
							while ($t5.moveNext()) {
								var item1 = $t5.current();
								var $t6 = new ss.ObjectEnumerator(o.api.converters);
								try {
									while ($t6.moveNext()) {
										var kv = $t6.current();
										item1[kv.key] = kv.value(item1);
									}
								}
								finally {
									$t6.dispose();
								}
								ss.add(ls, item1);
							}
						}
						finally {
							$t5.dispose();
						}
					}
					else {
						ss.add(ls, ss.cast(res1, T));
					}
					var tc = ss.cast(data1[o.api.totalCountProperty], ss.Int32);
					o.set_totalCount((ss.isValue(tc) ? ss.Nullable.unbox(tc) : Enumerable.from(ls).count(o.get_filterFn())));
					onStoreChanged(o, 2, null, null, -1);
				});
				req1.fail(function(f1) {
					onStoreFailed(o, 2, req1);
				});
				req1.always(function(f2) {
					onStoreRequested(o, 2, 2);
				});
				return req1;
			};
			var updateFn = function(record1) {
				onStoreRequested(o, 3, 1);
				var req2 = $.post(o.api.get_updateApi(), record1, function(cb2) {
				}, o.api.dataType);
				req2.done(function(scb2) {
					var r2 = o.api.dataProperty;
					var data2 = scb2;
					var res2 = ss.coalesce(data2[r2], data2);
					if (Array.isArray(res2)) {
						var $t7 = ss.getEnumerator(ss.cast(res2, ss.IList));
						try {
							while ($t7.moveNext()) {
								var item2 = { $: $t7.current() };
								var ur = Enumerable.from(ls).first(ss.mkdel({ item2: item2 }, function(f3) {
									return ss.referenceEquals($Cayita_Fn.$get(f3, o.get_idProperty()), $Cayita_Fn.$get(this.item2.$, o.get_idProperty()));
								}));
								var old = ss.createInstance(T);
								$Cayita_Fn.populateFrom(old, ur);
								$Cayita_Fn.populateFrom(ur, item2.$);
								onStoreChanged(o, 3, ur, old, ss.indexOf(ls, ur));
							}
						}
						finally {
							$t7.dispose();
						}
					}
					else {
						var ur1 = Enumerable.from(ls).first(function(f4) {
							return !!ss.referenceEquals($Cayita_Fn.$get(f4, o.get_idProperty()), res2.Get(o.get_idProperty()));
						});
						var old1 = ss.createInstance(T);
						$Cayita_Fn.populateFrom(old1, ur1);
						$Cayita_Fn.populateFrom(ur1, res2);
						onStoreChanged(o, 3, ur1, old1, ss.indexOf(ls, ur1));
					}
				});
				req2.fail(function(f5) {
					onStoreFailed(o, 3, req2);
				});
				req2.always(function(f6) {
					onStoreRequested(o, 3, 2);
				});
				return req2;
			};
			var destroyFn = function(record2) {
				onStoreRequested(o, 4, 1);
				var data3 = {};
				data3[o.get_idProperty()] = $Cayita_Fn.$get(record2, o.get_idProperty());
				var req3 = $.post(o.api.get_destroyApi(), data3, function(cb3) {
				}, o.api.dataType);
				req3.done(function(scb3) {
					var dr = Enumerable.from(ls).first(function(f7) {
						return ss.referenceEquals($Cayita_Fn.$get(f7, o.get_idProperty()), $Cayita_Fn.$get(record2, o.get_idProperty()));
					});
					ss.remove(ls, dr);
					onStoreChanged(o, 4, dr, dr, -1);
				});
				req3.fail(function(f8) {
					onStoreFailed(o, 4, null);
				});
				req3.always(function(f9) {
					onStoreRequested(o, 4, 2);
				});
				return req3;
			};
			var patchFn = function(record3) {
				onStoreRequested(o, 5, 1);
				var req4 = $.post(o.api.get_patchApi(), record3, function(cb4) {
				}, o.api.dataType);
				req4.done(function(scb4) {
					var r3 = o.api.dataProperty;
					var data4 = scb4;
					var res3 = ss.coalesce(data4[r3], data4);
					if (!!res3.IsArray()) {
						var $t8 = ss.getEnumerator(ss.cast(res3, ss.IList));
						try {
							while ($t8.moveNext()) {
								var item3 = { $: $t8.current() };
								var ur2 = Enumerable.from(ls).first(ss.mkdel({ item3: item3 }, function(f10) {
									return ss.referenceEquals($Cayita_Fn.$get(f10, o.get_idProperty()), $Cayita_Fn.$get(this.item3.$, o.get_idProperty()));
								}));
								var old2 = ss.createInstance(T);
								$Cayita_Fn.populateFrom(old2, ur2);
								$Cayita_Fn.populateFrom(ur2, item3.$);
								onStoreChanged(o, 5, ur2, old2, ss.indexOf(ls, ur2));
							}
						}
						finally {
							$t8.dispose();
						}
					}
					else {
						var ur3 = Enumerable.from(ls).first(function(f11) {
							return !!ss.referenceEquals($Cayita_Fn.$get(f11, o.get_idProperty()), res3.Get(o.get_idProperty()));
						});
						var old3 = ss.createInstance(T);
						$Cayita_Fn.populateFrom(old3, ur3);
						$Cayita_Fn.populateFrom(ur3, res3);
						onStoreChanged(o, 5, ur3, old3, ss.indexOf(ls, ur3));
					}
				});
				req4.fail(function(f12) {
					onStoreFailed(o, 5, req4);
				});
				req4.always(function(f13) {
					onStoreRequested(o, 5, 2);
				});
				return req4;
			};
			o.create = function(d4) {
				return createFn(d4);
			};
			o.read = function(ro, clear) {
				if (!ss.isValue(clear) || ss.Nullable.unbox(clear)) {
					ss.clear(ls);
				}
				if (!ss.staticEquals(ro, null)) {
					ro(o.lastOption);
				}
				var lo = o.lastOption;
				if (ss.isValue(lo.pageNumber) && (!ss.isValue(lo.pageSize) || ss.isValue(lo.pageSize) && ss.Nullable.unbox(lo.pageSize) === 0)) {
					lo.pageSize = defaultPageSize;
				}
				return readFn(o.lastOption);
			};
			o.update = function(d5) {
				return updateFn(d5);
			};
			o.destroy = function(d6) {
				return destroyFn(d6);
			};
			o.patch = function(d7) {
				return patchFn(d7);
			};
			o.replace = function(record4) {
				var self = o;
				var source = Enumerable.from(ls).first(function(f14) {
					return ss.referenceEquals($Cayita_Fn.$get(f14, self.get_idProperty()).toString(), $Cayita_Fn.$get(record4, self.get_idProperty()).toString());
				});
				var index1 = ss.indexOf(ls, source);
				var old4 = $Cayita_Fn.clone(source);
				$Cayita_Fn.populateFrom(source, record4);
				onStoreChanged(o, 8, source, old4, index1);
			};
			o.load = function(data5, ro1, append) {
				if (!ss.staticEquals(ro1, null)) {
					ro1(o.lastOption);
				}
				var lo1 = o.lastOption;
				if (ss.isValue(lo1.pageNumber) && (!ss.isValue(lo1.pageSize) || ss.isValue(lo1.pageSize) && ss.Nullable.unbox(lo1.pageSize) === 0)) {
					lo1.pageSize = defaultPageSize;
				}
				if (!ss.isValue(append) || !ss.Nullable.unbox(append)) {
					ss.clear(ls);
				}
				ss.arrayAddRange(ls, data5);
				o.set_totalCount(Enumerable.from(ls).count(o.get_filterFn()));
				onStoreChanged(o, 11, null, null, -1);
			};
			o.hasNextPage = function() {
				return ((o.get_count() === o.get_totalCount() || !ss.isValue(o.lastOption.pageNumber)) ? false : (ss.Nullable.unbox(o.lastOption.pageNumber) + 1 < o.pagesCount()));
			};
			o.hasPreviousPage = function() {
				return !(o.get_count() === o.get_totalCount() || !ss.isValue(o.lastOption.pageNumber) || ss.isValue(o.lastOption.pageNumber) && ss.Nullable.unbox(o.lastOption.pageNumber) === 0);
			};
			o.readFirstPage = function() {
				if (ss.isValue(o.lastOption.pageNumber)) {
					o.lastOption.pageNumber = 0;
				}
				if (!o.lastOption.localPaging) {
					o.get_readFn()(o.lastOption);
				}
				else {
					onStoreChanged(o, 2, null, null, -1);
				}
			};
			o.readNextPage = function(checkForNext) {
				if ((!ss.isValue(checkForNext) || ss.Nullable.unbox(checkForNext)) && !o.hasNextPage()) {
					return;
				}
				o.lastOption.pageNumber = ss.Nullable.add(o.lastOption.pageNumber, 1);
				if (!o.lastOption.localPaging) {
					o.get_readFn()(o.lastOption);
				}
				else {
					onStoreChanged(o, 2, null, null, -1);
				}
			};
			o.readPreviousPage = function(checkForPrevious) {
				if ((!ss.isValue(checkForPrevious) || ss.Nullable.unbox(checkForPrevious)) && !o.hasPreviousPage()) {
					return;
				}
				o.lastOption.pageNumber = ss.Nullable.sub(o.lastOption.pageNumber, 1);
				if (!o.lastOption.localPaging) {
					o.get_readFn()(o.lastOption);
				}
				else {
					onStoreChanged(o, 2, null, null, -1);
				}
			};
			o.readLastPage = function() {
				if (ss.isValue(o.lastOption.pageNumber)) {
					o.lastOption.pageNumber = o.pagesCount() - 1;
				}
				if (!o.lastOption.localPaging) {
					o.get_readFn()(o.lastOption);
				}
				else {
					onStoreChanged(o, 2, null, null, -1);
				}
			};
			o.readPage = function(page) {
				if (ss.isValue(o.lastOption.pageNumber)) {
					o.lastOption.pageNumber = ((page < 0) ? 0 : ((page >= o.pagesCount()) ? (o.pagesCount() - 1) : page));
				}
				if (!o.lastOption.localPaging) {
					o.get_readFn()(o.lastOption);
				}
				else {
					onStoreChanged(o, 2, null, null, -1);
				}
			};
			o.pagesCount = function() {
				return ss.Int32.trunc(Math.ceil(o.get_totalCount() / (ss.isValue(o.lastOption.pageSize) ? ss.Nullable.unbox(o.lastOption.pageSize) : ls.length)));
			};
			o.fromTo = function() {
				var lo2 = o.lastOption;
				var pageNumber = (ss.isValue(lo2.pageNumber) ? ss.Nullable.unbox(lo2.pageNumber) : 0);
				var pageSize = (ss.isValue(lo2.pageSize) ? ss.Nullable.unbox(lo2.pageSize) : o.get_totalCount());
				var from_ = pageNumber * pageSize + 1;
				var to_ = pageNumber * pageSize + pageSize;
				if (to_ > o.get_totalCount()) {
					to_ = o.get_totalCount();
				}
				if (to_ === 0) {
					from_ = 0;
				}
				return { item1: pageNumber, item2: from_, item3: to_ };
			};
			o.indexOf = function($t9) {
				return ss.indexOf(ls, $t9);
			};
			o.insert = function(index2, item4) {
				ss.insert(ls, index2, item4);
				onStoreChanged(o, 7, item4, item4, index2);
			};
			o.removeAt = function(index3) {
				var item5 = ls[index3];
				ss.removeAt(ls, index3);
				onStoreChanged(o, 9, item5, item5, index3);
			};
			o.get_item = function(index4) {
				return ls[index4];
			};
			o.set_item = function(index5, value) {
				var old5 = ls[index5];
				var clone = $Cayita_Fn.clone(old5);
				ls[index5] = value;
				onStoreChanged(o, 8, clone, value, index5);
			};
			o.get_count = function() {
				return ((o.lastOption.localPaging && ss.isValue(o.lastOption.pageSize) && ss.Nullable.unbox(o.lastOption.pageSize) < Enumerable.from(ls).count(o.get_filterFn())) ? ss.Nullable.unbox(o.lastOption.pageSize) : Enumerable.from(ls).count(o.get_filterFn()));
			};
			o.add = function(item6) {
				ss.add(ls, item6);
				onStoreChanged(o, 6, item6, item6, o.get_totalCount() - 1);
			};
			o.clear = function() {
				ss.clear(ls);
				onStoreChanged(o, 10, null, null, -1);
			};
			o.contains = function($t10) {
				return ss.contains(ls, $t10);
			};
			o.remove = function(item7) {
				var index6 = ss.indexOf(ls, item7);
				var r4 = ss.remove(ls, item7);
				if (r4) {
					onStoreChanged(o, 9, item7, item7, index6);
				}
				return r4;
			};
			o.getEnumerator = function() {
				var lo3 = o.lastOption;
				if (lo3.localPaging && ss.isValue(lo3.pageNumber) && ss.isValue(lo3.pageSize)) {
					return Enumerable.from(ls).where(o.get_filterFn()).skip(ss.Nullable.unbox(lo3.pageNumber) * ss.Nullable.unbox(lo3.pageSize)).take(ss.Nullable.unbox(lo3.pageSize)).getEnumerator();
				}
				return Enumerable.from(ls).where(o.get_filterFn()).getEnumerator();
			};
			o.add_storeChanged = function(v) {
				storeChanged = ss.delegateCombine(storeChanged, v);
			};
			o.remove_storeChanged = function(v1) {
				storeChanged = ss.delegateRemove(storeChanged, v1);
			};
			o.add_storeFailed = function(v2) {
				storeFailed = ss.delegateCombine(storeFailed, v2);
			};
			o.remove_storeFailed = function(v3) {
				storeFailed = ss.delegateRemove(storeFailed, v3);
			};
			o.add_storeRequested = function(v4) {
				storeRequested = ss.delegateCombine(storeRequested, v4);
			};
			o.remove_storeRequested = function(v5) {
				storeRequested = ss.delegateRemove(storeRequested, v5);
			};
			o.filter = function(fn) {
				if (!ss.staticEquals(fn, null)) {
					filterFn = fn;
				}
				if (ss.isValue(o.lastOption.pageNumber)) {
					o.lastOption.pageNumber = 0;
				}
				o.set_totalCount(Enumerable.from(ls).count(filterFn));
				onStoreChanged(o, 12, null, null, -1);
			};
			o.get_createFn = function() {
				return createFn;
			};
			o.set_createFn = function(v6) {
				createFn = v6;
			};
			o.get_readFn = function() {
				return readFn;
			};
			o.set_readFn = function(v7) {
				readFn = v7;
			};
			o.get_updateFn = function() {
				return updateFn;
			};
			o.set_updateFn = function(v8) {
				updateFn = v8;
			};
			o.get_destroyFn = function() {
				return destroyFn;
			};
			o.set_destroyFn = function(v9) {
				destroyFn = v9;
			};
			o.get_patchFn = function() {
				return patchFn;
			};
			o.set_patchFn = function(v10) {
				patchFn = v10;
			};
			o.get_totalCount = function() {
				return totalCount;
			};
			o.set_totalCount = function(v11) {
				totalCount = v11;
			};
			o.get_idProperty = function() {
				return idProperty;
			};
			o.set_idProperty = function(v12) {
				idProperty = v12;
			};
			o.get_filterFn = function() {
				return filterFn;
			};
			o.set_filterFn = function(v13) {
				filterFn = v13;
			};
			return o;
		};
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Fn
	var $Cayita_Fn = function() {
	};
	$Cayita_Fn.fmt = function(format, args) {
		return ss.formatString.apply(null, [format].concat(args));
	};
	$Cayita_Fn.header = function(text, size) {
		return $Cayita_UI.Atom('h' + size.toString(), null, null, text, null, null);
	};
	$Cayita_Fn.paragraph = function(text) {
		return $Cayita_UI.Atom('p', null, null, text, null, null);
	};
	$Cayita_Fn.send = function(fd, url) {
		return $.ajax({ url: url, type: 'POST', data: fd, processData: false, contentType: '' });
	};
	$Cayita_Fn.runAfterFn = function() {
		var timer = 0;
		return function(cb, dl) {
			window.clearTimeout(timer);
			timer = window.setTimeout(cb, dl);
		};
	};
	$Cayita_Fn.runAfter = function(callback, miliseconds) {
		$Cayita_Fn.runAfterFn()(callback, miliseconds);
	};
	$Cayita_Fn.delay = function(callback, miliseconds) {
		$Cayita_Fn.delayFn(callback, miliseconds);
	};
	$Cayita_Fn.getProperties = function(o) {
		var keys = Object.keys(o);
		var r = [];
		for (var $t1 = 0; $t1 < keys.length; $t1++) {
			var i = keys[$t1];
			if (!!(typeof(o[i]) !== 'function')) {
				ss.add(r, i);
			}
		}
		return Array.prototype.slice.call(r);
	};
	$Cayita_Fn.copyFrom = function(target, source) {
		var p = $Cayita_Fn.getProperties(source);
		for (var $t1 = 0; $t1 < p.length; $t1++) {
			var s = p[$t1];
			target[s] = source[s];
		}
	};
	$Cayita_Fn.populateFrom = function(target, source) {
		var tp = $Cayita_Fn.getProperties(target);
		var sp = $Cayita_Fn.getProperties(source);
		for (var $t1 = 0; $t1 < tp.length; $t1++) {
			var s = tp[$t1];
			if (ss.contains(sp, s)) {
				target[s] = source[s];
			}
		}
	};
	$Cayita_Fn.clone = function(target) {
		var source = {};
		$Cayita_Fn.copyFrom(target, source);
		return source;
	};
	$Cayita_Fn.normalize = function(date) {
		if (ss.staticEquals(date, null)) {
			return null;
		}
		var d = new Date(parseFloat((new RegExp('//Date\\(([^)]+)\\)//')).exec($Cayita_Fn.fmt('/{0}/', [date]))[1]));
		return new Date(d.getUTCFullYear(), d.getUTCMonth() + 1 - 1, d.getUTCDate(), d.getUTCHours(), d.getUTCMinutes(), d.getUTCSeconds());
	};
	$Cayita_Fn.$get = function(o, property) {
		return o[property];
	};
	$Cayita_Fn.$get$1 = function(T) {
		return function(o, property) {
			return ss.cast(o[property], T);
		};
	};
	$Cayita_Fn.someClass = function(name) {
		var age = null;
		this.name = name;
		this.showName = function() {
			console.log(this.name);
		};
		this.setAge = function(a) {
			age = a;
		};
		this.showAge = function() {
			console.log('Age;', age);
		};
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.FormUpdatedAction
	var $Cayita_FormUpdatedAction = function() {
	};
	$Cayita_FormUpdatedAction.prototype = { clear: 0, populate: 1 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.Plugins
	var $Cayita_Plugins = function() {
	};
	$Cayita_Plugins.BootboxOptions = function() {
		return {
			onEscape: function() {
			}
		};
	};
	$Cayita_Plugins.showBootboxDialog = function(message, handlers, options) {
		bootbox.dialog(message, handlers || [], options || Cayita.Plugins.BootboxOptions());
	};
	$Cayita_Plugins.PopoverOptions = function() {
		return { animation: true, placement: 'right', trigger: 'click', title: '', content: '' };
	};
	$Cayita_Plugins.popover = function(e, options) {
		return $(e).popover(options || Cayita.Plugins.PopoverOptions());
	};
	$Cayita_Plugins.popoverInit = function(o, options) {
		o.popover('destroy');
		o.popover(options);
	};
	$Cayita_Plugins.NumericOptions = function() {
		var o = {};
		o.vMax = 9.00719925474099E+15;
		o.vMin = -9.00719925474099E+15;
		return o;
	};
	$Cayita_Plugins.AutoNumeric = function(input, options) {
		$Cayita_Plugins.$init(input, options);
		var methods = {};
		methods['get'] = function(r) {
			return $Cayita_Plugins.$getValue(input, false);
		};
		methods['set'] = function(v) {
			$Cayita_Plugins.$setValue(input, v);
		};
		methods['init'] = function(o) {
			$Cayita_Plugins.$init(input, o);
		};
		methods['update'] = function(o1) {
			$Cayita_Plugins.$update(input, o1);
		};
		methods['getSettings'] = function() {
			return $Cayita_Plugins.$getSettings(input);
		};
		input.autoNumeric = methods;
		return input;
	};
	$Cayita_Plugins.$getValue = function(input, required) {
		var v = $(input)['autoNumeric']('get', null);
		return (required ? (parseFloat(v) || 0) : ((v == '0') ? 0 : (parseFloat(v) || null)));
	};
	$Cayita_Plugins.$setValue = function(input, value) {
		$(input)['autoNumeric']('set', value);
	};
	$Cayita_Plugins.$init = function(input, options) {
		if (input.hasAttribute('autonumeric')) {
			return;
		}
		$Cayita_Plugins.$initImp(input, options);
	};
	$Cayita_Plugins.$update = function(input, options) {
		if (!input.hasAttribute('autonumeric')) {
			$Cayita_Plugins.$initImp(input, options);
		}
		else {
			$(input)['autoNumeric']('update', options);
		}
	};
	$Cayita_Plugins.$getSettings = function(input) {
		if (!input.hasAttribute('autonumeric')) {
			$Cayita_Plugins.$initImp(input, null);
		}
		return $(input)['autoNumeric']('getSettings', null);
	};
	$Cayita_Plugins.$initImp = function(input, options) {
		input.setAttribute('autonumeric', true);
		input.setAttribute('data-type', 'numeric');
		input.style.cssText = 'text-align:right;';
		$(input)['autoNumeric']('init', options);
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.UI
	var $Cayita_UI = function() {
	};
	$Cayita_UI.Button = function(text, className, type, action, parent) {
		return $Cayita_UI.Atom('button', ss.coalesce(type, 'button'), ss.coalesce(className, 'btn'), text, action, parent);
	};
	$Cayita_UI.ResetButton = function(text, action, parent) {
		return $Cayita_UI.Button(text, 'btn', 'reset', action, parent);
	};
	$Cayita_UI.SubmitButton = function(text, action, parent) {
		return $Cayita_UI.Button(text, 'btn', 'submit', action, parent);
	};
	$Cayita_UI.ButtonIcon = function(iconClass, action, parent) {
		var e = $Cayita_UI.Button(null, 'btn', 'button', null, null);
		e.icon = Cayita.UI.Atom('i', null, iconClass);
		e.get_iconClass = function() {
			return e.icon.className;
		};
		e.set_iconClass = function(v) {
			e.icon.className = v;
		};
		e.append(e.icon);
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.Atom = function(tagName, type, className, text, action, parent) {
		var e = document.createElement(tagName);
		if ($Cayita_UI.AutoId) {
			e.createId();
		}
		if (!ss.isNullOrEmptyString(type)) {
			e.type = type;
		}
		if (!ss.isNullOrEmptyString(className)) {
			e.className = className;
		}
		if (!ss.isNullOrEmptyString(text)) {
			$(e).append($Cayita_UI.$BuildText(text));
		}
		e.is_hidden = function() {
			return !$(e).is(':visible');
		};
		e.do_hide = function(v) {
			if (!ss.isValue(v) || ss.Nullable.unbox(v)) {
				$(e).hide();
			}
			else {
				$(e).show();
			}
		};
		e.append = function(c) {
			$(e).append(c.parentNode || c);
		};
		e.toString = function() {
			return e.innerHTML;
		};
		e.get_text = function() {
			return $Cayita_UI.$GetText(e);
		};
		e.set_text = function(v1) {
			$Cayita_UI.$SetText(e, v1);
		};
		e.createId = function() {
			return $Cayita_UI.$CreateId(e);
		};
		e.set_setTextFn = function(v2) {
			$Cayita_UI.$SetTextFn(e, v2);
		};
		e.set_getTextFn = function(v3) {
			$Cayita_UI.$GetTextFn(e, v3);
		};
		e.add_handler = function(name, ev, se, co) {
			$Cayita_UI.$On(e, name, ev, se, co);
		};
		e.remove_handler = function(name1, ev1, se1) {
			$Cayita_UI.$Off(e, name1, ev1, se1);
		};
		e.add_clicked = function(ev2, se2) {
			$Cayita_UI.$OnClick(e, ev2, se2);
		};
		e.remove_clicked = function(ev3, se3) {
			$Cayita_UI.$OffClick(e, ev3, se3);
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.Anchor = function(className, href, text) {
		var e = $Cayita_UI.Atom('a', null, className, text, null, null);
		if (!ss.isNullOrEmptyString(href)) {
			e.href = href;
		}
		return e;
	};
	$Cayita_UI.Label = function(className, text, action, parent) {
		var e = $Cayita_UI.Atom('label', null, className, text, null, null);
		e.get_for = function() {
			return ss.coalesce(e.getAttribute('for'), '').toString();
		};
		e.set_for = function(v) {
			e.setAttribute('for', v);
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.ControlGroup = function() {
		var e = Cayita.UI.Atom('div', null, $Cayita_UI.ControlGroupClassName);
		e.label = Cayita.UI.Label($Cayita_UI.ControlLabelClassName);
		e.controls = Cayita.UI.Atom('div', null, $Cayita_UI.ControlsClassName);
		$(e).append(e.label).append(e.controls);
		e.get_text = function() {
			return e.label.get_text();
		};
		e.set_text = function(v) {
			e.label.set_text(v);
		};
		return e;
	};
	$Cayita_UI.Input = function(T) {
		return function(tagName, type, className, name, placeholder, action, parent) {
			var e = $Cayita_UI.Atom(tagName, type, className, null, null, null);
			e.minLengthMsgFn = function(i) {
				return $Cayita_Fn.fmt('Min {0} chars', [i.get_minLength()]);
			};
			e._minLength = 0;
			if (!ss.isNullOrEmptyString(name)) {
				e.name = name;
			}
			if (!ss.isNullOrEmptyString(placeholder)) {
				e.placeholder = placeholder;
			}
			e.get_value = function() {
				return $Cayita_UI.$GetValue(T).call(null, e);
			};
			e.set_value = function(v) {
				$Cayita_UI.$SetValue(e, v);
			};
			e.set_setValueFn = function(v1) {
				$Cayita_UI.$SetValueFn(T).call(null, e, v1);
			};
			e.set_getValueFn = function(v2) {
				$Cayita_UI.$GetValueFn(T).call(null, e, v2);
			};
			e.add_changed = function(ev, se) {
				$Cayita_UI.$OnChange(e, ev, se);
			};
			e.removed_changed = function(ev1, se1) {
				$Cayita_UI.$OffChange(e, ev1, se1);
			};
			e.get_minLength = function() {
				return e._minLength;
			};
			e.set_minLength = function(v3) {
				e.pattern = $Cayita_Fn.fmt('.{{0},}', [v3]);
				e._minLength = v3;
			};
			e.checkValidity = function() {
				e.setCustomValidity('');
				var r = e.validity.valid;
				if (!r && e.validity.patternMismatch && e.get_minLength() > 0) {
					e.setCustomValidity(e.minLengthMsgFn(e));
				}
				return r;
			};
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.AutoNumeric = function(T) {
		return function(options, className, name, placeholder, action, parent) {
			var e = $Cayita_UI.Input(T).call(null, 'input', 'text', className, name, placeholder, null, null);
			$Cayita_Plugins.AutoNumeric(e, options);
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.NullableNumericInput = function(options, className, name, placeholder, action, parent) {
		var $t2 = options;
		if (ss.isNullOrUndefined($t2)) {
			var $t1 = Cayita.Plugins.NumericOptions();
			$t1.lZero = 'deny';
			$t2 = $t1;
		}
		return $Cayita_UI.AutoNumeric(ss.Nullable).call(null, $t2, className, name, placeholder, action, parent);
	};
	$Cayita_UI.NumericInput = function(options, className, name, placeholder, action, parent) {
		var $t2 = options;
		if (ss.isNullOrUndefined($t2)) {
			var $t1 = Cayita.Plugins.NumericOptions();
			$t1.wEmpty = 'zero';
			$t1.lZero = 'deny';
			$t2 = $t1;
		}
		return $Cayita_UI.AutoNumeric(Number).call(null, $t2, className, name, placeholder, action, parent);
	};
	$Cayita_UI.IntInput = function(options, className, name, placeholder, action, parent) {
		var $t2 = options;
		if (ss.isNullOrUndefined($t2)) {
			var $t1 = Cayita.Plugins.NumericOptions();
			$t1.wEmpty = 'zero';
			$t1.lZero = 'deny';
			$t1.mDec = 0;
			$t2 = $t1;
		}
		return $Cayita_UI.AutoNumeric(ss.Int32).call(null, $t2, className, name, placeholder, action, parent);
	};
	$Cayita_UI.NullableIntInput = function(options, className, name, placeholder, action, parent) {
		var $t2 = options;
		if (ss.isNullOrUndefined($t2)) {
			var $t1 = Cayita.Plugins.NumericOptions();
			$t1.lZero = 'deny';
			$t1.mDec = 0;
			$t2 = $t1;
		}
		return $Cayita_UI.AutoNumeric(ss.Nullable).call(null, $t2, className, name, placeholder, action, parent);
	};
	$Cayita_UI.CheckInput = function(T) {
		return function(className, name, text, action, parent) {
			var e = $Cayita_UI.Input(T).call(null, 'input', 'checkbox', className, name, null, null, null);
			e.label = $Cayita_UI.Label('checkbox', null, null, null);
			e.label.set_text(ss.coalesce(text, ''));
			$(e.label).append(e);
			e.get_text = function() {
				return e.label.get_text();
			};
			e.set_text = function(v) {
				e.label.set_text(v);
			};
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.BooleanCheck = function(className, name, text, action, parent) {
		var e = $Cayita_UI.CheckInput(Boolean).call(null, className, name, text, null, null);
		e.set_value(true);
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.RadioInput = function(T) {
		return function(className, name, text, action, parent) {
			var e = $Cayita_UI.Input(T).call(null, 'input', 'radio', className, name, null, null, null);
			e.label = $Cayita_UI.Label('radio', null, null, null);
			e.label.set_text(ss.coalesce(text, ''));
			$(e.label).append(e);
			e.get_text = function() {
				return e.label.get_text();
			};
			e.set_text = function(v) {
				e.label.set_text(v);
			};
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.BooleanRadioInput = function(className, name, text, action, parent) {
		var e = $Cayita_UI.RadioInput(Boolean).call(null, className, name, text, null, null);
		e.set_value(true);
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.FileInput = function(className, name, placeholder) {
		return $Cayita_UI.Input(String).call(null, 'input', 'file', className, name, placeholder, null, null);
	};
	$Cayita_UI.DateInput = function(options, className, name, placeholder, action, parent) {
		return $Cayita_UI.$BuildDateInput(Element).call(null, options, className, name, placeholder, action, parent);
	};
	$Cayita_UI.NullableDateInput = function(options, className, name, placeholder, action, parent) {
		return $Cayita_UI.$BuildDateInput(Element).call(null, options, className, name, placeholder, action, parent);
	};
	$Cayita_UI.HtmlList = function(className) {
		return $Cayita_UI.Atom('ul', null, className, null, null, null);
	};
	$Cayita_UI.$BuildDateInput = function(T) {
		return function(options, className, name, placeholder, action, parent) {
			var e = $Cayita_UI.Input(Date).call(null, 'input', 'text', className, name, placeholder, null, null);
			e.picker = $(e).datepicker(options);
			e.setAttribute('datepicker', true);
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.$BuildText = function(text) {
		return $Cayita_Fn.fmt('<ctxt>{0}</ctxt>', [text]);
	};
	$Cayita_UI.$SetTextFn = function(el, func) {
		el.get_text = function(v) {
			func(el, v);
		};
	};
	$Cayita_UI.$GetTextFn = function(el, func) {
		el.set_text = function() {
			return func(el);
		};
	};
	$Cayita_UI.$SetValueFn = function(T) {
		return function(el, func) {
			el.set_value = function(v) {
				func(el, v);
			};
		};
	};
	$Cayita_UI.$GetValueFn = function(T) {
		return function(el, func) {
			el.get_value = function() {
				return func(el);
			};
		};
	};
	$Cayita_UI.$CreateId = function(e) {
		var id = { $: 0 };
		$Cayita_UI.$tags.tryGetValue(e.tagName, id);
		$Cayita_UI.$tags.set_item(e.tagName, ++id.$);
		e.id = $Cayita_Fn.fmt('{0}-{1}', [e.tagName.toLowerCase(), id.$]);
		return e.id;
	};
	$Cayita_UI.$SetText = function(atom, value) {
		var v = ss.coalesce(value, '');
		var ctxt = $($Cayita_UI.CTextTag, atom);
		if (ctxt.length === 0) {
			$(atom).append($Cayita_UI.$BuildText(v));
		}
		else {
			ctxt.html(v);
		}
	};
	$Cayita_UI.$GetText = function(atom) {
		var ctxt = $($Cayita_UI.CTextTag, atom);
		return ((ctxt.length === 0) ? '' : ctxt.html());
	};
	$Cayita_UI.$SetValue = function(atom, value) {
		var type = atom.type.toString();
		if (type === 'radio' || type === 'checkbox' || type === 'select-one' || type === 'select-multiple' || type === 'option') {
			atom.Object = value;
			atom.value = ss.coalesce(value, '');
		}
		else if (atom.hasAttribute('autonumeric')) {
			$(atom)['autoNumeric']('set', value);
		}
		else if (atom.hasAttribute('datepicker')) {
			$(atom)['datepicker']('setDate', value);
		}
		else {
			atom.value = ss.coalesce(value, '');
		}
	};
	$Cayita_UI.$GetValue = function(T) {
		return function(atom) {
			var r;
			var type = atom.type.toString();
			if (type === 'select-one' || type === 'select-multiple') {
				var index = atom.selectedIndex;
				r = ((index < 0) ? null : atom.options[index].Object);
			}
			else if (atom.hasAttribute('autonumeric')) {
				var $t1 = $(atom)['autoNumeric']('get', null);
				r = (($t1 == '0') ? 0 : (parseFloat($t1) || null));
			}
			else if (atom.hasAttribute('datepicker')) {
				r = $(atom)['datepicker']('getDate', null);
			}
			else {
				var $t2 = atom.Object;
				if (ss.isNullOrUndefined($t2)) {
					$t2 = atom.value;
				}
				r = $t2;
			}
			return r;
		};
	};
	$Cayita_UI.$On = function(atom, eventName, eventHandler, selector, context) {
		var data = {};
		data['context'] = context;
		$(atom).on(eventName, selector, data, eventHandler);
	};
	$Cayita_UI.$Off = function(atom, eventName, eventHandler, selector) {
		$(atom).off(eventName, selector, eventHandler);
	};
	$Cayita_UI.$OnClick = function(atom, eventHandler, selector) {
		$(atom).on('click', selector, eventHandler);
	};
	$Cayita_UI.$OffClick = function(atom, eventHandler, selector) {
		$(atom).off('click', selector, eventHandler);
	};
	$Cayita_UI.$OnChange = function(atom, eventHandler, selector) {
		$(atom).on('change', selector, eventHandler);
	};
	$Cayita_UI.$OffChange = function(atom, eventHandler, selector) {
		$(atom).off('change', selector, eventHandler);
	};
	$Cayita_UI.CreateDiv = function(parent, action, className) {
		var d = Cayita.UI.Atom('div', null, className);
		if (!ss.staticEquals(action, null)) {
			action(d);
		}
		if (ss.isValue(parent)) {
			parent.append(d);
		}
		return d;
	};
	$Cayita_UI.CreateContainerFluid$1 = function(parent, action) {
		return $Cayita_UI.CreateDiv(parent, action, 'container-fluid');
	};
	$Cayita_UI.CreateContainerFluid = function(action) {
		return $Cayita_UI.CreateDiv(null, action, 'container-fluid');
	};
	$Cayita_UI.CreateContainer$1 = function(parent, action) {
		return $Cayita_UI.CreateDiv(parent, action, 'container');
	};
	$Cayita_UI.CreateContainer = function(action) {
		return $Cayita_UI.CreateDiv(null, action, 'container');
	};
	$Cayita_UI.CreateRowFluid$1 = function(parent, action) {
		return $Cayita_UI.CreateDiv(parent, action, 'row-fluid');
	};
	$Cayita_UI.CreateRowFluid = function(action) {
		return $Cayita_UI.CreateDiv(null, action, 'row-fluid');
	};
	$Cayita_UI.CreateRow$1 = function(parent, action) {
		return $Cayita_UI.CreateDiv(parent, action, 'row');
	};
	$Cayita_UI.CreateRow = function(action) {
		return $Cayita_UI.CreateDiv(null, action, 'row');
	};
	$Cayita_UI.Form = function(parent, action) {
		var e = $Cayita_UI.Atom('form', null, null, null, action, parent);
		e._updated = function(f, a) {
		};
		e._validate = function(i) {
			if (ss.isNullOrUndefined(i.errorMessage) && !i.validity.valid) {
				var $t1 = Cayita.Plugins.PopoverOptions();
				$t1.trigger = 'manual';
				$t1.content = 'OK';
				i.errorMessage = $Cayita_Plugins.popover(i, $t1);
				i.errorMessage.popover('show');
			}
			if (i.checkValidity()) {
				if (ss.isValue(i.errorMessage)) {
					i.errorMessage.popover('destroy');
					i.errorMessage = null;
				}
				return true;
			}
			else {
				$('.popover-content', i.nextSibling).first().html(i.validationMessage);
				return false;
			}
		};
		e._clear = function(f1) {
			f1.reset();
			var inputs = f1.get_inputs();
			for (var $t2 = 0; $t2 < inputs.length; $t2++) {
				var i1 = inputs[$t2];
				if (ss.isValue(i1.errorMessage)) {
					i1.errorMessage.popover('destroy');
					i1.errorMessage = null;
				}
			}
		};
		e.setAttribute('novalidate', 'novalidate');
		e.clear = function() {
			e._clear(e);
			$(e).data('_source_', $(e).serialize());
			e._updated(e, 0);
		};
		e.populateFrom = function(d) {
			e._clear(e);
			var $t3 = new ss.ObjectEnumerator(d);
			try {
				while ($t3.moveNext()) {
					var p = { $: $t3.current() };
					var o = $($Cayita_Fn.fmt('[name=\'{0}\']', [p.$.key]), e);
					o.each(ss.mkdel({ p: p }, function(index, element) {
						var atom = element;
						var value = this.p.$.value;
						var type = atom.type.toString();
						if (type === 'radio') {
							if (ss.staticEquals(value, atom.get_value())) {
								atom.checked = true;
							}
						}
						else if (type === 'checkbox') {
							if (!Array.isArray(value)) {
								if (ss.staticEquals(value, true)) {
									atom.checked = true;
								}
							}
							else {
								var a1 = value;
								if (ss.indexOf(a1, atom.get_value()) > 0) {
									atom.checked = true;
								}
							}
						}
						else if (type === 'select-multiple' && Array.isArray(value)) {
							var a2 = value;
							for (var $t4 = 0; $t4 < a2.length; $t4++) {
								var item = a2[$t4];
								var q = $($Cayita_Fn.fmt('option[value={0}]', [item]), atom);
								if (q.length > 0) {
									q.get(0).selected = true;
								}
							}
						}
						else if (atom.hasAttribute('autonumeric')) {
							$(atom)['autoNumeric']('set', value);
						}
						else if (atom.hasAttribute('datepicker')) {
							$(atom)['datepicker']('setDate', value);
						}
						else {
							atom.value = ss.coalesce(value, '');
						}
					}));
				}
			}
			finally {
				$t3.dispose();
			}
			$(e).data('_source_', $(e).serialize());
			e._updated(e, 1);
		};
		e.populate = function(d1) {
			var $t5 = new ss.ObjectEnumerator(d1);
			try {
				while ($t5.moveNext()) {
					var p1 = $t5.current();
					var o1 = $($Cayita_Fn.fmt('[name=\'{0}\']', [p1.key]), e);
					if (o1.length === 0) {
						continue;
					}
					var r = { $: [] };
					o1.each(ss.mkdel({ r: r }, function(index1, element1) {
						var input = element1;
						var type1 = input.type;
						if (type1 === 'radio') {
							if (ss.staticEquals(input.checked, true)) {
								ss.add(this.r.$, input.get_value());
							}
						}
						else if (type1 === 'checkbox') {
							if (ss.staticEquals(input.get_value(), true)) {
								ss.add(this.r.$, ss.staticEquals(input.checked, true));
							}
							else if (ss.staticEquals(input.checked, true)) {
								ss.add(this.r.$, input.get_value());
							}
						}
						else if (type1 === 'select-one' || type1 === 'select-multiple') {
							var q1 = $('option:selected', element1);
							q1.each(ss.mkdel({ r: this.r }, function(i2, el) {
								ss.add(this.r.$, el.get_value());
							}));
						}
						else {
							ss.add(this.r.$, input.get_value());
						}
					}));
					if (!Array.isArray(p1.value)) {
						if (r.$.length > 0) {
							d1[p1.key] = r.$[0];
						}
					}
					else {
						d1[p1.key] = r.$;
					}
				}
			}
			finally {
				$t5.dispose();
			}
		};
		e.get_inputs = function() {
			return $('input,select,textarea', e).get();
		};
		e.checkValidity = function() {
			var inputs1 = e.get_inputs();
			for (var $t6 = 0; $t6 < inputs1.length; $t6++) {
				var i3 = inputs1[$t6];
				if (!i3.checkValidity()) {
					return false;
				}
			}
			return true;
		};
		e.hasChanges = function() {
			return !ss.referenceEquals($(e).serialize(), $(e).data('_source_').toString());
		};
		e.add_changed = function(hdl) {
			$(e).on('change', hdl);
		};
		e.remove_changed = function(hdl1) {
			$(e).off('change', '', hdl1);
		};
		e.add_updated = function(v) {
			e._updated = ss.delegateCombine(e._updated, v);
		};
		e.remove_updated = function(v1) {
			e._updated = ss.delegateRemove(e._updated, v1);
		};
		$(e).on('keyup', 'input[type!=radio]input[type!=checkbox],select,textarea', function(ev) {
			e._validate(ev.currentTarget);
		});
		$(e).on('change', 'input[type=radio],input[type=checkbox]', function(ev1) {
			var type2 = ev1.currentTarget.type.toString();
			e._validate($($Cayita_Fn.fmt('input[type={0}][name={1}]', [type2, ev1.currentTarget.name]), e).last().get(0));
		});
		$(e).on('change', 'select', function(ev2) {
			e._validate(ev2.currentTarget);
		});
		$(e).on('submit', function(ev3) {
			ev3.preventDefault();
			var inputs2 = e.get_inputs();
			var v2 = true;
			for (var $t7 = 0; $t7 < inputs2.length; $t7++) {
				var i4 = inputs2[$t7];
				var type3 = i4.type.toString();
				if (type3 === 'radio' || type3 === 'checkbox') {
					v2 = e._validate($($Cayita_Fn.fmt('input[type={0}][name={1}]', [type3, i4.name]), e).last().get(0)) && v2;
				}
				else {
					v2 = e._validate(i4) && v2;
				}
			}
			if (v2 && !ss.staticEquals(e.submitHandler, null)) {
				e.submitHandler(e);
			}
		});
		return e;
	};
	$Cayita_UI.SpinnerIcon = function(message) {
		var e = $Cayita_UI.Atom('div', null, 'well well-large lead', null, null, null);
		e.icon = $Cayita_UI.Atom('i', null, 'icon-spinner icon-spin icon-2x pull-left', null, null, null);
		e.append(e.icon);
		e.set_text((!ss.isNullOrEmptyString(message) ? message : ''));
		return e;
	};
	$Cayita_UI.DropdownMenu = function(text, iconClass) {
		var o = $Cayita_UI.$CreateMenuBase(text, iconClass, true, 'dropdown');
		o.className = 'dropdown-toggle';
		o.setAttribute('role', 'button');
		o.setAttribute('data-toggle', 'dropdown');
		o.nav.setAttribute('role', 'menu');
		return o;
	};
	$Cayita_UI.DropdownSubmenu = function(text, iconClass) {
		var o = $Cayita_UI.$CreateMenuBase(text, iconClass, false, 'dropdown-submenu');
		$(o).on('click', function(e) {
			e.preventDefault();
		});
		return o;
	};
	$Cayita_UI.$CreateMenuBase = function(text, iconClass, caret, parentClass) {
		var a = Cayita.UI.Anchor(null, '#');
		a.tabIndex = -1;
		a.icon = Cayita.UI.Atom('i', null, iconClass);
		$(a).append(a.icon).append($Cayita_UI.$BuildText(text) + (caret ? '<b class=\'caret\'></b>' : ''));
		a.nav = $Cayita_UI.CreateNavBase(null);
		a.nav.className = 'dropdown-menu';
		a.get_iconClass = function() {
			return a.icon.className;
		};
		a.set_iconClass = function(v) {
			a.icon.className = v;
		};
		a.addTo = function(v1) {
			$(v1).append(a).append(a.nav).addClass(parentClass);
		};
		return a;
	};
	$Cayita_UI.CheckField = function(name, text, action, parent) {
		return $Cayita_UI.Field(Boolean).call(null, function() {
			return $Cayita_UI.BooleanCheck('', name, text, null, null);
		}, action, parent);
	};
	$Cayita_UI.TextAreaField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(String).call(null, function() {
			return $Cayita_UI.Input(String).call(null, 'textarea', null, null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.SelectField = function(T) {
		return function(type, action, parent) {
			return $Cayita_UI.Field(T).call(null, function() {
				return $Cayita_UI.SelectInput(T).call(null, type, '');
			}, action, parent);
		};
	};
	$Cayita_UI.TextField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(String).call(null, function() {
			return $Cayita_UI.Input(String).call(null, 'input', 'text', null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.PasswordField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(String).call(null, function() {
			return $Cayita_UI.Input(String).call(null, 'input', 'password', null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.EmailField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(String).call(null, function() {
			return $Cayita_UI.Input(String).call(null, 'input', 'email', null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.NumericField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(Number).call(null, function() {
			return $Cayita_UI.NumericInput(null, null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.NullableNumericField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(ss.Nullable).call(null, function() {
			return $Cayita_UI.NullableNumericInput(null, null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.IntField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(ss.Int32).call(null, function() {
			return $Cayita_UI.IntInput(null, null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.NullableIntField = function(name, placeholder, action, parent) {
		return $Cayita_UI.Field(ss.Nullable).call(null, function() {
			return $Cayita_UI.NullableIntInput(null, null, name, placeholder, null, null);
		}, action, parent);
	};
	$Cayita_UI.DateField = function(options, name, placeholder, action, parent) {
		var e = $Cayita_UI.Field(Date).call(null, function() {
			return $Cayita_UI.DateInput(options, null, null, null, null, null);
		}, null, null);
		e.get_picker = function() {
			return e.input.picker;
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.NullableDateField = function(options, name, placeholder, action, parent) {
		var e = $Cayita_UI.Field(ss.Nullable).call(null, function() {
			return $Cayita_UI.NullableDateInput(options, null, null, null, null, null);
		}, null, null);
		e.get_picker = function() {
			return e.input.picker;
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.Field = function(T) {
		return function(factory, action, parent) {
			var e = $Cayita_UI.ControlGroup();
			e.input = factory();
			$(e.controls).append(e.input.parentNode || e.input);
			e.appendAddon = function(c) {
				$Cayita_UI.$AppendAddon(T).call(null, e, c);
			};
			e.appendStringAddon = function(c1) {
				$Cayita_UI.$AppendStringAddon(T).call(null, e, c1);
			};
			e.prependAddon = function(c2) {
				$Cayita_UI.$PrependAddon(T).call(null, e, c2);
			};
			e.prependStringAddon = function(c3) {
				$Cayita_UI.$PrependStringAddon(T).call(null, e, c3);
			};
			e.add_changed = function(ev) {
				e.input.add_changed(ev);
			};
			e.removed_changed = function(ev1) {
				e.input.remove_changed(ev1);
			};
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.$AppendAddon = function(T) {
		return function(field, atom) {
			$(field.controls).addClass('input-append');
			if (atom.tagName === 'BUTTON') {
				$(field.input).after($(atom));
			}
			else {
				var sp = $Cayita_UI.Atom('span', null, 'add-on', null, null, null);
				$(sp).append(atom);
				$(field.input).after($(sp));
			}
		};
	};
	$Cayita_UI.$AppendStringAddon = function(T) {
		return function(field, content) {
			$(field.controls).addClass('input-append');
			var sp = $Cayita_UI.Atom('span', null, 'add-on', null, null, null);
			$(sp).append(content);
			$(field.input).after($(sp));
		};
	};
	$Cayita_UI.$PrependAddon = function(T) {
		return function(field, atom) {
			$(field.controls).addClass('input-prepend');
			if (atom.tagName === 'BUTTON') {
				$(field.input).before($(atom));
			}
			else {
				var sp = $Cayita_UI.Atom('span', null, 'add-on', null, null, null);
				$(sp).append(atom);
				$(field.input).before($(sp));
			}
		};
	};
	$Cayita_UI.$PrependStringAddon = function(T) {
		return function(field, content) {
			$(field.controls).addClass('input-prepend');
			var sp = $Cayita_UI.Atom('span', null, 'add-on', null, null, null);
			$(sp).append(content);
			$(field.input).before($(sp));
		};
	};
	$Cayita_UI.CreateFileFieldBase = function(factory) {
		var e = $Cayita_UI.ControlGroup();
		e.input = factory();
		$(e.controls).addClass('fileupload fileupload-new');
		e.controls.setAttribute('data-provides', 'fileupload');
		e._divinput = Cayita.UI.Atom('div', null, 'input-append');
		e._spanfile = Cayita.UI.Atom('span', null, 'btn btn-file');
		e._spanfileopen = Cayita.UI.Atom('span', null, 'fileupload-new');
		e.fileOpenIcon = Cayita.UI.Atom('i', null, 'icon-folder-open');
		$(e._spanfileopen).append(e.fileOpenIcon);
		var spanFileChange = Cayita.UI.Atom('span', null, 'fileupload-exists');
		e.fileChangeIcon = Cayita.UI.Atom('i', null, 'icon-folder-open');
		$(spanFileChange).append(e.fileChangeIcon);
		$(e._spanfile).append(e._spanfileopen).append(spanFileChange).append(e.input);
		var anchorFileRemove = Cayita.UI.Anchor('btn fileupload-exists', '#', null);
		anchorFileRemove.setAttribute('data-dismiss', 'fileupload');
		e.fileRemoveIcon = Cayita.UI.Atom('i', null, 'icon-remove');
		$(anchorFileRemove).append(e.fileRemoveIcon);
		$(e._divinput).append(e._spanfile).append(anchorFileRemove);
		$(e.controls).append(e._divinput);
		e.appendAddon = function(c) {
			$Cayita_UI.$AppendAddon(String).call(null, e, c);
		};
		e.appendStringAddon = function(c1) {
			$Cayita_UI.$AppendStringAddon(String).call(null, e, c1);
		};
		e.prependAddon = function(c2) {
			$Cayita_UI.$PrependAddon(String).call(null, e, c2);
		};
		e.prependStringAddon = function(c3) {
			$Cayita_UI.$PrependStringAddon(String).call(null, e, c3);
		};
		e.set_fileOpenText = function(c4) {
			e._spanfileopen.set_text(c4);
		};
		e.get_fileOpenText = function() {
			return e._spanfileopen.get_text();
		};
		e.set_fileChangeText = function(c5) {
			spanFileChange.set_text(c5);
		};
		e.get_fileChangeText = function() {
			return spanFileChange.get_text();
		};
		e.set_FileRemoveText = function(c6) {
			anchorFileRemove.set_text(c6);
		};
		e.get_fileRemoveText = function() {
			return anchorFileRemove.get_text();
		};
		e.add_changed = function(ev) {
			e.input.add_changed(ev);
		};
		e.removed_changed = function(ev1) {
			e.input.remove_changed(ev1);
		};
		return e;
	};
	$Cayita_UI.FileField = function(name, placeholder, action, parent) {
		var e = $Cayita_UI.CreateFileFieldBase(function() {
			return $Cayita_UI.FileInput(null, name, placeholder);
		});
		e._uneditable = Cayita.UI.Atom('div', null, 'uneditable-input span3');
		e._inputSize = 'span3';
		$(e._uneditable).append(Cayita.UI.Atom('i', null, 'icon-file fileupload-exists')).append(Cayita.UI.Atom('span', null, 'fileupload-preview'));
		$('.btn-file', e.controls).before(e._uneditable);
		e.get_inputSize = function() {
			return $Cayita_UI.$GetInputSize(e);
		};
		e.set_inputSize = function(v) {
			$Cayita_UI.$SetInputSize(e, v);
		};
		e.hidePreview = function(v1) {
			$Cayita_UI.$HideFileBox(e, v1);
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.ImgField = function(name, placeholder, action, parent) {
		var e = $Cayita_UI.CreateFileFieldBase(function() {
			return $Cayita_UI.FileInput(null, name, placeholder);
		});
		e.input.accept = 'image/*';
		e.thumbnail = Cayita.UI.Atom('div', null, 'fileupload-new thumbnail');
		e.thumbnail.style.cssText = $Cayita_Fn.fmt('width:{0}; height:{1};', ['200px', '150px']);
		e.emptyImg = Cayita.UI.Atom('img', null, null);
		e.emptyImg.src = $Cayita_UI.EmptyImgSrc;
		$(e.thumbnail).append(e.emptyImg);
		e.thumbnailPreview = Cayita.UI.Atom('div', null, 'fileupload-preview fileupload-exists thumbnail');
		e.thumbnailPreview.style.cssText = $Cayita_Fn.fmt('width:{0}; height:{1};', ['200px', '150px']);
		$('.input-append', e.controls).removeClass('input-append').before(e.thumbnail).before(e.thumbnailPreview);
		e.hidePreview = function(v) {
			$Cayita_UI.$HideImgBox(e, v);
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.$SetInputSize = function(field, value) {
		$(field._uneditable).removeClass($Cayita_Fn.fmt('{0}', [field.get_inputSize()])).addClass(value);
		field._inputSize = value;
	};
	$Cayita_UI.$GetInputSize = function(field) {
		return field._inputSize;
	};
	$Cayita_UI.$HideFileBox = function(field, hide) {
		var j = $(field._uneditable);
		if (hide) {
			j.hide();
		}
		else {
			j.show();
		}
	};
	$Cayita_UI.$HideImgBox = function(field, hide) {
		var j = $(field.thumbnail);
		var q = $(field.thumbnailPreview);
		if (hide) {
			j.hide();
			q.hide();
		}
		else {
			j.show();
			q.show();
		}
	};
	$Cayita_UI.SelectedGridRow = function(T) {
		return function() {
			return { row: null, recordId: null, record: ss.createInstance(T) };
		};
	};
	$Cayita_UI.GridRequestMessage = function() {
		return { target: null, message: null, htmlElement: null };
	};
	$Cayita_UI.Grid = function(T) {
		return function(store, columns) {
			var e = $Cayita_UI.Table(T).call(null, columns, store.get_idProperty());
			e.store = store;
			var multiple = false;
			var rowClicked = function(g, r) {
			};
			var rowSelected = function(g1, r1) {
			};
			var keydown = function(g2, evt) {
			};
			var onRowClicked = function(r2) {
				rowClicked(e, r2);
			};
			var onRowSelected = function(r3) {
				rowSelected(e, r3);
			};
			var onKeydown = function(evt1) {
				keydown(e, evt1);
			};
			var selectRowImp = function(row, triggerSelected, triggerClicked) {
				if (ss.isNullOrUndefined(row)) {
					return;
				}
				e.selectedRow = row;
				if (!e.is_multiple()) {
					e.getRows().forEach(function(r4) {
						r4.classList.remove('info');
					});
				}
				$(row).addClass('info');
				if (triggerClicked) {
					onRowClicked(row);
				}
				if (triggerSelected) {
					onRowSelected(row);
				}
			};
			var previousRow = function() {
				var row1;
				if (ss.isNullOrUndefined(e.selectedRow)) {
					row1 = e.getLastRow();
					if (ss.isNullOrUndefined(row1)) {
						return;
					}
				}
				else {
					row1 = e.selectedRow.previousSibling;
					if (ss.isNullOrUndefined(row1)) {
						store.readPreviousPage(true);
					}
				}
				selectRowImp(row1, true, false);
			};
			var nextRow = function() {
				var row2;
				if (ss.isNullOrUndefined(e.selectedRow)) {
					row2 = e.getFirstRow();
					if (ss.isNullOrUndefined(row2)) {
						return;
					}
				}
				else {
					row2 = e.selectedRow.nextSibling;
					if (ss.isNullOrUndefined(row2)) {
						store.readNextPage(true);
					}
				}
				selectRowImp(row2, true, false);
			};
			var keydownHandler = function(evt2) {
				evt2.preventDefault();
				switch (evt2.which) {
					case 34: {
						//page_down
						store.readNextPage(true);
						break;
					}
					case 33: {
						//page_up
						store.readPreviousPage(true);
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
						previousRow();
						break;
					}
					case 40: {
						nextRow();
						break;
					}
					default: {
						onKeydown(evt2);
						break;
					}
				}
			};
			e.multiple = function(m) {
				multiple = ((!ss.isValue(m) || ss.Nullable.unbox(m)) ? true : false);
			};
			e.is_multiple = function() {
				return multiple;
			};
			e.add_rowClicked = function(v) {
				rowClicked = ss.delegateCombine(rowClicked, v);
			};
			e.remove_rowClicked = function(v1) {
				rowClicked = ss.delegateRemove(rowClicked, v1);
			};
			e.add_rowSelected = function(v2) {
				rowSelected = ss.delegateCombine(rowSelected, v2);
			};
			e.remove_rowSelected = function(v3) {
				rowSelected = ss.delegateRemove(rowSelected, v3);
			};
			e.add_keydown = function(v4) {
				keydown = ss.delegateCombine(keydown, v4);
			};
			e.remove_keydown = function(v5) {
				keydown = ss.delegateRemove(keydown, v5);
			};
			e.selectRow = function(id, trigger) {
				selectRowImp(e.getRowById(id), (ss.isValue(trigger) ? ss.isValue(trigger) : true), false);
			};
			e.unSelectRow = function(id1) {
				e.getRowById(id1).classList.remove('info');
			};
			e.clearSelection = function() {
				e.getRows().forEach(function(r5) {
					r5.classList.remove('info');
				});
				e.selectedRow = null;
			};
			e.getSelected = function() {
				return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}].info', [e.id]), e).get();
			};
			e.add_handler('click', function(ev) {
				selectRowImp(ev.currentTarget, true, true);
			}, $Cayita_Fn.fmt('tbody[main] tr[tb={0}]', [e.id]), null);
			e.add_handler('keydown', function(evt3) {
				keydownHandler(evt3);
			}, '', null);
			var $t1 = Cayita.UI.GridRequestMessage();
			$t1.target = e.body;
			$t1.message = 'Reading ' + ss.getTypeName(T);
			e.readRequestMessage = $t1;
			e.readRequestStarted = function(grid) {
				var sp = Cayita.UI.SpinnerIcon(e.readRequestMessage.message);
				sp.style.position = 'fixed';
				sp.style.zIndex = 10000;
				sp.style.opacity = '0.6';
				sp.style.height = '90%';
				sp.style.width = '77%';
				e.readRequestMessage.target.append(sp);
				return sp;
			};
			e.readRequestFinished = function(grid1, el) {
				$(el).remove();
			};
			e.load(e.store, false);
			e.store.add_storeChanged(function(st, dt) {
				switch (dt.action) {
					case 1: {
						e.addRow(dt.newData);
						break;
					}
					case 12:
					case 11:
					case 2: {
						e.load(e.store, false);
						e.clearSelection();
						break;
					}
					case 3: {
						e.updateRow(dt.newData);
						break;
					}
					case 4: {
						var recordId = $Cayita_Fn.$get(dt.oldData, e.store.get_idProperty());
						$(e.getRowById(recordId)).remove();
						break;
					}
					case 5: {
						e.updateRow(dt.newData);
						break;
					}
					case 6: {
						e.addRow(dt.newData);
						break;
					}
					case 8: {
						e.updateRow(dt.newData);
						break;
					}
					case 7: {
						e.addRow(dt.newData);
						break;
					}
					case 9: {
						var id2 = $Cayita_Fn.$get(dt.oldData, e.store.get_idProperty());
						$(e.getRowById(id2)).remove();
						break;
					}
					case 10: {
						$(e.body).empty();
						e.clearSelection();
						break;
					}
				}
			});
			e.store.add_storeRequested(function(st1, request) {
				switch (request.action) {
					case 1: {
						break;
					}
					case 2: {
						if (request.state === 1) {
							e.readRequestMessage.htmlElement = e.readRequestStarted(e);
						}
						else {
							e.readRequestFinished(e, e.readRequestMessage.htmlElement);
						}
						break;
					}
					case 3: {
						break;
					}
					case 4: {
						break;
					}
					case 5: {
						break;
					}
				}
			});
			return e;
		};
	};
	$Cayita_UI.$GroupOption = function(T) {
		return function(input, value, text, selected) {
			input.set_value(value);
			input.checked = selected;
			input.set_text(ss.coalesce(text, value));
			var l = input.parentNode;
			l.setAttribute('option', true);
			l.input = input;
			return l;
		};
	};
	$Cayita_UI.CheckOption = function(T) {
		return function(value, text, selected) {
			var input = $Cayita_UI.CheckInput(T).call(null, null, null, null, null, null);
			var e = $Cayita_UI.$GroupOption(T).call(null, input, value, text, selected);
			e.className = 'checkbox';
			return e;
		};
	};
	$Cayita_UI.RadioOption = function(T) {
		return function(value, text, selected) {
			var input = $Cayita_UI.RadioInput(T).call(null, '', null, null, null, null);
			var e = $Cayita_UI.$GroupOption(T).call(null, input, value, text, selected);
			e.className = 'radio';
			return e;
		};
	};
	$Cayita_UI.CheckGroup = function(T) {
		return function(action, parent) {
			var e = $Cayita_UI.InputGroup(T).call(null);
			e.addValue = function(value, text, selected) {
				$Cayita_UI.$AddOption(T).call(null, e, $Cayita_UI.CheckOption(T).call(null, value, text, selected));
			};
			e.loadList = function(l) {
				$Cayita_UI.$LoadList$1(T).call(null, e, l, function(d) {
					return $Cayita_UI.CheckOption(T).call(null, d, null, false);
				}, false);
			};
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.RadioGroup = function(T) {
		return function(action, parent) {
			var e = $Cayita_UI.InputGroup(T).call(null);
			e.addValue = function(value, text, selected) {
				$Cayita_UI.$AddOption(T).call(null, e, $Cayita_UI.RadioOption(T).call(null, value, text, selected));
			};
			e.loadList = function(l) {
				$Cayita_UI.$LoadList$1(T).call(null, e, l, function(d) {
					return $Cayita_UI.RadioOption(T).call(null, d, null, false);
				}, false);
			};
			if (!ss.staticEquals(action, null)) {
				action(e);
			}
			if (ss.isValue(parent)) {
				parent.append(e);
			}
			return e;
		};
	};
	$Cayita_UI.InputGroup = function(T) {
		return function() {
			var e = $Cayita_UI.ControlGroup();
			e.inline = function(v) {
				$Cayita_UI.$SetInlineValue(e, v);
			};
			e.is_inline = function() {
				return $Cayita_UI.$GetInlineValue(e);
			};
			e.required = function(v1) {
				if (!ss.isValue(v1) || ss.Nullable.unbox(v1)) {
					$(e).attr('required', 'required');
					$('input', e.controls).each(function(i, el) {
						el.required = true;
					});
				}
				else {
					$(e).removeAttr('required');
					$('input', e.controls).each(function(i1, el1) {
						el1.required = false;
					});
				}
			};
			e.is_required = function() {
				return !ss.isNullOrEmptyString($(e).attr('required'));
			};
			e.set_name = function(v2) {
				$Cayita_UI.$SetName(e, v2);
			};
			e.get_name = function() {
				return $Cayita_UI.$GetName(e);
			};
			e.addOption = function(o) {
				$Cayita_UI.$AddOption(T).call(null, e, o);
			};
			e.removeOption = function(v3) {
				$Cayita_UI.$RemoveValue(T).call(null, e, v3.input.get_value());
			};
			e.removeValue = function(v4) {
				$Cayita_UI.$RemoveValue(T).call(null, e, v4);
			};
			e.removeAll = function() {
				$Cayita_UI.$RemoveAll(e);
			};
			e.getChecked = function() {
				return $Cayita_UI.$GetChecked(T).call(null, e);
			};
			e.getOptions = function() {
				return $Cayita_UI.$GetOptions(T).call(null, e);
			};
			e.checkOption = function(v5, c) {
				$Cayita_UI.$CheckValue(T).call(null, e, v5.input.get_value(), c);
			};
			e.checkValue = function(v6, c1) {
				$Cayita_UI.$CheckValue(T).call(null, e, v6, c1);
			};
			e.checkAll = function(c2) {
				$Cayita_UI.$CheckAll(e, c2);
			};
			e.disableOption = function(v7, d) {
				$Cayita_UI.$DisableValue(T).call(null, e, v7.input.get_value(), d);
			};
			e.disableValue = function(v8, d1) {
				$Cayita_UI.$DisableValue(T).call(null, e, v8, d1);
			};
			e.disableAll = function(d2) {
				$Cayita_UI.$DisableAll(e, d2);
			};
			e.add_checked = function(ev) {
				$Cayita_UI.$On(e.controls, 'check', ev, $Cayita_UI.OptionSelector, null);
			};
			e.remove_checked = function(ev1) {
				$Cayita_UI.$Off(e, 'check', ev1, $Cayita_UI.OptionSelector);
			};
			$(e.controls).on('change', 'input', function(ev2) {
				$(ev2.target.parentNode).trigger('check');
			});
			e.inline(true);
			return e;
		};
	};
	$Cayita_UI.$GetInlineValue = function(parent) {
		return !ss.isNullOrEmptyString($(parent).attr('inline'));
	};
	$Cayita_UI.$SetInlineValue = function(parent, value) {
		if (value) {
			$(parent).attr('inline', 'true');
			$('label[option=true]', parent.controls).addClass('inline');
		}
		else {
			$(parent).removeAttr('inline');
			$('label[option=true]', parent.controls).removeClass('inline');
		}
	};
	$Cayita_UI.$GetName = function(parent) {
		return ss.coalesce($(parent.controls).attr('groupname'), '');
	};
	$Cayita_UI.$SetName = function(parent, value) {
		$(parent.controls).attr('groupname', value);
		$('input', parent.controls).attr('name', value);
	};
	$Cayita_UI.$AddOption = function(T) {
		return function(parent, item) {
			var name = $Cayita_UI.$GetName(parent);
			if (!ss.isNullOrEmptyString(name)) {
				item.input.name = name;
			}
			if ($Cayita_UI.$GetInlineValue(parent)) {
				$(item).addClass('inline');
			}
			if (!ss.isNullOrEmptyString(item.input.id)) {
				item.set_for(item.input.id);
			}
			if (!ss.isNullOrEmptyString($(parent).attr('required'))) {
				item.input.required = true;
			}
			$(parent.controls).append(item);
		};
	};
	$Cayita_UI.$GetOptions = function(T) {
		return function(parent) {
			return $($Cayita_UI.OptionSelector, parent.controls).get();
		};
	};
	$Cayita_UI.$GetChecked = function(T) {
		return function(parent) {
			var l = $Cayita_UI.$GetOptions(T).call(null, parent);
			return Enumerable.from(l).where(function(x) {
				return x.input.checked;
			}).toArray();
		};
	};
	$Cayita_UI.$RemoveValue = function(T) {
		return function(parent, value) {
			var l = $Cayita_UI.$GetOptions(T).call(null, parent);
			var item = Enumerable.from(l).firstOrDefault(function(x) {
				return ss.staticEquals(x.input.get_value(), value);
			}, ss.getDefaultValue(Element));
			if (ss.isValue(item)) {
				$(item).remove();
				ss.remove(l, item);
			}
		};
	};
	$Cayita_UI.$RemoveAll = function(parent) {
		$(parent.controls).empty();
	};
	$Cayita_UI.$DisableValue = function(T) {
		return function(parent, value, disable) {
			var e = $($Cayita_Fn.fmt('input[value={0}]', [value]), parent.controls).get(0);
			if (ss.isValue(e)) {
				e.disabled = disable;
			}
		};
	};
	$Cayita_UI.$DisableAll = function(parent, disable) {
		$('input', parent.controls).each(function(index, element) {
			return element.disabled = disable;
		});
	};
	$Cayita_UI.$CheckValue = function(T) {
		return function(parent, value, chck) {
			var e = $($Cayita_Fn.fmt('input[value={0}]', [value]), parent.controls).get(0);
			if (ss.isValue(e)) {
				e.checked = chck;
			}
		};
	};
	$Cayita_UI.$CheckAll = function(parent, check) {
		$('input', parent.controls).each(function(index, element) {
			return element.checked = check;
		});
	};
	$Cayita_UI.$LoadData = function(T, TData) {
		return function(el, data, optionFn, append) {
			if (!append) {
				$Cayita_UI.$RemoveAll(el);
			}
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = $t1.current();
					$Cayita_UI.$AddOption(T).call(null, el, optionFn(d));
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	$Cayita_UI.$LoadList$1 = function(T) {
		return function(el, data, factory, append) {
			if (!append) {
				$Cayita_UI.$RemoveAll(el);
			}
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = $t1.current();
					var option = factory(d);
					$Cayita_UI.$AddOption(T).call(null, el, option);
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	$Cayita_UI.ImgPicture = function(src, text, action, parent) {
		var e = Cayita.UI.Anchor('c-icon', '#', null);
		e.img = Cayita.UI.Atom('img', null, null);
		if (!ss.isNullOrEmptyString(src)) {
			e.img.src = src;
		}
		e.label = Cayita.UI.Label('c-icon-label');
		e.set_text(ss.coalesce(text, ''));
		$(e).append(e.img).append(e.label);
		e.get_text = function() {
			return e.label.get_text();
		};
		e.set_text = function(v) {
			e.label.set_text(v);
		};
		e.get_src = function() {
			return e.img.src;
		};
		e.set_src = function(v1) {
			e.img.src = v1;
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.CssPicture = function(src, text, action, parent) {
		var e = Cayita.UI.Anchor('c-icon', '#', null);
		e.img = Cayita.UI.Atom('i', null, src);
		e.label = Cayita.UI.Label('c-icon-label');
		e.set_text(ss.coalesce(text, ''));
		$(e).append(e.img).append(e.label);
		e.get_text = function() {
			return e.label.get_text();
		};
		e.set_text = function(v) {
			e.label.set_text(v);
		};
		e.get_src = function() {
			return e.img.className;
		};
		e.set_src = function(v1) {
			e.img.className = v1;
		};
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.OptionAtom = function(T) {
		return function(className) {
			var e = $Cayita_UI.Atom('option', 'option', className, null, null, null);
			e.get_value = function() {
				return $Cayita_UI.$GetValue(T).call(null, e);
			};
			e.set_value = function(v) {
				$Cayita_UI.$SetValue(e, v);
			};
			e.set_setValueFn = function(v1) {
				$Cayita_UI.$SetValueFn(T).call(null, e, v1);
			};
			e.set_getValueFn = function(v2) {
				$Cayita_UI.$GetValueFn(T).call(null, e, v2);
			};
			return e;
		};
	};
	$Cayita_UI.SelectInput = function(T) {
		return function(type, className) {
			var e = $Cayita_UI.Input(T).call(null, 'select', type, className, null, null, null, null);
			e.addOption = function(a) {
				$Cayita_UI.$AddOption$1(T).call(null, e, a);
			};
			e.addValue = function(data, text, selected) {
				$Cayita_UI.$AddValue(T).call(null, e, data, text, selected);
			};
			e.get_selectedOption = function() {
				return $Cayita_UI.$GetSelectedOption(T).call(null, e);
			};
			e.get_selected = function() {
				return $Cayita_UI.$GetSelected(T).call(null, e);
			};
			e.loadData = function(data1, optionFn, append) {
				$Cayita_UI.$LoadData$1(T, Object).call(null, e, data1, optionFn, append);
			};
			e.LoadList = function(data2, append1) {
				$Cayita_UI.$LoadList(T).call(null, e, data2, append1);
			};
			e.removeValue = function(value) {
				$Cayita_UI.$RemoveValue$1(T).call(null, e, value);
			};
			e.removeOption = function(value1) {
				$Cayita_UI.$RemoveOption(T).call(null, e, value1);
			};
			e.removeAll = function() {
				$Cayita_UI.$RemoveAll$1(T).call(null, e);
			};
			e.selectValue = function(value2, selected1) {
				$Cayita_UI.$SelectValue(T).call(null, e, value2, selected1);
			};
			e.selectOption = function(value3, selected2) {
				$Cayita_UI.$SelectValue(T).call(null, e, value3.get_value(), selected2);
			};
			e.selectAll = function(selected3) {
				$Cayita_UI.$SelectAll(T).call(null, e, selected3);
			};
			return e;
		};
	};
	$Cayita_UI.$RemoveValue$1 = function(T) {
		return function(parent, value) {
			$($Cayita_Fn.fmt('option[value={0}]', [value]), parent).remove();
		};
	};
	$Cayita_UI.$RemoveOption = function(T) {
		return function(parent, option) {
			$($Cayita_Fn.fmt('option[value={0}]', [option.get_value()]), parent).remove();
		};
	};
	$Cayita_UI.$AddValue = function(T) {
		return function(parent, value, text, selected) {
			$Cayita_UI.$AddOption$1(T).call(null, parent, function(o) {
				o.set_value(value);
				o.set_text(ss.coalesce(text, value));
				o.selected = selected;
			});
		};
	};
	$Cayita_UI.$AddOption$1 = function(T) {
		return function(parent, config) {
			var option = Cayita.UI.OptionAtom(T)();
			config(option);
			parent.add(option);
		};
	};
	$Cayita_UI.$GetSelectedOption = function(T) {
		return function(parent) {
			if (parent.selectedIndex < 0) {
				return null;
			}
			return parent.options[parent.selectedIndex];
		};
	};
	$Cayita_UI.$RemoveAll$1 = function(T) {
		return function(el) {
			$(el).empty();
		};
	};
	$Cayita_UI.$GetSelected = function(T) {
		return function(el) {
			var s = [];
			var q = $('option:selected', el);
			q.each(function(index, element) {
				ss.add(s, element);
			});
			return s;
		};
	};
	$Cayita_UI.$LoadData$1 = function(T, TData) {
		return function(el, data, optionFn, append) {
			if (!append) {
				$Cayita_UI.$RemoveAll$1(T).call(null, el);
			}
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = $t1.current();
					el.add(optionFn(d));
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	$Cayita_UI.$LoadList = function(T) {
		return function(el, data, append) {
			if (!append) {
				$Cayita_UI.$RemoveAll$1(T).call(null, el);
			}
			var $t1 = ss.getEnumerator(data);
			try {
				while ($t1.moveNext()) {
					var d = { $: $t1.current() };
					el.addOption(ss.mkdel({ d: d }, function(o) {
						o.set_value(this.d.$);
						o.set_text(this.d.$);
					}));
				}
			}
			finally {
				$t1.dispose();
			}
		};
	};
	$Cayita_UI.$SelectValue = function(T) {
		return function(el, value, selected) {
			var o = $($Cayita_Fn.fmt('option[value={0}]', [value]), el).get(0);
			if (ss.isValue(o)) {
				o.selected = selected;
			}
		};
	};
	$Cayita_UI.$SelectAll = function(T) {
		return function(el, selected) {
			$('option', el).each(function(i, e) {
				return e.selected = selected;
			});
		};
	};
	$Cayita_UI.NavBar = function() {
		var e = Cayita.UI.Atom('div', null, 'navbar');
		var ar = Cayita.UI.Anchor('btn btn-navbar', '#', null);
		ar.setAttribute('data-toggle', 'collapse');
		for (var i = 0; i < 3; i++) {
			var sp = Cayita.UI.Atom('span', null, 'icon-bar');
			$(ar).append(sp);
		}
		e.collapse = Cayita.UI.Atom('div', null, 'nav-collapse collapse');
		ar.setAttribute('data-target', '#' + e.collapse.createId());
		e.nav = $Cayita_UI.Nav(null);
		e.collapse.append(e.nav);
		var cf = Cayita.UI.Atom('div', null, 'container-fluid');
		$(cf).append(ar).append(e.collapse);
		var nbi = Cayita.UI.Atom('div', null, 'navbar-inner');
		$(nbi).append(cf);
		$(e).append(nbi);
		e.nav.$brand = null;
		e.nav.get_brandText = function() {
			if (ss.isNullOrUndefined(e.nav.$brand)) {
				return '';
			}
			return e.nav.$brand.get_text();
		};
		e.nav.set_brandText = function(v) {
			var fli = $($Cayita_UI.BrandSelector, cf);
			if (fli.length === 0) {
				e.nav.$brand = Cayita.UI.Anchor('brand', '#', v);
				$(e.collapse).before(e.nav.$brand);
			}
			else {
				e.nav.$brand.set_text(v);
			}
		};
		e.nav.add_brandClicked = function(ev) {
			$Cayita_UI.$On(cf, $Cayita_UI.BrandEventName, ev, $Cayita_UI.BrandSelector, null);
		};
		e.nav.remove_brandClicked = function(ev1) {
			$Cayita_UI.$Off(cf, $Cayita_UI.BrandEventName, ev1, $Cayita_UI.BrandSelector);
		};
		e.nav.is_inverse = function() {
			return $(e).hasClass('navbar-inverse');
		};
		e.nav.inverse = function(v1) {
			if (!ss.isValue(v1) || ss.Nullable.unbox(v1)) {
				$(e).addClass('navbar-inverse');
			}
			else {
				$(e).removeClass('navbar-inverse');
			}
		};
		e.get_text = function() {
			return e.nav.get_brandText();
		};
		e.set_text = function(v2) {
			e.nav.set_brandText(v2);
		};
		e.collapse.addElement = function(v3) {
			e.collapse.append(v3);
		};
		$(cf).on('click', $Cayita_UI.BrandSelector, function(ev2) {
			ev2.preventDefault();
			var j = $(ev2.currentTarget);
			if (j.hasClass('disabled')) {
				return;
			}
			j.trigger($Cayita_UI.BrandEventName);
		});
		return e;
	};
	$Cayita_UI.NavList = function(parent) {
		var e = Cayita.UI.Atom('div', null, 'well sidebar-nav');
		e.nav = $Cayita_UI.Nav('nav-list');
		$(e).append(e.nav);
		e.nav.get_header = function() {
			return ss.coalesce(e.$header.toString(), '');
		};
		e.nav.set_header = function(v) {
			e.$header = v;
			var fli = $('li:first', e.nav);
			if (fli.length === 0) {
				$(e.nav).append(Cayita.UI.Atom('li', null, 'nav-header', v));
			}
			else if (fli.hasClass('nav-header')) {
				fli.html($Cayita_UI.$BuildText(v));
			}
			else {
				fli.before(Cayita.UI.Atom('li', null, 'nav-header', v));
			}
		};
		e.get_text = function() {
			return e.nav.get_header();
		};
		e.set_text = function(v1) {
			e.nav.set_header(v1);
		};
		if (ss.isValue(parent)) {
			parent.append(e);
		}
		return e;
	};
	$Cayita_UI.NavItem = function(value, text, handler, disable, iconClassName) {
		var i = Cayita.UI.Atom('li', null, null);
		i.setAttribute('value', value);
		if (disable) {
			$(i).addClass('disabled');
		}
		i.handler = handler;
		i._icon = Cayita.UI.Atom('i', null, iconClassName);
		i._anchor = Cayita.UI.Anchor(null, '#');
		$(i._anchor).append(i._icon);
		i._anchor.set_text(ss.coalesce(text, value));
		$(i).append(i._anchor);
		i.get_text = function() {
			return i._anchor.get_text();
		};
		i.set_text = function(v) {
			i._anchor.set_text(v);
		};
		i.get_value = function() {
			return ss.coalesce(i.getAttribute('value').toString(), '');
		};
		i.set_value = function(v1) {
			i.setAttribute('value', v1);
		};
		i.get_iconClass = function() {
			return i._icon.className;
		};
		i.set_iconClass = function(v2) {
			i._icon.className = v2;
		};
		i.is_disabled = function() {
			return $(i).hasClass('disabled');
		};
		i.disable = function(d) {
			if (d) {
				$(i).addClass('disabled');
			}
			else {
				$(i).removeClass('disabled');
			}
		};
		i.add_clicked(function(ev) {
			if (i.is_disabled()) {
				return;
			}
			var h = i.handler;
			if (!ss.staticEquals(h, null)) {
				h(ev);
			}
		});
		return i;
	};
	$Cayita_UI.Nav = function(navType) {
		var l = $Cayita_UI.CreateNavBase(navType);
		$(l).on('click', $Cayita_UI.ItemSelector, function(e) {
			e.preventDefault();
			var j = $(e.currentTarget);
			if (j.hasClass('disabled')) {
				return;
			}
			$('li', e.delegateTarget).removeClass('active');
			j.addClass('active');
			j.trigger($Cayita_UI.SelectEventName);
		});
		return l;
	};
	$Cayita_UI.CreateNavBase = function(navType) {
		var l = Cayita.UI.HtmlList($Cayita_Fn.fmt('nav{0}', [(ss.isNullOrEmptyString(navType) ? '' : (' ' + navType))]));
		l.addDropdownMenu = function(m) {
			var i = Cayita.UI.Atom('li', null, null);
			m.addTo(i);
			if (l.classList.contains('nav-list')) {
				$('.caret', m).addClass('pull-right');
			}
			l.append(i);
		};
		l.addDropdownSubmenu = function(m1) {
			var i1 = Cayita.UI.Atom('li', null, null);
			m1.addTo(i1);
			l.append(i1);
		};
		l.addItem = function(i2) {
			$(l).append(i2);
		};
		l.removeItem = function(v) {
			$($Cayita_UI.SelectFn(v), l).remove();
		};
		l.removeAll = function() {
			$(l).empty();
		};
		l.disableItem = function(v1, d) {
			var j = $($Cayita_UI.SelectFn(v1), l);
			if (!ss.isValue(d) || ss.Nullable.unbox(d)) {
				j.addClass('disabled');
			}
			else {
				j.removeClass('disabled');
			}
		};
		l.disableAll = function(d1) {
			var j1 = $($Cayita_UI.ItemSelector, l);
			if (!ss.isValue(d1) || ss.Nullable.unbox(d1)) {
				j1.addClass('disabled');
			}
			else {
				j1.removeClass('disabled');
			}
		};
		l.addValue = function(v2, t, h, d2, i3) {
			l.addItem(Cayita.UI.NavItem(v2, t, h, d2, i3));
		};
		l.addDivider = function(v3) {
			l.addItem(Cayita.UI.Atom('li', null, v3, null));
		};
		l.loadList = function(list) {
			var s = new ss.StringBuilder();
			var v4 = 0;
			var $t1 = ss.getEnumerator(list);
			try {
				while ($t1.moveNext()) {
					var d3 = $t1.current();
					s.append(Cayita.UI.NavItem((v4++).toString(), d3, null, false, null).outerHTML);
				}
			}
			finally {
				$t1.dispose();
			}
			$(l).append(s.toString());
		};
		l.loadNavItemList = function(lst) {
			var s1 = new ss.StringBuilder();
			var $t2 = ss.getEnumerator(lst);
			try {
				while ($t2.moveNext()) {
					var d4 = $t2.current();
					s1.append(d4.outerHTML);
				}
			}
			finally {
				$t2.dispose();
			}
			$(l).append(s1.toString());
		};
		l.loadData = function(lst1, fn) {
			var s2 = new ss.StringBuilder();
			var $t3 = ss.getEnumerator(lst1);
			try {
				while ($t3.moveNext()) {
					var d5 = $t3.current();
					s2.append(fn(d5).outerHTML);
				}
			}
			finally {
				$t3.dispose();
			}
			$(l).append(s2.toString());
		};
		l.getItem = function(v5) {
			var j2 = $($Cayita_UI.SelectFn(v5), l);
			if (j2.length === 0) {
				return null;
			}
			return j2.get(0);
		};
		l.selectItem = function(v6) {
			var j3 = $($Cayita_UI.SelectFn(v6), l);
			if (j3.length === 0 || j3.hasClass('disabled')) {
				return;
			}
			j3.trigger($Cayita_UI.SelectEventName);
		};
		l.add_selected = function(ev) {
			$Cayita_UI.$On(l, $Cayita_UI.SelectEventName, ev, $Cayita_UI.ItemSelector, null);
		};
		l.remove_selected = function(ev1) {
			$Cayita_UI.$Off(l, $Cayita_UI.SelectEventName, ev1, $Cayita_UI.ItemSelector);
		};
		return l;
	};
	$Cayita_UI.PanelOptions = function() {
		return { closeIconClass: $Cayita_UI.DefaultCloseIconClass, collapseIconClass: $Cayita_UI.DefaultCollapseIconClass, expandIconClass: $Cayita_UI.DefaultExpandIconClass, resizable: true, draggable: true, closable: true, collapsible: true };
	};
	$Cayita_UI.Panel = function(options) {
		var dobject = null;
		var robject = null;
		var e = Cayita.UI.Atom('div', null, 'well well-panel');
		e.createId();
		e._options = options || Cayita.UI.PanelOptions();
		e._headerband = Cayita.UI.Atom('div', null, 'well-panel-header');
		e.closeIcon = Cayita.UI.Atom('i', null, e._options.closeIconClass);
		e.closeIcon.createId();
		e.collapseIcon = Cayita.UI.Atom('i', null, e._options.collapseIconClass);
		e.collapseIcon.createId();
		e.header = $Cayita_UI.Atom('ctxt', null, null, null, null, null);
		e._contentband = Cayita.UI.Atom('div', null, 'well-panel-content');
		e.body = Cayita.UI.Atom('div', null, 'well-panel-body');
		e._contentband.append(e.body);
		if (e._options.hidden) {
			$(e).hide();
		}
		$(e._headerband).append(e.closeIcon).append(e.collapseIcon).append(e.header);
		$(e).append(e._headerband).append(e._contentband);
		e.is_closable = function() {
			return e._options.closable;
		};
		e.closable = function(v) {
			e._options.closable = (ss.isValue(v) ? ss.Nullable.unbox(v) : true);
			e.closeIcon.do_hide(!e._options.closable);
		};
		e.is_collapsible = function() {
			return e._options.collapsible;
		};
		e.collapsible = function(v1) {
			e._options.collapsible = (ss.isValue(v1) ? ss.Nullable.unbox(v1) : true);
			e.collapseIcon.do_hide(!e._options.collapsible);
		};
		e.get_top = function() {
			return e._options.top;
		};
		e.set_top = function(v2) {
			if (ss.isNullOrEmptyString(v2)) {
				return;
			}
			e._options.top = v2;
			e.style.top = v2;
		};
		e.get_left = function() {
			return e._options.left;
		};
		e.set_left = function(v3) {
			if (ss.isNullOrEmptyString(v3)) {
				return;
			}
			e._options.left = v3;
			e.style.left = v3;
		};
		e.get_height = function() {
			return e._options.height;
		};
		e.set_height = function(v4) {
			if (ss.isNullOrEmptyString(v4)) {
				return;
			}
			e._options.height = v4;
			e._contentband.style.height = v4;
			e.style.height = 'auto';
		};
		e.get_width = function() {
			return e._options.width;
		};
		e.set_width = function(v5) {
			if (ss.isNullOrEmptyString(v5)) {
				return;
			}
			e._options.width = v5;
			e.style.width = v5;
			e._contentband.style.width = 'auto';
		};
		e.get_caption = function() {
			return e._options.caption;
		};
		e.set_caption = function(v6) {
			e._options.caption = v6;
			e.header.innerHTML = (ss.isNullOrEmptyString(v6) ? '' : v6);
		};
		e.do_show = function(show) {
			if (ss.isNullOrUndefined(e.parentNode)) {
				$(document.body).append(e);
			}
			if (!ss.isValue(show) || ss.Nullable.unbox(show)) {
				$(e).show();
			}
			else {
				$(e).hide();
			}
		};
		e.close = function() {
			$(e).remove();
		};
		e.add = function(c) {
			$(e.body).append(c);
			return e;
		};
		if (ss.staticEquals(e._options.closeIconHandler, null)) {
			e._options.closeIconHandler = function(p) {
				p.close();
			};
		}
		if (ss.staticEquals(e._options.collapseIconHandler, null)) {
			e._options.collapseIconHandler = function(p1, cl) {
				p1.collapse();
			};
		}
		e.add_closeIconClicked = function(ev) {
			$Cayita_UI.$On(e, $Cayita_UI.PanelCloseIconEventName, ev, '#' + e.closeIcon.id, null);
		};
		e.remove_closeIconClicked = function(ev1) {
			$Cayita_UI.$Off(e, $Cayita_UI.PanelCloseIconEventName, ev1, '#' + e.closeIcon.id);
		};
		e.add_collapseIconClicked = function(ev2) {
			$Cayita_UI.$On(e, $Cayita_UI.PanelCollapseIconEventName, ev2, '#' + e.collapseIcon.id, null);
		};
		e.remove_collapseIconClicked = function(ev3) {
			$Cayita_UI.$Off(e, $Cayita_UI.PanelCollapseIconEventName, ev3, '#' + e.collapseIcon.id);
		};
		e.collapse = function() {
			var collapsed = e._contentband.is_hidden();
			e._contentband.do_hide(!collapsed);
			if (collapsed) {
				e.collapseIcon.classList.remove(options.expandIconClass);
				$(e.collapseIcon).addClass(options.collapseIconClass);
			}
			else {
				e.collapseIcon.classList.remove(options.collapseIconClass);
				$(e.collapseIcon).addClass(options.expandIconClass);
				e.style.height = 'auto';
			}
		};
		e.resizable = function(v7) {
			options.resizable = (ss.isValue(v7) ? ss.Nullable.unbox(v7) : true);
			if (e._options.resizable) {
				if (ss.isNullOrUndefined(robject)) {
					robject = $(e._contentband).resizable();
					robject.resizable('option', 'alsoResize', e);
				}
			}
			else if (ss.isValue(robject)) {
				robject.resizable('destroy');
				robject = null;
			}
		};
		e.is_resizable = function() {
			return options.resizable;
		};
		e.do_draggable = function(v8) {
			e._options.draggable = (ss.isValue(v8) ? ss.Nullable.unbox(v8) : true);
			if (options.draggable) {
				if (ss.isNullOrUndefined(dobject)) {
					dobject = $(e).draggable();
					dobject.draggable('option', 'stack', '#' + e.id);
					dobject.draggable('option', 'addClasses', false);
					dobject.draggable('option', 'containment', 'parent');
					dobject.draggable('option', 'distance', 10);
					dobject.draggable('option', 'handle', e._headerband);
				}
			}
			else if (ss.isValue(dobject)) {
				dobject.draggable('destroy');
				dobject = null;
			}
		};
		e.is_draggable = function() {
			return options.draggable;
		};
		e.get_closeIconHandler = function() {
			return e._options.closeIconHandler;
		};
		e.set_closeIconHandler = function(v9) {
			e._options.closeIconHandler = v9;
		};
		e.get_collapseIconHandler = function() {
			return e._options.collapseIconHandler;
		};
		e.set_CollapseIconHandler = function(v10) {
			e._options.collapseIconHandler = v10;
		};
		$(e).on('click', '#' + e.closeIcon.id, function(ev4) {
			var j = $(ev4.currentTarget);
			if (j.hasClass('disabled')) {
				return;
			}
			j.trigger($Cayita_UI.PanelCloseIconEventName);
		}).on('dragstop', function(ev5) {
			$Cayita_UI.$z = e.style.zIndex;
		}).on('click', function(ev6) {
			e.style.zIndex = $Cayita_UI.$z++;
		}).on('click', '#' + e.collapseIcon.id, function(ev7) {
			var j1 = $(ev7.currentTarget);
			if (j1.hasClass('disabled')) {
				return;
			}
			j1.trigger($Cayita_UI.PanelCollapseIconEventName);
		});
		e.add_closeIconClicked(function(ev8) {
			e._options.closeIconHandler(e);
		});
		e.add_collapseIconClicked(function(ev9) {
			e._options.collapseIconHandler(e, e._contentband.is_hidden());
		});
		e.resizable(options.resizable);
		e.do_draggable(options.draggable);
		e.closable(options.closable);
		e.collapsible(options.collapsible);
		e.set_caption(options.caption);
		if (options.overlay) {
			e.style.position = 'fixed';
		}
		e.set_height(options.height);
		e.set_width(options.width);
		e.set_left(options.left);
		e.set_top(options.top);
		return e;
	};
	$Cayita_UI.SearchBoxConfig = function() {
		return { name: '', paged: true, delay: 400, searchIconClassName: 'icon-search', resetIconClassName: 'icon-remove', minLength: 4, required: false, placeholder: '' };
	};
	$Cayita_UI.SearchBox = function(T) {
		return function(store, columns, config) {
			var searchText = null;
			var searchIndex = null;
			var e = $Cayita_UI.Atom('div', null, null, null, null, null);
			e.config = config;
			var rowSelected = function(g, r) {
			};
			var onRowSelected = function(r1) {
				rowSelected(e, r1);
			};
			var he = Cayita.UI.Input(String)('input', 'text');
			he.do_hide(true);
			he.required = config.required;
			var te = Cayita.UI.Input(String)('input', 'text');
			te.className = 'search-query';
			te.placeholder = config.placeholder;
			e.searchButton = Cayita.UI.ButtonIcon(config.searchIconClassName);
			e.searchButton.do_hide(!config.searchButton);
			e.resetButton = Cayita.UI.ButtonIcon(config.resetIconClassName);
			e.resetButton.do_hide(!config.resetButton);
			e.body = Cayita.UI.Atom('div', null, 'c-search-body');
			e.body.do_hide(true);
			e.add_rowSelected = function(v) {
				rowSelected = ss.delegateCombine(rowSelected, v);
			};
			e.remove_rowSelected = function(v1) {
				rowSelected = ss.delegateRemove(rowSelected, v1);
			};
			if (ss.isNullOrUndefined(columns)) {
				columns = [];
				ss.add(columns, Cayita.UI.TableColumn(T)(config.textField, null, null, false));
			}
			var gr = Cayita.UI.Grid(T)(store, columns);
			e.body.append(gr);
			if (config.paged) {
				e.body.append(Cayita.UI.StorePager(T)(store));
			}
			var reset = function(all) {
				if (all) {
					te.set_value('');
					he.set_value('');
				}
				if (!ss.isNullOrEmptyString(searchText)) {
					searchText = null;
					searchIndex = null;
					onRowSelected(null);
				}
			};
			var search = function() {
				if (!ss.referenceEquals(te.get_value(), searchText)) {
					var st = te.get_value();
					if (ss.staticEquals(e.localFilter, null)) {
						if (st.length < e.config.minLength) {
							return;
						}
						store.read(function(opt) {
							opt.query[e.config.textField] = st;
						}, true);
					}
					else {
						store.filter(function(t) {
							return e.localFilter(t, st);
						});
					}
					reset(false);
				}
			};
			var readSelectedRow = function(sr) {
				if (ss.isNullOrUndefined(sr)) {
					e.indexValue = null;
					e.textValue = null;
					return;
				}
				var rec = Enumerable.from(store).first(function(r2) {
					return ss.referenceEquals($Cayita_Fn.$get(r2, store.get_idProperty()).toString(), sr.get_recordId());
				});
				he.set_value($Cayita_Fn.$get(rec, store.get_idProperty()).toString());
				te.set_value($Cayita_Fn.$get(rec, e.config.textField).toString());
				searchText = te.get_value();
				searchIndex = he.get_value();
				e.body.do_hide(true);
				e.indexValue = he.get_value();
				e.textValue = te.get_value();
				onRowSelected(sr);
			};
			e.searchButton.add_clicked(function(ev) {
				search();
				$(e.body).toggle();
				if (!e.body.is_hidden()) {
					gr.focus();
				}
			});
			e.resetButton.add_clicked(function(ev1) {
				reset(true);
				e.body.do_hide(true);
			});
			gr.add_rowClicked(function(g1, sr1) {
				readSelectedRow(sr1);
			});
			gr.add_keydown(function(g2, evt) {
				var k = evt.which;
				if (k === 27) {
					e.body.do_hide(true);
					return;
				}
				if (k === 13 || k === 107) {
					readSelectedRow(g2.selectedRow);
					return;
				}
			});
			$(te).keyup(function(evt1) {
				var k1 = evt1.which;
				//down enter numpad_enter
				if (k1 === 40 || k1 === 13 || k1 === 108) {
					if (e.body.is_hidden()) {
						e.body.do_hide(false);
					}
					$(gr).focus();
					return;
				}
				// esc
				if (k1 === 27) {
					he.set_value(searchIndex);
					te.set_value(searchText);
					if (!e.body.is_hidden()) {
						e.body.do_hide(true);
					}
					return;
				}
				// end home left 
				//numpad_add numpad_decimal numpad_divid numpad_multiply numpad_substract
				// page_down page_up right up tab
				if (k1 === 35 || k1 === 36 || k1 === 37 || k1 === 107 || k1 === 110 || k1 === 11 || k1 === 106 || k1 === 109 || k1 === 34 || k1 === 33 || k1 === 39 || k1 === 38 || k1 === 9) {
					return;
				}
				if (!config.searchButton || !ss.staticEquals(e.localFilter, null)) {
					var b = function() {
						search();
						if (e.body.is_hidden()) {
							e.body.do_hide(false);
						}
					};
					$Cayita_Fn.delay(b, config.delay);
				}
			});
			$(e).append(he).append(te).append(e.searchButton).append(e.resetButton).append(e.body);
			return e;
		};
	};
	$Cayita_UI.StorePager = function(T) {
		return function(store) {
			var e = Cayita.UI.Atom('div', null, 'storage-pager');
			var ofText = 'of';
			var pageText = 'Page';
			var infoFn = function(st) {
				var ft = st.fromTo();
				return $Cayita_Fn.fmt('from {0} to {1} of {2}', [ft.item2, ft.item3, st.get_totalCount()]);
			};
			e.update = function() {
				var fromTo = store.fromTo();
				var pagesCount = store.pagesCount();
				e.firstPage.disabled = !store.hasPreviousPage();
				e.previousPage.disabled = !store.hasPreviousPage();
				e.nextPage.disabled = !store.hasNextPage();
				e.lastPage.disabled = !store.hasNextPage();
				e.pageLabel.set_text(e.get_pageText());
				e.currentPage.set_value(((fromTo.item1 < pagesCount) ? (fromTo.item1 + 1) : pagesCount));
				e.totalPagesLabel.set_text(e.get_ofText() + ' ' + pagesCount);
				e.infoLabel.set_text(e.get_infoFn()(store));
			};
			e.get_pageText = function() {
				return pageText;
			};
			e.set_pageText = function(v) {
				pageText = v;
			};
			e.get_ofText = function() {
				return ofText;
			};
			e.set_ofText = function(v1) {
				ofText = v1;
			};
			e.get_infoFn = function() {
				return infoFn;
			};
			e.set_infoFn = function(v2) {
				infoFn = v2;
			};
			e.navDiv = Cayita.UI.Atom('div', null, 'btn-group');
			e.firstPage = Cayita.UI.ButtonIcon('icon-double-angle-left');
			$(e.firstPage).addClass('btn-medium');
			e.firstPage.add_clicked(function(ev) {
				store.readFirstPage();
			});
			e.previousPage = Cayita.UI.ButtonIcon('icon-angle-left');
			$(e.previousPage).addClass('btn-medium');
			e.previousPage.add_clicked(function(ev1) {
				store.readPreviousPage(true);
			});
			e.nextPage = Cayita.UI.ButtonIcon('icon-angle-right');
			$(e.nextPage).addClass('btn-medium');
			e.nextPage.add_clicked(function(ev2) {
				store.readNextPage(true);
			});
			e.lastPage = Cayita.UI.ButtonIcon('icon-double-angle-right');
			$(e.lastPage).addClass('btn-medium');
			e.lastPage.add_clicked(function(ev3) {
				store.readLastPage();
			});
			//
			e.pagerDiv = Cayita.UI.Atom('div', null, 'form-inline label');
			e.pagerDiv.style.padding = '4.5px';
			e.pageLabel = Cayita.UI.Label('checkbox');
			e.pageLabel.style.paddingRight = '4px';
			e.pageLabel.set_text(e.get_pageText());
			e.pageLabel.style.fontSize = '98%';
			e.currentPage = Cayita.UI.NullableIntInput();
			e.currentPage.autoNumeric.getSettings().vMin = 0;
			e.currentPage.className = 'input-mini';
			e.currentPage.style.padding = '0px';
			e.currentPage.style.height = '18px';
			e.currentPage.style.textAlign = 'center';
			e.currentPage.style.fontSize = '97%';
			e.currentPage.style.width = '45px';
			e.currentPage.add_handler('keypress', function(evt) {
				if (evt.which === 13) {
					store.readPage(e.currentPage.get_value() - 1);
				}
			}, '', null);
			e.totalPagesLabel = Cayita.UI.Label('checkbox');
			e.totalPagesLabel.style.paddingLeft = '2px';
			e.totalPagesLabel.set_text(e.get_ofText());
			e.totalPagesLabel.style.fontSize = '98%';
			e.infoDiv = Cayita.UI.Atom('div', null, 'form-inline label');
			e.infoDiv.style.padding = '4.5px';
			e.infoLabel = Cayita.UI.Label('checkbox');
			e.infoLabel.style.paddingRight = '4px';
			e.infoLabel.style.fontSize = '98%';
			e.infoLabel.set_text(e.get_infoFn()(store));
			$(e.infoDiv).append(e.infoLabel);
			$(e.pagerDiv).append(e.pageLabel).append(e.currentPage).append(e.totalPagesLabel);
			$(e.navDiv).append(e.firstPage).append(e.previousPage).append(e.nextPage).append(e.lastPage);
			$(e).append(e.navDiv).append(e.pagerDiv).append(e.infoDiv);
			store.add_storeChanged(function(st1, dt) {
				e.update();
			});
			return e;
		};
	};
	$Cayita_UI.TableCellAtom = function(rowId) {
		var e = $Cayita_UI.Atom('td', null, null, null, null, null);
		if (!ss.isNullOrEmptyString(rowId)) {
			e.setAttribute('tr', rowId);
		}
		e.get_value = function() {
			return $(e).text();
		};
		e.set_value = function(v) {
			$(e).text(ss.coalesce(v, '').toString());
		};
		e.set_getValueFn = function(func) {
			e.GetValue = function() {
				return func(e);
			};
		};
		e.set_setValueFn = function(func1) {
			e.setValue = function(v1) {
				func1(e, v1);
			};
		};
		return e;
	};
	$Cayita_UI.TableRowAtom = function(tableId) {
		var e = $Cayita_UI.Atom('tr', null, null, null, null, null);
		e.createId();
		if (!ss.isNullOrEmptyString(tableId)) {
			e.setAttribute('tb', tableId);
		}
		e.get_recordId = function() {
			return ss.coalesce(e.getAttribute('record-id'), '').toString();
		};
		e.set_recordId = function(v) {
			e.setAttribute('record-id', v);
		};
		e.insertCell = function(i) {
			if (!ss.isValue(i)) {
				i = -1;
			}
			var rf = ((ss.Nullable.unbox(i) < 0) ? e.getLastCell() : e.getCellByIndex(ss.Nullable.unbox(i)));
			var r = $Cayita_UI.TableCellAtom(e.id);
			if (ss.isNullOrUndefined(rf)) {
				$(rf).before(r);
			}
			else {
				e.append(r);
			}
			return r;
		};
		e.getFirstCell = function() {
			return $($Cayita_Fn.fmt('td[tr={0}]:first', [e.id]), e).get(0);
		};
		e.getLastCell = function() {
			return $($Cayita_Fn.fmt('td[tr={0}]:last', [e.id]), e).get(0);
		};
		e.getCellByIndex = function(i1) {
			return $($Cayita_Fn.fmt('td[tr={0}]', [e.id]), e).eq(i1).get(0);
		};
		e.addCell = function(c) {
			c.setAttribute('tr', e.id);
			e.append(c);
		};
		return e;
	};
	$Cayita_UI.TableColumn = function(T) {
		return function(index, header, val, autoHeader) {
			var o = { header: null, value: null, footer: null, hidden: false, afterCellCreated: null };
			if (!ss.isNullOrEmptyString(index)) {
				if (ss.isNullOrEmptyString(header) && (!ss.isValue(autoHeader) || ss.Nullable.unbox(autoHeader))) {
					header = index;
				}
				if (!ss.isNullOrEmptyString(header)) {
					var $t1 = Cayita.UI.TableCellAtom();
					$t1.set_value(header);
					o.header = $t1;
				}
				if (ss.staticEquals(val, null)) {
					val = function(t, c) {
						c.set_value($Cayita_Fn.$get(t, index));
					};
				}
				o.value = function(t1) {
					var cell = Cayita.UI.TableCellAtom();
					val(t1, cell);
					return cell;
				};
			}
			return o;
		};
	};
	$Cayita_UI.BuildColumns = function(T) {
		return function(autoHeader) {
			var cols = [];
			var o = ss.createInstance(T);
			var props = $Cayita_Fn.getProperties(o);
			for (var $t1 = 0; $t1 < props.length; $t1++) {
				var p = props[$t1];
				ss.add(cols, $Cayita_UI.TableColumn(T).call(null, p, p, null, autoHeader));
			}
			return cols;
		};
	};
	$Cayita_UI.TableAtom = function() {
		var t = $Cayita_UI.Atom('table', null, 'table table-striped table-hover table-condensed', null, null, null);
		t.createId();
		t.tabIndex = -1;
		t.setAttribute('data-provides', 'rowlink');
		t.body = $Cayita_UI.Atom('tbody', null, null, null, null, null);
		t.body.setAttribute('main', 'main');
		t.append(t.body);
		t.getRowByIndex = function(i) {
			return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}]', [t.id]), t).eq(i).get(0);
		};
		t.getLastRow = function() {
			return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}]:last', [t.id]), t).get(0);
		};
		t.getFirstRow = function() {
			return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}]:first', [t.id]), t).get(0);
		};
		t.insertRow = function(i1) {
			if (!ss.isValue(i1)) {
				i1 = -1;
			}
			var rf = ((ss.Nullable.unbox(i1) < 0) ? t.getLastRow() : t.getRowByIndex(ss.Nullable.unbox(i1)));
			var r = $Cayita_UI.TableRowAtom(t.id);
			if (ss.isNullOrUndefined(rf)) {
				$(rf).before(r);
			}
			else {
				t.body.append(r);
			}
			return r;
		};
		t.getRows = function() {
			return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}]', [t.id]), t).get();
		};
		return t;
	};
	$Cayita_UI.Table = function(T) {
		return function(columns, idProperty) {
			var e = $Cayita_UI.TableAtom();
			e.head = Cayita.UI.TableHead();
			e.foot = Cayita.UI.TableFoot();
			$(e.body).before(e.head).before(e.foot);
			var getRow = function(d) {
				return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}][record-id={1}]', [e.id, $Cayita_Fn.$get(d, e.idProperty)]), e).get(0);
			};
			e.idProperty = (ss.isNullOrEmptyString(idProperty) ? 'Id' : idProperty);
			e.columns = columns || $Cayita_UI.BuildColumns(T).call(null, true);
			e.getRowById = function(id) {
				return $($Cayita_Fn.fmt('tbody[main] tr[tb={0}][record-id={1}]', [e.id, id]), e).get(0);
			};
			e.addRow = function(d1) {
				var row = $Cayita_UI.TableRowAtom(e.id);
				row.set_recordId($Cayita_Fn.$get(d1, e.idProperty).toString());
				row.className = 'rowlink';
				for (var $t1 = 0; $t1 < e.columns.length; $t1++) {
					var col = e.columns[$t1];
					var c = col.value(d1);
					if (col.hidden) {
						c.do_hide(true);
					}
					row.addCell(c);
					if (!ss.staticEquals(col.afterCellCreated, null)) {
						col.afterCellCreated(d1, row);
					}
				}
				e.body.append(row);
			};
			e.updateRow = function(d2) {
				var row1 = getRow(d2);
				$(row1).empty();
				for (var $t2 = 0; $t2 < e.columns.length; $t2++) {
					var col1 = e.columns[$t2];
					var c1 = col1.value(d2);
					if (col1.hidden) {
						c1.do_hide(true);
					}
					row1.addCell(c1);
					if (!ss.staticEquals(col1.afterCellCreated, null)) {
						col1.afterCellCreated(d2, row1);
					}
				}
			};
			e.removeRow = function(d3) {
				$(getRow(d3)).remove();
			};
			e.removeRowById = function(id1) {
				$(e.getRowById(id1)).remove();
			};
			e.load = function(list, append) {
				if (!ss.isValue(append) || !ss.Nullable.unbox(append)) {
					$(e.body).empty();
				}
				var fbody = document.createDocumentFragment();
				var $t3 = ss.getEnumerator(list);
				try {
					while ($t3.moveNext()) {
						var d4 = $t3.current();
						var row2 = $Cayita_UI.TableRowAtom(e.id);
						row2.set_recordId($Cayita_Fn.$get(d4, e.idProperty).toString());
						row2.className = 'rowlink';
						for (var $t4 = 0; $t4 < e.columns.length; $t4++) {
							var col2 = e.columns[$t4];
							var c2 = col2.value(d4);
							if (col2.hidden) {
								c2.do_hide(true);
							}
							row2.addCell(c2);
							if (!ss.staticEquals(col2.afterCellCreated, null)) {
								col2.afterCellCreated(d4, row2);
							}
						}
						fbody.appendChild(row2);
					}
				}
				finally {
					$t3.dispose();
				}
				e.body.appendChild(fbody);
			};
			var h = Cayita.UI.TableRowAtom();
			var f = Cayita.UI.TableRowAtom();
			for (var $t5 = 0; $t5 < e.columns.length; $t5++) {
				var col3 = e.columns[$t5];
				if (ss.isValue(col3.header)) {
					var c3 = col3.header;
					if (col3.hidden) {
						c3.do_hide(true);
					}
					h.append(c3);
				}
				if (ss.isValue(col3.footer)) {
					var c4 = col3.footer;
					if (col3.hidden) {
						c4.do_hide(true);
					}
					f.append(c4);
				}
			}
			if (h.cells.length > 0) {
				e.head.append(h);
			}
			if (f.cells.length > 0) {
				e.foot.append(f);
			}
			return e;
		};
	};
	$Cayita_UI.CreateTableBand = function(tagName) {
		return $Cayita_UI.Atom(tagName, null, null, null, null, null);
	};
	$Cayita_UI.TableHead = function() {
		return $Cayita_UI.CreateTableBand('thead');
	};
	$Cayita_UI.TableFoot = function() {
		return $Cayita_UI.CreateTableBand('tfoot');
	};
	$Cayita_UI.DropdownTab = function(parent, text, iconClass) {
		var o = $Cayita_UI.DropdownMenu(text, iconClass);
		o.add = function(tab) {
			o.nav.addItem(tab.item);
			parent.content.append(tab.body);
		};
		var i = Cayita.UI.Atom('li', null, 'dropdown', null);
		$(i).append(o).append(o.nav);
		parent.links.append(i);
		return o;
	};
	$Cayita_UI.Tab = function(title, content, disabled) {
		var a = Cayita.UI.Anchor('', null, title);
		a.body = Cayita.UI.Atom('div', null, 'tab-pane');
		a.body.createId();
		a.href = '#' + a.body.id;
		if (ss.isValue(content)) {
			$(a.body).append(content);
		}
		a.setAttribute('data-toggle', 'tab');
		a.item = Cayita.UI.Atom('li', null, null);
		a.item.setAttribute('index', a.body.id);
		a.item.append(a);
		a.get_caption = function() {
			return a.get_text();
		};
		a.set_caption = function(v) {
			a.set_text(v);
		};
		a.is_disabled = function() {
			return a.item.classList.contains('disabled');
		};
		a.disable = function(v1) {
			if (!ss.isValue(v1) || ss.Nullable.unbox(v1)) {
				a.classList.add('disabled');
				a.item.classList.add('disabled');
			}
			else {
				a.classList.remove('disabled');
				a.item.classList.remove('disabled');
			}
		};
		if (ss.isValue(disabled) && ss.Nullable.unbox(disabled)) {
			a.disable(true);
		}
		a.clickHandler = function(p) {
			$(a)['tab']('show', null);
		};
		return a;
	};
	$Cayita_UI.TabPanelOptions = function(bordered, tabsPosition, navType, stacked) {
		var po = {};
		po.bordered = (ss.isValue(bordered) ? ss.Nullable.unbox(bordered) : false);
		po.tabsPosition = (ss.isNullOrEmptyString(tabsPosition) ? 'top' : tabsPosition);
		po.navType = (ss.isNullOrEmptyString(navType) ? 'tabs' : navType);
		po.stacked = (ss.isValue(stacked) ? ss.Nullable.unbox(stacked) : false);
		return po;
	};
	$Cayita_UI.TabPanel = function(options, action) {
		options = options || Cayita.UI.TabPanelOptions();
		var e = Cayita.UI.Atom('div', null, $Cayita_Fn.fmt('tabbable{0}{1}', [(options.bordered ? ' tabbable-bordered' : ''), ' tabs-' + options.tabsPosition]));
		e.links = Cayita.UI.HtmlList(ss.formatString('nav nav-{0}{1}', options.navType, (options.stacked ? ' nav-stacked' : '')));
		e.content = Cayita.UI.Atom('div', null, 'tab-content');
		var getTab = function(t) {
			var tp = typeof(t);
			if (tp === 'number') {
				return $('a[data-toggle=\'tab\']', e.links).get(parseInt(t.toString()));
			}
			if (tp === 'object') {
				return t;
			}
			return null;
		};
		if (options.tabsPosition !== 'below') {
			$(e).append(e.links).append(e.content);
		}
		else {
			$(e).append(e.content).append(e.links);
		}
		e.addDropdownTab = function(t1, i) {
			return Cayita.UI.DropdownTab(e, t1, i);
		};
		e.add = function(tab) {
			e.links.append(tab.item);
			e.content.append(tab.body);
		};
		e.addTab = function(act) {
			var tab1 = Cayita.UI.Tab();
			act(tab1);
			e.links.append(tab1.item);
			e.content.append(tab1.body);
		};
		e.getTab = function(index) {
			return $('a[data-toggle=\'tab\']', e.links).get(index);
		};
		e.remove = function(t2) {
			var tab2 = getTab(t2);
			if (ss.isNullOrUndefined(tab2)) {
				return;
			}
			$(tab2.body).remove();
			$(tab2.item).remove();
		};
		e.show = function(t3) {
			var tab3 = getTab(t3);
			if (ss.isNullOrUndefined(tab3)) {
				return;
			}
			$(tab3)['tab']('show', null);
		};
		e.disable = function(t4, v) {
			var tab4 = getTab(t4);
			if (ss.isNullOrUndefined(tab4)) {
				return;
			}
			tab4.disable((ss.isValue(v) ? ss.Nullable.unbox(v) : true));
		};
		e.add_tabShow = function(ev) {
			$Cayita_UI.$On(e, 'show', ev, 'a[data-toggle=\'tab\']', null);
		};
		e.remove_tabShow = function(ev1) {
			$Cayita_UI.$Off(e, 'show', ev1, 'a[data-toggle=\'tab\']');
		};
		e.add_tabShown = function(ev2) {
			$Cayita_UI.$On(e, 'shown', ev2, 'a[data-toggle=\'tab\']', null);
		};
		e.remove_tabShown = function(ev3) {
			$Cayita_UI.$Off(e, 'shown', ev3, 'a[data-toggle=\'tab\']');
		};
		e.add_tabClicked = function(ev4) {
			$Cayita_UI.$On(e, 'click', ev4, 'a[data-toggle=\'tab\']', null);
		};
		e.remove_tabClicked = function(ev5) {
			$Cayita_UI.$Off(e, 'clik', ev5, 'a[data-toggle=\'tab\']');
		};
		$(e).on('click', 'a[data-toggle=\'tab\']', function(ev6) {
			ev6.preventDefault();
			if (ev6.currentTarget.classList.contains('disabled')) {
				return;
			}
			ev6.currentTarget.clickHandler(ev6.currentTarget);
		});
		if (!ss.staticEquals(action, null)) {
			action(e);
		}
		return e;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.JData.StoreChangedAction
	var $Cayita_JData_StoreChangedAction = function() {
	};
	$Cayita_JData_StoreChangedAction.prototype = { none: 0, created: 1, read: 2, updated: 3, destroyed: 4, patched: 5, added: 6, inserted: 7, replaced: 8, removed: 9, cleared: 10, loaded: 11, filtered: 12 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.JData.StoreFailedAction
	var $Cayita_JData_StoreFailedAction = function() {
	};
	$Cayita_JData_StoreFailedAction.prototype = { none: 0, create: 1, read: 2, update: 3, destroy: 4, patch: 5 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.JData.StoreRequestedAction
	var $Cayita_JData_StoreRequestedAction = function() {
	};
	$Cayita_JData_StoreRequestedAction.prototype = { none: 0, create: 1, read: 2, update: 3, destroy: 4, patch: 5 };
	////////////////////////////////////////////////////////////////////////////////
	// Cayita.JData.StoreRequestedState
	var $Cayita_JData_StoreRequestedState = function() {
	};
	$Cayita_JData_StoreRequestedState.prototype = { none: 0, started: 1, finished: 2 };
	ss.registerClass(global, 'Cayita.AlertFn', $Cayita_AlertFn);
	ss.registerClass(global, 'Cayita.Data', $Cayita_Data);
	ss.registerClass(global, 'Cayita.Fn', $Cayita_Fn);
	ss.registerEnum(global, 'Cayita.FormUpdatedAction', $Cayita_FormUpdatedAction);
	ss.registerClass(global, 'Cayita.Plugins', $Cayita_Plugins);
	ss.registerClass(global, 'Cayita.UI', $Cayita_UI);
	ss.registerEnum(global, 'Cayita.JData.StoreChangedAction', $Cayita_JData_StoreChangedAction);
	ss.registerEnum(global, 'Cayita.JData.StoreFailedAction', $Cayita_JData_StoreFailedAction);
	ss.registerEnum(global, 'Cayita.JData.StoreRequestedAction', $Cayita_JData_StoreRequestedAction);
	ss.registerEnum(global, 'Cayita.JData.StoreRequestedState', $Cayita_JData_StoreRequestedState);
	$Cayita_Fn.delayFn = (function() {
		var timer = 0;
		return function(cb, dl) {
			window.clearTimeout(timer);
			timer = window.setTimeout(cb, dl);
		};
	})();
	$Cayita_UI.AutoId = false;
	$Cayita_UI.CTextTag = 'ctxt';
	$Cayita_UI.ControlGroupClassName = 'control-group';
	$Cayita_UI.ControlLabelClassName = 'control-label';
	$Cayita_UI.ControlsClassName = 'controls';
	$Cayita_UI.EmptyImgSrc = 'http://www.placehold.it/200x150/EFEFEF/AAAAAA&text=no+image';
	$Cayita_UI.$tags = new (ss.makeGenericType(ss.Dictionary$2, [String, ss.Int32]))();
	$Cayita_UI.OptionSelector = 'label[option=true]';
	$Cayita_UI.ItemSelector = 'li[value]';
	$Cayita_UI.SelectFn = function(v) {
		return $Cayita_Fn.fmt('li[value={0}]', [v]);
	};
	$Cayita_UI.SelectEventName = 'item.select';
	$Cayita_UI.BrandEventName = 'brand.click';
	$Cayita_UI.BrandSelector = '.brand';
	$Cayita_UI.DefaultCloseIconClass = 'icon-remove-circle';
	$Cayita_UI.DefaultCollapseIconClass = 'icon-circle-arrow-up';
	$Cayita_UI.DefaultExpandIconClass = 'icon-circle-arrow-down';
	$Cayita_UI.PanelCloseIconEventName = 'close-icon.click';
	$Cayita_UI.PanelCollapseIconEventName = 'collapse-icon.click';
	$Cayita_UI.$z = 0;
	$Cayita_AlertFn.ErrorTmpl = function(m) {
		return $Cayita_Fn.fmt('<div class=\'alert alert-block alert-error\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>', [m]);
	};
	$Cayita_AlertFn.SuccessTmpl = function(m) {
		return $Cayita_Fn.fmt('<div class=\'alert alert-block alert-success\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>', [m]);
	};
	$Cayita_AlertFn.InfoTmpl = function(m) {
		return $Cayita_Fn.fmt('<div class=\'alert alert-block alert-success\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>', [m]);
	};
	$Cayita_AlertFn.WarningTmpl = function(m) {
		return $Cayita_Fn.fmt('<div class=\'alert alert-block alert-success\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{0}</div>', [m]);
	};
	$Cayita_AlertFn.PageAlertTmpl = function(m, t) {
		return $Cayita_Fn.fmt('<div class=\'alert{0}\'><a class=\'close\' data-dismiss=\'alert\' href=\'#\'>×</a>{1}</div>', [(ss.isNullOrEmptyString(t) ? '' : (' alert-' + t)), m]);
	};
	$Cayita_AlertFn.PageAlertZIndex = 1040;
})();
