//The script for checking image size and input data. Also updating image preview.
function validate() {
    $("#upload-file-info").html("Cheking new uploading file..");
    var file = $('#file');
    var path = file.val();
    var reader = new FileReader();
    reader.readAsDataURL(file.prop('files')[0]);
    var fileSize = file[0].files[0].size;
    if (fileSize > 20 * 1024 * 1024) {
        $('input[type="submit"]').prop('disabled', true);
        $("#upload-file-info").html("File size is greater than 20MB");
        return;
    }
    reader.onload = function () {
        var data = reader.result;
        if (data.match(/^data:image\//)) {
            document.getElementsByClassName('img-thumbnail')[0].src = window.URL.createObjectURL(file.prop('files')[0]);
            $('input[type="submit"]').removeAttr('disabled');
            $("#upload-file-info").html(path);
        } else {
            $("#upload-file-info").html("Plase select an image to upload");
            alert('Not an image');
            return;
        }
    };
    $("#upload-file-info").html(path);
    return;
}