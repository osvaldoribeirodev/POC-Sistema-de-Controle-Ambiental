$(document).ready(function () {

    //Mask
    $("#txtCodigo").mask("9999999999");
    $("#txtTelefoneFixo").mask("(99)9999-9999");
    $("#txtTelefoneCelular").mask("(99)99999-9999");
    $("#txtCpfBoleto").mask("999.999.999-99");
    $("#txtCnpjBoleto").mask("99.999.999/9999-99");
    $("#txtPlaca").mask("aaa-9999");

    //equivalente ao load
    //CorrigirLarguraMenuBrand();

    //$(window).resize(function () {
    //    CorrigirLarguraMenuBrand();
    //});

    $('#janela-segunda-via').on('hidden.bs.modal', function () {
        $("#txtCodigo").css("border", "1px solid #ccc");
        $("#txtCpfBoleto").css("border", "1px solid #ccc");
        $("#txtCnpjBoleto").css("border", "1px solid #ccc");
        $("#txtPlaca").css("border", "1px solid #ccc");
        $("#divMensagemCamposObrigatoriosModal").css("display", "none");
    });

    //Efeito ancora
    $("a").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {
            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;
            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 800, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });

        } // End if
    });

    /*
    var scroll_pos = 0;
    $(window).scroll(function () {
        scroll_pos = $(this).scrollTop();
        if (scroll_pos > 280) {
            $("#nav-bar-menu").css('background-color', '#F8F8F8').css("transition", "color 1s ease").css("transition", "background 1s ease");
        } else {
            $("#nav-bar-menu").css('background-color', 'rgba(248,248,248, 0.9)');
        }
        console.log(scroll_pos);
    });
    

    var visibleMneuBrand = false;
    $(".sca-menu-list-brand").click(function () {
        if (visibleMneuBrand === false)
            $(".sca-submenu-list-brand").css("visibility", "visible").css("opacity", "1");
        else
            $(".sca-submenu-list-brand").css("visibility", "hidden").css("opacity", "0").css("transition","visibility 0.7s, opacity 0.7s linear");

        visibleMneuBrand = !visibleMneuBrand;
    });
    */

    $("form").submit(function () {
        if (ExecutarValidacoes()) {            
            $("#divMensagemErro").css("display", "none");
            $("#txtEmail").css("background-color", "#fff");
            LimparCampos();
            $("#divMensagemCamposObrigatorios").css("display", "none");
            alert("Mensagem enviada com sucesso!");
        }
        else{
            $("#divMensagemCamposObrigatorios").css("display", "block");
        }

        return false;
    });
});

//function CorrigirLarguraMenuBrand() {
//    //Corrigindo a largura do menu brand
//    var wdt = $(".navbar").css("width");
//    $(".sca-submenu-list-brand li").css("width", (parseInt(wdt)));
//}

function somente_letras(campo) {
    var digits = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWyYxXzZçÇ ôíãêú";
    var campo_temp;
    for (var i = 0; i < campo.value.length; i++) {
        campo_temp = campo.value.substring(i, i + 1);
        if (digits.indexOf(campo_temp) == -1) {
            campo.value = campo.value.substring(0, i);
            return false;
        }
    }
}

function ExecutarValidacoes() {

    var retorno = false;
    
    if ($("#txtNome").val() === "") {
        $("#txtNome").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtNome").css("border", "1px solid #ccc");
        retorno = true;
    }
        
    if ($("#txtEmail").val() === "") {
        $("#txtEmail").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtEmail").css("border", "1px solid #ccc");
        retorno = true;
    }

    if ($("#txtTelefoneFixo").val() === "") {
        $("#txtTelefoneFixo").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtTelefoneFixo").css("border", "1px solid #ccc");
        retorno = true;
    }

    if ($("#txtTelefoneCelular").val() === "") {
        $("#txtTelefoneCelular").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtTelefoneCelular").css("border", "1px solid #ccc");
        retorno = true;
    }

    if ($("#txtArea").val() === "") {
        $("#txtArea").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtArea").css("border", "1px solid #ccc");
        retorno = true;
    }

    if (!ValidarEmail($("#txtEmail"), $("#spanEmail")))
        retorno = false;
    else
        retorno = true;

    return retorno;
}

function ValidarCamposObrigatorios(){
    var retorno = false;
    
    if ($("#txtCodigo").val() === "") {
        $("#txtCodigo").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtCodigo").css("border", "1px solid #ccc");
        retorno = true;
    }
        
    if ($("#txtCpfBoleto").val() === "" && $("#txtCnpjBoleto").val() === "") {
        $("#txtCpfBoleto").css("border", "1px solid red");
        $("#txtCnpjBoleto").css("border", "1px solid red");
        retorno = false;
    }
    else if ($("#txtCpfBoleto").val() !== "" && $("#txtCnpjBoleto").val() === ""){
        $("#txtCpfBoleto").css("border", "1px solid #ccc");
        $("#txtCnpjBoleto").css("border", "1px solid #ccc");
        retorno = true;
    }
    else if ($("#txtCpfBoleto").val() === "" && $("#txtCnpjBoleto").val() !== ""){
            $("#txtCpfBoleto").css("border", "1px solid #ccc");
            $("#txtCnpjBoleto").css("border", "1px solid #ccc");
        retorno = true;
    }
    else{
        retorno = true;
    }

    if ($("#txtPlaca").val() === "") {
        $("#txtPlaca").css("border", "1px solid red");
        retorno = false;
    }
    else{
        $("#txtPlaca").css("border", "1px solid #ccc");
        retorno = true;
    }

    if (retorno === false)
    {
        $("#divMensagemCamposObrigatoriosModal").css("display", "block");
        $("#spnMensagem").html("Digite o código do cliente, o CPF ou CNPJ e a placa do veículo.");
    }
    else
    {
        $("#divMensagemCamposObrigatoriosModal").css("display", "none");
    }
    return retorno;
}

