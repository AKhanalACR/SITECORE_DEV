
$(function () {

    
        $("#stack-menu").stackMenu()
        $(".stack-menu__link--back").text("Go Back");
    

    $(window).scroll(function () {
        if ($(window).scrollTop() >= 100) {

            $('.bt-top').addClass('visible');
        } else {

            $('.bt-top').removeClass('visible');
        }
    });

    // Back to top button
    $(window).scroll(function() {
    if ($(this).scrollTop() > 100) {
        $('.bt-top').fadeIn('slow');
    } else {
        $('.bt-top').fadeOut('slow');
    }
    });
        $('.bt-top').click(function(){
        $('html, body').animate({scrollTop : 0},600);
    return false;
    });

    // Main Nav indication
    $('#main-nav').find('.nav-link').click(function() {
        $('.nav-link').removeClass('current');
        $(this).addClass('current');
      });

    // Banner background-image
    if($('#main-body').length){
        var bgUrl = $("#banner-backgroundImage").attr("src");
       $(".banner-wrapper").backstretch(bgUrl);
    }


    //sticky navbar
    $(window).scroll(function() {
      if ($(window).scrollTop() > 50 ) {
        $('.navbar-wrapper').addClass("shadow");
      } else {
        $('.navbar-wrapper').removeClass( "shadow" );
      }
    });

    //search box

        //$(".search").click(function(){
        //    $(".search-bar").slideDown('fast');
        //});
        //$('.search-close').click(function () {
        //    $('.search-bar').slideUp();
        //    });

  //event selector
  function eventSelecotrAll() {
    $('.search-item').show();
  }
  eventSelecotrAll();
  $('#searchSelector').change(function() {
    var value = $(this).val();
    if (value == 'all') {
      eventSelecotrAll();
    } else {
      $('.search-item').hide();
      $('.' + value).show();
    }
  });

//search result
// function divisionAll() {
//   $('.search-result').show();
// }
// divisionAll();
// $('#searchFilters').change(function() {
//   var ourClass = $(this).val();
//   if (ourClass == 'all') {
//     divisionAll();
//   } else {
//     $('.search-result').hide();
//     $('#' + ourClass).show();
//   }
// });

//events slider
$("#banner-flexslider").owlCarousel({
    autoPlay: 3000, //Set AutoPlay to 3 seconds

    items: 3,
    itemsDesktop: [1199, 3],
    itemsDesktopSmall: [991, 2],
    itemsTablet: [768, 1],
    itemsMobile:	[479,1],
    pagination:false,
    navigation:true,
    navigationText:	["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"]
});

//banner selection
(function () {
  [].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
      new SelectFx(el);
  });
})();


//accordion icon

  $('.panel-collapse').on('show.bs.collapse', function () {
    $(this).siblings('.panel-heading').addClass('active');
  });

  $('.panel-collapse').on('hide.bs.collapse', function () {
    $(this).siblings('.panel-heading').removeClass('active');
  });


    //load more video

  $(".video-list").each(function () {
      
      $(this).find('.list').slice(0, ($(this).find('#NumberOfResources').val() != undefined && $(this).find('#NumberOfResources').val() != "0" ? $(this).find('#NumberOfResources').val() : 6)).show();
      if ($(this).find('.list:hidden').length == 0) {
          $(this).find('.loadMore').removeClass(".loadMore").css("display", "none");
      }
  })

  $(".loadMore").on("click", function(e){
    e.preventDefault();
    var obj = $(this).closest('.video-list');
    obj.find(".list:hidden").slice(0, (obj.find("#NumberOfResourcesLoadMore").val() != undefined && obj.find("#NumberOfResourcesLoadMore").val() != "0" ? obj.find("#NumberOfResourcesLoadMore").val() : 6)).slideDown();
    if(obj.find(".list:hidden").length == 0) {
      $(this).removeClass(".loadMore").css("display", "none");
    }
  });

    //load more accordions
  var PanelCounter = 1;
  $(".panel-group").each(function (index) {

      $($(this).children()).each(function () {          
          if ($(this).children().hasClass("panel-collapse"))
          {
              $(this).children().has("div").next().attr("id", "collapse-" + PanelCounter);
          }
          $(this).children().children().children().attr("href", "#collapse-" + PanelCounter);
          $(this).children().children().children().attr("aria-controls", "collapse-" + PanelCounter);
          PanelCounter++;
      });

      $(this).children().slice(0, 5).show();

      if ($(this).children().length > 5) {
          $(this).parent().next().css("display", "block"); 
      } else {
          $(this).parent().next().css("display", "none");
      }


  });

  $(".loadMore-accordion").on("click", function (e) {
      e.preventDefault();
      if ($(this).prev().children().length > 1)
      {
          $(this).prev().children().has('div').children().show();
      }
      $(this).hide();
  });


 /* $(".panel").slice(0, 5).show();
  if ($(".panel:hidden").length == 0) {
      $(".loadMore-accordion").css("display", "none");
  }

$(".loadMore-accordion").on("click", function(e){
  e.preventDefault();
  $(".panel:hidden").slice(0, 5).slideDown();
  if($(".panel:hidden").length == 0) {
    $(".loadMore-accordion").css("display", "none");
  }
});*/

