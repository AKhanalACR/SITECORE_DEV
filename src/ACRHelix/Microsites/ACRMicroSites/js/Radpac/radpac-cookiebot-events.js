
function CookiebotCallback_OnDialogInit() {
    cookieBotMarketingDisplayBlock();
}

function cookieBotMarketingDisplayBlock() {
    if (!Cookiebot.consent.marketing) {
        $(".cookieconsent-optout-marketing").addClass('cookiebot-block');
        $(".video-downloads").find('.arrow-link').hide();
        $(".cookiebot-video").find('a').removeClass('arrow-link-first');
        $(".video-downloads-info").hide();
    }
}

function CookiebotCallback_OnDecline() {
    cookieBotMarketingDisplayBlock();
}

window.addEventListener('CookiebotOnAccept', function (e) {
    if (Cookiebot.consent.marketing) {
        $(".cookieconsent-optout-marketing").removeClass('cookiebot-block');
        $(".video-downloads").find('.arrow-link').show();
        $(".video-downloads-info").show();
    }
}, false);