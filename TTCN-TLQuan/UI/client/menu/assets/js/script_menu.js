let orderDetails = [];

function getCookie(name) {
    let cookies = document.cookie.split('; ');
    for (let i = 0; i < cookies.length; i++) {
        let [key, value] = cookies[i].split('=');
        if (key === name) return decodeURIComponent(value);
    }
    return null;
}

function addProduct(product) {
    let existingProduct = orderDetails.find(item => item.productId === product.productId);

    if (existingProduct) existingProduct.quantity = Number(existingProduct.quantity) + 1;
    else orderDetails.push(product);
}

function saveOrderDetailsToCookie(nameCookie, timeoutCookie, orderDetails) {
    document.cookie = `${nameCookie}=${encodeURIComponent(JSON.stringify(orderDetails))}; path=/; max-age=${timeoutCookie};`;
}

$(document).on('click', 'div.btnAddItem', function () {
    var buttonId = $(this).attr('tag');
    const parentDes = $(this).closest('.des');

    const nameItem = parentDes.find('.nameItem').text().trim();
    const priceItem = parseInt(parentDes.find('.priceItem').text().trim(), 10);

    $.ajax({
        type: "POST",
        url: "index.aspx/CheckRawMaterial",
        data: JSON.stringify({ productId: buttonId, quantity: 1 }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (respone) {
            if (respone.d === true) {
                addProduct({
                    productId: buttonId,
                    name: nameItem,
                    price: priceItem,
                    quantity: 1,
                });

                saveOrderDetailsToCookie('OrderDetails', 120, orderDetails);

                document.getElementById("cart_quantity").innerText = orderDetails.length;

                toastr.options = {
                    "closeButton": false,      // Hiển thị nút đóng
                    "debug": false,
                    "newestOnTop": true,      // Hiển thị thông báo mới nhất trên cùng
                    "progressBar": true,      // Hiển thị thanh tiến độ
                    "positionClass": "toast-top-right", // Vị trí thông báo ở góc trên bên phải
                    "preventDuplicates": true, // Ngăn thông báo trùng lặp
                    "showDuration": "300",    // Thời gian hiển thị thông báo (300ms)
                    "hideDuration": "1000",   // Thời gian ẩn thông báo
                    "timeOut": 1500,          // Thời gian thông báo tồn tại (2 giây)
                    "extendedTimeOut": "1000",// Thời gian thông báo tồn tại thêm khi người dùng hover vào
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",   // Phương thức hiện thị thông báo
                    "hideMethod": "fadeOut"  // Phương thức ẩn thông báo
                };


                toastr.success(`Sản phẩm "${nameItem}" đã được thêm vào giỏ hàng!`);
            }
            else {
                Swal.fire({ title: 'Thông báo!', text: 'Không đủ nguyên liệu làm sản phẩm. Quý khách vui lòng chọn sản phẩm khác', icon: 'warning', confirmButtonText: 'OK' });
            }
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    let orderDetailsCookie = getCookie('OrderDetails');
    if (orderDetailsCookie) {
        orderDetails = JSON.parse(orderDetailsCookie);
    }
    document.getElementById("cart_quantity").innerText = orderDetails.length;
});
