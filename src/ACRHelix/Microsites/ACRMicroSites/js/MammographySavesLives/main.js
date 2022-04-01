(function ($) {

	$(document).ready(function () {
		$('.tell-a-friend-modal').click(function (e) {
			e.preventDefault();
			$.blockUI({
				message: $('.friend-modal'),
				css: {
					border: 'none',
					padding: '0',
					margin: '0',
					width: '600px',
					top: '30px',
					left: '25%',
					backgroundColor: '#fff'
				}
			});
		});

		$('.friend-modal-cancel').click(function () {
			$.unblockUI();
			return false;
		});

		$('.friend-modal-send').click(function (e) {
			e.preventDefault();
			$.unblockUI({
				onUnblock: function () {
					eval($('.friend-modal-send').attr('href'));
					if ($.inArray(true, $('.friend-modal span').map(function () { return $(this).css('display') == "inline"; })) >= 0) {
						$('.tell-a-friend-modal').click();
					}
				}
			});
			return false;
		});

		$('.social-icon-item:last').addClass('social-icon-last');
		$('.content-footer-item:last').addClass('content-footer-last');
		$('.home-callout-item:last').addClass('home-callout-last');
		$('.home-section .video-downloads:first div:first').removeClass('video').addClass('video-first');
		$('.home-section .video-downloads:first a:first').removeClass('arrow-link').addClass('arrow-link-first');
		$('.home-section .video-downloads:first .video-downloads-info:first').removeClass('video-downloads-info').addClass('video-downloads-info-first');
		$('.home-section .video-downloads-start-at-40:first div:first').removeClass('video').addClass('video-first');
		$('.home-section .video-downloads-start-at-40:first a:first').removeClass('arrow-link').addClass('arrow-link-first');
		$('.home-section .video-downloads-start-at-40:first .video-downloads-info:first').removeClass('video-downloads-info').addClass('video-downloads-info-first');
		resetChannelAreaHeight();
	});

})(jQuery);

function resetChannelAreaHeight() {
	$('.channel-area:visible').height($('.video-area:visible').height());
}