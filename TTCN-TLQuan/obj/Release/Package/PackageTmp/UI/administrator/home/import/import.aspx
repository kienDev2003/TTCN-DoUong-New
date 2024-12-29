<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="import.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.import.import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product {
            border: 1px solid #ddd;
            padding: 10px;
            margin-bottom: 10px;
        }

        button {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 15px;
            cursor: pointer;
            height: fit-content;
            width: auto;
            margin: auto 20px;
            border-radius: 10px;
        }

            button:hover {
                background-color: #45a049;
            }

        #total {
            text-align: end;
            margin-right: 10px;
            font-weight: bold;
            margin-top: 20px;
        }

        input[type="number"] {
            height: 25px;
            border-radius: 10px;
        }

        .cart-item input {
            flex: 1;
            max-width: 50px;
            text-align: center;
        }

        input[type="button"] {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 15px;
            cursor: pointer;
            height: fit-content;
            width: auto;
            margin: auto 10px;
            border-radius: 10px;
            float: right;
        }

        .cart-container {
            max-height: 490px; /* Điều chỉnh chiều cao tối đa */
            overflow-y: auto;
        }

        input[type="number"] {
            height: 25px;
            border-radius: 10px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

            table th,
            table td {
                border: 1px solid #ddd;
                text-align: center;
                padding: 10px;
            }

            table th {
                background-color: #657a71;
                color: white;
                font-weight: bold;
            }

            table tbody tr:nth-child(even) {
                background-color: #f9f9f9;
            }

        .product h2 {
            font-size: 40px;
        }

        .product p {
            font-size: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container_child" style="display: flex; justify-content: space-between;">
        <div class="cart-container" id="listingredient" runat="server" style="width: 30%;">
            <div class="product" style="display: flex; flex-direction: row; margin-top: 10px;">
                <div>
                    <h2>Táo</h2>
                    <p>200</p>
                </div>
                <input type="button" onclick="AddIngredient(1,200,'Táo',2,'g')" value="+">
            </div>
            <div class="product" style="display: flex; flex-direction: row;">
                <div>
                    <h2>Nước Trà</h2>
                    <p>100</p>
                </div>
                <input type="button" onclick="AddIngredient(2,100,'Nước Trà',4,'ml')" value="+">
            </div>
        </div>
        <div class="cart-container" style="width: 69%;">
            <table>
                <thead>
                    <tr>
                        <th>Tên nguyên liệu</th>
                        <th>Số lượng</th>
                        <th>Đơn vị tính</th>
                        <th>Đơn giá</th>
                        <th>Chức Năng</th>

                    </tr>
                </thead>
                <tbody id="cart">
                </tbody>
            </table>
            <div class="total">
                <p id="total">Tổng: 0 VND</p>
                <input type="button" onclick="ImportClick()" value="Nhập hàng">
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>

        // Giỏ hàng
        let cart = [];
        let total = 0;

        // Cập nhật giao diện giỏ hàng
        function updateCart() {

            const cartList = document.getElementById('cart');
            const totalDisplay = document.getElementById('total');

            // Xóa danh sách hiện tại
            cartList.innerHTML = '';

            // Hiển thị từng sản phẩm trong giỏ hàng
            cart.forEach(item => {
                const li = document.createElement('tr');
                li.className = 'cart-item';

                li.innerHTML = `
              <td>${item.Name}</td>
              <td>
                <input type="number" min="1" value="${item.Quantity}" class="quantity-input" onchange="updateQuantity(${item.IngredientID}, this.value)" oninput="this.value = this.value.replace(/[^0-9]/g, '').replace(/^0+/, '');">
                </td>
              <td>${item.UnitName}</td>
              <td>${item.Price.toLocaleString()} VND</td>
                <td>
                    <input type="button" class="remove-item" onclick="removeFromCart(${item.IngredientID})" value="Xóa">
                </td>
             
            `;
                cartList.appendChild(li);
            });

            // Cập nhật tổng
            totalDisplay.textContent = `Tổng: ${total.toLocaleString()} VND`;

        }

        // Thêm sản phẩm vào giỏ hàng
        function AddIngredient(IngredientID, Price, Name, UnitID, UnitName) {
            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            const existingItem = cart.find(item => item.IngredientID === IngredientID);

            if (existingItem) {
                // Nếu đã có, tăng số lượng
                existingItem.Quantity += 1;
            } else {
                // Nếu chưa có, thêm sản phẩm mới
                cart.push({ IngredientID, UnitID, Name, Price, UnitID, UnitName, Quantity: 1 }); // Lưu giá trị dvi
            }

            // Cập nhật tổng tiền
            total += Price;

            // Cập nhật giao diện
            updateCart();
        }

        // Xóa sản phẩm khỏi giỏ hàng
        function removeFromCart(IngredientID) {
            const itemIndex = cart.findIndex(item => item.IngredientID === IngredientID);

            if (itemIndex !== -1) {
                const item = cart[itemIndex];

                // Cập nhật tổng tiền
                total -= item.Price * item.Quantity;

                // Xóa sản phẩm khỏi giỏ hàng
                cart.splice(itemIndex, 1);

                // Cập nhật giao diện
                updateCart();
            }
        }

        // Cập nhật số lượng sản phẩm
        function updateQuantity(IngredientID, newQuantity) {
            const item = cart.find(item => item.IngredientID === IngredientID);

            if (item) {
                // Kiểm tra nếu giá trị nhập không hợp lệ hoặc nhỏ hơn 1
                if (isNaN(newQuantity) || newQuantity < 1) {
                    alert("Số lượng phải là số hợp lệ và lớn hơn hoặc bằng 1.");
                    updateCart(); // Khôi phục lại giá trị cũ
                    return;
                }

                // Tính toán sự chênh lệch trong số lượng
                const difference = Number(newQuantity) - item.Quantity;

                // Cập nhật tổng tiền
                total += item.Price * difference;

                // Cập nhật số lượng
                item.Quantity = Number(newQuantity);

                // Cập nhật giao diện
                updateCart();
            }
        }

        function ImportClick() {
            $.ajax({
                type: "POST",
                url: "import.aspx/Add",
                data: JSON.stringify({ ImportDetails: cart, TotalMoney: total }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d === true) { window.location.href = "./"; }
                    else { alert("co loi xay ra") }
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        }
    </script>
</asp:Content>
