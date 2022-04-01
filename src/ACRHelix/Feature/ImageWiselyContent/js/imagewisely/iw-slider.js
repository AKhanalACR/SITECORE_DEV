var homeSlideContentHtml = [];
(function () {
    jQuery('#home-slider').find('.slick-slide').each(function () {
        homeSlideContentHtml.push(jQuery(this).find('.home-slide-text-area').html());
    });

    jQuery('.slide-transition-content').html(homeSlideContentHtml[0]);
})();

jQuery('#home-slider').slick({
    dots: true,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 6500,
    speed: 700,
    appendArrows: '#home-slider-nav',
    appendDots: '#home-slider-dots'
}).on('beforeChange', function (event, slick, currentSlide, nextSlide) {

    jQuery('.home-slide-content').addClass('slide-content-hide');

}).on('afterChange', function (event, slick, currentSlide, nextSlide) {

    jQuery('.slide-transition-content').html(homeSlideContentHtml[currentSlide]);
    jQuery('.home-slide-content').removeClass('slide-content-hide');

});