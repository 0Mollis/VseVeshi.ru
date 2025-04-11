// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function scrollCatalog(direction) {
    let scrollAmount = 0;
    let catalog = document.querySelector('.catalog');

    let itemWidth = catalog.querySelector('.catalog-item').offsetWidth + 35.2; // 35.2 - это margin
    scrollAmount += direction * itemWidth;
    // Защита от прокрутки за границы
    let maxScroll = catalog.scrollWidth - catalog.parentNode.clientWidth;
    if (scrollAmount < 0) {
        scrollAmount = 0;
    } else if (scrollAmount > maxScroll) {
        scrollAmount = maxScroll;
    }
    // Устанавливаем новое положение каталога
    catalog.style.transform = `translateX(-${scrollAmount}px)`;
}

if (document.querySelector('.quantity-col') != null) {
check_quantity();
function quantity_plus() {
    var quantity = document.querySelector('.quantity-col');
    var maxquantity = document.querySelector('.maxquantity');
    quantity.textContent = Number(quantity.textContent) + 1;
    check_quantity();
}

function check_quantity() {
    var quantity = document.querySelector('.quantity-col');
    var btn = document.querySelector('.button-quantity')
    var mbtn = document.querySelector('.mbutton-quantity')
    var maxquantity = document.querySelector('.maxquantity');
    if (Number(quantity.textContent) + 1 > maxquantity.textContent) {
        btn.disabled = true;
        btn.classList.remove('quantity-plus');
        btn.classList.add('quantity-min');
    }
    else {
        btn.disabled = false;
        btn.classList.add('quantity-plus')
    }
    if (Number(quantity.textContent) - 1 < 1) {
        mbtn.disabled = true;
        mbtn.classList.remove('quantity-plus');
        mbtn.classList.add('quantity-min');
    }
    else {
        mbtn.disabled = false;
        mbtn.classList.add('quantity-plus')
    }
}
}


function quantity_minus() {
    var quantity = document.querySelector('.quantity-col');
    var maxquantity = document.querySelector('.maxquantity');
    quantity.textContent = Number(quantity.textContent) - 1;
    check_quantity();
}




function getQuery(name) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(name);
}

//const SearchCatalog = (query,selectedCategory) => {
//        $.ajax({
//        url: 'api/catalog',
//        method: 'GET',
//            data: {query : query, category : selectedCategory}
//    }).done(function (data) {
//        for(cat of data)
//        {
//            console.log(cat);
//        }
//    })
//}

function haveCategory(query) {
    var url = window.location.search.substring(1);
    var pair = url.split("=");
    if (pair[0] == query) { return 1; }
    else { return 0; }
}

var selectedCategory = getQuery('category'); //Функция для извлечения значения
$(document).on('click', 'button[data-id="search_catalog-btn"]', function (e) {
    e.preventDefault();
    var query = $('input[data-id="search_catalog-input"]').val();
    if (haveCategory("category")) {
        window.location.href = `/Catalog?category=${getQuery('category')}&search=${query}&SelectDate=0&SelectPrice=0&SelectBrand=0&SelectColor=0&SelectGender=0`;
    }
    else {
        window.location.href = `/Catalog?search=${query}&SelectDate=0&SelectPrice=0&SelectBrand=0&SelectColor=0&SelectGender=0`;
    }

})

//var selectedCategory = getQuery('category'); //Функция для извлечения значения
//$(document).on('click', 'button[data-id="search_catalog-btn"]', function (e) {
//    e.preventDefault();
//    var query = $('input[data-id="search_catalog-input"]').val();
//    $('input[data-id="search_catalog-input"]').val('');
//    SearchCatalog(query, selectedCategory);
//})

$(document).on('click', 'button[data-id="search_index-btn"]', function (e) {
    var query = $('input[data-id="search_index-input"]').val();
    window.location.href = `Catalog?Search=${query}&SelectDate=0&SelectPrice=0&SelectBrand=0&SelectColor=0&SelectGender=0`;
})

$(document).on('click', 'a[class="ahref"]', function (e) {
    e.preventDefault();
    var cat = e.currentTarget.id;
    window.location.href = `/Catalog?category=${cat}&SelectDate=0&SelectPrice=0&SelectBrand=0&SelectColor=0&SelectGender=0`;
})

function itsCatalog() {
    if (window.location.pathname == "/Catalog") {
        $('.select-date').val(getQuery("SelectDate"));
        $('.select-cost').val(getQuery("SelectPrice"));
        $('.select-brand').val(getQuery("SelectBrand"));
        $('.select-color').val(getQuery("SelectColor"));
        $('.select-pol').val(getQuery("SelectGender"));

        //var url = window.location.search;
        //url = url.split("&");
        //if (!haveCategory("search")) {
        //    url = url.slice(1).join("=");
        //    url = url.split("=");
        //    url = url.filter((element, index) => index % 2 != 0);
        //    filtr(url);
        //} 
        //else if (haveCategory("category") && getQuery("search") == "") {
        //    url = url.slice(2).join("=");
        //    url = url.split("=");
        //    url = url.filter((element, index) => index % 2 != 0);
        //    filtr(url);
        //}
        //else if (haveCategory("category") && getQuery("search") != "") {
        //    url = url.slice(2).join("=");
        //    url = url.split("=");
        //    url = url.filter((element, index) => index % 2 != 0);
        //    filtr(url);
        //} 
        //console.log(url);
    }
}
itsCatalog();

