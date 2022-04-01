import headerAdButlerServe from './header-ad-butler.js';
import getCookie, {setCookie,deleteCookie} from './cookies.js';

export default function setMainSpacingTop() {
	var timer;

	//need the onload method because there's an image!
	$(document).on("load ready", function () {
		$('main').css('margin-top', ($('#site-header-outer').height()) + "px");
	});

	$(window).on("scroll resize setTopSpace", function () {
		clearTimeout(timer);
		timer = setTimeout(function () {
			if (!headerIsSticky) {
				$('main').css('margin-top', ($('#site-header-outer').height()) + "px");
			}
		}, 200);
	});
}


(function ($) {
    "use strict";
    window.displayHeaderAd = (getCookie("hideHeaderBanner") === "") ? true : false;

    if (displayHeaderAd) {
        $('#site-header-ad').addClass('ad-is-visible');
        $('body').addClass('site-header-ad-visible');
        headerAdButlerServe();
    }
    $('#header-ad-btn').on("click", function () {
        var adIsVisible = $('#site-header-ad').hasClass('ad-is-visible'),
            siteHeaderAdHeight = $('#site-header-ad-inner').outerHeight();

        if (!adIsVisible) {
            $('#site-header-ad').find('.content').slideDown(400, function () {
                $('#site-header-ad').addClass('ad-is-visible')
                    .find('.content').removeAttr("style");
            });
            $('main').animate({
                'margin-top':
                ($('#site-header-outer').height() + siteHeaderAdHeight) + "px"
            }, 400, function () {
                $(window).trigger('setTopSpace');
            });

            deleteCookie("hideHeaderBanner");
            displayHeaderAd = true;
        } else {

            $('#site-header-ad').find('.content').slideUp(400, function () {
                $('#site-header-ad').removeClass('ad-is-visible')
                    .find('.content').removeAttr("style");

                $('body').removeClass('site-header-ad-visible');

            });
            $('main').animate({
                'margin-top':
                ($('#site-header-outer').height() - siteHeaderAdHeight - 1) + "px"
            }, 400, function () {
                $(window).trigger('setTopSpace');
            });

            if (CookieConsent.consent.preferences) {
                setCookie("hideHeaderBanner", "hide ad", 365); console.log(getCookie("hideHeaderBanner"));
            }
            displayHeaderAd = false;
        }
        headerAdButlerServe();
    });
})(jQuery);
