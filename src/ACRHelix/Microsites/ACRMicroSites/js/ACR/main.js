/*******************************************************************************

	CSS on Sails Framework
	Title: ACR
	Author: XHTMLized (http://www.xhtmlized.com/)
	Date: November 2011

*******************************************************************************/


$j(document).ready(function () {

	_createLinks();
	_initTextResizer();
	_initFormElements();
	_selectCurrentMenu();
	_disableCurrentSecondaryMenu();
	_initTabs();
	_initSlider();
	//Pagination won't be strictly client side....
	//_initPagination();
	_initDatePickers();
	_moreShow();
	_handleDateRanges($);
	_initVideoWidgets();
	_initMemberDetail();
	_initHeaderSearch();
	_placeHolderModernizr();
	_expandCollapse($);

    //Added by Addis on 12/8/2016
	_newMessageCount();
});


/*
Sets the Header search box events
*/
function _initHeaderSearch() {

	$j(".header_tbSearch").keypress(function (e) {
		if (e.which == 13) {
			if (!_HeaderSearchDoSearch()) {
				e.preventDefault();
				return false;
			}
		}

	});

	$j(".form-header-search-submit-btn").click(function () {
		_HeaderSearchDoSearch();
	
		return false;
	});
}

function _HeaderSearchDoSearch() {
	var query = $j(".header_tbSearch").val();
	if (query.length > 0 && query != "Search ACR...") {
		var href = $j(".form-header-search-submit-btn").attr("href");
		var appender = "#"; //href.indexOf("?") == -1 ? "?" : "&";
		window.location = href + appender + "q=" + query.replace(/<(?:.|\n)*?>/gm, '');
	}
	else {
		// Do something else
		// Warning about blank searches?
		return false;
	}
}

function _placeHolderModernizr() {

	if (!Modernizr.input.placeholder) {

		$j('[placeholder]').focus(function() {
			var input = $j(this);
			if (input.val() == input.attr('placeholder')) {
				input.val('');
				input.removeClass('placeholder');
			}
		}).blur(function() {
			var input = $j(this);
			if (input.val() == '' || input.val() == input.attr('placeholder')) {
				input.addClass('placeholder');
				input.val(input.attr('placeholder'));
			}
		}).blur();
		$j('[placeholder]').parents('form').submit(function() {
			$j(this).find('[placeholder]').each(function() {
				var input = $j(this);
				if (input.val() == input.attr('placeholder')) {
					input.val('');
				}
			});
		});
	}
}

/* 
Init forms elements (placeholders, selects)
*/
function _initFormElements(){
	
	// init placeholders
	$j('input[placeholder], textarea[placeholder]').JSizedFormPlaceholder({color:'#000'});
	
	// init selects
	//jQuery('select').JSizedFormSelect({defaultText: "-Select-", altTextAttribute: 'data-display', maxItems:3, maxItemsUseMaxHeight: false});
	
	// init checkboxes
	//jQuery('input[type="checkbox"]').JSizedFormCheckbox();
}

/*
	Create links with custom images
*/
function _createLinks(){
	// insert separator to global menu
	$j('.nav-global .main li a')
		.not('.nav-global .main li.current-menu a')
		.not('.nav-global .main li.homemenuitem a')
		.not('.nav-global .submenu li a')
		.before('<span class="separator">&#124;</span>');
	
	//// add arrow to join button
	//$j('header .nav-utility .join-btn a')
	//	.not('header .nav-utility .join-btn.logged-in a')
	//	.after('<span class="join-after-content"></span>');
	
}

function _disableCurrentSecondaryMenu(){

	if($j('.nav-secondary a.active-page').length>0){
		$j('.nav-secondary a.active-page').click(function(e){
			e.preventDefault;
			return false;
		});	
	}		
}

/*
 *	Select current menu item
 */
function _selectCurrentMenu(){
	
	// find current url
	var path = location.pathname;
	paths = path.split('/');
	var lastURL = paths[paths.length-1];
	
	// find if submenu item is selected
	if($j('.nav-global .submenu li a[href="'+lastURL+'"]').length > 0){
		//select it as submenu and select main menu item differently
		$j('.nav-global .submenu li a[href="'+lastURL+'"]').addClass('current-submenu')
																 .parent().parent().parent()
																 .addClass('current-menu');
	// menu item is current
	} else if($j('.nav-global ul li a[href="'+lastURL+'"]').length > 0) {
		$j('.nav-global ul li a[href="'+lastURL+'"]').addClass('current');
	} 
}

