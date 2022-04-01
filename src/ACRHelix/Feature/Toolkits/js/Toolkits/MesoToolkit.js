jQuery(function ($) {
    $('.pfcc-sort-ddl').dropdown();

    //remove external link icon
    $('.pfcc-result-list').find('a').each(function () {
        if ($(this).hasClass('external-link-added')) {
            $(this).removeClass('external-link-added').remove('span');
            $(this).find('.icon-external-site').remove();
        }
    });

    //facet hide items >4
    $("[id^=pfcc-fg]").each(function () {
        $(this).children('label:gt(3)').hide();
    });

    //facet footer hide less icon
    $('[id^=pfcc-facet-footer]').each(function () {
        $(this).find('.facet-less').hide();
    });

    //mobile facet toggle button	
    $('.filter-btn .close-dd-nav').on('click', function () {
        $('.filter-menu').slideToggle("slow");
        $('#pfcc-filter-up').toggle();
        $('#pfcc-filter-down').toggle();
    });

    //mobile dropdown toggle icon
    $('#pfcc-filter-down').hide();
    $('.filter-main i').on('click', function () {
        $('.filter-menu').slideToggle("slow");
        $('#pfcc-filter-up').toggle();
        $('#pfcc-filter-down').toggle();
    });

    //keyword search press enter
    $($('#pfcc-search-bar').find('#keyword')).keypress(function (e) {
        if (e !== undefined && e.which === 13) {
            $('#pfcc-search-bar .btn-icon').click();
        }
    });

    //checkbox change event
    $('#pfcc-fg-0 :checkbox').change(function () {
        $('#pfcc-search-bar .btn-icon').click();
    });

    $('#pfcc-fg-1 :checkbox').change(function () {
        $('#pfcc-search-bar .btn-icon').click();
    });

    $('#pfcc-fg-2 :checkbox').change(function () {
        $('#pfcc-search-bar .btn-icon').click();
    });
    $('#pfcc-fg-3 :checkbox').change(function () {
        $('#pfcc-search-bar .btn-icon').click();
    });
    //search button click event
    $(document).on('click', '#pfcc-search-bar .btn-icon', function () {
        pfcc_search(1, 'desc');
    });

    //pagination events
    $(document).on('click', '.pfcc-pagination .pfcc-pg-next', function () {
        var pgNbr = 0;
        var a = +$('.pfcc-pagination #pfcc-pageNbr').text().trim();
        var b = +$('.pfcc-pagination #pfcc-TotalNbrPages').text().trim();
        if (a < b)
            pgNbr = +$('.pfcc-pagination #pfcc-pageNbr').text() + 1;
        else
            pgNbr = +$('.pfcc-pagination #pfcc-TotalNbrPages').text();

        var sortDir = $('.pfcc-ddls').find('.menu').find('.selected').attr('data-value');
        pfcc_search(pgNbr, sortDir);
    });

    $(document).on('click', '.pfcc-pagination .pfcc-pg-back', function () {
        var pgNbr = 0;
        var a = +$('.pfcc-pagination #pfcc-pageNbr').text().trim();
        if (a > 1)
            pgNbr = +$('.pfcc-pagination #pfcc-pageNbr').text() - 1;
        else
            pgNbr = 1;

        var sortDir = $('.pfcc-ddls').find('.menu').find('.selected').attr('data-value');
        pfcc_search(pgNbr, sortDir);
    });

    //sort event
    $(document).on('click', '.pfcc-sort-ddl .menu .item', function () {
        var sortDir = $(this).attr('data-value');
        pfcc_search(1, sortDir);
    });

    //share link content
    $('.share-link-mail').each(function () {

        var t = 'mailto:email?subject={0}&body={1}';
        var l = $(this).attr('data-url'); //.find('.sharethis-inline-share-buttons')
        if (l.match('^/-/media')) {
            l = window.location.protocol + "//" + window.location.host + l;
        }
        var s = "Exciting Patient and Family-Centered Care Resource";
        var b = "I think you'll find this useful. \n\n";
        b = b + "Found this great Patient- and Family-Centered Care resource on the ACR Toolkit and wanted to share. \n\n";
        b = b + $(this).attr('data-description') + " - " + l; //.find('.sharethis-inline-share-buttons')
        b = encodeURIComponent(b);
        t = t.replace("{0}", s).replace("{1}", b);
        $(this).attr('href', t);

        //facebook
        var fb = 'https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(l) + '&quote=' + encodeURIComponent($(this).attr('data-description'));
        $(this).siblings('.pf-facebook').attr('href', fb);

        //twitter
        var tw = 'https://twitter.com/share?text=' + encodeURIComponent($(this).attr('data-description')) + '&url=' + encodeURIComponent(l);
        $(this).siblings('.pf-twitter').attr('href', tw);
    });
	
	//siginup email submission
	$(document).on('click', '#mesoSignUpEmail', function (event) {
        var email = $("input[name='MesoSignupWithEmail']").val();
        if (email == undefined || email == '') {
            $("input[name='MesoSignupWithEmail']").css({ 'border': '1px solid red' });
            event.preventDefault();
        } else {
            $("input[name='MesoSignupWithEmail']").css({ 'border': '1px solid #bebebe' });
            $('.mktoForm').find('form').find('#Email').val(email);
			var formId = $('.mktoForm').children('form');
            var btnId = $(formId).find('button[type="submit"]');
            $(btnId).click();
        }
    });
});

