import BulletinTopicList from "./components/bulletin/bulletin-topic-list";
import BulletinTagList from "./components/bulletin/bulletin-tag-list";
import BulletinIssueList from "./components/bulletin/bulletin-issue-list";

jQuery(function($) {
  var topicList = new BulletinTopicList(
    "#bulletin-year-ddl",
    "#bulletin-topic-article-area"
  );
  var tagList = new BulletinTagList(
    "#bulletin-year-ddl",
    "#bulletin-tag-article-area"
  );

  var issueList = new BulletinIssueList(
    "#bulletin-issue-years-ddl",
    "#bulletin-issue-list"
  );

  //props
  let resizeThrottle = null,
    winWidth = null,
    $pullquoteTableZoneTarget = $(".bulletin-features")
      .find(">div")
      .eq(1),
    $pullquoteOriginalTarget = $(".pullquote-outer"),
    colorboxScriptingIsAttached = $.fn.colorbox,
    thereBeSlickSlider = $.fn.slick;

  const bkpts = {
    mb: 641,
    dk: 960
  };

  //init (to win it)
  equalizeThings();
  lightBox();
  featureArea();


	let $slider =  $('.bulletin-past-issues-slider');

	function articleStaggering( $centerElem ){

		const $slickSlides =  $('.slick-slide',$slider);;
		$slickSlides.each(function(){
			$(this)
				.removeClass(`
					pos-next-1
					pos-next-2
					pos-prev-1
					pos-prev-2
				`);
		});

		if($(window).width() > bkpts.mb) {

			$centerElem
				.prev().addClass('pos-prev-1')
				.prev().addClass('pos-prev-2');

			$centerElem
				.next().addClass('pos-next-1')
				.next().addClass('pos-next-2');

		}
	}

	if( thereBeSlickSlider ){

		$slider
			.on('init reInit', function(event, slick){

				const $slickSlides =  $('.slick-slide',$slider);
				$slickSlides.each(function(){
					let $this = $(this);

					$this.addClass(`slick-slide-i_${$this.data('slick-index')}`);
				});

				const $centerElem = $('.slick-slide.slick-center',$slider);

				articleStaggering( $centerElem );

			}).on('beforeChange',function(event, slick, currentSlide, nextSlide){

				const $centerElem = $(`.slick-slide-i_${nextSlide}`,$slider);

				articleStaggering( $centerElem );

			})
			.slick({
				slidesToShow: 5,
				slidesToScroll: 1,
				centerMode: true,
				centerPadding: '0px',
				//infinite: false,
				touchThreshold: 40,
				responsive: [
					{
						breakpoint: bkpts.mb,
						settings: {
							slidesToShow: 1,
							slidesToScroll: 1,
							centerMode: true
						}
					}
				]
			});
	}




	//Functions

  function equalizeThings() {
    //equalize stuff
    $(".bulletin-features").equalizeContent({
      equalizeItem: ".news-box footer",
      useHeight: true
    });
    $(".recommended-reading-tiles").equalizeContent({
      equalizeItem: ".rec-read-tile footer",
      useHeight: true
    });
  }

  function lightBox() {
    if (colorboxScriptingIsAttached) {
      $(".figure-lightbox-btn").colorbox({
        maxWidth: "100%",
        title: function() {
          //the Default title attribute is shit... this is better I think.
          const title = $(this)
            .parent()
            .find("figcaption")
            .text();
          return title;
        }
      });
    }
  }

  function featureArea() {
    if (thereBeSlickSlider) {
      setFeatureArea();

      $(window).on("resize.setFeatureArea", function() {
        resizeThrottle
          ? clearTimeout(resizeThrottle)
          : setTimeout(setFeatureArea, 200);
      });
    }
  }

	function basicArticleHeroResize(){
		const $hero = $('.bulletin-pg-article-basic-hero').find('img');
		const $heroSubtitle = $('.bulletin-pg-article-basic-hero-subtitle');
		let resizeThrottle = null;

		function subtitleResize(){
			resizeThrottle && clearTimeout(resizeThrottle);

            resizeThrottle = setTimeout(function () {
                if ($hero.width() !== null && $hero.width() !== 0) {
                    $heroSubtitle.css({
                        width: $hero.width() + 68
                    });
                }
			},200);
		}

		$(window).on('resize',subtitleResize);
		subtitleResize();
	}
	basicArticleHeroResize();

  function setFeatureArea() {
    winWidth = $(window).width();

    if (winWidth < bkpts.mb) {
      $(".bulletin-features").slick({
        slidesToShow: 1,
        slidesToScroll: 1
      });
    } else {
      $(".bulletin-features.slick-initialized").slick("unslick");
    }

    if (winWidth > bkpts.mb && winWidth < bkpts.dk) {
      $($(".bulletin-pullquote")).insertAfter($pullquoteTableZoneTarget);
    } else {
      if ($pullquoteOriginalTarget.find(".bulletin-pullquote").length == 0) {
        $pullquoteOriginalTarget.append($(".bulletin-pullquote"));
        //some reason 'unslick' isn't working exactly
        //so we need to manually remove the crap it adds
        $(".bulletin-pullquote.slick-slide").attr({
          "data-slick-index": "",
          style: "",
          tabindex: "",
          role: "",
          "aria-describedby": ""
        });
      }
    }
  }
});
