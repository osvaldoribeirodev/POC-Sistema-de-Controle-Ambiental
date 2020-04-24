app.controller('PrincipalController', function ($scope, $rootScope) {
    
    //$('[data-toggle="tooltip"]').tooltip();

    //var isTrueSet = loginService.validarLogin();
    //console.log(isTrueSet);
    //    $(window.document.location).attr('href', "login.html");

    //$scope.usuarioLogado = JSON.parse(localStorage.getItem('usuarioLogado'));
    $rootScope.usuarioLogado = JSON.parse(localStorage.getItem('usuarioLogado'));
    //$rootScope.Login = usuarioLogado.Login;
    //$rootScope.Perfil = "ADMIN"; //usuarioLogado.Perfil;
    //$rootScope.Nome = usuarioLogado.Nome;

    $("#spnTela").html("Home");
    //$("#spnAssemblyInfo").html("Versão " + $rootScope.Versao);

    //$scope.setarLabelHome = function () {
    //    $("#spnTela").html("Home");
    //};

    $scope.logout = function () {
        localStorage.removeItem('usuarioLogado');        
        $(window.document.location).attr('href', "../index.html");
    };
});