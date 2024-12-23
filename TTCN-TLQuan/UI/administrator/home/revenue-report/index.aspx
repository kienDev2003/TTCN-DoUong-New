<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.revenue_report.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./bctk.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="body_child">
        <h1>Thống kê doanh thu</h1>
        <div style="display: flex; justify-content: space-between; width: 100%; padding: 10px 0px; align-items: center;">
            <div class="date">
                <div>
                    <span>Từ ngày</span><input type="date" name="" id="">
                </div>
                <div>
                    <span>Đến ngày</span><input type="date" name="" id="">
                </div>
            </div>
            <div class="chucNang">
                <input type="button" value="Lọc">
            </div>

        </div>

        <table>
            <thead>
                <tr>
                    <th>Bàn</th>
                    <th>Thời gian </th>
                    <th>Kiểu thanh toán</th>
                    <th>Tổng tiền</th>
                    <th>Chức năng</th>
                </tr>
            </thead>
            <tbody id="table_container">
            </tbody>
        </table>
        <div class="pagination" id="pagination" style="position: absolute;"></div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="./order.js"></script>
</asp:Content>
