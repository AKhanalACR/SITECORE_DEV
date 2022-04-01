
jQuery(function ($) {
	//this fn comes from acr-main.js
	iosOutsideClickSupport.add();

	/*the normal*/
	$('#filter-search').find('select').dropdown();
	scrollInView('.acr-tabs', { childItem: 'li', $slideContainer: 'ul', scrollItemAmount: 1 });

	/*preventing some default for now*/
	$('.acr-tabs').on('click', 'a', function (event) {
		event.preventDefault();
	});

	/*filter tab clicking*/
	$('#filter-tab').on('click', function (event) {
		$('#filter-tab').toggleClass('active visible');
		$('#filter-tab-outer').toggleClass('filter-opts-shown');
		$('#filter-dropdown-area').toggleClass('show-filter-dropdown');
		if ($('#filter-dropdown-area').hasClass('show-filter-dropdown')) {
			$('#filter-dropdown').css('min-height', $('#filter-dropdown').height() + 'px');
		} else {
			$('#filter-dropdown').css('min-height', '');
		}
		setTimeout(function () {
			$('#filter-dropdown').css('min-height', '');
		}, 500);
		event.stopPropagation();
	});

	/*not filter tab clicking*/
	$('main').on('click', function (event) {
		var $target = $(event.target);
		if ((!$('#filter-dropdown').find(event.target).length) && $(event.target).closest('.coveo-facet-value').length == 0) {
			if (!$target.is('#filter-dropdown')) {
				$('#filter-tab').removeClass('active visible');
				$('#filter-tab-outer').removeClass('filter-opts-shown');
				$('#filter-dropdown-area').removeClass('show-filter-dropdown');
				$('#filter-dropdown').css('min-height', '');
			}
		}
	});

	/*filter accordion functionality*/
	$('#filter-dropdown').on('click', '.filter-cat-header', function () {
		$(this).parent().next().slideToggle(500);
		$(this).toggleClass('open');
	});

});
