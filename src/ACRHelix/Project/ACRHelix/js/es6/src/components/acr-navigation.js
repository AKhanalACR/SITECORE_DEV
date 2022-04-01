import iosOutsideClickSupport from './ios-click-support.js';


!function ($) {
	'use strict';

	var VERSION = 'ACR 2.1.1';
	var ACRMainNav = ACRMainNav || {};

	ACRMainNav = (function () {
		ACRMainNav = function (element, option) {
			var _ = this;
			_.stayHover;
			_.level1StartDelay;
			_.$element = $(element);
			_.windowWidth = $(window).width();
			_.resizeDelay = null;
			_.initials = {
				mobileButton: '#mobile-nav-btn',
				mainNavHolder: '#main-nav-holder',
				mobileWidth: 1024,
				delay: 900,
				navHoveredBodyClass: 'desktop-nav-hovered',
				outerElement: 'body',
				outsideClickClose: true,
				afterHovered: function () { }
			};
			_.param = $.extend({}, _.initials, option);
			_.mobileMenuOpened = false;
			_.desktopMenuOpened = false;

			_.init();
		};
		return ACRMainNav;
	})();

	ACRMainNav.prototype.init = function () {
		"use strict";
		var _ = this;

		_.magicifyUlElems();
		_.highlightPath();
		_.desktopClicking();
		_.hoverDelay();
		_.level1InitialDelay();
		_.mobileNavClicking();
		_.navOnSticky();
		_.resizeUpdate();
		_.addAdditionalMobileLinks();
		if (_.param.outsideClickClose) {
			_.doOutsideClick();
		}
		return _;
	};

	ACRMainNav.prototype.magicifyUlElems = function () {
		var _ = this;
		$('li', _.$element).has('ul').each(function () {

			var $link = $("> a", this),
			$backLink = '<i class="acr-icon icon-arrow-skinny-left back-btn mobile-nav-only"></i>',
			$mobileNext = '<i class="acr-icon next-nav-level icon-chevron2-right mobile-nav-only"></i>',
			$anchor = '<a href="' + $link.attr('href') + '" class="nav-click-thru" >' + $link.text() + '</a>';
			$(this).append($mobileNext);

			!$(this).hasClass('has-children') && $(this).addClass('has-children');

			$(">ul", this).prepend('<li><h3>' + $backLink + $anchor + '</h3></li>');
		});

		$('> ul > li', _.param.mainNavHolder).has('ul').each(function () {
			$(this).find('>ul').addClass('main-nav-l2')
			.wrapAll('<div class="main-nav-mega"><div class="content"></div></div>')
		});

		return _;
	};

	ACRMainNav.prototype.desktopClicking = function () {
		"use strict";
		var _ = this;
		$('ul', _.$element).on('click', '.has-children > a', function (event) {

			if ($(window).width() < _.param.mobileWidth) return;

			var $thisLi = $(this).parent('li');

			$thisLi
			.toggleClass('active')
			.siblings('li').removeClass('active');

			if (!$thisLi.find('.on-page').length) {
				$thisLi
				.find('li').removeClass('active');
			}

			_.desktopMegaMenuResize(this);
			if ($thisLi.hasClass('active')) {

				event.preventDefault();
			}
			event.stopPropagation();

			_.desktopMenuOpened = true;
		});
	};

	ACRMainNav.prototype.highlightPath = function () {
		"use strict";
		var _ = this,
		lpath = location.pathname.slice(1).split("/"),
		lpathDepth = 0,
		compiledHref = "/" + lpath[lpathDepth],
		$mainNav = $('ul:first', _.$element),
		$ulAnchors = $mainNav.find('li>a');

		lpath.forEach(function (item, index) {

			for (var i = 0, l = $ulAnchors.length; i < l; i += 1) {
				var cssClasses = (index === 0 || index === lpath.length - 1) ? 'on-page' : 'on-page active';

				if ($ulAnchors.eq(i).attr('href') === compiledHref) {
					lpathDepth += 1;
					compiledHref += "/" + lpath[lpathDepth];

					$ulAnchors.eq(i).parent('li').addClass(cssClasses);
					//lets change this to the next set of immediate List Items and immdediate Anchors
					$ulAnchors = $ulAnchors.eq(i).parent('li').find('ul').eq(0).find('>li>a');

					break;
				}
			}
		});
		//resize to fit if its larger
		_.desktopMegaMenuResize($('.on-page', _.$mainNav).last());
	};

	ACRMainNav.prototype.desktopMegaMenuResize = function (elem) {
		"use strict";
		var _ = this;

		var $thisMegaMenu = $(elem).closest('.main-nav-mega');
		var $lvl2Ul = $(elem).closest('.main-nav-l2'),

		lvl2UlHeight = $lvl2Ul.outerHeight() || 0,
		thisMMHeight = $thisMegaMenu.height(),
		openedUlHeight = (function () {
			var tallest = 0;
			$lvl2Ul.find('.active > ul').each(function () {
				var outerHeight = $(this).outerHeight();
				if (outerHeight > tallest) {
					tallest = outerHeight;
				}
			});
			return tallest;
		})();

		if (openedUlHeight > lvl2UlHeight && lvl2UlHeight !== 0) {
			$thisMegaMenu
			.animate({ minHeight: openedUlHeight }, 250);
		} else {
			$thisMegaMenu
			.animate({ minHeight: openedUlHeight }, 500);
		}

	};

	ACRMainNav.prototype.hoverDelay = function () {
		var _ = this;
		$('ul', _.$element).on('mouseenter mouseleave doNavHovers', 'li', function (event) {
			if ($(window).width() > _.param.mobileWidth) {

				$('body').addClass(_.param.navHoveredBodyClass);

				clearTimeout(_.stayHover);

				if (event.type === 'mouseleave') {

					_.stayHover = setTimeout(function () {
						_.$element.find('li').removeClass('hover ');
						$('body').removeClass(_.param.navHoveredBodyClass);
						_.param.afterHovered();

					}, _.param.delay);

				}
			}
		});
		return _;
	};

	ACRMainNav.prototype.resizeUpdate = function () {
		"use strict";
		var _ = this;
		$(window).on('resize', function (event) {
			clearTimeout(_.resizeDelay);
			_.resizeDelay = setTimeout(function () {
				var winWidth = $(window).width(),
				didntActuallyResize = (_.windowWidth === winWidth);
				_.windowWidth = winWidth;

				if (didntActuallyResize) {
					if (event.type === 'resize') return;
				}

				if (_.windowWidth <= _.param.mobileWidth) {
					_.closeDesktopView();
				} else {
					//resize to fit if its larger
					_.desktopMegaMenuResize($('.on-page', _.$mainNav).last());
				}

			}, 100);
		});
	};

	ACRMainNav.prototype.closeDesktopView = function () {
		"use strict";
		var _ = this;
		_.$element.find('.main-nav-mega').css({ minHeight: '' });
		_.$element.find('.active').removeClass('active');

		_.desktopMenuOpened = false;
	};

	ACRMainNav.prototype.level1InitialDelay = function () {
		var _ = this;
		_.$element.on('mouseenter mouseleave', function (event) {

			var $this = $(this);

			clearTimeout(_.level1StartDelay);

			if (event.type === "mouseenter") {

				_.level1StartDelay = setTimeout(function () {
					$this.addClass('do-nav-hovers');
					$('ul', _.$element).find('li:hover').trigger('doNavHovers');
				}, _.param.lvl1Delay);

			} else {
				_.stayHover = setTimeout(function () {
					$this.removeClass('do-nav-hovers');
					$('body').removeClass(_.param.navHoveredBodyClass);
					_.param.afterHovered();
				}, _.param.delay);
			}
		});
		return _;
	};

	ACRMainNav.prototype.navOnSticky = function () {
		var _ = this;
		var navOnStickyTimer,
		scrollTopTimer,
		scrollTop = 0,
		mouseoverTimes = 0;

		//yes this needs ot be mouseover not mouseenter event
		//it won't work if its not!
		_.$element.on('mouseover', function () {
			clearTimeout(navOnStickyTimer);
			if (headerIsSticky && _.desktopMenuOpened) {

				if (mouseoverTimes < 2) {
					mouseoverTimes++;
					scrollTop = $(window).scrollTop();
					$('#site-header').css({ position: 'absolute', top: scrollTop });
				}
			}

		});

		_.$element.on('mouseleave', function () {
			clearTimeout(navOnStickyTimer);
			navOnStickyTimer = setTimeout(function () {
				$('#site-header').css({ position: '', top: '' });
				mouseoverTimes = 0;
			}, _.param.delay);

		});

		$(window).on('scroll', function () {
			if ($('body').hasClass('desktop-nav-hovered')) {
				var scrolledTop = $(window).scrollTop();
				if (scrolledTop < scrollTop) {
					scrollTop = scrolledTop;
					$('#site-header').css({ top: scrollTop });
				}
			}
		});
	};

	ACRMainNav.prototype.mobileMenuToggle = function () {
		var _ = this;

		if (_.mobileMenuOpened) {
			_.$element.parent()
			.find('.menu-opened')
			.removeClass('menu-opened')
			.find("[style]").css('display', '');

			$(_.param.outerElement).removeClass('menu-opened');

			$('li', _.$element)
			.removeClass('hide-nav-elem active-parent show-nav-elem');

			_.mobileMenuOpened = false;
		} else {
			$(_.param.element).addClass('menu-opened');
			$(_.param.outerElement).addClass('menu-opened');

			_.mobileMenuOpened = true;
		}
	};

	ACRMainNav.prototype.addAdditionalMobileLinks = function () {
		"use strict";
		var _ = this;

		//copy from the utility nav.. to then copy to the mobile
		$('#m-utility-bottom').append($('.top-utility-nav').html());
		$('#m-utility-top').append($('.action-utility-nav').html());

		$('> ul', _.param.mainNavHolder)
		.append('<li id="m-utility-nav-holder" class="mobile-nav-only" >' + $('#additional-mobile-nav').html() + '</li>');

		$('#additional-mobile-nav').remove();
	};

	ACRMainNav.prototype.mobileNavClicking = function () {
		"use strict";
		var _ = this;
		$(_.param.mobileButton).on('click', function (event) {
			_.mobileMenuToggle();
			event.stopPropagation();
		});

		_.$element.on('click', '.has-children .next-nav-level', function (event) {
			//exit if were not in mobile
			if ($(window).width() > _.param.mobileWidth) return;

			var $thisLi = $(this).closest('.has-children');

			$thisLi.addClass('show-nav-elem active-parent')
			.siblings('li').addClass('hide-nav-elem');

			//give it some transitioning tlc
			$thisLi.find(">ul").css({ 'opacity': '0' })
			.animate({ 'opacity': '1' }, 600);

			event.stopPropagation();
		})
		.on('click', '.has-children .back-btn', function (event) {

			var $activeParent = $(this).closest('.active-parent');

			$activeParent.removeClass('active-parent show-nav-elem')
			.siblings().removeClass('hide-nav-elem')
			.removeClass('show-nav-elem');

			event.stopPropagation();
		});

	};

	ACRMainNav.prototype.doOutsideClick = function () {
		"use strict";
		var _ = this;

		iosOutsideClickSupport.add();

		$('body')[0].addEventListener('click', function (event) {

			if (_.mobileMenuOpened) {

				var menuClicked = (_.$element.find(event.target).length > 0);
				//if the menu item is not clicked and its opened
				//the menu button shouldn't register because propogation is prevented to the body
				if (!menuClicked) {
					_.mobileMenuToggle();
				}
			}
			_.closeDesktopView();
		});

	};

	$.fn.acrDesktopNav = function () {
		var _ = this,
		opt = arguments[0];

		for (var i = 0, l = _.length; i < l; i++) {
			_[i].acrDesktopNav = new ACRMainNav(_[i], opt);
		}
		return _;
	};
	$.fn.acrDesktopNav.version = VERSION;
}(jQuery);
