export default function iframeHeightResize(not, offset) {
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
