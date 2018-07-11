$(document).ready(function () {

    function isAllTrue(o) {
        var ok = true;
        for (var prop in o) {
            if (o.hasOwnProperty(prop)) {
                ok = o[prop] && ok;
            }
        }
        return ok;
    }

    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

    function actionIfExist(elem, className, add) {
        if (add) {
            if (!elem.hasClass(className))
                elem.addClass(className);
        } else {
            if (elem.hasClass(className))
                elem.removeClass(className);
        }
    }

    (function () {
        var formValid = {
            txbNome: false,
            txbEmail: false,
            dpdAssunto: 0,
            txbMensagem: false,
        };

        function resolveForm() {
            formValid.txbNome = ($("#txbNome").val() !== "");
            formValid.txbEmail = validateEmail($("#txbEmail").val());
            formValid.dpdAssunto = ($("#dpdAssunto").val() != 0);
            formValid.txbMensagem = ($("#txbMensagem").val() !== "");

            $("#btnEnviar").prop("disabled", !isAllTrue(formValid));
            console.log(formValid);
            console.log("dpdAssunto", $("#dpdAssunto").val());
        }

        $("#btnEnviar").prop('disabled', true);
        $("#txbNome, #txbEmail, #txbMensagem").on("input", resolveForm);
        $("#dpdAssunto").on("change", resolveForm);
    })();
});