! function ($) {
    var $sideNavUl = $(".side-nav-inner").find("> ul > li");
    if ($sideNavUl.each(function () {
        $(this).find("> ul").length && $(this).append('<i class="acr-icon icon-arrow-right" />')
    }), getCookie("sideNavOpenLi")) {
        var indexLi = getCookie("sideNavOpenLi");
        $sideNavUl.eq(indexLi).addClass("nav-opened")
    }
    $(".side-nav").addClass("side-nav-transition").on("click", ".acr-icon", function () {
        $(this).parent("li").toggleClass("nav-opened");
        var $thisLi = $(this).parent("li");
        $(this).parent("li").hasClass("nav-opened") ? ($thisLi.css({
            "min-height": $thisLi.height() + "px"
        }), setCookie("sideNavOpenLi", $thisLi.index())) : ($thisLi.css({
            "min-height": "0px"
        }), deleteCookie("sideNavOpenLi"))
    }), $(".profile-toggle-side-nav").click(function () {
        var $nav = $(".side-nav-inner");
        $(this).toggleClass("nav-opened"), $nav.find("> ul").slideToggle(800, function () {
            $nav.toggleClass("side-nav-open").find("> ul").css("display", "")
        })
    }), $(".print-btn").click(function () {
        window.print()
    })
}(jQuery),
    function ($) {
        var pgName = location.pathname.slice(location.pathname.lastIndexOf("/") + 1);
        $("ul", ".side-nav").find("a").each(function () {
            var theHref = $(this).attr("href").replace("/", "");
            pgName === theHref && $(this).parent("li").addClass("selected")
        })
    }(jQuery);