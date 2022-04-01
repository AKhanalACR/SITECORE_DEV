function msieversion() {

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))  // If Internet Explorer, return version number
    {
        //alert(parseInt(ua.substring(msie + 5, ua.indexOf(".", msie))));
        alert('Internet Explorer is not supported. To improve your virtual experience, please use a modern browser such as Chrome, Firefox, Safari, or Microsoft Edge.');
    }
    else  // If another browser, return 0
    {
        //alert('otherbrowser');
    }

    return false;
}
msieversion();