export default function tabRotatingTiles(sliderElem) {
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
