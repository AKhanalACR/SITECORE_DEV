$(document).ready(function () {
	$('div').pngFix();
	$('#searchTxt').blur(function () {
		toggleTextOut(this, 'Search');
	});

	$('#searchTxt').focus(function () {
		toggleTextIn(this, 'Search');
	});

	//Homepage slider
	$(function () {
		$('.slides').slides({
			play: 5000,
			pause: 2500,
			hoverPause: true
		});
	});

	//tooltips for Pledge Page
	$('.help').betterTooltip({
		speed: 150,
		delay: 0
	});

	$('.key-up-validation.pledgefield').keyup(function () { Page_ClientValidate('PledgeFormOnKeyUp'); });

	//Accordion for honor roll
	$('.honorRoll .listWrap .listItem .inner').hide();  //Hide/close all containers

	//on click
	$('.honorRoll .listWrap .listItem h3').click(function () {
		if ($(this).next().is(':hidden')) {
			//If immediate next container is closed...
			//Remove all .open classes and slide up the immediate next container
			$('.honorRoll .listWrap .listItem h3').removeClass('open').next().slideUp();
			//Add .open class to clicked trigger and slide down the immediate next container
			$(this).toggleClass('open').next().slideDown();
		}
		else {
			$(this).toggleClass('open').next().slideUp();
		}
		return false; //Prevent the browser jump to the link anchor
	});

	//Honor Roll Level 'tabs' code
	$('.honorRoll ul.levelNav li').click(function () {
		if ($(this).is('.active')) {
			//do nothing
		} else {
			//Remove other instances of 'active' from the other nav items
			$('.honorRoll ul.levelNav li').removeClass('active');
			//Toggle 'active' on for this nav item
			$(this).toggleClass('active');

			//Remove 'active' from the currently displayed level
			$('.listWrap').removeClass('active');
			
			//Toggle 'active' on for the associated level area
			//get text from the clicked tab, and convert it to something a bit more usable (no spaces, all lowercase)
			var newTarget = '.listWrap.' + $(this).text().replace(/ /g, '').toLowerCase();
			$(newTarget).toggleClass('active');
		}
	});

	

	/*Apply an 'odd' class to every other item of a list on the honor-roll page */
	$(".honorRoll .listWrap .listItem .inner ul li:nth-child(2n+1)").addClass("odd");

});


function toggleTextOut(e,txtval) {
	if(e.value=="") e.value = txtval;
}

function toggleTextIn(e,txtval) {
	if(e.value==txtval) e.value="";
	else e.select();
}

var timeout    = 500;
var closetimer = 0;
var ddmenuitem = 0;


function findPosX(obj) {
	var curleft = 0;
	//alert(obj);
	if(obj.offsetParent)
		while(1) {
		  curleft += obj.offsetLeft;
		  if(!obj.offsetParent)
			break;
		  obj = obj.offsetParent;
		}
	else if(obj.x)
		curleft += obj.x;
	return curleft;
}

function xp_menu_open(){ 
   xp_menu_canceltimer();
   xp_menu_close();
   var xpos=findPosX(this);
   $(this).find('ul').attr('left',xpos-this.offsetWidth);
   ddmenuitem = $(this).find('ul').css('visibility', 'visible');
}

function xp_menu_close(){  
	if(ddmenuitem) ddmenuitem.css('visibility', 'hidden');
}

function xp_menu_timer(){  
	closetimer = window.setTimeout(xp_menu_close, timeout);
}

function xp_menu_canceltimer(){  
	if(closetimer){  
		window.clearTimeout(closetimer);
		closetimer = null;
	}
}

$(document).ready(function(){
	$('#xp_menu > li').bind('mouseover', xp_menu_open)
	$('#xp_menu > li').bind('mouseout',  xp_menu_timer)
});

document.onclick = xp_menu_close;