var kichthuoc = 200;

//background: #E7E7E7;
var vitri = 0;
var slide = document.getElementsByClassName("chuyen-slide")[0];
var img = document.getElementsByClassName("img");
var max = 1000;
var laptop = document.getElementById("laptop");
var cirleleft = document.getElementById("circle-left");
var cirleright = document.getElementById("circle-right");
$(document).ready(function () {
    if (window.location.pathname == "/BongDa.aspx" || window.location.pathname == "/BangDau.aspx") {
        $('body').css("background", "#E7E7E7");
        $('.head').css("background", "white"); 
        $('.head').css("height", "80px");
        if (window.location.pathname == "/BongDa.aspx") {
            $('.bodyOfBong').css("height", "1000px");
        }
    }
});
$(window).scroll(function () {
    
    
    if ($(window).scrollTop() >= 85) {
        $('.menu-bar').css("position", "fixed");
        $('.menu-bar').css("top", "0");
    } else {
        $('.menu-bar').css("top", 80 - $(window).scrollTop() +"px");
        
        
    }


});

function chao(){       
    window.location = "WebForm1.aspx";
}  


function home(position) {

    if ($(window).scrollTop() == 0 && position == 0) return;
    else $("HTML, BODY").animate({ scrollTop: position }, 800);
    //hide();
    //show(position);
}	  

function changeTitle(name) {
    $('#titleVideo').text(name) ;
}

function slideRight() {
   // alert(vitri + " và " + max );
    
    if (vitri < max) {
        vitri = vitri + kichthuoc + 2;

    } else {
        vitri = 0;

    }

    $('.chuyen-slide').css('margin-left', - vitri + "px");
}
function slideLeft() {

    if (vitri != 0) {
        vitri = vitri - kichthuoc - 2;
        
    } else {
        
        
    }
    $('.chuyen-slide').css('margin-left', - vitri + "px");
}