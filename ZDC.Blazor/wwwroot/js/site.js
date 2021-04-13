$(window).scroll(function () {
    if (window.$(document).scrollTop() > 50) {
        window.$("#home-nav").removeClass("transparent");
        window.$("#home-nav").addClass("bg-gray-800");
    } else {
        window.$("#home-nav").addClass("transparent");
        window.$("#home-nav").removeClass("bg-gray-800");
    }
});