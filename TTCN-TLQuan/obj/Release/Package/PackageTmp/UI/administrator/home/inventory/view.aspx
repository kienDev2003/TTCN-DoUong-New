<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.inventory.view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="page-view-stock">
        <h1>Xem Tồn Kho</h1>
        <div class="action">
            <input type="button" id="backButton" value="Quay lại">
        </div>
        <table>
            <thead>
                <tr>
                    <th>Tên Nguyên Liệu</th>
                    <th>Số Lượng Hệ Thống</th>
                    <th>Số Lượng Thực Tế</th>
                </tr>
            </thead>
            <tbody id="viewStockTable">
                
            </tbody>
        </table>
        <div class="pagination" id="pagination" style="position: absolute;"></div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="view.js"></script>
</asp:Content>
