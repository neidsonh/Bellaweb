$(document).ready(function () {
    $('#txbCnpj').mask('99.999.999/9999-99');
    $('#txbCep').mask('99999-999');

    var mask = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
    options = {
        onKeyPress: function (val, e, field, options) {
            field.mask(mask.apply({}, arguments), options);
        }
    };

    $('#txbTelefone').mask(mask, options);
    $('#txbCelular').mask(mask, options);
});