$(function () {
    $('#datepicker').datepicker({
        onSelect: function (dateText) {
            $('#datepicker2').datepicker("setDate", $(this).datepicker("getDate"));
        }
    });
});

$(function () {
    $("#datepicker2").datepicker();
});

$("#calendar").shieldCalendar({
    footer: {
        enabled: true,
        footerTemlpate: "{0:dd.MM.yy}"
    },
    min: new Date("2009/2/23"),
    max: new Date("2039/3/1"),
    value: new Date()
});