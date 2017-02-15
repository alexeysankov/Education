function FillTemplate() {
    var datepicker = "<div class=\"calendar\" id=\"calendar-content\">" +
        "<table class=\"calendar-table\">" +
        "<thead>" +
        "<tr>" +
        "<td colspan=\"7\">" +
        "<div class=\"datepicker-header\">" +
        "<div class=\"datepicker-title\">" +
        "<span id=\"datepicker-month\">MMMM&nbsp;</span>" +
        "<span id=\"datepicker-year\">YYYY</span>" +
        "</div>" +
        "<a id=\"next\" class=\"next\">" +
        "<span>></span>" +
        "<a id=\"prev\" class=\"prev\">" +
        "<span><</span>" +
        "</div>" +
        "<tr><td>Mo<td>Tu<td>We<td>Th<td>Fr<td>Sa<td>Su" +
        "<tbody id=\"calendar-body\"></tbody>" +
        "</table>" +
        "</div>";
    $("#custom-datepicker").after(datepicker);
};

FillTemplate();

var monthNames = [
        "January ", "February ", "March ", "April ", "May ", "June ",
        "July ", "August ", "September ", "October ", "November ", "December "
];

var yearGlobal = new Date().getFullYear();
var monthGlobal = new Date().getMonth();

function FillCalendar(year, month) {
    if (month < 0) {
        year--;
        month = 11;
    }        
    if (month > 11) {
        year++;
        month = 0;
    }
    yearGlobal = year;
    monthGlobal = month;
    var lastDay = new Date(year, month + 1, 0).getDate();
    var lastDayOfWeek = new Date(year, month, lastDay).getDay();
    var firstDayOfWeek = new Date(year, month, 1).getDay();
    var calendar = "<tr>";

    $("#datepicker-month").text(monthNames[month]);
    $("#datepicker-year").text(year);

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
        var date = new Date(yearGlobal, monthGlobal, $(this).text());
        $("#custom-datepicker").val(date.toLocaleDateString());
        $("#calendar-content").hide();
    });
};

$("#next").click(function () { FillCalendar(yearGlobal, monthGlobal + 1) });
$("#prev").click(function () { FillCalendar(yearGlobal, monthGlobal - 1) });

$("#custom-datepicker").click(function () {
    FillCalendar(new Date().getFullYear(), new Date().getMonth());
    $("#calendar-content").show();
});