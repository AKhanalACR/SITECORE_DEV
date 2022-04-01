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
