app.controller('ModuloAdministradorController', function ($scope, $rootScope, moduloAdministradorService) {
    $scope.Usuarios = [];
    $scope.Perfis = [];
    $scope.Usuario = {};

    $scope.TipoModoEnum = {};
    $scope.TipoModoEnum.INSERT = "I";
    $scope.TipoModoEnum.UPDATE = "U";
    $scope.TipoModoEnum.READ = "R";
    $scope.Modo = "";

    $scope.listarPerfis = function () {
        $("#divProcessando").show();

        moduloAdministradorService.listarPerfis()
            .then(function (response) {
                $scope.Perfis = response.data;
                $("#divProcessando").hide();
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    $scope.listar = function () {
        $("#divProcessando").show();

        moduloAdministradorService.listar()
            .then(function (response) {
                $scope.Usuarios = response.data;
                $("#divProcessando").hide();
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    $scope.editar = function (id) {

        $scope.Modo = $scope.TipoModoEnum.UPDATE;
        $scope.obter(id);
    };

    $scope.obter = function (id) {
        $("#divProcessando").show();
        moduloAdministradorService.obter(id)
            .then(function (response) {
                $scope.Usuario = response.data;
                $scope.Usuario.confirmarSenha = response.data.senha;
                $("#divProcessando").hide();
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    $scope.novo = function () {
        $scope.Modo = $scope.TipoModoEnum.INSERT;
        $scope.Usuario = {};
    };

    $scope.salvarOuAtualizar = function () {
        if ($scope.Modo === $scope.TipoModoEnum.INSERT)
            $scope.salvar($scope.Usuario);
        else if ($scope.Modo === $scope.TipoModoEnum.UPDATE)
            $scope.atualizar($scope.Usuario);
    };

    $scope.salvar = function (usuario) {
        $("#divProcessando").show();
        var perfil = {};
        perfil.id = $scope.Usuario.perfilId;
        perfil.nome = $("#ddlPerfil :selected").text();

        moduloAdministradorService.salvar(usuario)
            .then(function (response) {
                var usuarioSalvo = response.data.entityModel;
                usuarioSalvo.perfil = perfil;
                $scope.Usuarios.push(usuarioSalvo);
                $scope.cadastroForm.$setPristine();
                $('#janela-modal-cadastro').modal('toggle');
                $("#divProcessando").hide();
                swal("", response.data.message, "success");
            })
            .catch(function (error) {
                $('#janela-modal-cadastro').modal('toggle');
                $("#divProcessando").hide();
                swal("", error.data.errorMessage, "error");
            });
    };

    $scope.atualizar = function (usuario) {
        $("#divProcessando").show();
        moduloAdministradorService.atualizar(usuario)
            .then(function (response) {
                $scope.listar();
                $scope.cadastroForm.$setPristine();
                $('#janela-modal-cadastro').modal('toggle');
                $("#divProcessando").hide();
                swal("", response.data.message, "success");
            })
            .catch(function (error) {
                $('#janela-modal-cadastro').modal('toggle');
                $("#divProcessando").hide();
                swal("", error.data.errorMessage, "error");
            });
    };

    $scope.confirmarExclusao = function (id) {
        $scope.UsuarioExcluir = $scope.Usuarios.filter(function (item) {
            return item.id === id;
        });
    };

    $scope.excluir = function () {
        $("#divProcessando").show();

        moduloAdministradorService.excluir($scope.UsuarioExcluir[0])
            .then(function (response) {
                $scope.listar();
                $("#divProcessando").hide();
                swal("", response.data.message, "success");
            })
            .catch(function (error) {
                $("#divProcessando").hide();
                swal("", error.data.errorMessage, "error");
            });
    };
});