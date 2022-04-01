//*****************************************************
// Membership Testimonial
// Author:  
// Date: 7 / 26 / 2017
//*****************************************************

//infinite scrolling
var pageIndex = 0;
var lastScrollTop = 0;
var loadMore = function () {
    'use strict'
    var st = $(this).scrollTop();
    if (st > lastScrollTop) {
        lastScrollTop = st;

        var win = jQuery(window);
        var sec = jQuery('#mtLoadMore');
        var cat = jQuery('.mt-catLst').find('.selected').attr('data-value'); // jQuery('.category-filter').val();
        var maxIndex = jQuery('#MaxIndex');
        if (sec.length > 0) {
            var viewport = {
                top: win.scrollTop()
            };
            viewport.bottom = viewport.top + win.height();

            var bounds = sec.offset();
            bounds.bottom = bounds.top + sec.outerHeight();
            if (pageIndex <= maxIndex.val()) {
                if (!(viewport.bottom < bounds.top || viewport.top > bounds.bottom)) {
                    pageIndex++;
                    jQuery(".ajax-loader").show();
                    jQuery.ajax({
                        type: "GET",
                        url: "/api/Sitecore/MembershipTestimonials/LoadMoreTestimonials",
                        datatype: "json",
                        data: { "pageIndex": pageIndex, "category": cat },
                        success: function (data) {
                            jQuery(".ajax-loader").hide();
                            jQuery("#mtTiles").append(data);
                        },
                        error: function () {
                            jQuery(".ajax-loader").hide();
                            //alert("Dynamic content load failed.");
                        }
                    });
                }
            }   
        }
    }
    lastScrollTop = st;
}
jQuery(window).on('scroll', loadMore);

//open popup - detail personal tesimony
var details = function () {
    'use strict'
    //debugger;    
    var $buttonClicked = jQuery(this);
    var cusId = $buttonClicked.attr('data-item-id');
    var options = { "backdrop": "static", keyboard: true };
    jQuery.ajax({
        type: "GET",
        url: "/api/Sitecore/MembershipTestimonials/TestimonialDetails",
        datatype: "json",
        data: { "id": cusId },
        success: function (data) {
            //debugger;
            jQuery('#myModalContent').html(data);
            jQuery('#myModal').modal(options);
            jQuery('#myModal').modal({
                keyboard: true
            }); //.modal('show');
            window.__sharethis__.initialize();
        },
        error: function () {
            //alert("Dynamic content load failed.");
        }
    });
};
jQuery(document).on("click", ".read-more-link", details);
jQuery(document).on("click", ".overlay-to-show", details);

//share link initialize
jQuery('#myModal').on('show.bs.modal', function (e) {
    'use strict'    
    var url = window.location.protocol + '//' + window.location.host;
    var shareUrl = url + "/Member-Resources/We-Are-ACR/testimonials/" + jQuery('.header-share-opts').attr('data-sitecore-id');
    shareUrl = shareUrl.replace(/#/g, '').replace(/\s/g, '-').toLocaleLowerCase();
    jQuery('.sharethis-inline-share-buttons').attr('data-url', shareUrl);

    var mailTo = "mailto:email?subject={0}&body={1}";
    var title = encodeURIComponent(jQuery("title").text());
    var description = encodeURIComponent('This page on www.acr.org has been shared with you! \r\n\r\n' + jQuery("meta[name='description']").attr("content") + '\r\n\r\n' + shareUrl);
    mailTo = mailTo.replace('{0}', title).replace('{1}', description);
    jQuery('.mailToLink').attr('href', mailTo);

    //pinterest btn hide
    jQuery('.st-btn:eq(2)', '.share-link .share-drawer').css('display', 'none');
    
})

//filter by category
var filter = function () {
    'use strict'
    //debugger;
    var category = jQuery('.mt-catLst').find('.selected').attr('data-value');
    var options = { "backdrop": "static", keyboard: true };
    if (category != "") {
        pageIndex = 0;
        jQuery(".ajax-loader").show();
        jQuery.ajax({
            type: "GET",
            url: "/api/Sitecore/MembershipTestimonials/TestimonialsByCategory",
            datatype: "json",
            data: { "category": category },
            success: function (data) {
                jQuery(".ajax-loader").hide();
                if (data !== null && jQuery.trim(data) !== "") {
                    jQuery("#mtTiles").html(data); //.replaceWith(data);
                }
                else {
                    jQuery("#mtTiles").html("<div class='xl-col-12 text-content'>There are no yet testimonials for this category.</div>");
                }
                
            },
            error: function () {
                //alert("Dynamic content load failed.");
            }
        });
    }
};
jQuery(document).on("click", ".mt-catLst", filter); //change .category-filter

//play video
jQuery(document).on("click", ".video", function () {
    'use strict'
    var elm = jQuery(this),
        conts = elm.contents(),
        le = conts.length,
        ifr = null;

    for (var i = 0; i < le; i++) {
        if (conts[i].nodeType == 8) ifr = conts[i].textContent;
    }
    elm.css('background-color', 'black');
    elm.addClass("player").html(ifr);
    var videoUrl = jQuery('#mtdVideoUrl').val().trim();

    if (videoUrl.indexOf('?') == -1) { 
        if (videoUrl.indexOf('autoplay=1&rel=0') == -1) {
            videoUrl = videoUrl + "?autoplay=1&rel=0";
        }
    } else {
        if (videoUrl.indexOf('autoplay=1&rel=0') == -1) {
            if (videoUrl.endsWith('?')){
                videoUrl = videoUrl + "autoplay=1&rel=0";
            } else {
                videoUrl = videoUrl + "&autoplay=1&rel=0";
            }
        }
    } 
    jQuery('.video iframe').attr('src', videoUrl);
    elm.off("click");
});

jQuery(document).on("click", "#cboxClose", function () {
    jQuery('.video iframe').attr('src', '');
});

jQuery(document).ready(function () {
    jQuery(".mt-catLst").find("select").dropdown();

    jQuery('#myModal').click(function (event) {
        if (event.target.id == "myModal") {            
            jQuery("#cboxClose").click();
        }      
    });
})