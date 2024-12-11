<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.product.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="editProduct.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container_child">
        <div class="title">
            <h2>Thêm thêm sản phẩm</h2>
        </div>
        <div class="form">
            <div class="mb-2">
                <label for="Product_Categori" class="form-label">Loại sản phẩm</label>
                <asp:DropDownList ID="cboProductCategory" runat="server" class="form-select">
                </asp:DropDownList>

            </div>
            <div class="mb-2">
                <label for="txtName" class="form-label">Tên Sản Phẩm</label>
                <input type="text" class="form-control" id="txtName" runat="server" required>
            </div>
            <div class="mb-2">
                <label for="txtDescribe" class="form-label">Mô Tả</label>
                <input type="text" class="form-control" id="txtDescribe" runat="server" required>
            </div>
            <div class="mb-2">
                <label for="txtPrice" class="form-label">Giá Sản Phẩm</label>
                <input type="number" class="form-control" id="txtPrice" runat="server" required>
            </div>
            <div class="mb-2">
                <label for="fImageUrl" class="form-label">Ảnh Sản Phẩm</label>
                <asp:FileUpload runat="server" ID="fImageUrl" />
            </div>
            <div class="mb-2">
                <label for="cboStatusSell" class="form-label">Trạng Thái</label>
                <asp:DropDownList ID="cboStatusSell" runat="server" class="form-select">
                </asp:DropDownList>

            </div>
            <input type="button" class="btninsert" id="btnCRUD" runat="server" onserverclick="btnCRUD_ServerClick" value="Lưu">
            <a style="margin-left: 10px;" href="./" class="btn btn-danger mb-2">Hủy</a>
        </div>
    </div>
</asp:Content>
