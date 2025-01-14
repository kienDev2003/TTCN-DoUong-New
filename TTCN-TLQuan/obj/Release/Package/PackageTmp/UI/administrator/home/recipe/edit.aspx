﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/administrator/home/master/Layout.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TTCN_TLQuan.UI.administrator.home.recipe.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container_child {
            background-color: #fff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            border-radius: 10px;
            overflow: hidden;
        }
        /* Header */
        .header_child {
            background-color: #657a71;
            color: white;
            padding: 20px;
            font-size: 18px;
            line-height: 30px;
        }

            .header_child label {
                font-weight: bold;
            }

            .header_child span {
                font-style: italic;
                font-weight: normal;
            }

        /* Body */

        /* Table */
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

            table th,
            table td {
                border: 1px solid #ddd;
                text-align: center;
                padding: 10px;
            }

            table th {
                background-color: #657a71;
                color: white;
                font-weight: bold;
            }

            table tbody tr:nth-child(even) {
                background-color: #f9f9f9;
            }

        .exit svg {
            width: 30px;
            height: 30px;
            position: fixed;
            z-index: 1000;
            right: 27px;
            border: 1px solid black;
            border-radius: 50%;
            padding: 2px;
        }

        .pagination {
            display: inline-block;
            padding: 10px;
            bottom: 0;
            left: 0;
            width: 100%;
            background-color: #fff;
            text-align: center;
            border-top: 1px solid #ddd;
        }

            .pagination a {
                padding: 8px 16px;
                margin: 4px;
                text-decoration: none;
                border: 1px solid #ddd;
                border-radius: 4px;
                color: #007bff;
            }

                .pagination a:hover {
                    background-color: #ddd;
                }

            .pagination .active {
                background-color: #007bff;
                color: white;
            }

            .pagination .disabled {
                pointer-events: none;
                color: #ccc;
            }

        .search_child {
            display: flex;
            align-items: center;
            margin-top: 10px;
        }

            .search_child input[type="search"] {
                padding: 8px 10px;
                border: 1px solid #ddd;
                border-radius: 5px;
                margin-right: 10px;
                font-size: 14px;
            }

            .search_child input[type="Date"] {
                padding: 8px 10px;
                border: 1px solid #ddd;
                border-radius: 5px;
                margin-right: 10px;
                font-size: 14px;
                ;
            }

            .search_child button {
                padding: 8px 15px;
                background-color: #3f66d9;
                color: #fff;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                font-size: 14px;
                transition: background-color 0.3s ease;
            }

                .search_child button:hover {
                    background-color: #5750b6;
                }

        .body_child {
            display: flex;
            justify-content: space-between;
        }

        .ingredint {
            display: flex;
            flex-direction: row;
            align-items: center;
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            padding: 16px;
            margin: 11px 0;
            border-radius: 8px;
        }

        .ingredint_item {
            flex: 1;
        }

            .ingredint_item h2 {
                font-size: 24px;
                font-weight: bold;
                margin-bottom: 8px;
            }

            .ingredint_item p {
                font-size: 20px;
            }

        button {
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 8px;
            padding: 10px 16px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        .table_container:first-child {
            max-height: 490px; /* Điều chỉnh chiều cao tối đa */
            overflow-y: auto;
        }

        input[type="button"] {
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

        input[type="number"] {
            padding: 10px 15px;
            cursor: pointer;
            height: fit-content;
            width: auto;
            margin: auto 20px;
            border-radius: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container_child">
        <div class="header_child">
            <div class="exit">
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
                    <path
                        d="M438.6 278.6c12.5-12.5 12.5-32.8 0-45.3l-160-160c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3L338.8 224 32 224c-17.7 0-32 14.3-32 32s14.3 32 32 32l306.7 0L233.4 393.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0l160-160z" />
                </svg>
            </div>
            <label for="User_FullName">Tên sản phẩm : </label>
            <span id="User_FullName" runat="server">Trà chanh quất</span>
            <br>
        </div>
        <div class="body_child">
            <div class="table_container" style="width: 30%;">
                <table>
                    <tbody id="load_ingredint">
                        <tr>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="table_container" style="width: 69%;">
                <table>
                    <thead>
                        <tr>
                            <th>Tên nguyên liệu</th>
                            <th>Số lượng cần dùng </th>
                            <th>Đơn vị tính</th>
                        </tr>
                    </thead>
                    <tbody id="E_imports_load">
                    </tbody>
                </table>
            </div>
        </div>
        <input type="button" value="Lưu" onclick="btnLuu()" />
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="editRecipe.js"></script>
</asp:Content>
