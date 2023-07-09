<%@ Page Title="SearchOrder" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="Searchbyordernumber.aspx.cs" Inherits="YanivProject_Searchbyordernumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server">
    <center>
        <h1></h1><hr />
    <asp:Label ID="Label1" style="color:white;" runat="server" Text="Enter order id:"></asp:Label><asp:TextBox ID="txtorder" type="number" runat="server"></asp:TextBox><asp:Button ID="btncheek" runat="server" Text="Button" OnClick="Button1_Click" /><asp:Label ID="lblerr" runat="server" forecolor="red" Text="No matching order number"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="grdinfo" runat="server" style="color:coral; min-width:80%; border:groove;" ></asp:GridView>
    </asp:Panel></center>
</asp:Content>

