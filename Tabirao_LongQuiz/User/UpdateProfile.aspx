<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="Tabirao_LongQuiz.User.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 40%;
            border: solid
        }

        table tr td {
            padding: 5px;
        }

        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .auto-style2 {
            width: 128px;
            text-align: right;
        }
        .auto-style3 {
            width: 128px;
            text-align: right;
            height: 36px;
        }
        .auto-style4 {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Address:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddress" runat="server" Text="Update" OnClick="btnAddress_Click" />
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Phone Number:</td>
            <td>
                <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                <asp:Button ID="btnNumber" runat="server" Text="Update" OnClick="btnNumber_Click" />
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Password:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:Button ID="btnPassword" runat="server" Text="Update" OnClick="btnPassword_Click" />
                <asp:Label ID="lblPassword" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>
