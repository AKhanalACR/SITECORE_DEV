jQuery(function ($) {
    $('.pfcc-state-ddl').dropdown();
    $('.pfcc-reviewers-ddl').dropdown();
    $('.pfcc-status-ddl').dropdown();

    //state value
    $(document).on('click', '.pfcc-state-ddl .menu .item', function () {
        var state = $(this).attr('data-value');
        $("select[name='ReviewFormData.State']").val(state);
    });

    //Practice setting - Audience
    var pracSet = $("input[name='ReviewFormData.PracticeSetting']").val().split(',');
    $.each(pracSet, function (index, value) {
        $("#pfcc-fg-0").find('input[type="checkbox"]').each(function (i, obj) {
            if (value == $(obj).val())
                $(this).prop("checked", true);
        });
    });

    //Content type - core knowledge 
    var contype = $("input[name='ReviewFormData.ContentType']").val().split(',');
    $.each(contype, function (index, value) {
        $("#pfcc-fg-1").find('input[type="checkbox"]').each(function (i, obj) {
            if (value == $(obj).val())
                $(this).prop("checked", true);
        });
    });

    //Resource type - anatomy subcategory type
    var rectype = $("input[name='ReviewFormData.ResourceType']").val().split(',');
    $.each(rectype, function (index, value) {
        $("#pfcc-fg-2").find('input[type="checkbox"]').each(function (i, obj) {
            if (value == $(obj).val())
                $(this).prop("checked", true);
        });
    });
	
	
    //resource format
    var rfm = '';
    $('#pfcc-fg-3 :checkbox').on('click', function (event) {
        $("#pfcc-fg-3").find('input[type="checkbox"]').each(function () {
            $(this).prop("checked", false);
        });
        rfm = $(this).val();
        $(this).prop("checked", true);
        $("input[name='ReviewFormData.ResourceFormat']").val(rfm);
    });

    var resFormat = $("input[name='ReviewFormData.ResourceFormat']").val().split(',');
    $.each(resFormat, function (index, value) {
        $("#pfcc-fg-3").find('input[type="checkbox"]').each(function (i, obj) {
            if (value == $(obj).val())
                $(this).prop("checked", true);
        });
    });


    //Reviwer value
    $(document).on('click', '.pfcc-reviewers-ddl .menu .item', function () {
        var rev = $(this).attr('data-value');
        $("select[name='Reviewer']").val(rev);
    });

    //Status value
    $(document).on('click', '.pfcc-status-ddl .menu .item', function () {
        var st = $(this).attr('data-value');
        $("select[name='Status']").val(st);
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
        var email = $("input[name='ReviewFormData.Email']").val();
        var validEmail = validateEmail(email);

        //phone number 
        var phone = $("input[name='ReviewFormData.Phone']").val();
        $("input[name='ReviewFormData.Phone']").val(phone.replace(/[^\d]/g, ''));

        //check box validation
        var checkListValidation = validateCheckboxList();

        if (!isValid || !validEmail || !checkListValidation)
            event.preventDefault();
    });
});

function validateCheckboxList() {
    isValid = true;

    //practice setting - Audience
    var ps = [];
    $("#pfcc-fg-0").find("input:checked").each(function (i, ob) {
        ps.push($(ob).val());
    });
    ps = ps.toString();
    $("input[name='ReviewFormData.PracticeSetting']").val(ps);

    if (ps.length === 0) {
        $('#pfcc-fg-0').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        $('#pfcc-fg-0').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    //content type - core knowledge
    var cont = [];
    $("#pfcc-fg-1").find("input:checked").each(function (i, ob) {
        cont.push($(ob).val());
    });
    cont = cont.toString();
    $("input[name='ReviewFormData.ContentType']").val(cont);

    if (cont.length === 0) {
        $('#pfcc-fg-1').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        $('#pfcc-fg-1').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    //resource type - anatomy subcategory type
    var rt = [];
    $("#pfcc-fg-2").find("input:checked").each(function (i, ob) {
        rt.push($(ob).val());
    });
    rt = rt.toString();
    $("input[name='ReviewFormData.ResourceType']").val(rt);

    //if (rt.length === 0) {
        //$('#pfcc-fg-2').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        //isValid = false;
    //} else {
        //$('#pfcc-fg-2').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    //}

    return isValid ? true : false;
}

function validateEmail(inputtxt) {
    var pattern = /^\w+([-+.'][^\s]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    return pattern.test(inputtxt);
}

function fileValidation(fileInput) {
    var filePath = fileInput.value;

    // Allowing file type 
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.pdf|\.docx|\.doc)$/i;
    if (!allowedExtensions.exec(filePath.toLowerCase())) {
        alert('Invalid file type');
        fileInput.value = '';
        return false;
    }
}

