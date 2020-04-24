app.controller('LoginController', function ($scope, loginService) {
    
    $scope.login = function () {
        $scope.errorMessage = null;
        $("#divProcessando").show();
        loginService.login($scope.Usuario)
            .then(function (response) {
                $("#divProcessando").hide();
                localStorage.setItem('usuarioLogado', JSON.stringify(response.data));                
                $(window.document.location).attr('href', "home.html");
            })
            .catch(function (error) {
                $("#divProcessando").hide();                
                $scope.errorMessage = error.data.message;
            });
    };

    $scope.esconderErro = function () {
        $scope.errorMessage = null;
    };
});