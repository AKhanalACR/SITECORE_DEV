/*!
 *
   Hileman's
   Base-Frame version: 1.1.0
 *
 */
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

            setCookie("hideHeaderBanner", "hide ad", 365); console.log(getCookie("hideHeaderBanner"));
            displayHeaderAd = false;
        }
        headerAdButlerServe();
    });
})(jQuery);

//for IOS devices to work with an outside click, the body
//must have the style 'cursor: pointer'
var iosOutsideClickSupport = {
    styleAdded: false,
    is_ios: navigator.userAgent.toLowerCase().match(/(iphone|ipod|ipad)/) ? true : false,
    add: function () {
        "use strict";
        var _ = this;
        if (_.is_ios && !_.styleAdded) {
            $('body').css({ cursor: 'pointer' });
            console.log('added once ' + _.styleAdded);
            _.styleAdded = true;
        }
    }
};

/*Plugin: $(elem).afterResize()*/
!function (n) { "use strict"; var t, i = { action: function () { }, runOnLoad: !1, duration: 200 }, a = i, e = !1, o = {}; o.init = function () { for (var t = 0; t <= arguments.length; t++) { var i = arguments[t]; switch (typeof i) { case "function": a.action = i; break; case "boolean": a.runOnLoad = i; break; case "number": a.duration = i } } return this.each(function () { a.runOnLoad && a.action(), n(this).resize(function () { o.timedAction.call(this) }) }) }, o.timedAction = function (n, i) { var o = function () { var n = a.duration; if (e) { var i = new Date - t; if (n = a.duration - i, 0 >= n) return clearTimeout(e), e = !1, void a.action() } r(n) }, r = function (n) { e = setTimeout(o, n) }; t = new Date, "number" == typeof i && (a.duration = i), "function" == typeof n && (a.action = n), e || o() }, n.fn.afterResize = function (n) { return o[n] ? o[n].apply(this, Array.prototype.slice.call(arguments, 1)) : o.init.apply(this, arguments) } }(jQuery);

/*Plugin: $(elem).equalizeContent()*/
!function (e) { var t = function (e, t) { var i = this; return i.el = e, i.param = jQuery.extend({ equalizeItem: ".equalize", pattern: null, responsive: null, smartPattern: !0, startWidth: null, stopWidth: 640, timerDelay: 100, resizeItem: window }, t), i.init(i.el, i.param), i }; t.prototype.init = function () { var t, i = this; return e(i.param.resizeItem).on("resize imgsLoaded equalizeContent load", function (e) { clearTimeout(t), t = setTimeout(function () { i.equalize() }, i.param.timerDelay) }), i.imgsLoadedEvent(), i }, t.prototype.imgsLoadedEvent = function () { var t = this, i = e("img", t.el).length - 1, a = 0; e("img", t.el).load(function (r) { a++ , i === a && (e(t.param.resizeItem).trigger("imgsLoaded"), console.log("last image src: " + this.src + " iteration " + a)) }), 0 === i && e(t.param.resizeItem).trigger("imgsLoaded") }, t.prototype.equalize = function () { var t = this, i = 0, a = e(t.el).find(t.param.equalizeItem), r = e(t.el).hasClass("flex-content-left"); if (winWidth = e(t.param.resizeItem).width(), startWidthIsGood = "number" != typeof t.param.startWidth || winWidth < t.param.startWidth, e(t.el).find(t.param.equalizeItem).length) { if (winWidth > t.param.stopWidth && startWidthIsGood) if (e(t.el).addClass("in-resize"), "string" == typeof t.param.pattern || t.param.smartPattern) { var n, o = t.param.smartPattern && t.param.pattern ? t.param.pattern.split(";") || [Number(t.param.pattern)] : [], s = 0; if (t.param.smartPattern) { r ? "" : e(t.el).addClass("flex-content-left"); var l = Math.floor(a.eq(0).position().top), m = a.length - 1; inRow = 0, a.each(function (t) { if (0 !== t) { var i = Math.floor(e(this).position().top); i === l ? inRow += 1 : (o.push(inRow + 1), inRow = 0), t === m && o.push(inRow + 1), l = i } }), r ? "" : e(t.el).removeClass("flex-content-left") } for (var u = 0, p = 0, h = a.length; h > u && "" !== o[p] && (n = Number(o[p]) + s, a.slice(s, n).css("min-height", ""), e(t.el).trigger("beforeEqualize", [a.slice(s, n)]), a.slice(s, n).each(function () { e(this).outerHeight() > i ? i = e(this).outerHeight() : "" }).css("min-height", i + "px"), 0 !== a.slice(s + 1).length); u++)e(t.el).trigger("afterEqualize", [a.slice(s, n)]), s += Number(o[p]), p > u ? p = 0 : p++ , i = 0 } else a.css("min-height", "").each(function () { e(this).outerHeight() > i ? i = e(this).outerHeight() : "" }), e(t.el).trigger("beforeEqualize", [t.param.equalizeItem]), a.css("min-height", i + "px"), e(t.el).trigger("beforeEqualize", [t.param.equalizeItem]); else a.css("min-height", ""); return e(t.el).removeClass("in-resize"), t } }, jQuery.fn.equalizeContent = function () { for (var e, i, a = this, r = arguments[0], n = Array.prototype.slice.call(arguments, 1), o = 0, s = a.length; s > o; o++)if (i = "object" == typeof r || "undefined" == typeof r ? a[o].equalizeContent = new t(a[o], r) : e = a[o].equalizeContent[r].apply(a[o].equalizeContent, n), "undefined" != typeof e) return e; return a }, jQuery.fn.equalizeContent.Constructor = t, t.version = "1.5.0" }(jQuery);

/*Plugin: $(elem).easyTabs()*/
/*
	- Modified from its source to target the [data-tab-id=ID] attribute rather than the id attribute
	- Callback option added for additional functionality
	- maintainTallest option added so the page doesnt jump around if the tab content gets shorter
	- Option to load from location hash added, possible patterns listed below
*/

