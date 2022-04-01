import './polyfills/object-assign.js';
import headerAdButlerServe from './components/header-ad-butler.js';
import setMainSpacingTop from './components/site-header.js';
import iosOutsideClickSupport from './components/ios-click-support.js';
import './components/acr-navigation.js';
import './components/after-resize.js';
import './components/acr-tabs.js';
import './components/acr-sticky.js';
import scrollInView from './components/scroll-in-view.js';
import tooltips from './components/tool-tips.js';
import accordions from './components/accordions.js';
import getCookie, { setCookie, deleteCookie } from './components/cookies.js';
import scrollToTarget, { jumpToTargetOffset } from './components/target-scroll.js';
import './components/radios-checkboxes.js';
import iframeHeightResize from './components/iframe-resize.js';
import { squareItUp, resourceSlider, tabRotatingTiles, tabRotatingTilesUtility } from './components/resource-slider.js';
import multiFieldDatePicker from './components/multi-field-datepicker.js';
import lookForExternalUrlThenAddIcon from './components/add-external-icon.js';
import addBookmark, { deleteBookmark, addReccomended, reccomendClick, bookmarkClick } from './components/bookmarks.js';
import './plugin/jquery.touchSwipe.js';

import EqualizeContent from '@hilemangroup/plugins/src/equalize-content/jquery.equalize-content.js';
//import Parallax from '@hilemangroup/plugins/src/parallax-bg/jquery.parallax.js';
import BackgroundImageLoad from './components/background-img-load.js';

//not quite working :-/
// import Accordion from '@hilemangroup/plugins/src/accordion/jquery.accordion.js';
// function accordions(config){
// 	console.log('ehhh uhhh')
// 	$('.accordion-header','.accordion').each(function(){
// 		if( $(this).find('a').length === 0 ){
// 			console.log('no anchors so we adds')
// 			$('h2',this).wrapInner('<a href="#"/>');
// 		}
// 	});
//
// 	$('.accordion').accordion(config);
// }


function setLoginReturnUrl() {
    var loginLink = jQuery("#main-nav-login").find('a').each(function () {
        var href = jQuery(this).attr('href');
        var currentPath = encodeURIComponent(window.location.href);
        jQuery(this).attr('href', href += '?returnUrl=' + currentPath);
    })
}


function ACRSearchPageNavigate(e) {
    var searchInput = $(e).closest('.form-search').find('#header_tbSearch');
    var searchLink = $(e).closest('.form-search').find('#header_hlSearchLink');
    searchInput.attr("disabled", "disabled");
    if ($('.CoveoSearchPageSearchbox').find('input').length > 0) {
        $('.CoveoSearchPageSearchbox').find('input').val(searchInput.val());
        $('.CoveoSearchButton').find('.coveo-icon').click();
        searchInput.removeAttr("disabled", "");
        $(window).scrollTop($('h1').first().offset().top);
    } else {
        searchInput.removeAttr("disabled", "");
        if (searchLink.attr('data-url').indexOf('#') > 0) {
            window.location.href = searchLink.attr('data-url') + '&q=' + searchInput.val();
        } else {
            window.location.href = searchLink.attr('data-url') + '#q=' + searchInput.val();
        }
    }
    return false;
}

function checkTabsEvenlySpaced() {
    $('.tabs-evenly-spaced').each(function () {
        if ($(this).find('li').length === 1) {
            $(this).addClass('only-one-tab');
        }
    });
}


function keepIconFromBreakingToOwnLine(elem) {
    $(elem).each(function () {
        var cleanedHTML = $(this).html()
            .replace(/\r?\n|\r/g, '')
            .replace(/\s+/g, ' ').trim()
            .replace(' <span', '&nbsp;<span');

        $(this).html(cleanedHTML);
    });
}

function fixWffmForms() {
    $('form').each(function () {
        var form = $(this);
        var datawffm = form.attr('data-wffm');
        if (datawffm !== undefined) {
            if (datawffm.length > 0) {
                var submit = form.find('input[type="submit"]');

                submit.click(function () {
                    setTimeout(function () {
                        submit.attr('disabled', 'disabled');
                    }, 250);

                    setTimeout(function () {
                        submit.removeAttr('disabled');
                    }, 2000);
                });
            }
        }
    });
}

//Dalton Functions
function hideNotification() {
    jQuery("#dismissible-notification").hide();
    var notificationText = jQuery("#dismissible-notification .notification-bar-text").text();
    if (CookieConsent.consent.preferences) {
        deleteCookie("hiddenNotificationText");
        setCookie("hiddenNotificationText", notificationText);
    }
}


