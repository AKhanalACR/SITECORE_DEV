jQuery(function () {  
    tabRotatingTiles('.acr-news-slider');
    jQuery('.acr-news-slider').equalizeContent({ equalizeItem: '.news-content' });

    jQuery(document).ready(function ($) {
        $('[data-pageId]').each(function () {
            //if on home page only
            if ($(this).attr('data-pageId') == '658E9C4C194C44C7A9E5EC30D7292235') {
                $(this).on('click', '.tab-slider-link', function () {
                    window.dataLayer = window.dataLayer || [];
                    window.dataLayer.push({
                        'event': 'Homepage-Tab-Click',
                        'tabname': $(this).attr('data-tabname'),
                        'slidename': $(this).attr('data-slide'),
                        'click-url': $(this).attr('href')
                    });
                });
            }
        });
        jQuery(".acr-news-slider").show();
        jQuery(".acr-news-slider-disabled").show();
    });
});