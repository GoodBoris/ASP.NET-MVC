$(function () {
    $.ajaxSetup({ cache: false });
    if ($(".alert").hasClass("alert-dismissable")) {
        var timer = window.setTimeout(function () {
            $(".alert").fadeTo(1000).slideUp(1000, function () {
                $(this).remove();
            });
        }, 3000);
        $(document).on("click", "[data-dismiss]", function () {
            if (timer != null) {
                clearTimeout(timer);
                $(this).closest("." + $(this).attr("data-dismiss")).remove();
            }
        });
    }
    return;
});
