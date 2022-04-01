jQuery(document).ready(function($) {
	$('.rotator-items').addClass('cycle-widget').cycle({
		fx: $.browser.msie ? 'none' : 'fade',
		speed: 1000,
		timeout: 8000,
		pager: '.rotator-pager',
		activePagerClass: 'active',
		pause: true,
		cleartype: true,
		cleartypeNoBg: true,
		pagerAnchorBuilder: function(idx, slide) {
			return '<a href="#"></a>';
		}
	});
});
