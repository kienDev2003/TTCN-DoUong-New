var endShiftData = []
const PageSize = 7;
let PageIndex = 1;
function load() {
    
        $.ajax({
            type: "POST",
            url: "ketca.aspx/GetIngredients",
            data: JSON.stringify({}),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                endShiftData = response.d;
                renderTable(endShiftData, PageIndex)  
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });           
}
    function renderTable(endShiftData) {
        const start = (PageIndex - 1) * PageSize;
        const end = start + PageSize;
        const currentEmployees = endShiftData.slice(start, end); // Lấy dữ liệu trang hiện tại
    
        const tableBody = document.getElementById('endShiftTable');
        tableBody.innerHTML = ""; // Xóa nội dung cũ
        currentEmployees.forEach(item => {
            const row = document.createElement('tr');
            row.innerHTML = `
            <tr>
            <td>${item.Name}</td>
            <td><input type="number" id="quantity" data-id=${item.IngredientID} value=""  min=0></td>
            <td>${item.UnitName}</td>
        </tr>
    `;  
            tableBody.appendChild(row);
        });
        setupPagination(endShiftData, PageIndex);
    }
    
    function setupPagination(endShiftData) {
        const totalPages = Math.ceil(endShiftData.length / PageSize);
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
    // Xử lý sự kiện "Quay lại"
    document.getElementById("backButton").addEventListener("click", () => {
        window.location.href = "index.aspx";
    });
//hàm thay đổi số lượng 

function end() {
    Swal.fire({
        title: 'Thông báo!',
        text: 'Bạn có chắc chắn muốn Lưu?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'OK',
        cancelButtonText: 'Hủy'
    }).then((result) => {
        if (result.isConfirmed) {
            var QuantityData = []
            var quatityImport = document.querySelectorAll('#quantity')
            quatityImport.forEach(item => {
                QuantityData.push({
                    IngredientID: item.dataset.id,
                    ActualQuantity: parseInt(item.value) || 0
                })
            })
            $.ajax({
                type: "POST",
                url: "ketca.aspx/Add",
                data: JSON.stringify({ InventoryDetails: QuantityData }),
                contentType: "application/json",
                dataType: "Json",
                success: function (response) {
                    if (response.d === true) {
                        window.location.href = "./"
                    }
                },
                error: function (a, b, error) {
                    console.log("Error sending data:", error);
                }
            });
        }
    })
}


    