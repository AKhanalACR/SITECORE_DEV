jQuery.noConflict();

/*AFTER RESIZE script... minified*/
!function(n){"use strict";var t,i={action:function(){},runOnLoad:!1,duration:200},a=i,e=!1,o={};o.init=function(){for(var t=0;t<=arguments.length;t++){var i=arguments[t];switch(typeof i){case"function":a.action=i;break;case"boolean":a.runOnLoad=i;break;case"number":a.duration=i}}return this.each(function(){a.runOnLoad&&a.action(),n(this).resize(function(){o.timedAction.call(this)})})},o.timedAction=function(n,i){var o=function(){var n=a.duration;if(e){var i=new Date-t;if(n=a.duration-i,0>=n)return clearTimeout(e),e=!1,void a.action()}r(n)},r=function(n){e=setTimeout(o,n)};t=new Date,"number"==typeof i&&(a.duration=i),"function"==typeof n&&(a.action=n),e||o()},n.fn.afterResize=function(n){return o[n]?o[n].apply(this,Array.prototype.slice.call(arguments,1)):o.init.apply(this,arguments)}}(jQuery);


var iframeHeight = function(elem){
	"use strict";
	var h = jQuery(elem).attr('height'),
		w = jQuery(elem).attr('width'),
		ratio = h/w,
		computedWidth = jQuery(elem).width(),
		newHeight = (Math.floor(computedWidth * ratio) + 0) + 'px';
	
	//now it gets a brand new height!
	jQuery(elem).css('height', newHeight);
};


var searchExpand = function(){
	"use strict";
	jQuery('body').click(function(){	
		if(jQuery('.search-box-header').hasClass('focused') && 
			jQuery('.search-box-header').find('input[type=text]').val() ===''){
				jQuery('.search-box-header').removeClass('focused');
		}
	});
	
	jQuery('.search-box-header').find('input[type=text]').click(function(){
		setTimeout(function(){
			jQuery('.search-box-header').addClass('focused');
		},50);
	});
};


var accordions = function(){
	"use strict";
	jQuery('.accordion-header').on('click',this,function(){		 
		var openState 	 = !!jQuery(this).hasClass('open'),
			toggleOthers = !jQuery(this).closest('.accordion').hasClass('dont-toggle');
			
		//Expand or collapse this panel
		jQuery(this).next().slideToggle(500);
		//Hide the other panels
		if(toggleOthers){
			jQuery(this).closest('.accordion').find(".accordion-details")
			.not(jQuery(this).parent().find(".accordion-details"))
			.slideUp(500);
			
			jQuery(this).closest('.accordion').find(".accordion-header").removeClass('open');
		}
		
		openState ? jQuery(this).removeClass('open') : jQuery(this).addClass('open');
	});
	
};

var mobileToggleSideNav = function(){
	"use strict";
	jQuery(".product-logo").on('click',this,function(){
		/*exit if its not mobile*/
		if(jQuery(window).width() > 640){return;}
		
		jQuery(".product-navigation").toggle(500,function(){
			if(jQuery(this).hasClass('sm-opened')){
				jQuery(this).addClass('sm-closed').removeClass('sm-opened').removeAttr('style');	
				jQuery(".product-logo").removeClass('sm-opened');
			}else{
				jQuery(this).removeClass('sm-closed').addClass('sm-opened').removeAttr('style');
				jQuery(".product-logo").addClass('sm-opened');
			}
		});
	});
	//jQuery(".product-navigation").addClass('sm-closed');
};
 
var scrollToTarget = function(){
	"use strict";
	jQuery("a[href^='#']").on('click', this, function(e) {
		 var target = jQuery('a[name="'+this.href.split("#")[1]+'"]');
		 if( target.length > 0 ) {
			 e.preventDefault();
			 jQuery('body,html').animate({
				 scrollTop: target.offset().top
			 }, 700);
		 }
	 });
};

jQuery(function(){
	'use strict'; 
	accordions();
	searchExpand();
});