!function($) {
    $.fn.scrollInView = function(selector,option) {
	var touchSwipeScript = false;
	
	if(typeof jQuery.fn.swipe === 'undefined'){
		console.log('please add jquery.touchSwipe.js touch swiping will not work :-/');
	}else{
		touchSwipeScript = true;
	}
	
	
		
	$(this).each(function(index){	
		
		var parentElem = this,
			hasTouchSwipe = touchSwipeScript,
			scrollingEnabled = false,
			scrolledIndex = 0,
			param = jQuery.extend({
				startWidth:1024,
				childItem: '.in-view-item',
				$slideContainer: null,
				offsetBtnSpace: 64,
				//thisElem: this.selection,
				not: 'tabs-evenly-spaced',
				scrollItemAmount: 1,
				breakPointsOnWindow: true,
				resizeDelay: 100,
				fixItemsToScreenWidth: [
					{breakpoint:359,cols:1},
					{breakpoint:768,cols:2},
					{breakpoint:1024,cols:3},
					{breakpoint:2800,cols:4}
				],
				buttonsAddedClass: 'in-view-btns-added'
			},option);
		
		var thisInstance = '.scrollyID_' + index + "_" + selector.slice(1);
			$(this).addClass( thisInstance.slice(1) );
		
		var $parent = $(thisInstance),
			$slideContainer = $parent.find(param.$slideContainer),
			slideContainerOrigMinWidth = (parseInt($slideContainer.css('width')) > 0) ? parseInt($slideContainer.css('width')) : 0,
			scrolledItems = $parent.find(param.childItem+':first').parent().find(param.childItem).length,
			slideContainerWidth = $slideContainer.width() + param.offsetBtnSpace,
			btnsAdded = false,
			doFixedScroll = (param.childItem === 'td'),
			tFixedScrollOffset = 1,//<-remove this eventually
			wrapperWidth,
			currElemLeft = 0,
			lastElemWidth = $slideContainer.find(param.childItem).last().outerWidth(),
			lastElemPos = $slideContainer.find(param.childItem).last().position().left,
			fixedItemsToScreen;
		
		
		if( $(this).hasClass((param.not || 'tabs-evenly-spaced')) || $(this).hasClass('table-no-scroll')) {return;}
		
		$parent.addClass("hide-left-btn");
		
		//wrap it so we can better hide the overflow
		$slideContainer.wrap('<div class="in-view-wrapper" />');
		
		//adding position relative to the slideContainer
		$slideContainer.css({'position':'relative'});
		
		function getFixedItemsToScreen(){
			
			wrapperWidth = $parent.find('.in-view-wrapper').width();
			var widthToUse = (param.breakPointsOnWindow) ? $(window).width(): wrapperWidth;
			
			if(typeof param.fixItemsToScreenWidth === 'number'){
								
				fixedItemsToScreen = param.fixItemsToScreenWidth;

			}else if(typeof param.fixItemsToScreenWidth ==='object'){
				//structure array like this, SMALLEST FIRST, not adding that logic
				//var arr = [{breakpoint:360,cols:1},{breakpoint:1200,cols:2}]
				
				for(var i = 0, 
					l = param.fixItemsToScreenWidth.length,
					fisw = param.fixItemsToScreenWidth; i < l;i++){
					
					if(widthToUse <= fisw[i].breakpoint){
						fixedItemsToScreen =fisw[i].cols;
						break;
					}
				}
			}
			

			if(doFixedScroll){
				//should find them on a UL and table at least
				
				var itemWidth = (wrapperWidth / fixedItemsToScreen) - tFixedScrollOffset;

				$slideContainer.css(
					{'width': (itemWidth * scrolledItems) + scrolledItems + 'px',
					'table-layout':'fixed'
				});
			}
		}
		
		function changePos(direction){
			
			if(!scrollingEnabled) {return;}
			
			var doNum = (doFixedScroll ) ? fixedItemsToScreen : param.scrollItemAmount,
				lastItemInView = (lastElemPos + lastElemWidth - currElemLeft )<(wrapperWidth-param.offsetBtnSpace);
			
			if(direction.toUpperCase() === "LEFT" || direction.toUpperCase() ==="SWIPERIGHT"){
				(scrolledIndex === 0) ? scrolledIndex : 
					((scrolledIndex <= scrolledIndex - param.scrollItemAmount) 
						? scrolledIndex = 0 : scrolledIndex-= param.scrollItemAmount);
				
			}else if(direction.toUpperCase() === "RIGHT" || direction.toUpperCase() ==="SWIPELEFT"){
				if(!lastItemInView  || doFixedScroll){
					(scrolledIndex >= scrolledItems - doNum) 
						? scrolledIndex : scrolledIndex+= param.scrollItemAmount;
				}
			}
		
			currElemLeft = $parent.find(param.childItem).eq(scrolledIndex).position().left;
			
			//lastItemInView needs to be redefined for the display 
			//of the buttons after the currElemLeft is updated
			lastItemInView = (lastElemPos + lastElemWidth - currElemLeft )<(wrapperWidth-param.offsetBtnSpace);
			
			
			if(doFixedScroll && currElemLeft !==0) currElemLeft+= tFixedScrollOffset;
			$slideContainer.css('transform','translate3d('+(currElemLeft*-1)+'px, 0px, 0px)');

			$parent.removeClass('hide-right-btn hide-left-btn');
			(scrolledIndex === 0) && $parent.addClass('hide-left-btn');
			
			if(!doFixedScroll){
				(lastItemInView) && $parent.addClass('hide-right-btn');
			}else{
				(scrolledIndex === scrolledItems - doNum) 
					&& $parent.addClass('hide-right-btn');
			}
			
			
			if(doFixedScroll){
				
				if(!scrollingEnabled) return;
				
				$parent.find('table,.scroll-box')
					.not('table table')
					.find('tr, > div').each(function(){
					 
					$(this).find('th,td')
						.removeClass('contents-in-view')
						.addClass('hide-contents')
						.slice(scrolledIndex, scrolledIndex+fixedItemsToScreen)
						.removeClass('hide-contents').addClass('contents-in-view');
				});
			}else{
				
				$parent.find(param.childItem).each(function(){
					var thisLoc =($(this).position().left + $(this).width()) - currElemLeft;
					
					if(thisLoc > wrapperWidth ){
						$(this).addClass('ellipsis');
					}else{
						$(this).removeClass('ellipsis');
					}	
				});
				
			}
		}
		
		
		$parent.on('click','.view-btn-left',function(){
			changePos('LEFT');
		})
		.on('click','.view-btn-right',function(){
			changePos('RIGHT');
		})
		.on('mouseleave touchend',function(){ 
			
			$(this).trigger('mouseup');
			
			$slideContainer.css('transform','translate3d('+(currElemLeft*-1)+'px, 0px, 0px)');
		});
		
		if(hasTouchSwipe && doFixedScroll){ 
			
			$parent.swipe({
				swipe:function(event, direction) { 
					changePos("SWIPE"+direction);
				},
				swipeStatus:function(event, phase, direction, distance, duration){
					var dragPos = currElemLeft,
						dragDistance = (distance < 130) ? distance : 130;
					
					if (phase==="move" && scrollingEnabled) {
						
						if(direction.toUpperCase() === "LEFT"){ 
							$slideContainer
								.css('transform','translate3d('+((dragPos + dragDistance)*-1)+'px, 0px, 0px)');
							
						}else if(direction.toUpperCase() === "RIGHT"){
							$slideContainer
								.css('transform','translate3d('+((dragPos - dragDistance)*-1)+'px, 0px, 0px)');
						}
					}
					if ( (phase==="end" || event.type==="touchcancel" || event.type ==="mouseup") && scrollingEnabled ){
						
						$slideContainer
							.css('transform','translate3d('+(currElemLeft*-1)+'px, 0px, 0px)'); 
						
				 	}
				},
				allowPageScroll: "vertical"
			});
		}
		
		return (function(parentElem,param){
			var resizeTimer; 
			$(window).on('resize load scrollInView', function() {	
				clearTimeout(resizeTimer);
				
				slideContainerWidth = $slideContainer.width();
				
				resizeTimer = setTimeout(function() {	
					
					wrapperWidth = $parent.find('.in-view-wrapper').width();
					
					var basedOnThisWidth = (slideContainerOrigMinWidth > 0) 
							? slideContainerOrigMinWidth : slideContainerWidth;
					
					if( (basedOnThisWidth >= wrapperWidth ) /*&& ($(window).width() < param.startWidth)*/ ){
					
						scrollingEnabled = true; 
						
						getFixedItemsToScreen();
						
						if(!btnsAdded){
							btnsAdded = true;
							$parent.addClass(param.buttonsAddedClass)
							.append('<i class="in-view-btn view-btn-left acr-icon icon-arrow-left"/><i class="in-view-btn view-btn-right acr-icon icon-arrow-right"/>');
						}
						$parent.addClass('hide-left-btn');
						changePos('');
						
					}else{
						scrollingEnabled = false;
						scrolledIndex = 0;
						currElemLeft = 0;
						//remove right and left scrolly buttons
						if(btnsAdded){
							btnsAdded = false;
							$parent.removeClass(param.buttonsAddedClass + ' hide-right-btn hide-left-btn')
								.find('.in-view-btn').remove();
						}
						$slideContainer.css({'transform':'translate3d(0px, 0px, 0px)','width':''});
						
						if(doFixedScroll){
							$slideContainer.css({'min-width': '','table-layout':''});
							$parent.find(param.childItem).css('width','');
							$slideContainer.find('th,td').removeClass('hide-contents');
							
						}else{
							$parent.find(param.childItem).removeClass('ellipsis');
						}
					}
					
				}, param.resizeDelay, parentElem,param);
			});
		})(parentElem,param);	
	});
	return this;
	}
}(jQuery);