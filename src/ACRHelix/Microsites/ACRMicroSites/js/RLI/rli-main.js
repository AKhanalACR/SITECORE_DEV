/*!
 * Hileman's
   Base-Frame version: 1.1.0
 * 
 */

/*AFTER RESIZE script... minified*/
!function(n){"use strict";var t,i={action:function(){},runOnLoad:!1,duration:200},a=i,e=!1,o={};o.init=function(){for(var t=0;t<=arguments.length;t++){var i=arguments[t];switch(typeof i){case"function":a.action=i;break;case"boolean":a.runOnLoad=i;break;case"number":a.duration=i}}return this.each(function(){a.runOnLoad&&a.action(),n(this).resize(function(){o.timedAction.call(this)})})},o.timedAction=function(n,i){var o=function(){var n=a.duration;if(e){var i=new Date-t;if(n=a.duration-i,0>=n)return clearTimeout(e),e=!1,void a.action()}r(n)},r=function(n){e=setTimeout(o,n)};t=new Date,"number"==typeof i&&(a.duration=i),"function"==typeof n&&(a.action=n),e||o()},n.fn.afterResize=function(n){return o[n]?o[n].apply(this,Array.prototype.slice.call(arguments,1)):o.init.apply(this,arguments)}}(jQuery);

/*Easy Tabs js... minified as well*/
!function($){$.fn.easyTabs=function(option){var param=jQuery.extend({fadeSpeed:"fast",defaultContent:1,activeClass:'active',callback:false},option);$(this).each(function(){var thisId="#"+this.id;if(param.defaultContent==''){param.defaultContent=1;}
if(typeof param.defaultContent=="number")
{var defaultTab=$(thisId+" .tabs li:eq("+(param.defaultContent-1)+") a").attr('href').substr(1);}else{var defaultTab=param.defaultContent;}
$(thisId+" .tabs li a").each(function(){var tabToHide=$(this).attr('href').substr(1);$("#"+tabToHide).addClass('easytabs-tab-content');});hideAll();changeContent(defaultTab);function hideAll(){$(thisId+" .easytabs-tab-content").hide();}
function changeContent(tabId){hideAll();$(thisId+" .tabs li").removeClass(param.activeClass);$(thisId+" .tabs li a[href=\"#"+tabId+"\"]").closest('li').addClass(param.activeClass);if(param.fadeSpeed!="none")
{$(thisId+" #"+tabId).fadeIn(param.fadeSpeed);}else{$(thisId+" #"+tabId).show();}}
$(thisId+" .tabs li").click(function(){var tabId=$(this).find('a').attr('href').substr(1);changeContent(tabId);if(typeof param.callback ==='function'){param.callback(tabId);	}return false;});});}}(jQuery);





/*MOBILE NAV*/
!function($){
	"use strict";
	$.fn.mobileNavigation=function(option){
		var param=jQuery.extend({
			mobileButton: '#mobile-nav-btn',
			navParent: $(this).selector,
			slide: 300,
			navOpenState: 'body',
			callback:false
		},option);
	
	$('body').append('<div class="mobile-menu-overlay" />');
			
	function mobileNav(){
		$(param.mobileButton).click(function(event){
			mobileMenuToggle(param.navParent);
			event.stopPropagation();
		});
		$(param.navParent).find('li').has('ul').each(function(){
			if(!$(this).hasClass('has-children')){ 
				$(this).addClass('has-children');
			}
		});
		$(param.navParent).on('click','.has-children,a',function(event){
			var that = this; 
			if($(this).hasClass('menu-opened')){
				$(this).find('> ul').slideUp(param.slide,function(){
					$(this).removeAttr('style');
					$(that).removeClass('menu-opened')
					.find('.menu-opened').removeClass('menu-opened');
				});
			}else{
				$(this).addClass('menu-opened')
				.find('> ul').css('display','none')
				.slideDown(param.slide);
			}
			event.stopPropagation();
		});
		
	}

	function mobileMenuToggle(el,nav){
	
		//so we can pass just one argument if two aren't needed
		var els = arguments.length > 1 ? nav+', '+el: el;
		
		if($(param.navOpenState).hasClass('menu-opened')){ 
			$(els).removeClass('menu-opened')
			.find('.menu-opened').removeClass('menu-opened');
			$(param.navOpenState).removeClass('menu-opened');
		}else{
			$(els).addClass('menu-opened');
			$(param.navOpenState).addClass('menu-opened');
		}
	}
	mobileNav();
	};
}(jQuery);


