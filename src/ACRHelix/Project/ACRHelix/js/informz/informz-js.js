radiosCheckboxes();
tooltips();
jQuery("select").dropdown();
displayStatesForCountry();


if (jQuery('#registerInformzTitle').length > 0) {
    jQuery('#RegistrationData_Email').val(jQuery('#Email').val());
    jQuery('#Email').parent().hide();
}

jQuery("#informzSubmitBtn").click(function () {
    jQuery("#HiddenCaptcha").val("informz-valid");

    if (jQuery('#Checkboxes_0__Checked').length > 0) {
        jQuery('#FormSubmitted').val('OptIn');
    }
});

jQuery('#RegistrationData_Country').change(function () {
    displayStatesForCountry();
});

function displayStatesForCountry() {
    var selectedCountry = jQuery('#RegistrationData_Country').val();
    jQuery('#RegistrationData_State').parent().find('.item').each(function () {
        if (jQuery(this).attr('data-value').indexOf('|' + selectedCountry) < 0) {
            jQuery(this).hide();
        } else {
            jQuery(this).show();
        }
    });
}

jQuery(document).ready(function () {
    if (jQuery('#Email').parent().is(':visible')) {
        jQuery('#informzFormContainer').find('form').validate({
            rules: {
                Email: {
                    required: true,
                    email: true
                }
            }
        })
    }

    if (jQuery('#RegistrationData_FirstName').length > 0) {
        //alert('setting registration validators!');
        jQuery('#informzFormContainer').find('form').validate({
            rules: {
                "RegistrationData.FirstName": {
                    required: true
                },
                "RegistrationData.LastName": {
                    required: true
                },
                "RegistrationData.Email": {
                    required: true,
                    email: true
                },
               "RegistrationData.Address": {
                    required: true
                },
                "RegistrationData.City": {
                    required: true
                },
                "RegistrationData.Zip": {
                    required: true,
                    minlength: 5,
                    digits: true
                }
            }
        })

    }
});