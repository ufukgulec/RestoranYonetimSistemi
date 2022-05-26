$(document).ready(function () {
    ActiveNav();
});

function ActiveNav() {
    if (window.location.pathname.length > 1) {
        var navs = document.getElementsByClassName("menu-item");
        for (var i = 0; i < navs.length; i++) {
            navs[i].classList.remove("active");
        }
        var selecetedMenu = window.location.pathname.split("/")[1];
        document.getElementsByClassName("nav" + selecetedMenu)[0].classList.add("active");
    }

    else {
        document.getElementById("homenavlink").classList.add("active");
    }
}