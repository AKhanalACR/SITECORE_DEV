
    jQuery(function ($) {
        $('<li class="link-divider"><span>|</span></li>').insertAfter($(".dsi-top-utility-nav").find("li").first());
        $(".fluid-tiles").find(".xl-col-4").removeClass("col-6");
        $(".img-max-400").removeClass("lg-col-5").removeClass('img-max-400').removeClass("xl-text-right");
        $(".text-content").css('font-size', 'inherit');

        dsiMailTo();
    });

function dsiMailTo() {

    var mailTo = jQuery(".dsi-mail-to-use-case-add-subject");
    if (mailTo.length > 0) {
        mailTo.each(function () {
            var href = jQuery(this).attr('href');
            var h1 = jQuery('h1').first();
            var subj = 'DSI use case';
            if (h1.length > 0) {
                var subjt = jQuery('h1').first().text().trim();
                if (subjt.length > 0) {
                    subj = subjt;
                }
            }
            href += '?subject=' + encodeURIComponent('Feedback on ' + subj);
            jQuery(this).attr('href', href);
        });

    }

}