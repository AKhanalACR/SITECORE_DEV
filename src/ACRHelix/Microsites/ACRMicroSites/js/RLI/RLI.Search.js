//*****************************************************
// Author: Tim Braga - Velir
// Email: tim.braga@velir.com
// Date: 03/21/2013
// RLI Search
//*****************************************************

RLI = [];
if (RLI == null) {
	RLI = [];
}

if (RLI.Search == null) {
	RLI.Search = [];
}

$(document).ready(function () {

	RLI.Search.InitializeSearchBox();

	//verify we are on the search page
	if ($('#rliSearchList').length == 0) {
		//no search element, exiting
		return;
	}
	RLI.Search.Log(RLI.Search.GetParameterByName('q'));
	if (RLI.Search.GetParameterByName('q') == "") {
		$('div.terms').html("No search terms");
		$('div.pagination').hide();
		//no search parameter, exiting
		return;
	}
	var arguments = RLI.Search.GetArguments();
	//retrieve page parameters
	RLI.Search.PerformSearch(arguments);
});

RLI.Search.Log = function (obj) {
	if (window.console && console.log) console.log(obj);
}

RLI.Search.InitializeSearchBox = function () {
		$('#searchbox').on("keydown", function (e) {
			var keycode = (e.keyCode ? e.keyCode : e.which);
			if (keycode == '13') {
				if ($(e.target).prop("type") === "textarea") {
					return;
				}
				e.preventDefault();
				e.stopPropagation();
				$('#searchlink').click();
				return false;
			}
			return;
		});
	$('#searchlink').click(function (e) {
		e.preventDefault();
		e.stopPropagation();
		window.location.href = '/search' + '?q=' + $('#searchbox')[0].value;
	});
	
}

//perform search query
RLI.Search.PerformSearch = function (args) {
	//verify we are on the search page
	if ($('.list, .search').length == 0) {
		RLI.Search.Log('no search element, exiting');
		return;
	}

	//make ajax request
	var jsonData = JSON.stringify({ args: args });
	jQuery.ajax({
		url: "/Services/RLISearch.asmx/PerformSearch",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		type: 'POST',
		data: jsonData,
		success: function (data) {
			RLI.Search.SetPage(data.d);
		},
		error: function () {
			RLI.Search.Log('RLISearch call failed: PerformSearch');
		}
	});
}

//get current search arguments
RLI.Search.GetArguments = function () {
	var arguments = new Object();
	arguments.SearchText = RLI.Search.GetParameterByName("q").replace(/<(?:.|\n)*?>/gm, '');
	arguments.Pages = 2;
	arguments.PageNumber = 1;
	arguments.ResultsPerPage = 10;
	arguments.NumberOfResults = 20;
	arguments.Results = null;

	return arguments;
}

//sets page against search arguments
RLI.Search.SetPage = function (args) {
	RLI.Search.BuildResults(args.Results);
	RLI.Search.BuildPagination(args);
	RLI.Search.BuildPreviousNext(args);
	RLI.Search.SetSearchTerm(args.SearchText);
	RLI.Search.SetResultInfo(args);
}

//builds previous and next buttons
RLI.Search.BuildPreviousNext = function (args) {
	RLI.Search.BuildPrevious(args);
	RLI.Search.BuildNext(args);
}

//builds previous buttons
RLI.Search.BuildPrevious = function (args) {
	//verify the number of pages

	if (args.Pages <= 1) {
		$('.previousButtons').hide();
		return;
	}

	//do not show if this is the first page
	if (args.PageNumber == 1) {
		$('.previousButtons').hide();
		return;
	}

	//show previous buttons
	$('.previousButtons').show();
	$('.previousButtons').unbind("click");
	$('.previousButtons').click(function () {
		args.PageNumber = args.PageNumber - 1;
		RLI.Search.PerformSearch(args);
		RLI.Search.SetPage(args);
	});
}



//builds next buttons
RLI.Search.BuildNext = function (args) {

	//verify the number of pages
	if (args.Pages <= 1) {
		$('.nextButtons').hide();
		return;
	}

	//do not show if this is the last page
	if (args.Pages == args.PageNumber) {
		$('.nextButtons').hide();
		return;
	}

	//show next buttons
	$('.nextButtons').show();
	$('.nextButtons').unbind("click");
	$('.nextButtons').click(function () {
		args.PageNumber = args.PageNumber + 1;
		RLI.Search.PerformSearch(args);
		RLI.Search.SetPage(args);
	});
}

//builds top and bottom pagination
RLI.Search.BuildPagination = function (args) {

	//clear pagination before rebuilding
	$('#searchTopPagination').html('');
	$('#searchBottomPagination').html('');

	//get result template
	$.get('/js/rli/templates/paginationItem.html', function (htmlRetrieved) {

		//compile template
		var template = _.template($(htmlRetrieved).html());

		for (var i = 1; i <= args.Pages; i++) {
			var html = template({ name: i, currentPage: args.PageNumber });

			$('#searchTopPagination').append(html);
			$('#searchBottomPagination').append(html);
			RLI.Search.SetPaginationLink(args, i);
		}
	});
}

RLI.Search.SetPaginationLink = function (args, pagenum) {
	$('a.pagination' + pagenum).click(function () {
		args.PageNumber = pagenum;
		RLI.Search.PerformSearch(args);
		RLI.Search.SetPage(args);
	})
}

//sets the search term
RLI.Search.SetSearchTerm = function (searchText) {
	$('#searchTerm').html(searchText);
}

//sets result numbering, pagination range, totals
RLI.Search.SetResultInfo = function (args) {
	var of = args.PageNumber * 10;
		var from = (args.PageNumber - 1) * 10 + 1;
	if (args.NumberOfResults == 0) {
		$('.count').html('No Results found');
		return;
	}
	if (args.NumberOfResults < of) {
		of = args.NumberOfResults;
		$('.count').html('Showing Results ' + from + ' - ' + of);
	}
	else {
		$('.count').html('Showing Results ' + from + ' - ' + of + ' of ' + args.NumberOfResults);
	}
}

//build search result set
RLI.Search.BuildResults = function (results) {

	//clear result container
	$('#searchResultsContainer').html('');

	if (results == null || results.length == 0) {
		return;
	}

	//get result template
	$.get('/js/rli/templates/searchResultItem.html', function (htmlRetrieved) {

		//compile template
		var template = _.template($(htmlRetrieved).html());
		
		for (var key = 0; key < results.length; key++) {
			$('#searchResultsContainer').append(template({ x: results[key] }));
		}
	});

}

RLI.Search.GetParameterByName = function(name) {
	name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
	var regexS = "[\\?&]" + name + "=([^&#]*)";
	var regex = new RegExp(regexS);
	var results = regex.exec(window.location.href);
	if (results == null)
		return "";
	else
		return decodeURIComponent(results[1].replace(/\+/g, " "));
}