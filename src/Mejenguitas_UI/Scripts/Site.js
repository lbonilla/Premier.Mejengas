//Date Picker funtion

$(".datepicker").datepicker({
    dateFormat: 'dd/mm/yyyy'
});


//Player functions
var equipoA = ["P", "DF1", "DF2", "D1", "D2"];
var equipoB = ["P", "DF1", "DF2", "D1", "D2"];
$(function () {

    //SubscribeTogame(26, 11, "1D1");

    var pivoteX = ($("#imgField").offset().left + $("#imgField").width() / 2) - 235;
    var pivoteY = ($("#imgField").height() / 2 - 30);
    var topImage = $("#imgField").offset().top;
    var imagHeight = 60;

    $(".player").each(function () {
        var puesto = $("img", this).attr("data-Puesto");
        var equipo = $("img", this).attr("data-Equipo");
        var posX = 0;
        var posY = 0;
        if (equipo == 1) {
            switch (puesto) {
                case "D1":
                    posX = pivoteX - (imagHeight + 5);
                    posY = pivoteY + 50;
                    break;
                case "D2":
                    posX = pivoteX - (imagHeight + 5);
                    posY = pivoteY - 50;
                    break;
                case "DF1":
                    posX = pivoteX - (imagHeight * 3 + 5);
                    posY = pivoteY + 100;
                    break;
                case "DF2":
                    posX = pivoteX - (imagHeight * 3 + 5);
                    posY = pivoteY - 100;
                    break;
                case "P":
                    posX = pivoteX - (imagHeight * 5 + 5);
                    posY = pivoteY;
                    break;
            }
        }
        else {
            switch (puesto) {
                case "D1":
                    posX = pivoteX + (imagHeight + 5);
                    posY = pivoteY + 50;
                    break;
                case "D2":
                    posX = pivoteX + (imagHeight + 5);
                    posY = pivoteY - 50;
                    break;
                case "DF1":
                    posX = pivoteX + (imagHeight * 3 + 5);
                    posY = pivoteY + 100;
                    break;
                case "DF2":
                    posX = pivoteX + (imagHeight * 3 + 5);
                    posY = pivoteY - 100;
                    break;
                case "P":
                    posX = pivoteX + (imagHeight * 5 + 5);
                    posY = pivoteY;
                    break;
            }
        }

        $(this).css({position:"absolute", left: posX, top: posY });
        $("#" + equipo + puesto).hide();
    });

    $(".disponible").each(function () {
        var puesto = $("div", this).attr("data-Puesto");
        var equipo = $("div", this).attr("data-Equipo");
        var posX = 0;
        var posY = 0;
        if (equipo == 1) {
            switch (puesto) {
                case "D1":
                    posX = pivoteX - (imagHeight + 5);
                    posY = pivoteY + 50;
                    break;
                case "D2":
                    posX = pivoteX - (imagHeight + 5);
                    posY = pivoteY - 50;
                    break;
                case "DF1":
                    posX = pivoteX - (imagHeight * 3 + 5);
                    posY = pivoteY + 100;
                    break;
                case "DF2":
                    posX = pivoteX - (imagHeight * 3 + 5);
                    posY = pivoteY - 100;
                    break;
                case "P":
                    posX = pivoteX - (imagHeight * 5 + 5);
                    posY = pivoteY;
                    break;
            }

        }
        else {
            switch (puesto) {
                case "D1":
                    posX = pivoteX + (imagHeight + 5);
                    posY = pivoteY + 50;
                    break;
                case "D2":
                    posX = pivoteX + (imagHeight + 5);
                    posY = pivoteY - 50;
                    break;
                case "DF1":
                    posX = pivoteX + (imagHeight * 3 + 5);
                    posY = pivoteY + 100;
                    break;
                case "DF2":
                    posX = pivoteX + (imagHeight * 3 + 5);
                    posY = pivoteY - 100;
                    break;
                case "P":
                    posX = pivoteX + (imagHeight * 5 + 5);
                    posY = pivoteY;
                    break;
            }
        }
        $(this).css({ position: "absolute", left: posX, top: posY });
    });

    //Set dragable settings
    if ($(".myPlayer") != null)
        $(".myPlayer").draggable(
            {
                appendTo: ".disponible",
                opacity: 0.35,
                zIndex: 100,
                start: function (event, ui) {
                    xpos = ui.position.left;
                    ypos = ui.position.top;
                },
                stop: function (event, ui) {
                    if (!$(this).parent().hasClass("disponible")) {
                        $(this).animate({ top: ypos, left: xpos }, 500);
                    }

                },
                snap: true
            }
            );


    $(".disponible").droppable({
        drop: function (event, ui) {
            $(ui.draggable).detach().css({ top: 0, left: 0 }).appendTo(this)
            $(this).children('.disponibleContent:first').remove();
        }
    });


    $(window).resize(function () {

    });

    //Slider
    $('.flexslider').flexslider({
        animation: "slide",
        animationLoop: false,
        itemWidth: 210,
        itemMargin: 5
    });
});

function SubscribeTogame(idJuego, idJugador, posicion) {
    $.ajax({
        type:"Post",
        url: 'JuegoJugador/Subscribir',
        data: { idJuego: idJuego, idJugador: idJugador, Posicion: posicion },
        success: function () {
            alert('Added');
        }
    });
}
