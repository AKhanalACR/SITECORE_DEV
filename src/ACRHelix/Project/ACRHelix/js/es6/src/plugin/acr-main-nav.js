/*
	Acr.org Main Navigation!
*/
(function($){
	"use strict";
	
	if(!$('#main-nav').length){console.log('no #main-nav element');}
	
	var mouseleaveTimerLvl1,
		mouseenterTimerLvl1,
		myDelay = 600,
		desktopWidth = 1024,
		$dropdownNavAllElemsStr = '';

	//var start = Date.now();
	
	var ACRMegaMenu = ACRMegaMenu || {};
	//no need to return a new instance, just object literal
	ACRMegaMenu.buildDropDown = function(){
		//this does the little carrot and etc on desktop
		//and the clicks to the inners
		var _ = this;
		$('li','#main-nav').each(function(index){	
			if( !!$(this).has('ul').length ){
				var thisParents = $(this).parents('ul').length;

				$(this).addClass('has-children')
					.append('<i class="nav-enable-lvl acr-icon" />')
					.find('>a').attr('data-nav-el','nav-lvl-ul-'+thisParents+"-i-"+index);
			}
		}).each(function(){
			if( $(this).hasClass('has-children') ){
				_.buildLevel2NavUtility(this);
			}
		});
		//add in the links on the bottom for mobile
		$('#main-nav').find('#main-nav-holder').append('<div id="m-nav-bottom">'+ $('#additional-mobile-nav').html() + '</div>');
		$('#additional-mobile-nav').remove();	
		//now append once to the spot we want it!
		$('#main-nav-dropdown').append($dropdownNavAllElemsStr);
	};
	
	ACRMegaMenu.buildLevel2NavUtility = function(elem){
		var $a = $(elem).find('>a'),
			anchorClassId = ($a.data('nav-el') || 'NA'),
			thisAnchor= '<a href="'+$a.attr('href')+'" >'+$a.html()+"</a>";
		
		$dropdownNavAllElemsStr += '<div class="main-dropdown-nav-item" data-nav-lvl="'+anchorClassId+'"><div class="m-close-dropdown sm-only acr-icon icon-cancel"></div><div class="content row"><div class="dropdown-nav-lvl-2 col-nav-level"><i class="tablet-nav-only tablet-nav-back nav-back"><i class="acr-icon icon-chevron2-left"></i>Back</i><h3><i class="mobile-nav-back nav-back acr-icon icon-arrow-skinny-left"></i>'+thisAnchor+'</h3><ul>'+($(elem).find('>ul').html())+'</ul></div><div class="dropdown-nav-lvl-3 col-nav-level"></div></div></div>';
	};	 
	
	ACRMegaMenu.mobileNavButton = function(){
		//for the mobile button
		$('#mobile-nav-btn').click(function(event){

			if($('body').hasClass('menu-opened')){ 
				$('#main-nav').removeClass('menu-opened hide-main-nav')
					.find('.menu-opened').removeClass('menu-opened');
				$('body').removeClass('menu-opened');
				$('#main-nav-dropdown').removeClass('m-dropdown-open')
					.find('.enabled-lvl2-item')
					.removeClass('enabled-lvl2-item');
			}else{
				$('#main-nav').addClass('menu-opened');
				$('body').addClass('menu-opened');
			}
			event.stopPropagation();
		});
		
		//close that dropdown on mobile
		$('#main-nav-dropdown').on('click','.m-close-dropdown,.dropdown-nav-lvl-2 .nav-back',function(){
			$('.enabled-lvl2-item','#main-nav-dropdown')
				.removeClass('enabled-lvl2-item');

			$('#main-nav-dropdown').removeClass('m-dropdown-open');
			$('#main-nav').removeClass('hide-main-nav');
		});
	};

	ACRMegaMenu.level1EnterExit = function(){
		$('#main-nav').find('#main-nav-holder').on('mouseenter mouseleave','.has-children',function(event){
			//exit this function if were not in desktop
			if( $(window).width() <= desktopWidth ) {return;}

			clearTimeout(mouseleaveTimerLvl1);
			clearTimeout(mouseenterTimerLvl1);
			var $lvl1Anchor = $(this).find('>a'),
				lvl2Id = '[data-nav-lvl='+ ($lvl1Anchor.data('nav-el')||'NA') +']',
				$lvl2DropDown = $(lvl2Id),
				that = this;
			if(event.type === "mouseenter"){

				mouseenterTimerLvl1 = setTimeout(function(){
					$('.enabled-lvl2-item','#main-nav-dropdown')
					.not(lvl2Id)
					.removeClass('enabled-lvl2-item');

					$lvl2DropDown.addClass('enabled-lvl2-item');

				},110);
				$(that).addClass('hover');
				$('.hover','#main-nav').removeClass('hover');

			}else{

				mouseleaveTimerLvl1 = setTimeout(function(){
					$('.enabled-lvl2-item','#main-nav-dropdown')
						.removeClass('enabled-lvl2-item');

					$('.hover','#main-nav').removeClass('hover');
				}, myDelay);

			}
		});
	};
	
	ACRMegaMenu.level2EnterExit = function(){
		//hovering over populated UL in mega dropdown
		$('#main-nav-dropdown').on('mouseleave mouseenter','.enabled-lvl2-item',function(event){

			//exit this function if were not in desktop
			if( $(window).width() <= desktopWidth ) {return;}

			var currAnchorStr = "[data-nav-el="+$(this).data('nav-lvl').toString()+"]";

			if(event.type === "mouseenter"){
				clearTimeout(mouseleaveTimerLvl1);
				$('#main-nav').find('.hover').removeClass('hover');
				$('[data-nav-el="'+ $(this).data('nav-lvl').toString() +'"]').addClass('hover');
				$(currAnchorStr).parent().addClass('hover');
			}else{	
				mouseleaveTimerLvl1 = setTimeout(function(){
					$('.enabled-lvl2-item','#main-nav-dropdown')
						.removeClass('enabled-lvl2-item');

					$('#main-nav').find('.hover').removeClass('hover');
				}, myDelay);		
			}
		});
	};
	
	ACRMegaMenu.mobileLevel2Click = function(){
		$('ul','#main-nav').on('click','.nav-enable-lvl',function(){
			//exit if were not in mobile
			if( $(window).width() > desktopWidth ) {return;}

			var $lvl1Anchor = $(this).parent('li').find('>a'),
				lvl2Id = '[data-nav-lvl='+ ($lvl1Anchor.data('nav-el')||'NA') +']',
				$lvl2DropDown = $(lvl2Id);
				//$lvl2DropDown = $(this).siblings('ul');

			$('#main-nav-dropdown').addClass('m-dropdown-open');
			$lvl2DropDown.addClass('enabled-lvl2-item');
			$('#main-nav').toggleClass('hide-main-nav');

		});
	};
	
	ACRMegaMenu.level3Click = function(){
		//for the 3rd level button click .nav-lvl-3-outer
		$('#main-nav-dropdown').on('click','.dropdown-nav-lvl-2 .nav-enable-lvl',function(){
			var $lvl3Nav = "<ul>"+ $(this).parent('li').find('ul').html() + "</ul>",
				$lvl3Location = $(this).closest('.main-dropdown-nav-item').find('.dropdown-nav-lvl-3'),
				$a = $(this).parent('li').find('>a'),
				thisAnchor = '<a href="'+$a.attr('href')+'" >'+$a.html()+"</a>";

			$('.enabled-lvl2-item')
				.find('.selected-lvl3-li')
				.removeClass('selected-lvl3-li');

			$(this).closest('.main-dropdown-nav-item')
				.find('.col-nav-level')
				.toggleClass('nav-lvl-3-enabled');

			$(this).closest('li').addClass('selected-lvl3-li');
			$lvl3Location.html('<div class="nav-lvl-3-outer">'+
				'<span class="tablet-nav-only tablet-nav-back nav-back"><i class="acr-icon icon-chevron2-left"/>Back</span>'+
				'<h3><i class="mobile-nav-back nav-back acr-icon icon-arrow-skinny-left" />'+thisAnchor+'</h3>'+
				$lvl3Nav+'</div>' );
			setTimeout(function(){
				$lvl3Location.find('.nav-lvl-3-outer')
					.addClass('enabled-lvl3-item');	
			},100);
		});
	};
	
	ACRMegaMenu.level3Back = function(){
		$('#main-nav-dropdown').on('click','.dropdown-nav-lvl-3 .nav-back',function(){
		$(this).closest('.main-dropdown-nav-item')
			.find('.col-nav-level')
			.removeClass('nav-lvl-3-enabled');
		});
	};
	
	ACRMegaMenu.level4Click = function(){
		/*only for mobile & desktop level 4! */
		$('#main-nav-dropdown').on('click', '.nav-lvl-3-outer .nav-enable-lvl', function() {

			var $parentLi = $(this).parent('li'),
				$liUL = $parentLi.find('>ul');

			//give it some transitioning tlc
			if( !$liUL.is(':visible') ){
				$parentLi.addClass('show-level-4');
				$liUL.css({ 'opacity': '0'}).animate({'opacity': '1'}, 600);
			}else{
				$liUL.animate({'opacity': '0'}, 600,
					function(){
						$parentLi.removeClass('show-level-4');
					});
			}
		});
	};
	
	ACRMegaMenu.init = function(){
		var _ = this;
		_.buildDropDown();
		_.level1EnterExit();
		_.level2EnterExit();
		_.level3Click();
		_.level3Back();
		_.level4Click();
		_.mobileNavButton();
		_.mobileLevel2Click();
	};
	ACRMegaMenu.init();
	//how long does she take to execute!
	//var end = Date.now();
	//console.log("execution time: " + (end - start) );

})(jQuery);