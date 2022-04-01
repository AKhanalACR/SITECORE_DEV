jQuery(document).ready(function () {
	jQuery('ul.showHideList').each(function (index, value) {
		if (jQuery(value).children('li').length > 5) {
			jQuery(value).children('li:gt(4)').hide();
			jQuery(value).after('<a href="#" class="showhideul link-more arrow">View More</a>');
		}
	});
	jQuery('.showhideul').click(function (e) {
		e.preventDefault();
		jQuery(this).prev('ul').children('li:gt(4)').toggle();
		jQuery(this).text(jQuery(this).text() == 'View More' ? 'View Less' : 'View More');
	});
});