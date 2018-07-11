$(document).ready(function () {
    $("#slider").slider({
        min: 0,
        max: 200,
        step: 1,
        values: [0, 200],
        slide: function (event, ui) {
            for (var i = 0; i < ui.values.length; ++i) {
                $("input.valor[data-index=" + i + "]").val(ui.values[i]);
            }
        }
    });

    $("input.valor").change(function () {
        var $this = $(this);
        $("#slider").slider("values", $this.data("index"), $this.val());
    });
});