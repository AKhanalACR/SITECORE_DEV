!function ($) {
    var VERSION = '1.6.0';

    var EqualizeContent = function (element, option) {
        var _ = this;
        _.el = element;
        _.param = jQuery.extend({
            equalizeItem: '.equalize',
            pattern: null,
            responsive: null,
            startWidth: null,
            stopWidth: 540,
            timerDelay: 100,
            useHeight: false,//instead of using min-height
            useMargin: false,
            aligningCls: 'flex-content-left',
            resizeItem: window
        }, option);
        _.elHeight = (_.param.useHeight) ? 'height' : 'min-height';
        _.$equalizeItems = $(_.el).find(_.param.equalizeItem),
            _.aligningCSS = $(_.el).hasClass(_.param.aligningCls);
        _.winWidth = $(_.param.resizeItem).width();
        _.matches = [];

        _.init(_.el, _.param);

        return _;
    };

    EqualizeContent.prototype.init = function () {
        var _ = this;
        var resizeTimer,
            loaded = /trident/i.test(navigator.userAgent) ? 'load' : 'imgsLoaded';
        //on load if images are present, otherwise equalizing will fail
        $(_.param.resizeItem).on('resize equalizeContent ' + loaded, function (e) {
            clearTimeout(resizeTimer);
            resizeTimer = setTimeout(function () {
                _.equalize();
            }, _.param.timerDelay);
        });
        _.imgsLoadedEvent();
        _.equalize();
        return _;
    };

    EqualizeContent.prototype.imgsLoadedEvent = function () {
        var _ = this;
        var imgl = $('img', _.el).length - 1,
            i = 0;

        $('img', _.el).on('load', function (event) {

            if (imgl === i) {
                $(_.param.resizeItem).trigger('imgsLoaded');
                //console.log('last image src: '+ this.src + " iteration " + i);
            }
            i++;
        });

        if (imgl === 0) $(_.param.resizeItem).trigger('imgsLoaded');
    };

    EqualizeContent.prototype.buildMatchArray = function () {
        "use strict";
        var _ = this;
        _.matches = [];//clear out the array

        _.$equalizeItems.css(_.elHeight, '').each(function (index) {

            var thisTop = Math.floor($(this).position().top);
            var thisHeight = $(this).outerHeight(_.param.useMargin);
            var noMatch = true;
            //whole lotta loopin'
            //console.log($(this).css('min-height'))
            //console.log("this " +index+ ": "+ thisHeight);
            for (var i = 0, l = _.matches.length; i < l; i += 1) {
                if (_.matches[i].ypos === thisTop) {
                    noMatch = false;
                    _.matches[i].elems.push(index);
                    if (_.matches[i].tallest < thisHeight) {
                        _.matches[i].tallest = thisHeight;
                    }
                    break;
                }
            }
            if (_.matches.length === 0 || noMatch) {
                _.matches.push({ ypos: thisTop, elems: [index], tallest: thisHeight });
            }

        });
        //console.log(_.matches);
    };

    EqualizeContent.prototype.assignHeightsToElems = function () {
        "use strict";
        var _ = this;
        for (var i = 0, l = _.matches.length; i < l; i += 1) {
            _.matches[i].elems.forEach(function (index) {
                _.$equalizeItems.eq(index).css(_.elHeight, _.matches[i].tallest);
            });
        }
    };

    EqualizeContent.prototype.equalize = function () {
        var _ = this;
        _.winWidth = $(_.param.resizeItem).width();
        startWidthIsGood = (typeof _.param.startWidth === "number") ? (_.winWidth < _.param.startWidth) : true;

        //if it doesn't have any elements exit the function
        if (!_.$equalizeItems.length) { return; }

        if (_.winWidth > _.param.stopWidth && startWidthIsGood) {

            $(_.el).addClass('in-resize');
            if (!_.aligningCSS) {
                $(_.el).addClass(_.param.aligningCls);
            }

            _.buildMatchArray();
            _.assignHeightsToElems();

            $(_.el).removeClass('in-resize');
            if (!_.aligningCSS) {
                $(_.el).removeClass(_.param.aligningCls);
            }
        } else {
            _.$equalizeItems.css(_.elHeight, '');
        }
    };

    jQuery.fn.equalizeContent = function () {
        var _ = this;

        for (var i = 0, l = _.length; i < l; i++) {
            _[i].equalizeContent = new EqualizeContent(_[i], arguments[0]);
        }
        return _;
    };

    jQuery.fn.equalizeContent.version = VERSION;

}(jQuery);
