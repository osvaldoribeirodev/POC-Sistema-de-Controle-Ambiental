app.controller('BaseController', function ($scope) {
    
    var usuarioLogado = JSON.parse(localStorage.getItem('usuarioLogado'));
    if (usuarioLogado === undefined || usuarioLogado === null)
        $(window.document.location).attr('href', "../login.html");
        //$rootScope.usuarioLogado = usuarioLogado;
    //else
    //    $(window.document.location).attr('href', "../login.html");
});