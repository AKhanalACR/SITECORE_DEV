(function ($) {

	$(document).ready(function () {
		
	});

})(jQuery);

var mslYTPlayerInfo = [];
var mslYTPlayers = {};

function getYouTubePlayerContainers() {
	$('.player-container').each(function () {
		var playerId = $(this).attr('id');
		var videoId = $(this).attr('v');
		mslYTPlayerInfo.push([playerId, videoId]);
	});
}

function createYouTubePlayers() {
	for (var i = 0; i < mslYTPlayerInfo.length; i++) {
		var playerId = "player" + mslYTPlayerInfo[i][0].replace("player-container", "");
		mslYTPlayers[playerId] = new YT.Player(mslYTPlayerInfo[i][0], { height: '100%', width: '100%', videoId: mslYTPlayerInfo[i][1], events: { 'onReady': onPlayerReady, 'onStateChange': onPlayerStateChange} });
	}
}

function onYouTubeIframeAPIReady() {
	getYouTubePlayerContainers();
	createYouTubePlayers();
}

// 4. The API will call this function when the video player is ready.
function onPlayerReady(event) {
	var player = event.target;
	if (player) {
		var togglePlay = (function () {
			if (player.getPlayerState() == YT.PlayerState.PLAYING) { // if it's playing, let's pause
				player.pauseVideo();
			} else { // otherwise, play it!
				player.playVideo();
			}
			return false;
		});
		
		$(player.getIframe())
			.parent(".video,.video-first")
			.next(".arrow-link,.arrow-link-first")
			.click(togglePlay);
	}
}

// 5. The API calls this function when the player's state changes.
function onPlayerStateChange(event) {
	switch (event.data) {
		case YT.PlayerState.PLAYING:
			// Started playing
			getPlayerButton(event.target.getIframe()).addClass("pause-button");
			break;
		case YT.PlayerState.ENDED:
			// Ended
			event.target.cueVideoById(event.target.getVideoUrl().match(/v=([^&]+)/)[1]);
		default:
			getPlayerButton(event.target.getIframe()).removeClass("pause-button");
	}
}

function getPlayerButton(player) {
	return $(player).parent(".video,.video-first").next(".arrow-link,.arrow-link-first");
}

onYouTubeIframeAPIReady();