const urlParams = new URLSearchParams(window.location.search);
const OrderID = urlParams.get('OrderID');
function load() {
    var orders_detail = [];
    $.ajax({
        type: "POST",
        url: "orderDetail.aspx/GetAllByOrderID",
        data: JSON.stringify({ OrderID: OrderID }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var orders_detail = response.d;
            renderTable(orders_detail, PageIndex); // Chuyển PageIndex vào đây
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}
const PageSize = 9;
let PageIndex = 1;


function renderTable(orders_detail) {
    const start = (PageIndex - 1) * PageSize;
    const end = start + PageSize;
    const currentEmployees = orders_detail.slice(start, end); // Lấy dữ liệu trang hiện tại

    const tableBody = document.getElementById('table_detail');
    tableBody.innerHTML = ""; // Xóa nội dung cũ
    currentEmployees.forEach(order => {
        const row = document.createElement('tr');
        row.innerHTML = `
        <td>${order.ProductName}</td>
        <td>${order.Quantity}</td>
        <td>${order.TotalMoney}</td>
       
                `;
        tableBody.appendChild(row);
    });
    setupPagination(orders_detail, PageIndex);
}

function setupPagination(orders_detail) {
    const totalPages = Math.ceil(orders_detail.length / PageSize);
    const paginationDiv = document.getElementById('pagination');
    paginationDiv.innerHTML = ""; // Xóa nội dung cũ

    // Tạo nút "Trước"
    const prevPage = document.createElement('a');
    prevPage.href = "#";
    prevPage.textContent = "Trước";
    if (PageIndex === 1) {
        prevPage.classList.add('disabled');
    }
    prevPage.addEventListener('click', function (event) {
        event.preventDefault();
        if (PageIndex > 1) {
            PageIndex--;
            // var txtSearch = document.getElementById("txtSearch").value;
            // if (txtSearch != '' || txtSearch != null) {
            //     btnSearch();
            // }
            // else {
            load(PageIndex);
            // }
        }
    });
    paginationDiv.appendChild(prevPage);

    // Tạo các liên kết trang số
    const totalPagesToShow = 5; // Hiển thị tối đa 5 trang
    let startPage = PageIndex - Math.floor(totalPagesToShow / 2);
    let endPage = PageIndex + Math.floor(totalPagesToShow / 2);

    if (startPage < 1) {
        startPage = 1;
        endPage = totalPagesToShow;
    }
    if (endPage > totalPages) {
        endPage = totalPages;
        startPage = totalPages - totalPagesToShow + 1;
    }
    if (startPage < 1) {
        startPage = 1;
    }
    if (startPage > 1) {
        const firstPage = document.createElement('a');
        firstPage.href = "#";
        firstPage.textContent = "1";
        firstPage.addEventListener('click', function (event) {
            event.preventDefault();
            PageIndex = 1;
            var txtSearch = document.getElementById("txtSearch").value;
            if (txtSearch != '' || txtSearch != null) {
                btnSearch();
            }
            else {
                load(PageIndex);
            }
        });
        paginationDiv.appendChild(firstPage);

        paginationDiv.appendChild(document.createTextNode("..."));
    }

    for (let i = startPage; i <= endPage; i++) {
        const pageLink = document.createElement('a');
        pageLink.href = "#";
        pageLink.textContent = i;
        if (i === PageIndex) {
            pageLink.classList.add('active');
        }

        pageLink.addEventListener('click', function (event) {
            event.preventDefault();
            PageIndex = i;
            // // var txtSearch = document.getElementById("txtSearch").value;
            // if (txtSearch != '' || txtSearch != null) {
            //     btnSearch();
            // }
            // else {
            load(PageIndex);
            // }
        });

        paginationDiv.appendChild(pageLink);
    }

    if (endPage < totalPages) {
        paginationDiv.appendChild(document.createTextNode("..."));

        const lastPage = document.createElement('a');
        lastPage.href = "#";
        lastPage.textContent = totalPages;
        lastPage.addEventListener('click', function (event) {
            event.preventDefault();
            PageIndex = totalPages;
            // var txtSearch = document.getElementById("txtSearch").value;
            // if (txtSearch != '' || txtSearch != null) {
            //     btnSearch();
            // }
            // else {
            load(PageIndex);
            // }
        });
        paginationDiv.appendChild(lastPage);
    }

    // Tạo nút "Tiếp"
    const nextPage = document.createElement('a');
    nextPage.href = "#";
    nextPage.textContent = "Tiếp";
    if (PageIndex === totalPages) {
        nextPage.classList.add('disabled');
    }
    nextPage.addEventListener('click', function (event) {
        event.preventDefault();
        if (PageIndex < totalPages) {
            PageIndex++;
            // var txtSearch = document.getElementById("txtSearch").value;
            // if (txtSearch != '' || txtSearch != null) {
            //     btnSearch();
            // }
            // else {
            load(PageIndex);
            // }
        }
    });
    paginationDiv.appendChild(nextPage);
}
load();