app.controller('ModuloAtivoController', function ($scope, moduloAtivoService) {

    $scope.Ativos = [];
    $scope.Classes = [];
    $scope.Ativo = {};

    $scope.TipoModoEnum = {};
    $scope.TipoModoEnum.INSERT = "I";
    $scope.TipoModoEnum.UPDATE = "U";
    $scope.TipoModoEnum.AGENDA = "AG";
    $scope.Modo = "";

    $scope.listarClasses = function () {
        $("#divProcessando").show();

        moduloAtivoService.listarClasses()
            .then(function (response) {
                $scope.Classes = response.data;
                $("#divProcessando").hide();
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    $scope.listar = function () {
        $("#divProcessando").show();

        moduloAtivoService.listar()
            .then(function (response) {
                $scope.Ativos = response.data;
                $("#divProcessando").hide();
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    $scope.novo = function () {
        $scope.Modo = $scope.TipoModoEnum.INSERT;
        $scope.Ativo = {};
    };

    $scope.editar = function (id) {
        
        $scope.Modo = $scope.TipoModoEnum.UPDATE;
        $scope.obter(id);
    };

    $scope.obter = function (id) {
        $("#divProcessando").show();
        moduloAtivoService.obter(id)
            .then(function (response) {
                $scope.Ativo = response.data;
                if (response.data.dataManutencao !== null) {
                    var dataManutencao = new Date(response.data.dataManutencao);
                    $scope.Ativo.dataManutencao = dataManutencao;
                }
                $("#divProcessando").hide();
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    $scope.salvarOuAtualizar = function () {
        if ($scope.Modo === $scope.TipoModoEnum.INSERT)
            $scope.salvar($scope.Ativo);
        else if ($scope.Modo === $scope.TipoModoEnum.UPDATE)
            $scope.atualizar($scope.Ativo);
    };

    $scope.salvar = function (ativo) {
        $("#divProcessando").show();
        var classe = {};
        classe.id = $scope.Ativo.classeId;
        classe.nome = $("#ddlClasse :selected").text();        

        moduloAtivoService.salvar(ativo)
            .then(function (response) {
                var ativoSalvo = response.data.entityModel;
                ativoSalvo.classe = classe;
                $scope.Ativos.push(ativoSalvo);
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

    $scope.atualizar = function (ativo) {
        $("#divProcessando").show();
        moduloAtivoService.atualizar(ativo)
            .then(function (response) {
                $scope.listar();
                $scope.cadastroForm.$setPristine();
                if ($scope.Modo === $scope.TipoModoEnum.UPDATE)
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

    $scope.agendarManutencao = function (id) {
        $scope.obter(id);
    };

    $scope.agendar = function () {
        $scope.Ativo.manutencaoAgendada = true;
        $scope.Modo = $scope.TipoModoEnum.AGENDA;
        $scope.atualizar($scope.Ativo);
    };

    $scope.cancelarAgendamento = function () {
        $scope.Modo = $scope.TipoModoEnum.AGENDA;
        $scope.Ativo.manutencaoAgendada = false;
        $scope.Ativo.dataManutencao = null;
        $scope.Ativo.tipoManutencao = null;
        $scope.atualizar($scope.Ativo);
        //$('#janela-modal-agenda-manutencao').modal('toggle');
    };

    $scope.confirmarExclusao = function (id) {
        $scope.AtivoExcluir = $scope.Ativos.filter(function (item) {
            return item.id === id;
        });
    };

    $scope.excluir = function () {
        $("#divProcessando").show();

        moduloAtivoService.excluir($scope.AtivoExcluir[0])
            .then(function (response) {
                $scope.listar();
                $("#divProcessando").hide();
                swal("", response.data.message, "success");
            })
            .catch(function (error) {
                $("#divProcessando").hide();
            });
    };

    setMinDate();

    //Ordenação
    $scope.predicate = 'Id';
    $scope.reverse = false;
    $scope.ordenar = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };
});

function setMinDate()
{
    var today = new Date();
    today.setDate(today.getDate() + 1);
    var dd = today.getDate();    
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }

    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("dataManutencao").setAttribute("min", today);
}