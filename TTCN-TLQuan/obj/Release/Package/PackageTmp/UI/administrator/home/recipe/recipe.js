const PageSize = 7;
let PageIndex = 1;


function btnDelete(productID) {
    Swal.fire({
        title: 'Thông báo!',
        text: 'Bạn có chắc chắn muốn xóa?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'OK',
        cancelButtonText: 'Hủy'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "index.aspx/DeleteRecipeByProductID",
                data: JSON.stringify({ ProductID: productID }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d === true) {
                        load();
                    }
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        }
    });
}
function load() {
    $.ajax({
        type: "POST",
        url: "index.aspx/GetAllNotStatusExistRecipe",
        data: JSON.stringify({}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var products = response.d;
            renderTable(products, PageIndex); // Chuyển PageIndex vào đây
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

function renderTable(products) {
    const start = (PageIndex - 1) * PageSize;
    const end = start + PageSize;
    const currentEmployees = products.slice(start, end); // Lấy dữ liệu trang hiện tại

    const tableBody = document.getElementById('product_load');
    tableBody.innerHTML = ""; // Xóa nội dung cũ
    currentEmployees.forEach(product => {
        const row = document.createElement('tr');
        row.innerHTML = `
                            <td>${product.Name}</td>
                            <td>${product.StatusNotExistRecipe ? 'Đã có công thức' : 'Chưa có công thức'}</td>
                            <td>
                                <a href="edit.aspx?ProductID=${product.ProductID}">Sửa</a>
                                <input type="button" onclick="btnDelete(${product.ProductID})" class="btn" value="Xóa">
                            </td>
                        `;
        tableBody.appendChild(row);
    });
    setupPagination(products, PageIndex);
}

function setupPagination(products) {
    const totalPages = Math.ceil(products.length / PageSize);
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
            //if (txtSearch != '' || txtSearch != null) {
            //    btnSearch();
            //}
            //else {
                load(PageIndex);
            //}
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
            //if (txtSearch != '' || txtSearch != null) {
            //    btnSearch();
            //}
            //else {
                load(PageIndex);
            //}
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
            //var txtSearch = document.getElementById("txtSearch").value;
            //if (txtSearch != '' || txtSearch != null) {
            //    btnSearch();
            //}
            //else {
                load(PageIndex);
            //}
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
            //if (txtSearch != '' || txtSearch != null) {
            //    btnSearch();
            //}
            //else {
                load(PageIndex);
            //}
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
            //if (txtSearch != '' || txtSearch != null) {
            //    btnSearch();
            //}
            //else {
                load(PageIndex);
            //}
        }
    });
    paginationDiv.appendChild(nextPage);
}
load();