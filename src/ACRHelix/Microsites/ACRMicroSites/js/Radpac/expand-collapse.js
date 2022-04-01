jQuery(function($) {

    $('.expandable').next().hide();

    $('.expandable').removeClass('minus');
    $('.expandable').addClass('plus');

    $('.expandable').removeClass('close');
    $('.expandable').addClass('open');


    $('.expandable').bind('click', function() {

        if ($(this).hasClass('open')) {


            $(this).removeClass('open');
            $(this).addClass('close');

            $(this).removeClass('plus');
            $(this).addClass('minus')

            $(this).next().slideDown("slow");

            return false;

        }
        else {

            $(this).removeClass('close');
            $(this).addClass('open');

            $(this).removeClass('minus');
            $(this).addClass('plus')

            $(this).next().slideUp("slow");

            return false;

        }


    });

    

});
