$(document).ready(function () {
	//impliment placeholders in IE
	if ($.support.placeholder != true) {
		$('input').placeholder();
	}



	//jquery cycle for homepage slideshow
	if ($('.carousel').length > 0) {
		$('.slideshow').cycle({
			fx: 'fade',
			timeout: 5000,
			pager: '.carousel .pager'
		});
	}
	$('.carousel .pause').click(function () {
		$('.slideshow').cycle('toggle');
		$(this).toggleClass('play');
	});



	//minor css adjustment for .mission when .newsletter is present
	if ($('.newsletter').length > 0) {
		$('.mission').addClass('wider');
	}


	//additions for the homepage styling in IE7
	if ($('.wrapper').hasClass('home') && $('html').hasClass('ie7')) {
		$('.home article section:nth-child(2n+1)').before('<div></div>');
	}



});


//add the ability to detect support for 'placeholder' to the jQuery.support object
jQuery.support.placeholder = (function () {
	var i = document.createElement('input');
	return 'placeholder' in i;
})();