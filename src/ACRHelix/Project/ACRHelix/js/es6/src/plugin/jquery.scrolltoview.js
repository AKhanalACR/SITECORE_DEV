!function($) {
	$.fn.scrollToView = function(){
		var instanceID = 0,
			touchSwipeScript = false,
        	param = jQuery.extend({
            startWidth: 1020,
			childItem: '.in-view-item',
			$slideContainer: $(thisInstance).find(myParam.$slideContainer) || $parentElem.find('.slide-container'),
			offsetBtnSpace: 64,
			scrollItemAmount:1,
			useWindow: true,
			resizeDelay: 100,
			fixItemsToScreenWidth: false,
			buttonsAddedClass: 'in-view-btns-added'
        }, option);

		var $parentElem = $(thisInstance),
			thisParentElem = parentElem,
			slideContainer = param.$slideContainer || '.slide-container',
			hasTouchSwipe = touchSwipeScript,
			scrollingEnabled = false,
			scrolledIndex = 0;

		if(typeof jQuery.fn.swipe === 'undefined'){
			console.log('please add jquery.touchSwipe.js touch swiping will not work :-/');
		}else{
			touchSwipeScript = true;
		}

        $(this).each(function() {
			var thisInstance = '.scrollyID_' + instanceID + "_" + parentElem.substr(1);
			$(parentElem).eq(instanceID).addClass( thisInstance.slice(1) );
			instanceID++;

		});
	return this;
	}
}(jQuery);


