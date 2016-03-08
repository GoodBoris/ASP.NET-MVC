$(function() {
    $.ajaxSetup({
        cache: false
    });
    var cookieEnabled=(navigator.cookieEnabled)? true : false;
    //if navigator,cookieEnabled is not supported
    if (typeof navigator.cookieEnabled == "undefined" && !cookieEnabled) {
        alert("This application does not support your browser!");
        window.close();
        document.cookie="testcookie";
        cookieEnabled=(document.cookie.indexOf("testcookie") !== -1)? true : false;
    }
    if (!cookieEnabled) {
        alert("Please enable cookies first!");
        window.location.replace("/Home/Index");
    } 
});


