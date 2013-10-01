//Player functions
var equipoA = ["P", "DF1", "DF2", "D1", "D2"];
var equipoB = ["P", "DF1", "DF2", "D1", "D2"];
$(function () {

    //SubscribeTogame(26, 11, "1D1");
    var pivoteX = (($("#divfield").offset().left + $("#divfield").width() / 2)) - 230;
    var pivoteY = (569 / 2) - 30;
    var topImage = $("#divfield").offset().top;
    var imagHeight = 60;

    $(".player").each(function () {
        var puesto = $(this).attr("data-Puesto");
        var equipo = $(this).attr("data-Equipo");
        var esInvitado = $(this).attr("data-EsInvitado");


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
        $("#" + equipo + puesto).remove();

        if (esInvitado === "True") {
            $(".invitado:first").remove();
            $(this).addClass("invitadoInscrito");
        }

    });

    $(".disponible").each(function () {
        var puesto = $(this).attr("data-Puesto");
        var equipo = $(this).attr("data-Equipo");
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
    if ($(".myPlayer") != null) {
        $(".myPlayer").draggable(
            {
                appendTo: ".disponible",
                opacity: 0.35,
                zIndex: 100,
                snap: true,
                start: function (event, ui) {
                    xpos = ui.position.left;
                    ypos = ui.position.top;
                },
                stop: function (event, ui) {
                    if (!$(this).parent().hasClass("disponible")) {
                        $(this).animate({ top: ypos, left: xpos }, 500);
                    }

                }
            }
            );
    }

    if ($(".invitado") != null) {
        $(".invitado").draggable(
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
        });
    }

    $(".disponible").droppable({
        drop: function (event, ui) {

            var idJuego = $(ui.draggable).attr('data-idJuego');
            var idJugador = $(ui.draggable).attr('data-idJugador');
            var esInvitado = $(ui.draggable).hasClass("invitado");

            var equipo = $(this).attr("data-equipo");
            var puesto = $(this).attr("data-puesto");

            $(ui.draggable).detach().css({ top: 0, left: 0 }).appendTo(this)

            SubscribeTogame(idJuego, idJugador, equipo, puesto, esInvitado)
        }
    });

});

function SubscribeTogame(idJuego, idJugador, equipo, puesto, esInvitado) {
    $.ajax({
        async: false,
        type: 'post',
        dataType: 'html',
        url: 'JuegoJugador/Subscribir',
        data: { idJuego: idJuego, idJugador: idJugador, equipo: equipo, puesto: puesto, esInvitado: esInvitado },
        success: function (data) {
            window.location.reload();
        }
    });
}