function ExecutarValidacoesModal() {

    if(!ValidarCPF($("#txtCpfBoleto"))) return false;
    if(!ValidarCNPJ($("#txtCnpjBoleto"))) return false;
    return true;    
}

function LimparCampos(){
    $("#txtNome").val("");
    $("#txtEmail").val("");
    $("#txtTelefoneFixo").val("");
    $("#txtTelefoneCelular").val("");
    $("#txtArea").val("");
}

function LimparCamposModal(){
    $("#txtCodigo").val("");
    $("#txtCpfBoleto").val("");
    $("#txtCnpjBoleto").val("");
    $("#txtPlaca").val("");
}

function ValidarCPF(campo) {
    if ($(campo).val()   === ""){return true};
    if ($(campo).val() !== "") {

        var cpf = $(campo).val().replace('.', '').replace('.', '').replace('-', '');

        while (cpf.length < 11) cpf = "0" + cpf;

        var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
        var a = [];
        var b = new Number;
        var c = 11;

        for (i = 0; i < 11; i++) {
            a[i] = cpf.charAt(i);
            if (i < 9) b += (a[i] * --c);
        }

        if ((x = b % 11) < 2) {
            a[9] = 0
        } else {
            a[9] = 11 - x
        }

        b = 0;
        c = 11;

        for (y = 0; y < 10; y++) b += (a[y] * c--);
        if ((x = b % 11) < 2) {
            a[10] = 0;
        } else {
            a[10] = 11 - x;
        }

        if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) {
            $("#spanCPF").css("display", "block").html("CPF informado é inválido!");
            $("#txtCpfBoleto").css("border", "1px solid red");
            return false;
        }
        else {
            $("#spanCPF").css("display", "none").html("");
            $("#txtCpfBoleto").css("border", "1px solid #ccc");
            return true;
        }
    }

}

function ValidarCNPJ(ObjCnpj) {
    if ($("#txtCnpjBoleto").val() === ""){return true};
    //alert(ObjCnpj);
    var cnpj = ObjCnpj;
    var valida = new Array(6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2);
    var dig1 = new Number;
    var dig2 = new Number;

    //exp = /\.|\-|\//g

    cnpj = $(cnpj).val().replace('.', '').replace('.', '').replace('/', '').replace('-', '');//cnpj.replace(exp, '');
    
    var digito = new Number(eval(cnpj.charAt(12) + cnpj.charAt(13)));

    for (i = 0; i < valida.length; i++) {
        dig1 += (i > 0 ? (cnpj.charAt(i - 1) * valida[i]) : 0);
        dig2 += cnpj.charAt(i) * valida[i];
    }
    dig1 = (((dig1 % 11) < 2) ? 0 : (11 - (dig1 % 11)));
    dig2 = (((dig2 % 11) < 2) ? 0 : (11 - (dig2 % 11)));

    if (((dig1 * 10) + dig2) != digito)
    {
        $("#spanCNPJ").css("display", "block").html("CNPJ informado é inválido!");
        $("#txtCnpjBoleto").css("border", "1px solid red");
        return false;
    }
    else {
        $("#spanCNPJ").css("display", "none").html("");
        $("#txtCnpjBoleto").css("border", "1px solid #ccc");
        return true;
    }
}

function ValidarEmail(campoEmail, spanEmail) {

    var er = new RegExp(/^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-\.]{2,}\.[A-Za-z0-9]{2,}(\.[A-Za-z0-9])?/);
    if ($(campoEmail).val() !== "") {
        if (!er.test($.trim($(campoEmail).val()))) {
            //alert("O e-mail informado é inválido!");
            $(spanEmail).css("display", "block").html("O e-mail informado é inválido!");
            $("#txtEmail").css("border", "1px solid red");
            return false;
        }
        else
            $("#txtEmail").css("border", "1px solid #ccc");

        return true;
        //else {
        //    if (validarConf) {
        //        if ($(campoEmailConf) !== undefined && ($(campoEmailConf).val() !== $(campoEmail).val())) {
        //            //Alteração solicitada pelo Daniel - Alterado por Alessandra Ferreira
        //            //$(spanEmail).css("display", "block").html("A confirmação de e-mail está incorreta!");
        //            $(spanEmail).css("display", "block").html("E-mails não correspondem.");
        //            PintarCampos(campoEmail, true);
        //            return false;
        //        }
        //        else {
        //            $(spanEmail).css("display", "none").html("");
        //            PintarCampos(campoEmail, false);
        //            return true;
        //        }
        //    }
        //    else {
        //        $(spanEmail).css("display", "none").html("");
        //        PintarCampos(campoEmail, false);
        //        return true;
        //    }
        //    //                $(this).removeClass('invalid').addClass('valid');
        //    //                $(this).parent().find('span').fadeOut(500);
        //}
    }
    //}
}