﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function Add(movieId) {
    $.ajax({
        type: 'Post',
        url: 'Order/AddtoCart',
        dataType: "json",
        data: { id: movieId },
        success: function (count) {
            $('#cartCount').html(count);
            showCart();
        }
    })
}

function showCart() {
    var cartEle = document.getElementById("cartDiv");
    cartEle.classList.remove("notShowCart");
    cartEle.classList.add("showCart");
}


function incrementQuantity(movieId) {
    $.ajax({
        type: 'Post',
        url: 'Order/AddToCart',
        dataType: "json",
        data: { id: movieId },
        success: function (count) {
            $('#cartCount').html(count);
            showCart();
        }
    })
    
}


function decrementQuantity(itemId) {
    var quantityInput = document.getElementById('quantity-' + itemId);
    quantityInput.stepDown();
}