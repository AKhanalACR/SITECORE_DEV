radiosCheckboxes();
//tooltips();

jQuery('#loginSubmitBtn').click(function () {
    jQuery('#HiddenCaptcha').val('login');
});

jQuery(document).ready(function () {
    if (jQuery('#err-msg').is(':visible')) {
        jQuery(window).scrollTop(jQuery('#breadcrumbs').offset().top);
    }
});