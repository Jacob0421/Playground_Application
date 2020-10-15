
/*
 * 
 * SideNav instructions cann be found at:
 * https://www.w3schools.com/howto/howto_js_sidenav.asp
 * 
 * JS Comments found at:
 * https://www.w3schools.com/js/js_comments.asp 
 */

function OpenSideNav() {
    document.getElementById("SideNav").style.width = "250px";
    document.getElementById("contentContainer").style.marginLeft = "250px";
}

function closeSideNav() {
    document.getElementById("SideNav").style.width = "0";
    document.getElementById("contentContainer").style.marginLeft = "250px";
}