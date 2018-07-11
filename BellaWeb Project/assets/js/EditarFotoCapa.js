//Editar foto capa

var uriCapa = "";

$(function () {
    $('#capa_image').change(function (e) {
        uriCapa = URL.createObjectURL(e.target.files[0]);
    });
});

var changeCapaImage = function () {
    if (uriCapa != "") {
        $('.img-capa').attr('src', uriCapa);
    }
    $('#modalCapa').modal('hide');
}

function showLinkCapa(x) {
    panelCapa = document.getElementById("editarFotoCapa");
    imgCapa = document.getElementById("capa-img");

    panelCapa.style.visibility = "visible";
    panelCapa.clientHeight = imgCapa.clientHeight;
    panelCapa.scrollHeight = imgCapa.scrollHeight;
    panelCapa.offsetHeight = imgCapa.offsetHeight;

}

function hideLinkCapa(x) {
    h2 = document.getElementById("editarFotoCapa");
    h2.style.visibility = "hidden";
}