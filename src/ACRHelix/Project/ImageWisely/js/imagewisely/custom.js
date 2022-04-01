
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

    //pearls
    var flt = 'All News';
    var typeUrl = (window.location.href).split('#')[1];
    if (typeUrl != undefined && typeUrl.trim() != '') {
        $('#lnkTopic a').each(function () {
            $(this).removeClass('active');
            if ($(this).text().indexOf(typeUrl) != -1) {
                flt = $(this).text();
                $(this).addClass('active');
            }
        });
    }

    //initial load 
    initializeList(flt, 'All Years', 0);
});

//mobile navigation
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

//change view grid/list
function changeView(e) {
    $('.news-section-list').children().each(function () {
        if (e.className == "grid-view") {
            $(this).find('.ibox-content').css('min-height', 'auto').css('padding', '15px 15px 40px 15px');
            $(this).find('.ibox-title').css('background-color', '#fff').css('color', '#a52f01').css('border', '1px solid #d9d9d9').css('border-bottom', '0').css('height', 'auto');
            $(this).find('.ibox-title h5').css('font-weight', 'bold');

            if ($(this).attr('class') != 'clearfix') {
                $(this).removeClass().addClass('col-xs-12 col-sm-12 col-lg-12');
            }

        }
        else {
            $(this).find('.ibox-content').css('min-height', '200px').css('padding', '15px');
            $(this).find('.ibox-title').css('background-color', '#a52f01').css('color', '#fff');
            if ($(this).attr('class') != 'clearfix') {
                $(this).removeClass().addClass('col-xs-12 col-sm-6 col-lg-4');
            }
        }
    });
    if (e.className == "grid-view") {
        e.className = "list-view ";
        e.text = "Tile view";
    }
    else {
        e.className = "grid-view";
        e.text = "List view";
    }
    $(e).append('<i class="fa fa-angle-right"></i>')
}

var pgIndex = 1;
var nbrPages = 0
var pageSize = $('input:hidden[name=PgSize]').val();

//load more 
$(document).on('click', '#loadMore', function () {
    $('.news-section-list').children().each(function () {
        if ($(this).attr('page-index') == pgIndex) {
            $(this).removeAttr("hidden");
        }
    });
    ++pgIndex;

    //hide load more button 
    if (nbrPages <= pgIndex) {
        $('#loadMore').parent().attr('hidden', 'true');     
    } 

});

//filter by topic
$(document).on('click', '#lnkTopic a', function () {
    pgIndex = 1;
    nbrPages = 0;
    $('#lnkTopic').find('a.active').removeClass('active');
    $(this).addClass('active');
    var year = $('#lnkYear').find('a.active').text();
    initializeList($(this).text(), year, 1);
});

//filter by year
$(document).on('click', '#lnkYear a', function () {
    pgIndex = 1;
    nbrPages = 0;
    $('#lnkYear').find('a.active').removeClass('active');
    $(this).addClass('active');
    var topic = $('#lnkTopic').find('a.active').text();
    initializeList(topic, $(this).text(), 2);
});

$(document).on('click', function () {
    if ($('.megamenu-show').length > 0) {
        $('.megamenu-show').removeClass('megamenu-show');
    }
})

//form select tags being used yet
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

//initialize filter sort action
function initializeList(topic, year, trigger) {
    var itemCount = 0;    
    
    // topic and year are dropdown selections
    $('.news-section-list').children().each(function () {
        $(this).removeAttr('page-index');
        $(this).attr('hidden');
        if ($(this).attr('class').indexOf('tile-exclude') == -1 && $(this).attr('class') != 'clearfix') {
            if(trigger == 0 || trigger == 1){
                if ((topic == $(this).attr('data-news-type')) || (topic == 'All News' || topic == 'All Topics')) {
                    if (($(this).attr('data-news-year').indexOf(year) != -1) || (year == 'All Years')) {
                        $(this).removeAttr('hidden');
                        itemCount++;
                    }
                } else {
                    $(this).attr('hidden', 'true');
                }
            } else if(trigger == 2){
                if (($(this).attr('data-news-year').indexOf(year) != -1) || (year == 'All Years')) {
                    if ((topic == $(this).attr('data-news-type')) || (topic == 'All News' || topic == 'All Topics')) {
                        $(this).removeAttr('hidden');
                        itemCount++;
                    }
                } else {
                    $(this).attr('hidden', 'true');
                }
            }

            
        }
    });

    nbrPages = Math.ceil(itemCount / pageSize);
    
    //update page title
    var filter = topic;
    if (year != 'All Years') {
        filter = filter + ' | ' + year;
    }
    $('#fltTitle').text(filter);
    
          
    //update page-index
    for (var i=0; i < nbrPages; i++) {
        var j = 0;
        $('.news-section-list').children().each(function () {
            if ($(this).attr('class').indexOf('tile-exclude') == -1 && $(this).attr('class') != 'clearfix') {
                if ($(this).attr('hidden') == undefined) {
                    if (j < pageSize && $(this).attr('page-index') == undefined) {
                        $(this).attr('page-index', i);
                        j++;
                    }
                }
            }
        });       
    }

    //hide non active page items
    $('.news-section-list').children().each(function () {
        if ($(this).attr('class').indexOf('tile-exclude') == -1 && $(this).attr('class') != 'clearfix') {
            if ($(this).attr('hidden') == undefined) {
                if ($(this).attr('page-index') != 0) {
                    $(this).attr('hidden', 'true');
                }
            }
        }
    });

    //hide load more button 
    if (nbrPages == 0) {
        $('.no-item-found').removeAttr('hidden');
    } else if (nbrPages == 1 || nbrPages <= pgIndex) {
        $('#loadMore').parent().attr('hidden', 'true');
        $('.no-item-found').attr('hidden', 'true');
    } else {
        $('#loadMore').parent().removeAttr('hidden');
        $('.no-item-found').attr('hidden', 'true');
    }
}

function ShowhideMegamenu(ele, e) {
    $('.dropdown').removeClass('open');
    if ($(ele).next().hasClass('tab-active')) {

    }
    else {
        $('.megamenu-show').removeClass('megamenu-show');
        $('.tab-active').removeClass('tab-active');
    }

    if ($(ele).next().hasClass('megamenu-show')) {
        $(ele).next().removeClass('megamenu-show');
        $(ele).next().removeClass('tab-active');
    }
    else {
        $(ele).next().addClass('megamenu-show');
        $(ele).next().addClass('tab-active');
    }
    e.stopPropagation();

}

function ShowHideCounter() {
    $('#counter-toggle').toggle();
}



