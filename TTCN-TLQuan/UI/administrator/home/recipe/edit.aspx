﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.recipe.edit" %>

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
    <div style="width: 30%;" id="listingredient" runat="server">
        <div class="product" style="display: flex; flex-direction: row;">
            <div>
                <h2>Trà</h2>
                <p>100</p>
            </div>

            <button onclick="AddIngredient(1,2,'Alo',1,'gam')">+</button>
        </div>

        <div class="product" style="display: flex; flex-direction: row;">
            <div>
                <h2>Chanh</h2>
                <p>Giá: 200,000 VND</p>
            </div>

            <button onclick="AddIngredient(2,3,'Loa',2,'kilogram')">+</button>
        </div>
    </div>
    <section class="cart-container">
        <h2>Giỏ Hàng</h2>
        <ul id="cart"></ul>
        <input type="button" onclick="ImportClick()" value="Nhập hàng">
    </section>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        const urlParams = new URLSearchParams(window.location.search);
        const ProductID = urlParams.get('ProductID');

        // Giỏ hàng
        let cart = [];
        let total = 0;

        // Cập nhật giao diện giỏ hàng
        function updateCart() {

            const cartList = document.getElementById('cart');

            // Xóa danh sách hiện tại
            cartList.innerHTML = '';

            // Hiển thị từng sản phẩm trong giỏ hàng
            cart.forEach(item => {
                const li = document.createElement('li');
                li.className = 'cart-item';

                li.innerHTML = `
              <span>${item.Name}</span>
              <span>${item.UnitName}</span>
              <input type="number" min="1" value="${item.QuantityNeed}" class="quantity-input" onchange="updateQuantity(${item.IngredientID}, this.value)" oninput="this.value = this.value.replace(/[^0-9]/g, '').replace(/^0+/, '');">

              <button class="remove-item" onclick="removeFromCart(${item.IngredientID})">Xóa</button>
            `;

                cartList.appendChild(li);
            });
        }

        // Thêm sản phẩm vào giỏ hàng
        function AddIngredient(IngredientID, Name, UnitName) {
            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            const existingItem = cart.find(item => item.IngredientID === IngredientID);

            if (existingItem) {
                // Nếu đã có, tăng số lượng
                existingItem.QuantityNeed += 1;
            } else {
                // Nếu chưa có, thêm sản phẩm mới
                cart.push({ IngredientID, Name, UnitName, QuantityNeed: 1 }); // Lưu giá trị dvi
            }
            // Cập nhật giao diện
            updateCart();
        }

        // Xóa sản phẩm khỏi giỏ hàng
        function removeFromCart(IngredientID) {
            const itemIndex = cart.findIndex(item => item.IngredientID === IngredientID);

            if (itemIndex !== -1) {
                const item = cart[itemIndex];

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
                const difference = Number(newQuantity) - item.QuantityNeed;

                // Cập nhật số lượng
                item.QuantityNeed = Number(newQuantity);

                // Cập nhật giao diện
                updateCart();
            }
        }

        function ImportClick() {
            $.ajax({
                type: "POST",
                url: "edit.aspx/Add",
                data: JSON.stringify({ ProductID: ProductID, recipeDetails: cart }),
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
</body>

</html>
