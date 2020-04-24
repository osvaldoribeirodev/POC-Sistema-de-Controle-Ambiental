app.service('loginService', function ($http, config) {
    //console.log("loginService");
    var loginService = {};

    loginService.login = function (acesso) {
        return $http.post(config.baseUrlAdmin + "login/", acesso);
    };

    //loginService.logout = function () {
    //    return $http.get(config.baseUrl + "acesso/v1/logout");
    //};
    
    return loginService;
});