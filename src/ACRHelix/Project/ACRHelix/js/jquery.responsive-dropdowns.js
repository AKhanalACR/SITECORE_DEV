
/*Plugin: $(elem).responsiveDropDown()*/
(function($){
	function ResponsiveDropDown(element, params) {
		"use strict";
		var _ = this;
		_.initials = {
			clickHeader: '.resp-nav-header',
			toggleBody: '.resp-nav-dd-body',
			openHeaderClass: 'resp-dd-active',
			inMobileClass: 'resp-dd-in-mobile',
			closeBtnBottom: true,
			closeBtnHTML: null,
			toggleAmount: 600,
			mobileBreak: 768
		};
		//_.log = $('h1');
		_.isActive = false;
		_.$outer = $(element);
		_.resizeDelay = null;
		_.windowWidth = $(window).width();
		_.param = $.extend({},_.initials,params);

		_.init();
	};

	ResponsiveDropDown.prototype.init = function(){
		"use strict";
		var _ = this;
		_.windowWidth = $(window).width();
		_.updateMobileDesktopView();
		_.clickHeaderClick();
		_.outsideClickClose();
		if(_.param.closeBtnBottom){
			_.doCloseBtn();
		}
	};

	ResponsiveDropDown.prototype.outsideClickClose = function(){
	"use strict";
	var _ = this;
	iosOutsideClickSupport.add();
	//I need to do some event capturing, not supported via jQuery
		$('body')[0].addEventListener("click",function(event){
			var isToggleBody = $(_.param.toggleBody).find(event.target).length;

			if( isToggleBody ){ return }

			if(_.isActive){
				//need to remove the click real fast
				if(_.windowWidth < _.param.mobileBreak){
					//openHeaderClass
					_.$outer.toggleClass(_.param.openHeaderClass);
					$(_.param.toggleBody,_.$outer).slideUp(_.param.toggleAmount);

					_.$outer.off('click');
					_.isActive = !_.isActive;

					//anddd add it back
					setTimeout(function(){
						_.clickHeaderClick();
					},100);
				}
			}
		},true);
	};

	ResponsiveDropDown.prototype.doCloseBtn = function(){
		"use strict";
		var _ = this;
		var openTag = '<div class="dd-close-btn-area">',
			closeTag = '</div>',
			defaultCloseBtnHTML = '<button class="close-dd-nav">Close</button>',
			closeBtnBottomHTML = _.param.closeBtnHTML || defaultCloseBtnHTML;

		$(_.param.toggleBody, _.$outer).append(openTag +closeBtnBottomHTML + closeTag);
	};

	ResponsiveDropDown.prototype.updateMobileDesktopView = function(){
		"use strict";
		var _ = this;
		$(window).on('resize responsiveDropDown',function(event){
			clearTimeout(_.resizeDelay);
			_.resizeDelay = setTimeout(function(){
				var winWidth = $(window).width(),
					didntActuallyResize = (_.windowWidth === winWidth);
				_.windowWidth = winWidth;

				if(didntActuallyResize){
					if(event.type === 'resize') return;
				}

				if(_.windowWidth > _.param.mobileBreak ){
					_.$outer.removeClass(_.param.inMobileClass).removeClass(_.param.openHeaderClass);

					$(_.param.clickHeader,_.$outer).css({display: 'none'});
					$(_.param.toggleBody,_.$outer).css({display: 'block'});
					_.isActive = false;
				}else{
					//in mobile
					_.$outer.addClass(_.param.inMobileClass);
					$(_.param.clickHeader,_.$outer).css({display: 'block'});
					//$(_.param.toggleBody,_.$outer).css({display: 'none'});
					//_.isActive = false;
				}
			},100);
		}).trigger('responsiveDropDown');
	};

	ResponsiveDropDown.prototype.clickHeaderClick = function(){
		"use strict";
		var _ = this;
		_.$outer.on('click ddtoggle',_.param.clickHeader + ', .close-dd-nav' ,function(event){
			if(_.windowWidth < _.param.mobileBreak){
				//openHeaderClass

				_.$outer.toggleClass(_.param.openHeaderClass);
				if(!_.isActive){
					$(_.param.toggleBody,_.$outer)
						.slideDown(_.param.toggleAmount);
					_.isActive = true;
				}else{
					$(_.param.toggleBody,_.$outer)
						.slideUp(_.param.toggleAmount);
					_.isActive = false;
				}


				event.stopPropagation();
			}
		});
	};

	$.fn.responsiveDropDown = function(){
		"use strict";
		var _ = this;
		for (var i = 0,l = _.length; i < l; i++) {
			_[i].responsiveDropDown = new ResponsiveDropDown(_[i],arguments[0]);
		}
	}
})(jQuery);
