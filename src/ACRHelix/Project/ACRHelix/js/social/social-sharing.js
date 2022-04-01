jQuery(function ($) {

    $('.share-link').find('> .share-drawer')
        .css('display', '')
        .wrapInner('<div class="share-content-inner" />');

    $(window).on('load', function () {

    
        $('main').on('click', this, function () {

            $('.share-link.share-enabled')
                .removeClass('share-enabled')
                .find('.share-on-edge')
                .removeClass('share-on-edge');
        })
            .on('click', '.share-link', function (e) {

                if (CookieConsent.consent.statistics) {

                    //check to see if it has been added already
                    customACRMailtoToShareThis(this);

                    $(this).addClass('share-enabled')
                        .find('.share-on-edge')
                        .removeClass('share-on-edge');

                    var $elm = $('.share-drawer', this),
                        off = $elm.offset(),
                        l = off.left + 40,
                        w = $elm.width(),
                        docW = $(window).width();

                    var isEntirelyVisible = (l + w <= docW);

                    if (!isEntirelyVisible) {
                        $elm.addClass('share-on-edge');
                    } else {
                        $elm.removeClass('share-on-edge');
                    }
                    //some odd bug in sharethis causing them to display as none
                    //this fixes that!
                    $('.st-btn').css('display', 'inline-block');

                    //pinterest btn hide for testimonials
                    if (jQuery('#myModal .modal-dialog').length) {
                        jQuery('.st-btn:eq(2)', '.share-link .share-drawer').css('display', 'none');
                        jQuery('.share-link .sharethis-inline-share-buttons').css('text-align', 'center');
                    }

                    e.preventDefault();
                    e.stopPropagation();
                } else {
                    $('.share-link').on('click', function () {
                        $(".mailToLink")[0].click();
                    });
                }
            });   
    });

    var mailTo = "mailto:email?subject={0}&body={1}";
    var title = encodeURIComponent(jQuery("title").text());
    var description = encodeURIComponent('This page on www.acr.org has been shared with you! \r\n\r\n' + jQuery("meta[name='description']").attr("content") + '\r\n\r\n' + window.location.protocol + '//' + window.location.host + window.location.pathname);
    mailTo = mailTo.replace('{0}', title).replace('{1}', description);
    jQuery('.mailToLink').attr('href', mailTo);

});

function customACRMailtoToShareThis(scope) {
    var mailToAddedAlready = ($('.share-drawer', scope).find('.acr-mailto').length > 0);
    if (!mailToAddedAlready) {
        var $shareEmailBtn = $('.st-btn:eq(3)', '.share-drawer'),
            $mailToBtn = $('.mailToLink');

        $mailToBtn
            .insertAfter($shareEmailBtn)
            .show();

        $shareEmailBtn.detach();

        $mailToBtn
            .addClass('st-btn acr-mailto')
            .css({ 'background': '#999' })
            .html($shareEmailBtn.html());

        $mailToBtn.on('click', function (e) {

            e.stopPropagation();
        });
    }
}
