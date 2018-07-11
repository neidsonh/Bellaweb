$(document).ready(function () {
    $("form1").validate;

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
            txbEmail: false,
            txbConfimaEmail: false,
            emailIgual: false,
            txbSenha: false,
            txbConfirmaSenha: false,
            senhaIgual: false,
            emailValido: false
        };

        $("#btnSecond").prop("disabled", true);
        $("#txbEmail").on("input", function () {
            function resolveValidation() {
                var txbEmail = $("#txbEmail"),
                    emailResponse = $("#emailResponse");
                if (validateEmail(txbEmail.val())) {
                    checkEmail(txbEmail.val(), callbackEmail);
                } else {
                    formValid.emailValido = false;
                    changeMessageStatus(formValid.emailValido, "E-mail inválido");
                }
                $("#btnSecond").prop("disabled", !isAllTrue(formValid));
            }

            function checkEmail(email, callback) {
                var json = JSON.stringify({ email: email });
                $.ajax({
                    method: "POST",
                    url: "Pages/CadastroEstab.aspx/CheckEmail",
                    data: json,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        callback(data.d);
                        console.log("callback");
                    }
                });
            }

            function callbackEmail(exists) {
                var message;
                formValid.emailValido = !exists;
                message = (exists) ? "Este e-mail já está em uso" : "E-mail válido";
                changeMessageStatus(formValid.emailValido, message);
                $("#btnSecond").prop("disabled", !isAllTrue(formValid));
            }

            function changeMessageStatus(valid, message) {
                var emailResponse = $("#emailResponse");
                actionIfExist(emailResponse, "label-success", valid);
                actionIfExist(emailResponse, "label-danger", !valid);
                emailResponse.text(message);
            }

            resolveValidation();
        });
        $("#txbConfirmaEmail, #txbSenha, #txbConfirmaSenha").on("input", function () {
            formValid.txbEmail = ($("#txbEmail").val() !== "");
            formValid.txbConfimaEmail = ($("#txbConfirmaEmail").val() !== "");
            formValid.txbSenha = ($("#txbSenha").val() !== "");
            formValid.txbConfirmaSenha = ($("#txbConfirmaSenha").val() !== "");
            formValid.emailIgual = ($("#txbEmail").val() === $("#txbConfirmaEmail").val());
            formValid.senhaIgual = ($("#txbSenha").val() === $("#txbConfirmaSenha").val());

            $("#btnSecond").prop("disabled", !isAllTrue(formValid));
        });
    })();

    //Vai ser primeiro agora

    (function () {
        var formValid2 = {
            txbFantasia: false,
            txbRazaoSocial: false,
            txbCnpj: false,
            txbCep: false,
            txbLogradouro: false,
            txbNumero: false,
            txbBairro: false
        };

        $("#btnFirst").prop("disabled", true);
        $("#txbFantasia, #txbRazaoSocial, #txbCnpj, #txbCep, #txbLogradouro, #txbNumero, #txbBairro").on("input", function () {
            formValid2.txbFantasia = ($("#txbFantasia").val() !== "");
            formValid2.txbRazaoSocial = ($("#txbRazaoSocial").val() !== "");
            formValid2.txbCnpj = ($("#txbCnpj").val() !== "");
            formValid2.txbCep = ($("#txbCep").val() !== "");
            formValid2.txbLogradouro = ($("#txbLogradouro").val() !== "");
            formValid2.txbNumero = ($("#txbNumero").val() !== "");
            formValid2.txbBairro = ($("#txbBairro").val() !== "");

            $("#btnFirst").prop("disabled", !isAllTrue(formValid2));
        });
    })();

    (function () {
        var formValid3 = {
            txbResponsavel: false
        };

        function validateForm() {
            var allTrue = isAllTrue(formValid3);
            var checked = $("#cbTermosDeUso").is(":checked");
            $("#btnEnviar").prop("disabled", !allTrue || !checked);
        }

        $("#btnEnviar").prop('disabled', true);

        $("#txbResponsavel").on("input", function () {
            formValid3.txbResponsavel = ($("#txbResponsavel").val() !== "");
            validateForm();
        });

        $("#cbTermosDeUso").click(function () {
            validateForm();
        });

    })();
});