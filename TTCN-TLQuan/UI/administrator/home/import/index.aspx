<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.import.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container_child">
        <h2 class="title_child">Nguyên liệu</h2>
        <div class="header_child">
            <a href="import.aspx">Nhập Nguyên liệu</a>
        </div>
        <div class="tb_load">
            <table>
                <thead>
                    <tr>
                        <th>Ngày Nhập</th>
                        <th>Người Nhập</th>
                        <th>Tổng tiền</th>
                        <th>Chức Năng</th>
                    </tr>
                </thead>
                <tbody id="imports_load">
                </tbody>
            </table>
        </div>
        <div class="pagination" id="pagination"></div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="import.js"></script>
</asp:Content>
