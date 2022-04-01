jQuery(document).ready(function () {
	//attach click event to our meeting overview register link
	jQuery('a[data-link-type="meeting-overview-register"]').click(function () {
		//show our registration tab.
		jQuery('ul.tabs li a[data-tab-type="meeting-registration"]').click();
	});
});