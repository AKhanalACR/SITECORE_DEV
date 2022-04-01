export default function lookForExternalUrlThenAddIcon(_params) {
	"use strict";
	var initials = {
		elem: 'a',
		outer: 'main',
		elemWithinLink: null
	},
	params = $.extend({}, initials, _params),
	SITEURL = location.protocol + '//' + location.hostname;

	$(params.elem, params.outer).each(function () {
		var $this = $(this),
		thisURL = $this.attr('href'),
		//icon must be a span.. or other workaround needed
		//since other components directly use the <i> tag
		//for styling purposes
		icon = '&nbsp;<span class="icon-external-site"/>';

		if (
			!RegExp(SITEURL).test(thisURL) &&
			/^http(s|)\:\/\//.test(thisURL) &&
			!$this.hasClass('external-link-added') && ($this.find('img').length == 0)
		) {

			if (params.elemWithinLink) {
				$this.find(params.elemWithinLink)
				.not('.no-target-icon')
				.append(icon)
				.attr('target', '_blank');
			} else {
				$this.not('.no-target-icon')
				.append(icon)
				.attr('target', '_blank');
			}

			//give it a tracking class
			$this.addClass('external-link-added');
		}

	});
}
