app.service('moduloAtivoService', function ($http, $rootScope, config) {
    //console.log("loginService");
    var moduloAtivoService = {};

    moduloAtivoService.listarClasses = function () {
        return $http.get(config.baseUrl + "v1/classes", { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAtivoService.obter = function (id) {
        return $http.get(config.baseUrl + "v1/ativos/" + id, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAtivoService.listar = function () {
        return $http.get(config.baseUrl + "v1/ativos", { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAtivoService.salvar = function (ativo) {
        return $http.post(config.baseUrl + "v1/ativos/", ativo, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAtivoService.atualizar = function (ativo) {
        return $http.put(config.baseUrl + "v1/ativos/", ativo, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    moduloAtivoService.excluir = function (ativo) {
        return $http.post(config.baseUrl + "v1/ativos/delete/", ativo, { headers: { 'Authorization': 'Bearer ' + $rootScope.usuarioLogado.token } });
    };

    return moduloAtivoService;
});