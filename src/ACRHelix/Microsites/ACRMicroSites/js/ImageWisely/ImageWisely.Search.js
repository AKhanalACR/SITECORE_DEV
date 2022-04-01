//*****************************************************
// ImageWisely Search
// Author: Addis 
// Date: 4 / 27 / 2017
//*****************************************************

ImageWisely = [];
if (ImageWisely == null) {
    ImageWisely = [];
}

if (ImageWisely.Search == null) {
    ImageWisely.Search = [];
}

$(document).ready(function () {
    ImageWisely.Search.InitializeSearchBox();
});

ImageWisely.Search.InitializeSearchBox = function () {
    $('#searchbox').on("keydown", function (e) {
        var keycode = (e.keyCode ? e.keyCode : e.which);
        if (keycode == '13') {
            if ($(e.target).prop("type") === "textarea") {
                return;
            }
            e.preventDefault();
            e.stopPropagation();
            $('#searchlink').click();
            return false;
        }
        return;
    });
    $('#searchlink').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        window.location.href = '/search' + '?q=' + $('#searchbox')[0].value;
    });
}