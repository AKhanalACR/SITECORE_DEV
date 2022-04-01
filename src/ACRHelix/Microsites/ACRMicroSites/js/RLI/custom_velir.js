$(document).ready(function () {
	//tag <html> with the 'ie10' class, if you're in IE version 10
	if (Function('/*@cc_on return document.documentMode===10@*/')()) { document.documentElement.className += ' ie10'; }

	//impliment placeholders in IE
	if ($.support.placeholder != true) {
		$('input').placeholder();
	}

	//jquery cycle for carousel
	//setting slideshow background to current slide image
	if ($('.carousel').length > 0) {
		var theSlideshow = $('.slideshow');

		cycleBackground();
		
		theSlideshow.cycle({
			fx: 'none',
			timeout: 7000,
			pager: '.carousel .nav',
			after: cycleBackground
		});

		$('.carousel .controls a').on('click', function () {
			var $this = $(this);

			if ($this.hasClass('pause')) {
				theSlideshow.cycle('pause');
				$this
					.hide()
					.next().show();
			} else if ($this.hasClass('play')) {
				theSlideshow.cycle('resume');
				$this
					.hide()
					.prev().show();
			}
			
		});
	}

	//Setting the page background for subpages
	if ($('.pageBackground img').length > 0) {
		//Pull in the user selected background image
		var theBackground = $('.pageBackground img').attr('src');
		setBackground(theBackground);
	}


	//Tabbed section(s) scripting
	$('.tabbed .tabs a').click(function () {
		$('.tabbed .selected').removeClass('selected');
		$(this).addClass('selected');
		var selectedIndex = $(this).index() + 1;
		$('.tabbed section:nth-of-type(' + selectedIndex + ')').addClass('selected');
	});


	//Ensure that button height matches up with button icon
	if ($('.button.icon img').length > 0) {
		$('.button.icon img').each(function () {
			//get the height of the image/icon
			var targetHeight = $(this).height();
			//add in the combined height of the top and bottom padding of the parent element

			if (/*$('html.ie8').length > 0 ||*/$('html.ie9').length > 0 || $('html.ie10').length > 0) {
				//If you're in IE8, do not add the padding to the height measurement
				targetHeight += Math.round(
					parseFloat($(this).parent().css('padding-top').slice(0, -2)) +
					parseFloat($(this).parent().css('padding-bottom').slice(0, -2))
				);
			}

			//modify the min-height of the parent element to better match the icon height
			$(this).parent().css('min-height', (targetHeight));
		});

	}


});                    	// End Document.ready


//add the ability to detect support for 'placeholder' to the jQuery.support object
jQuery.support.placeholder = (function () {
	var i = document.createElement('input');
	return 'placeholder' in i;
})();

//Function to set the background of the page to the current slideshow background
function cycleBackground(theImage) {
	var currentImage = $('.slideshow .slide:visible img').attr('src');
	setBackground(currentImage);
}

//Function to calculate the combined height of the header+mainNav
function getHeaderHeight() {
	//this function returns the combined height of the header and main nav
    return Math.round($('header.header').height()) +
                    //Using hard value instead of 'Math.round($('header.headerBanner').height())' since it was taking time
                    109 +
					Math.round($('nav.mainNav').height()) +
					'px';
}

//Function to set the background of the BODY to the specified image, centered
//horizontally and with it's top position just below the header+mainNav
function setBackground(theImage) {
	$('body').attr('style', 'background:url("' + theImage + '") no-repeat center ' + getHeaderHeight() + '; background-size:1680px 476px;');
}