export default function addBookmark(scid) {
	var url = "/MyACRDashboard/AddBookmark/" + encodeURIComponent(scid);
	jQuery.ajax({
		type: "POST", url: url, contentType: "application/json", cache: false, error: function () {
			//alert("error posting to bookmark service.");
		}, success:
		function (data) {
			//alert('post successful');
			//alert(data.Result);
			if (data.Success === false) {
				//alert(data.Message);
				jQuery('.bookmark-link').find('.tip-text').hide();
			}
		}
	});
}

export function deleteBookmark(scid) {
	var url = "/MyACRDashboard/DeleteBookmark/" + encodeURIComponent(scid);
	jQuery.ajax({
		type: "POST", url: url, contentType: "application/json", cache: false, error: function () {
			//alert("error posting to bookmark service.");
		}, success:
		function (data) {
			//alert('post successful');
			//alert(data.Result);
			//alert(data.Message);
		}
	});
}

export function addReccomended(scid) {
	var url = "/MyACRDashboard/AddReccomendedArticle/" + encodeURIComponent(scid);
	jQuery.ajax({
		type: "POST", url: url, contentType: "application/json", cache: false, error: function () { alert("error posting to bookmark service."); }, success:
		function (data) {
			//alert('post successful');
			//alert(data.Result);
			if (data.Success === false) {
				//alert(data.Message);
				jQuery('.reccommend-link').find('.tip-text').hide();
			}
		}
	});
}

export function reccomendClick(link) {
	var authenticated = jQuery(link).parent().attr('data-authenticated');
	if (authenticated == 'true') {
		jQuery(link).find('.tip-text').show();
		var id = jQuery(link).parent().attr('data-sitecore-id');
		addReccomended(id);
	} else {
		//window.location = "/Login-Page?returnUrl=" + window.location.pathname + '?addReccomend=1';

		jQuery(link).find('.tip-text').find('strong').text('Please login to recommend this article');
		jQuery(link).find('.tip-text').find('p').text('The articles you recommend will be added to the "what others are reading" feed on "My ACR".');
		jQuery(link).find('.tip-text').show();
	}
}

export function bookmarkClick(link) {
	var authenticated = jQuery(link).parent().attr('data-authenticated');
	if (authenticated == 'true') {
		jQuery(link).find('.tip-text').show();
		var id = jQuery(link).parent().attr('data-sitecore-id');
		addBookmark(id);
	} else {

		//window.location = "/Login-Page?returnUrl=" + window.location.pathname + '?addBookmark=1';
		jQuery(link).find('.tip-text').find('strong').text('Please login to bookmark this article');
		jQuery(link).find('.tip-text').find('p').text('The pages that you bookmark will be saved to your "my reading list" in My ACR.');
		jQuery(link).find('.tip-text').show();

	}
}
