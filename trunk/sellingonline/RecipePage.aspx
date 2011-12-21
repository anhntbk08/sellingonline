<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RecipePage.aspx.cs" Inherits="RecipePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 115px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>
        Điền thông tin để kết thúc quá trình đặt hàng</h1>
    <table>
        <tr>
            <td class="style1">
                <label>
                    Họ Tên
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <label>
                    CMTND
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtCMT" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <label>
                    Số điện thoại
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <label>
                    Email
                </label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="style1">
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
            </td>
        </tr>
    </table>
    <div id ='ProductTable' runat="server"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" runat="Server">

</asp:Content>
