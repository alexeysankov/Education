function FillTemplate() {
    var datepicker = "<div class=\"calendar\" id=\"calendar-content\">" +
        "<table class=\"calendar-table\">" +
        "<thead>" +
        "<tr>" +
        "<td colspan=\"4\">" +
        "<select id=\"days-of-week\">" +
        "<option value=\"0\">Junuary</option>" +
        "<option value=\"1\">February</option>" +
        "<option value=\"2\">March</option>" +
        "<option value=\"3\">April</option>" +
        "<option value=\"4\">May</option>" +
        "<option value=\"5\">June</option>" +
        "<option value=\"6\">July</option>" +
        "<option value=\"7\">August</option>" +
        "<option value=\"8\">September</option>" +
        "<option value=\"9\">October</option>" +
        "<option value=\"10\">November</option>" +
        "<option value=\"11\">December</option>" +
        "</select>" +
        "<td colspan=\"3\">" +
        "<input type=\"number\" id=\"year\" min=\"1970\" max=\"9999\" maxlength=\"4\">" +
        "<tr><td>Mo<td>Tu<td>We<td>Th<td>Fr<td>Sa<td class=\"ui-datepicker-week-end\">Su" +
        "<tbody id=\"calendar-body\"></tbody>" +
        "</table>" +
        "</div>";
    $("#custom-datepicker").after(datepicker);
};

FillTemplate();

function FillCalendar(year, month) {
    month = parseInt(month);
    year = parseInt(year);
    var lastDay = new Date(year, month + 1, 0).getDate();
    var lastDayOfWeek = new Date(year, month, lastDay).getDay();
    var firstDayOfWeek = new Date(year, month, 1).getDay();
    var calendar = "<tr>";

    $("#days-of-week option[value='" + month + "']").prop("selected", true);
    $("#year").val(year);

    if (firstDayOfWeek !== 0) {
        for (var i = 1; i < firstDayOfWeek; i++)
            calendar += "<td>";
    } else {
        for (var i = 0; i < 6; i++)
            calendar += "<td>";
    }

    for (var i = 1; i <= lastDay; i++) {
        if (i === new Date().getDate() && year === new Date().getFullYear() && month === new Date().getMonth())
            calendar += "<td class=\"today\"><div>" + i;
        else {
            //filling of holidays
            if (false) { //(i == 23 && D.getMonth() == 1 && D.getFullYear() > 2001)
                calendar += "<td class=\"holiday\"><div>" + i;
            } else {
                calendar += "<td><div>" + i;
            }
        }
        if (new Date(year, month, i).getDay() === 0) {
            calendar += "<tr>";
        }
    }

    for (var i = lastDayOfWeek; i < 7; i++)
        calendar += "<td>&nbsp;";

    $("#calendar-body").empty().append(calendar);

    $("#calendar-body tr td div").click(function () {
        var date = new Date(parseInt($("#year").val()), parseInt($("#days-of-week").val()), $(this).text());
        $("#custom-datepicker").val(date.toLocaleDateString());
        $("#calendar-content").hide();
    });

    $("#days-of-week").change(function () { FillCalendar($("#year").val(), $("#days-of-week").val()) });
    $("#year").change(function () { FillCalendar($("#year").val(), $("#days-of-week").val()) });    
};

$("#custom-datepicker").click(function () {
    FillCalendar(new Date().getFullYear(), new Date().getMonth());
    $("#calendar-content").show();
});