function pfcc_more_less(clicked) {
    if ($(clicked).find('.facet-more').css('display') !== 'none') {
        $(clicked).parent().children('label:gt(3)').show();
        $(clicked).find('.facet-more').toggle();
        $(clicked).find('.facet-less').toggle();
    } else {
        var pId = $(clicked).parent();
        $(pId).each(function () {
            $(pId).children('label:gt(3)').hide();
        });
        $(clicked).find('.facet-less').toggle();
        $(clicked).find('.facet-more').toggle();
    }
}

function pfcc_search(pageNbr, sortDir) {
    var tgt = [];
    $("#pfcc-fg-0").find("input:checked").each(function (i, ob) {
        tgt.push($(ob).val());
    });
    tgt = tgt.toString();

    var ckt = [];
    $("#pfcc-fg-1").find("input:checked").each(function (i, ob) {
        ckt.push($(ob).val());
    });
    ckt = ckt.toString();

    var asct = [];
    $("#pfcc-fg-2").find("input:checked").each(function (i, ob) {
        asct.push($(ob).val());
    });
    asct = asct.toString();

    var rtype = [];
    $("#pfcc-fg-3").find("input:checked").each(function (i, ob) {
        rtype.push($(ob).val());
    });
    rtype = rtype.toString();

    var kw = $('#pfcc-search-bar #keyword').val().trim();
    kw = kw.replace(/['"]+/g, '');
	
    var feedbackemail = $('#feedbackemail').attr('href');

    var url = '/api/Sitecore/MesoToolkit/Resources';
    jQuery.ajax({
        type: "GET",
        url: url,
        contentType: "application/json",
        data: {
            'tgtype': tgt.replace(/["']/g, ""),
            'cktype': ckt.replace(/["']/g, ""),
            'asctype': asct.replace(/["']/g, ""),
            'rtype': rtype.replace(/["']/g, ""),
            'kword': kw.replace(/["']/g, ""),
            'pageNbr': encodeURIComponent(pageNbr),
            'sortDir': encodeURIComponent(sortDir)
        },
        cache: false,
        error: function () {
            alert("error: MESSO Toolkit retriving resource data.");
        },
        success: function (data) {
            $('#pfcc-results-list').html(data);
            $('#feedbackemail').attr('href', feedbackemail);
            $('.pfcc-sort-ddl').val(sortDir);
            $('.pfcc-sort-ddl').dropdown();

            //share link content
            $('.share-link-mail').each(function () {

                var t = 'mailto:email?subject={0}&body={1}';
                var l = $(this).attr('data-url'); //.find('.sharethis-inline-share-buttons')
                if (l.match('^/-/media')) {
                    l = window.location.protocol + "//" + window.location.host + l;
                }
                var s = "Exciting Patient and Family-Centered Care Resource";
                var b = "I think you'll find this useful. \n\n";
                b = b + "Found this great Patient- and Family-Centered Care resource on the ACR Toolkit and wanted to share. \n\n";
                b = b + $(this).attr('data-description') + " - " + l;
                b = encodeURIComponent(b);
                t = t.replace("{0}", s).replace("{1}", b);
                $(this).attr('href', t);

                //facebook
                var fb = 'https://www.facebook.com/sharer/sharer.php?u=' + encodeURIComponent(l) + '&quote=' + encodeURIComponent($(this).attr('data-description'));
                $(this).siblings('.pf-facebook').attr('href', fb);

                //twitter
                var tw = 'https://twitter.com/share?text=' + encodeURIComponent($(this).attr('data-description')) + '&url=' + encodeURIComponent(l);
                $(this).siblings('.pf-twitter').attr('href', tw);
            });

            $('html, body').animate({
                scrollTop: ($('.search-bar').offset().top)
            }, 500);

        }
    });
}
