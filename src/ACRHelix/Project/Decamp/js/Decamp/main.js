$(function () {
    // Main Nav indication
    $('#main-nav').find('.nav-link').click(function () {
        $('.nav-link').removeClass('current');
        $(this).addClass('current');
    });

    if ($('#main-body').length) {
        $('.callout').each(function (d, i) {
            var bgUrl = $(this).find(".callout-backgroundImage").attr("src");
            $(this).find(".callout-wrapper").backstretch(bgUrl);
        });
    }

    $(".navbar-nav li a").filter(function () {
        return this.href == location.href.replace(/#.*/, "");
    })
    .addClass("nav-active")
    .closest('ul')
    .prev('a')
    .addClass("nav-active");

    // Banner background-image
    if ($('#main-body').length) {
        var bgUrl = $("#banner-backgroundImage").attr("src");
        $(".banner-wrapper").backstretch(bgUrl);
    }

    //sticky navbar
    $(window).scroll(function () {
        if ($(window).scrollTop() > 50) {
            $('.navbar-wrapper').addClass("shadow");
        } else {
            $('.navbar-wrapper').removeClass("shadow");
        }
    });

    //search box
    $(".search-top").click(function () {
        $(".search-bar").toggle("slide", { direction: "left" }, 10);
        $(".search-top").toggleClass('active');
        if ($(this).children(".search-text").text() == "Search") {
            $(this).children(".search-text").text("X Close");
        }
        else {
            $(this).children(".search-text").text("Search");
        }
    });

    //mobile collapse
    $('.animated-collapse-button').on('click', function () {
        $('.animated-collapse').toggleClass('open');
    });

    
    
});

//main nav events
function tabEvent(e) {
    var target = $(e.currentTarget);
    var isOpen = target.attr('aria-expanded') == 'true';
    if (isOpen || !target.siblings(".dropdown-menu").length) {
        var link = target.attr('href');
        window.location.href = link;
    }
    return false;
}

//search box desktop
$('#decamp-searchbox').on('keypress', function (e) {
    if (e.which === 13) {
        SearchPageNavigate(this);
    }
});

//seach box redirect
function SearchPageNavigate(e) {
    var searchInput = $(e);
    var searchLink = $('.search-bar').find('#decamp-searchbox');
    searchInput.attr("disabled", "disabled");
    if ($('.CoveoSearchPageSearchbox').find('input').length > 0) {
        $('.CoveoSearchPageSearchbox').find('input').val(searchInput.val());
        $('.CoveoSearchButton').find('.coveo-icon').click();
        searchInput.removeAttr("disabled", "");
        $(window).scrollTop($('h1').first().offset().top);
    } else {
        searchInput.removeAttr("disabled", "");
        window.location.href = searchLink.attr('data-url') + '#q=' + searchInput.val();
    }
    return false;
}


