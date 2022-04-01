RLI = [];
if (RLI == null) {
    RLI = [];
}

if (RLI.Search == null) {
    RLI.Search = [];
}

$(document).ready(function () {
    RLI.Search.Accordion();
});

//facets accordion
RLI.Search.Accordion = function accordions() {
    "use strict";
    jQuery('.CoveoFacet').on('click', '.coveo-facet-header', function () {
        var openState = !!jQuery(this).hasClass('open'),
		toggleOthers = !jQuery(this).closest('.CoveoFacet').hasClass('dont-toggle');

        //Expand or collapse this panel
        jQuery(this).next().slideToggle(500);
        //Hide the other panels
        if (toggleOthers) {
            jQuery(this).closest('.CoveoFacet').find(".coveo-facet-values")
			.not(jQuery(this).parent().find(".coveo-facet-values"))
			.slideUp(500);

            jQuery(this).closest('.CoveoFacet').find(".coveo-facet-header").removeClass('open');
        }
        (openState) ? jQuery(this).removeClass('open') : jQuery(this).addClass('open');
    });
    $('.CoveoFacet')
	.find('.coveo-facet-values').css({ display: 'open' })
	.closest('.CoveoFacet').addClass('accordion-enabled');
}