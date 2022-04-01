 // Set the date we're counting down to
var targetDate = document.getElementById("cd-targetDate").value;
var countDownDate = new Date(targetDate).getTime();

// Update the count down every 1 second
var x = setInterval(function() {

    // Get today's date and time
    var now = new Date().getTime();
     
    // Find the distance between now and the count down date
    var distance = countDownDate - now;
     
    // Time calculations for days, hours, minutes and seconds
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var daysDisp = (days < 10) ? ("" + 0 + days) : days; 
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var hoursDisp = (hours < 10) ? ("" + 0 + hours) : hours;
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var minutesDisp = (minutes < 10) ? ("" + 0 + minutes) : minutes;
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);
    var secondsDisp = (seconds < 10) ? ("" + 0 + seconds) : seconds;
	     
    // Output the result in an element with id="demo"
    document.getElementById("cd-clockdown").innerHTML = daysDisp + "<sub>Days</sub>" + hoursDisp + "<sub>Hours</sub>" + minutesDisp + "<sub>Minutes</sub>" + secondsDisp + "<sub>Seconds</sub>";
     
    // If the count down is over, write some text
  if (distance < 0) {
      clearInterval(x);
      document.getElementById("cd-clockdown").innerHTML = "EXPIRED";
  }
}, 1000);
