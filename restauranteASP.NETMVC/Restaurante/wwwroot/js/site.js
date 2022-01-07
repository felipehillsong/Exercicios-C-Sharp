$(document).ready(function () {
    $("#servicoPrato").change(function () {
        if ($(this).val() == "Pratos") {
            $('.resultadoPrato').show();
            $('.quantidadePrato').show();
            $(".resultadoPrato").attr("placeholder", "Entre com o prato");
        } else {
            $('.resultadoPrato').hide();
            $('.quantidadePrato').hide();
        }       

    });
    $(".resultadoPrato").hide();
    $('.quantidadePrato').hide();
});

$(document).ready(function () {
    $("#servicoBebida").change(function () {
        if ($(this).val() == "Bebidas") {
            $('.resultadoBebida').show();
            $('.quantidadeBebida').show();
            $(".resultadoBebida").attr("placeholder", "Entre com o bebida");
        } else {
            $('.resultadoBebida').hide();
            $('.quantidadeBebida').hide();
        }

    });
    $(".resultadoBebida").hide();
    $('.quantidadeBebida').hide();
});

$(document).ready(function () {
    $("#servicoSobremesa").change(function () {
        if ($(this).val() == "Sobremesas") {
            $('.resultadoSobremesa').show();
            $('.quantidadeSobremesa').show();
            $(".resultadoSobremesa").attr("placeholder", "Entre com a sobremesa");
        } else {
            $('.resultadoSobremesa').hide();
            $('.quantidadeSobremesa').hide();
        }

    });
    $(".resultadoSobremesa").hide();
    $('.quantidadeSobremesa').hide();
});