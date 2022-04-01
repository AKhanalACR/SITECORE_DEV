jQuery(function ($) {
    loadScript("//platform-api.sharethis.com/js/sharethis.js#property=5ba3b2f17e79f50011adb6d4&product=inline-share-buttons' async='async'", loadScriptLoadBack)
});

function loadScript(url, callback) {
    var script = document.createElement("script")
    script.type = "text/javascript";

    if (script.readyState) {  //IE
        script.onreadystatechange = function () {
            if (script.readyState == "loaded" ||
                    script.readyState == "complete") {
                script.onreadystatechange = null;
                callback();
            }
        };
    } else {  //Others
        script.onload = function () {
            callback();
        };
    }

    script.src = url
    document.getElementsByTagName("head")[0].appendChild(script);
}

function loadScriptLoadBack() {
    console.log('failed to load ShareThis script');
}