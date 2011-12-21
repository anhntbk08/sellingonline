<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RecipePage.aspx.cs" Inherits="RecipePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 115px;
        }
        .style2
        {
            width: 466px;
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
            <td class="style2">
                <asp:TextBox ID="txtName" runat="server" Width="139px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Bắt buộc phải nhập tên" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <label>
                    CMTND
                </label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtCMT" runat="server" Height="21px" Width="141px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                <label>
                    Số điện thoại
                </label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtPhone" runat="server" Height="22px" Width="141px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPhone" ErrorMessage="Bắt buộc nhập SDT" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtPhone" ErrorMessage="Định dạng không đúng" 
                    ForeColor="#FF3300" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <label>
                    Email
                </label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtEmail" runat="server" Height="22px" Width="140px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Định dạng không đúng" 
                    ForeColor="#FF3300" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr class="style1">
            <td>
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
            </td>
        </tr>
    </table>
    <div id ='ProductTable' runat="server"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AdditionalContent" runat="Server">

</asp:Content>
