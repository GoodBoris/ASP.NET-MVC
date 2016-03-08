//Set sort order value to browser cookie
function sort(e) {
    $.cookie.raw = true;
    $.cookie('sortby', e.value, {
        expires: 7,
        path: '/'
    });
    location.reload();
}

$(function () {
    //Set Sort Order by default sorting prop if no cookies in browser
    if ($.cookie('sortby') == null) {
        $('[name=sorting][value="1"]').prop('checked', true);
    }

    //Get sort order from cookies
    if (!$("[name=sorting]:checked").length) {
        $("[name=sorting]").val([$.cookie('sortby')]);
    }
    //Some modifications for dropdown
    $(".dropdown-menu li:contains('" + $('#dropDownDiv').attr('data-model') + "')")
        .addClass('disabled').css("background-color", "#337ab7");
    
    //Set page size as cookie
    $('.dropdown-menu li a').click(function () {
        $.cookie.raw = true;
        $.cookie('pagesize', $(this).text(), {
            expires: 7,
            path: '/'
        });
        location.reload();
    });
});