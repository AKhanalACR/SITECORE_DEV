export default function tooltips(parent) {
	$('.tool-tip').find('> .tip-text')
	.wrapInner('<div class="tip-text-inner" />');

	$('.tool-tip').each(function () {

		if ($(this).hasClass('reccommend-link') || $(this).hasClass('bookmark-link')) {
			$(this).find('> .tip-text').hide();
		}

	});

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

		var link = jQuery(this);

		if (link.hasClass('reccommend-link')) {
			reccomendClick(this);
		}
		if (link.hasClass('bookmark-link')) {
			bookmarkClick(this);
		}
		e.preventDefault();
		e.stopPropagation();
	});
}