function scrollInView(parentElem,myParam){
	var instanceID = 0,
		touchSwipeScript = false;

	if(typeof jQuery.fn.swipe === 'undefined'){
		console.log('please add jquery.touchSwipe.js touch swiping will not work :-/');
	}else{
		touchSwipeScript = true;
	}

	$(parentElem).each(function(){
		var thisInstance = '.scrollyID_' + instanceID + "_" + parentElem.substr(1);
		$(parentElem).eq(instanceID).addClass( thisInstance.slice(1) );
		instanceID++;

		var $parentElem = $(thisInstance),
			thisParentElem = parentElem,
			slideContainer = myParam.$slideContainer || '.slide-container',
			hasTouchSwipe = touchSwipeScript,
			scrollingEnabled = false,
			scrolledIndex = 0,
			param = {
				startWidth: myParam.startWidth || 1020,
				childItem:  myParam.childItem || '.in-view-item',
				$slideContainer: $parentElem.find(myParam.$slideContainer) || $parentElem.find('.slide-container'),
				offsetBtnSpace: myParam.offsetBtnSpace || 64,
				scrollItemAmount : myParam.scrollItemAmount || 1,
				useWindow : myParam.useWindow || true,
				resizeDelay: myParam.resizeDelay || 100,
				fixItemsToScreenWidth: myParam.fixItemsToScreenWidth || false,
				buttonsAddedClass: myParam.buttonsAddedClass || 'in-view-btns-added'
			},
			scrolledItems = (param.childItem === 'td')
				? $parentElem.find('td').first().parent('tr').find('td').length : $(param.childItem).length,
			slideContainerWidth = param.$slideContainer.width() + param.offsetBtnSpace,
			btnsAdded = false,
			tableFixedScroll = (typeof param.fixItemsToScreenWidth ==="number" && param.childItem === 'td');
			$parentElem.addClass("hide-left-btn");

		//wrap it so we can better hide the overflow
		param.$slideContainer.wrap('<div class="in-view-wrapper" />');

		//adding position relative to the slideContainer
		param.$slideContainer.css({'position':'relative','left':'0'});


		if(tableFixedScroll){
			$parentElem.find('.in-view-wrapper').addClass('hide-out-of-view');
		}

		var changePos = function(self,direction){

			if(!scrollingEnabled) return;

			var $thisParent = $(self).closest(thisParentElem),
				tableNum =(tableFixedScroll && param.scrollItemAmount === 1) ? 1 : 0;

			if(direction.toUpperCase() === "LEFT" || direction.toUpperCase() ==="SWIPERIGHT"){

				(scrolledIndex === 0) ? scrolledIndex :
					((scrolledIndex <= scrolledIndex - param.scrollItemAmount)
				 		? scrolledIndex = 0 : scrolledIndex-= param.scrollItemAmount);

			}else if(direction.toUpperCase() === "RIGHT" || direction.toUpperCase() ==="SWIPELEFT"){

				(scrolledIndex >= scrolledItems - param.scrollItemAmount)
					? scrolledIndex : scrolledIndex+= param.scrollItemAmount;
			}

			var elemLeft = $thisParent.find(param.childItem).eq(scrolledIndex).position().left;

			if(tableFixedScroll && elemLeft !==0) elemLeft-= 24;
			$thisParent.find(slideContainer).css('left','-'+elemLeft+'px');

			//visibility check on right and left buttons
			$thisParent.removeClass('hide-right-btn hide-left-btn');

			if(scrolledIndex===0)
				$thisParent.addClass('hide-left-btn');

			if(scrolledIndex===scrolledItems - param.scrollItemAmount - tableNum)
				$thisParent.addClass('hide-right-btn');

			if(tableFixedScroll){
				//the .hide-out-of-view class can only be added if its a table
				$parentElem.find('.hide-out-of-view').find('tr').each(function(){
					$(this).find('th,td').addClass('hide-contents')
						.slice(scrolledIndex, scrolledIndex+param.fixItemsToScreenWidth)
						.removeClass('hide-contents');
				});
			}
		}

		$parentElem.on('click','.view-btn-right',function(){changePos(this,'RIGHT');});
		$parentElem.on('click','.view-btn-left',function(){changePos(this,'LEFT');});

		if(hasTouchSwipe && tableFixedScroll ){

			$parentElem.swipe({
				swipe:function(event, direction) {
					changePos(this,"SWIPE"+direction);console.log('scrolling enabled')
				},
				allowPageScroll: "vertical"
			});
		}

		return (function(parentElem,myParam){
			var resizeTimer;
			$(window).on('resize load', function() {
				clearTimeout(resizeTimer);
				resizeTimer = setTimeout(function() {
					var winWidth = (param.useWindow) ? $(window).width()
						: $parentElem.find('.in-view-wrapper').width();

					if((slideContainerWidth > winWidth) && (winWidth < param.startWidth) ){

						scrollingEnabled = true;
						//add in right and left buttons to the parent container,
						//add class to parent container to allow spacing for
						if(!btnsAdded){
							btnsAdded = true;
							$parentElem.addClass(param.buttonsAddedClass)
							.append('<span class="in-view-btn view-btn-left acr-icon icon-arrow-left"></span><span class="in-view-btn view-btn-right acr-icon icon-arrow-right"></span>');
						}
						$parentElem.addClass('hide-left-btn');

						//do this only if its a table!
						if(tableFixedScroll){

							var itemWidth = ($parentElem.find('.in-view-wrapper').width() / param.fixItemsToScreenWidth) - 24;

							//should find them on a UL and table at least
							param.$slideContainer.css({'min-width': (itemWidth * scrolledItems) + scrolledItems + 'px','table-layout':'fixed'});
							//$parentElem.find(param.childItem).css('width',itemWidth + "px");
							$parentElem.find('.hide-out-of-view')
								.find('tr').each(function(){
									$(this).find('th,td').addClass('hide-contents')
										.slice(scrolledIndex, scrolledIndex+param.fixItemsToScreenWidth).removeClass('hide-contents');
							});
						}

					}else{
						scrollingEnabled = false;
						scrolledIndex = 0;
						//remove right and left scrolly buttons
						if(btnsAdded){
							btnsAdded = false;
							$parentElem.removeClass(param.buttonsAddedClass + ' hide-right-btn hide-left-btn')
								.find('.in-view-btn').remove();
						}
						$parentElem.find(slideContainer).css('left','0');

						if(tableFixedScroll){
							param.$slideContainer.css({'min-width': ''});
							$parentElem.find(param.childItem).css('width','');
							param.$slideContainer.find('th,td').removeClass('hide-contents');

						}
					}

				}, param.resizeDelay, parentElem,myParam);
			});
		})(parentElem,myParam);
	});
}
