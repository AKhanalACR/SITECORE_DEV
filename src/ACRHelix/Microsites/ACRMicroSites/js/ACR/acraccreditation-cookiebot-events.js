
function CookiebotCallback_OnDialogInit() {
    cookieBotMarketingDisplayBlock();
}

function cookieBotMarketingDisplayBlock() {
    if (!Cookiebot.consent.marketing) {
        jQuery(".cookieconsent-optout-marketing").addClass('cookiebot-block');
        jQuery(".video-downloads").find('.arrow-link').hide();
        jQuery(".cookiebot-video").find('a').removeClass('arrow-link-first');
        jQuery(".video-downloads-info").hide();
    }
}

function CookiebotCallback_OnDecline() {
    cookieBotMarketingDisplayBlock();
}

window.addEventListener('CookiebotOnAccept', function (e) {
    if (Cookiebot.consent.marketing) {
        jQuery(".cookieconsent-optout-marketing").removeClass('cookiebot-block');
        jQuery(".video-downloads").find('.arrow-link').show();
        jQuery(".video-downloads-info").show();
    }
}, false);