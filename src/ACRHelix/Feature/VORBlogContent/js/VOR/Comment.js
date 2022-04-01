
    function recaptcha_callback() {
        $('#captchaerror').hide();
    }
    $(document).ready(function () {
        $(document).on('click', '.leave-comment', function () {
            $(this).toggleClass('open');
            $(this).next('.comment-body').slideToggle();
        })
        $(document).on('click', '.reply-node .link', function () {
            if (!$(".leave-comment").hasClass("open")) {
        $(".leave-comment").toggleClass('open');
    $(".leave-comment").next('.comment-body').slideToggle();
}
            $('html, body').animate({
        scrollTop: $(".comments-wrap").offset().top-190
});
})

        $(".cominput").keyup(function () {
            if ($("#commentWrap").hasClass("submitattempt")) {
                if (!$('#comment').val()) {
        $('#commenterror').show();
    } else {
        $('#commenterror').hide();
    }
                if (!$('#name').val()) {
        $('#nameerror').show();
    } else {
        $('#nameerror').hide();
    }
                if (!$('#email').val()) {
        $('#emailerror').show();
    $('#emailpatternerror').hide();
                } else {
                    var email = $('#email').val();
                    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                    if (!emailReg.test(email)) {
        $('#emailpatternerror').show();
    $('#emailerror').hide();
                    } else {
        $('#emailpatternerror').hide();
    }
}
}
});

        $("#commentSubmit").click(function commentValidation(e) {
        $('#commenterror').hide();
    $('#nameerror').hide();
    $('#emailerror').hide();
    $('#emailpatternerror').hide();
    $('#captchaerror').hide();
            if (!$("#commentWrap").hasClass("submitattempt")) {
        $('#commentWrap').addClass("submitattempt");
    }
   
    var commentForm = $('#commentForm')[0];

    var errorCount = 0;
            if (!$('#comment').val()) {
        $('#commenterror').show();
    errorCount = 1;
}
            if (!$('#name').val()) {
        $('#nameerror').show();
    errorCount = 1;
}
            if (!$('#email').val()) {
        $('#emailerror').show();
    errorCount = 1;
            } else  {
                var email = $('#email').val();
                var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                if (!emailReg.test(email)) {
        $('#emailpatternerror').show();
    errorCount = 1;
}
}
            if (grecaptcha.getResponse().length === 0) {
        $('#captchaerror').show();
    errorCount = 1;
}
            if (errorCount == 1) {
        e.preventDefault();
    }
                else {
        e.preventDefault();
    console.log("success");
    submitCommentData();
    }


}

);

        function submitCommentData() {
            var comment = $('#comment').val();
    var name = $('#name').val();
    var email = $('#email').val();
    var capchaResponse = grecaptcha.getResponse();
    var ItemId = $('.commentParentId').attr('id');
    var pageUrl = window.location.pathname.replace(/\/+$/, '');
            $.ajax({
        url: "/api/Sitecore/XBlog/CommentSubmit",
    //url: pageUrl +'/CommentSubmit/',
    type: 'post',
    async: false,
                data: {comment: comment, name: name, email: email, capchaResponse: capchaResponse, ItemId: ItemId },
    dataType: 'json',
                success: function (data) {
                    if (data.success == "success") {
        $("#commentForm")[0].reset();
    grecaptcha.reset();
    $('#commentWrap').removeClass("submitattempt");
    $(".alert").show();
                        setTimeout(function () {$(".alert").hide(); }, 10000);
}
                    else if (data.message == "Commentnotcreated") {
        alert("Something went wrong. Please try again after some time.");
    }
    else
                    {
        grecaptcha.reset();
    $('#captchaerror').show();
}
},
                error: function (jqXHR, exception) {
        alert("Something went wrong. Please try again after some time");
    },
});
}


    });