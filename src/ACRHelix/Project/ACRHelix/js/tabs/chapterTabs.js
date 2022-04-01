
//	chapter-area
jQuery('.chapter-area').easyTabs({
  callback: function (thisTabID, tabId) {
      jQuery('.event-tile-area').each(function () {
        jQuery(this).hasClass('slick-initialized') && jQuery(this).slick('unslick');
      });
      //resourceSliderTabs(tabId);  
    jQuery(window).trigger('resize');
  }
});
//jQuery('.tabs').scrollInView({ childItem: 'li', slideWrapper: 'ul', scrollItemAmount: 1 });
squareItUp('.square-tile-area', { squareItem: '.square-tile', useOuterWidth: true, stopWidth: 960, timerDelay: 120 });
//resourceSlider('.event-tile-area');
//jQuery('select').dropdown();

//similar to main.js resource slider, but only finds slider in current tab id
function resourceSliderTabs(dataTabId) {

    if ("undefined" == typeof jQuery.fn.slick)
      return void console.log("your gonna need to add in the slick.js for this to work!");
    var tab = jQuery("[data-tab-id='" + dataTabId + "']");
    var elem = tab.find('.event-tile-area');
    var $customPager = $(elem).next(".resources-slider-nav")
      , $inputPageLoc = $customPager.find(".slick-custom-pager")
      , slideTotal = $(elem).find(".slick-slide").length;
    slideTotal > 1 && $inputPageLoc.prepend('<input type="text" class="slide-num-input" data-prev-val="1" value="1"> of ' + slideTotal);
    var $slideInputNum = $customPager.find(".slide-num-input");
    jQuery(elem).slick({
      dots: !0,
      infinite: !0,
      autoplaySpeed: 6500,
      speed: 700,
      appendArrows: $customPager,
      appendDots: $inputPageLoc
    }).on("beforeChange", function (event, slick, currentSlide, nextSlide) {
      $slideInputNum.data("prev-val", $slideInputNum.val()).val(nextSlide + 1)
    }),
    squareItUp(elem, {
      squareItem: ".event-tile",
      useOuterWidth: !0,
      stopWidth: 960,
      timerDelay: 120
    }),
    $customPager.on("change", ".slide-num-input", function () {
      var val = this.value
        , valAsInt = Number(val);
      /\D/g.test(val) ? this.value = jQuery(this).data("prev-val") : valAsInt > slideTotal || valAsInt < 1 ? this.value = jQuery(this).data("prev-val") : ($inputPageLoc.find("button").eq(valAsInt - 1).trigger("click"),
      jQuery(this).data("prev-val", val))
    })  
}