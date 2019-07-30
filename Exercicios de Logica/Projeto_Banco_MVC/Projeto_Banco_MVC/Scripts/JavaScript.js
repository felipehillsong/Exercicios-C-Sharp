$(document).ready(function () {
    $("#tipoConta").change(function () {        
        if ($(this).val() == "contaCorrente") {
            $('#saldoinicial').val(100);
        }
        if ($(this).val() == "contaPoupanca") {
            $('#saldoinicial').val(300);
        }
    });
});