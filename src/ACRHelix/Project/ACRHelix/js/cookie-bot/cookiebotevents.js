
function CookiebotCallback_OnDialogInit() {
    cookieBotMarketingDisplayBlock();
}

function cookieBotMarketingDisplayBlock() {
    if (!Cookiebot.consent.marketing) {
        $(".cookieconsent-optout-marketing").addClass('cookiebot-block');
    }
}

function CookiebotCallback_OnDecline() {
    cookieBotMarketingDisplayBlock();
}

window.addEventListener('CookiebotOnAccept', function (e) {
    if (Cookiebot.consent.marketing) {
        $(".cookieconsent-optout-marketing").removeClass('cookiebot-block');
    }
}, false);