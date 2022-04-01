export function resourceSlider(elem) {
    //Dependencies js/slick.1.6.0.custom.min.js/
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

export function squareItUp(elem, _p) {
    return (function (elem, _p) {
        var param = {
            stopWidth: _p.stopWidth || 960,
            squareItem: _p.squareItem || '.square-it-item',
            resizeDelay: _p.resizeDelay || 100,
            useOuterWidth: _p.useOuterWidth || false
        }
        var resizeTimer;
        $(window).on('resize load squareItUp', function () {
            clearTimeout(resizeTimer);
            resizeTimer = setTimeout(function () {
                //console.log(elem+ " | " +param.stopWidth + " | " + param.squareItem);

                if ($(window).width() > param.stopWidth) {
                    $(elem).each(function () {
                        var squareUnit = (_p.useOuterWidth) ? $(this).find(param.squareItem).eq(0).outerWidth()
                            : $(this).find(param.squareItem).eq(0).width();

                        $(this).find(param.squareItem).each(function () {
                            $(this).css('min-height', squareUnit + 'px');
                        });
                    });
                } else {
                    $(elem).find(param.squareItem).css('min-height', '');
                }
            }, param.resizeDelay, elem, param);
        }).trigger('squareItUp');

        //to make it extend further than the square if the
        //content exceeds it.. using 'height'
        $(elem).equalizeContent({
            equalizeItem: param.squareItem,
            stopWidth: param.stopWidth,
            resizeDelay: 230,
            useHeight: true
        });
    })(elem, _p);
}

export function tabRotatingTiles(sliderElem) {
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

            //slight (1ms) delay so we don't get the
            //resize issue with the slider of it being 1px in width
            setTimeout(tabRotatingTilesUtility, 1, tabId, thisTabID);
        }
    }).first().each(function () {
        var firstTabId = jQuery(this).find('.tabs .active').find('a').attr('href').slice(1);
        tabRotatingTilesUtility(firstTabId, this);
    });
}

export function tabRotatingTilesUtility(tabId, sliderElem) {
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
        }).last().on('load', function () {
            jQuery(window).trigger('resize');
            // setTimeout(function(){
            // 	var theMinHeight = parseFloat(jQuery(sliderElem).css('min-height'));
            // 	var theHeight = jQuery(sliderElem).height() > theMinHeight ? jQuery(sliderElem).height() : theMinHeight;
            //
            // 	jQuery(sliderElem).css('min-height',theHeight);
            // },20);
        });
}