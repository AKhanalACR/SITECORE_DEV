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
