export default class BackgroundImageLoad {
	constructor(){
		const _ =  this;
		let resizeThrottle = null;

		$(window).on('resize.BackgroundImageLoad',()=>{
			resizeThrottle && clearTimeout(resizeThrottle);

			resizeThrottle = setTimeout(()=>{
				_.loadVisibleImageElem();
			},200);
		});
		_.loadVisibleImageElem();
	}

	loadVisibleImageElem(){
		$('.hero-img-mb,.hero-img-dk').each(function(){
			const $this = $(this);
			const bgImg = $this.data('bg-img');

			if( $this.is(':visible') ){
				$this.css({
					'background-image': `url(${bgImg})`
				});
			}
		});
	}
}
