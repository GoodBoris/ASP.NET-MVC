$(function () {
    //Bind event functions for rating setter and popup
    $("#photos .rateit.set-rating").bind('over', function (event, value) { $(this).attr('title', value); });
    $("#photos .rateit.set-rating").bind('rated', function (event, value) {
        var ri = $(this);
        var photoId = ri.data('photoid');
        $.ajax({
            url: "/Photo/SendRating",
            data: { id: photoId, value: value },
            type: 'POST',
            cache: false,
            success: function (result) {
                if (result.success) {
                    //Update average rating
                    $('#' + photoId).rateit('value', result.averageRating);
                    ri.rateit('readonly', true);
                    ri.append('<span style="color:#2ecc71">' + " Thanks for your vote!" + '</span>');
                    //Set cookies to can not vote again by current user
                    $.cookie.raw = true;
                    $.cookie(photoId, value, {
                        expires: 7,
                        path: '/'
                    });
                } else {
                    ri.html('<span style="color:red">' + "Can not vote now. Try later!" + '</span>');
                }
            }
        });
    });
});