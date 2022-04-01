jQuery(function ($) {  
    //checkbox limit selection to one 
	//target audience
    //$('#pfcc-fg-0 :checkbox').on('click', function(event){
    //$("#pfcc-fg-0").find('input[type="checkbox"]').each(function (i, obj) {
    //if (value == $(obj).val())
    //$(this).prop("checked", true);
    //});
    //});
	
	//core knowledge type
    //$('#pfcc-fg-1 :checkbox').on('click', function(event){
    //$("#pfcc-fg-1").find('input[type="checkbox"]').each(function (i, obj) {
    //if (value == $(obj).val())
    //$(this).prop("checked", true);
    //});
    //});
		
    ////anatomy subcategory type
    //$('#pfcc-fg-2 :checkbox').on('click', function(event){
    //$("#pfcc-fg-2").find('input[type="checkbox"]').each(function (i, obj) {
    //if (value == $(obj).val())
    //$(this).prop("checked", true);
    //});
    //});
	
    //resoure type - format
	$('#pfcc-fg-3 :checkbox').on('click', function(event){
		$("#pfcc-fg-3").find('input[type="checkbox"]').each(function () {
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

        //email validation
        var email = $("input[name='MesoFormData.Email']").val();
        var validEmail = validateEmail(email);
         
        //check box validation
        var checkListValidation = validateCheckboxList();
		
		//disclaimer checkbox
		var disclaimerSigned = false; 
		if ($('#disclaimercheckbox').is(":checked")){
			disclaimerSigned = true;
		}

		//check all validation
        if (!isValid || !validEmail || !checkListValidation || !disclaimerSigned){
            event.preventDefault();
		}
    });
});

function validateCheckboxList() {
    isValid = true;

    //taget audience 
    var ps = [];
    $("#pfcc-fg-0").find("input:checked").each(function (i, ob) {
        ps.push($(ob).val());
    });
    
    if (ps.length === 0) {
        $('#pfcc-fg-0').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        ps = ps.toString(); //[0];
		$("input[name='MesoFormData.TargetAudience']").val(ps);
        $('#pfcc-fg-0').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    //Core knowledge
    var cont = [];
    $("#pfcc-fg-1").find("input:checked").each(function (i, ob) {
        cont.push($(ob).val());
    });
        
    if (cont.length === 0) {
        $('#pfcc-fg-1').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
        cont = cont.toString(); //[0];
		$("input[name='MesoFormData.CoreKnowledge']").val(cont);
        $('#pfcc-fg-1').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    }

    //Anatomy subcategory
    var rt = [];
    $("#pfcc-fg-2").find("input:checked").each(function (i, ob) {
        rt.push($(ob).val());
    });
    rt = rt.toString(); 
    $("input[name='MesoFormData.AnatomySubcategory']").val(rt);

    //if (rt.length === 0) {
        //$('#pfcc-fg-2').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        //isValid = false;
    //} else {
        //rt = rt.toString(); //[0];
		//$("input[name='MesoFormData.AnatomySubcategory']").val(rt);
        //$('#pfcc-fg-2').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
    //}
	
    //resource type - format
    var rty = [];
    $("#pfcc-fg-3").find("input:checked").each(function (i, ob) {
        rty.push($(ob).val());
    });
    
    if (rty.length === 0) {
        $('#pfcc-fg-3').siblings('p').find('span').removeClass('field-validation-valid').addClass('field-validation-error');
        isValid = false;
    } else {
		rty = rty[0];
		$("input[name='MesoFormData.ResourceType']").val(rty);
        $('#pfcc-fg-3').siblings('p').find('span').removeClass('field-validation-error').addClass('field-validation-valid');
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
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.pdf|\.docx|\.doc|\.pptm|\.apkg|\.ppsm)$/i;
    if (!allowedExtensions.exec(filePath.toLowerCase())) {
        alert('Invalid file type');
        fileInput.value = '';
        return false;
    }
}