/*
	Init Text Resizer
*/
function _initTextResizer(){
	var _textsizer = new fluidtextresizer({
		controlsdiv: 'font-sizers', //id of special div containing your resize controls. Enter "" if not defined
		targets: ['.content-with-sidebar', '.content-with-sidebar p',
					'aside'], //target elements to resize text within: ["selector1", "selector2", etc]
		levels: 3, //number of levels users can magnify (or shrink) text
		persist: 'none', //enter "session" or "none"
		animate: 200 //animation duration of text resize. Enter 0 to disable
	});
}

/*
	Init Tabs
*/
function _initTabs(){
	if($j("ul.tabs").length > 0){
		$j("ul.tabs").tabs("div.panels > div");
	}
}

/*
	Init Slider
*/
function _initSlider(){
	
	// one item slider / with auto-scrolling
	if($j('.slider.one-item.scroll .scrollable').length>0){
		
		// one item only
		if($j('.slider.one-item.scroll .scrollable .items div').length < 2){
		
			$j('.scrollable[data-rel="one-item"]').scrollable();
			$j('.slider.one-item.scroll .nav').css('display','none');
			
		// more than 2 items
		} else {
		
			var root = $j('.scrollable[data-rel="one-item"]').scrollable({ circular: true }).navigator().autoscroll({ autoplay: true, interval:5000 });
		
			window.api = root.data('scrollable');
			
			// current slide index
			var index;
			// play/pause state
			var paused = false;
			
			// show captions upon scroll
			api.onSeek(function () {
				index = this.getIndex() + 1;

				// show captions
				$j('.slider.one-item.scroll .captions').fadeTo(250, 0, function () {
					// hide current caption
					$j('.slider.one-item.scroll .captions li').fadeTo(0, 0);
					// show current caption
					$j('.slider.one-item.scroll .captions li[title="' + index + '"]').fadeTo(0, 1, function () {
						// fade in main captions box
						$j('.slider.one-item.scroll .captions').fadeTo(250, 1);
					});
				});
			});
			
			// pause button mouse click hanlder
			$j('.slider.one-item.scroll .nav .pause').click(function(){
				// slider stopped
				if(paused){
					api.play();
					paused = false;
					$j(this).removeClass('play');
					
				// slider is playing
				} else {
					api.stop();
					paused = true;
					$j(this).addClass('play');
					
				}
			});

			//add click event to stop slider when any navigation items are selected.
			$j('.slider.one-item.scroll .navi a, .slider.one-item.scroll .nav a.prev, .slider.one-item.scroll .nav a.next').click(function () {
				//make sure slider stops
				paused = true;
				api.stop();

				//make sure play/pause button has correct class
				var playPauseBtn = $j('.slider.one-item.scroll .nav .pause');
				if (!playPauseBtn.hasClass('play')) {
					playPauseBtn.addClass('play');
				}
			});
		}
		// hide all captions
		$j('.slider.one-item.scroll .captions li').fadeTo(0, 0);
		
		// show first caption, if available
		if($j('.slider.one-item.scroll .captions li[title="1"]').length>0){
			$j('.slider.one-item.scroll .captions li[title="1"]').fadeTo(0, 1);
		} else {
			// hide main caption box
			$j('.slider.one-item.scroll .captions').fadeTo(0, 0);
		}			
	}
	
	// one item slider / no scrolling
	if($j('.slider.one-item.no-scroll .scrollable').length>0) {
		// one item only
		if($j('.slider.one-item.no-scroll .scrollable .items .module').length < 2){
			$j('.scrollable[data-rel="one-item"]').scrollable();						
		// more than 2 items
		} else {
			$j('.scrollable[data-rel="one-item"]').scrollable().navigator();
		}
	}
	
	// two item slider
	if($j('.slider.two-items .scrollable').length>0) {
		// one item only
		if($j('.slider.two-items .scrollable .items .module').length <= 2){
			$j('.scrollable[data-rel="two-items"]').scrollable();						
		// more than 2 items
		} else {
			$j('.scrollable[data-rel="two-items"]').scrollable().navigator();
		}
	}
	
	// four item slider
	if($j('.slider.four-items .scrollable').length>0){
		// one item only
		if($j('.slider.four-items .scrollable .items .module').length <= 4){
			$j('.scrollable[data-rel="four-items"]').scrollable();						
		// more than 2 items
		} else {
			$j('.scrollable[data-rel="four-items"]').scrollable().navigator();
		}
	}
}

