$(document).ready(function () {
    $('.add-user').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: "Home/AddContact",
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
            }
        });
    });
});