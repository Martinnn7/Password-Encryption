<%@ Page Title="" Language="C#" MasterPageFile="~/ProfilePage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Tabirao_LongQuiz.User.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 40%;
        border:solid
    }
    table tr td {
        padding: 5px;
    }
    table, th, td{
        border: 1px solid black;
        border-collapse: collapse;
    }
    .auto-style2 {
        width: 128px;
        text-align: right;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Email Address:</td>
            <td>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Name:</td>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Address:</td>
            <td>
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Phone Number:</td>
            <td>
                <asp:Label ID="lblNumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Password:</td>
            <td>
                <asp:Label ID="lblPassword" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
