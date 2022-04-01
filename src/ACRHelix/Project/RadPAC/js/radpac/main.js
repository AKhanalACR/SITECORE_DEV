$(document).ready(function () {
    //resize select
    var $this = $('#ddl-state-selector-2');
    var text = GetPageUrl();
    resizeSelect($this, text);

    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });

    $('.back-to-top').click(function () {
        $('html, body').animate({
            scrollTop: 0
        }, 600);
        return false;
    });
    
    $('.dropdown-sub').click(function (e) {
        $(this).find('.nav-item-drop-menu').toggleClass('open');
        // $($(e.target).find('.fa-angle-double-right').toggleClass('rotate'));
        // e.preventDefault();
        e.stopPropagation();
        $(document).click(function () {
            $('.nav-item-drop-menu').removeClass('open');
            // $('.fa-angle-double-right').removeClass('rotate');
        });
    });
    
    $(window).on('resize load', function (e) {
        width = $(window).width();
        if (width >= 1200) {
            $('.dropdown-toggle').find('.fa-angle-double-right').removeClass('fa-angle-double-right').addClass('fa-caret-down');
        }
        else {
            $('.dropdown-toggle').find('.fa-caret-down').removeClass('fa-caret-down').addClass('fa-angle-double-right');
        }
    });

    //$(window).scroll(function () {
    //    if ($(window).scrollTop() >= 160) {
    //        $('header').addClass('sticky');
    //    }
    //    else {
    //        $('header').removeClass('sticky');
    //    }
    //});


    // Banner background-image
    if ($('#main-body').length) {
        var bgUrl = $("#banner-backgroundImage").attr("src");
        $(".banner-wrapper").backstretch(bgUrl);
    }

    //search box mobile
    $(".search-top-mobile").click(function () {
        $(".mobile-search-bar").slideDown('fast');
    });

    $('.search-close').click(function () {
        $('.mobile-search-bar').slideUp('fast');
    });

    $(".search-top").click(function () {
        $(".search-bar").toggle("slide", { direction: "right" }, 200);
        $(".search-top").toggleClass('active');
        $("i", this).toggleClass("fa fa-close fa fa-search");
    });

    //mobile collapse
    $('.animated-collapse-button').on('click', function () {
        $('.animated-collapse').toggleClass('open');
    });

    //banner scrollerGradient
    $("#demo").scrollForever({

        // distance between slides
        placeholder: 0,

        // scroll direction. left or top
        dir: 'top',

        // container element
        container: 'ul',

        // inner element
        inner: 'li',

        // animation speed
        speed: 1000,

        // slide interval
        delayTime: 40,

        // continuous scroll
        continuous: true,

        // how many slides to slide at a time
        num: 1
    });

    // Basic FitVids Test
    $(".container").fitVids();

    // Custom selector and No-Double-Wrapping Prevention Test
    $(".container").fitVids({ customSelector: "iframe[src^='http://socialcam.com']" });

    //chapter challenge bracket division
    $('#divisionSelector').change(function () {
        var value = $(this).val();
        if (value == '' || value == undefined) {
            $('.division').show();
        } else {
            $('.division').hide();
            $('#' + value).show();
        }
    });

    //contribution page
    $('#state-selector').change(function () {
        //resize select
        var $this = $(this);
        var text = $this.find("option:selected").text();
        resizeSelect($this, text);

        var value = $this.val();
        if (value == '' || value == undefined) {
            // do nothing
        } else {
            window.location.href = $('#mapcontainer').attr('data-parent-item') + '/' + $('#state-selector :selected').text().replace(/ /g, '-');
        }
    });

    //default selection
    $('#ddl-state-selector-2 option').filter(function () { return $.trim($(this).text()).toLowerCase() == GetPageUrl() }).prop('selected', true);

    //state by state
    $('#ddl-state-selector-2').change(function () {
        //resize select
        var $this = $(this);
        var text = $this.find("option:selected").text();
        resizeSelect($this, text);

        var value = $this.val();
        if (value == '' || value == undefined) {
            // do nothing
        } else {
            window.location.href = $('#ddl-state-selector-2').attr('data-parent-item') + '/' + $('#ddl-state-selector-2 :selected').text().replace(/ /g,'-');
        }
    });

    //search box desktop
    $('#rp-searchbox').on('keypress', function (e) {
        if (e.which === 13) {
            SearchPageNavigate(this);
        }
    });

    //search box mobile
    $('#rp-searchbox-mobile').on('keypress', function (e) {
        if (e.which === 13) {
            SearchPageNavigate(this);
        }
    });

    //login page validation
    $('.form-signin').find('#loginSubmitBtn').on('click', function () {
        if ($('.form-signin').find('#inputName').val() == undefined || $('.form-signin').find('#inputName').val() == '') {
            return false
        }

        if ($('.form-signin').find('#inputPassword').val() == undefined || $('.form-signin').find('#inputPassword').val() == '') {
            return false
        }
    });

    $('.form-signin').find('#loginSubmitBtn').on('keypress', function (e) {
        if (e.which === 13) {
            if ($('.form-signin').find('#inputName').val() == undefined || $('.form-signin').find('#inputName').val() == '') {
                return false
            }

            if ($('.form-signin').find('#inputPassword').val() == undefined || $('.form-signin').find('#inputPassword').val() == '') {
                return false
            }
        }
    });
});


//nav toggle link
function tabEvent(e) {
    var target = $(e.currentTarget);
    var isOpen = target.attr('aria-expanded') == 'true';
    if (isOpen) {
        var link = target.attr('href');
        window.location.href = link;
    }
    return false;
}

//seach box redirect
function SearchPageNavigate(e) {
    var searchInput = $(e); 
    var searchLink = $('.search-bar').find('#rp-searchbox');
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

//get page url
function GetPageUrl() {
    var vars = window.location.href.split('/');
    return vars[vars.length - 1].toLowerCase().replace(/-/g, ' ');
}

//resize select
function resizeSelect(selector, txt) {
    var arrowWidth = 30;
    var $this = selector;
    var text = txt;
    var $temp = $("<span>").html(text).css({
        "font-size": $this.css("font-size"), // ensures same size text
        "visibility": "hidden" 				 // prevents FOUC
    });

    // add to body, get width, and get out
    $temp.appendTo($this.parent());
    var width = $temp.width();
    $temp.remove();
    $this.width(width + arrowWidth);
}