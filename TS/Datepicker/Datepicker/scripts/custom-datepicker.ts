class CustomDate {
    private year: number;
    private month: number;

    constructor(public y, public m) {
        if (m < 0) {
            this.year = y--;
            this.month = 11;
        }
        if (m > 11) {
            this.year = y++;
            this.month = 0;
        }
    }

    getYear() {
        return this.year;
    }

    getMonth() {
        return this.month;
    }

    nextMonth() {
        if (this.month === 11) {
            this.year++;
            this.month = 0;
        } else
            this.month++;
        return this;
    }

    prevMonth() {
        if (this.month === 0) {
            this.year--;
            this.month = 11;
        } else
            this.month--;
        return this;
    }

    currentDate() {
        this.year = new Date().getFullYear();
        this.month = new Date().getMonth();
        return this;
    }
}

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
};

fillTemplate();

var monthNames = [
    "January ", "February ", "March ", "April ", "May ", "June ",
    "July ", "August ", "September ", "October ", "November ", "December "
];

var globalDate = new CustomDate(new Date().getFullYear(), new Date().getMonth());

function fillCalendar(date: CustomDate) {
    
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
                //calendar += "<td class=\"holiday\"><div>" + i;
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
        var date = new Date(globalDate.getYear(), globalDate.getMonth(), parseInt($(this).text()));
        $("#custom-datepicker").val(date.toLocaleDateString());
        $("#calendar-content").hide();
    });
};

$("#next").click(() => { fillCalendar(globalDate.nextMonth()) });
$("#prev").click(() => { fillCalendar(globalDate.prevMonth()) });

$("#custom-datepicker").click(() => {
    fillCalendar(globalDate.currentDate());
    $("#calendar-content").show();
});