//*****************************************************
// RADPAC Search
// Author: Addis 
// Date: 5 / 23 / 2017
//*****************************************************

Radpac = [];
if (Radpac == null) {
    Radpac = [];
}

if (Radpac.Search == null) {
    Radpac.Search = [];
}

$(document).ready(function () {
    Radpac.Search.InitializeSearchBox();
});

Radpac.Search.InitializeSearchBox = function () {
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