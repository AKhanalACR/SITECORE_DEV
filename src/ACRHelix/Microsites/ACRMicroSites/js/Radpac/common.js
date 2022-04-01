$(document).ready(function(){
		$('div').pngFix();
		$('#searchTxt').blur( function (){
       		toggleTextOut(this,'Search');
		});

		$('#searchTxt').focus( function (){
			   toggleTextIn(this,'Search');
		});
		
		
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