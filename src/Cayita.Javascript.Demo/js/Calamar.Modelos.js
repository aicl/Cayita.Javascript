(function() {
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.AuthPermission
	var $Calamar_Auht_AuthPermission = function() {
	};
	$Calamar_Auht_AuthPermission.createInstance = function() {
		return $Calamar_Auht_AuthPermission.$ctor();
	};
	$Calamar_Auht_AuthPermission.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Name = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.AuthRole
	var $Calamar_Auht_AuthRole = function() {
	};
	$Calamar_Auht_AuthRole.createInstance = function() {
		return $Calamar_Auht_AuthRole.$ctor();
	};
	$Calamar_Auht_AuthRole.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Name = null;
		$this.Directory = null;
		$this.ShowOrder = null;
		$this.Title = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.AuthRolePermission
	var $Calamar_Auht_AuthRolePermission = function() {
	};
	$Calamar_Auht_AuthRolePermission.createInstance = function() {
		return $Calamar_Auht_AuthRolePermission.$ctor();
	};
	$Calamar_Auht_AuthRolePermission.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.AuthRoleId = 0;
		$this.AuthPermissionId = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.AuthRoleUser
	var $Calamar_Auht_AuthRoleUser = function() {
	};
	$Calamar_Auht_AuthRoleUser.createInstance = function() {
		return $Calamar_Auht_AuthRoleUser.$ctor();
	};
	$Calamar_Auht_AuthRoleUser.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.AuthRoleId = 0;
		$this.UserId = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.LoginResponse
	var $Calamar_Auht_LoginResponse = function() {
	};
	$Calamar_Auht_LoginResponse.createInstance = function() {
		return $Calamar_Auht_LoginResponse.$ctor();
	};
	$Calamar_Auht_LoginResponse.$ctor = function() {
		var $this = {};
		$this.Permissions = null;
		$this.Roles = null;
		$this.DisplayName = null;
		$this.Info = null;
		$this.Permissions = [];
		$this.Roles = [];
		$this.Info = new (ss.makeGenericType(ss.Dictionary$2, [String, String]))();
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.RolePermission
	var $Calamar_Auht_RolePermission = function() {
	};
	$Calamar_Auht_RolePermission.createInstance = function() {
		return $Calamar_Auht_RolePermission.$ctor();
	};
	$Calamar_Auht_RolePermission.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.AuthRoleId = 0;
		$this.AuthPermissionId = 0;
		$this.Name = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.UserRole
	var $Calamar_Auht_UserRole = function() {
	};
	$Calamar_Auht_UserRole.createInstance = function() {
		return $Calamar_Auht_UserRole.$ctor();
	};
	$Calamar_Auht_UserRole.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.AuthRoleId = 0;
		$this.UserId = 0;
		$this.Name = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.BLResponse
	var $Calamar_Model_BLResponse$1 = function(T) {
		var $type = function() {
		};
		$type.createInstance = function() {
			return $type.$ctor();
		};
		$type.$ctor = function() {
			var $this = {};
			$this.Result = null;
			$this.Html = null;
			$this.TotalCount = null;
			$this.Result = [];
			return $this;
		};
		$type.$ctor1 = function(data) {
			var $this = {};
			$this.Result = null;
			$this.Html = null;
			$this.TotalCount = null;
			$this.Result = [];
			ss.add($this.Result, data);
			return $this;
		};
		ss.registerGenericClassInstance($type, $Calamar_Model_BLResponse$1, [T], function() {
			return Object;
		}, function() {
			return [];
		});
		return $type;
	};
	ss.registerGenericClass(global, 'Calamar.Model.BLResponse$1', $Calamar_Model_BLResponse$1, 1);
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.Concepto
	var $Calamar_Model_Concepto = function() {
	};
	$Calamar_Model_Concepto.createInstance = function() {
		return $Calamar_Model_Concepto.$ctor();
	};
	$Calamar_Model_Concepto.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Codigo = null;
		$this.Tipo = null;
		$this.Nombre = null;
		$this.Acumulado = 0;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.Fuente
	var $Calamar_Model_Fuente = function() {
	};
	$Calamar_Model_Fuente.createInstance = function() {
		return $Calamar_Model_Fuente.$ctor();
	};
	$Calamar_Model_Fuente.GetSaldo = function($this) {
		return $this.SaldoInicial + $this.Entradas - $this.Salidas;
	};
	$Calamar_Model_Fuente.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Codigo = null;
		$this.Tipo = null;
		$this.Nombre = null;
		$this.IdConcepto = null;
		$this.SaldoInicial = 0;
		$this.Entradas = 0;
		$this.Salidas = 0;
		$this.Sistema = false;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.Gasto
	var $Calamar_Model_Gasto = function() {
	};
	$Calamar_Model_Gasto.createInstance = function() {
		return $Calamar_Model_Gasto.$ctor();
	};
	$Calamar_Model_Gasto.GetConcepto = function($this, conceptos) {
		if (ss.isNullOrUndefined(conceptos)) {
			return $Calamar_Model_Concepto.$ctor();
		}
		var cp = Enumerable.from(conceptos).firstOrDefault(function(f) {
			return f.Id === $this.IdConcepto;
		}, ss.getDefaultValue($Calamar_Model_Concepto));
		return cp || $Calamar_Model_Concepto.$ctor();
	};
	$Calamar_Model_Gasto.GetFuente = function($this, fuente) {
		if (ss.isNullOrUndefined(fuente)) {
			return $Calamar_Model_Fuente.$ctor();
		}
		var cp = Enumerable.from(fuente).firstOrDefault(function(f) {
			return f.Id === $this.IdFuente;
		}, ss.getDefaultValue($Calamar_Model_Fuente));
		return cp || $Calamar_Model_Fuente.$ctor();
	};
	$Calamar_Model_Gasto.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Fecha = new Date(0);
		$this.IdConcepto = 0;
		$this.IdFuente = 0;
		$this.Valor = 0;
		$this.Pagado = 0;
		$this.Descripcion = null;
		$this.Beneficiario = null;
		$this.Sistema = false;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.Ingreso
	var $Calamar_Model_Ingreso = function() {
	};
	$Calamar_Model_Ingreso.createInstance = function() {
		return $Calamar_Model_Ingreso.$ctor();
	};
	$Calamar_Model_Ingreso.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Fecha = new Date(0);
		$this.IdConcepto = 0;
		$this.IdFuente = 0;
		$this.Valor = 0;
		$this.Descripcion = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.PagoCredito
	var $Calamar_Model_PagoCredito = function() {
	};
	$Calamar_Model_PagoCredito.createInstance = function() {
		return $Calamar_Model_PagoCredito.$ctor();
	};
	$Calamar_Model_PagoCredito.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Fecha = new Date(0);
		$this.IdFuenteOrigen = 0;
		$this.IdFuenteDestino = 0;
		$this.IdConcepto = 0;
		$this.Capital = 0;
		$this.Intereses = 0;
		$this.Descripcion = null;
		return $this;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Aicl.Calamar.Scripts.Modelos.Traslado
	var $Calamar_Model_Traslado = function() {
	};
	$Calamar_Model_Traslado.createInstance = function() {
		return $Calamar_Model_Traslado.$ctor();
	};
	$Calamar_Model_Traslado.$ctor = function() {
		var $this = {};
		$this.Id = 0;
		$this.Fecha = new Date(0);
		$this.IdFuenteOrigen = 0;
		$this.IdFuenteDestino = 0;
		$this.Valor = 0;
		$this.Descripcion = null;
		return $this;
	};
	ss.registerClass(global, 'Calamar.Auht.AuthPermission', $Calamar_Auht_AuthPermission);
	ss.registerClass(global, 'Calamar.Auht.AuthRole', $Calamar_Auht_AuthRole);
	ss.registerClass(global, 'Calamar.Auht.AuthRolePermission', $Calamar_Auht_AuthRolePermission);
	ss.registerClass(global, 'Calamar.Auht.AuthRoleUser', $Calamar_Auht_AuthRoleUser);
	ss.registerClass(global, 'Calamar.Auht.LoginResponse', $Calamar_Auht_LoginResponse);
	ss.registerClass(global, 'Calamar.Auht.RolePermission', $Calamar_Auht_RolePermission);
	ss.registerClass(global, 'Calamar.Auht.UserRole', $Calamar_Auht_UserRole);
	ss.registerClass(global, 'Calamar.Model.Concepto', $Calamar_Model_Concepto);
	ss.registerClass(global, 'Calamar.Model.Fuente', $Calamar_Model_Fuente);
	ss.registerClass(global, 'Calamar.Model.Gasto', $Calamar_Model_Gasto);
	ss.registerClass(global, 'Calamar.Model.Ingreso', $Calamar_Model_Ingreso);
	ss.registerClass(global, 'Calamar.Model.PagoCredito', $Calamar_Model_PagoCredito);
	ss.registerClass(global, 'Calamar.Model.Traslado', $Calamar_Model_Traslado);
})();