/*ENHANCE DESKTOP NAV*/
!function($){
$.fn.enhanceDesktopNav=function(option){
	var param=jQuery.extend({
		navParent: $(this).selector,
		mobileSwitchOff: 740,
		delay: 1000,
		navEdgeClassName: 'main-nav-edge'
	},option);
	
	$(param.navParent).find('li').has('ul').each(function(){
		if(!$(this).hasClass('has-children')){ 
			$(this).addClass('has-children');
		}
	});
		
	var menuDelayDropdowns = (function(_navParent,_delay){
		var stayHover;
		return function(_navParent,_delay){
			jQuery(_navParent).find('ul').on('mouseout','.has-children',function(){
				clearInterval(stayHover);
				var that = this;
				
				//jQuery(_navParent).find('.hover').not(this).removeClass('hover');
				jQuery(this).addClass('hover');
				stayHover = setTimeout(
					function(){
						jQuery(that).removeClass('hover');
					},
				_delay);
			});
			
			jQuery(param.navParent).find('ul').on('mouseover','> li',function(){
				jQuery(param.navParent).find('.hover').removeClass('hover');
			});
		};
	})();
	menuDelayDropdowns(param.navParent,param.delay);

	$(param.navParent).find("li").on('mouseenter mouseleave', function(){
		if($(window).width() > param.mobileSwitchOff){
			if ($('ul', this).length) {
				var elm = $('ul:first', this);
				var off = elm.offset();
				var l = off.left;
				var w = elm.width();
				var docW = $(window).width();
	
				var isEntirelyVisible = (l + w <= docW);
	
				if (!isEntirelyVisible) {
					$(this).addClass(param.navEdgeClassName);
				} else {
					if($(this).hasClass('hover')){
						console.log('has navs edge class');
						$(this).removeClass(param.navEdgeClassName);
					}
				}
			}
		}
		});		
	};
}(jQuery);


!function($){
	"use strict";
	var instances = [],	
		stickyAnimate = function(param,isScrolled){
		//strip the classname dot if its present
		var stickyClass = param.stickyClassName.replace(/\./g,''),
			offsetTop = param.offsetTop;
		
		var scrollTop = jQuery(window).scrollTop();
		if(scrollTop > offsetTop && !jQuery(param.nav).hasClass(stickyClass)){
			jQuery(param.nav).addClass(stickyClass);
			if(isScrolled){
				jQuery(param.nav).css('top',param.startPosition)
					.animate({top: param.endPosition},param.duration);
			}
		}
		if(scrollTop < offsetTop){ 
			jQuery(param.nav).removeClass(stickyClass);
		}
	};
	
	function Sticky(element,option){
		var self = this;
		self.param = $.extend({
			nav: element,
			stickyClassName: 'sticky',
			duration: 300,
			offsetTop: 200,
			startPosition: "-100px",
			endPosition: "0px"
		},option);
		
		(function(){
		var scrollTimer;
			$(window).on("scroll",function(){
				clearTimeout(scrollTimer);
				scrollTimer = setTimeout(function(){
					for(var i = 0,l = instances.length; i < l; i++){
						stickyAnimate(instances[i].param,true);
					}
				},50);
			});
		})();
		stickyAnimate(self.param,false);
			
		return self;
	}
	
	$.fn.sticky = function() {
        var self = this,
            opt = arguments[0],
            args = Array.prototype.slice.call(arguments, 1),
            ret,inst;
			
        for (var i = 0, l = self.length; i < l; i++) {
            if (typeof opt === 'object' || typeof opt === 'undefined'){
                inst =  self[i].sticky = new Sticky(self[i], opt);
				instances.push(inst);
			}else{
                inst = ret = self[i].sticky[opt].apply(self[i].sticky, args);
            	if (typeof ret !== 'undefined') {return ret;}
				instances.push(inst);
        	}
		}
        return self;
    };
	$.fn.sticky.Constructor = Sticky;
	Sticky.version = "1.1.0";
}(jQuery);



function iframeHeightResize(not,offset){
	"use strict";
	jQuery('iframe').each(function(){
		var h = jQuery(this).attr('height'),
			w = jQuery(this).attr('width'),
			ratio = h/w,
			computedWidth = jQuery(this).width(),
			newHeight = (Math.floor(computedWidth * ratio) + offset) + 'px';
		
		jQuery(this).not(not).css('height', newHeight);
	});
}

!function($){
	"use strict";
		
	$.extend({ 
		iframeResize: function(option){
		var param=jQuery.extend({offset: 0, not: ''},option);
		
		(function(){
			var resizeTimer;
			$(window).on('resize', function(e) {	
				clearTimeout(resizeTimer);
				resizeTimer = setTimeout(function() {	
					iframeHeightResize(param.not,param.offset);			
				}, 250);
			});
		})();
		iframeHeightResize(param.not,param.offset);
		}
	});

}(jQuery);

