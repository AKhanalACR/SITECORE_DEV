export default function scrollToTarget() {
	//if were doing a click
	$("body").on("click.scrollto", "a[href^='#']", function (event) {
		'use strict';
		var targ = this.hash;
		var lhash = location.hash;
		var target = $(targ);
		var coveoSearchParams = ((/f\:/).test(lhash) || (/q\=/).test(lhash));
		var eClickScroll = event.type === "click";

		var inDesktop = $(window).width() > 1024;
		var hdrHeight = inDesktop ? $('#site-header').height(): 0;

		event.preventDefault();
		
		if (!coveoSearchParams && eClickScroll) {
			if (target.length > 0) {

				$('body,html').animate({
					scrollTop: (target.offset().top - hdrHeight)
				}, $('html,body').scrollTop() * .35);

			} else if (targ === '#to-top' && eClickScroll) {
				$('body,html').animate({
					scrollTop: 0
				}, $('html,body').scrollTop() * .35);
			}
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

export function jumpToTargetOffset() {
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