/*
Init Pagination
*/

function _initPagination(){
	if($j('.paging_container').length>0){
	$j('.paging_container').pajinate({
		items_per_page : 10,
		item_container_id : '.pagination_content',
		nav_panel_id : '.page_navigation'
		
	});
	}
}

/*
Init DatePickers
*/

function _initDatePickers() {
	$j('input.s-datepicker').datepicker();
}

/*
Searchbar - more box
*/

function _moreShow(){

	$j('.searchbar .cat-more').click(function(e){
			
			$j(this).prev('.more-box').slideToggle();
		}).toggle(
			function() {
				$j(this).text('Less'); }, 
			function() { 
				$j(this).text('More'); }
		);

			$j('.module .cat-more').click(function (e) {

				$j(this).prev('.more-box').slideToggle();
			}).toggle(
			function () {
				$j(this).text('Less');
			},
			function () {
				$j(this).text('More');
			}
		);
}

function _expandCollapse($){
	$j('.js-sub-content-list').each(function(){
		var $el = $j(this),
			$content = $el.find('.js-sub-content-list-content').first();

		if($content.length === 0) {
			return;
		}

		$el.find('h3').click(function (e) {
			if($el.hasClass('is-expanded')){
				$el.removeClass('is-expanded');
				$content.slideUp();
			} else {
				$el.addClass('is-expanded');
				$content.slideDown();
			}
		});
	});
}

/*
Handle DateRanges
*/

function _handleDateRanges($) {
	$j(".ch-auto-date-range").change(function () {
		if ($j(this).attr('checked')) {
			$j('.ch-auto-date-range:checked').not(this).attr('checked', false);
			var now = new Date();
			var span = new Date($j(this).attr('days') * 86400000);
			var oldDate = new Date(now.getTime() - span.getTime());
			$j(".s-datepicker.startdate").val(oldDate.getMonth() + 1 + "/" + oldDate.getDate() + "/" + oldDate.getFullYear());
			$j(".s-datepicker.enddate").val((now.getMonth() + 1) + "/" + now.getDate() + "/" + now.getFullYear());
		}
	});
	$j(".ch-future-date-range").change(function () {
		if ($j(this).attr('checked')) {
			$j('.ch-future-date-range:checked').not(this).attr('checked', false);
			var now = new Date();
			var span = new Date($j(this).attr('days') * 86400000);
			var newDate = new Date(now.getTime() + span.getTime());
			$j(".s-datepicker.startdate").val((now.getMonth() + 1) + "/" + now.getDate() + "/" + now.getFullYear());
			$j(".s-datepicker.enddate").val(newDate.getMonth() + 1 + "/" + newDate.getDate() + "/" + newDate.getFullYear());
		}
	});
}

/* VideoWidgets */
function _initVideoWidgets() {
	try{
	$j("a.videoPromo").fancybox(
		{
			width: 640,
			height: 480,
			autoDimensions: true,
			type: 'inline'
		});
	}catch(err){}
	}

	function _initMemberDetail() {
		try{
		$j("a.mDtl").fancybox(
		{
			width: 305,
			height: 425,
			autoDimensions: false,
			type: 'inline'
		});
		}catch(err){}
	}

    //Added by Addis on 12/8/2016
	function _newMessageCount() {
	    var count = jQuery('#header_LoginControl_divNewMessageCount').text(); 
	    jQuery('#header_LoginControl_hlMessages').attr('data-badge', count);
	    if (count == "0")
	        jQuery('#header_LoginControl_hlMessages').removeClass('badge');
	}