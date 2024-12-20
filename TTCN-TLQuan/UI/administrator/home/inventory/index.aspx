﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.inventory.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="page-stock">
        <h1>Quản Lý Tồn Kho</h1>
        <div class="action">
            <input type="button" id="endShiftButton" onclick="end()" value="Kết thúc ca"></input>
        </div>
        <div class="date-filter">
            <label for="datePicker">Xem tồn kho ngày:</label>
            <input type="date" id="datePicker" />
            <input type="button" id="btntimkiem" onclick="btntimkiem()" value="Tìm Kiếm" />
        </div>
        <table>
            <thead>
                <tr>
                    <th>Nhân viên</th>
                    <th>Ngày cập nhật</th>
                    <th>Chức năng</th>
                </tr>
            </thead>
            <tbody id="stockTable">
                <!-- Nội dung sẽ được thêm từ JavaScript -->
            </tbody>
        </table>
        <div class="pagination" id="pagination" style="position: absolute;"></div>
    </div>
    <script src="index.js"></script>
</asp:Content>
