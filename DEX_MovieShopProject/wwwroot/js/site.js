// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function Add(movieId) {
    $.ajax({
        type: 'post',
        url: 'Order/AddToCart',
        dataType: 'json',
        data: { id: movieId },
        success: function (count) {
            $('#cartCount').html(count);
        }
    })
}
