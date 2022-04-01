jQuery(function () {
  var homeSlideContentHtml = [];
  //load the text in the first time... init event on slick doesnt' seem to work for me :-(
  //and don't need to wait anyway
  (function () {
    jQuery('.carousel-slider').find('.slick-slide').each(function () {
      homeSlideContentHtml.push(jQuery(this).find('.carousel-slide-text-area').html());
    });

    jQuery('.slide-transition-content').html(homeSlideContentHtml[0]);
  })();

  jQuery('.carousel-slider').slick({
    dots: true,
    infinite: true,
    autoplaySpeed: 6500,
    speed: 700,
    appendArrows: '.carousel-slider-nav',
    appendDots: '.carousel-slider-dots'
  }).on('beforeChange', function (event, slick, currentSlide, nextSlide) {

    jQuery('.carousel-slide-content').addClass('slide-content-hide');

  }).on('afterChange', function (event, slick, currentSlide, nextSlide) {

    jQuery('.slide-transition-content').html(homeSlideContentHtml[currentSlide]);
    jQuery('.carousel-slide-content').removeClass('slide-content-hide');

  });
});