//*****************************************************
// Membership Testimonial
// Author:  
// Date: 7 / 26 / 2017
//*****************************************************

//page load
jQuery(function () {
    'use strict'
    jQuery('#spMessage').css('display', 'none');
    jQuery('#spFile').css('display', 'none');
    jQuery(".mt-catLst").find("select").dropdown();
});

//browse click event
jQuery(document).on('click', '.browse', function () {
    'use strict'
    var file = jQuery(this).parent().find('.file');
    file.trigger('click');
});

//update the file input tag
jQuery(document).on('change', '.file', function () {
    'use strict'
    if (jQuery(this).val() != '') {
        jQuery(this).parent().find('.mtFile-div').slideDown("fast");
        jQuery(this).parent().find('.input-field span').text(jQuery(this).val().replace(/C:\\fakepath\\/i, ''));
        //readFile(this);
    }
});

//reset selected file
jQuery(document).on('click', '.input-field a', function () {
    'use strict'
    jQuery(this).parent().parent().find('.input-field span').text('');
    jQuery('.mtFile-div').slideUp("fast");
    var file = jQuery(this).parent().find('.file');
    jQuery('.file').val('');
});

//assign dropdown selected value
var filter = function () {
    'use strict'
    var category = jQuery('.mt-catLst').find('.selected').attr('data-value');
    if (category != undefined) {
        jQuery('#ddlCatagory').val(category.trim());
    }
}
jQuery(document).on("click", ".mt-catLst", filter);

//form validation
jQuery(document).on('click', '#btnSave', function () {
    'use strict'
    if (jQuery('#txtYouTubeLink').val() == undefined || jQuery('#txtYouTubeLink').val() == '') {

        //tesimonial message text area
        if (jQuery('#txtTestimonialMessage').val() == undefined || jQuery('#txtTestimonialMessage').val() == '') {
            jQuery('#spMessage').css('display', 'block');
            return false
        }

        //file upload input
        if (jQuery('.file').val() == undefined || jQuery('.file').val() == '') {
            jQuery('#spFile').css('display', 'block');
            return false
        }
    }   
});

jQuery(document).on('change', '#txtYouTubeLink', function () {
    jQuery('#spMessage').hide();
    jQuery('#spFile').hide();
});

//word count for text area
var txtAreaWordCount = function () {
    'use strict'
    var value = $('#txtTestimonialMessage').val();
    
    if (value.length == 0) {
        $('#totalChars').html(0);
        //$('#wordCount').html(0);
        //$('#charCount').html(0);
        //$('#charCountNoSpace').html(0);
        return;
    }

    var regex = /\s+/gi;
    var totalChars = value.length;
    //var wordCount = value.trim().replace(regex, ' ').split(' ').length;   
    //var charCount = value.trim().length;
    //var charCountNoSpace = value.replace(regex, '').length;

    $('#totalChars').html(totalChars);
    //$('#wordCount').html(wordCount);
    //$('#charCount').html(charCount);
    //$('#charCountNoSpace').html(charCountNoSpace);
}

jQuery(document).on('change', '#txtTestimonialMessage', txtAreaWordCount);

jQuery(document).on('keydown', '#txtTestimonialMessage', txtAreaWordCount);

jQuery(document).on('keypress', '#txtTestimonialMessage', txtAreaWordCount);

jQuery(document).on('keyup', '#txtTestimonialMessage', txtAreaWordCount);

jQuery(document).on('blur', '#txtTestimonialMessage', txtAreaWordCount);

jQuery(document).on('focus', '#txtTestimonialMessage', txtAreaWordCount);

//image crop 
var imageCropWidth = 0;
var imageCropHeight = 0;
var cropPointX = 0;
var cropPointY = 0;
var jcropApi;

jQuery(document).on("click", "#hl-crop-image", function (e) {

    /*
    The event.preventDefault() method stops the default action of
    an element from happening. For example: Prevent a submit button
    from submitting a form. Prevent a link from following the URL
    */
    e.preventDefault();
    cropImage();
});

jQuery(document).on("click", "#hl-crop-cancel", function (e) {
    e.preventDefault();
    jQuery('.browse').popover('destroy');
    jQuery('.input-field').val('');
    jQuery('.input-field').val('');
    jQuery('.file').val('');
});

function initCrop() {
    jQuery('#uploaded-image-1').Jcrop({
        onChange: setCoordsAndImgSize,
        setSelect: [0, 0, 200],
        minSize: [100, 100],
        aspectRatio: 1, // 0 means will be not be the same for height and weight
        onSelect: setCoordsAndImgSize
    }, function () { jcropApi = this });
}

function showCoordinate() {
    //$("#lblWidth").text(imageCropWidth + "px");
    //$("#lblHeight").text(imageCropHeight + "px");
}

function setCoordsAndImgSize(e) {
    imageCropWidth = e.w;
    imageCropHeight = e.h;
    cropPointX = e.x;
    cropPointY = e.y;

    //jQuery("#lblWidth").text(imageCropWidth + "px");
    //$("#lblHeight").text(imageCropHeight + "px");
}

function cropImage() {

    if (imageCropWidth == 0 && imageCropHeight == 0) {
        alert("Please select crop area.");
        return;
    }
    var img = jQuery("#uploaded-image-1").attr("src");

    /*Show cropped image*/
    //var img = new Image();
    //img.onload = function () {
    //    canvas.height = height;
    //    canvas.width = width;
    //    context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
    //    jQuery('#CroppedImagePath').val(canvas.toDataURL());
    //};
    showCroppedImage();
    jQuery('.browse').popover('destroy');
}

function showCroppedImage() {
    var x1 = cropPointX;
    var y1 = cropPointY;

    var width = imageCropWidth;
    var height = imageCropHeight;

    var canvas = jQuery("#canvas")[0];
    var context = canvas.getContext('2d');
    var img = new Image();
    img.onload = function () {
        canvas.height = height;
        canvas.width = width;
        context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
        jQuery('#CroppedImagePath').val(canvas.toDataURL());
    };
    img.src = jQuery('#uploaded-image-1').attr("src"); 
}

function readFile(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        /*Destroy jcrop initialization other wise it will hold it previous image in img tag*/
        if (jcropApi != null) {
            jcropApi.destroy();
        }
        reader.onload = function (e) {
            var image = '<img id="uploaded-image-1" src=" ' + e.target.result + '" /><br />'
                + '<div style="text-align:center"><a href="#" id="hl-crop-image" class="button input-button">Apply</a>   '
                + '   <a href="#" id="hl-crop-cancel" class="button btn-ghost-blue">Cancel</a><div>';
            
            jQuery('.browse').popover(
                {
                    placement: 'right',
                    content: image,
                    container: 'popover',
                    html: true
                }
            ).popover('show');

            //InitCrop must call here otherwise it will not work
            initCrop();

            //jQuery('#uploaded-image').attr('src', "");
            //jQuery('#uploaded-image').attr('src', e.target.result);
            //var img = jQuery('#uploaded-image').attr('src', e.target.result);

            /*Current uploaded image size*/
            //var width = img[0].height;
            //var height = img[0].width;
            //jQuery("#lblWidth").text(width + "px");
            //jQuery("#lblHeight").text(height + "px");
            //InitCrop must call here otherwise it will not work
            //initCrop();
        }
        
        reader.readAsDataURL(input.files[0]);        
    }
}