function acrTables(){
	$('table.has-acr-table').each(function () {
	    var tableParent = $(this).parent();
	    tableParent.scrollInView({
	        childItem: 'td',
	        $slideContainer: 'table',
	        breakPointsOnWindow: false
	    });
	});

	$('div.has-acr-table').each(function () {
	    $(this).find('table').each(function () {
	        var tableParent = $(this).parent();
	        tableParent.scrollInView({
	            childItem: 'td',
	            $slideContainer: 'table',
	            breakPointsOnWindow: false
	        });
	    });
	});
}

function reccomendOrBookmark(){
	const ls = location.search;
	const bookMarkOrRec = ( ls.indexOf('addReccomend=1') > 0 || ls.indexOf('addBookmark=1') > 0 )

	bookMarkOrRec && $(".reccommend-link").click();
}

//set some globals
(function(w){
	w.iosOutsideClickSupport = iosOutsideClickSupport;
	w.headerAdButlerServe = headerAdButlerServe;
	w.setMainSpacingTop = setMainSpacingTop;
	w.tooltips = tooltips;
	w.squareItUp = squareItUp;
	w.getCookie = getCookie;
	w.setCookie = setCookie;
	w.deleteCookie = deleteCookie;
	w.scrollToTarget = scrollToTarget;
	w.jumpToTargetOffset = jumpToTargetOffset;
	w.iframeHeightResize = iframeHeightResize;
	w.resourceSlider = resourceSlider;
	w.tabRotatingTiles = tabRotatingTiles;
	w.multiFieldDatePicker = multiFieldDatePicker;
	w.scrollInView = scrollInView;
	w.accordions = accordions;
	w.addBookmark = addBookmark;
	w.deleteBookmark = deleteBookmark;
	w.addReccomended = addReccomended;
	w.reccomendClick = reccomendClick;
	w.bookmarkClick = bookmarkClick;
	w.lookForExternalUrlThenAddIcon = lookForExternalUrlThenAddIcon;
	w.checkTabsEvenlySpaced = checkTabsEvenlySpaced;
	w.setLoginReturnUrl = setLoginReturnUrl;
	w.ACRSearchPageNavigate = ACRSearchPageNavigate;
	w.fixWffmForms = fixWffmForms;
	w.keepIconFromBreakingToOwnLine = keepIconFromBreakingToOwnLine;
	w.hideNotification = hideNotification;
})(window);

jQuery(function ($) {
    setMainSpacingTop();
		reccomendOrBookmark();
		tooltips();
		scrollToTarget();
    checkTabsEvenlySpaced();
    accordions();
    setLoginReturnUrl();
    jumpToTargetOffset();
    lookForExternalUrlThenAddIcon();
    lookForExternalUrlThenAddIcon({ outer: '#main-nav' });
		fixWffmForms();
		new BackgroundImageLoad();
    setTimeout(function () {
        $(window).trigger('setTopSpace');
    }, 10);

    $('#site-header').sticky({
        dontStickyCondition: function () {
            return ($('body').hasClass('desktop-nav-hovered'));
        }
    });
    $('#main-nav').acrDesktopNav({
        afterHovered: function () {
            $(window).trigger('StickyAnimate');
        }
    });
		$.iframeResize();
    $(window).on('load', function () {
        jumpToTargetOffset();
    });

    $('.tabs').scrollInView({
        childItem: 'li',
        slideWrapper: 'ul',
        scrollItemAmount: 1
    });
    $('.meeting-area').easyTabs({
        maintainTallest: false,
        callback: function (thisTabID, tabId) {
            $(window).trigger('scrollInView');
        }
    });

    $(".tab-container").easyTabs({
        maintainTallest: false,
        callback: function (thisTabID, tabId) {
            $(window).trigger('scrollInView');
        }
    });
});

jQuery('.remove-bookmark').click(function () {
    var result = confirm("Are you sure you want to remove this from your reading list?");
    if (result) {
        jQuery(this).closest('.lg-col-6').hide();
        var id = jQuery(this).attr('data-bookmark-id');
        deleteBookmark(id);
    }
});

//JT FUNCTIONS
$('#header_tbSearch').on('keypress', function (e) {
    if (e.which === 13) {
        ACRSearchPageNavigate(this);
    }
});

$('#header_hlSearchLink').click(function () {
    ACRSearchPageNavigate(this);
});

jQuery('.log-out').click(function () {
    window.location.href = jQuery(this).find('a').first().attr('href')
});

if (getCookie("hiddenNotificationText") !== $("#dismissible-notification .notification-bar-text").text()) {
    jQuery('#dismissible-notification').show();
}

jQuery('#newsletter-email-tb').keypress(function (e) {
    if (e.which == 13) {
        jQuery('#newsletter-submit-btn').click();
    }
});
