//Editar foto perfil

var uri = "";

$(function () {
    $('#profile_image').change(function (e) {
        uri = URL.createObjectURL(e.target.files[0]);
    });
});

var changeProfileImage = function () {
    if (uri != "") {
        $('.img-profile').attr('src', uri);
    }
    $('#myModal').modal('hide');
}

function showLink(x) {
    panel = document.getElementById("editarFoto");
    img = document.getElementById("profile-img");

    panel.style.visibility = "visible";
    panel.clientHeight = img.clientHeight;
    panel.scrollHeight = img.scrollHeight;
    panel.offsetHeight = img.offsetHeight;

}

function hideLink(x) {
    h2 = document.getElementById("editarFoto");
    h2.style.visibility = "hidden";
}