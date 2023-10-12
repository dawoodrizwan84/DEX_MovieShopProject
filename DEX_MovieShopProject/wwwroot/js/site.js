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


function decrease() {
    var quantityInput = document.getElementById("quantity");
    var quantity = parseInt(quantityInput.value);

    if (quantity > 1) {
        quantityInput.value = quantity - 1;
    }
}

function increase() {
    var quantityInput = document.getElementById("quantity");
    var quantity = parseInt(quantityInput.value);

    if (quantity < 10) {
        quantityInput.value = quantity + 1;
    }
}

$('.increment').click(function () {
    var goods_num = $(this).siblings('#goods_num').val();
    goods_num++;
    $(this).siblings("#goods_num").val(goods_num);

    var num = $(this).siblings('#goods_num').val();

    // var price = $(this).siblings(".price").text();
    // price=price.substr(1)
    // var sum = (number * price).toFixed(2);
    // $(this).siblings(".sum").text(price*num+'kr')
    // getSun();

})
