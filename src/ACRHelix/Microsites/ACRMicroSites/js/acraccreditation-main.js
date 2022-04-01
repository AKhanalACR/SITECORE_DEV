/*AFTER RESIZE script... minified*/
!function (n) { "use strict"; var t, i = { action: function () { }, runOnLoad: !1, duration: 200 }, a = i, e = !1, o = {}; o.init = function () { for (var t = 0; t <= arguments.length; t++) { var i = arguments[t]; switch (typeof i) { case "function": a.action = i; break; case "boolean": a.runOnLoad = i; break; case "number": a.duration = i } } return this.each(function () { a.runOnLoad && a.action(), n(this).resize(function () { o.timedAction.call(this) }) }) }, o.timedAction = function (n, i) { var o = function () { var n = a.duration; if (e) { var i = new Date - t; if (n = a.duration - i, 0 >= n) return clearTimeout(e), e = !1, void a.action() } r(n) }, r = function (n) { e = setTimeout(o, n) }; t = new Date, "number" == typeof i && (a.duration = i), "function" == typeof n && (a.action = n), e || o() }, n.fn.afterResize = function (n) { return o[n] ? o[n].apply(this, Array.prototype.slice.call(arguments, 1)) : o.init.apply(this, arguments) } }(jQuery);

var iframeHeight = function (elem) {
    var h = jQuery(elem).attr('height'),
        w = jQuery(elem).attr('width'),
        ratio = h / w,
        computedWidth = jQuery(elem).width(),
        newHeight = (Math.floor(computedWidth * ratio) + 30) + 'px';

    //now it gets a brand new height!
    jQuery(elem).css('height', newHeight);
}

//scroll to modality step
if (location.hash) {
    setTimeout(function () {
        window.scrollTo(0, 0);
    }, 1);
}

jQuery(window).load(function () {
    jQuery(".starter-steps").find('a[href="' + window.location.hash + '"]').click();
});

jQuery(function ($) {

    $(".ddlFindByOption").hide();
    $("#mam-zip-city").show();
    $("label[for='mam-zip-city']").show();

    $("#ddlFindBy").change(function () {
        $(".ddlFindByOption").hide();
        var sel = $(this).val();
        switch (sel) {
            case "mam-zip-city":
                $("#mam-zip-city").show();
                $("label[for='mam-zip-city']").show();
                break;
            case "mam-state":
                $("#mam-state").show();
                $("label[for='mam-state']").show();
                break;
            case "mam-country":
                $("#mam-country").show();
                $("label[for='mam-country']").show();
                break;
            case "mam-facility-name":
                $("#mam-facility-name").show();
                $("label[for='mam-facility-name']").show();
                break;
        }

    });

    $("#mammoSearchBtn").click(function () {

        var url = "/accredited-facility-search?";

        if ($("#mam-zip-city").is(":visible")) {
            var zipVal = $("#mam-zip-city").val();
            if (zipVal.length > 0) {
                url += "cityzip=" + encodeURIComponent(zipVal);
            }
        }

        if ($("#mam-state").is(":visible")) {
            var stateVal = $("#mam-state").val();
            if (stateVal.length > 0) {
                url += "state=" + encodeURIComponent(stateVal);
            }
        }

        if ($("#mam-country").is(":visible")) {
            var countryVal = $("#mam-country").val();
            if (countryVal.length > 0) {
                url += "country=" + encodeURIComponent(countryVal);
            }
        }

        if ($("#mam-facility-name").is(":visible")) {
            var facVal = $("#mam-facility-name").val();
            if (facVal.length > 0) {
                url += "facilityname=" + encodeURIComponent(facVal);
            }
        }

        url += "&modality=MAP";
        window.location.href = url;
        return false;
    });





    /*MAIN NAVIGATION*/
    $('#mobile-btn').click(function (e) {
        menuToggle('#mobile-btn', "#main-nav");
        e.stopPropagation();
    });
    $('html,body').click(function (event) {
        if ($('#mobile-btn').hasClass('opened')) {
            //preventing this from closing when selecting a sub-nav in mobile
            //its parent is a unordered list
            if (event.target.parentNode.nodeName.toLowerCase() !== 'ul') {
                menuToggle('#mobile-btn', "#main-nav");
            }
        }
    });

    /*so subnav stays put if not hovered over for less 1 second on desktop*/
    var mainNavHoverTimeout;
    $('#main-nav').find('ul').on('mouseout', '> li', function () {
        var that = this;
        $('#main-nav').find('li').removeClass('hover');
        $(this).addClass('hover');
        clearTimeout(mainNavHoverTimeout);
        mainNavHoverTimeout = setTimeout(function () {
            $(that).removeClass('hover');
        }, 1000);
    });

    var menuToggle = function (el, nav) {
        //so we can pass just one argument if two aren't needed
        els = arguments.length > 1 ? nav + ', ' + el : el;
        if ($(els).hasClass('opened')) {
            $(els).removeClass('opened')
                .find('.opened').removeClass('opened');
            $('.header-logo').removeClass('opened');
        } else {
            $(els).addClass('opened');
            $('.header-logo').addClass('opened');
        }
    }
    //Replace this snippet with some code thats rendered
    $('#main-nav > ul').find('> li > ul').each(function () {
        if ($(this).text().length > 0)
            $(this).wrap("<div class='content dropdown'></div>");
    });

    jQuery('.dropdown').each(function () {
        var navSupport = jQuery(this).next('.navSupport');
        if (navSupport.find('a').length) {
            jQuery(this).append("<div class=\"navSupport-border\"></div>");
            jQuery(this).append(navSupport);
        }
    });

    /*SCROLL TO*/
    $("a[href^='#']").on('click', this, function (e) {
        var theHref = this.href.split("#")[1];
        var target = $('a[name="' + theHref + '"]');
        if (target.length > 0) {
            e.preventDefault();
            var theTime = Math.abs(Math.floor($(this).offset().top - target.offset().top) * .5) + 500;
            var addedCauseHeader = $('header').outerHeight(true);
            $('body,html').animate({
                scrollTop: (target.offset().top - addedCauseHeader)
            }, theTime);
        }
    });

    //ON PAGE LOAD
    //if we have an iframe, lets run the function on the page
    if (jQuery('iframe').length > 0) {
        jQuery(window).afterResize(function () {
            jQuery('iframe').each(function (index, element) {
                iframeHeight(this);
            });
        });
        jQuery('iframe').each(function (index, element) {
            iframeHeight(this);
        });
    }

});

//scroll to section fix
jQuery(document).ready(function ($) {
    if ($(window.location.hash).offset() != undefined) {
        $("html, body").animate({ scrollTop: $(window.location.hash).offset().top - 250 }, 500);
    }
});