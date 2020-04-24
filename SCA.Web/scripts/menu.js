$(document).ready(function () {

    //equivalente ao load
    CorrigirLarguraMenuBrand();

    $(window).resize(function () {
        CorrigirLarguraMenuBrand();
    });

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
            $(".sca-submenu-list-brand").css("visibility", "hidden").css("opacity", "0").css("transition", "visibility 0.7s, opacity 0.7s linear");

        visibleMneuBrand = !visibleMneuBrand;
    });
});

function CorrigirLarguraMenuBrand() {
    //Corrigindo a largura do menu brand
    var wdt = $(".navbar").css("width");
    $(".sca-submenu-list-brand li").css("width", (parseInt(wdt)));
}