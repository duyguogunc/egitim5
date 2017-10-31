$(document).ready(function () {
    StepForm();
    KonuSec();
    $(".adminbuttons").click(function () {
        StepForm();
    });


    $(".ekitapsil").click(function () {
        var id = $(this).attr("rel");
        $.ajax({
            url: "/Ekitap/KitapSil",
            method: "POST",
            data: { "id": id },
            success: function (gelenVeri) {
                alert(gelenVeri.message);
                location.reload();
            },
            error: function () {
                alert("Bağlantıda hata oluştu");
            }
        });
    });

    $(".makalesil").click(function () {
        var id = $(this).attr("rel");
        $.ajax({
            url: "/Makale/MakaleSil",
            method: "POST",
            data: { "id": id },
            success: function (gelenVeri) {
                alert(gelenVeri.message);
                location.reload();
            },
            error: function () {
                alert("Bağlantıda hata oluştu");
            }
        });
    });

    $(".konusil").click(function () {
        var id = $(this).attr("rel");
        $.ajax({
            url: "/Konu/KonuSil",
            method: "POST",
            data: { "id": id },
            success: function (gelenVeri) {
                alert(gelenVeri.message);
                location.reload();
            },
            error: function () {
                alert("Bağlantıda hata oluştu");
            }
        });
    });

    $('.icerikForm').on('show.bs.modal', function (e) {
        KonuSec();
    });



});



/*
  _________ __                  ___________                   
 /   _____//  |_  ____ ______   \_   _____/__________  _____  
 \_____  \\   __\/ __ \\____ \   |    __)/  _ \_  __ \/     \ 
 /        \|  | \  ___/|  |_> >  |     \(  <_> )  | \/  Y Y  \
/_______  /|__|  \___  >   __/   \___  / \____/|__|  |__|_|  /
        \/           \/|__|          \/                    \/ 
*/
function StepForm() {
    var navListItems = $('div.setup-panel div a'),
            allWells = $('.setup-content'),
            allNextBtn = $('.nextBtn');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
                $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-primary').addClass('btn-default');
            $item.addClass('btn-primary');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid)
            nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-primary').trigger('click');
}

/*
 ____  __.                      _________              
|    |/ _|____   ____  __ __   /   _____/ ____   ____  
|      < /  _ \ /    \|  |  \  \_____  \_/ __ \_/ ___\ 
|    |  (  <_> )   |  \  |  /  /        \  ___/\  \___ 
|____|__ \____/|___|  /____/  /_______  /\___  >\___  >
        \/          \/                \/     \/     \/ 
*/

function KonuSec() {
    $('.konuSec').multiselect({
        buttonClass: 'btn',
        buttonWidth: 'auto',
        buttonText: function (options) {
            if (options.length == 0) {
                return 'Konu Seçiniz';
            }
            else if (options.length > 6) {
                return options.length + ' seçili ';
            }
            else {
                var selected = '';
                options.each(function () {
                    selected += $(this).text() + ', ';
                });
                return selected.substr(0, selected.length - 2) + ' ';
            }
        }
    });
};