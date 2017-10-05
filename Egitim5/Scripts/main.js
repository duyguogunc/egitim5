$(document).ready(function () {

    $(".ekitapsil").click(function () {
        var id = $(this).attr("rel");
        $.ajax({
            url: "/Ekitap/KitapSil",
            method: "POST",
            data: { "id": id },
            success: function (gelenVeri) {
                alert(gelenVeri.message);
            },
            error: function () {
                alert("Bağlantıda hata oluştu");
            }
        });
    });

    $('#ekitapKonu').selectize({
        plugins: ['remove_button'],
        delimiter: ',',
        persist: false,
        maxItems:5,
        create: function (input) {
            return {
                value: input,
                text: input
            }
        }
    });

});

function formgetir() {
    alert("tıklandı");
}