<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.pay.bill.index" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>hoaDon</title>
    <link rel="stylesheet" href="hoaDon.css">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .hoaDon {
            background: #fff;
            width: 300px;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .ten {
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .diaChi,
        .phone,
        .hoaDon-so,
        .ngayTao,
        .thuNgan,
        .noiThanhToan {
            font-size: 15px;
            margin: 5px 0;
        }

        .hoaDon-tieuDe {
            font-size: 16px;
            font-weight: bold;
            margin: 10px 0;
        }

        .items_table {
            width: 100%;
            border-collapse: collapse;
            margin: 10px 0;
            font-size: 12px;
            border-top: 1px solid black;
            border-bottom: 1px solid black;
        }

            .items_table thead {
                border-bottom: 1px solid black;
            }

            .items_table tbody tr {
                border-bottom: 1px dotted black;
            }

            .items_table th,
            .items_table td {
                padding: 5px;
                text-align: left;
            }

            .items_table th {
                background-color: #f9f9f9;
                font-weight: bold;
            }

        .tong {
            margin-top: 10px;
            font-size: 12px;
            text-align: left;
        }

            .tong p {
                margin: 5px 0;
            }

            .tong span {
                float: right;
            }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="hoaDon">
            <h2 class="ten">Tiên Lữ Quán</h2>
            <p class="diaChi">Nội thị 2 - TT.Vương - Tiên Lữ - Hưng Yên</p>
            <p class="phone">+8488888888</p>

            <h3 class="hoaDon-tieuDe">Phiếu Thanh Toán</h3>
            <p class="hoaDon-so" id="txtOrderID" runat="server"></p>
            <p style="display: flex; justify-content: space-between;" class="ngayTao">
                Ngày tạo: <span id="txtOrderDate" runat="server"></span>
            </p>
            <table class="items_table">
                <thead>
                    <tr>
                        <th>Tên</th>
                        <th>SL</th>
                        <th>Giá</th>
                        <th>Tổng</th>
                    </tr>
                </thead>
                <tbody id="tbody_content" runat="server">
                </tbody>
            </table>

            <div class="tong">
                <p><strong>Tổng thanh toán: <span id="txtTotalMoney" runat="server"></span></strong></p>
            </div>

        </div>
    </form>
</body>

</html>
