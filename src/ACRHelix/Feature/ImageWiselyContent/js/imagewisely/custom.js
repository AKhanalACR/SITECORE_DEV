
    $(document).on("click", "#mobile-nav-toggle", function (e) {
        var container = $("#mobile-nav-toggle");
        {
            if ($('button').hasClass('navbar-toggle')) {
                $('button').removeClass('collapsed');
                $('#mobile-nav-toggle i').toggleClass('ic-times ic-bars');
                //$('#mobile-body-overly').fadeOut();
            }
        }
    });

    $(document).ready(function () {

        //var totalitems = $("#parent .child").length;
        var scrollval = 100;
        //var totalheight = (totalitems * scrollval) - ($("#parent").height());

        $(document).on("click", "#down", function () {
            var currentscrollval = $('#parent').scrollTop();
            $('#parent').scrollTop(scrollval + currentscrollval);
        });

        $(document).on("click", "#up", function () {
            var currentscrollval = parseInt($('#parent').scrollTop());
            $('#parent').scrollTop(currentscrollval - scrollval);
        });

    });

    $('select').each(function () {
        var $this = $(this), numberOfOptions = $(this).children('option').length;

        $this.addClass('select-hidden');
        $this.wrap('<div class="select"></div>');
        $this.after('<div class="select-styled"></div>');

        var $styledSelect = $this.next('div.select-styled');
        $styledSelect.text($this.children('option').eq(0).text());

        var $list = $('<ul />', {
            'class': 'select-options'
        }).insertAfter($styledSelect);

        for (var i = 0; i < numberOfOptions; i++) {
            $('<li />', {
                text: $this.children('option').eq(i).text(),
                rel: $this.children('option').eq(i).val()
            }).appendTo($list);
        }

        var $listItems = $list.children('li');

        $styledSelect.click(function (e) {
            e.stopPropagation();
            $('div.select-styled.active').not(this).each(function () {
                $(this).removeClass('active').next('ul.select-options').hide();
            });
            $(this).toggleClass('active').next('ul.select-options').toggle();
        });

        $listItems.click(function (e) {
            e.stopPropagation();
            $styledSelect.text($(this).text()).removeClass('active');
            $this.val($(this).attr('rel'));
            $list.hide();
            //console.log($this.val());
        });

        $(document).click(function () {
            $styledSelect.removeClass('active');
            $list.hide();
        });

    });

function changeView(e) {
    $('.news-section-list').children().each(function () {
        if (e.className == "grid-view") {
            $(this).find('.ibox-content').css('min-height', 'auto').css('padding', '15px 15px 40px 15px');
            $(this).find('.ibox-title').css('background-color', '#fff').css('color', '#a52f01').css('border', '1px solid #d9d9d9').css('border-bottom', '0').css('height', 'auto');
            $(this).find('.ibox-title h5').css('font-weight', 'bold');
            $(this).removeClass().addClass('col-xs-12 col-sm-12 col-lg-12');
        }
        else {
            $(this).find('.ibox-content').css('min-height', '200px').css('padding', '15px');
            $(this).find('.ibox-title').css('background-color', '#a52f01').css('color', '#fff');
            $(this).removeClass().addClass('col-xs-12 col-sm-6 col-lg-4');
        }
    });
    if (e.className == "grid-view") {
        e.className = "list-view";
        e.text = "Grid view";
    }
    else {
        e.className = "grid-view";
        e.text = "List view";
    }
}