<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="import.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.import.import" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Giỏ Hàng</title>
    <link rel="stylesheet" href="styles.css">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

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

        #cart {
            list-style: none;
            padding: 0;
        }

        li {
            border: 1px solid black;
            border-radius: 10px;
            height: 50px;
            width: 100%;
        }

        .cart-item {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px;
            padding-right: 0;
            border-radius: 5px;
            margin-bottom: 10px;
            border-radius: 10px;
            gap: 10px;
        }

            .cart-item span {
                flex: 2;
                text-align: left;
            }

            .cart-item input {
                flex: 1;
                max-width: 50px;
                text-align: center;
            }

        #total {
            text-align: end;
            margin-right: 10px;
            font-weight: bold;
            margin-top: 20px;
        }

        .cart-container {
            padding-left: 20px;
            width: 100%;
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

        input[type="number"] {
            height: 25px;
            border-radius: 10px;
        }
    </style>
</head>

<body style="display: flex; flex-direction: row;">
    <div class="product_list" id="ingredient_content" runat="server" style="width: fit-content;">
        <div class="product" style="display: flex; flex-direction: row; width: fit-content;">
            <div>
                <h2>Trà</h2>
                <p>Giá: 100,000 VND</p>
            </div>
            <input type="button" class="add-to-cart" onclick="" value="+">
        </div>

        <div class="product" style="display: flex; flex-direction: row; width: fit-content;">
            <div>
                <h2>Chanh</h2>
                <p>Giá: 200,000 VND</p>
            </div>
            <input type="button" class="add-to-cart" data-dvi="quả" data-name="Chanh" data-price="100000" value="+">
        </div>
        <div class="product" style="display: flex; flex-direction: row; width: fit-content;">
            <div>
                <h2>Đường</h2>
                <p>Giá: 200,000 VND</p>
            </div>
            <input type="button" class="add-to-cart" data-dvi="gram" data-name="Đường" data-price="200000" value="+">
        </div>
    </div>
    <section class="cart-container">
        <h2>Giỏ Hàng</h2>
        <ul id="cart"></ul>
        <p id="total">Tổng: 0 VND</p>
        <input type="button" value="Nhập hàng">
    </section>
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
                const li = document.createElement('li');
                li.className = 'cart-item';

                li.innerHTML = `
                                  <span>${item.name}</span>
                                  <span>${item.dvi}</span>
                                  <span>${item.price.toLocaleString()} VND</span>
                                  <input type="number" min="1" value="${item.quantity}" class="quantity-input" data-id="${item.id}" oninput="this.value = this.value.replace(/[^0-9]/g, '').replace(/^0+/, '');">

                                  <button class="remove-item" data-name="${item.name}">Xóa</button>
                                `;

                cartList.appendChild(li);
            });

            // Cập nhật tổng
            totalDisplay.textContent = `Tổng: ${total.toLocaleString()} VND`;

            // Thêm sự kiện "Xóa" cho từng nút
            document.querySelectorAll('.remove-item').forEach(button => {
                button.addEventListener('click', () => {
                    const name = button.dataset.name;
                    removeFromCart(name);
                });
            });

            // Thêm sự kiện "Thay đổi số lượng" cho ô nhập
            document.querySelectorAll('.quantity-input').forEach(input => {
                input.addEventListener('input', (event) => {
                    const name = event.target.dataset.name;
                    const newQuantity = parseInt(event.target.value, 10) || 0; // Lấy giá trị hoặc mặc định là 0
                    updateQuantity(name, newQuantity);
                });
            });

        }

        // Thêm sản phẩm vào giỏ hàng
        function addToCart(id, price, dvi) {
            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            const existingItem = cart.find(item => item.name === name);

            if (existingItem) {
                // Nếu đã có, tăng số lượng
                existingItem.quantity += 1;
            } else {
                // Nếu chưa có, thêm sản phẩm mới
                cart.push({ name, price, dvi, quantity: 1 }); // Lưu giá trị dvi
            }

            // Cập nhật tổng tiền
            total += price;

            // Cập nhật giao diện
            updateCart();
        }

        // Xóa sản phẩm khỏi giỏ hàng
        function removeFromCart(name) {
            const itemIndex = cart.findIndex(item => item.name === name);

            if (itemIndex !== -1) {
                const item = cart[itemIndex];

                // Cập nhật tổng tiền
                total -= item.price * item.quantity;

                // Xóa sản phẩm khỏi giỏ hàng
                cart.splice(itemIndex, 1);

                // Cập nhật giao diện
                updateCart();
            }
        }

        // Cập nhật số lượng sản phẩm
        function updateQuantity(name, newQuantity) {
            const item = cart.find(item => item.name === name);

            if (item) {
                // Kiểm tra nếu giá trị nhập không hợp lệ hoặc nhỏ hơn 1
                if (isNaN(newQuantity) || newQuantity < 1) {
                    alert("Số lượng phải là số hợp lệ và lớn hơn hoặc bằng 1.");
                    updateCart(); // Khôi phục lại giá trị cũ
                    return;
                }

                // Tính toán sự chênh lệch trong số lượng
                const difference = newQuantity - item.quantity;

                // Cập nhật tổng tiền
                total += item.price * difference;

                // Cập nhật số lượng
                item.quantity = newQuantity;

                // Cập nhật giao diện
                updateCart();
            }
        }

        // Gắn sự kiện cho nút "Thêm vào giỏ hàng"
        document.querySelectorAll('.add-to-cart').forEach(button => {
            button.addEventListener('click', () => {
                const id = button.dataset.id;
                const price = parseInt(button.dataset.price, 10);
                const dvi = button.dataset.dvi; // Lấy giá trị dvi

                addToCart(id, price, dvi); // Gọi hàm addToCart với cả dvi
                console.log(cart);
            });
        });

        
    </script>
</body>

</html>
