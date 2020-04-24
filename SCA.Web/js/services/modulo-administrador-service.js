app.service('moduloAdministradorService', function ($http, $rootScope, config) {
    //console.log("loginService");
    var moduloAdministradorService = {};

    moduloAdministradorService.listarPerfis = function () {
        return $http.get(config.baseUrlAdmin + "v1/perfis", { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAdministradorService.obter = function (id) {
        return $http.get(config.baseUrlAdmin + "v1/usuarios/" + id, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAdministradorService.listar = function () {
        return $http.get(config.baseUrlAdmin + "v1/usuarios", { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAdministradorService.salvar = function (usuario) {
        return $http.post(config.baseUrlAdmin + "v1/usuarios/", usuario, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAdministradorService.atualizar = function (usuario) {
        return $http.put(config.baseUrlAdmin + "v1/usuarios/", usuario, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAdministradorService.excluir = function (usuario) {
        return $http.post(config.baseUrlAdmin + "v1/usuarios/delete/", usuario, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    return moduloAdministradorService;
});