export default function headerAdButlerServe() {
	if (displayHeaderAd) {


		//var plc187820 = window.plc187820 || 0;
		//$('#header-ad-write').html('<div id="placement_187820_' + plc187820 + '"><\/div>');
		//AdButler.ads.push({
		//	handler: function (opt) {
		//		AdButler.register(165731, 187820, [728, 90], 'placement_187820_' + opt.place, opt);
		//	},
		//	opt: { place: plc187820++, keywords: abkw, domain: 'servedbyadbutler.com', click: 'CLICK_MACRO_PLACEHOLDER' }
		//});

		//ad for RLI pages
		var itemUrl = $(location).attr('href').trim().toLowerCase();
		if ($("#header-ad-write").length > 0) {

			if (!window.AdButler) {
				(function () {
					var s = document.createElement("script");
					s.async = true; s.type = "text/javascript";
					s.src = 'https://servedbyadbutler.com/app.js';
					var n = document.getElementsByTagName("script")[0];
					n.parentNode.insertBefore(s, n);
				}());
			}

			window.AdButler = window.AdButler || {};
			AdButler.ads = AdButler.ads || [];
			var abkw = window.abkw || '';


			if (itemUrl.indexOf('radiology-leadership-institute') != -1) {
				var plc187823 = window.plc187823 || 0;
				$('#header-ad-write').html('<div id="placement_187823_' + plc187823 + '"><\/div>');
				AdButler.ads.push({
					handler: function (opt) {
						AdButler.register(165731, 187823, [728, 90], 'placement_187823_' + opt.place, opt);
					},
					opt: { place: plc187823++, keywords: abkw, domain: 'servedbyadbutler.com', click: 'CLICK_MACRO_PLACEHOLDER' }
				});
			} else { //ad for NON RLI pages
				var plc187820 = window.plc187820 || 0;
				$('#header-ad-write').html('<div id="placement_187820_' + plc187820 + '"><\/div>');
				AdButler.ads.push({
					handler: function (opt) {
						AdButler.register(165731, 187820, [728, 90], 'placement_187820_' + opt.place, opt);
					},
					opt: { place: plc187820++, keywords: abkw, domain: 'servedbyadbutler.com', click: 'CLICK_MACRO_PLACEHOLDER' }
				});
			}
		}

	}
}