!function ($) {
    "use strict";
    var VERSION = "ACR 1.0.2";
    var EasyTabs = EasyTabs || {};
    EasyTabs = (function () {

        var instanceID = 0;
        function EasyTabs(element, option) {
            var _ = this;
            _.thisElem = element;
            _.param = $.extend({
                fadeSpeed: 260,
                defaultContent: 0,
                activeClass: 'active',
                maintainTallest: false,
                cssTransition: null,
                callback: null
            }, option);
            _.thisTabID = '.tabID_' + instanceID;
            _.init();
            instanceID++;
        }
        return EasyTabs;
    })();

    EasyTabs.prototype.findHashTab = function () {
        //special characters need to be escapced, hence the .replace() method
        var _ = this, rhash, tabSet, tabId,
            lhash = location.hash;// || location.search; <--maybe, it does work though!

        if (!/\&/.test(lhash)) {
            lhash = lhash.slice(1).replace(/([^A-Za-z0-9\=\-\.])/g, '');
            tabSet = /\=/.test(lhash) ? lhash.split('=')[0] : '';
            tabId = /\=/.test(lhash) && lhash.split('=')[1];

            rhash = _.retrieveHashTab(lhash, tabSet, tabId);

        } else {
            //for loop here
            for (var i = 0, lhs = lhash.split('&'), l = lhs.length; i < l; i++) {

                lhash = lhs[i].replace(/([^A-Za-z0-9\=\-\#\.])/g, '');
                tabSet = /\=/.test(lhash) ? lhash.split('=')[0] : '';
                tabId = /\=/.test(lhash) && lhash.split('=')[1];

                rhash = _.retrieveHashTab(lhash, tabSet, tabId);

                if (rhash !== '') break;
            }
        }
        return rhash;
    };

    EasyTabs.prototype.retrieveHashTab = function (lhash, tabSet, tabId) {
        var _ = this,
            tabExists = false,
            tabSet = tabSet.replace(/(\=|\#)/g, '');
        //%23 = # for id based
        //the . in the class is just the dot
        //example url: /meeting.html#.meeting-area=program
        //or /meeting.html#program
        //or #.meeting-area=program&day-3 <--multiple

        if (!!lhash && tabSet !== '' && $(_.thisTabID).hasClass(tabSet.slice(1))) {
            //console.log('is tab set: '+ tabSet)
            tabExists = $(decodeURIComponent(tabSet)).find("[data-tab-id=" + tabId.replace(/(\.|\=|\#)/g, '') + "]").length;

            if (tabExists) return tabId.replace(/(\.|\=|\#)/g, '');

        } else {
            //just specifying a tab.. and remove special characters so it doesn't error
            //console.log(lhash.replace(/(\.|\=|\#)/g,'') )
            tabExists = !!lhash && $("[data-tab-id=" + lhash.replace(/(\.|\=|\#)/g, '') + "]", _.thisTabID).length;

            if (!!lhash && tabExists) return lhash.replace(/(\.|\=|\#)/g, '');

        }
        return '';
    };


    EasyTabs.prototype.init = function () {
        var _ = this,
            defaultTab;
        //need to add the _.thisTabID class to the elem before running the findHasTab() fn
        $(_.thisElem).addClass(_.thisTabID.slice(1));
        var hashTab = _.findHashTab();

        $(_.thisElem).find(".tabs ul:first").addClass(_.thisTabID.slice(1) + "-list");

        if (hashTab !== '') {
            defaultTab = hashTab;
        }
        else if (typeof _.param.defaultContent == "number") {
            defaultTab = $(_.thisTabID + " .tabs li:eq(" + _.param.defaultContent + ") a").attr('href').substr(1);
        } else {
            defaultTab = _.param.defaultContent;
        }

        $(_.thisTabID + "-list a").each(function () {
            var tabToHide = $(this).attr('href').substr(1);
            $(_.thisTabID).find("[data-tab-id=" + tabToHide + "]")
                .addClass(_.thisTabID.slice(1) + '-content');
        });

        _.changeContent(defaultTab);

        $(_.thisTabID + "-list").on("click", "a", function (event) {

            var tabId = $(this).attr('href').substr(1);
            window.location.hash = tabId;

            if (typeof _.param.callback === 'function') {
                _.param.callback(_.thisTabID, tabId);
            }

            var $tabsBody = jQuery(_.thisTabID).find('.tabs-body'),
                tabsBodyHeight = $tabsBody.height(),
                currMinHeight = parseFloat($tabsBody.css('min-height'));

            if (_.param.maintainTallest) {

                if (tabsBodyHeight > currMinHeight) {
                    $tabsBody.css('min-height', tabsBodyHeight + 'px'); console.log('tabs min height')
                }
            }

            event.preventDefault();
            event.stopPropagation();
        });


        window.addEventListener("hashchange", function () {
            _.changeContent(window.location.hash.slice(1));
        });

        if (_.param.maintainTallest) {
            var $tabsBody = $(_.thisTabID).find('.tabs-body'),
                tabsBodyHeight = $tabsBody.height();
            if (tabsBodyHeight > parseFloat($tabsBody.css('min-height'))) {
                $tabsBody.css('min-height', tabsBodyHeight + 'px');
            }
            (function () {
                var resizeTimer;
                $(window).on('resize', function () {
                    clearTimeout(resizeTimer);
                    resizeTimer = setTimeout(function () {

                        $tabsBody
                            .css('min-height', '')
                            .css('min-height', $tabsBody.height() + 'px');

                    }, 250);
                });
            })();
        }
    };

    EasyTabs.prototype.hideAll = function (tabId) {
        var _ = this;
        $(_.thisTabID + '-content', _.thisTabID).each(function () {

            if (typeof tabId !== 'undefined' &&
                $(_.thisTabID).find(_.thisTabID + "-content[data-tab-id=" + tabId + "]").length !== 0) {

                $(this).hide();
            }

        });
    };

    EasyTabs.prototype.changeContent = function (tabId) {
        var _ = this;
        _.hideAll(tabId);
        if ($(_.thisTabID).find(_.thisTabID + "-content[data-tab-id=" + tabId + "]").length !== 0) {

            $(_.thisTabID + "-list li").removeClass(_.param.activeClass);
            $(_.thisTabID + "-list a[href=\"#" + tabId + "\"]").closest('li').addClass(_.param.activeClass);
            if (_.param.fadeSpeed !== "none") {
                $(_.thisTabID).find("[data-tab-id=" + tabId + "]").fadeIn(_.param.fadeSpeed);
            } else {
                $(_.thisTabID).find("[data-tab-id=" + tabId + "]").show();
            }

        }

    };

    $.fn.easyTabs = function () {
        var _ = this,
            opt = arguments[0],
            args = Array.prototype.slice.call(arguments, 1),
            ret;
        for (var i = 0, l = _.length; i < l; i++) {
            if (typeof opt === 'object' || typeof opt === 'undefined') {
                _[i].easyTabs = new EasyTabs(_[i], opt);
            } else {
                ret = _[i].easyTabs[opt].apply(_[i].easyTabs, args);
            }
            if (typeof ret !== 'undefined') { return ret; }
        }

        return _;
    };
    $.fn.easyTabs.version = VERSION;
}(jQuery);

/*Plugin: $(elem).acrDesktopNav()*/
!function ($) {
    'use strict';

    var VERSION = 'ACR 2.1.0';
    var ACRMainNav = ACRMainNav || {};

    ACRMainNav = (function () {
        ACRMainNav = function (element, option) {
            var _ = this;
            _.stayHover;
            _.level1StartDelay;
            _.$element = $(element);
            _.windowWidth = $(window).width();
            _.resizeDelay = null;
            _.initials = {
                mobileButton: '#mobile-nav-btn',
                mainNavHolder: '#main-nav-holder',
                mobileWidth: 1024,
                delay: 900,
                navHoveredBodyClass: 'desktop-nav-hovered',
                outerElement: 'body',
                outsideClickClose: true,
                afterHovered: function () { }
            };
            _.param = $.extend({}, _.initials, option);
            _.mobileMenuOpened = false;
            _.desktopMenuOpened = false;

            _.init();
        };
        return ACRMainNav;
    })();

    ACRMainNav.prototype.init = function () {
        "use strict";
        var _ = this;

        _.magicifyUlElems();
        _.highlightPath();
        _.desktopClicking();
        _.hoverDelay();
        _.level1InitialDelay();
        _.mobileNavClicking();
        _.navOnSticky();
        _.resizeUpdate();
        _.addAdditionalMobileLinks();
        if (_.param.outsideClickClose) {
            _.doOutsideClick();
        }
        return _;
    };

    ACRMainNav.prototype.magicifyUlElems = function () {
        var _ = this;
        $('li', _.$element).has('ul').each(function () {

            var $link = $("> a", this),
                $backLink = '<i class="acr-icon icon-arrow-skinny-left back-btn mobile-nav-only"></i>',
                $mobileNext = '<i class="acr-icon next-nav-level icon-chevron2-right mobile-nav-only"></i>',
                $anchor = '<a href="' + $link.attr('href') + '" class="nav-click-thru" >' + $link.text() + '</a>';
            $(this).append($mobileNext);

            !$(this).hasClass('has-children') && $(this).addClass('has-children');

            $(">ul", this).prepend('<li><h3>' + $backLink + $anchor + '</h3></li>');
        });

        $('> ul > li', _.param.mainNavHolder).has('ul').each(function () {
            $(this).find('>ul').addClass('main-nav-l2')
                .wrapAll('<div class="main-nav-mega"><div class="content"></div></div>')
        });

        return _;
    };

    ACRMainNav.prototype.desktopClicking = function () {
        "use strict";
        var _ = this;
        $('ul', _.$element).on('click', '.has-children > a', function (event) {
            var $thisLi = $(this).parent('li');

            $thisLi
                .toggleClass('active')
                .siblings('li').removeClass('active');

            if (!$thisLi.find('.on-page').length) {
                $thisLi
                    .find('li').removeClass('active');
            }

            _.desktopMegaMenuResize(this);
            if ($thisLi.hasClass('active')) {
                event.preventDefault();
            }
            event.stopPropagation();

            _.desktopMenuOpened = true;
        });
    };

    ACRMainNav.prototype.highlightPath = function () {
        "use strict";
        var _ = this,
            lpath = location.pathname.slice(1).split("/"),
            lpathDepth = 0,
            compiledHref = "/" + lpath[lpathDepth],
            $mainNav = $('ul:first', _.$element),
            $ulAnchors = $mainNav.find('li>a');

        lpath.forEach(function (item, index) {

            for (var i = 0, l = $ulAnchors.length; i < l; i += 1) {
                var cssClasses = (index === 0 || index === lpath.length - 1) ? 'on-page' : 'on-page active';

                if ($ulAnchors.eq(i).attr('href') === compiledHref) {
                    lpathDepth += 1;
                    compiledHref += "/" + lpath[lpathDepth];

                    $ulAnchors.eq(i).parent('li').addClass(cssClasses);
                    //lets change this to the next set of immediate List Items and immdediate Anchors
                    $ulAnchors = $ulAnchors.eq(i).parent('li').find('ul').eq(0).find('>li>a');

                    break;
                }
            }
        });
        //resize to fit if its larger
        _.desktopMegaMenuResize($('.on-page', _.$mainNav).last());
    };

    ACRMainNav.prototype.desktopMegaMenuResize = function (elem) {
        "use strict";
        var _ = this;

        var $thisMegaMenu = $(elem).closest('.main-nav-mega');
        var $lvl2Ul = $(elem).closest('.main-nav-l2'),

            lvl2UlHeight = $lvl2Ul.outerHeight() || 0,
            thisMMHeight = $thisMegaMenu.height(),
            openedUlHeight = (function () {
                var tallest = 0;
                $lvl2Ul.find('.active > ul').each(function () {
                    var outerHeight = $(this).outerHeight();
                    if (outerHeight > tallest) {
                        tallest = outerHeight;
                    }
                });
                return tallest;
            })();

        if (openedUlHeight > lvl2UlHeight && lvl2UlHeight !== 0) {
            $thisMegaMenu
                .animate({ minHeight: openedUlHeight }, 250);
        } else {
            $thisMegaMenu
                .animate({ minHeight: openedUlHeight }, 500);
        }

    };

    ACRMainNav.prototype.hoverDelay = function () {
        var _ = this;
        $('ul', _.$element).on('mouseenter mouseleave doNavHovers', 'li', function (event) {
            if ($(window).width() > _.param.mobileWidth) {

                $('body').addClass(_.param.navHoveredBodyClass);

                clearTimeout(_.stayHover);

                if (event.type === 'mouseleave') {

                    _.stayHover = setTimeout(function () {
                        _.$element.find('li').removeClass('hover ');
                        $('body').removeClass(_.param.navHoveredBodyClass);
                        _.param.afterHovered();


                    }, _.param.delay);

                }
            }
        });
        return _;
    };

    ACRMainNav.prototype.resizeUpdate = function () {
        "use strict";
        var _ = this;
        $(window).on('resize', function (event) {
            clearTimeout(_.resizeDelay);
            _.resizeDelay = setTimeout(function () {
                var winWidth = $(window).width(),
                    didntActuallyResize = (_.windowWidth === winWidth);
                _.windowWidth = winWidth;

                if (didntActuallyResize) {
                    if (event.type === 'resize') return;
                }

                if (_.windowWidth <= _.param.mobileWidth) {
                    _.closeDesktopView();
                } else {
                    //resize to fit if its larger
                    _.desktopMegaMenuResize($('.on-page', _.$mainNav).last());
                }

            }, 100);
        });
    };

    ACRMainNav.prototype.closeDesktopView = function () {
        "use strict";
        var _ = this;
        _.$element.find('.main-nav-mega').css({ minHeight: '' });
        _.$element.find('.active').removeClass('active');

        _.desktopMenuOpened = false;
    };

    ACRMainNav.prototype.level1InitialDelay = function () {
        var _ = this;
        _.$element.on('mouseenter mouseleave', function (event) {

            var $this = $(this);

            clearTimeout(_.level1StartDelay);

            if (event.type === "mouseenter") {

                _.level1StartDelay = setTimeout(function () {
                    $this.addClass('do-nav-hovers');
                    $('ul', _.$element).find('li:hover').trigger('doNavHovers');
                }, _.param.lvl1Delay);

            } else {
                _.stayHover = setTimeout(function () {
                    $this.removeClass('do-nav-hovers');
                    $('body').removeClass(_.param.navHoveredBodyClass);
                    _.param.afterHovered();
                }, _.param.delay);
            }
        });
        return _;
    };

    ACRMainNav.prototype.navOnSticky = function () {
        var _ = this;
        var navOnStickyTimer,
            scrollTopTimer,
            scrollTop = 0,
            mouseoverTimes = 0;

        //yes this needs ot be mouseover not mouseenter event
        //it won't work if its not!
        _.$element.on('mouseover', function () {
            clearTimeout(navOnStickyTimer);
            if (headerIsSticky && _.desktopMenuOpened) {

                if (mouseoverTimes < 2) {
                    mouseoverTimes++;
                    scrollTop = $(window).scrollTop();
                    $('#site-header').css({ position: 'absolute', top: scrollTop });
                }
            }

        });

        _.$element.on('mouseleave', function () {
            clearTimeout(navOnStickyTimer);
            navOnStickyTimer = setTimeout(function () {
                $('#site-header').css({ position: '', top: '' });
                mouseoverTimes = 0;
            }, _.param.delay);

        });

        $(window).on('scroll', function () {
            if ($('body').hasClass('desktop-nav-hovered')) {
                var scrolledTop = $(window).scrollTop();
                if (scrolledTop < scrollTop) {
                    scrollTop = scrolledTop;
                    $('#site-header').css({ top: scrollTop });
                }
            }
        });
    };

    ACRMainNav.prototype.mobileMenuToggle = function () {
        var _ = this;

        if (_.mobileMenuOpened) {
            _.$element.parent()
                .find('.menu-opened')
                .removeClass('menu-opened')
                .find("[style]").css('display', '');

            $(_.param.outerElement).removeClass('menu-opened');

            $('li', _.$element)
                .removeClass('hide-nav-elem active-parent show-nav-elem');

            _.mobileMenuOpened = false;
        } else {
            $(_.param.element).addClass('menu-opened');
            $(_.param.outerElement).addClass('menu-opened');

            _.mobileMenuOpened = true;
        }
    };

    ACRMainNav.prototype.addAdditionalMobileLinks = function () {
        "use strict";
        var _ = this;

        //copy from the utility nav.. to then copy to the mobile
        $('#m-utility-bottom').append($('.top-utility-nav').html());
        $('#m-utility-top').append($('.action-utility-nav').html());

        $('> ul', _.param.mainNavHolder)
            .append('<li id="m-utility-nav-holder" class="mobile-nav-only" >' + $('#additional-mobile-nav').html() + '</li>');

        $('#additional-mobile-nav').remove();
    };

    ACRMainNav.prototype.mobileNavClicking = function () {
        "use strict";
        var _ = this;
        $(_.param.mobileButton).click(function (event) {
            _.mobileMenuToggle();
            event.stopPropagation();
        });

        _.$element.on('click', '.has-children .next-nav-level', function (event) {
            //exit if were not in mobile
            if ($(window).width() > _.param.mobileWidth) return;

            var $thisLi = $(this).closest('.has-children');

            $thisLi.addClass('show-nav-elem active-parent')
                .siblings('li').addClass('hide-nav-elem');

            //give it some transitioning tlc
            $thisLi.find(">ul").css({ 'opacity': '0' })
                .animate({ 'opacity': '1' }, 600);

            event.stopPropagation();
        })
            .on('click', '.has-children .back-btn', function (event) {

                var $activeParent = $(this).closest('.active-parent');

                $activeParent.removeClass('active-parent show-nav-elem')
                    .siblings().removeClass('hide-nav-elem')
                    .removeClass('show-nav-elem');

                event.stopPropagation();
            });

    };

    ACRMainNav.prototype.doOutsideClick = function () {
        "use strict";
        var _ = this;

        iosOutsideClickSupport.add();

        $('body')[0].addEventListener('click', function (event) {

            if (_.mobileMenuOpened) {

                var menuClicked = (_.$element.find(event.target).length > 0);
                //if the menu item is not clicked and its opened
                //the menu button shouldn't register because propogation is prevented to the body
                if (!menuClicked) {
                    _.mobileMenuToggle();
                }
            }
            _.closeDesktopView();
        });

    };

    $.fn.acrDesktopNav = function () {
        var _ = this,
            opt = arguments[0];

        for (var i = 0, l = _.length; i < l; i++) {
            _[i].acrDesktopNav = new ACRMainNav(_[i], opt);
        }
        return _;
    };
    $.fn.acrDesktopNav.version = VERSION;
}(jQuery);


!function ($) {
    "use strict";
    var VERSION = 'ACR 1.0.0';
    var Sticky = Sticky || {};
	/*create global var headerIsSticky, scrollToTarget() uses this so the scrolled to link isn't cut off/underneath the header,
	or if the scrollToTarget's top is going to make the header sticky'*/
    window.headerIsSticky = false;
    window.headerStickyOffset = 0;
    window.stickyAnimateDuration = 300;

    Sticky = (function () {

        function Sticky(element, option) {
            var _ = this;
            _.param = $.extend({
                stickyElem: element,
                stickyClassName: 'sticky',
                duration: stickyAnimateDuration,
                offsetTop: 200,
                startPosition: "-100px",
                endPosition: "0px",
                dontStickyCondition: function () { return false },
                stopWidth: null
            }, option);
            headerStickyOffset = _.param.offsetTop;
            _.isScrolled = false;
            _.windowWidth = $(window).width();
            _.init();
        }
        return Sticky;
    })();

    Sticky.prototype.stickyAnimate = function () {

        var _ = this,
            stickyClass = _.param.stickyClassName.replace(/\./g, ''),
            stopWidthReached = _.param.stopWidth === null ? false : (_.param.stopWidth > _.windowWidth),
            isItSticky = !$(_.param.stickyElem).hasClass(stickyClass),
            offsetTop = (displayHeaderAd) ? (_.param.offsetTop + $('#site-header-ad').height()) : _.param.offsetTop;

        var scrollTop = $(window).scrollTop();

        if (scrollTop > _.param.offsetTop && isItSticky && !stopWidthReached && !_.param.dontStickyCondition()) {
            $(_.param.stickyElem).addClass(stickyClass);
            headerIsSticky = true;
            if (_.isScrolled) {
                $(_.param.stickyElem).css('top', _.param.startPosition)
                    .animate({ top: _.param.endPosition }, _.param.duration);
            }
        }
        if (scrollTop < _.param.offsetTop || stopWidthReached) {
            $(_.param.stickyElem).removeClass(stickyClass);

            headerIsSticky = false;
        }

    };

    Sticky.prototype.stickyResize = function () {
        var _ = this;

        $(window).on("scroll resize StickyAnimate", function () {

            _.isScrolled = true;
            _.windowWidth = $(window).width();
            _.stickyAnimate();

        });
    };

    Sticky.prototype.init = function () {
        var _ = this;
        _.stickyResize();
        _.stickyAnimate();
    };

    $.fn.sticky = function () {
        var _ = this;

        for (var i = 0, l = _.length; i < l; i++) {
            _[i].sticky = new Sticky(_[i], arguments[0]);
        }
        return _;
    };
    $.fn.sticky.version = VERSION;
}(jQuery);


function setMainSpacingTop() {

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

function iframeHeightResize(not, offset) {
    "use strict";
    jQuery('iframe').each(function () {
        var h = jQuery(this).attr('height'),
            w = jQuery(this).attr('width'),
            ratio = h / w,
            computedWidth = jQuery(this).width(),
            newHeight = (Math.floor(computedWidth * ratio) + offset) + 'px';

        jQuery(this).not(not).css('height', newHeight);
    });
}

!function ($) {
    "use strict";
    $.extend({
        iframeResize: function (option) {
            var param = jQuery.extend({ offset: 0, not: '' }, option);
            (function () {
                var resizeTimer;
                $(window).on('resize', function (e) {
                    clearTimeout(resizeTimer);
                    resizeTimer = setTimeout(function () {
                        iframeHeightResize(param.not, param.offset);
                    }, 250);
                });
            })();
            iframeHeightResize(param.not, param.offset);
        }
    });
}(jQuery);

function accordions() {
    "use strict";
    jQuery('.accordion').on('click', '.accordion-header', function () {
        var openState = !!jQuery(this).hasClass('open'),
            toggleOthers = !jQuery(this).closest('.accordion').hasClass('dont-toggle');

        //Expand or collapse this panel
        jQuery(this).next().slideToggle(500);
        //Hide the other panels
        if (toggleOthers) {
            jQuery(this).closest('.accordion').find(".accordion-details")
                .not(jQuery(this).parent().find(".accordion-details"))
                .slideUp(500);

            jQuery(this).closest('.accordion').find(".accordion-header").removeClass('open');
        }
        (openState) ? jQuery(this).removeClass('open') : jQuery(this).addClass('open');
    });
    $('.accordion')
        .find('.accordion-details').css({ display: 'none' })
        .closest('.accordion').addClass('accordion-enabled');
}

function resourceSlider(elem) {
    /*Dependencies js/slick.1.6.0.custom.min.js*/
    if (typeof jQuery.fn.slick === 'undefined') {
        console.log('your gonna need to add in the slick.js for this to work!');
        return;
    }

    var $customPager = $(elem).next('.resources-slider-nav'),
        $inputPageLoc = $customPager.find('.slick-custom-pager'),
        slideTotal = $(elem).find('.slick-slide').length;

    if (slideTotal > 1) {
        $inputPageLoc.prepend('<input type="text" class="slide-num-input" data-prev-val="1" value="1"> of ' + slideTotal);
    }

    var $slideInputNum = $customPager.find('.slide-num-input');

    jQuery(elem).slick({
        dots: true,
        infinite: true,
        autoplaySpeed: 6500,
        speed: 700,
        appendArrows: $customPager,
        appendDots: $inputPageLoc
    }).on('beforeChange', function (event, slick, currentSlide, nextSlide) {
        $slideInputNum.data("prev-val", $slideInputNum.val())
            .val(nextSlide + 1);

    });
    squareItUp(elem, { squareItem: '.event-tile', useOuterWidth: true, stopWidth: 960, timerDelay: 120 });
    $customPager.on('change', '.slide-num-input', function () {
        var val = this.value,
            valAsInt = Number(val);

        if (!(/\D/g).test(val)) {
            if ((valAsInt > slideTotal || valAsInt < 1)) {
                this.value = jQuery(this).data("prev-val");
            } else {
                $inputPageLoc.find('button').eq(valAsInt - 1).trigger('click');
                jQuery(this).data("prev-val", val);
            }
        } else {
            this.value = jQuery(this).data("prev-val");
        }
    });
}

function squareItUp(elem, _p) {
    return (function (elem, _p) {
        var param = {
            stopWidth: _p.stopWidth || 960,
            squareItem: _p.squareItem || '.square-it-item',
            resizeDelay: _p.resizeDelay || 100,
            useOuterWidth: _p.useOuterWidth || false
        }
        var resizeTimer;
        $(window).on('resize load', function () {
            clearTimeout(resizeTimer);
            resizeTimer = setTimeout(function () {
                //console.log(elem+ " | " +param.stopWidth + " | " + param.squareItem);

                if ($(window).width() > param.stopWidth) {
                    $(elem).each(function () {
                        var width = (_p.useOuterWidth) ? $(this).find(param.squareItem).eq(0).outerWidth()
                            : $(this).find(param.squareItem).eq(0).width();

                        $(this).find(param.squareItem).each(function () {
                            $(this).css('min-height', width + 'px');
                        });
                    });
                } else {
                    $(elem).find(param.squareItem).css('min-height', '');
                }
            }, param.resizeDelay, elem, param);
        });
    })(elem, _p);
}

function tabRotatingTiles(sliderElem) {
    //console.log(sliderElem)
    jQuery(sliderElem).easyTabs({
        defaultContent: 0,
        callback: function (thisTabID, tabId) {

            jQuery(thisTabID)
                .find("[data-tab-id=" + tabId + "]")
                .find(".slick-initialized")
                .slick("unslick");

            //when custom appending arrows and dots to an element
            //the 'unslick' doesn't erase those elements
            jQuery(thisTabID).find('.acr-news-slider-nav')
                .html('<div class="acr-news-slider-dots"/>');

            tabRotatingTilesUtility(tabId, thisTabID);
        }
    }).each(function () {
        var firstTabId = jQuery(this).find('.tabs .active').find('a').attr('href').slice(1);
        tabRotatingTilesUtility(firstTabId, this);
    });

}

function tabRotatingTilesUtility(tabId, sliderElem) {
    var $thisSliderTab = jQuery(sliderElem).find("[data-tab-id=" + tabId + "]");
    //console.log(sliderElem + " " + tabId)

    if (typeof jQuery.fn.slick === 'undefined') {
        console.log('your gonna need to add in the slick.js for this to work!');
        return;
    }

    $thisSliderTab.find(".news-slider").slick({
        infinite: true,
        speed: 600,
        autoplay: false,
        autoplaySpeed: 7500,
        arrows: true,
        dots: true,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [{
            breakpoint: 1025,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2
            }
        }, {
            breakpoint: 768,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                appendArrows: jQuery(sliderElem).find('.acr-news-slider-nav'),
                appendDots: jQuery(sliderElem).find('.acr-news-slider-dots')
            }
        }]
    })
        .css({ 'opacity': '0' })
        .delay(251)
        .animate({ opacity: 1 }, 250)
        .find('img').each(function () {
            //lazy load some imagery
            //but only if it hasn't been already!
            if (!this.hasAttribute('data-lazy-loaded')) {
                jQuery(this).attr("src", jQuery(this).data('lazy-src'))
                    .attr('data-lazy-loaded', '');
            }
        }).last().load(function () {
            jQuery(window).trigger('resize');
            // setTimeout(function(){
            // 	var theMinHeight = parseFloat(jQuery(sliderElem).css('min-height'));
            // 	var theHeight = jQuery(sliderElem).height() > theMinHeight ? jQuery(sliderElem).height() : theMinHeight;
            //
            // 	jQuery(sliderElem).css('min-height',theHeight);
            // },20);

        });
}

function headerAdButlerServe() {
    if (displayHeaderAd) {
        if (!window.AdButler) {
            (function () {
                var s = document.createElement("script");
                s.async = true; s.type = "text/javascript";
                s.src = 'https://servedbyadbutler.com/app.js';
                var n = document.getElementsByTagName("script")[0];
                n.parentNode.insertBefore(s, n);
            }());
        }

        window.AdButler = window.AdButler || {};
        AdButler.ads = AdButler.ads || [];
        var abkw = window.abkw || '';
        var plc187820 = window.plc187820 || 0;
        $('#header-ad-write').html('<div id="placement_187820_' + plc187820 + '"><\/div>');
        AdButler.ads.push({
            handler: function (opt) {
                AdButler.register(165731, 187820, [728, 90], 'placement_187820_' + opt.place, opt);
            },
            opt: { place: plc187820++, keywords: abkw, domain: 'servedbyadbutler.com', click: 'CLICK_MACRO_PLACEHOLDER' }
        });
    }
}

/*Plugin: $(elem).scrollInView(); found in ./plugin folder*/
!function (e) { "use strict"; var t = !1, r = r || {}; r = function () { function r(r, n) { var i = this; i.thisInstance = ".scrollID_" + s, e(r).addClass(i.thisInstance.slice(1)), s++ , i.parentElem = r, i.hasTouchSwipe = t, i.scrollingEnabled = !1, i.scrolledIndex = 0, i.defaults = { startWidth: 1024, childItem: ".in-view-item", slideWrapper: n.$slideContainer || null, btnSpace: 64, not: "tabs-evenly-spaced", scrollItemAmount: 1, breakPointsOnWindow: !0, resizeDelay: 100, leftBtnClass: "acr-icon icon-arrow-left", rightBtnClass: "acr-icon icon-arrow-right", minWidth: null, columns: [{ breakpoint: 359, cols: 1 }, { breakpoint: 768, cols: 2 }, { breakpoint: 1024, cols: 3 }, { breakpoint: 2800, cols: 4 }], buttonsAddedClass: "in-view-btns-added" }, i.param = e.extend({}, i.defaults, n), i.parent = e(i.thisInstance), i.slideWrapper = i.parent.find(i.param.slideWrapper), i.slideContainerCssMinWidth = parseFloat(i.slideWrapper.css("min-width")), i.slideContainerUseWidth = "number" == typeof i.param.minWidth ? i.param.minWidth : i.slideContainerCssMinWidth, i.scrolledItems = i.parent.find(i.param.childItem + ":first").parent().find(i.param.childItem).length, i.slideContainerWidth = i.slideWrapper.width() + i.param.btnSpace, i.btnsAdded = !1, i.doFixedScroll = "td" === i.param.childItem, i.tFixedScrollOffset = 1, i.wrapperWidth = 0, i.currElemLeft = 0, i.lastElem = i.slideWrapper.find(i.param.childItem).last(), i.lastElemWidth = i.lastElem.outerWidth(), i.lastElemPos = i.lastElem.position().left, i.fixedItemsToScreen = 0, i.parent.hasClass(i.param.not || "tabs-evenly-spaced") || i.parent.hasClass("table-no-scroll") || (i.parent.addClass("hide-left-btn"), i.slideWrapper.wrap('<div class="in-view-wrapper" />'), i.slideWrapper.css({ position: "relative" }), i.init()) } var s = 0; return r }(), r.prototype.init = function () { var e = this; e.resizedScreen(), e.swipePlugin(), e.scrollIt() }, r.prototype.getFixedItemsToScreen = function () { var t = this; t.wrapperWidth = t.parent.find(".in-view-wrapper").width(); var r = t.param.breakPointsOnWindow ? e(window).width() : t.wrapperWidth; if ("number" == typeof t.param.columns) t.fixedItemsToScreen = t.param.columns; else if ("object" == typeof t.param.columns) for (var s = 0, n = t.param.columns.length, i = t.param.columns; n > s; s++)if (r <= i[s].breakpoint) { t.fixedItemsToScreen = i[s].cols; break } if (t.doFixedScroll) { var a = t.wrapperWidth / t.fixedItemsToScreen - t.tFixedScrollOffset; t.slideWrapper.css({ "min-width": "1px", width: a * t.scrolledItems + t.scrolledItems + "px", "table-layout": "fixed" }) } }, r.prototype.changePos = function (t) { var r = this; if (r.scrollingEnabled) { var s = r.doFixedScroll ? r.fixedItemsToScreen : r.param.scrollItemAmount, n = r.lastElemPos + r.lastElemWidth - r.currElemLeft < r.wrapperWidth - r.param.btnSpace; if ("LEFT" === t.toUpperCase() || "SWIPERIGHT" === t.toUpperCase() ? 0 === r.scrolledIndex ? r.scrolledIndex : r.scrolledIndex <= r.scrolledIndex - r.param.scrollItemAmount ? r.scrolledIndex = 0 : r.scrolledIndex -= r.param.scrollItemAmount : ("RIGHT" === t.toUpperCase() || "SWIPELEFT" === t.toUpperCase()) && (!n || r.doFixedScroll) && (r.scrolledIndex >= r.scrolledItems - s ? r.scrolledIndex : r.scrolledIndex += r.param.scrollItemAmount), r.currElemLeft = r.parent.find(r.param.childItem).eq(r.scrolledIndex).position().left, n = r.lastElemPos + r.lastElemWidth - r.currElemLeft < r.wrapperWidth - r.param.btnSpace, r.doFixedScroll && 0 !== r.currElemLeft && (r.currElemLeft += r.tFixedScrollOffset), r.slideWrapper.css("transform", "translate3d(" + -1 * r.currElemLeft + "px, 0px, 0px)"), r.parent.removeClass("hide-right-btn hide-left-btn"), 0 === r.scrolledIndex && r.parent.addClass("hide-left-btn"), r.doFixedScroll ? r.scrolledIndex === r.scrolledItems - s && r.parent.addClass("hide-right-btn") : n && r.parent.addClass("hide-right-btn"), r.doFixedScroll) { if (!r.scrollingEnabled) return; r.parent.find("table,.scroll-box").not("table table").find("tr, > div").each(function () { e(this).find("th,td").removeClass("contents-in-view").addClass("hide-contents").slice(r.scrolledIndex, r.scrolledIndex + r.fixedItemsToScreen).removeClass("hide-contents").addClass("contents-in-view") }) } else r.parent.find(r.param.childItem).each(function () { var t = e(this).position().left + e(this).width() - r.currElemLeft; t > r.wrapperWidth ? e(this).addClass("ellipsis") : e(this).removeClass("ellipsis") }) } }, r.prototype.scrollIt = function () { var t = this; t.parent.on("click", ".view-btn-left", function () { t.changePos("LEFT") }).on("click", ".view-btn-right", function () { t.changePos("RIGHT") }).on("mouseleave touchend", function () { e(this).trigger("mouseup"), t.slideWrapper.css("transform", "translate3d(" + -1 * t.currElemLeft + "px, 0px, 0px)") }) }, r.prototype.swipePlugin = function () { var e = this; e.hasTouchSwipe && e.doFixedScroll && e.parent.swipe({ swipe: function (t, r) { e.changePos("SWIPE" + r) }, swipeStatus: function (t, r, s, n, i) { var a = e.currElemLeft, l = 130 > n ? n : 130; "move" === r && e.scrollingEnabled && ("LEFT" === s.toUpperCase() ? e.slideWrapper.css("transform", "translate3d(" + -1 * (a + l) + "px, 0px, 0px)") : "RIGHT" === s.toUpperCase() && e.slideWrapper.css("transform", "translate3d(" + -1 * (a - l) + "px, 0px, 0px)")), "end" !== r && "touchcancel" !== t.type && "mouseup" !== t.type || !e.scrollingEnabled || e.slideWrapper.css("transform", "translate3d(" + -1 * e.currElemLeft + "px, 0px, 0px)") }, allowPageScroll: "vertical" }) }, r.prototype.resizedScreen = function () { var t = this; return function () { var r; e(window).on("resize load scrollInView", function () { clearTimeout(r), t.slideContainerWidth = t.slideWrapper.width() + t.param.btnSpace, r = setTimeout(function () { t.wrapperWidth = t.parent.find(".in-view-wrapper").width(); var r = t.slideContainerUseWidth > t.slideContainerWidth ? t.slideContainerUseWidth : t.slideContainerWidth; r >= t.wrapperWidth && t.param.startWidth >= e(window).width() ? (t.scrollingEnabled = !0, t.getFixedItemsToScreen(), t.btnsAdded || (t.btnsAdded = !0, t.parent.addClass(t.param.buttonsAddedClass).append('<i class="in-view-btn view-btn-left ' + t.param.leftBtnClass + '"/><i class="in-view-btn view-btn-right ' + t.param.rightBtnClass + '"/>')), t.parent.addClass("hide-left-btn"), t.changePos("")) : (t.scrollingEnabled = !1, t.scrolledIndex = 0, t.currElemLeft = 0, t.btnsAdded && (t.btnsAdded = !1, t.parent.removeClass(t.param.buttonsAddedClass + " hide-right-btn hide-left-btn").find(".in-view-btn").remove()), t.slideWrapper.css({ transform: "translate3d(0px, 0px, 0px)", width: "" }), t.doFixedScroll ? (t.slideWrapper.css({ width: "", "table-layout": "" }), t.parent.find(t.param.childItem).css("width", ""), t.slideWrapper.find("th,td").removeClass("hide-contents")) : t.parent.find(t.param.childItem).removeClass("ellipsis")) }, t.param.resizeDelay, t.parentElem, t.param) }) }(t.parentElem, t.param) }, e.fn.scrollInView = function () { "undefined" == typeof e.fn.swipe ? console.log("please add jquery.touchSwipe.js touch swiping will not work :-/") : t = !0; for (var s, n = this, i = arguments[0], a = Array.prototype.slice.call(arguments, 1), l = 0, d = n.length; d > l; l++)if ("object" == typeof i || "undefined" == typeof i ? n[l].scrollInView = new r(n[l], i) : s = n[l].scrollInView[i].apply(n[l].scrollInView, a), "undefined" != typeof s) return s; return n } }(jQuery);

function scrollInView(parentElem, param) {
    $(parentElem).scrollInView(param);
}

function tooltips(parent) {
    $('.tool-tip').find('> .tip-text')
        .wrapInner('<div class="tip-text-inner" />');

    $((parent || 'main')).on('click', this, function () {
        $('.tool-tip.tip-enabled')
            .removeClass('tip-enabled')
            .find('.tip-on-edge')
            .removeClass('tip-on-edge');
    })
        .on('click', '.tool-tip', function (e) {

            $(this).toggleClass('tip-enabled');

            var $elm = $('.tip-text', this),
                off = $elm.offset(),
                l = off.left,
                w = $elm.width(),
                docW = $(window).width();

            var isEntirelyVisible = (l + w <= docW);

            if (!isEntirelyVisible) {
                $elm.addClass('tip-on-edge');
            } else {
                $elm.removeClass('tip-on-edge');
            }

            e.preventDefault();
            e.stopPropagation();
        });
}

function radiosCheckboxes(parent, preFn) {

    //use the preFn in case we need to do some
    //kind of routine to wrap the checkboxes and labels
    //into the wrapper if we cannot hard-code it

    if (typeof preFn !== 'undefined' && typeof preFn === 'function') {
        preFn();
    }

    var $parent = $((parent || 'main'));

    $('.acr-checkbox,.acr-radio').each(function () {

        $(this).prepend('<i></i>');
        var $input = $('input', this);

        $input.is(':checked') && $(this).addClass('input-checked');
        $input.is(':disabled') && $(this).addClass('disabled-input');
    });

    $parent.on('click radiosCheckboxes', '.acr-checkbox,.acr-radio', function () {

        if ($(this).hasClass('disabled-input')) { return }

        var $input = $('input', this),
            isRadio = $input[0].type.toUpperCase() === "RADIO";

        if ($input.is(':checked')) {
            if (!isRadio) {
                $input.prop('checked', false);
                $(this).removeClass('input-checked');
            }
        } else {
            $input.prop('checked', true);
            $(this).addClass('input-checked');
        }
        //create the change event in case it
        //didn't register
        $input.trigger('change');

        $('input[id=' + $input.attr('id') + ']')
            .not(':checked')
            .parent('.acr-radio')
            .removeClass('input-checked');

    });
}


function multiFieldDatePicker(dateYear, dateParent, changeTheYear) {
	/*
		dependencies: jquery.ui
	*/
    if (typeof jQuery.fn.datepicker !== 'function') {
        console.log('install some jquery ui! Thanks :-)');
    }

    //we got a picker!
    jQuery((dateYear || ".date-hidden")).datepicker({
        showOn: 'button',
        buttonText: "",
        dateFormat: 'mm/dd/yy',
        changeYear: (changeTheYear !== 'undefined' ? changeTheYear : false),
        onSelect: function (dateText, picker) {
            var dateArr = dateText.split('/');
            jQuery(this).siblings('.date-month').val(dateArr[0]);
            jQuery(this).siblings('.date-day').val(dateArr[1]);
            jQuery(this).siblings('.date-year').val(dateArr[2]);

            //plop in the hidden field!
            jQuery(this).val(dateText);
        }
    });

    //read from the date field and populate
    jQuery((dateParent || '.date-multi-field')).each(function () {
        var $dateHidden = $(this).find('.date-hidden');

        if (/\//.test($dateHidden.val())) {
            var dateArr = $dateHidden.val().split('/');

            jQuery(this).find('.date-month').val(dateArr[0]);
            jQuery(this).find('.date-day').val(dateArr[1]);
            jQuery(this).find('.date-year').val(dateArr[2]);
        }
    });

    //change triggered on one of the fields to update the hidden
    jQuery((dateParent || '.date-multi-field')).on('change', 'input', function () {
        var $dateHidden = $(this).siblings('.date-hidden'),
            $parent = $(this).parent((dateParent || '.date-multi-field')),
            mm = $parent.find('.date-month').val(),
            dd = $parent.find('.date-day').val(),
            yyyy = $parent.find('.date-year').val();

        $dateHidden.val(mm + "\/" + dd + "\/" + yyyy);

    });
}


// primary function to retrieve cookie by name
function getCookie(name) {
    var arg = name + "=";
    var alen = arg.length;
    var clen = document.cookie.length;
    var i = 0;
    while (i < clen) {
        var j = i + alen;
        if (document.cookie.substring(i, j) == arg) {
            return getCookieVal(j);
        }
        i = document.cookie.indexOf(" ", i) + 1;
        if (i == 0) break;
    }
    return "";
}
// utility function called by getCookie()
function getCookieVal(offset) {
    var endstr = document.cookie.indexOf(";", offset);
    if (endstr == -1) {
        endstr = document.cookie.length;
    }
    return decodeURI(document.cookie.substring(offset, endstr));
}
// store cookie value with optional details as needed
function setCookie(name, value, exdays, path, domain, secure) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = d.toUTCString();

    document.cookie = name + "=" + encodeURI(value) +
        ((expires) ? "; expires=" + expires : "") +
        ((path) ? "; path=" + path : "") +
        ((domain) ? "; domain=" + domain : "") +
        ((secure) ? "; secure" : "");
}

// remove the cookie by setting ancient expiration date
function deleteCookie(name, path, domain) {
    if (getCookie(name)) {
        document.cookie = name + "=" +
            ((path) ? "; path=" + path : "") +
            ((domain) ? "; domain=" + domain : "") +
            "; expires=Thu, 01-Jan-70 00:00:01 GMT";
    }
}

function scrollToTarget() {
    //if were doing a click
    $("body").on("click", "a[href^='#']", function (event) {
        'use strict';
        var targ = this.hash;
        var target = $(targ);

        location.hash = targ;

        event.preventDefault();
        if (target.length > 0) {

            //scrollTargetOffset(target);

        } else if (targ === '#to-top' && event.type === "click") {
            $('body,html').animate({
                scrollTop: 0
            }, $('html,body').scrollTop() * .35);
        }
    });
    //If we're using the to the top button
    if ($('#to-top-btn').length) {
        $(window).on('scroll topBtnCheck', function () {
            var limiter,
                $topBtn = $('#to-top-btn');

            clearTimeout(limiter);

            limiter = setTimeout(function () {
                ($(window).scrollTop() > 800) ?
                    $topBtn.addClass('top-btn-show') : $topBtn.removeClass('top-btn-show');
            }, 100);
        });
        $(window).trigger('topBtnCheck');
    }

}

function jumpToTargetOffset() {
    var lhash = location.hash;
    setTimeout(function () {
        //if we need to jump to a section on the page
        if (lhash.indexOf("f:") < 0 && lhash.indexOf('q=') < 0) {
            //if the location hash has a valid format
            //so that it doesn't break jQuery...
            if (!(/[\.\=\&\;]/g).test(lhash)) {
                var $target = $(lhash);
                if (!$target.length) { return; }//exit the target doesn't exist

                var targetTop = $target.offset().top,
                    inDesktop = $(window).width() > 1024,
                    siteHeaderHeight = 0;

                if (inDesktop) {
                    var hdrHeight = $('#site-header').height();
                    siteHeaderHeight = headerIsSticky ? hdrHeight : hdrHeight - $('.stick-hide').height();
                }

                targetTop = (targetTop > headerStickyOffset) ? targetTop - siteHeaderHeight : targetTop;
                $('body,html').scrollTop(targetTop);

            }
        }
    }, stickyAnimateDuration + 100);
}

$('#dnn_HeaderLinks').on('keypress', '#header_tbSearch', function (e) {
    if (e.which === 13) {
        $('#header_hlSearchLink').click();
        return false;
    }
});


//JT FUNCTIONS
//$('#header_tbSearch').on('keypress', function (e) {
//    if (e.which === 13) {
//        ACRSearchPageNavigate(this);
//    }
//});

$('#dnn_HeaderLinks').on('click', '#header_hlSearchLink', function () {
    ACRSearchPageNavigate(this);
});

//$('#header_hlSearchLink').click(function () {
//    ACRSearchPageNavigate(this);
//});

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
    searchInput.removeAttr("disabled", "");
    if (window.location.host == 'stgshop75.acr.org') {
        window.location.href = 'http://staging.acr.org/Search-Results#q=' + searchInput.val();
    }
    if (window.location.host == 'shopqa.acr.org') {
        window.location.href = 'http://preprod.acr.org/Search-Results#q=' + searchInput.val();
    }
    if (window.location.host == 'shop.acr.org') {
        window.location.href = 'https://www.acr.org/Search-Results#q=' + searchInput.val();
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

jQuery(function ($) {
    setMainSpacingTop();
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
    scrollToTarget();
    checkTabsEvenlySpaced();
    $.iframeResize();
    accordions();
    //setLoginReturnUrl();
    jumpToTargetOffset();

    $(window).on('load', function () {
        jumpToTargetOffset();
    });
});

function addBookmark(scid) {
    var url = "/MyACRDashboard/AddBookmark/" + encodeURIComponent(scid);
    jQuery.ajax({
        type: "POST", url: url, contentType: "application/json", cache: false, error: function () { alert("error posting to bookmark service."); }, success:
        function (data) {
            //alert('post successful');
            //alert(data.Result);    
            alert(data.Message)
        }
    });
}

function deleteBookmark(scid) {
    var url = "/MyACRDashboard/DeleteBookmark/" + encodeURIComponent(scid);
    jQuery.ajax({
        type: "POST", url: url, contentType: "application/json", cache: false, error: function () { alert("error posting to bookmark service."); }, success:
        function (data) {
            //alert('post successful');
            //alert(data.Result);    
            alert(data.Message)
        }
    });
}

function addReccomended(scid) {
    var url = "/MyACRDashboard/AddReccomendedArticle/" + encodeURIComponent(scid);
    jQuery.ajax({
        type: "POST", url: url, contentType: "application/json", cache: false, error: function () { alert("error posting to bookmark service."); }, success:
        function (data) {
            //alert('post successful');
            //alert(data.Result);    
            alert(data.Message)
        }
    });
}

jQuery(".reccommend-link").click(function () {

    var authenticated = jQuery(this).parent().attr('data-authenticated');
    if (authenticated == 'true') {
        var id = jQuery(this).parent().attr('data-sitecore-id');
        addReccomended(id);
    } else {
        window.location = "/Login-Page?returnUrl=" + window.location.pathname + '?addReccomend=1';
    }
});

jQuery('.remove-bookmark').click(function () {

    var result = confirm("Are you sure you want to remove this from your reading list?");
    if (result) {
        jQuery(this).closest('.lg-col-6').hide();
        var id = jQuery(this).attr('data-bookmark-id');
        deleteBookmark(id);

    }

});

jQuery(".bookmark-link").click(function () {

    var authenticated = jQuery(this).parent().attr('data-authenticated');
    if (authenticated == 'true') {

        var id = jQuery(this).parent().attr('data-sitecore-id');
        addBookmark(id);

    } else {
        window.location = "/Login-Page?returnUrl=" + window.location.pathname + '?addBookmark=1';
    }
});

//jQuery('#main-nav-login').click(function () {
//    jQuery(this).find('.main-nav-mega').hide();
//    window.location.href = jQuery(this).find('a').first().attr('href');
//});

jQuery(document).ready(function () {
    jQuery('#main-nav-login').removeClass('has-children');
    if (window.location.href.indexOf('?addReccomend=1') > 0) {
        jQuery(".reccommend-link").click();
    }
    if (window.location.href.indexOf('?addBookmark=1') > 0) {
        jQuery(".bookmark-link").click();
    }
});

jQuery('.news-letter-form').find('input[type="submit"]').click(function () {
    var email = jQuery('.news-letter-form').find('input[type="text"]').val();
    if (window.location.host == 'shop.acr.org') {
        window.location = 'https://www.acr.org/Sign-Up-for-ACR-Newsletters?email=' + encodeURIComponent(email);
    }

    if (window.location.host == 'stgshop75.acr.org') {
        window.location = 'https://staging.org/Sign-Up-for-ACR-Newsletters?email=' + encodeURIComponent(email);
    }

    return false;
});


