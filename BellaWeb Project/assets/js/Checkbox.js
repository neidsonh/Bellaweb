$(document).ready(function () {
    $('#cbxPromocao').click(function () {
        this.checked ? $('#promocao').show(800) : $('#promocao').hide(800);
    });
});