//Player functions
var equipoA = ["P", "DF1", "DF2", "D1", "D2"];
var equipoB = ["P", "DF1", "DF2", "D1", "D2"];
$(function () {

    //SubscribeTogame(26, 11, "1D1");
    var pivoteX = (($("#divfield").offset().left + $("#divfield").width() / 2)) - 230;
    var pivoteY = (569/2)-30;
    var topImage = $("#divfield").offset().top;
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

        $(this).css({ position: "absolute", left: posX, top: posY });
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

            var idJuego = $("img", ui.draggable).attr('data-idJuego');
            var idJugador = $("img", ui.draggable).attr('data-idJugador');

            var equipo = $("div.contentData", this).attr("data-equipo");
            var puesto = $("div.contentData", this).attr("data-puesto");

            $(ui.draggable).detach().css({ top: 0, left: 0 }).appendTo(this)
            $(this).children('.disponibleContent:first').remove();

            SubscribeTogame(idJuego, idJugador, equipo, puesto)
        }
    });


    $(window).resize(function () {

    });

});

function SubscribeTogame(idJuego, idJugador, equipo, puesto) {
    $.ajax({
        async: false,
        type: 'post',
        dataType: 'html',
        url: 'JuegoJugador/Subscribir',
        data: { idJuego: idJuego, idJugador: idJugador, equipo: equipo, puesto: puesto },
        success: function (data) {
           window.location.reload();
        }
    });
}