!function(){
	var instances = [];
		
	function equalize(element,param){	
		var tallest = 0,
			equalizeItems = jQuery(element).find(param.equalizeItem),
			hasInlineBlockCols = jQuery(element).hasClass('inline-block-cols');
			winWidth = $(param.resizeItem).width();
			startWidthIsGood = (typeof param.startWidth === "number") ? (winWidth < param.startWidth) : true;
	
		//if it doesn't have any elements exit the function
		if(!jQuery(element).find(param.equalizeItem).length){return;}
		
		if(winWidth > (param.stopWidth - 30) && startWidthIsGood){
			
			jQuery(element).addClass('in-resize');
			
			if(typeof param.pattern === 'string' || param.smartPattern){
				var currPatt = (param.smartPattern && param.pattern) ? param.pattern.split(';') || [Number(param.pattern)] : [],
					prevPatt = 0,
					endPatt;
					
				  	
				if(param.smartPattern){
					(!hasInlineBlockCols) ? jQuery(element).addClass('inline-block-cols') : '';

					var prevTop = Math.floor(equalizeItems.eq(0).position().top),
						totalItems = equalizeItems.length-1;
						inRow  = 0;
					equalizeItems.each(function(index){
						
						if(index === 0 ) {return;}
						
						var thisTop = Math.floor(jQuery(this).position().top); 
						/*console.log("element " +index+ ": " + thisTop);*/
						if(thisTop === prevTop){
							inRow+=1;
						}else{
							currPatt.push(inRow+1);
							inRow = 0;
						}
						if(index === totalItems){currPatt.push(inRow+1);}
						prevTop = thisTop;
					});
					
					(!hasInlineBlockCols) ? jQuery(element).removeClass('inline-block-cols') : '';
				} //console.log('updated: '+currPatt);
					
				for(var i = 0,p = 0,l = equalizeItems.length; i < l; i++){
					if(currPatt[p] === ''){break;}
					endPatt = Number(currPatt[p]) + prevPatt;
					equalizeItems.slice( prevPatt , endPatt ).css('min-height','0').each(function(){
						$(this).outerHeight() > tallest ? tallest = $(this).outerHeight() : '';
				
					}).css('min-height', tallest + "px");
					
					if(equalizeItems.slice(prevPatt + 1).length === 0 ){break;}
							
					prevPatt += Number(currPatt[p]);	
					(p > i ) ?  p = 0 : p++;
					tallest = 0;
				}	
			}else{
				equalizeItems.removeAttr('style').each(function(){
					$(this).outerHeight() > tallest ? tallest = $(this).outerHeight() : '';
				});
				equalizeItems.css('min-height', tallest + "px");
			}
    	}else{
      		equalizeItems.removeAttr('style');
   		}
		jQuery(element).removeClass('in-resize'); 
	}
		
	var EqualizeContent = function(element,option){
		var self = this;
		self.el = element;
		self.param = $.extend({
				equalizeItem:'.equalize', 
				pattern: null,
				responsive: null,
				smartPattern: true,
				startWidth: null,
				stopWidth: 640,
				resizeItem: window
			},option);
		
		self.resize(self.el,self.param);
		
		return self;
	};
	
	EqualizeContent.prototype.resize = function(el,param){ 
		var self = this;
		var resizeTimer;
		//on load if images are present, otherwise equalizing will fail
		$(param.resizeItem).on('resize load', function(e) {	
			clearTimeout(resizeTimer);
			resizeTimer = setTimeout(function() {	
				for(var i = 0,l = instances.length; i < l; i++){
					equalize(instances[i].el,instances[i].param);
				}			
			}, 100);
		});
		
		equalize(el,param);	
	};
	
	$.fn.equalizeContent = function() {
        var self = this,
            opt = arguments[0],
            args = Array.prototype.slice.call(arguments, 1),
            ret,inst;
			
        for (var i = 0, l = self.length; i < l; i++) {
			
            if (typeof opt === 'object' || typeof opt === 'undefined'){
                inst = self[i].equalizeContent = new EqualizeContent(self[i], opt);
				instances.push(inst);
				
			}else{
                inst = ret = self[i].equalizeContent[opt].apply(self[i].equalizeContent, args);
				instances.push(inst);
			}
            if (typeof ret !== 'undefined') {return ret;}
        }
		
        return self;
    };
	$.fn.equalizeContent.Constructor = EqualizeContent;
	EqualizeContent.version = "1.3.0";
}(jQuery);



function accordions(){
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
		
		(openState) ? jQuery(this).removeClass('open') : jQuery(this).addClass('open');
	});
	
}

 
function scrollToTarget(){
	if(!!jQuery('a[name]').length){
		jQuery("a[href^='#']").on('click', this, function(e) {
			 var target = jQuery('a[name="'+this.href.split("#")[1]+'"]');
			 if( target.length > 0 ) {
				 e.preventDefault();
				 jQuery('body,html').animate({
					 scrollTop: target.offset().top
				 }, 700);
			 }
		 });
	}
}


//Development Helpers
function getWidestObject(){	
	var widestObject = null, 
		theWidest = 0; 
		jQuery('*').not('script').each(function(){
		if(jQuery(this).width() > theWidest){
			widestObject = this;
		}
	});
	console.log(widestObject);
}


jQuery(function($){
	$('#main-nav').mobileNavigation();
	$('#main-nav').enhanceDesktopNav();
	$.iframeResize();
});