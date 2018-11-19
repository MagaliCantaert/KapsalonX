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

$(document).ready(function () {
    $("#state").prop("disabled", true);
    $("#geslacht").change(function () {
        if ($("#geslacht").val() !== "Please select") {
            var options = {};
            options.url = "/admin/getgeslacht";
            options.type = "POST";
            options.data = JSON.stringify({ geslacht: $("#geslacht").val() });
            options.dataType = "json";
            options.contentType = "application/json";
            options.success = function (states) {
                $("#state").empty();
                for (var i = 0; i < states.length; i++) {
                    $("#state").append("<option>" + states[i] + "</option>");
                }
                $("#state").prop("disabled", false);
            };
            options.error = function () { alert("Error retrieving states!"); };
            $.ajax(options);
        }
        else {
            $("#state").empty();
            $("#state").prop("disabled", true);
        }
    });
});