//function filtr(url) {
//    $('.select-date').val(url[0]);
//    $('.select-cost').val(url[1]);
//    $('.select-brand').val(url[2]);
//    $('.select-color').val(url[3]);
//    $('.select-pol').val(url[4]);
//}

$(document).on('click', 'button[id="filtr"]', function () {
    var selectDate = $('.select-date').val();
    var selectPrice = $('.select-cost').val();
    var selectBrand = $('.select-brand').val();
    var selectColor = $('.select-color').val();
    var selectGender = $('.select-pol').val();
    var query = "";

    if (haveCategory("category")) {
        window.location.href = `/Catalog?category=` + getQuery("category") + `&search=${query}&SelectDate=${selectDate}&SelectPrice=${selectPrice}&SelectBrand=${selectBrand}&SelectColor=${selectColor}&SelectGender=${selectGender}`;
    }   
    else {
        window.location.href = `/Catalog?search=${query}&SelectDate=${selectDate}&SelectPrice=${selectPrice}&SelectBrand=${selectBrand}&SelectColor=${selectColor}&SelectGender=${selectGender}`;
    } 
})

$(document).on('click', '.menu-btn', function () {
    this.classList.toggle('active');
    var menu = document.querySelector(".menu");
    menu.classList.toggle('active');
})
$(document).on('click', '.inmenu-btn', function () {
    var menu = document.querySelector(".menu");
    var menuBtn = document.querySelector(".menu-btn");
    menu.classList.toggle('active');
    menuBtn.classList.toggle('active');
})

$(document).on('click', '.search-id-btn', function () {
    var selected = $('.select-id').val();
    var input = $('input[data-id="input-id"]').val();

    if (selected != 0 && input != "") {
        $('.error').addClass('visible');
    }
    else if (selected != 0) {
        window.location.href = `/Edit?id=${selected}`;
    }
    else if (input != "") {
        window.location.href = `/Edit?id=${input}`;
    }
})

$(document).on('click', 'input[data-id="itemBtnPost"]', function () {
    var itemPrice = $('input[data-id="itemPrice"]').val();
    var itemDate = $('select[data-id="itemDate"]').val();
    var itemName = $('input[data-id="itemName"]').val();
    var itemDescription = $('input[data-id="itemDescription"]').val();
    var itemQuantity = $('input[data-id="itemQuantity"]').val();
    var itemCatalog = $('input[data-id="itemCatalog"]').val();
    var itemImage = $('input[data-id="itemImage"]').val();
    var itemType = $('input[data-id="itemType"]').val();
    var itemBrand = $('input[data-id="itemBrand"]').val();
    var itemColor = $('input[data-id="itemColor"]').val();
    var itemGender = $('input[data-id="itemGender"]').val();

    if (itemDate != 0) {
        $.ajax({
            method: 'POST',
            url: 'api/addItem/addNewItem',
            contentType: 'application/json',
            data: JSON.stringify({
                Price: itemPrice,
                Days: itemDate,
                Description: itemDescription,
                quantity: itemQuantity,
                catalogs: itemCatalog,
                img: itemImage,
                Name: itemName,
                brand: itemBrand,
                color: itemColor,
                gender: itemGender,
                type: itemType
            })
        })
    }
})

$(document).on('click', 'button[data-action="Item_to_cart"]', function () {
    var itemsId = $('div[data-id]').attr('data-id');
    var itemsQuantity = $('span[data-id="quantity"]').text();
    itemsId = parseInt(itemsId, 10);
    itemsQuantity = parseInt(itemsQuantity, 10);

    $.ajax({
        url: '/api/Cart',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            itemId: itemsId,
            itemQuantity: itemsQuantity
        })
    })
})

function calcPrice() {
    var allPricesArr = [];
    var fullPrice = 0;

    $('div[data-id="cards"]').each(function () {
        var priceElement = $(this).find('.cartPrice');
        var price = parseFloat(priceElement.text());
        allPricesArr.push(price);
    }) 

    for (var p of allPricesArr) {
        fullPrice += p;
    }

    $('span[data-id="priceAll"]').text(fullPrice);
}

function checkQuantity() {
    $('div[data-id="cards"]').each(function () {
        var itemQuantity = $(this).find('.quantity-col').text();
        var itemMaxQuantity = $(this).find('.maxquantity').text();
        console.log(itemQuantity + ' ' + itemMaxQuantity);
        if (itemQuantity == itemMaxQuantity) {
            $(this).find('button[data-id="quantity_plus"]').attr('disabled', 'disabled');
            $(this).find('button[data-id="quantity_plus"]').addClass('quantity-min');
        }
        else {
            $(this).find('button[data-id="quantity_plus"]').removeAttr('disabled');
        }
        if (itemQuantity == 1) {
            $(this).find('button[data-id="quantity_minus"]').attr('disabled', 'disabled');
            $(this).find('button[data-id="quantity_minus"]').addClass('quantity-min');
        }
        else {
            $(this).find('button[data-id="quantity_minus"]').removeAttr('disabled');
        }
    })
}

