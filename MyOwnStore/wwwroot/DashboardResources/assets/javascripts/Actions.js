$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var result = confirm("Tem certeza que deseja executar esta açáo?");
        if (result == false) {
            e.preventDefault();
        }
    });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
})

function AjaxFileUpload() {

}