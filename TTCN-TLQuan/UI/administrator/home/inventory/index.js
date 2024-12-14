function btntimkiem(){
    var date = document.getElementById('datePicker').value
    console.log(date)
    var now = new Date();

    // Lấy các phần ngày, tháng, năm, giờ, phút, giây
    var day = String(now.getDate()).padStart(2, '0'); // Ngày (DD)
    var month = String(now.getMonth() + 1).padStart(2, '0'); // Tháng (MM), getMonth() trả về từ 0-11
    var year = now.getFullYear(); // Năm (YYYY)

    var hours = String(now.getHours()).padStart(2, '0'); // Giờ (HH)
    var minutes = String(now.getMinutes()).padStart(2, '0'); // Phút (MM)
    var seconds = String(now.getSeconds()).padStart(2, '0'); // Giây (SS)

    // Định dạng ngày giờ thành DD-MM-YYYY HH:MM:SS
    var formattedDateTime = `${day}-${month}-${year} ${hours}:${minutes}:${seconds}`;

    // Hiển thị kết quả
    console.log("Ngày giờ hiện tại:", formattedDateTime);
    alert("Ngày giờ hiện tại: " + formattedDateTime);
}

    // sua
    function load(){
        const stockData = [
            { Inventory_ID: 1, User_ID: "U001", Inventory_Date: "2024-12-05" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 1, User_ID: "U001", Inventory_Date: "2024-12-05" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 1, User_ID: "U001", Inventory_Date: "2024-12-05" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 1, User_ID: "U001", Inventory_Date: "2024-12-05" },
            { Inventory_ID: 1, User_ID: "U001", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 1, User_ID: "U001", Inventory_Date: "2024-12-05" },
            { Inventory_ID: 2, User_ID: "U001", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 1, User_ID: "U00", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            { Inventory_ID: 2, User_ID: "U002", Inventory_Date: "2024-12-06" },
            
        ];
    renderTable(stockData,PageIndex)  
    }
    const PageSize = 9;
    let PageIndex = 1;
    
    
    function renderTable(stockData) {
        const start = (PageIndex - 1) * PageSize;
        const end = start + PageSize;
        const currentEmployees = stockData.slice(start, end); // Lấy dữ liệu trang hiện tại
    
        const tableBody = document.getElementById('stockTable');
        tableBody.innerHTML = ""; // Xóa nội dung cũ
        currentEmployees.forEach(order => {
            const row = document.createElement('tr');
            row.innerHTML =
            `
                <td>${order.User_ID}</td>
                <td>${order.Inventory_Date}</td>
                <td>
                <a class="button" style="text-decoration: none; color: #007BFF;" href="view.html">
                  
                  <i class="fas fa-eye"></i> 
                </a>
              </td>
            `;
            tableBody.appendChild(row);
        });
        setupPagination(stockData, PageIndex);
    }
    
    function setupPagination(stockData) {
        const totalPages = Math.ceil(stockData.length / PageSize);
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
   function end(){
    endShiftButton = document.getElementById('endShiftButton')
    window.location.href='endshift.html'
    }
    


