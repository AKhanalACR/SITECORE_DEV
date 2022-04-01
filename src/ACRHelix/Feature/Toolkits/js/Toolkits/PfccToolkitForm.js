jQuery(function ($) {
    //$('.pfcc-state-ddl').dropdown();

    //state value
    //$(document).on('click', '.pfcc-state-ddl .menu .item', function () {
    //    var state = $(this).attr('data-value');
    //    $("select[name='ResourceFormData.State']").val(state);
    //});

    //Resource type
    $('#pfcc-fg-2 :checkbox').on('click', function (event) {
        $("#pfcc-fg-2").find('input[type="checkbox"]').each(function () {
            $(this).prop("checked", false);
        });
        $(this).prop("checked", true);
    });

    //form field validation
    $(document).on('click', '#pfcc-submit-btn', function (event) {
        var isValid = true;
        $('.pfcc-new-form').find('.required').each(function () {

            if ($('.required').val() == undefined || $('.required').val() == '') {
                $(this).addClass('input-validation-error');
                $(this).siblings('.field-validation-valid').removeClass('field-validation-valid').addClass('field-validation-error');

                isValid = false;
            } else {
                $(this).removeClass('input-validation-error');
                $(this).siblings('.field-validation-error').removeClass('field-validation-error').addClass('field-validation-valid');
            }
        });

        //email
        var email = $("input[name='ResourceFormData.Email']").val();
        var validEmail = validateEmail(email);

        //phone number 
        //var phone = $("input[name='ResourceFormData.Phone']").val();
        //$("input[name='ResourceFormData.Phone']").val(phone.replace(/[^\d]/g, ''));

        //check box validation
        var checkListValidation = validateCheckboxList();

        if (!isValid || !validEmail || !checkListValidation)
            event.preventDefault();
    });
});

function validateCheckboxList() {
    isValid = true;

    //practice setting
    var ps = [];
    $("#pfcc-fg-0").find("input:checked").each(function (i, ob) {
        ps.push($(ob).val());
    });

    if (ps.length === 0) {
        $('#pfcc-fg-0').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        //ps = ps[0];
        ps = ps.toString();
        $("input[name='ResourceFormData.PracticeSetting']").val(ps);
        $('#pfcc-fg-0').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    //content type
    var cont = [];
    $("#pfcc-fg-1").find("input:checked").each(function (i, ob) {
        cont.push($(ob).val());
    });
    cont = cont.toString();
    $("input[name='ResourceFormData.ContentType']").val(cont);

    if (cont.length === 0) {
        $('#pfcc-fg-1').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        $('#pfcc-fg-1').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    //resource type
    var rt = [];
    $("#pfcc-fg-2").find("input:checked").each(function (i, ob) {
        rt.push($(ob).val());
    });
    rt = rt.toString();
    $("input[name='ResourceFormData.ResourceType']").val(rt);

    if (rt.length === 0) {
        $('#pfcc-fg-2').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        $('#pfcc-fg-2').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    return isValid ? true : false;
}

function validateEmail(inputtxt) {
    var pattern = /^\w+([-+.'][^\s]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    return pattern.test(inputtxt);
}

function fileValidation(fileInput) {
    var filePath = fileInput.value;

    // Allowing file type 
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.pdf|\.docx|\.doc|\.pptm)$/i;
    if (!allowedExtensions.exec(filePath.toLowerCase())) {
        alert('Invalid file type');
        fileInput.value = '';
        return false;
    }
}