if (window.location.pathname == '/Cart') {
    showCart();
}

function showCart() {
    $.ajax({
        url: '/api/Cart',
        method: 'GET',
    }).done((data) => {
        var list = '';

        $.each(data, function () {
            list += `
            <div class="d-flex justify-content-between flex-column w-75" data-id="cards">
                <div>
                    <img class="cart-img-size" src="${this.rentItems.img}">
                    <span class="item-card-name">${this.rentItems.name}</span>
                </div>
                <div class="d-flex justify-content-between">
                    <div class="d-flex align-items-end">
                        <div class="mt-2 d-flex flex-column">
                            <span class="arend-giver">Арендодатель:</span>
                            <span class="arend-giver-name">Димон</span>
                        </div>
                    </div>
                    <div class="d-flex flex-column align-items-end">
                        <button class="btn-delite mb-4" data-action="Remove"><img src="Images/close.svg"></button>
                        <div class="d-flex flex-row">
                            <button class="quantity-plus d-flex align-items-center mbutton-quantity" data-id="quantity_minus"><img src="Images/minus.svg"></button>
                            <span class="mx-2 quantity-col" data-id="${this.rentItems.id}">${this.quantity}</span>
                            <button class="quantity-plus d-flex align-items-center button-quantity" data-id="quantity_plus"><img src="Images/plus.svg"></button>
                        </div>
                        <div class="d-flex">
                            <span class="how-have cart-font-size">Доступно</span><span class="maxquantity how-have mx-1 cart-font-size" data-id="${this.rentItems.quantity}">${this.rentItems.quantity}</span>
                        </div>
                        <span class="mt-3 chost-font">Аренда</span>
                        <span class="cartPrice" data-id="${this.rentItems.price * this.quantity}">
                            ${this.rentItems.price * this.quantity}
                        </span>
                    </div>
                </div>
                <hr class="w-100 hr-color">
            </div>`;
        })
        if (list != "") {
            list += `<div class="d-flex flex-column w-75">
            <div class="d-flex justify-content-between my-3 align-items-center">
                <span>Расчётная стоимость</span>
                <div class="d-flex flex-column align-items-end">
                    <span class="chost-font">Аренда</span>
                    <span data-id="priceAll">
                        9999
                    </span>
                </div>
            </div>
            
            <hr class="w-100 hr-color">
        </div>
    </div>
    <div>
        <div class="d-flex flex-column">
            <div class="form-check">
                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                <label class="form-check-label" for="flexRadioDefault1">
                    Самовывоз
                </label>
            </div>
            <span class="cart-font-size how-have-color">С адреса: г Пенза, ул Новосёловка, д 5</span>
        </div>
        <div class="form-check mt-2">
            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2">
            <label class="form-check-label" for="flexRadioDefault2">
                Доставка по г. Пенза
            </label>
        </div>
        <div class="mt-3">
            <button class="btn-color btn p-2 chose-date">Выберите дату и время</button>
        </div>
        <div class="mt-4">
            <button class="btn btn-warning btn-cart-text py-2">
                Арендовать
            </button>
        </div>`;
            $('div[data-id="cart_Place"]').html(list);
            calcPrice();
            checkQuantity();
        }
        else {
            list += '<h2><font color="gray">Корзина пуста</font></h2>';
            $('div[data-id="cart_Place"]').addClass('clearCart');
            $('div[data-id="cart_Place"]').html(list);
        }
    })
}

$(document).on('click', 'button[data-id="quantity_plus"]', function () {
    var itemsId = $(this).parent().find('.quantity-col').data('id');
    var itemsMaxQuantity = $(this).parent().parent().find('.maxquantity').data('id');

    $.ajax({
        url: '/api/Cart',
        method: 'POST',//                        Увеличить quantity по кнопке
        contentType: 'application/json',
        data: JSON.stringify({
            itemId: itemsId,
            itemQuantity: itemsMaxQuantity
        })
    }).done(function () {
        showCart();
    })
})

$(document).on('click', 'button[data-id="quantity_minus"]', function () {
    var itemsId = $(this).parent().find('.quantity-col').data('id');
    var remove = 0;

    $.ajax({
        url: '/api/Cart/remove',//                       Уменьшить Quantity по кнопке
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            itemId: itemsId,
            removeBool: remove
        })
    }).done(function () {
        showCart();
    })
})
$(document).on('click', 'button[data-action="Remove"]', function () {
    var itemsId = $(this).parent().find('.quantity-col').data('id');
    var remove = 1;

    $.ajax({
        url: '/api/Cart/remove',
        method: 'POST',//                 Удалить записть из БД Cart
        contentType: 'application/json',
        data: JSON.stringify({
            itemId: itemsId,
            removeBool: remove
        })
    }).done(function () {
        showCart();
    })
})
