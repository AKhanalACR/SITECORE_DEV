//active tab
jQuery(function ($) {
    //add active button css
    $('.rli-tabs li a').each(function () {
        var urlArray = $(location).attr('href').trim().split('/');
        urlArray = urlArray.filter(function (e) { return e.replace(/(\r\n|\n|\r)/gm, "") });
        var itemUrl = $(this).attr('href').trim().split('/');
        itemUrl = itemUrl.filter(function (e) { return e.replace(/(\r\n|\n|\r)/gm, "") });       
        if (itemUrl[itemUrl.length - 1].toLowerCase().indexOf(urlArray[urlArray.length - 1].toLowerCase()) != -1) {
            $(this).parent().addClass('active');            
        }

        //if (itemUrl[itemUrl.length - 1].toLowerCase() == "meetings-and-course-calendar") {
        //    var url = $(this).attr('href') + "#f:meetingType=[RLI]";
        //    $(this).attr('href', url);
        //}
    });
});

//slick slide on smaller devices
jQuery('.chapter-area').easyTabs({
    callback: function (thisTabID, tabId) {
        jQuery('.event-tile-area').each(function () {
            jQuery(this).hasClass('slick-initialized') && jQuery(this).slick('unslick');
        });
        resourceSliderTabs(tabId);
        jQuery(window).trigger('resize');
    }
});
jQuery('.tabs').scrollInView({ childItem: 'li', slideWrapper: 'ul', scrollItemAmount: 1 });
squareItUp('.square-tile-area', { squareItem: '.square-tile', useOuterWidth: true, stopWidth: 960, timerDelay: 120 });