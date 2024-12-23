<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.revenue_report.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./bctk.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h1>Thống kê doanh thu</h1>

    <div style="display: flex; justify-content: space-between; width: 100%; margin: 0 auto;">
        <div class="date">
            <div>
                <span>Từ ngày</span><input style="margin-right: 100px;" type="date" name="" id="">
            </div>
            <div>
                <span>Đến ngày</span><input type="date" name="" id="">
            </div>
        </div>
        <div class="chucNang">
            <input type="button" value="Lọc">
        </div>
    </div>

    <table id="table_container">
        <thead>
            <tr>
                <th>Id</th>
                <th>Thời gian </th>
                <th>Kiểu thanh toán</th>
                <th>Bàn</th>
                <th>Tổng tiền</th>
                <th>Chức năng</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>
    <div class="pagination" id="pagination"></div>
    <script src="./order.js"></script>
</asp:Content>
