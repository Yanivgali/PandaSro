<%@ Page Title="Change admin info" Language="C#" MasterPageFile="~/YanivProject/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeAdminInfo.aspx.cs" Inherits="YanivProject_ChangeAdminInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MasterPage" Runat="Server"> 
    <asp:DropDownList runat="server" AutoPostBack="True" ID="ddlt">
        <asp:ListItem>Choose Info to change</asp:ListItem>
        <asp:ListItem>ChangeAdminName</asp:ListItem>
        <asp:ListItem>ChangePassword</asp:ListItem>
        <asp:ListItem>ChangeEmail</asp:ListItem>
    </asp:DropDownList>   
    <asp:Panel runat="server" ID="pnlEmail">
    <asp:Label ID="Label1" style="background-color:red; color:white;" runat="server" Text="Up date your Email:"></asp:Label><asp:TextBox ID="txtupEmail" runat="server"></asp:TextBox></asp:Panel>
    <asp:Panel runat="server" ID="pnlUsername">
    <asp:Label ID="Label2" style="background-color:red; color:white;" runat="server" Text="Up date your UserName:"></asp:Label><asp:TextBox ID="txtupdateAdminName" runat="server"></asp:TextBox></asp:Panel>
        <asp:Panel runat="server" ID="pnlPassword">
    <asp:Label ID="Label3" style="background-color:red; color:white;" runat="server" Text="Up date your Password:"></asp:Label><asp:TextBox ID="txtupdatepassword" runat="server"></asp:TextBox></asp:Panel>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="You need to change at least one thing pls try agian." ID="lblerr"></asp:Label>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="This UserName alredy in use." ID="lblusernamet"></asp:Label>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="This Email alredy in use/or not valid." ID="lblemailt"></asp:Label>
    <asp:Label style="background-color:red; color:white;" runat="server" Text="Your Id have been change successfully." ID="lblsucc"></asp:Label>
         <asp:Button runat="server" style="background-color:red; color:white;" ID="btnacc" OnClick="btnacc_Click" Text="Change Settings" />
</asp:Content>

