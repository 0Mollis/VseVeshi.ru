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




function getQuery(url) {
    var query = window.location.search.substring(1);
    var pair = query.split("=");
    if (pair[0] == url) { return pair[1]; }
}

const SearchCatalog = (query,selectedCategory) => {
        $.ajax({
        url: 'api/catalog',
        method: 'GET',
            data: {query : query, category : selectedCategory}    
    }).done(function (data) {
        for(cat of data)
        {
            console.log(cat);
        }
    })
}

var selectedCategory = getQuery('category'); //Функция для извлечения значения
$(document).on('click', 'button[data-id="search_catalog-btn"]', function (e) {
    e.preventDefault();
    var query = $('input[data-id="search_catalog-input"]').val();
    $('input[data-id="search_catalog-input"]').val('');
    SearchCatalog(query, selectedCategory);
})