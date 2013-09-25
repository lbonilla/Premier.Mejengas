$(".datepicker").datepicker({
    dateFormat: 'dd/mm/yyyy'
});

function drawField() {
    var c = document.getElementById("fieldCanvas");
    if (c != null) {
        var ctx = c.getContext("2d");
        ctx.fillStyle = "#FF0000";
        ctx.fillStyle(0, 0, 150, 75);
    }
}
drawField();
