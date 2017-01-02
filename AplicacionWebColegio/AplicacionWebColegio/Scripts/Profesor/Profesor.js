//$("#btnNuevo").click(function (eve) {
//    $("#modal-content").load("/Profesores/Create", function (){
//        $('#myModal').modal("show");
//    });
//});


$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".btnDetalhes").click(function () {

        var id = $(this).data("value");

        $("#modal").load("/Profesores/Details/" + id, function () {
            $('#myModal').modal("show");

        });
    });
});



$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".btnDelete").click(function () {

        var id = $(this).data("value");

        $("#modal").load("/Profesores/Delete/" + id, function () {
            $('#myModal').modal("show");

        });
    });
});