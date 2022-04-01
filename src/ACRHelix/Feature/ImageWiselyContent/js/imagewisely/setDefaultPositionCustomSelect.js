$(function () {

    $("div.select select.select-hidden").each(function () {

        var selectId = $(this).attr("id");
        setDefaultPositionForCustomSelect($("#" + selectId));

    });

    function setDefaultPositionForCustomSelect(select) {

        var parentSelectDiv = select.parent();
        selectedItem = select.find("option:selected").val(),
        selectOptionsList = parentSelectDiv.find(".select-options");

        if (!selectedItem) {
            return;
        }

        parentSelectDiv.find(".select-options").find("li[rel='" + selectedItem + "']").click();

        selectOptionsList.show();
        var topPositionOfLi = selectOptionsList.find("li[rel='" + selectedItem + "']").position().top;
        selectOptionsList.scrollTop(topPositionOfLi - selectOptionsList.height() / 2);
        selectOptionsList.hide();
    }
});