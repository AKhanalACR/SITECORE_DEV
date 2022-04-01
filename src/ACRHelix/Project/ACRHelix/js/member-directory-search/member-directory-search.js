jQuery(document).ready(function () {
    jQuery('select').dropdown();
    displayStatesForCountry();
    jQuery('.member-directory-table').find('table').tablesorter();

    var table = jQuery('.has-acr-table');
    if (table.length > 0) {
        jQuery(window).scrollTop(jQuery('.has-acr-table').offset().top - 200)
    }
})




jQuery('#Country').change(function () {
    displayStatesForCountry();
});

function displayStatesForCountry() {
    var selectedCountry = jQuery('#Country').val();
    jQuery('#State').parent().find('.item').each(function () {
        if (jQuery(this).attr('data-value').indexOf('|' + selectedCountry) < 0) {
            jQuery(this).hide();
        } else {
            jQuery(this).show();
        }
    });
}

jQuery('.member-info').click(function () {

    jQuery(this).next().dialog();
    jQuery('.ui-dialog').css('border', 'solid');
    jQuery('.ui-dialog').css('padding', '10px');
    jQuery('.ui-dialog').css('background-color', 'white');
    jQuery('.ui-dialog').css('z-index', '99');
    jQuery('.ui-dialog').find('button').css('float', 'right');

    return false;
});


