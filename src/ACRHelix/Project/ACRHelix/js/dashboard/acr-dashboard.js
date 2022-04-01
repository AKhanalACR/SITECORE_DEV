jQuery(function ($) {

    $('.account-main').equalizeContent({ equalizeItem: '.box-account' });
    $('.reading-lists').equalizeContent({ equalizeItem: '.event-tile' });

    tooltips();
    radiosCheckboxes1('#my-links-reports');

    $(".tab-container").easyTabs({
        callback: function () {
            $('.reading-lists').trigger('equalizeContent');
        }
    });


    scrollInView('.acr-tabs', { childItem: 'li', $slideContainer: 'ul', scrollItemAmount: 1 });


    $('.latest-news-item-body').on('init', function () {
        var $firstBtn = $('.latest-news-pager').find('a:eq(0)');
        $("<span> &nbsp;|&nbsp; </span>").insertAfter($firstBtn);

		$('.latest-news-pager').on('click','.latest-news-btn',function(e){
			e.preventDefault();
			e.stopPropagation();
		})

    }).slick({
        arrows: true,
        appendArrows: $('.latest-news-pager'),
        fade: true,
        prevArrow: '<a href="#" class="latest-news-btn"><i class="acr-icon icon-arrow-left"/><strong>Previous</strong></a>',
        nextArrow: '<a  href="#" class="latest-news-btn"><strong>Next</strong><i class="acr-icon icon-arrow-right"/></a>'
        });

    $('.dashboard-links-container').on('init', function () {
        var $firstBtn = $('.dashboard-links-pager').find('a:eq(0)');
        $("<span> &nbsp;|&nbsp; </span>").insertAfter($firstBtn);

    }).slick({
        arrows: true,
        appendArrows: $('.dashboard-links-pager'),
        fade: true,
        prevArrow: '<a href="#" class="latest-news-btn"><i class="acr-icon icon-arrow-left"/><strong>Previous</strong></a>',
        nextArrow: '<a  href="#" class="latest-news-btn"><strong>Next</strong><i class="acr-icon icon-arrow-right"/></a>'
    });



    $('#add-new-my-link').colorbox({ maxWidth: '820px', width: "90%", inline: true });
    $('#cancel-add-link-modal').click(function () {
        $.colorbox.close()
    });

    if ($('#my-links-reports').attr('data-updated') == 'True') {
        $('#scrollmylinks').click();
    }

    //var t = $(".credit-hours");
    //var percentage = $(".credit-hours").attr('data-credits-pct');
    //var col1 = '#194a6a';
    //var col2 = '#ffffff';
    //t[0].style.background = "-webkit-gradient(linear, left top,right top, color-stop(" + percentage + "%," + col1 + "), color-stop(" + percentage + "%," + col2 + "))";
    //t[0].style.background = "-moz-linear-gradient(left center," + col1 + " " + percentage + "%, " + col2 + " " + percentage + "%)";
    //t[0].style.background = "-o-linear-gradient(left," + col1 + " " + percentage + "%, " + col2 + " " + percentage + "%)";
    //t[0].style.background = "linear-gradient(to right," + col1 + " " + percentage + "%, " + col2 + " " + percentage + "%)";

    $('.show-all-bookmarks').click(function () {
        $('.show-bookmark').show();
        $('.show-all-bookmarks').hide();
        return false;
    });

    $('.show-all-reccomended').click(function () {

        $('.show-reccomend').show();
        $('.show-all-reccomended').hide();
        return false;
    });
});

function radiosCheckboxes1(parent) {

    var $parent = $((parent || 'main'));

    $('.acr-checkbox,.acr-radio').each(function () {

        $(this).prepend('<i></i>');
        var $input = $('input', this);

        $input.is(':checked') && $(this).addClass('input-checked');
        $input.is(':disabled') && $(this).addClass('disabled-input');
    });

    $parent.on('click radiosCheckboxes', '.acr-checkbox,.acr-radio', function () {

        if ($(this).hasClass('disabled-input')) { return }

        var $input = $('input', this),
            isRadio = $input[0].type.toUpperCase() === "RADIO";

        if ($input.is(':checked')) {
            if (!isRadio) {
                $input.prop('checked', false);
                $(this).removeClass('input-checked');
            }
        } else {
            $input.prop('checked', true);
            $(this).addClass('input-checked');
        }
        //create the change event in case it
        //didn't register
        $input.trigger('change');

        $('input[id=' + $input.attr('id') + ']')
            .not(':checked')
            .parent('.acr-radio')
            .removeClass('input-checked');

    });
}