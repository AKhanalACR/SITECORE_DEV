

RLIEventCalendar = [];
if (RLIEventCalendar == null) {
    RLIEventCalendar = [];
}

var rliMonthEvents;
var firstCalendarBuild = true;

$(document).ready(function () {

	//verify we are on the calendar page
	if ($('.custom-calendar-wrap').length == 0) {
		//no calendar element, exiting
		return;
	}

	$('#chgFilters').on('click', function () {
		RLIEventCalendar.UpdateMonthYear();
	});

	$('.tabbed .tabs a').click(function () {
		RLIEventCalendar.AppendFilterOption($(this));
	});

	$('#ddEventTags').on('change', function () {
		RLIEventCalendar.UpdateFilterOption();
	});

	var dttm = new Date();
	RLIEventCalendar.GetMonthEvents(dttm);

});

RLIEventCalendar.AppendFilterOption = function(tab) {
	if (tab.attr("ID").indexOf("hlList") != -1) {
		document.location = "?tab=ListView&f=" + $('#hdnFilterOptionId').val();
	} else {
		document.location = document.location.href.split('?')[0] + "?f=" + $('#hdnFilterOptionId').val();
	}
};

RLIEventCalendar.GetMonthEvents = function (dttm) {

    var arguments = RLIEventCalendar.GetArguments(dttm);

    //make ajax request
    var jsonData = JSON.stringify({ args: arguments });
    jQuery.ajax({
        url: "/Services/RLIEvents.asmx/GetMonthEvents",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: 'POST',
        data: jsonData,
        success: function (data) {
            RLIEventCalendar.BuildMonthEvents(data.d), RLIEventCalendar.BuildCalendar()
        },
        error: function (request, error, errorThrown) {
            alert('An error has occurred in retrieving your data. Please try again.');
        }
    });
}

RLIEventCalendar.BuildCalendar = function () {

    if (!firstCalendarBuild) {
        cal.setData(rliMonthEvents);
    }
    else {
        $wrapper = $('#custom-inner'),
			$calendar = $('#calendar'),
			    cal = $calendar.calendario({
			        onDayClick: function ($el, $contentEl, dateProperties) {
			            //if there are day events, call show day events
			            if ($contentEl.length > 0) {
			                RLIEventCalendar.GetDayEvents($el, dateProperties);
			            }
			        },
			        caldata: rliMonthEvents,
			        displayWeekAbbr: true
			    }),
			    $month = $('#custom-month').html(cal.getMonthName()),
			    $year = $('#custom-year').html(cal.getYear());

        $('#custom-next').on('click', function () {
            cal.gotoNextMonth(RLIEventCalendar.UpdateMonthYear);
        });
        $('#custom-prev').on('click', function () {
            cal.gotoPreviousMonth(RLIEventCalendar.UpdateMonthYear);
        });

        firstCalendarBuild = false;
    }
}

//get current calendar event arguments
RLIEventCalendar.GetArguments = function (dttm) {
    
    dttm.setHours(dttm.getHours() - dttm.getTimezoneOffset() / 60);
    
    var arguments = new Object();
    arguments.EventDate = dttm;
    arguments.EventTagId = $('.fltrEvtTag').val();
    arguments.EventTypeId = $('.fltrEvtType').val();
    arguments.MonthEvents = null;
    arguments.DayEvents = null;

    return arguments;
}

//build the rliMonthEvents object for the month
RLIEventCalendar.BuildMonthEvents = function (args) {

    var events = "rliMonthEvents = {" + args.MonthEvents + "}";
    eval(events);
    
}

RLIEventCalendar.UpdateMonthYear = function () {
    var m = cal.getMonth();
    var y = cal.getYear();
    var mname = cal.getMonthName();

    $month.html(mname);
    $year.html(y);

    //adjust month integer for zero-based month array
    var dttm = new Date(y, m - 1, 1);
    RLIEventCalendar.GetMonthEvents(dttm);

}

// Get Day Events
RLIEventCalendar.GetDayEvents = function ($el, dateProperties) {
    //adjust month integer for zero-based month array
    dttm = new Date(dateProperties.year, dateProperties.month - 1, dateProperties.day);
    var arguments = RLIEventCalendar.GetArguments(dttm);

    //make ajax request
    var jsonData = JSON.stringify({ args: arguments });
    jQuery.ajax({
        url: "/Services/RLIEvents.asmx/GetDayEvents",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: 'POST',
        data: jsonData,
        success: function (data) {
            RLIEventCalendar.BuildDayEvents($el, data.d, dateProperties);
        },
        error: function (request, error, errorThrown) {
            alert('An error has occurred in retrieving your data. Please try again.');
        }
    });
}

//build event result set for day
RLIEventCalendar.BuildDayEvents = function ($el, d, dateProperties) {

	RLIEventCalendar.HideDayEvents;

	//clear result container
	var $popup = $('#calpop');
	$popup.html('');

	//append html for header and "close" button
	$popup.append('<h4>' + dateProperties.weekdayname + ', ' + dateProperties.monthname + ' ' + dateProperties.day + ', ' + dateProperties.year + '</h4>');
	var $close = $('<span class="calpop-close"></span>').on('click', RLIEventCalendar.HideDayEvents);
	$popup.append($close);

	//get results from EventArgs data object
	var results = d.DayEvents;
	if (results == null || results.length == 0) {
		$popup.append('<div class="evts"><p>There are no events for this day.</p></div>');
		return;
	}

	//get content: events merged with result template
	$.get('/js/rli/templates/CalendarDayPopup.html', function (htmlRetrieved) {
	var $content = $('<div class="evts"></div>');

		//compile template
		var template = _.template(htmlRetrieved);

		for (var key = 0; key< results.length; key++) {
			$content.append(template({ x: results[key] }));
		}
		//append html container with events
		$popup.append($content);
	});


	//set position
	var x = $el.position().top + 85;
	var y = ($el.position().left + $el.outerWidth()) + 2;
	$popup.css({ top: x, left: y });

	//show it!
	setTimeout(function () {
		$popup.show();
	}, 25);

}

// Hide events pop-up
RLIEventCalendar.HideDayEvents = function () {
    var $popup = $('#calpop');
    if ($popup.length > 0) {
        $popup.css({ top: 100, left: 50 });
        $popup.css('display', 'none');
    }
      }

RLIEventCalendar.UpdateFilterOption = function() {
	var filterOption = $('section.selected option:selected').val();
	$('#hdnFilterOptionId').val(filterOption);
};