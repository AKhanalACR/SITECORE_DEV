var homeSlideContentHtml = [];
//load the text in the first time... init event on slick doesnt' seem to work for me :-(
//and don't need to wait anyway
(function () {
    lookForExternalUrlThenAddIcon({ outer: '#home-slider' });
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

jQuery(document).ready(function ($) {
    if (homeSlideContentHtml === undefined || homeSlideContentHtml.length == 0) {
        lookForExternalUrlThenAddIcon({ outer: '#home-slider' });
        $('#home-slider').find('.slick-slide').each(function () {
            homeSlideContentHtml.push($(this).find('.home-slide-text-area').html());
        });

        $('.slide-transition-content').html(homeSlideContentHtml[0]);
    }

    $('#home-slider-outer').on('click', '.home-carousel-click', function () {
        window.dataLayer = window.dataLayer || [];
        window.dataLayer.push({
            'event': 'home-carousel-click',
            'carousel-slide-name': $(this).attr('data-carousel-slide-name'),
            'click-url': $(this).attr('href')
        });
    });
});
