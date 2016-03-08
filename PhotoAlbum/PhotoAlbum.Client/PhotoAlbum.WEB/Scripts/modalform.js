
$(function () {
    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
            $.validator.unobtrusive.parse(this);
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {
    var bar = $('.progress-bar');
    var percent = $('.progress-bar');
    function showResponse(responseText) {
        if (responseText.success) {
            var percentValue = '100%';
            bar.width(percentValue);
            percent.html(percentValue);
            $('#myModal').modal('hide');
            $('#prog').hide();
            location.reload(true);
        } else {
            $('#prog').hide();
            $('#myModalContent').html(responseText);
            $.validator.unobtrusive.parse(dialog);
            bindForm(dialog);
        }
    }

    var options = {
        url: this.action,
        type: this.method,
        data: $(this).serialize(),
        success: showResponse,
        beforeSend: function() {
            var percentValue = '0%';
            bar.width(percentValue);
            percent.html(percentValue);
        },
        uploadProgress: function upl(event, position, total, percentComplete) {
            var percentValue = percentComplete + '%';
            bar.width(percentValue);
            percent.html(percentValue);
        }
    }

    $('form', dialog).submit(function () {
        $('#prog').show();
        if (!$(this).valid()) {
            $('#prog').hide();
            return false;
        }
        $(this).ajaxSubmit(options);
        return false;
    });
}