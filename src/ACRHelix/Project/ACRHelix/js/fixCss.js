
jQuery(function ($) {
    //fix breadcrumb margin when header is present
    var breadCrumb = $("#breadcrumbs");
    var next = breadCrumb.next();
    if (next.hasClass('chapter-header') || next.hasClass('page-hero-image')) {
        breadCrumb.css('margin-bottom', '0px');
    }//end breadcrumb

    //fix double indented sections
    $('.indented-section').each(function () {
        var indent = $(this).find('.indented-section')
        if (indent.length > 0) {
            if (indent.attr('style') == 'padding-right:0px') {
                $(this).css('padding-right', '0px');
            }
            $(this).find('.indented-section').removeClass('indented-section');           
        }
    });

    //$('.indented-section').find('.indented-section').removeClass('indented-section');
    //$('.section-spacing').find('.section-spacing').removeClass('section-spacing');
    $('.no-section-spacing').find('.section-spacing').removeClass('section-spacing');


    $('a').each(function () {
        var btn = $(this).find('.button');
        if (btn.length > 0) {
            btn.removeClass('button');
            $(this).addClass('button');
        }
    });

    $('.button').each(function () {
        var btn = $(this).find('a');
        if (btn.length > 0) {
            btn.addClass('button');
            $(this).removeClass('button');
        }
    });

    var headerShare = $('h1').first().next('.header-share-opts');
    if (headerShare.length > 0) {
        $('h1').first().addClass('margin-bottom-0');
    }

});