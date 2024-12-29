<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="ketca.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.inventory.ketca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./styles.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <div id="page-end-shift">
        <h1>Kết Ca</h1>
        <div class="header_action">
            <div class="combobox-container">
                <input
                    type="text"
                    class="combobox-input"
                    id="comboboxInput"
                    placeholder="Tìm sản phẩm..."
                    oninput="filterData()"
                    onclick="toggleOptions(true)" />
                <div class="combobox-options" id="comboboxOptions"></div>
            </div>
            <div class="action">
                <input type="button" id="endShiftButton" onclick="end()" value="Kết thúc ca"></input>
                <input type="button" id="backButton" value="Quay lại">
            </div>
        </div>

        <table>
            <thead>
                <tr>
                    <th>Tên Nguyên Liệu</th>
                    <th>Số Lượng</th>
                    <th>Đơn vị tính</th>
                </tr>
            </thead>
            <tbody id="endShiftTable">
                <!-- Nội dung sẽ được thêm từ JavaScript -->
            </tbody>
        </table>
        <div class="pagination" id="pagination" style="position: absolute;"></div>


    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="endshift.js"></script>

</asp:Content>
