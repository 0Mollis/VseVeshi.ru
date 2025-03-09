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
