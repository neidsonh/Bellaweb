$().ready(function () {
    function nextFieldset() {
        var atual_fs = $(this).parents('fieldset'),
            next_fs = $(this).parents('fieldset').next();

        $('#progress li').eq($('fieldset').index(next_fs)).addClass('ativo');
        atual_fs.hide(800);
        next_fs.show(800);

        scrollToTop();
    }

    function previousFieldset() {
        var atual_fs = $(this).parents('fieldset'),
            prev_fs = $(this).parents('fieldset').prev();

        $('#progress li').eq($('fieldset').index(atual_fs)).removeClass('ativo');
        atual_fs.hide(800);
        prev_fs.show(800);

        scrollToTop();
    }

    function scrollToTop() {
        $('html, body').animate({
            scrollTop: $('#progress').offset().top
        }, 800);
    };

    function checkCep() {
        requestCEP(verifyEstadoCidade, function (err) {
            console.log(err);
        });
    }

    function requestCEP(ok, fail) {
        var cep = $("#txbCep").val().replace(/\-|\_/, "");
        if (cep.length < 8)
            return;

        var url = 'https://' + 'viacep.com.br/ws/' + cep + '/json/';
        $.ajax({
            method: "GET",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: ok,
            fail: fail
        });
    }

    function verifyEstadoCidade(data) {
       
        if (data.erro) {
            $("#locationError").show();
            $("#locationFail, #locationOk").hide();
        }
        var json = JSON.stringify({ cidade: data.localidade, estado: data.uf });
        $.ajax({
            method: "POST",
            url: "/Pages/CadastroEstab.aspx/CheckEndereco",
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (retorno) {
                var showElem = (retorno.d) ? '#locationOk' : '#locationFail';
                var hideElem = ((!retorno.d) ? '#locationOk' : '#locationFail') + ", #locationError";

                $(showElem).show();
                $(hideElem).hide();
                if (retorno.d) {
                    fillFields(data);
                }
            }
        });
    }

    function fillFields(data) {
        $('#txbLogradouro').val(data.logradouro);
        $('#txbBairro').val(data.bairro);
        $('#txbCidade').val(data.localidade);
        $('#txbUf').val(data.uf);
        $('#txbFantasia').focus();
    }

    function definePwdStrength() {
        options = {};
        options.commom = {
            minChar: 8,
        };
        options.ui = {
            errorMessages: {
                wordLength: "Sua senha é muito curta",
                wordNotEmail: "Não seu e-mail como senha",
                wordSimilarToUsername: "Your password cannot contain your username",
                wordTwoCharacterClasses: "Use different character classes",
                wordRepetitions: "Muitas repetições",
                wordSequences: "Sua senha contem sequências"
            },
            verdicts: ["Muito Fraca", "Fraca", "Normal", "Média", "Forte", "Muito Forte"],
            showVerdictsInsideProgressBar: true,
            container: "#pwd-container",
            viewports: {
                progress: '#progressbar'
            }
        };
        $('#txbSenha').pwstrength(options);
    }

    $('.next').click(nextFieldset);
    $('.prev').click(previousFieldset);
    $('#btnChecar').on('click', checkCep);
    $('#locationOk, #locationFail, #locationError').hide();
    // $('#txbLogradouro').attr('disabled', 'disabled');

    definePwdStrength();
});