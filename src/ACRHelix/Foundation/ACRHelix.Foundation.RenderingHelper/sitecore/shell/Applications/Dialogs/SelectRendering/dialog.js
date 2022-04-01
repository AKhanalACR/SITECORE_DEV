document.addEventListener('DOMContentLoaded', function () {
	var tabStrip = jQuery(".scTabstrip").children().length;
	if(tabStrip > 0){
  var iFrame = parent.document.getElementById("scContentIframeId0");
  if (iFrame)
    {
    iFrame.style.height = "620px";
    }
  jQuery(".scTabstrip").css('height','123px');
  jQuery(".scTabstrip").css('background-color', 'gray');
  jQuery(".scTabPage").css('top', '80px');
  jQuery('nobr').css('white-space', 'inherit');
  jQuery(".scTabstrip").click(function () { setTimeout(function () { jQuery(".scScrollbox").css('height', '100%') }, 500) });
	} else {
	  jQuery(".scTabstripContainer").hide();
	}
}, false);