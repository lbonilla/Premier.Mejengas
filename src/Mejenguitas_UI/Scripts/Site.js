$(".datepicker").datepicker({
    dateFormat: 'dd/mm/yyyy'
});

function drawField() {
    var c = document.getElementById("fieldCanvas");
    if (c != null) {
        var ctx = c.getContext("2d");
        ctx.fillStyle = "#00FF00";
        ctx.fillRect(0, 0, 600, 350);
        ctx.fillStyle = "#000000";
        ctx.moveTo(300, 0);
        ctx.stroke(300,350);
    }
}
drawField();
