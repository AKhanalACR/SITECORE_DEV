$(function () {
    addStatesToForm('$("#State")');
});

$("#Country").parent().find(".select-options li").click(function (e) {

    var checkedCountry = $(this),
        stateSelect = $("#State"),
        provinceSelect = $("#Province");

    if (checkedCountry.attr("rel") == "Canada") {

        addProvincesToForm(provinceSelect);
        //removeStateOrProvincesIfNeed(stateSelect);
        //var selectedProvince = @Html.Raw(Json.Encode(Model.GroupPledge.Province));
        //markItemAsSelected(provinceSelect,selectedProvince);

    } else if (checkedCountry.attr("rel") == "United States") {

        addStatesToForm(stateSelect);
        //removeStateOrProvincesIfNeed(provinceSelect);
        //var selectedState = @Html.Raw(Json.Encode(Model.GroupPledge.State));
        //markItemAsSelected($(stateSelect),selectedState);

    } else {

        //removeStateOrProvincesIfNeed(stateSelect);
        //removeStateOrProvincesIfNeed(provinceSelect);

        hideStatesAndProvinces();
    }
});

function markItemAsSelected(select, selectedItemValue) {

    if (selectedItemValue) {

        select.find("option[value='" + selectedItemValue + "']").prop("selected", true);
    }
}

function addProvincesToForm(provinceSelect) {

    getItemsList("ImagingFacilities/GetProvinces", provinceSelect);

    $("#statesSection").hide();
    $("#provincesSection").show();
}

function removeStateOrProvincesIfNeed(select) {

    var items = select.find("option");

    if (items.length > 0) {
        var parent = select.parent();
        items.remove();
        parent.find("ul.select-options li").remove();
    }
}

function addStatesToForm(stateSelect) {

    getItemsList("ImagingFacilities/GetStates", stateSelect);
    $("#state option").attr("selected", false);
    $("#provincesSection").hide();
    $("#statesSection").show();
}

function hideStatesAndProvinces() {

    $("#state option").attr("selected", false);
    $("#province option").attr("selected", false);
    $("#provincesSection").hide();
    $("#statesSection").hide();
}

function getItemsList(ajaxUrl, select) {
    if ($("#province option").length == 0) {
        $.ajax({
            url: ajaxUrl,
            dataType: "json",
            async: false,
            type: "POST",
            success: function (result) {
                initiallizeItemsList(result.items, select);
            }
        });
    }
}

function initiallizeItemsList(itemsFromJson, select) {

    var ulSelectOptions = select.parent().find(".select-options");

    $(itemsFromJson).each(function () {
        var item = $(this),
            optionItem = $("<option />"),
            liItem = $("<li />");

        optionItem.val(item[0].Value);
        optionItem.text(item[0].Text);
        select.append(optionItem);

        liItem.text(item[0].Text);
        liItem.attr("rel", item[0].Value);
        ulSelectOptions.append(liItem);
    });

    var defaultOption = ulSelectOptions.children().first().text(),
        divSelectStyled = select.parent().find(".select-styled");

    divSelectStyled.text(defaultOption);


    ulSelectOptions.find("li").click(function () {
        var selectedLi = $(this);
        divSelectStyled.text(selectedLi.text());
        select.val(selectedLi.attr("rel"));
    });
}