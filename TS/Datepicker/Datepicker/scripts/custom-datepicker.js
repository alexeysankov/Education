var CustomDate = (function () {
    function CustomDate(y, m) {
        this.y = y;
        this.m = m;
        if (m < 0) {
            this.year = y--;
            this.month = 11;
        }
        if (m > 11) {
            this.year = y++;
            this.month = 0;
        }
    }
    CustomDate.prototype.getYear = function () {
        return this.year;
    };
    CustomDate.prototype.getMonth = function () {
        return this.month;
    };
    CustomDate.prototype.nextMonth = function () {
        if (this.month === 11) {
            this.year++;
            this.month = 0;
        }
        else
            this.month++;
        return this;
    };
    CustomDate.prototype.prevMonth = function () {
        if (this.month === 0) {
            this.year--;
            this.month = 11;
        }
        else
            this.month--;
        return this;
    };
    CustomDate.prototype.currentDate = function () {
        this.year = new Date().getFullYear();
        this.month = new Date().getMonth();
        return this;
    };
    return CustomDate;
}());
function fillTemplate() {
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
}
;
fillTemplate();
var monthNames = [
    "January ", "February ", "March ", "April ", "May ", "June ",
    "July ", "August ", "September ", "October ", "November ", "December "
];
var globalDate = new CustomDate(new Date().getFullYear(), new Date().getMonth());
function fillCalendar(date) {
    var year = date.getYear();
    var month = date.getMonth();
    var lastDay = new Date(year, month + 1, 0).getDate();
    var lastDayOfWeek = new Date(year, month, lastDay).getDay();
    var firstDayOfWeek = new Date(year, month, 1).getDay();
    var calendar = "<tr>";
    $("#datepicker-month").text(monthNames[month]);
    $("#datepicker-year").text(year);
    if (firstDayOfWeek !== 0) {
        for (var i = 1; i < firstDayOfWeek; i++)
            calendar += "<td>";
    }
    else {
        for (var i = 0; i < 6; i++)
            calendar += "<td>";
    }
    for (var i = 1; i <= lastDay; i++) {
        if (i === new Date().getDate() && year === new Date().getFullYear() && month === new Date().getMonth())
            calendar += "<td class=\"today\"><div>" + i;
        else {
            //filling of holidays
            if (false) {
            }
            else {
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
        var date = new Date(globalDate.getYear(), globalDate.getMonth(), parseInt($(this).text()));
        $("#custom-datepicker").val(date.toLocaleDateString());
        $("#calendar-content").hide();
    });
}
;
$("#next").click(function () { fillCalendar(globalDate.nextMonth()); });
$("#prev").click(function () { fillCalendar(globalDate.prevMonth()); });
$("#custom-datepicker").click(function () {
    fillCalendar(globalDate.currentDate());
    $("#calendar-content").show();
});
