export default function accordions() {
	jQuery('.accordion').on('click', '.accordion-header', function () {
		var openState = !!jQuery(this).hasClass('open'),
			toggleOthers = !jQuery(this).closest('.accordion').hasClass('dont-toggle');

		//Expand or collapse this panel
		jQuery(this).next().slideToggle(500);
		//Hide the other panels
		if (toggleOthers) {
			jQuery(this).closest('.accordion').find(".accordion-details")
			.not(jQuery(this).parent().find(".accordion-details"))
			.slideUp(500);

			jQuery(this).closest('.accordion').find(".accordion-header").removeClass('open');
		}
		(openState) ? jQuery(this).removeClass('open') : jQuery(this).addClass('open');
	});
	$('.accordion')
	.find('.accordion-details').css({ display: 'none' })
	.closest('.accordion').addClass('accordion-enabled');
}
