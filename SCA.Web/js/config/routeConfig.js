app.config(function ($routeProvider, $locationProvider) {
    //    $locationProvider.html5Mode(true);
    
    $routeProvider
        .when
        (
            '/index',
            {
                templateUrl: '../app/principal.html'
            }
        )
        .when
        (
            '/ativo/cadastro',
            {
                templateUrl: '../app/ativo-cadastro.html',
                controller: 'ModuloAtivoController'
            }
        )
        .when
        (
            '/acesso/cadastro',
            {
                templateUrl: '../app/acesso-cadastro.html',
                controller: 'ModuloAdministradorController'
            }
        )
        .when
        (
            '/monitoramento',
            {
                templateUrl: '../app/monitoramento.html'
                //controller: 'AcessoController'
            }
        )
        .when
        (
            '/processos',
            {
                templateUrl: '../app/processos.html'
                //controller: 'AcessoController'
            }
        )
        .when
        (
            '/relatorios',
            {
                templateUrl: '../app/relatorios.html'
                //controller: 'AcessoController'
            }
        )
        .otherwise
        (
            {
                redirectTo: '/index'
            }
        );

    //$locationProvider.hashPrefix("");
});

//configuração para o endereço das rotas.. 
app.config(function ($locationProvider) {
    $locationProvider.hashPrefix('');
});