//subscribe
$(".btn.default").on("click", function () {
  $(".active.form-control").prop("disabled", true);
  $(".default.form-control").prop("disabled", false);
});

$(".btn.active").on("click", function () {
  $(".active.form-control").prop("disabled", false);
  $(".default.form-control").prop("disabled", true);
});


/*$(document).mouseup(function (e) {
    //var popup = $("#myPopup");
    //if (!$('.popup').is(e.target) && !popup.is(e.target) && popup.has(e.target).length == 0) {
    //    popup.removeClass("show");
    //}
    var popup = $("#123");
    if (!$('.share-drawer').is(e.target) && !popup.is(e.target) && popup.has(e.target).length == 0) {
        popup.hide();
    }
});*/


$(".container").click(function (e) {
    if (e.target.id != "share-link")
    {
        $(".share-drawer").hide();
    }
});

//function closest(e, t) {
//    return !e ? false : e === t ? true : closest(e.parentNode, t);
//}

//container = document.getElementsByClassName("share-drawer");
//open = document.getElementById("share-link");

//open.addEventListener("click", function (e) {
//    container[0].style.display = "block";
//    //open.disabled = true;
//    e.stopPropagation();
//});

//document.body.addEventListener("click", function (e) {
//    if (!closest(e.target, container)) {
//        container[0].style.display = "none";
//        //open.disabled = false;
//    }
//});




	/* Toggle Video Modal
  -----------------------------------------*/
	function toggle_video_modal() {

    // Click on video thumbnail or link
    $(".js-trigger-video-modal").on("click", function(e){

        // prevent default behavior for a-tags, button tags, etc.
        e.preventDefault();

        // Grab the video ID from the element clicked
        var id = $(this).attr('data-youtube-id');

        // Autoplay when the modal appears
        // Note: this is intetnionally disabled on most mobile devices
        // If critical on mobile, then some alternate method is needed
        var autoplay = '?autoplay=1';

        // Don't show the 'Related Videos' view when the video ends
        var related_no = '&rel=0';

        // String the ID and param variables together
        var src = '//www.youtube.com/embed/'+id+autoplay+related_no;

        // Pass the YouTube video ID into the iframe template...
        // Set the source on the iframe to match the video ID
        $("#youtube").attr('src', src);

        // Add class to the body to visually reveal the modal
        $("body").addClass("show-video-modal noscroll");

    });

    // Close and Reset the Video Modal
    function close_video_modal() {

      event.preventDefault();

      // re-hide the video modal
      $("body").removeClass("show-video-modal noscroll");

      // reset the source attribute for the iframe template, kills the video
      $("#youtube").attr('src', '');

    }
    // if the 'close' button/element, or the overlay are clicked
    $('body').on('click', '.close-video-modal, .video-modal .overlay', function(event) {

        // call the close and reset function
        close_video_modal();

    });
    // if the ESC key is tapped
    $('body').keyup(function(e) {
        // ESC key maps to keycode `27`
        if (e.keyCode == 27) {

          // call the close and reset function
          close_video_modal();

        }
    });
}
toggle_video_modal();

});
