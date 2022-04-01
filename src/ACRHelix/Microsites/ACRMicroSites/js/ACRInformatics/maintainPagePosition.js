
var cookieName = "page_scroll";
jQuery.each(Cookies.get(), function (name, value) {
    if (/^page_scroll/.test(name)) {
        if (name != 'page_scroll' + window.location.pathname)
            Cookies.remove(name);
    }
});

jQuery(function($) {
  loadScroll();
  $(window).unload(function () {
      saveScroll();
  });
});

function setCookie(name, value){
    Cookies.set(name, value, { expires: 7 });
}

function getCookie(name) {
    return Cookies.get(name);
}

function saveScroll() { 
    var x = jQuery(window).scrollLeft();//(document.pageXOffset ? document.pageXOffset : document.body.scrollLeft)
    var y = jQuery(window).scrollTop();//(document.pageYOffset ? document.pageYOffset : document.body.scrollTop)
    Data = x + "_" + y
    setCookie(cookieName + window.location.pathname, Data)//, expdate)
}

function loadScroll() { // added function
    inf = getCookie(cookieName + window.location.pathname)
    if (!inf) { return }
    var ar = inf.split("_");
    if (ar.length == 2) {
        window.scrollTo(parseInt(ar[0]), parseInt(ar[1]))
    }
}