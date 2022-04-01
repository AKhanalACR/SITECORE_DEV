var slideIndex = 0;
if (screen.width > 1199) {
    showSlidesDesktop(slideIndex);
} else if (screen.width > 767) {
    showSlidesTablet(slideIndex);
} else {
    showSlidesMobile(slideIndex);
}

window.addEventListener("resize", resizeCorousel);
function resizeCorousel() {
    if (screen.width > 1199) {
        showSlidesDesktop(slideIndex);
    } else if (screen.width > 767) {
        showSlidesTablet(slideIndex);
    } else {
        showSlidesMobile(slideIndex);
    }
}

function plusSlides(n) {
    if (screen.width > 1199) {
        showSlidesDesktop((slideIndex += n));
    } else if (screen.width > 767) {
        showSlidesTablet((slideIndex += n));
    } else {
        showSlidesMobile((slideIndex += n));
    }
}

function showSlidesDesktop(n) {
    var i;
    var slides = document.getElementsByClassName("slideCustomCarousel");   

    if (n > slides.length - 1) {
        slideIndex = 0;
    }
    if (n < -2) {
        slideIndex = slides.length - 3;
    }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    if (slides.length > 2) {
        document.getElementById("1").style.display = "none";
        document.getElementById("2").style.display = "none";
    }
    if (slides.length > 3) {
        switch (slideIndex) {
            case -1:
                slides[slides.length - 1].style.display = "block";
                document.getElementById("1").style.display = "block";
                document.getElementById("2").style.display = "block";
                break;
            case -2:
                slides[slides.length - 1].style.display = "block";
                slides[slides.length - 2].style.display = "block";
                document.getElementById("1").style.display = "block";
                break;
            case slides.length - 1:
                slides[slides.length - 1].style.display = "block";
                document.getElementById("1").style.display = "block";
                document.getElementById("2").style.display = "block";
                break;
            case slides.length - 2:
                slides[slides.length - 1].style.display = "block";
                slides[slides.length - 2].style.display = "block";
                document.getElementById("1").style.display = "block";
                break;
            default:
                slides[slideIndex].style.display = "block";
                slides[slideIndex + 1].style.display = "block";
                slides[slideIndex + 2].style.display = "block";
            // code block
        }
    }
    else {
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "block";
        }
    }
   
}
function showSlidesTablet(n) {
    var i;
    var slides = document.getElementsByClassName("slideCustomCarousel");   
    if (n > slides.length - 1) {
        slideIndex = 0;
    }
    if (n < -1) {
        slideIndex = slides.length - 2;
    }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    if (slides.length > 2) {
        document.getElementById("1").style.display = "none";
        document.getElementById("2").style.display = "none";
        switch (slideIndex) {
            case -1:
                slides[slides.length - 1].style.display = "block";
                document.getElementById("1").style.display = "block";
                break;
            case slides.length - 1:
                slides[slides.length - 1].style.display = "block";
                document.getElementById("1").style.display = "block";
                break;
            default:
                slides[slideIndex].style.display = "block";
                slides[slideIndex + 1].style.display = "block";
            // code block
        }
    }
    else {
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "block";
        }
    }
    
}
function showSlidesMobile(n) {
    var i;
    var slides = document.getElementsByClassName("slideCustomCarousel");
    if (slides.length > 2) {
        document.getElementById("1").style.display = "none";
        document.getElementById("2").style.display = "none";
    }

    if (n > slides.length - 1) {
        slideIndex = 0;
    }
    if (n < 0) {
        slideIndex = slides.length - 1;
    }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    slides[slideIndex].style.display = "block";
    // code block
}