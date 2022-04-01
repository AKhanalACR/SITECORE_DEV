function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function validatePhone(phone) {
    var re = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    return re.test(String(phone).toLowerCase());
}

function validateZip(zip) {
    var re = /^[0-9]{5}(?:-[0-9]{4})?$/;            
    return re.test(String(zip).toLowerCase());
}

jQuery(function ($) {    
    jQuery('.ctc-form-section').find('select').dropdown();
});

$(document).ready(function () {
    $('#regForm').submit(function (e) {
        var isValid = true;

        var first_name = $('#txtFName').val();
        var last_name = $('#txtLName').val();
        var email = $('#txtEmail').val();
        var center = $('#txtCenter').val();
        var address1 = $('#txtAddress1').val();
        var city = $('#txtCity').val();
        var zip_code = $('#txtZip').val();
        var phone = $('#txtPhone').val();

        $('#reqmsg_fname').text("");
        $('#reqmsg_lname').text("");
        $('#reqmsg_email').text("");
        $('#reqmsg_center').text("");
        $('#reqmsg_address1').text("");
        $('#reqmsg_city').text("");
        $('#reqmsg_zip').text("");
        $('#reqmsg_phone').text("");

        if (first_name.length < 1) {
            $('#reqmsg_fname').text("Please enter first name.");
            isValid = false;
        }
        if (last_name.length < 1) {
            $('#reqmsg_lname').text("Please enter last name.");
            isValid = false;
        }
        if (email.length < 1) {
            $('#reqmsg_email').text("Please enter email.");
            isValid = false;
        }
        if (center.length < 1) {
            $('#reqmsg_center').text("Please enter center name.");
            isValid = false;
        }        
        if (city.length < 1) {
            $('#reqmsg_city').text("Please enter city.");
            isValid = false;
        }              

        if (validateEmail(email) != true){
            $('#reqmsg_email').text("Please enter valid email address.");
            isValid = false;
        }

        if (validatePhone(phone) != true){
            $('#reqmsg_phone').text("Please enter valid phone number.");
            isValid = false;
        }

        if (validateZip(zip_code) != true) {
            $('#reqmsg_zip').text("Please enter valid zip code.");
            isValid = false;
        }

        if (isValid == false) {
            e.preventDefault();
        }
    });
});




